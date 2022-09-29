namespace POO22B_MZJA.src.Clases
{
    partial class DlgMonitorParticula
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PnlMonitorHeader = new System.Windows.Forms.Panel();
            this.DgvMonitor = new System.Windows.Forms.DataGridView();
            this.LblTotalParticulas = new System.Windows.Forms.Label();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPosX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPosY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FBtnAutomatico = new POO22B_MZJA.src.FButton.FlatButton();
            this.FBtnActualizar = new POO22B_MZJA.src.FButton.FlatButton();
            this.PnlMonitorHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMonitor)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMonitorHeader
            // 
            this.PnlMonitorHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.PnlMonitorHeader.Controls.Add(this.FBtnAutomatico);
            this.PnlMonitorHeader.Controls.Add(this.FBtnActualizar);
            this.PnlMonitorHeader.Controls.Add(this.LblTotalParticulas);
            this.PnlMonitorHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlMonitorHeader.Location = new System.Drawing.Point(0, 0);
            this.PnlMonitorHeader.Name = "PnlMonitorHeader";
            this.PnlMonitorHeader.Size = new System.Drawing.Size(782, 52);
            this.PnlMonitorHeader.TabIndex = 0;
            // 
            // DgvMonitor
            // 
            this.DgvMonitor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvMonitor.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.DgvMonitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMonitor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColNombre,
            this.ColPosX,
            this.ColPosY});
            this.DgvMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMonitor.Location = new System.Drawing.Point(0, 52);
            this.DgvMonitor.Name = "DgvMonitor";
            this.DgvMonitor.RowHeadersWidth = 51;
            this.DgvMonitor.RowTemplate.Height = 24;
            this.DgvMonitor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMonitor.Size = new System.Drawing.Size(782, 501);
            this.DgvMonitor.TabIndex = 1;
            // 
            // LblTotalParticulas
            // 
            this.LblTotalParticulas.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblTotalParticulas.ForeColor = System.Drawing.Color.White;
            this.LblTotalParticulas.Location = new System.Drawing.Point(0, 0);
            this.LblTotalParticulas.Name = "LblTotalParticulas";
            this.LblTotalParticulas.Size = new System.Drawing.Size(339, 52);
            this.LblTotalParticulas.TabIndex = 0;
            this.LblTotalParticulas.Text = "En este momento hay 0 particulas activas.";
            this.LblTotalParticulas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColID
            // 
            this.ColID.HeaderText = "ID";
            this.ColID.MinimumWidth = 6;
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            // 
            // ColNombre
            // 
            this.ColNombre.HeaderText = "Nombre";
            this.ColNombre.MinimumWidth = 6;
            this.ColNombre.Name = "ColNombre";
            this.ColNombre.ReadOnly = true;
            // 
            // ColPosX
            // 
            this.ColPosX.HeaderText = "Posición en X";
            this.ColPosX.MinimumWidth = 6;
            this.ColPosX.Name = "ColPosX";
            this.ColPosX.ReadOnly = true;
            // 
            // ColPosY
            // 
            this.ColPosY.HeaderText = "Posición en Y";
            this.ColPosY.MinimumWidth = 6;
            this.ColPosY.Name = "ColPosY";
            this.ColPosY.ReadOnly = true;
            // 
            // FBtnAutomatico
            // 
            this.FBtnAutomatico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(233)))), ((int)(((byte)(5)))));
            this.FBtnAutomatico.Dock = System.Windows.Forms.DockStyle.Right;
            this.FBtnAutomatico.FlatAppearance.BorderSize = 0;
            this.FBtnAutomatico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FBtnAutomatico.HoverColor = System.Drawing.Color.Empty;
            this.FBtnAutomatico.Location = new System.Drawing.Point(530, 0);
            this.FBtnAutomatico.Name = "FBtnAutomatico";
            this.FBtnAutomatico.Size = new System.Drawing.Size(125, 52);
            this.FBtnAutomatico.TabIndex = 2;
            this.FBtnAutomatico.Text = "Automatico";
            this.FBtnAutomatico.UseVisualStyleBackColor = false;
            this.FBtnAutomatico.Click += new System.EventHandler(this.FBtnAutomatico_Click);
            // 
            // FBtnActualizar
            // 
            this.FBtnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(105)))), ((int)(((byte)(209)))));
            this.FBtnActualizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.FBtnActualizar.FlatAppearance.BorderSize = 0;
            this.FBtnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FBtnActualizar.ForeColor = System.Drawing.Color.White;
            this.FBtnActualizar.HoverColor = System.Drawing.Color.Empty;
            this.FBtnActualizar.Location = new System.Drawing.Point(655, 0);
            this.FBtnActualizar.Name = "FBtnActualizar";
            this.FBtnActualizar.Size = new System.Drawing.Size(127, 52);
            this.FBtnActualizar.TabIndex = 1;
            this.FBtnActualizar.Text = "Actualizar";
            this.FBtnActualizar.UseVisualStyleBackColor = false;
            this.FBtnActualizar.Click += new System.EventHandler(this.FBtnActualizar_Click);
            // 
            // DlgMonitorParticula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.DgvMonitor);
            this.Controls.Add(this.PnlMonitorHeader);
            this.Name = "DlgMonitorParticula";
            this.Text = "Monitor de particulas";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgMonitorParticula_FormClosing);
            this.Load += new System.EventHandler(this.DlgMonitorParticula_Load);
            this.PnlMonitorHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMonitor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMonitorHeader;
        private System.Windows.Forms.DataGridView DgvMonitor;
        private System.Windows.Forms.Label LblTotalParticulas;
        private FButton.FlatButton FBtnActualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPosX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPosY;
        private FButton.FlatButton FBtnAutomatico;
    }
}