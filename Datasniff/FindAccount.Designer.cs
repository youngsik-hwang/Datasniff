
namespace Datasniff
{
    partial class FindAccount
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
            this.find = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.titlenumber3 = new System.Windows.Forms.TextBox();
            this.titlenumber2 = new System.Windows.Forms.TextBox();
            this.titlenumber1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.result_display = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.find);
            this.groupBox1.Controls.Add(this.title);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.titlenumber3);
            this.groupBox1.Controls.Add(this.titlenumber2);
            this.groupBox1.Controls.Add(this.titlenumber1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(27, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 109);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // find
            // 
            this.find.Location = new System.Drawing.Point(365, 30);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(82, 56);
            this.find.TabIndex = 9;
            this.find.Text = "확인";
            this.find.UseVisualStyleBackColor = true;
            this.find.Click += new System.EventHandler(this.find_Click);
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(142, 63);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(217, 23);
            this.title.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "-";
            // 
            // titlenumber3
            // 
            this.titlenumber3.Location = new System.Drawing.Point(274, 30);
            this.titlenumber3.MaxLength = 5;
            this.titlenumber3.Name = "titlenumber3";
            this.titlenumber3.Size = new System.Drawing.Size(85, 23);
            this.titlenumber3.TabIndex = 5;
            // 
            // titlenumber2
            // 
            this.titlenumber2.Location = new System.Drawing.Point(214, 30);
            this.titlenumber2.Name = "titlenumber2";
            this.titlenumber2.Size = new System.Drawing.Size(40, 23);
            this.titlenumber2.TabIndex = 4;
            // 
            // titlenumber1
            // 
            this.titlenumber1.Location = new System.Drawing.Point(142, 30);
            this.titlenumber1.MaxLength = 3;
            this.titlenumber1.Name = "titlenumber1";
            this.titlenumber1.Size = new System.Drawing.Size(49, 23);
            this.titlenumber1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "사업장 이름";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "사업자등록번호";
            // 
            // result_display
            // 
            this.result_display.Location = new System.Drawing.Point(28, 127);
            this.result_display.Name = "result_display";
            this.result_display.Size = new System.Drawing.Size(467, 62);
            this.result_display.TabIndex = 1;
            this.result_display.Text = "";
            // 
            // FindAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 213);
            this.Controls.Add(this.result_display);
            this.Controls.Add(this.groupBox1);
            this.Name = "FindAccount";
            this.Text = "FindAccount";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox titlenumber3;
        private System.Windows.Forms.TextBox titlenumber2;
        private System.Windows.Forms.TextBox titlenumber1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox result_display;
        private System.Windows.Forms.Button find;
    }
}