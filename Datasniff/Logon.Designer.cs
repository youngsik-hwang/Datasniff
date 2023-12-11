
namespace Datasniff
{
    partial class Logon
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.pw = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.find_account = new System.Windows.Forms.Button();
            this.checkAutoLogin = new System.Windows.Forms.CheckBox();
            this.login = new System.Windows.Forms.Button();
            this.create_account = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "아이디";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "패스워드";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(129, 47);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(181, 23);
            this.id.TabIndex = 1;
            // 
            // pw
            // 
            this.pw.Location = new System.Drawing.Point(129, 86);
            this.pw.Name = "pw";
            this.pw.Size = new System.Drawing.Size(181, 23);
            this.pw.TabIndex = 2;
            this.pw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pw_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.find_account);
            this.groupBox1.Controls.Add(this.checkAutoLogin);
            this.groupBox1.Controls.Add(this.login);
            this.groupBox1.Controls.Add(this.id);
            this.groupBox1.Controls.Add(this.pw);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 237);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // find_account
            // 
            this.find_account.Location = new System.Drawing.Point(169, 130);
            this.find_account.Name = "find_account";
            this.find_account.Size = new System.Drawing.Size(141, 23);
            this.find_account.TabIndex = 7;
            this.find_account.Text = "아이디/패스워드 찾기";
            this.find_account.UseVisualStyleBackColor = true;
            this.find_account.Click += new System.EventHandler(this.find_account_Click);
            // 
            // checkAutoLogin
            // 
            this.checkAutoLogin.AutoSize = true;
            this.checkAutoLogin.Location = new System.Drawing.Point(41, 134);
            this.checkAutoLogin.Name = "checkAutoLogin";
            this.checkAutoLogin.Size = new System.Drawing.Size(86, 19);
            this.checkAutoLogin.TabIndex = 6;
            this.checkAutoLogin.Text = "자동로그인";
            this.checkAutoLogin.UseVisualStyleBackColor = true;
            // 
            // login
            // 
            this.login.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.login.Location = new System.Drawing.Point(41, 169);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(269, 44);
            this.login.TabIndex = 3;
            this.login.Text = "LOGIN";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // create_account
            // 
            this.create_account.Location = new System.Drawing.Point(16, 258);
            this.create_account.Name = "create_account";
            this.create_account.Size = new System.Drawing.Size(141, 23);
            this.create_account.TabIndex = 8;
            this.create_account.Text = "회원가입";
            this.create_account.UseVisualStyleBackColor = true;
            this.create_account.Click += new System.EventHandler(this.create_account_Click);
            // 
            // Logon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 307);
            this.Controls.Add(this.create_account);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Logon";
            this.Text = "Logon";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.TextBox pw;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button find_account;
        private System.Windows.Forms.CheckBox checkAutoLogin;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button create_account;
    }
}