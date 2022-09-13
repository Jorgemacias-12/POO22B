using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO22B_MZJA.src.TabPanel
{
    public partial class TabPanel : TabControl
    {

        private const int TCM_ADJUSTRECT = 0x1328;

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Color that will be applied to the tab pages")]
        public Color TabsBackColor
        {
            get; set;
        }

        public TabPanel()
        {
            InitializeComponent();

        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == TCM_ADJUSTRECT && !DesignMode) m.Result = (IntPtr)1;
            else base.WndProc(ref m);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            foreach(TabPage Tab in TabPages)
            {
                Tab.BackColor = TabsBackColor;
            }

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
