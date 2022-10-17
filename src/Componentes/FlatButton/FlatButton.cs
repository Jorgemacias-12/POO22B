using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace POO22B_MZJA.src.FButton
{
    public partial class FlatButton : Button
    {
        [
         Browsable(true),
         Category("Appearance"),
         Description("Color to be applied when cursor is on the button")
        ]
        public Color HoverColor
        {
            get; set;
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Allow to enable visual styles on hover")]
        public bool HoverEnabled
        {
            get; set;
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Color applied to the border of the button")]
        public Color BorderColor
        {
            get; set;
        }



        // TODO: implement the code commented in antoher new component
        // called FToggleButton

        //[
        // Browsable(true),
        // Category("Appearance"),
        // Description("Color to be applied when the mouse clicked the button")
        //]
        //public Color ClickedColor
        //{
        //    get; set;
        //}

        //public bool IsActive
        //{
        //    get; set;
        //}

        // It stores the old value of backColor used in mousevents
        private Color OldColor;

        public FlatButton()
        {
            InitializeComponent();
            InitProperties();
        }

        private void InitProperties()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderColor = BorderColor;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (HoverEnabled)
            {
                OldColor = BackColor;
                BackColor = HoverColor;
                Cursor = Cursors.Hand;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (HoverEnabled)
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
