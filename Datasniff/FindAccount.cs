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
    public partial class FindAccount : Form
    {
        public FindAccount()
        {
            InitializeComponent();
        }

        #region ***** 일반 함수 *****

        private bool IsValid()
        {
            if (string.IsNullOrEmpty(titlenumber1.Text))
            {
                MessageBox.Show("사업자 번호가 입력되지 않았습니다.");
                titlenumber1.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(titlenumber2.Text))
            {
                MessageBox.Show("사업자 번호가 입력되지 않았습니다.");
                titlenumber2.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(titlenumber3.Text))
            {
                MessageBox.Show("사업자 번호가 입력되지 않았습니다.");
                titlenumber3.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(title.Text))
            {
                MessageBox.Show("사업장 이름이 입력되지 않았습니다.");
                title.Focus();
                return false;
            }
            return true;
        }


        private void DoFindAccount()
        {
            string titlenumber = string.Format("{0}-{1}-{2}", titlenumber1.Text, titlenumber2.Text, titlenumber3.Text);
            //무결성 체크
            if (IsValid())
            {
                result_display.Text = string.Empty;
                Member member = new Member();
                foreach(string item in member.FindAccountResult(title.Text, titlenumber))
                {
                    result_display.Text += string.Format("{0}", item);
                    result_display.Text += "\n";
                }                

            }
        }

        #endregion


        private void find_Click(object sender, EventArgs e)
        {
            DoFindAccount();
        }
    }
}
