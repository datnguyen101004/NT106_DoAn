namespace room
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.In4Panel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.roundbutton2 = new room.roundbutton();
            this.roundbutton1 = new room.roundbutton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.In4Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // In4Panel
            // 
            this.In4Panel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.In4Panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("In4Panel.BackgroundImage")));
            this.In4Panel.Controls.Add(this.label7);
            this.In4Panel.Controls.Add(this.button3);
            this.In4Panel.Controls.Add(this.label6);
            this.In4Panel.Controls.Add(this.label5);
            this.In4Panel.Controls.Add(this.label4);
            this.In4Panel.Controls.Add(this.label3);
            this.In4Panel.Location = new System.Drawing.Point(189, 82);
            this.In4Panel.Name = "In4Panel";
            this.In4Panel.Size = new System.Drawing.Size(451, 262);
            this.In4Panel.TabIndex = 6;
            this.In4Panel.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(13, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "Win rate:";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Location = new System.Drawing.Point(345, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 33);
            this.button3.TabIndex = 10;
            this.button3.Text = "Close";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(14, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "Lose:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(13, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Win: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Name: ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 43);
            this.button1.TabIndex = 8;
            this.button1.Text = "  Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // roundbutton2
            // 
            this.roundbutton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("roundbutton2.BackgroundImage")));
            this.roundbutton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.roundbutton2.FlatAppearance.BorderSize = 0;
            this.roundbutton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundbutton2.Location = new System.Drawing.Point(104, 6);
            this.roundbutton2.Name = "roundbutton2";
            this.roundbutton2.Size = new System.Drawing.Size(95, 89);
            this.roundbutton2.TabIndex = 7;
            this.roundbutton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.roundbutton2.UseVisualStyleBackColor = true;
            this.roundbutton2.Click += new System.EventHandler(this.roundbutton2_Click);
            // 
            // roundbutton1
            // 
            this.roundbutton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("roundbutton1.BackgroundImage")));
            this.roundbutton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.roundbutton1.FlatAppearance.BorderSize = 0;
            this.roundbutton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundbutton1.Location = new System.Drawing.Point(12, 326);
            this.roundbutton1.Name = "roundbutton1";
            this.roundbutton1.Size = new System.Drawing.Size(95, 89);
            this.roundbutton1.TabIndex = 0;
            this.roundbutton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.roundbutton1.UseVisualStyleBackColor = true;
            this.roundbutton1.Click += new System.EventHandler(this.roundbutton1_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(581, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(243, 324);
            this.listBox1.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(581, 350);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(162, 62);
            this.textBox1.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(749, 350);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 62);
            this.button2.TabIndex = 11;
            this.button2.Text = "SEND";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(826, 427);
            this.Controls.Add(this.In4Panel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.roundbutton2);
            this.Controls.Add(this.roundbutton1);
            this.Name = "Form1";
            this.Text = " ";
            this.In4Panel.ResumeLayout(false);
            this.In4Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private roundbutton roundbutton1;
        private System.Windows.Forms.Panel In4Panel;
        private roundbutton roundbutton2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
    }
}

