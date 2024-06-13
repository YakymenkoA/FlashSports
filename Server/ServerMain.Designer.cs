namespace Server
{
    partial class ServerMain
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
            this.EventLogLB = new System.Windows.Forms.ListView();
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Key = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserRole = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Action = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SupportChatTB = new System.Windows.Forms.TextBox();
            this.SettingsBtn = new System.Windows.Forms.Button();
            this.MainGB = new System.Windows.Forms.GroupBox();
            this.MainGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // EventLogLB
            // 
            this.EventLogLB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Date,
            this.Key,
            this.UserId,
            this.UserRole,
            this.Action});
            this.EventLogLB.Dock = System.Windows.Forms.DockStyle.Left;
            this.EventLogLB.FullRowSelect = true;
            this.EventLogLB.HideSelection = false;
            this.EventLogLB.Location = new System.Drawing.Point(3, 22);
            this.EventLogLB.Name = "EventLogLB";
            this.EventLogLB.Size = new System.Drawing.Size(679, 518);
            this.EventLogLB.TabIndex = 0;
            this.EventLogLB.UseCompatibleStateImageBehavior = false;
            this.EventLogLB.View = System.Windows.Forms.View.Details;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 100;
            // 
            // Key
            // 
            this.Key.Text = "Key";
            this.Key.Width = 100;
            // 
            // UserId
            // 
            this.UserId.Text = "UserId";
            this.UserId.Width = 100;
            // 
            // UserRole
            // 
            this.UserRole.Text = "UserRole";
            this.UserRole.Width = 150;
            // 
            // Action
            // 
            this.Action.Text = "Action";
            this.Action.Width = 210;
            // 
            // SupportChatTB
            // 
            this.SupportChatTB.Location = new System.Drawing.Point(688, 66);
            this.SupportChatTB.Multiline = true;
            this.SupportChatTB.Name = "SupportChatTB";
            this.SupportChatTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SupportChatTB.Size = new System.Drawing.Size(271, 474);
            this.SupportChatTB.TabIndex = 1;
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.Location = new System.Drawing.Point(851, 18);
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Size = new System.Drawing.Size(102, 37);
            this.SettingsBtn.TabIndex = 7;
            this.SettingsBtn.Text = "Settings";
            this.SettingsBtn.UseVisualStyleBackColor = true;
            this.SettingsBtn.Click += new System.EventHandler(this.SettingsBtn_Click);
            // 
            // MainGB
            // 
            this.MainGB.Controls.Add(this.SupportChatTB);
            this.MainGB.Controls.Add(this.EventLogLB);
            this.MainGB.Controls.Add(this.SettingsBtn);
            this.MainGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainGB.Location = new System.Drawing.Point(0, 0);
            this.MainGB.Name = "MainGB";
            this.MainGB.Size = new System.Drawing.Size(965, 543);
            this.MainGB.TabIndex = 8;
            this.MainGB.TabStop = false;
            // 
            // ServerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 543);
            this.Controls.Add(this.MainGB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ServerMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServerMain_FormClosed);
            this.Load += new System.EventHandler(this.ServerMain_Load);
            this.MainGB.ResumeLayout(false);
            this.MainGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView EventLogLB;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Key;
        private System.Windows.Forms.ColumnHeader UserId;
        private System.Windows.Forms.ColumnHeader UserRole;
        private System.Windows.Forms.TextBox SupportChatTB;
        private System.Windows.Forms.ColumnHeader Action;
        private System.Windows.Forms.Button SettingsBtn;
        private System.Windows.Forms.GroupBox MainGB;
    }
}

