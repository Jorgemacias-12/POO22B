using POO22B_MZJA.src.Utils;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace POO22B_MZJA.src.FToggleButton
{
    public partial class FlatToggleButton : Button
    {

        public bool OverrideMethod
        {
            get; set;
        }

        public bool IsActive
        {
            get; set;
        }

        public Color OldColor
        {
            get; set;
        }

        [
         Browsable(true),
         Category("Appearance"),
         Description("Color to be applied when the button is Active")
        ]
        public Color ActiveColor
        {
            get; set;
        }

        [
         Browsable(true),
         Category("Appearance"),
         Description("This color will be applied when the mouse is over the button")
        ]
        public Color HoverColor
        {
            get; set;
        }

        public FlatToggleButton()
        {
            InitializeComponent();
            InitProperties();
        }

        private void InitProperties()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            IsActive = false;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (!OverrideMethod)
            {
                IsActive = !IsActive;

                if (!IsActive)
                {
                    BackColor = OldColor;
                    ForeColor = ColorUtils.GetForegroundColor(BackColor);
                }

                if (IsActive)
                {
                    BackColor = ActiveColor;
                    ForeColor = ColorUtils.GetForegroundColor(BackColor);
                }
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if (!IsActive)
            {
                OldColor = BackColor;
                BackColor = HoverColor;
            }

            Cursor = Cursors.Hand;

        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (!IsActive)
            {
                BackColor = OldColor;
            }

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
