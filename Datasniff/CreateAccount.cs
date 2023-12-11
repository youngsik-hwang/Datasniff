using MySql.Data.MySqlClient;
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
    public partial class CreateAccount : Form
    {
        #region ***** 변수 선언 *****
        private string sqlquery = string.Empty;
        private bool idChecked = false;

        #endregion

        public CreateAccount()
        {
            InitializeComponent();

            //pw.PasswordChar = '*';
        }
        #region ##### 일반함수 #####
        private void Save()
        {
            //무결성 체크
            if (IsValid()) {
                // 임시방편 코드
                using (MySqlConnection connection1 = new MySqlConnection(MariaDB.ConnectStr()))
                {
                    try
                    {
                        connection1.Open();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("실패");
                        Console.WriteLine(ex.ToString());
                    }
                }

                // DB저장
                using (MySqlConnection connection = new MySqlConnection(MariaDB.ConnectStr()))
                {
                    StringBuilder sql = new StringBuilder();
                    sql.AppendFormat("Insert into member(id, pw, title, titlenumber, val_date, in_date, bigo ) ");
                    sql.AppendFormat("values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')"
                        , id.Text
                        , pw.Text
                        , title.Text
                        , titlenumber_first.Text + "-" + titlenumber_second.Text + "-" + titlenumber_third.Text                        
                        , DateTime.Parse("2023-12-30").ToShortDateString()
                        , DateTime.Now.ToShortDateString()
                        , bigo.Text
                        );
                    try
                    {
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(sql.ToString(), connection);
                        
                        if (command.ExecuteNonQuery() == 1)
                        {
                            Console.WriteLine("인서트 성공");
                            MessageBox.Show("성공적으로 회원가입이 진행되었습니다.");
                            InitForm();
                        }
                        else
                        {                            
                            Console.WriteLine("인서트 실패");
                            MessageBox.Show("회원가입 실패!!!");
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("실패");
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
        }

        private bool IsValid()
        {
            if (string.IsNullOrEmpty(id.Text))
            {
                MessageBox.Show("아이디가 입력되지 않았습니다.");                
                id.Focus();
                return false;
            }
            if (!idChecked)
            {
                MessageBox.Show("아이디 중복체크를 성공하지 못했습니다.");
                check_dupl.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(pw.Text))
            {
                MessageBox.Show("비밀번호가 입력되지 않았습니다.");
                pw.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(pw_re.Text))
            {
                MessageBox.Show("비밀번호 확인이 입력되지 않았습니다.");
                pw_re.Focus();
                return false;
            }

            if (pw.Text != pw_re.Text)
            {
                MessageBox.Show("비밀번호가 서로 일치하지 않습니다.");
                return false;
            }

            if (string.IsNullOrEmpty(titlenumber_first.Text))
            {
                MessageBox.Show("사업자 번호가 입력되지 않았습니다.");
                titlenumber_first.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(titlenumber_second.Text))
            {
                MessageBox.Show("사업자 번호가 입력되지 않았습니다.");
                titlenumber_second.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(titlenumber_third.Text))
            {
                MessageBox.Show("사업자 번호가 입력되지 않았습니다.");
                titlenumber_third.Focus();
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

        private void CheckId()
        {
            Member member = new Member();
            if (member.IdDuplicationById(id.Text))
            {
                MessageBox.Show("사용 가능한 아이디 입니다.");
                idChecked = true;                
            }
            else
            {
                MessageBox.Show("사용중인 아이디 입니다.");
                idChecked = false;
            }            
        }

        private void InitForm()
        {
            id.Text = string.Empty;
            pw.Text = string.Empty;
            pw_re.Text = string.Empty;
            titlenumber_first.Text = string.Empty;
            titlenumber_second.Text = string.Empty;
            titlenumber_third.Text = string.Empty;
            title.Text = string.Empty;
            bigo.Text = string.Empty;
        }

        #endregion


        #region ##### Event Method #####

        /// <summary>
        /// 저장 버튼 Method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_Click(object sender, EventArgs e)
        {                      
            Save();            
        }

        /// <summary>
        /// 아이디 중복체크 버튼 Method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void check_dupl_Click(object sender, EventArgs e)
        {
            CheckId();
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


    }
}
