namespace POO22B_MZJA
{
    partial class DlgPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.PnlAppContainer = new System.Windows.Forms.Panel();
            this.PnlSidebar = new System.Windows.Forms.Panel();
            this.LblTabIndicator = new System.Windows.Forms.Label();
            this.PnlInfoArea = new System.Windows.Forms.Panel();
            this.LblInfoText = new System.Windows.Forms.Label();
            this.PnlTopbar = new System.Windows.Forms.Panel();
            this.TpbPractices = new POO22B_MZJA.src.TabPanel.TabPanel();
            this.TbpPractice1 = new System.Windows.Forms.TabPage();
            this.TbpPractice2 = new System.Windows.Forms.TabPage();
            this.PnlP2Navigation = new System.Windows.Forms.Panel();
            this.FBtnPD = new POO22B_MZJA.src.FButton.FlatButton();
            this.FBtnPY = new POO22B_MZJA.src.FButton.FlatButton();
            this.FBtnP2PX = new POO22B_MZJA.src.FButton.FlatButton();
            this.PnlP2Container = new System.Windows.Forms.Panel();
            this.TbpPractice3 = new System.Windows.Forms.TabPage();
            this.TbpPractice4 = new System.Windows.Forms.TabPage();
            this.TbpPractice5 = new System.Windows.Forms.TabPage();
            this.TbpPractice6 = new System.Windows.Forms.TabPage();
            this.TbpPractice7 = new System.Windows.Forms.TabPage();
            this.TbpPractice8 = new System.Windows.Forms.TabPage();
            this.TbpPractice9 = new System.Windows.Forms.TabPage();
            this.TbpPractice10 = new System.Windows.Forms.TabPage();
            this.PnlNavPractices = new POO22B_MZJA.src.NavigationBar.NavigationBar();
            this.PbxInfoIcon = new System.Windows.Forms.PictureBox();
            this.FBtnOptions = new POO22B_MZJA.src.FButton.FlatButton();
            this.FBtnSidebar = new POO22B_MZJA.src.FButton.FlatButton();
            this.PnlAppContainer.SuspendLayout();
            this.PnlSidebar.SuspendLayout();
            this.PnlInfoArea.SuspendLayout();
            this.PnlTopbar.SuspendLayout();
            this.TpbPractices.SuspendLayout();
            this.TbpPractice2.SuspendLayout();
            this.PnlP2Navigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxInfoIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlAppContainer
            // 
            this.PnlAppContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.PnlAppContainer.Controls.Add(this.TpbPractices);
            this.PnlAppContainer.Controls.Add(this.PnlSidebar);
            this.PnlAppContainer.Controls.Add(this.PnlTopbar);
            this.PnlAppContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlAppContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlAppContainer.Location = new System.Drawing.Point(0, 0);
            this.PnlAppContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PnlAppContainer.Name = "PnlAppContainer";
            this.PnlAppContainer.Size = new System.Drawing.Size(1685, 838);
            this.PnlAppContainer.TabIndex = 0;
            // 
            // PnlSidebar
            // 
            this.PnlSidebar.Controls.Add(this.PnlNavPractices);
            this.PnlSidebar.Controls.Add(this.PnlInfoArea);
            this.PnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlSidebar.Location = new System.Drawing.Point(0, 62);
            this.PnlSidebar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PnlSidebar.Name = "PnlSidebar";
            this.PnlSidebar.Size = new System.Drawing.Size(333, 776);
            this.PnlSidebar.TabIndex = 1;
            // 
            // LblTabIndicator
            // 
            this.LblTabIndicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTabIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTabIndicator.Location = new System.Drawing.Point(81, 0);
            this.LblTabIndicator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTabIndicator.Name = "LblTabIndicator";
            this.LblTabIndicator.Size = new System.Drawing.Size(1523, 62);
            this.LblTabIndicator.TabIndex = 1;
            this.LblTabIndicator.Text = "Práctica 1";
            this.LblTabIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlInfoArea
            // 
            this.PnlInfoArea.Controls.Add(this.LblInfoText);
            this.PnlInfoArea.Controls.Add(this.PbxInfoIcon);
            this.PnlInfoArea.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlInfoArea.Location = new System.Drawing.Point(0, 0);
            this.PnlInfoArea.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PnlInfoArea.Name = "PnlInfoArea";
            this.PnlInfoArea.Size = new System.Drawing.Size(333, 64);
            this.PnlInfoArea.TabIndex = 0;
            // 
            // LblInfoText
            // 
            this.LblInfoText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblInfoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfoText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(193)))), ((int)(((byte)(179)))));
            this.LblInfoText.Location = new System.Drawing.Point(81, 0);
            this.LblInfoText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblInfoText.Name = "LblInfoText";
            this.LblInfoText.Size = new System.Drawing.Size(252, 64);
            this.LblInfoText.TabIndex = 1;
            this.LblInfoText.Text = "JAMZ";
            this.LblInfoText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlTopbar
            // 
            this.PnlTopbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(102)))));
            this.PnlTopbar.Controls.Add(this.LblTabIndicator);
            this.PnlTopbar.Controls.Add(this.FBtnOptions);
            this.PnlTopbar.Controls.Add(this.FBtnSidebar);
            this.PnlTopbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTopbar.Location = new System.Drawing.Point(0, 0);
            this.PnlTopbar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PnlTopbar.Name = "PnlTopbar";
            this.PnlTopbar.Size = new System.Drawing.Size(1685, 62);
            this.PnlTopbar.TabIndex = 0;
            // 
            // TpbPractices
            // 
            this.TpbPractices.Controls.Add(this.TbpPractice1);
            this.TpbPractices.Controls.Add(this.TbpPractice2);
            this.TpbPractices.Controls.Add(this.TbpPractice3);
            this.TpbPractices.Controls.Add(this.TbpPractice4);
            this.TpbPractices.Controls.Add(this.TbpPractice5);
            this.TpbPractices.Controls.Add(this.TbpPractice6);
            this.TpbPractices.Controls.Add(this.TbpPractice7);
            this.TpbPractices.Controls.Add(this.TbpPractice8);
            this.TpbPractices.Controls.Add(this.TbpPractice9);
            this.TpbPractices.Controls.Add(this.TbpPractice10);
            this.TpbPractices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TpbPractices.Location = new System.Drawing.Point(333, 62);
            this.TpbPractices.Margin = new System.Windows.Forms.Padding(4);
            this.TpbPractices.Name = "TpbPractices";
            this.TpbPractices.SelectedIndex = 0;
            this.TpbPractices.Size = new System.Drawing.Size(1352, 776);
            this.TpbPractices.TabIndex = 2;
            this.TpbPractices.TabsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            // 
            // TbpPractice1
            // 
            this.TbpPractice1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.TbpPractice1.Location = new System.Drawing.Point(4, 34);
            this.TbpPractice1.Margin = new System.Windows.Forms.Padding(4);
            this.TbpPractice1.Name = "TbpPractice1";
            this.TbpPractice1.Padding = new System.Windows.Forms.Padding(4);
            this.TbpPractice1.Size = new System.Drawing.Size(1344, 738);
            this.TbpPractice1.TabIndex = 0;
            this.TbpPractice1.Text = "Practice 1";
            // 
            // TbpPractice2
            // 
            this.TbpPractice2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.TbpPractice2.Controls.Add(this.PnlP2Navigation);
            this.TbpPractice2.Controls.Add(this.PnlP2Container);
            this.TbpPractice2.Location = new System.Drawing.Point(4, 34);
            this.TbpPractice2.Margin = new System.Windows.Forms.Padding(4);
            this.TbpPractice2.Name = "TbpPractice2";
            this.TbpPractice2.Padding = new System.Windows.Forms.Padding(4);
            this.TbpPractice2.Size = new System.Drawing.Size(1344, 738);
            this.TbpPractice2.TabIndex = 1;
            this.TbpPractice2.Text = "Practice 2";
            // 
            // PnlP2Navigation
            // 
            this.PnlP2Navigation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(95)))), ((int)(((byte)(92)))));
            this.PnlP2Navigation.Controls.Add(this.FBtnPD);
            this.PnlP2Navigation.Controls.Add(this.FBtnPY);
            this.PnlP2Navigation.Controls.Add(this.FBtnP2PX);
            this.PnlP2Navigation.Dock = System.Windows.Forms.DockStyle.Right;
            this.PnlP2Navigation.Location = new System.Drawing.Point(1219, 4);
            this.PnlP2Navigation.Margin = new System.Windows.Forms.Padding(4);
            this.PnlP2Navigation.Name = "PnlP2Navigation";
            this.PnlP2Navigation.Size = new System.Drawing.Size(121, 730);
            this.PnlP2Navigation.TabIndex = 1;
            // 
            // FBtnPD
            // 
            this.FBtnPD.Dock = System.Windows.Forms.DockStyle.Top;
            this.FBtnPD.FlatAppearance.BorderSize = 0;
            this.FBtnPD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FBtnPD.HoverColor = System.Drawing.Color.Empty;
            this.FBtnPD.Location = new System.Drawing.Point(0, 98);
            this.FBtnPD.Margin = new System.Windows.Forms.Padding(4);
            this.FBtnPD.Name = "FBtnPD";
            this.FBtnPD.Size = new System.Drawing.Size(121, 49);
            this.FBtnPD.TabIndex = 2;
            this.FBtnPD.Text = "PD";
            this.FBtnPD.UseVisualStyleBackColor = true;
            this.FBtnPD.Click += new System.EventHandler(this.FBtnPD_Click);
            // 
            // FBtnPY
            // 
            this.FBtnPY.Dock = System.Windows.Forms.DockStyle.Top;
            this.FBtnPY.FlatAppearance.BorderSize = 0;
            this.FBtnPY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FBtnPY.HoverColor = System.Drawing.Color.Empty;
            this.FBtnPY.Location = new System.Drawing.Point(0, 49);
            this.FBtnPY.Margin = new System.Windows.Forms.Padding(4);
            this.FBtnPY.Name = "FBtnPY";
            this.FBtnPY.Size = new System.Drawing.Size(121, 49);
            this.FBtnPY.TabIndex = 1;
            this.FBtnPY.Text = "PY";
            this.FBtnPY.UseVisualStyleBackColor = true;
            // 
            // FBtnP2PX
            // 
            this.FBtnP2PX.Dock = System.Windows.Forms.DockStyle.Top;
            this.FBtnP2PX.FlatAppearance.BorderSize = 0;
            this.FBtnP2PX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FBtnP2PX.HoverColor = System.Drawing.Color.Empty;
            this.FBtnP2PX.Location = new System.Drawing.Point(0, 0);
            this.FBtnP2PX.Margin = new System.Windows.Forms.Padding(4);
            this.FBtnP2PX.Name = "FBtnP2PX";
            this.FBtnP2PX.Size = new System.Drawing.Size(121, 49);
            this.FBtnP2PX.TabIndex = 0;
            this.FBtnP2PX.Text = "PX";
            this.FBtnP2PX.UseVisualStyleBackColor = true;
            // 
            // PnlP2Container
            // 
            this.PnlP2Container.Location = new System.Drawing.Point(4, 4);
            this.PnlP2Container.Margin = new System.Windows.Forms.Padding(4);
            this.PnlP2Container.Name = "PnlP2Container";
            this.PnlP2Container.Size = new System.Drawing.Size(1386, 711);
            this.PnlP2Container.TabIndex = 0;
            // 
            // TbpPractice3
            // 
            this.TbpPractice3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.TbpPractice3.Location = new System.Drawing.Point(4, 34);
            this.TbpPractice3.Margin = new System.Windows.Forms.Padding(4);
            this.TbpPractice3.Name = "TbpPractice3";
            this.TbpPractice3.Size = new System.Drawing.Size(1344, 738);
            this.TbpPractice3.TabIndex = 2;
            this.TbpPractice3.Text = "Practice 3";
            // 
            // TbpPractice4
            // 
            this.TbpPractice4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.TbpPractice4.Location = new System.Drawing.Point(4, 34);
            this.TbpPractice4.Margin = new System.Windows.Forms.Padding(4);
            this.TbpPractice4.Name = "TbpPractice4";
            this.TbpPractice4.Size = new System.Drawing.Size(1344, 738);
            this.TbpPractice4.TabIndex = 3;
            this.TbpPractice4.Text = "Practice 4";
            // 
            // TbpPractice5
            // 
            this.TbpPractice5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.TbpPractice5.Location = new System.Drawing.Point(4, 34);
            this.TbpPractice5.Margin = new System.Windows.Forms.Padding(4);
            this.TbpPractice5.Name = "TbpPractice5";
            this.TbpPractice5.Size = new System.Drawing.Size(1344, 738);
            this.TbpPractice5.TabIndex = 4;
            this.TbpPractice5.Text = "Practice 5";
            // 
            // TbpPractice6
            // 
            this.TbpPractice6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.TbpPractice6.Location = new System.Drawing.Point(4, 34);
            this.TbpPractice6.Margin = new System.Windows.Forms.Padding(4);
            this.TbpPractice6.Name = "TbpPractice6";
            this.TbpPractice6.Size = new System.Drawing.Size(1344, 738);
            this.TbpPractice6.TabIndex = 5;
            this.TbpPractice6.Text = "Practice 6";
            // 
            // TbpPractice7
            // 
            this.TbpPractice7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.TbpPractice7.Location = new System.Drawing.Point(4, 34);
            this.TbpPractice7.Margin = new System.Windows.Forms.Padding(4);
            this.TbpPractice7.Name = "TbpPractice7";
            this.TbpPractice7.Size = new System.Drawing.Size(1344, 738);
            this.TbpPractice7.TabIndex = 6;
            this.TbpPractice7.Text = "Practice 7";
            // 
            // TbpPractice8
            // 
            this.TbpPractice8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.TbpPractice8.Location = new System.Drawing.Point(4, 34);
            this.TbpPractice8.Margin = new System.Windows.Forms.Padding(4);
            this.TbpPractice8.Name = "TbpPractice8";
            this.TbpPractice8.Size = new System.Drawing.Size(1344, 738);
            this.TbpPractice8.TabIndex = 7;
            this.TbpPractice8.Text = "Practice 8";
            // 
            // TbpPractice9
            // 
            this.TbpPractice9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.TbpPractice9.Location = new System.Drawing.Point(4, 34);
            this.TbpPractice9.Margin = new System.Windows.Forms.Padding(4);
            this.TbpPractice9.Name = "TbpPractice9";
            this.TbpPractice9.Size = new System.Drawing.Size(1344, 738);
            this.TbpPractice9.TabIndex = 8;
            this.TbpPractice9.Text = "Practice 9";
            // 
            // TbpPractice10
            // 
            this.TbpPractice10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.TbpPractice10.Location = new System.Drawing.Point(4, 34);
            this.TbpPractice10.Margin = new System.Windows.Forms.Padding(4);
            this.TbpPractice10.Name = "TbpPractice10";
            this.TbpPractice10.Size = new System.Drawing.Size(1344, 738);
            this.TbpPractice10.TabIndex = 9;
            this.TbpPractice10.Text = "Practice 10";
            // 
            // PnlNavPractices
            // 
            this.PnlNavPractices.AutoScroll = true;
            this.PnlNavPractices.AutoScrollMinSize = new System.Drawing.Size(1, 0);
            this.PnlNavPractices.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PnlNavPractices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlNavPractices.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PnlNavPractices.HeaderLabel = this.LblTabIndicator;
            this.PnlNavPractices.ItemActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(68)))), ((int)(((byte)(255)))));
            this.PnlNavPractices.ItemBackColor = System.Drawing.Color.Empty;
            this.PnlNavPractices.ItemForeColor = System.Drawing.Color.White;
            this.PnlNavPractices.ItemHeight = 0;
            this.PnlNavPractices.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.PnlNavPractices.ItemIcon = global::POO22B_MZJA.Properties.Resources.document;
            this.PnlNavPractices.ItemPrefixName = "Práctica";
            this.PnlNavPractices.ItemWidth = 0;
            this.PnlNavPractices.Location = new System.Drawing.Point(0, 64);
            this.PnlNavPractices.Margin = new System.Windows.Forms.Padding(4);
            this.PnlNavPractices.Name = "PnlNavPractices";
            this.PnlNavPractices.NumberOfItems = 10;
            this.PnlNavPractices.Padding = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.PnlNavPractices.Size = new System.Drawing.Size(333, 712);
            this.PnlNavPractices.TabContentContainer = this.TpbPractices;
            this.PnlNavPractices.TabIndex = 1;
            this.PnlNavPractices.WrapContents = false;
            // 
            // PbxInfoIcon
            // 
            this.PbxInfoIcon.BackgroundImage = global::POO22B_MZJA.Properties.Resources.icecube;
            this.PbxInfoIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PbxInfoIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.PbxInfoIcon.Location = new System.Drawing.Point(0, 0);
            this.PbxInfoIcon.Margin = new System.Windows.Forms.Padding(4);
            this.PbxInfoIcon.Name = "PbxInfoIcon";
            this.PbxInfoIcon.Size = new System.Drawing.Size(81, 64);
            this.PbxInfoIcon.TabIndex = 0;
            this.PbxInfoIcon.TabStop = false;
            // 
            // FBtnOptions
            // 
            this.FBtnOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.FBtnOptions.FlatAppearance.BorderSize = 0;
            this.FBtnOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FBtnOptions.HoverColor = System.Drawing.Color.Empty;
            this.FBtnOptions.Image = global::POO22B_MZJA.Properties.Resources.fa_cog;
            this.FBtnOptions.Location = new System.Drawing.Point(1604, 0);
            this.FBtnOptions.Margin = new System.Windows.Forms.Padding(4);
            this.FBtnOptions.Name = "FBtnOptions";
            this.FBtnOptions.Size = new System.Drawing.Size(81, 62);
            this.FBtnOptions.TabIndex = 2;
            this.FBtnOptions.UseVisualStyleBackColor = true;
            // 
            // FBtnSidebar
            // 
            this.FBtnSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.FBtnSidebar.FlatAppearance.BorderSize = 0;
            this.FBtnSidebar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FBtnSidebar.HoverColor = System.Drawing.Color.Empty;
            this.FBtnSidebar.Image = global::POO22B_MZJA.Properties.Resources.bars_solid;
            this.FBtnSidebar.Location = new System.Drawing.Point(0, 0);
            this.FBtnSidebar.Margin = new System.Windows.Forms.Padding(4);
            this.FBtnSidebar.Name = "FBtnSidebar";
            this.FBtnSidebar.Size = new System.Drawing.Size(81, 62);
            this.FBtnSidebar.TabIndex = 0;
            this.FBtnSidebar.UseVisualStyleBackColor = true;
            // 
            // DlgPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1685, 838);
            this.Controls.Add(this.PnlAppContainer);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1701, 875);
            this.Name = "DlgPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JAMZ - POO22B";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.DlgPrincipal_Load);
            this.PnlAppContainer.ResumeLayout(false);
            this.PnlSidebar.ResumeLayout(false);
            this.PnlInfoArea.ResumeLayout(false);
            this.PnlTopbar.ResumeLayout(false);
            this.TpbPractices.ResumeLayout(false);
            this.TbpPractice2.ResumeLayout(false);
            this.PnlP2Navigation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbxInfoIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlAppContainer;
        private System.Windows.Forms.Panel PnlTopbar;
        private src.FButton.FlatButton FBtnSidebar;
        private System.Windows.Forms.Label LblTabIndicator;
        private src.FButton.FlatButton FBtnOptions;
        private System.Windows.Forms.Panel PnlSidebar;
        private System.Windows.Forms.Panel PnlInfoArea;
        private System.Windows.Forms.PictureBox PbxInfoIcon;
        private System.Windows.Forms.Label LblInfoText;
        private src.NavigationBar.NavigationBar PnlNavPractices;
        private src.TabPanel.TabPanel TpbPractices;
        private System.Windows.Forms.TabPage TbpPractice1;
        private System.Windows.Forms.TabPage TbpPractice2;
        private System.Windows.Forms.TabPage TbpPractice3;
        private System.Windows.Forms.TabPage TbpPractice4;
        private System.Windows.Forms.TabPage TbpPractice5;
        private System.Windows.Forms.TabPage TbpPractice6;
        private System.Windows.Forms.TabPage TbpPractice7;
        private System.Windows.Forms.TabPage TbpPractice8;
        private System.Windows.Forms.TabPage TbpPractice9;
        private System.Windows.Forms.TabPage TbpPractice10;
        private System.Windows.Forms.Panel PnlP2Container;
        private System.Windows.Forms.Panel PnlP2Navigation;
        private src.FButton.FlatButton FBtnP2PX;
        private src.FButton.FlatButton FBtnPD;
        private src.FButton.FlatButton FBtnPY;
    }
}

