using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POO22B_MZJA.src.FButton;
using POO22B_MZJA.src.FToggleButton;
using Timer = System.Windows.Forms.Timer;

namespace POO22B_MZJA.src.NavigationBar
{
    public partial class NavigationBar : FlowLayoutPanel
    {
        private const int DEFAULT_ITEM_HEIGH = 65;
        private FlatToggleButton NavigationItem;
        private Font Poppins;

        [Browsable(true)]
        [Category("Design")]
        public Label HeaderLabel
        {
            get; set;
        }

        public int NumberOfItems
        {
            get; set;
        }

        [Browsable(true)]
        [Category("Design")]
        public Image ItemIcon
        {
            get; set;
        }

        [Browsable(true)]
        [Category("Content source")]
        public TabControl TabContentContainer
        {
            get; set;
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Background Color of the Tab")]
        public Color ItemBackColor
        {
            get; set;
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("When the Tab has the state active this color will be applied")]
        public Color ItemActiveColor
        {
            get; set;
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("When the move is hover him this color will be applied")]
        public Color ItemHoverColor
        {
            get; set;
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Foreground color of the buttons/items")]
        public Color ItemForeColor
        {
            get; set;
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Item width")]
        public int ItemWidth
        {
            get; set;
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Item height")]
        public int ItemHeight
        {
            get; set;
        }

        [Browsable(true)]
        [Category("Design")]
        public string ItemPrefixName
        {
            get; set;
        }

        public NavigationBar()
        {
            InitializeComponent();
            InitProperties();
        }

        private void InitProperties()
        {
            HorizontalScroll.Maximum = 0;
            AutoScroll = false;
            AutoScrollMinSize = new Size(10, Height);
            VerticalScroll.Maximum = 5;
            VerticalScroll.Minimum = 5;
            VerticalScroll.Visible = false;
            AutoScroll = true;

            ItemPrefixName = "";

            Padding = new Padding(10, 0, 10, 0);

            Poppins = new Font("Poppins", 12, FontStyle.Regular);

        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (TabContentContainer is null)
            {
                NumberOfItems = 2;
                return;
            }

            FlatToggleButton Tab;

            NumberOfItems = TabContentContainer.TabPages.Count; // This was a mess, I hate you past Jorge.

            for (int i = 0; i < NumberOfItems; i++)
            {
                NavigationItem = new FlatToggleButton()
                {
                    AutoSize = true,
                    Name = i.ToString(),
                    Text = ItemPrefixName == string.Empty ? $"ToggleButton {i}" : $"{ItemPrefixName} {i + 1}",
                    OldColor = ItemBackColor,
                    ActiveColor = ItemActiveColor,
                    HoverColor = ItemHoverColor,
                    Anchor = AnchorStyles.None,
                    Width = ItemWidth > 0 ? ItemWidth : this.Width - 40,
                    Height = ItemHeight > 0 ? ItemHeight : DEFAULT_ITEM_HEIGH,
                    ForeColor = ItemForeColor,
                    Image = ItemIcon,
                    ImageAlign = ContentAlignment.MiddleLeft,
                    Font = Poppins,
                    OverrideMethod = true,
                };

                NavigationItem.Click += ChangeTab;

                Controls.Add(NavigationItem);
                Update();
            }

            Tab = (FlatToggleButton)this.Controls[0];

            Tab.BackColor = ItemActiveColor;

        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
        }

        private void ChangeTab(object sender, EventArgs e)
        {
            if (sender is null) return;
            if (TabContentContainer is null) return;
            if (HeaderLabel is null) return;

            FlatToggleButton CurrentTab;

            foreach (FlatToggleButton item in Controls)
            {
                item.IsActive = false;
                item.BackColor = BackColor;
            }

            CurrentTab = (FlatToggleButton)sender;

            CurrentTab.IsActive = true;
            CurrentTab.BackColor = ItemActiveColor;

            HeaderLabel.Text = $"{CurrentTab.Text}";

            TabContentContainer.SelectedIndex = Convert.ToInt32(CurrentTab.Name);

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
