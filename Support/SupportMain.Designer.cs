namespace Support
{
    partial class SupportMain
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StartChatBtn = new System.Windows.Forms.Button();
            this.PendingChatLV = new System.Windows.Forms.ListView();
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClientName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.SendBtn = new System.Windows.Forms.Button();
            this.MessageTB = new System.Windows.Forms.TextBox();
            this.GeneralChatTB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SettingsBtn = new System.Windows.Forms.Button();
            this.UpdateChatInfo = new System.Windows.Forms.Timer(this.components);
            this.UpdateGeneralChat = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.StartChatBtn);
            this.groupBox1.Controls.Add(this.PendingChatLV);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 590);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pending client chats:";
            // 
            // StartChatBtn
            // 
            this.StartChatBtn.Location = new System.Drawing.Point(121, 540);
            this.StartChatBtn.Name = "StartChatBtn";
            this.StartChatBtn.Size = new System.Drawing.Size(136, 43);
            this.StartChatBtn.TabIndex = 1;
            this.StartChatBtn.Text = "Start Chat";
            this.StartChatBtn.UseVisualStyleBackColor = true;
            this.StartChatBtn.Click += new System.EventHandler(this.StartChatBtn_Click);
            // 
            // PendingChatLV
            // 
            this.PendingChatLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Date,
            this.ClientName,
            this.Status});
            this.PendingChatLV.Dock = System.Windows.Forms.DockStyle.Top;
            this.PendingChatLV.FullRowSelect = true;
            this.PendingChatLV.HideSelection = false;
            this.PendingChatLV.Location = new System.Drawing.Point(3, 18);
            this.PendingChatLV.Name = "PendingChatLV";
            this.PendingChatLV.Size = new System.Drawing.Size(365, 512);
            this.PendingChatLV.TabIndex = 0;
            this.PendingChatLV.UseCompatibleStateImageBehavior = false;
            this.PendingChatLV.View = System.Windows.Forms.View.Details;
            this.PendingChatLV.SelectedIndexChanged += new System.EventHandler(this.PendingChatLV_SelectedIndexChanged);
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 65;
            // 
            // ClientName
            // 
            this.ClientName.Text = "Client Name";
            this.ClientName.Width = 110;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 170;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ClearBtn);
            this.groupBox3.Controls.Add(this.SendBtn);
            this.groupBox3.Controls.Add(this.MessageTB);
            this.groupBox3.Controls.Add(this.GeneralChatTB);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(371, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(566, 530);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "General Chat";
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(313, 480);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(136, 43);
            this.ClearBtn.TabIndex = 3;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(148, 480);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(136, 43);
            this.SendBtn.TabIndex = 2;
            this.SendBtn.Text = "Send Message";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // MessageTB
            // 
            this.MessageTB.BackColor = System.Drawing.Color.White;
            this.MessageTB.Location = new System.Drawing.Point(3, 428);
            this.MessageTB.Multiline = true;
            this.MessageTB.Name = "MessageTB";
            this.MessageTB.Size = new System.Drawing.Size(565, 42);
            this.MessageTB.TabIndex = 1;
            // 
            // GeneralChatTB
            // 
            this.GeneralChatTB.BackColor = System.Drawing.Color.White;
            this.GeneralChatTB.Dock = System.Windows.Forms.DockStyle.Top;
            this.GeneralChatTB.Enabled = false;
            this.GeneralChatTB.Location = new System.Drawing.Point(3, 18);
            this.GeneralChatTB.Multiline = true;
            this.GeneralChatTB.Name = "GeneralChatTB";
            this.GeneralChatTB.Size = new System.Drawing.Size(560, 404);
            this.GeneralChatTB.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SettingsBtn);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(371, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(566, 54);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.Location = new System.Drawing.Point(413, 12);
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Size = new System.Drawing.Size(146, 36);
            this.SettingsBtn.TabIndex = 4;
            this.SettingsBtn.Text = "Settings";
            this.SettingsBtn.UseVisualStyleBackColor = true;
            this.SettingsBtn.Click += new System.EventHandler(this.SettingsBtn_Click);
            // 
            // UpdateChatInfo
            // 
            this.UpdateChatInfo.Interval = 3000;
            this.UpdateChatInfo.Tick += new System.EventHandler(this.UpdateChatInfo_Tick);
            // 
            // UpdateGeneralChat
            // 
            this.UpdateGeneralChat.Enabled = true;
            this.UpdateGeneralChat.Interval = 3000;
            this.UpdateGeneralChat.Tick += new System.EventHandler(this.UpdateGeneralChat_Tick);
            // 
            // SupportMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 590);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "SupportMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Support";
            this.Load += new System.EventHandler(this.SupportMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView PendingChatLV;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader ClientName;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.Button StartChatBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox GeneralChatTB;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.TextBox MessageTB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button SettingsBtn;
        private System.Windows.Forms.Timer UpdateChatInfo;
        private System.Windows.Forms.Timer UpdateGeneralChat;
    }
}

