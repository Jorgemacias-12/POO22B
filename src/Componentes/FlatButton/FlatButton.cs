using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            FlatAppearance.BorderSize = 0;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            OldColor = BackColor;
            BackColor = HoverColor;
            Cursor = Cursors.Hand;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            BackColor = OldColor;
        }
        
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
