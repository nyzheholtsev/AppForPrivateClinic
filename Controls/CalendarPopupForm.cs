using System.Drawing.Drawing2D;
using program.Localization;

namespace program.Controls
{
    public class CalendarPopupForm : Form
    {
        public event Action<DateTime> DateSelected;

        private DateTime _displayDate;
        private DateTime _selectedDate;

        public DateTime MinDate { get; set; } = DateTime.MinValue;
        public DateTime MaxDate { get; set; } = DateTime.MaxValue;

        private enum CalendarView { Days, Years }
        private CalendarView _currentView = CalendarView.Days;

        private string[] _monthNames;
        private string[] _dayNames;

        private Rectangle _btnPrevRect;
        private Rectangle _btnNextRect;
        private Rectangle _headerRect;

        private Point _mouseLocation = new Point(-1, -1);

        private Font _headerFont;
        private Font _dayFont;
        private Color _hoverColor = Color.FromArgb(100, 100, 100);
        private Color _disabledColor = Color.DimGray;

        public CalendarPopupForm(DateTime initialDate)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.DoubleBuffered = true;
            this.BackColor = Color.Gray;
            this.Size = new Size(300, 260);

            _selectedDate = initialDate;
            _displayDate = initialDate;

            LoadLocalizedStrings();

            _headerFont = new Font("Palatino Linotype", 11f, FontStyle.Bold);
            _dayFont = new Font("Segoe UI", 9f, FontStyle.Regular);

