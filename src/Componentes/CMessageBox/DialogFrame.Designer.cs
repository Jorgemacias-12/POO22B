namespace POO22B_MZJA.src.Componentes.CMessageBox
{
    partial class DialogFrame
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
            this.PnlContainer = new System.Windows.Forms.Panel();
            this.PnlBottom = new System.Windows.Forms.Panel();
            this.BtnClose = new System.Windows.Forms.Button();
            this.LblMensaje = new System.Windows.Forms.Label();
            this.PbxIcon = new System.Windows.Forms.PictureBox();
            this.PnlContainer.SuspendLayout();
            this.PnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlContainer
            // 
            this.PnlContainer.BackColor = System.Drawing.Color.White;
            this.PnlContainer.Controls.Add(this.PnlBottom);
            this.PnlContainer.Controls.Add(this.LblMensaje);
            this.PnlContainer.Controls.Add(this.PbxIcon);
            this.PnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlContainer.Location = new System.Drawing.Point(0, 0);
            this.PnlContainer.Name = "PnlContainer";
            this.PnlContainer.Size = new System.Drawing.Size(403, 145);
            this.PnlContainer.TabIndex = 0;
            // 
            // PnlBottom
            // 
            this.PnlBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PnlBottom.Controls.Add(this.BtnClose);
            this.PnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBottom.Location = new System.Drawing.Point(0, 100);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.Size = new System.Drawing.Size(403, 45);
            this.PnlBottom.TabIndex = 3;
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(304, 10);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 2;
            this.BtnClose.Text = "Aceptar";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // LblMensaje
            // 
            this.LblMensaje.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMensaje.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Assertive;
            this.LblMensaje.Location = new System.Drawing.Point(82, 24);
            this.LblMensaje.Name = "LblMensaje";
            this.LblMensaje.Size = new System.Drawing.Size(309, 64);
            this.LblMensaje.TabIndex = 1;
            this.LblMensaje.Text = "Texto";
            // 
            // PbxIcon
            // 
            this.PbxIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PbxIcon.Location = new System.Drawing.Point(12, 24);
            this.PbxIcon.Name = "PbxIcon";
            this.PbxIcon.Size = new System.Drawing.Size(64, 64);
            this.PbxIcon.TabIndex = 0;
            this.PbxIcon.TabStop = false;
            // 
            // DialogFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 145);
            this.ControlBox = false;
            this.Controls.Add(this.PnlContainer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DialogFrame";
            this.PnlContainer.ResumeLayout(false);
            this.PnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbxIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlContainer;
        private System.Windows.Forms.PictureBox PbxIcon;
        private System.Windows.Forms.Label LblMensaje;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Panel PnlBottom;
    }
}