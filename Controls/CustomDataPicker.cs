using System;
using System.Drawing;
using System.Windows.Forms;

namespace program.Controls
{
    public class CustomDatePicker : DateTimePicker
    {
        private Color _backColor = Color.Wheat;
        private Color _foreColor = Color.Black;
        private Color _borderColor = Color.DimGray;
        private Color _arrowColor = Color.DimGray;

        public CustomDatePicker()
        {
            // Устанавливаем стили для перерисовки
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        public override Color BackColor
        {
            get => _backColor;
            set { _backColor = value; Invalidate(); }
        }

        public override Color ForeColor
        {
            get => _foreColor;
            set { _foreColor = value; Invalidate(); }
        }

        // Самая важная часть: перехватываем системное сообщение о прорисовке (WM_PAINT = 0xF)
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0xF) // WM_PAINT
            {
                // Сначала даем системе отрисовать стандартный контроль (чтобы обновилось состояние)
                base.WndProc(ref m);

                // А затем рисуем ПОВЕРХ него нашу графику
                using (Graphics g = Graphics.FromHwnd(this.Handle))
                {
                    OnPaint(new PaintEventArgs(g, ClientRectangle));
                }
                return;
            }
            base.WndProc(ref m);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush backBrush = new SolidBrush(_backColor))
            using (SolidBrush textBrush = new SolidBrush(_foreColor))
            using (Pen borderPen = new Pen(_borderColor))
            using (SolidBrush arrowBrush = new SolidBrush(_arrowColor))
            {
                // 1. Заливаем фон
                e.Graphics.FillRectangle(backBrush, ClientRectangle);

                // 2. Рисуем текст даты
                // Отступаем немного слева (5px), чтобы текст не прилипал к краю
                Rectangle textRect = new Rectangle(5, 0, ClientRectangle.Width - 35, ClientRectangle.Height);

                // Рисуем текст (Value.ToLongDateString() или просто Text)
                TextRenderer.DrawText(e.Graphics, Text, Font, textRect, _foreColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);

                // 3. Рисуем кнопку со стрелочкой справа
                Rectangle btnRect = new Rectangle(ClientRectangle.Width - 25, 0, 25, ClientRectangle.Height);

                // Координаты треугольника (стрелки)
                Point[] arrows = new Point[] {
                    new Point(btnRect.Left + 8, btnRect.Top + (btnRect.Height / 2) - 2),
                    new Point(btnRect.Left + 18, btnRect.Top + (btnRect.Height / 2) - 2),
                    new Point(btnRect.Left + 13, btnRect.Top + (btnRect.Height / 2) + 3)
                };
                e.Graphics.FillPolygon(arrowBrush, arrows);

                // 4. Рисуем рамку вокруг
                e.Graphics.DrawRectangle(borderPen, 0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            }
        }
    }
}