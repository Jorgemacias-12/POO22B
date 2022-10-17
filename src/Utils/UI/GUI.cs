using System.Drawing;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Utils.GUI
{
    public class UI
    {
        public static void PaintBorder(Control Component, Color BorderColor, int BorderSize,
                                       bool LeftVisible, bool TopVisible, bool RightVisible,
                                       bool BottomVisible)
        {
            Rectangle ComponentRect;
            ButtonBorderStyle BorderStyle;

            ComponentRect = new Rectangle(new Point(0, 0), Component.Size);
            BorderStyle = ButtonBorderStyle.Solid;

            ControlPaint.DrawBorder(Component.CreateGraphics(),
                                    ComponentRect,
                                    BorderColor,
                                    BorderSize, // left
                                    BorderStyle,
                                    BorderColor,
                                    BorderSize, // top
                                    BorderStyle,
                                    BorderColor,
                                    BorderSize, // right
                                    BorderStyle,
                                    BorderColor,
                                    BorderSize, // bottom
                                    BorderStyle);

        }

        private static void PaintBorderDelegate()
        {

        }

    }
}
