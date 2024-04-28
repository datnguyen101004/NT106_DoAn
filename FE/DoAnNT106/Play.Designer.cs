namespace DoAnNT106
{
    partial class Play
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Play));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.bt_keo = new System.Windows.Forms.RichTextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.bt_bua = new System.Windows.Forms.Button();
            this.bt_bao = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(811, 407);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(450, 225);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // bt_keo
            // 
            this.bt_keo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_keo.Location = new System.Drawing.Point(811, 629);
            this.bt_keo.Name = "bt_keo";
            this.bt_keo.Size = new System.Drawing.Size(359, 44);
            this.bt_keo.TabIndex = 1;
            this.bt_keo.Text = "";
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(1167, 629);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(94, 45);
            this.btnSendMessage.TabIndex = 2;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // bt_bua
            // 
            this.bt_bua.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bt_bua.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_bua.Image = global::DoAnNT106.Properties.Resources.ROCK;
            this.bt_bua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_bua.Location = new System.Drawing.Point(152, 601);
            this.bt_bua.Name = "bt_bua";
            this.bt_bua.Size = new System.Drawing.Size(134, 60);
            this.bt_bua.TabIndex = 4;
            this.bt_bua.Text = "Búa";
            this.bt_bua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_bua.UseVisualStyleBackColor = false;
            // 
            // bt_bao
            // 
            this.bt_bao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_bao.Image = global::DoAnNT106.Properties.Resources.bao;
            this.bt_bao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_bao.Location = new System.Drawing.Point(292, 601);
            this.bt_bao.Name = "bt_bao";
            this.bt_bao.Size = new System.Drawing.Size(134, 60);
            this.bt_bao.TabIndex = 5;
            this.bt_bao.Text = "Bao";
            this.bt_bao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_bao.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::DoAnNT106.Properties.Resources.Scissors;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(12, 601);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 60);
            this.button1.TabIndex = 6;
            this.button1.Text = "Kéo";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Play
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_bao);
            this.Controls.Add(this.bt_bua);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.bt_keo);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Play";
            this.Text = "check";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox bt_keo;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button bt_bua;
        private System.Windows.Forms.Button bt_bao;
        private System.Windows.Forms.Button button1;
    }
}