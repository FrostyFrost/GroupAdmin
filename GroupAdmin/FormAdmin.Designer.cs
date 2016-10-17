namespace GroupAdmin
{
    partial class FormAdmin
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
            this.textBoxGroupID = new System.Windows.Forms.TextBox();
            this.buttonMS = new System.Windows.Forms.Button();
            this.textBoxEventID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonInviteFromGroup = new System.Windows.Forms.Button();
            this.textBox_offset = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonInviteAllFriends = new System.Windows.Forms.Button();
            this.textBoxGroupMess = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxGroupID
            // 
            this.textBoxGroupID.Location = new System.Drawing.Point(152, 76);
            this.textBoxGroupID.Name = "textBoxGroupID";
            this.textBoxGroupID.Size = new System.Drawing.Size(128, 20);
            this.textBoxGroupID.TabIndex = 0;
            // 
            // buttonMS
            // 
            this.buttonMS.Location = new System.Drawing.Point(297, 76);
            this.buttonMS.Name = "buttonMS";
            this.buttonMS.Size = new System.Drawing.Size(56, 19);
            this.buttonMS.TabIndex = 2;
            this.buttonMS.Text = "MS";
            this.buttonMS.UseVisualStyleBackColor = true;
            this.buttonMS.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxEventID
            // 
            this.textBoxEventID.Location = new System.Drawing.Point(152, 25);
            this.textBoxEventID.Name = "textBoxEventID";
            this.textBoxEventID.Size = new System.Drawing.Size(125, 20);
            this.textBoxEventID.TabIndex = 3;
            this.textBoxEventID.Text = "78757330";
            this.textBoxEventID.TextChanged += new System.EventHandler(this.textBoxEventID_TextChanged);
            this.textBoxEventID.DoubleClick += new System.EventHandler(this.textBoxEventID_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Номер встречи:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Пригласить из группы:";
            // 
            // buttonInviteFromGroup
            // 
            this.buttonInviteFromGroup.Location = new System.Drawing.Point(297, 113);
            this.buttonInviteFromGroup.Name = "buttonInviteFromGroup";
            this.buttonInviteFromGroup.Size = new System.Drawing.Size(155, 23);
            this.buttonInviteFromGroup.TabIndex = 6;
            this.buttonInviteFromGroup.Text = "Пригласить из сообщества";
            this.buttonInviteFromGroup.UseVisualStyleBackColor = true;
            this.buttonInviteFromGroup.Click += new System.EventHandler(this.buttonInviteFriends_Click);
            // 
            // textBox_offset
            // 
            this.textBox_offset.Location = new System.Drawing.Point(152, 116);
            this.textBox_offset.Name = "textBox_offset";
            this.textBox_offset.Size = new System.Drawing.Size(54, 20);
            this.textBox_offset.TabIndex = 7;
            this.textBox_offset.Click += new System.EventHandler(this.textBox_offset_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(372, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 24);
            this.button1.TabIndex = 8;
            this.button1.Text = "Сообщения";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(372, 333);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Посты на стены";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // buttonInviteAllFriends
            // 
            this.buttonInviteAllFriends.Location = new System.Drawing.Point(297, 142);
            this.buttonInviteAllFriends.Name = "buttonInviteAllFriends";
            this.buttonInviteAllFriends.Size = new System.Drawing.Size(155, 23);
            this.buttonInviteAllFriends.TabIndex = 10;
            this.buttonInviteAllFriends.Text = "Пригласить своих друзей";
            this.buttonInviteAllFriends.UseVisualStyleBackColor = true;
            this.buttonInviteAllFriends.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBoxGroupMess
            // 
            this.textBoxGroupMess.Location = new System.Drawing.Point(15, 193);
            this.textBoxGroupMess.Multiline = true;
            this.textBoxGroupMess.Name = "textBoxGroupMess";
            this.textBoxGroupMess.Size = new System.Drawing.Size(258, 80);
            this.textBoxGroupMess.TabIndex = 11;
            this.textBoxGroupMess.Text = "Стартовал новый проект для пользователей SJ4000 и других аналогичных экшн-камер. " +
    "Вступайте, делитесь впечатлениями, кидайте фото, видео, задавайте вопросы\r\nhttps" +
    "://vk.com/sjcam_msk";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(297, 193);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(209, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Разослать сообщение сообществу";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(297, 222);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(209, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "Разослать сообщение списку друзей";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(198, 303);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 14;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBoxAvatar
            // 
            this.pictureBoxAvatar.Location = new System.Drawing.Point(447, 13);
            this.pictureBoxAvatar.Name = "pictureBoxAvatar";
            this.pictureBoxAvatar.Size = new System.Drawing.Size(94, 83);
            this.pictureBoxAvatar.TabIndex = 15;
            this.pictureBoxAvatar.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Оффсет:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 368);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBoxAvatar);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBoxGroupMess);
            this.Controls.Add(this.buttonInviteAllFriends);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_offset);
            this.Controls.Add(this.buttonInviteFromGroup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEventID);
            this.Controls.Add(this.buttonMS);
            this.Controls.Add(this.textBoxGroupID);
            this.Name = "FormAdmin";
            this.Text = "Администрирование";
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxGroupID;
        private System.Windows.Forms.Button buttonMS;
        private System.Windows.Forms.TextBox textBoxEventID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonInviteFromGroup;
        private System.Windows.Forms.TextBox textBox_offset;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonInviteAllFriends;
        private System.Windows.Forms.TextBox textBoxGroupMess;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBoxAvatar;
        private System.Windows.Forms.Label label3;
    }
}