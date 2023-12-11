using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datasniff
{
    public partial class Logon : Form
    {
        public Logon()
        {
            InitializeComponent();
            
            // 패스워드 설정
            pw.PasswordChar = '*';
        }

        #region ***** 일반 함수 *****
        private bool IsValid()
        {
            if (string.IsNullOrEmpty(id.Text))
            {
                MessageBox.Show("아이디가 입력되지 않았습니다.");
                id.Focus();
                return false;
            }         
            if (string.IsNullOrEmpty(pw.Text))
            {
                MessageBox.Show("비밀번호가 입력되지 않았습니다.");
                pw.Focus();
                return false;
            }
           
            return true;
        }

        private void DoLogin()
        {
            if (IsValid())
            {
                Member member = new Member();
                if (member.IsMember(id.Text, pw.Text))
                {
                    //MessageBox.Show("성공적으로 로그인 하였습니다.");
                    MainForm form = new MainForm();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("계정이 일치하지 않습니다.\n(아이디, 암호를 확인해 주세요.)");                    
                }
            }
        }


        #endregion



        #region ***** Event Method *****

        private void find_account_Click(object sender, EventArgs e)
        {
            FindAccount form = new FindAccount();
            form.Show();
            
        }

        private void create_account_Click(object sender, EventArgs e)
        {
            CreateAccount form = new CreateAccount();
            form.Show();
        }
        private void login_Click(object sender, EventArgs e)
        {
            DoLogin();
        }
        #endregion

        private void pw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                DoLogin();
            }
        }
    }
}