            this.Deactivate += (s, e) => this.Close();
            this.KeyPreview = true;
            this.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Escape) this.Close();
            };
        }

        private void LoadLocalizedStrings()
        {
            _monthNames = LocalizationManager.GetStringArray("Calendar_Months");
            _dayNames = LocalizationManager.GetStringArray("Calendar_Days");

            if (_monthNames == null || _monthNames.Length < 12)
                _monthNames = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };

            if (_dayNames == null || _dayNames.Length < 7)
                _dayNames = new[] { "Mo", "Tu", "We", "Th", "Fr", "Sa", "Su" };
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            _mouseLocation = e.Location;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _mouseLocation = new Point(-1, -1);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            using (Pen p = new Pen(Color.DimGray, 2))
            {
                e.Graphics.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
            }

            DrawHeader(e.Graphics);

            if (_currentView == CalendarView.Days)
            {
                DrawDays(e.Graphics);
            }
            else
            {
                DrawYears(e.Graphics);
            }
        }

        private void DrawHeader(Graphics g)
        {
            int headerHeight = 40;
            string title = "";

            if (_currentView == CalendarView.Days)
            {
                string monthName = _monthNames[_displayDate.Month - 1];
                title = $"{monthName} {_displayDate.Year}";
            }
            else
            {
                int startYear = _displayDate.Year - (_displayDate.Year % 12);
                title = $"{startYear} - {startYear + 11}";
            }

            _headerRect = new Rectangle(40, 0, Width - 80, headerHeight);

            if (_headerRect.Contains(_mouseLocation))
            {
                using (SolidBrush b = new SolidBrush(_hoverColor))
                    g.FillRectangle(b, _headerRect);
            }

            TextRenderer.DrawText(g, title, _headerFont, _headerRect, Color.Wheat,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            int arrowSize = 20;
            _btnPrevRect = new Rectangle(10, (headerHeight - arrowSize) / 2, arrowSize, arrowSize);
            _btnNextRect = new Rectangle(Width - 10 - arrowSize, (headerHeight - arrowSize) / 2, arrowSize, arrowSize);

            Brush prevBrush = _btnPrevRect.Contains(_mouseLocation) ? Brushes.White : Brushes.Wheat;
            Brush nextBrush = _btnNextRect.Contains(_mouseLocation) ? Brushes.White : Brushes.Wheat;

            g.FillPolygon(prevBrush, new Point[] {
                new Point(_btnPrevRect.Right, _btnPrevRect.Top),
                new Point(_btnPrevRect.Left, _btnPrevRect.Top + arrowSize/2),
                new Point(_btnPrevRect.Right, _btnPrevRect.Bottom)
            });

            g.FillPolygon(nextBrush, new Point[] {
                new Point(_btnNextRect.Left, _btnNextRect.Top),
                new Point(_btnNextRect.Right, _btnNextRect.Top + arrowSize/2),
                new Point(_btnNextRect.Left, _btnNextRect.Bottom)
            });
        }

        private void DrawDays(Graphics g)
        {
            int headerHeight = 40;
            string[] days = _dayNames;

            int cellWidth = (Width - 20) / 7;
            int cellHeight = 30;
            int startX = 10;
            int startY = headerHeight;

            for (int i = 0; i < 7; i++)
            {
                Rectangle r = new Rectangle(startX + i * cellWidth, startY, cellWidth, cellHeight);
                TextRenderer.DrawText(g, days[i], _dayFont, r, Color.Wheat,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }

            startY += cellHeight;
            DateTime firstDay = new DateTime(_displayDate.Year, _displayDate.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(_displayDate.Year, _displayDate.Month);

            int dayOfWeek = (int)firstDay.DayOfWeek;
            if (dayOfWeek == 0) dayOfWeek = 7;
            dayOfWeek -= 1;

            for (int day = 1; day <= daysInMonth; day++)
            {
                int row = dayOfWeek / 7;
                int col = dayOfWeek % 7;

                Rectangle cellRect = new Rectangle(startX + col * cellWidth, startY + row * cellHeight, cellWidth, cellHeight);

                DateTime currentDayDate = new DateTime(_displayDate.Year, _displayDate.Month, day);
                bool isDisabled = currentDayDate.Date < MinDate.Date || currentDayDate.Date > MaxDate.Date;

                bool isSelected = (_displayDate.Year == _selectedDate.Year &&
                                   _displayDate.Month == _selectedDate.Month &&
                                   day == _selectedDate.Day);

                if (isDisabled)
                {
                    TextRenderer.DrawText(g, day.ToString(), _dayFont, cellRect, _disabledColor, //плохие дни
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
                else
                {
                    
                    if (isSelected)
                    {
                        using (Pen p = new Pen(Color.Wheat, 2))// хорошие 
                            g.DrawRectangle(p, cellRect.X + 2, cellRect.Y + 2, cellRect.Width - 4, cellRect.Height - 4);
                    }
                    else if (cellRect.Contains(_mouseLocation))
                    {
                        using (SolidBrush b = new SolidBrush(_hoverColor))
                            g.FillRectangle(b, cellRect);
                    }

                    TextRenderer.DrawText(g, day.ToString(), _dayFont, cellRect, Color.Wheat,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }

                dayOfWeek++;
            }
        }

        private void DrawYears(Graphics g)
        {
            int headerHeight = 40;
            int startX = 10;
            int startY = headerHeight + 10;
            int cellWidth = (Width - 20) / 4;
            int cellHeight = (Height - headerHeight - 20) / 3;

            int startYear = _displayDate.Year - (_displayDate.Year % 12);

            for (int i = 0; i < 12; i++)
            {
                int year = startYear + i;
                int row = i / 4;
                int col = i % 4;

                Rectangle cellRect = new Rectangle(startX + col * cellWidth, startY + row * cellHeight, cellWidth, cellHeight);

                if (year == _selectedDate.Year)
                {
                    using (Pen p = new Pen(Color.Wheat, 2))
                        g.DrawRectangle(p, cellRect.X + 4, cellRect.Y + 4, cellRect.Width - 8, cellRect.Height - 8);
                }
                else if (cellRect.Contains(_mouseLocation))
                {
                    using (SolidBrush b = new SolidBrush(_hoverColor))
                        g.FillRectangle(b, cellRect);
                }

                TextRenderer.DrawText(g, year.ToString(), _headerFont, cellRect, Color.Wheat,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (_headerRect.Contains(e.Location))
            {
                _currentView = (_currentView == CalendarView.Days) ? CalendarView.Years : CalendarView.Days;
                Invalidate();
                return;
            }

            if (_btnPrevRect.Contains(e.Location))
            {
                if (_currentView == CalendarView.Days) _displayDate = _displayDate.AddMonths(-1);
                else _displayDate = _displayDate.AddYears(-12);
                Invalidate();
                return;
            }
            if (_btnNextRect.Contains(e.Location))
            {
                if (_currentView == CalendarView.Days) _displayDate = _displayDate.AddMonths(1);
                else _displayDate = _displayDate.AddYears(12);
                Invalidate();
                return;
            }

            int headerHeight = 40;

            if (_currentView == CalendarView.Days)
            {
                int cellWidth = (Width - 20) / 7;
                int cellHeight = 30;
                int startX = 10;
                int startY = headerHeight + 30;

                if (e.Y > startY && e.X > startX && e.X < startX + 7 * cellWidth)
                {
                    int row = (e.Y - startY) / cellHeight; //верт
                    int col = (e.X - startX) / cellWidth;  //гор

                    DateTime firstDay = new DateTime(_displayDate.Year, _displayDate.Month, 1);
                    int offset = (int)firstDay.DayOfWeek;
                    if (offset == 0) offset = 7; //неделя с пн
                    offset -= 1; // -1 инд

                    int dayNum = (row * 7 + col) - offset + 1;

                    if (dayNum >= 1 && dayNum <= DateTime.DaysInMonth(_displayDate.Year, _displayDate.Month))
                    {
                        DateTime clickedDate = new DateTime(_displayDate.Year, _displayDate.Month, dayNum);

                        if (clickedDate.Date >= MinDate.Date && clickedDate.Date <= MaxDate.Date)// валид
                        {
                            DateSelected?.Invoke(clickedDate); // передаём
                            this.Close(); // закрываем
                        }
                    }
                }
            }
            else
            {
                int cellWidth = (Width - 20) / 4;
                int cellHeight = (Height - headerHeight - 20) / 3;
                int startX = 10;
                int startY = headerHeight + 10;

                if (e.Y > startY && e.Y < startY + 3 * cellHeight)
                {
                    int row = (e.Y - startY) / cellHeight;
                    int col = (e.X - startX) / cellWidth;

                    int startYear = _displayDate.Year - (_displayDate.Year % 12);
                    _displayDate = new DateTime(startYear + (row * 4 + col), _displayDate.Month, 1);
                    _currentView = CalendarView.Days;
                    Invalidate();
                }
            }
        }
    }
}