namespace Client
{
    partial class News
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
            this.MainGB = new System.Windows.Forms.GroupBox();
            this.TitleGB = new System.Windows.Forms.GroupBox();
            this.TitleL = new System.Windows.Forms.Label();
            this.CommentsGB = new System.Windows.Forms.GroupBox();
            this.NewsTextGB = new System.Windows.Forms.GroupBox();
            this.ContentTB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CommentTB = new System.Windows.Forms.TextBox();
            this.PostBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AllCommentsTB = new System.Windows.Forms.TextBox();
            this.MainGB.SuspendLayout();
            this.TitleGB.SuspendLayout();
            this.CommentsGB.SuspendLayout();
            this.NewsTextGB.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainGB
            // 
            this.MainGB.Controls.Add(this.NewsTextGB);
            this.MainGB.Controls.Add(this.CommentsGB);
            this.MainGB.Controls.Add(this.TitleGB);
            this.MainGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainGB.Location = new System.Drawing.Point(0, 0);
            this.MainGB.Name = "MainGB";
            this.MainGB.Size = new System.Drawing.Size(590, 871);
            this.MainGB.TabIndex = 0;
            this.MainGB.TabStop = false;
            // 
            // TitleGB
            // 
            this.TitleGB.Controls.Add(this.TitleL);
            this.TitleGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleGB.Location = new System.Drawing.Point(3, 18);
            this.TitleGB.Name = "TitleGB";
            this.TitleGB.Size = new System.Drawing.Size(584, 100);
            this.TitleGB.TabIndex = 0;
            this.TitleGB.TabStop = false;
            // 
            // TitleL
            // 
            this.TitleL.AutoSize = true;
            this.TitleL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleL.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TitleL.Location = new System.Drawing.Point(3, 18);
            this.TitleL.Name = "TitleL";
            this.TitleL.Size = new System.Drawing.Size(66, 31);
            this.TitleL.TabIndex = 0;
            this.TitleL.Text = "Title";
            // 
            // CommentsGB
            // 
            this.CommentsGB.Controls.Add(this.groupBox2);
            this.CommentsGB.Controls.Add(this.groupBox1);
            this.CommentsGB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CommentsGB.Location = new System.Drawing.Point(3, 458);
            this.CommentsGB.Name = "CommentsGB";
            this.CommentsGB.Size = new System.Drawing.Size(584, 410);
            this.CommentsGB.TabIndex = 1;
            this.CommentsGB.TabStop = false;
            // 
            // NewsTextGB
            // 
            this.NewsTextGB.Controls.Add(this.ContentTB);
            this.NewsTextGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewsTextGB.Location = new System.Drawing.Point(3, 118);
            this.NewsTextGB.Name = "NewsTextGB";
            this.NewsTextGB.Size = new System.Drawing.Size(584, 340);
            this.NewsTextGB.TabIndex = 2;
            this.NewsTextGB.TabStop = false;
            // 
            // ContentTB
            // 
            this.ContentTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentTB.Location = new System.Drawing.Point(3, 18);
            this.ContentTB.Multiline = true;
            this.ContentTB.Name = "ContentTB";
            this.ContentTB.ReadOnly = true;
            this.ContentTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ContentTB.Size = new System.Drawing.Size(578, 319);
            this.ContentTB.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PostBtn);
            this.groupBox1.Controls.Add(this.CommentTB);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 139);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comment:";
            // 
            // CommentTB
            // 
            this.CommentTB.Dock = System.Windows.Forms.DockStyle.Top;
            this.CommentTB.Location = new System.Drawing.Point(3, 18);
            this.CommentTB.Multiline = true;
            this.CommentTB.Name = "CommentTB";
            this.CommentTB.Size = new System.Drawing.Size(572, 65);
            this.CommentTB.TabIndex = 0;
            // 
            // PostBtn
            // 
            this.PostBtn.Location = new System.Drawing.Point(434, 89);
            this.PostBtn.Name = "PostBtn";
            this.PostBtn.Size = new System.Drawing.Size(138, 43);
            this.PostBtn.TabIndex = 5;
            this.PostBtn.Text = "Post";
            this.PostBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AllCommentsTB);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(578, 250);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "All comments:";
            // 
            // AllCommentsTB
            // 
            this.AllCommentsTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AllCommentsTB.Location = new System.Drawing.Point(3, 18);
            this.AllCommentsTB.Multiline = true;
            this.AllCommentsTB.Name = "AllCommentsTB";
            this.AllCommentsTB.ReadOnly = true;
            this.AllCommentsTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AllCommentsTB.Size = new System.Drawing.Size(572, 229);
            this.AllCommentsTB.TabIndex = 0;
            // 
            // News
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 871);
            this.Controls.Add(this.MainGB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "News";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "News";
            this.MainGB.ResumeLayout(false);
            this.TitleGB.ResumeLayout(false);
            this.TitleGB.PerformLayout();
            this.CommentsGB.ResumeLayout(false);
            this.NewsTextGB.ResumeLayout(false);
            this.NewsTextGB.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MainGB;
        private System.Windows.Forms.GroupBox NewsTextGB;
        private System.Windows.Forms.GroupBox CommentsGB;
        private System.Windows.Forms.GroupBox TitleGB;
        private System.Windows.Forms.Label TitleL;
        private System.Windows.Forms.TextBox ContentTB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox CommentTB;
        private System.Windows.Forms.Button PostBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox AllCommentsTB;
    }
}