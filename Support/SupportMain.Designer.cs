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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StartChatBtn = new System.Windows.Forms.Button();
            this.PendingChatLV = new System.Windows.Forms.ListView();
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClientName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.PortTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.SendBtn = new System.Windows.Forms.Button();
            this.MessageTB = new System.Windows.Forms.TextBox();
            this.GeneralChatTB = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.StartChatBtn);
            this.groupBox1.Controls.Add(this.PendingChatLV);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 590);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pending client chats:";
            // 
            // StartChatBtn
            // 
            this.StartChatBtn.Location = new System.Drawing.Point(73, 535);
            this.StartChatBtn.Name = "StartChatBtn";
            this.StartChatBtn.Size = new System.Drawing.Size(136, 43);
            this.StartChatBtn.TabIndex = 1;
            this.StartChatBtn.Text = "Start Chat";
            this.StartChatBtn.UseVisualStyleBackColor = true;
            // 
            // PendingChatLV
            // 
            this.PendingChatLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Date,
            this.ClientName,
            this.Status});
            this.PendingChatLV.Dock = System.Windows.Forms.DockStyle.Top;
            this.PendingChatLV.HideSelection = false;
            this.PendingChatLV.Location = new System.Drawing.Point(3, 18);
            this.PendingChatLV.Name = "PendingChatLV";
            this.PendingChatLV.Size = new System.Drawing.Size(288, 512);
            this.PendingChatLV.TabIndex = 0;
            this.PendingChatLV.UseCompatibleStateImageBehavior = false;
            this.PendingChatLV.View = System.Windows.Forms.View.Details;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 100;
            // 
            // ClientName
            // 
            this.ClientName.Text = "Client Name";
            this.ClientName.Width = 120;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ConnectBtn);
            this.groupBox2.Controls.Add(this.PortTB);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(294, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(571, 70);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Multiple connection imitation:";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(310, 18);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(118, 37);
            this.ConnectBtn.TabIndex = 2;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            // 
            // PortTB
            // 
            this.PortTB.Location = new System.Drawing.Point(153, 27);
            this.PortTB.Name = "PortTB";
            this.PortTB.Size = new System.Drawing.Size(131, 22);
            this.PortTB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ClearBtn);
            this.groupBox3.Controls.Add(this.SendBtn);
            this.groupBox3.Controls.Add(this.MessageTB);
            this.groupBox3.Controls.Add(this.GeneralChatTB);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(294, 70);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(571, 520);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "General Chat";
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(292, 465);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(136, 43);
            this.ClearBtn.TabIndex = 3;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(130, 465);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(136, 43);
            this.SendBtn.TabIndex = 2;
            this.SendBtn.Text = "Send Message";
            this.SendBtn.UseVisualStyleBackColor = true;
            // 
            // MessageTB
            // 
            this.MessageTB.Location = new System.Drawing.Point(3, 386);
            this.MessageTB.Multiline = true;
            this.MessageTB.Name = "MessageTB";
            this.MessageTB.Size = new System.Drawing.Size(565, 74);
            this.MessageTB.TabIndex = 1;
            // 
            // GeneralChatTB
            // 
            this.GeneralChatTB.Dock = System.Windows.Forms.DockStyle.Top;
            this.GeneralChatTB.Location = new System.Drawing.Point(3, 18);
            this.GeneralChatTB.Multiline = true;
            this.GeneralChatTB.Name = "GeneralChatTB";
            this.GeneralChatTB.Size = new System.Drawing.Size(565, 355);
            this.GeneralChatTB.TabIndex = 0;
            // 
            // SupportMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 590);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SupportMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Support";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView PendingChatLV;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader ClientName;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.Button StartChatBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.TextBox PortTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox GeneralChatTB;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.TextBox MessageTB;
    }
}

