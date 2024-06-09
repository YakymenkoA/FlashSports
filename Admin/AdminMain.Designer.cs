namespace Admin
{
    partial class AdminMain
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
            this.ControlPanelGB = new System.Windows.Forms.GroupBox();
            this.ChatsBtn = new System.Windows.Forms.Button();
            this.SettingsBtn = new System.Windows.Forms.Button();
            this.RemoveSuppBtn = new System.Windows.Forms.Button();
            this.ManageSuppBtn = new System.Windows.Forms.Button();
            this.BlockUserBtn = new System.Windows.Forms.Button();
            this.FilterCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UsersGB = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.UserId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Role = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Login = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Password = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ControlPanelGB.SuspendLayout();
            this.UsersGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlPanelGB
            // 
            this.ControlPanelGB.Controls.Add(this.ChatsBtn);
            this.ControlPanelGB.Controls.Add(this.SettingsBtn);
            this.ControlPanelGB.Controls.Add(this.RemoveSuppBtn);
            this.ControlPanelGB.Controls.Add(this.ManageSuppBtn);
            this.ControlPanelGB.Controls.Add(this.BlockUserBtn);
            this.ControlPanelGB.Controls.Add(this.FilterCB);
            this.ControlPanelGB.Controls.Add(this.label1);
            this.ControlPanelGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlPanelGB.Location = new System.Drawing.Point(0, 0);
            this.ControlPanelGB.Name = "ControlPanelGB";
            this.ControlPanelGB.Size = new System.Drawing.Size(1081, 81);
            this.ControlPanelGB.TabIndex = 0;
            this.ControlPanelGB.TabStop = false;
            this.ControlPanelGB.Text = "Control Panel:";
            // 
            // ChatsBtn
            // 
            this.ChatsBtn.Location = new System.Drawing.Point(840, 27);
            this.ChatsBtn.Name = "ChatsBtn";
            this.ChatsBtn.Size = new System.Drawing.Size(102, 37);
            this.ChatsBtn.TabIndex = 7;
            this.ChatsBtn.Text = "Chats";
            this.ChatsBtn.UseVisualStyleBackColor = true;
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.Location = new System.Drawing.Point(948, 27);
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Size = new System.Drawing.Size(102, 37);
            this.SettingsBtn.TabIndex = 6;
            this.SettingsBtn.Text = "Settings";
            this.SettingsBtn.UseVisualStyleBackColor = true;
            // 
            // RemoveSuppBtn
            // 
            this.RemoveSuppBtn.Location = new System.Drawing.Point(650, 27);
            this.RemoveSuppBtn.Name = "RemoveSuppBtn";
            this.RemoveSuppBtn.Size = new System.Drawing.Size(161, 37);
            this.RemoveSuppBtn.TabIndex = 4;
            this.RemoveSuppBtn.Text = "Remove Support";
            this.RemoveSuppBtn.UseVisualStyleBackColor = true;
            // 
            // ManageSuppBtn
            // 
            this.ManageSuppBtn.Location = new System.Drawing.Point(451, 27);
            this.ManageSuppBtn.Name = "ManageSuppBtn";
            this.ManageSuppBtn.Size = new System.Drawing.Size(193, 37);
            this.ManageSuppBtn.TabIndex = 3;
            this.ManageSuppBtn.Text = "Manage Support Account";
            this.ManageSuppBtn.UseVisualStyleBackColor = true;
            // 
            // BlockUserBtn
            // 
            this.BlockUserBtn.Location = new System.Drawing.Point(330, 27);
            this.BlockUserBtn.Name = "BlockUserBtn";
            this.BlockUserBtn.Size = new System.Drawing.Size(115, 37);
            this.BlockUserBtn.TabIndex = 2;
            this.BlockUserBtn.Text = "Block User";
            this.BlockUserBtn.UseVisualStyleBackColor = true;
            // 
            // FilterCB
            // 
            this.FilterCB.FormattingEnabled = true;
            this.FilterCB.Location = new System.Drawing.Point(87, 34);
            this.FilterCB.Name = "FilterCB";
            this.FilterCB.Size = new System.Drawing.Size(210, 24);
            this.FilterCB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(33, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter:";
            // 
            // UsersGB
            // 
            this.UsersGB.Controls.Add(this.listView1);
            this.UsersGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsersGB.Location = new System.Drawing.Point(0, 81);
            this.UsersGB.Name = "UsersGB";
            this.UsersGB.Size = new System.Drawing.Size(1081, 447);
            this.UsersGB.TabIndex = 1;
            this.UsersGB.TabStop = false;
            this.UsersGB.Text = "Users:";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserId,
            this.Role,
            this.Login,
            this.Password});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 18);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1075, 426);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // UserId
            // 
            this.UserId.Text = "UserId";
            this.UserId.Width = 84;
            // 
            // Role
            // 
            this.Role.Text = "Role";
            this.Role.Width = 163;
            // 
            // Login
            // 
            this.Login.Text = "Login";
            this.Login.Width = 317;
            // 
            // Password
            // 
            this.Password.Text = "Password";
            this.Password.Width = 406;
            // 
            // AdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 528);
            this.Controls.Add(this.UsersGB);
            this.Controls.Add(this.ControlPanelGB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AdminMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.ControlPanelGB.ResumeLayout(false);
            this.ControlPanelGB.PerformLayout();
            this.UsersGB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ControlPanelGB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox FilterCB;
        private System.Windows.Forms.Button BlockUserBtn;
        private System.Windows.Forms.Button ManageSuppBtn;
        private System.Windows.Forms.GroupBox UsersGB;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader UserId;
        private System.Windows.Forms.ColumnHeader Role;
        private System.Windows.Forms.ColumnHeader Login;
        private System.Windows.Forms.ColumnHeader Password;
        private System.Windows.Forms.Button RemoveSuppBtn;
        private System.Windows.Forms.Button ChatsBtn;
        private System.Windows.Forms.Button SettingsBtn;
    }
}

