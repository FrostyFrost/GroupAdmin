namespace GroupAdmin
{
    partial class FormWallPost
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
            this.listBoxGroups = new System.Windows.Forms.ListBox();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.textBoxAttach = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxRepost = new System.Windows.Forms.TextBox();
            this.buttonRepostList = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxList = new System.Windows.Forms.ComboBox();
            this.buttonSaveList = new System.Windows.Forms.Button();
            this.textBoxOffset = new System.Windows.Forms.TextBox();
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxGroups
            // 
            this.listBoxGroups.FormattingEnabled = true;
            this.listBoxGroups.Location = new System.Drawing.Point(39, 12);
            this.listBoxGroups.Name = "listBoxGroups";
            this.listBoxGroups.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxGroups.Size = new System.Drawing.Size(120, 303);
            this.listBoxGroups.TabIndex = 0;
            this.listBoxGroups.SelectedIndexChanged += new System.EventHandler(this.listBoxGroups_SelectedIndexChanged);
            // 
            // textBoxText
            // 
            this.textBoxText.Location = new System.Drawing.Point(264, 31);
            this.textBoxText.Multiline = true;
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(348, 205);
            this.textBoxText.TabIndex = 1;
            this.textBoxText.Text = "Группа для пиара, лайков и поиска друзей. \r\nПри добавлении не будет анти-спам кар" +
    "тинки!\r\n\r\nhttps://vk.com/club102277002";
            this.textBoxText.TextChanged += new System.EventHandler(this.textBoxText_TextChanged);
            // 
            // textBoxAttach
            // 
            this.textBoxAttach.Location = new System.Drawing.Point(264, 254);
            this.textBoxAttach.Multiline = true;
            this.textBoxAttach.Name = "textBoxAttach";
            this.textBoxAttach.Size = new System.Drawing.Size(348, 45);
            this.textBoxAttach.TabIndex = 2;
            this.textBoxAttach.Text = "photo201621284_378232982";
            this.textBoxAttach.TextChanged += new System.EventHandler(this.textBoxAttach_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(390, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Добавить по списку";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(264, 347);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(390, 347);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Добавить в одну";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxRepost
            // 
            this.textBoxRepost.Location = new System.Drawing.Point(679, 115);
            this.textBoxRepost.Multiline = true;
            this.textBoxRepost.Name = "textBoxRepost";
            this.textBoxRepost.Size = new System.Drawing.Size(175, 45);
            this.textBoxRepost.TabIndex = 6;
            this.textBoxRepost.Text = "photo201621284_298486067";
            // 
            // buttonRepostList
            // 
            this.buttonRepostList.Location = new System.Drawing.Point(693, 166);
            this.buttonRepostList.Name = "buttonRepostList";
            this.buttonRepostList.Size = new System.Drawing.Size(136, 23);
            this.buttonRepostList.TabIndex = 7;
            this.buttonRepostList.Text = "Добавить по списку";
            this.buttonRepostList.UseVisualStyleBackColor = true;
            this.buttonRepostList.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(39, 321);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(120, 23);
            this.buttonRefresh.TabIndex = 8;
            this.buttonRefresh.Text = "Обновить список";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 9;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBoxList
            // 
            this.comboBoxList.FormattingEnabled = true;
            this.comboBoxList.Items.AddRange(new object[] {
            "Grouplist.txt",
            "Grouplist_g.txt",
            "Grouplist_m.txt",
            "Grouplist_capcha.txt"});
            this.comboBoxList.Location = new System.Drawing.Point(39, 351);
            this.comboBoxList.Name = "comboBoxList";
            this.comboBoxList.Size = new System.Drawing.Size(96, 21);
            this.comboBoxList.TabIndex = 10;
            this.comboBoxList.Text = "Grouplist.txt";
            this.comboBoxList.TextChanged += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonSaveList
            // 
            this.buttonSaveList.Location = new System.Drawing.Point(141, 351);
            this.buttonSaveList.Name = "buttonSaveList";
            this.buttonSaveList.Size = new System.Drawing.Size(72, 23);
            this.buttonSaveList.TabIndex = 11;
            this.buttonSaveList.Text = "Сохранить";
            this.buttonSaveList.UseVisualStyleBackColor = true;
            this.buttonSaveList.Click += new System.EventHandler(this.buttonSaveList_Click);
            // 
            // textBoxOffset
            // 
            this.textBoxOffset.Location = new System.Drawing.Point(205, 254);
            this.textBoxOffset.Name = "textBoxOffset";
            this.textBoxOffset.Size = new System.Drawing.Size(53, 20);
            this.textBoxOffset.TabIndex = 12;
            this.textBoxOffset.Text = "0";
            // 
            // pictureBoxAvatar
            // 
            this.pictureBoxAvatar.Location = new System.Drawing.Point(760, 12);
            this.pictureBoxAvatar.Name = "pictureBoxAvatar";
            this.pictureBoxAvatar.Size = new System.Drawing.Size(94, 83);
            this.pictureBoxAvatar.TabIndex = 16;
            this.pictureBoxAvatar.TabStop = false;
            // 
            // FormWallPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 373);
            this.Controls.Add(this.pictureBoxAvatar);
            this.Controls.Add(this.textBoxOffset);
            this.Controls.Add(this.buttonSaveList);
            this.Controls.Add(this.comboBoxList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonRepostList);
            this.Controls.Add(this.textBoxRepost);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxAttach);
            this.Controls.Add(this.textBoxText);
            this.Controls.Add(this.listBoxGroups);
            this.Name = "FormWallPost";
            this.Text = "Wall posting";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormWallPost_FormClosed);
            this.Load += new System.EventHandler(this.FormWallPost_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxGroups;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.TextBox textBoxAttach;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxRepost;
        private System.Windows.Forms.Button buttonRepostList;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxList;
        private System.Windows.Forms.Button buttonSaveList;
        private System.Windows.Forms.TextBox textBoxOffset;
        private System.Windows.Forms.PictureBox pictureBoxAvatar;
    }
}