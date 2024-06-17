namespace Client
{
    partial class ClientMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientMain));
            this.MainGB = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.EventsLV = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FilterTC = new System.Windows.Forms.TabControl();
            this.Sport1 = new System.Windows.Forms.TabPage();
            this.Sport2 = new System.Windows.Forms.TabPage();
            this.Sport3 = new System.Windows.Forms.TabPage();
            this.Sport4 = new System.Windows.Forms.TabPage();
            this.Bets = new System.Windows.Forms.TabPage();
            this.Favorites = new System.Windows.Forms.TabPage();
            this.NewsGB = new System.Windows.Forms.GroupBox();
            this.NewsPanelLV = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SettingIcon = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SupportIcon = new System.Windows.Forms.PictureBox();
            this.CandyAmount = new System.Windows.Forms.Label();
            this.CandyIcon = new System.Windows.Forms.PictureBox();
            this.UserNickname = new System.Windows.Forms.Label();
            this.UserAvatar = new System.Windows.Forms.PictureBox();
            this.MainGB.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.FilterTC.SuspendLayout();
            this.NewsGB.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupportIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CandyIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // MainGB
            // 
            this.MainGB.Controls.Add(this.groupBox2);
            this.MainGB.Controls.Add(this.groupBox1);
            this.MainGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainGB.Location = new System.Drawing.Point(0, 0);
            this.MainGB.Name = "MainGB";
            this.MainGB.Size = new System.Drawing.Size(1063, 643);
            this.MainGB.TabIndex = 0;
            this.MainGB.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.EventsLV);
            this.groupBox2.Controls.Add(this.FilterTC);
            this.groupBox2.Controls.Add(this.NewsGB);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1057, 532);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(552, 479);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 43);
            this.button3.TabIndex = 5;
            this.button3.Text = "Add to Favorites";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(355, 479);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 43);
            this.button2.TabIndex = 4;
            this.button2.Text = "Place a bet";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 479);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 43);
            this.button1.TabIndex = 3;
            this.button1.Text = "Event Full Information";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // EventsLV
            // 
            this.EventsLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Description,
            this.Date});
            this.EventsLV.Dock = System.Windows.Forms.DockStyle.Top;
            this.EventsLV.HideSelection = false;
            this.EventsLV.Location = new System.Drawing.Point(3, 44);
            this.EventsLV.Name = "EventsLV";
            this.EventsLV.Size = new System.Drawing.Size(810, 429);
            this.EventsLV.TabIndex = 0;
            this.EventsLV.UseCompatibleStateImageBehavior = false;
            this.EventsLV.View = System.Windows.Forms.View.Details;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 208;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 331;
            // 
            // Date
            // 
            this.Date.Text = "Issue Date";
            this.Date.Width = 182;
            // 
            // FilterTC
            // 
            this.FilterTC.Controls.Add(this.Sport1);
            this.FilterTC.Controls.Add(this.Sport2);
            this.FilterTC.Controls.Add(this.Sport3);
            this.FilterTC.Controls.Add(this.Sport4);
            this.FilterTC.Controls.Add(this.Bets);
            this.FilterTC.Controls.Add(this.Favorites);
            this.FilterTC.Dock = System.Windows.Forms.DockStyle.Top;
            this.FilterTC.Location = new System.Drawing.Point(3, 18);
            this.FilterTC.Name = "FilterTC";
            this.FilterTC.SelectedIndex = 0;
            this.FilterTC.Size = new System.Drawing.Size(810, 26);
            this.FilterTC.TabIndex = 2;
            this.FilterTC.SelectedIndexChanged += new System.EventHandler(this.FilterTC_TabChange);
            // 
            // Sport1
            // 
            this.Sport1.Location = new System.Drawing.Point(4, 25);
            this.Sport1.Name = "Sport1";
            this.Sport1.Padding = new System.Windows.Forms.Padding(3);
            this.Sport1.Size = new System.Drawing.Size(802, 0);
            this.Sport1.TabIndex = 0;
            this.Sport1.Text = "Sport1";
            this.Sport1.UseVisualStyleBackColor = true;
            // 
            // Sport2
            // 
            this.Sport2.Location = new System.Drawing.Point(4, 25);
            this.Sport2.Name = "Sport2";
            this.Sport2.Padding = new System.Windows.Forms.Padding(3);
            this.Sport2.Size = new System.Drawing.Size(802, 0);
            this.Sport2.TabIndex = 1;
            this.Sport2.Text = "Cricket";
            this.Sport2.UseVisualStyleBackColor = true;
            // 
            // Sport3
            // 
            this.Sport3.Location = new System.Drawing.Point(4, 25);
            this.Sport3.Name = "Sport3";
            this.Sport3.Size = new System.Drawing.Size(802, 0);
            this.Sport3.TabIndex = 4;
            this.Sport3.Text = "Soccer";
            this.Sport3.UseVisualStyleBackColor = true;
            // 
            // Sport4
            // 
            this.Sport4.Location = new System.Drawing.Point(4, 25);
            this.Sport4.Name = "Sport4";
            this.Sport4.Size = new System.Drawing.Size(802, 0);
            this.Sport4.TabIndex = 5;
            this.Sport4.Text = "Sport4";
            this.Sport4.UseVisualStyleBackColor = true;
            // 
            // Bets
            // 
            this.Bets.Location = new System.Drawing.Point(4, 25);
            this.Bets.Name = "Bets";
            this.Bets.Size = new System.Drawing.Size(802, 0);
            this.Bets.TabIndex = 2;
            this.Bets.Text = "Bets";
            this.Bets.UseVisualStyleBackColor = true;
            // 
            // Favorites
            // 
            this.Favorites.Location = new System.Drawing.Point(4, 25);
            this.Favorites.Name = "Favorites";
            this.Favorites.Size = new System.Drawing.Size(802, 0);
            this.Favorites.TabIndex = 3;
            this.Favorites.Text = "Favorites";
            this.Favorites.UseVisualStyleBackColor = true;
            // 
            // NewsGB
            // 
            this.NewsGB.Controls.Add(this.NewsPanelLV);
            this.NewsGB.Dock = System.Windows.Forms.DockStyle.Right;
            this.NewsGB.Location = new System.Drawing.Point(813, 18);
            this.NewsGB.Name = "NewsGB";
            this.NewsGB.Size = new System.Drawing.Size(241, 511);
            this.NewsGB.TabIndex = 1;
            this.NewsGB.TabStop = false;
            this.NewsGB.Text = "News:";
            // 
            // NewsPanelLV
            // 
            this.NewsPanelLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewsPanelLV.HideSelection = false;
            this.NewsPanelLV.Location = new System.Drawing.Point(3, 18);
            this.NewsPanelLV.Name = "NewsPanelLV";
            this.NewsPanelLV.Size = new System.Drawing.Size(235, 490);
            this.NewsPanelLV.TabIndex = 0;
            this.NewsPanelLV.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.SettingIcon);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.SupportIcon);
            this.groupBox1.Controls.Add(this.CandyAmount);
            this.groupBox1.Controls.Add(this.CandyIcon);
            this.groupBox1.Controls.Add(this.UserNickname);
            this.groupBox1.Controls.Add(this.UserAvatar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1057, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Information:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(810, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Settings";
            // 
            // SettingIcon
            // 
            this.SettingIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SettingIcon.BackgroundImage")));
            this.SettingIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SettingIcon.Location = new System.Drawing.Point(771, 30);
            this.SettingIcon.Name = "SettingIcon";
            this.SettingIcon.Size = new System.Drawing.Size(33, 33);
            this.SettingIcon.TabIndex = 6;
            this.SettingIcon.TabStop = false;
            this.SettingIcon.Click += new System.EventHandler(this.SettingIcon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(934, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Contact Support";
            // 
            // SupportIcon
            // 
            this.SupportIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SupportIcon.BackgroundImage")));
            this.SupportIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SupportIcon.Location = new System.Drawing.Point(895, 30);
            this.SupportIcon.Name = "SupportIcon";
            this.SupportIcon.Size = new System.Drawing.Size(33, 33);
            this.SupportIcon.TabIndex = 4;
            this.SupportIcon.TabStop = false;
            this.SupportIcon.Click += new System.EventHandler(this.SupportIcon_Click);
            // 
            // CandyAmount
            // 
            this.CandyAmount.AutoSize = true;
            this.CandyAmount.Location = new System.Drawing.Point(245, 38);
            this.CandyAmount.Name = "CandyAmount";
            this.CandyAmount.Size = new System.Drawing.Size(123, 16);
            this.CandyAmount.TabIndex = 3;
            this.CandyAmount.Text = "Amount of candies: ";
            // 
            // CandyIcon
            // 
            this.CandyIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CandyIcon.BackgroundImage")));
            this.CandyIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CandyIcon.Location = new System.Drawing.Point(206, 30);
            this.CandyIcon.Name = "CandyIcon";
            this.CandyIcon.Size = new System.Drawing.Size(33, 33);
            this.CandyIcon.TabIndex = 2;
            this.CandyIcon.TabStop = false;
            // 
            // UserNickname
            // 
            this.UserNickname.AutoSize = true;
            this.UserNickname.Location = new System.Drawing.Point(78, 38);
            this.UserNickname.Name = "UserNickname";
            this.UserNickname.Size = new System.Drawing.Size(100, 16);
            this.UserNickname.TabIndex = 1;
            this.UserNickname.Text = "User Nickname";
            // 
            // UserAvatar
            // 
            this.UserAvatar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UserAvatar.BackgroundImage")));
            this.UserAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.UserAvatar.InitialImage = null;
            this.UserAvatar.Location = new System.Drawing.Point(22, 21);
            this.UserAvatar.Name = "UserAvatar";
            this.UserAvatar.Size = new System.Drawing.Size(50, 50);
            this.UserAvatar.TabIndex = 0;
            this.UserAvatar.TabStop = false;
            this.UserAvatar.Click += new System.EventHandler(this.UserAvatar_Click);
            // 
            // ClientMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 643);
            this.Controls.Add(this.MainGB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ClientMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.Load += new System.EventHandler(this.ClientMain_Load);
            this.MainGB.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.FilterTC.ResumeLayout(false);
            this.NewsGB.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupportIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CandyIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MainGB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox UserAvatar;
        private System.Windows.Forms.Label UserNickname;
        private System.Windows.Forms.Label CandyAmount;
        private System.Windows.Forms.PictureBox CandyIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox SupportIcon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox SettingIcon;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox NewsGB;
        private System.Windows.Forms.ListView EventsLV;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.TabControl FilterTC;
        private System.Windows.Forms.TabPage Sport1;
        private System.Windows.Forms.TabPage Sport2;
        private System.Windows.Forms.TabPage Bets;
        private System.Windows.Forms.TabPage Favorites;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView NewsPanelLV;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.TabPage Sport3;
        private System.Windows.Forms.TabPage Sport4;
    }
}

