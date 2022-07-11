namespace Erudite
{
    partial class FormSettings
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown_limit = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton_limit_on = new System.Windows.Forms.RadioButton();
            this.radioButton_limit_off = new System.Windows.Forms.RadioButton();
            this.checkBox_player_1 = new System.Windows.Forms.CheckBox();
            this.checkBox_player_2 = new System.Windows.Forms.CheckBox();
            this.checkBox_player_3 = new System.Windows.Forms.CheckBox();
            this.checkBox_player_4 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_player_4 = new System.Windows.Forms.TextBox();
            this.textBox_player_3 = new System.Windows.Forms.TextBox();
            this.textBox_player_2 = new System.Windows.Forms.TextBox();
            this.pictureBox_player_4 = new System.Windows.Forms.PictureBox();
            this.pictureBox_player_3 = new System.Windows.Forms.PictureBox();
            this.pictureBox_player_2 = new System.Windows.Forms.PictureBox();
            this.textBox_player_1 = new System.Windows.Forms.TextBox();
            this.pictureBox_player_1 = new System.Windows.Forms.PictureBox();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_play = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_limit)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player_1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.numericUpDown_limit);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.radioButton_limit_on);
            this.groupBox2.Controls.Add(this.radioButton_limit_off);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(313, 359);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(490, 104);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Лимит очков:";
            // 
            // numericUpDown_limit
            // 
            this.numericUpDown_limit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown_limit.Location = new System.Drawing.Point(298, 63);
            this.numericUpDown_limit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDown_limit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_limit.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown_limit.Name = "numericUpDown_limit";
            this.numericUpDown_limit.Size = new System.Drawing.Size(92, 26);
            this.numericUpDown_limit.TabIndex = 2;
            this.numericUpDown_limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_limit.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(397, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "очков";
            // 
            // radioButton_limit_on
            // 
            this.radioButton_limit_on.AutoSize = true;
            this.radioButton_limit_on.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_limit_on.Location = new System.Drawing.Point(15, 63);
            this.radioButton_limit_on.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton_limit_on.Name = "radioButton_limit_on";
            this.radioButton_limit_on.Size = new System.Drawing.Size(279, 24);
            this.radioButton_limit_on.TabIndex = 1;
            this.radioButton_limit_on.Text = "завершение игры по достижении";
            this.radioButton_limit_on.UseVisualStyleBackColor = true;
            // 
            // radioButton_limit_off
            // 
            this.radioButton_limit_off.AutoSize = true;
            this.radioButton_limit_off.Checked = true;
            this.radioButton_limit_off.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_limit_off.Location = new System.Drawing.Point(15, 29);
            this.radioButton_limit_off.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton_limit_off.Name = "radioButton_limit_off";
            this.radioButton_limit_off.Size = new System.Drawing.Size(120, 24);
            this.radioButton_limit_off.TabIndex = 0;
            this.radioButton_limit_off.TabStop = true;
            this.radioButton_limit_off.Text = "отсутствует";
            this.radioButton_limit_off.UseVisualStyleBackColor = true;
            // 
            // checkBox_player_1
            // 
            this.checkBox_player_1.AutoSize = true;
            this.checkBox_player_1.Checked = true;
            this.checkBox_player_1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_player_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox_player_1.Location = new System.Drawing.Point(16, 44);
            this.checkBox_player_1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox_player_1.Name = "checkBox_player_1";
            this.checkBox_player_1.Size = new System.Drawing.Size(15, 14);
            this.checkBox_player_1.TabIndex = 0;
            this.checkBox_player_1.UseVisualStyleBackColor = true;
            this.checkBox_player_1.CheckedChanged += new System.EventHandler(this.checkBox_player_1_CheckedChanged_1);
            // 
            // checkBox_player_2
            // 
            this.checkBox_player_2.AutoSize = true;
            this.checkBox_player_2.Checked = true;
            this.checkBox_player_2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_player_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox_player_2.Location = new System.Drawing.Point(290, 44);
            this.checkBox_player_2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox_player_2.Name = "checkBox_player_2";
            this.checkBox_player_2.Size = new System.Drawing.Size(15, 14);
            this.checkBox_player_2.TabIndex = 1;
            this.checkBox_player_2.UseVisualStyleBackColor = true;
            this.checkBox_player_2.CheckedChanged += new System.EventHandler(this.checkBox_player_2_CheckedChanged);
            // 
            // checkBox_player_3
            // 
            this.checkBox_player_3.AutoSize = true;
            this.checkBox_player_3.Checked = true;
            this.checkBox_player_3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_player_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox_player_3.Location = new System.Drawing.Point(565, 44);
            this.checkBox_player_3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox_player_3.Name = "checkBox_player_3";
            this.checkBox_player_3.Size = new System.Drawing.Size(15, 14);
            this.checkBox_player_3.TabIndex = 2;
            this.checkBox_player_3.UseVisualStyleBackColor = true;
            this.checkBox_player_3.CheckedChanged += new System.EventHandler(this.checkBox_player_3_CheckedChanged);
            // 
            // checkBox_player_4
            // 
            this.checkBox_player_4.AutoSize = true;
            this.checkBox_player_4.Checked = true;
            this.checkBox_player_4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_player_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox_player_4.Location = new System.Drawing.Point(844, 44);
            this.checkBox_player_4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox_player_4.Name = "checkBox_player_4";
            this.checkBox_player_4.Size = new System.Drawing.Size(15, 14);
            this.checkBox_player_4.TabIndex = 3;
            this.checkBox_player_4.UseVisualStyleBackColor = true;
            this.checkBox_player_4.CheckedChanged += new System.EventHandler(this.checkBox_player_4_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.textBox_player_4);
            this.groupBox1.Controls.Add(this.textBox_player_3);
            this.groupBox1.Controls.Add(this.textBox_player_2);
            this.groupBox1.Controls.Add(this.pictureBox_player_4);
            this.groupBox1.Controls.Add(this.pictureBox_player_3);
            this.groupBox1.Controls.Add(this.pictureBox_player_2);
            this.groupBox1.Controls.Add(this.textBox_player_1);
            this.groupBox1.Controls.Add(this.pictureBox_player_1);
            this.groupBox1.Controls.Add(this.checkBox_player_1);
            this.groupBox1.Controls.Add(this.checkBox_player_4);
            this.groupBox1.Controls.Add(this.checkBox_player_2);
            this.groupBox1.Controls.Add(this.checkBox_player_3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(23, 25);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1074, 308);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Игроки (минимум 2 игрока):";
            // 
            // textBox_player_4
            // 
            this.textBox_player_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_player_4.Location = new System.Drawing.Point(867, 37);
            this.textBox_player_4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_player_4.MaxLength = 32;
            this.textBox_player_4.Name = "textBox_player_4";
            this.textBox_player_4.Size = new System.Drawing.Size(192, 26);
            this.textBox_player_4.TabIndex = 11;
            this.textBox_player_4.Text = "Игрок 4";
            // 
            // textBox_player_3
            // 
            this.textBox_player_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_player_3.Location = new System.Drawing.Point(588, 37);
            this.textBox_player_3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_player_3.MaxLength = 32;
            this.textBox_player_3.Name = "textBox_player_3";
            this.textBox_player_3.Size = new System.Drawing.Size(192, 26);
            this.textBox_player_3.TabIndex = 10;
            this.textBox_player_3.Text = "Игрок 3";
            // 
            // textBox_player_2
            // 
            this.textBox_player_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_player_2.Location = new System.Drawing.Point(313, 37);
            this.textBox_player_2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_player_2.MaxLength = 32;
            this.textBox_player_2.Name = "textBox_player_2";
            this.textBox_player_2.Size = new System.Drawing.Size(192, 26);
            this.textBox_player_2.TabIndex = 9;
            this.textBox_player_2.Text = "Игрок 2";
            // 
            // pictureBox_player_4
            // 
            this.pictureBox_player_4.BackColor = System.Drawing.Color.White;
            this.pictureBox_player_4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_player_4.Image = global::Erudite.Properties.Resources.player_4_active;
            this.pictureBox_player_4.Location = new System.Drawing.Point(844, 73);
            this.pictureBox_player_4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox_player_4.Name = "pictureBox_player_4";
            this.pictureBox_player_4.Size = new System.Drawing.Size(215, 215);
            this.pictureBox_player_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_player_4.TabIndex = 8;
            this.pictureBox_player_4.TabStop = false;
            this.pictureBox_player_4.Click += new System.EventHandler(this.pictureBox_player_4_Click);
            // 
            // pictureBox_player_3
            // 
            this.pictureBox_player_3.BackColor = System.Drawing.Color.White;
            this.pictureBox_player_3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_player_3.Image = global::Erudite.Properties.Resources.player_3_active;
            this.pictureBox_player_3.Location = new System.Drawing.Point(565, 73);
            this.pictureBox_player_3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox_player_3.Name = "pictureBox_player_3";
            this.pictureBox_player_3.Size = new System.Drawing.Size(215, 215);
            this.pictureBox_player_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_player_3.TabIndex = 7;
            this.pictureBox_player_3.TabStop = false;
            this.pictureBox_player_3.Click += new System.EventHandler(this.pictureBox_player_3_Click);
            // 
            // pictureBox_player_2
            // 
            this.pictureBox_player_2.BackColor = System.Drawing.Color.White;
            this.pictureBox_player_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_player_2.Image = global::Erudite.Properties.Resources.player_2_active;
            this.pictureBox_player_2.Location = new System.Drawing.Point(290, 73);
            this.pictureBox_player_2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox_player_2.Name = "pictureBox_player_2";
            this.pictureBox_player_2.Size = new System.Drawing.Size(215, 215);
            this.pictureBox_player_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_player_2.TabIndex = 6;
            this.pictureBox_player_2.TabStop = false;
            this.pictureBox_player_2.Click += new System.EventHandler(this.pictureBox_player_2_Click);
            // 
            // textBox_player_1
            // 
            this.textBox_player_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_player_1.Location = new System.Drawing.Point(39, 37);
            this.textBox_player_1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_player_1.MaxLength = 32;
            this.textBox_player_1.Name = "textBox_player_1";
            this.textBox_player_1.Size = new System.Drawing.Size(192, 26);
            this.textBox_player_1.TabIndex = 5;
            this.textBox_player_1.Text = "Игрок 1";
            // 
            // pictureBox_player_1
            // 
            this.pictureBox_player_1.BackColor = System.Drawing.Color.White;
            this.pictureBox_player_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_player_1.Image = global::Erudite.Properties.Resources.player_1_active;
            this.pictureBox_player_1.Location = new System.Drawing.Point(16, 73);
            this.pictureBox_player_1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox_player_1.Name = "pictureBox_player_1";
            this.pictureBox_player_1.Size = new System.Drawing.Size(215, 215);
            this.pictureBox_player_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_player_1.TabIndex = 4;
            this.pictureBox_player_1.TabStop = false;
            this.pictureBox_player_1.Click += new System.EventHandler(this.pictureBox_player_1_Click);
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_exit.Location = new System.Drawing.Point(39, 359);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(215, 104);
            this.button_exit.TabIndex = 2;
            this.button_exit.Text = "Назад";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button_play
            // 
            this.button_play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button_play.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_play.Location = new System.Drawing.Point(867, 359);
            this.button_play.Name = "button_play";
            this.button_play.Size = new System.Drawing.Size(215, 104);
            this.button_play.TabIndex = 3;
            this.button_play.Text = "Старт игры";
            this.button_play.UseVisualStyleBackColor = false;
            this.button_play.Click += new System.EventHandler(this.button_play_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1123, 480);
            this.Controls.Add(this.button_play);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "\"Эрудит\" - Настройки игры";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSettings_FormClosed);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_limit)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player_1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown_limit;
        private System.Windows.Forms.RadioButton radioButton_limit_on;
        private System.Windows.Forms.RadioButton radioButton_limit_off;
        private System.Windows.Forms.CheckBox checkBox_player_1;
        private System.Windows.Forms.CheckBox checkBox_player_2;
        private System.Windows.Forms.CheckBox checkBox_player_3;
        private System.Windows.Forms.CheckBox checkBox_player_4;
        private System.Windows.Forms.PictureBox pictureBox_player_1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_player_1;
        private System.Windows.Forms.TextBox textBox_player_4;
        private System.Windows.Forms.TextBox textBox_player_3;
        private System.Windows.Forms.TextBox textBox_player_2;
        private System.Windows.Forms.PictureBox pictureBox_player_4;
        private System.Windows.Forms.PictureBox pictureBox_player_3;
        private System.Windows.Forms.PictureBox pictureBox_player_2;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_play;
    }
}

