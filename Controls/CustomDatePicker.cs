using program.Localization;

namespace program.Controls
{
    public class CustomDatePicker : Control, Localizable
    {
        public event EventHandler ValueChanged;
            
        private DateTime _value = DateTime.Now;
        public DateTime MinDate { get; set; } = DateTime.MinValue;
        public DateTime MaxDate { get; set; } = DateTime.MaxValue;

        private Color _backColor = Color.Wheat;
        private Color _foreColor = Color.Black;
        private Color _borderColor = Color.DimGray;
        private Color _iconColor = Color.DimGray;


        public CustomDatePicker()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.Selectable, true);

            this.Cursor = Cursors.Hand;
            this.Size = new Size(200, 30);
            this.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Regular);
        }

        public DateTime Value
        {
            get => _value;
            set
            {
                _value = value;
                Invalidate();

                ValueChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void UpdateLocalization()
        {
            Invalidate(); // Перерисовка для обновления языка
        }


        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            CalendarPopupForm popup = new CalendarPopupForm(_value);

            popup.MinDate = this.MinDate; // -> в календарь 
            popup.MaxDate = this.MaxDate; // -> в календарь 

            Point screenLocation = this.PointToScreen(new Point(0, this.Height));
            popup.Location = screenLocation;

            popup.DateSelected += (newDate) =>
            {
                this.Value = newDate;
                popup.Close();
            };

            popup.Show();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (SolidBrush backBrush = new SolidBrush(_backColor))
            using (SolidBrush textBrush = new SolidBrush(_foreColor))
            using (Pen borderPen = new Pen(_borderColor))
            using (SolidBrush iconBrush = new SolidBrush(_iconColor))
            {
                
                e.Graphics.FillRectangle(backBrush, ClientRectangle); //Фон

                string[] months = LocalizationManager.GetStringArray("Calendar_Months");
                string monthName = "";

                if (months != null && months.Length == 12)
                {
                    monthName = months[_value.Month - 1];
                }
                else
                {
                    monthName = _value.ToString("MMMM");
                }

                string dateText = $"{_value.Day:00} {monthName} {_value.Year}";

                Rectangle textRect = new Rectangle(5, 0, ClientRectangle.Width - 30, ClientRectangle.Height);
                TextRenderer.DrawText(e.Graphics, dateText, this.Font, textRect, _foreColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);

                
                int iconSize = 16;
                int iconX = Width - 25;
                int iconY = (Height - iconSize) / 2;

                e.Graphics.DrawRectangle(new Pen(_iconColor, 2), iconX, iconY, iconSize, iconSize); // Иконка
                e.Graphics.FillRectangle(iconBrush, iconX, iconY, iconSize, 4);

                
                e.Graphics.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);//Рамка
            }
        }
    }
}