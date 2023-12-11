using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datasniff
{
    public class Member
    {
        private string ConnectionString;
        private string sqlquery = string.Empty;        

        public Member()
        {
            ConnectionString = MariaDB.ConnectStr();
        }

        //아이디 중복체크
        public bool IdDuplicationById(string id)
        {
            // 첫번째 Connection 실패 오류 해결을 위한 임시방편
            using (MySqlConnection connection1 = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection1.Open();
                }
                catch (Exception ex)
                {
                }
            }

            bool bResult = true;
            DataSet ds = new DataSet();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    sqlquery = string.Format("SELECT id FROM member WHERE id ='{0}'", id);
                    MySqlCommand cmd = new MySqlCommand(sqlquery, connection);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        bResult = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                    bResult = true;
                }
            }
            return bResult;
        }

        //사업자번호 중복체크

        //LOG IN 체크
        /// <summary>
        /// LOG IN 체크
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool IsMember(string id, string pw)
        {
            // 첫번째 Connection 실패 오류 해결을 위한 임시방편
            using (MySqlConnection connection1 = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection1.Open();
                }
                catch (Exception ex)
                {
                }
            }

            bool bResult = false;            
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    sqlquery = string.Format("SELECT id FROM member WHERE id ='{0}' and pw ='{1}'", id, pw);
                    MySqlCommand cmd = new MySqlCommand(sqlquery, connection);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        bResult = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                    bResult = false;
                }
            }
            return bResult;
        }

        //아이디 비밀번호 찾기
        public string [] FindAccountResult(string title, string titlenumber)
        {
            // 첫번째 Connection 실패 오류 해결을 위한 임시방편
            using (MySqlConnection connection1 = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection1.Open();
                }
                catch (Exception ex)
                {
                }
            }

            string[] result = new string[2];            
            
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    sqlquery = string.Format("SELECT id, pw FROM member WHERE title ='{0}' and titlenumber='{1}'", title, titlenumber);
                    MySqlCommand cmd = new MySqlCommand(sqlquery, connection);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result[0] = dr["id"].ToString();
                        result[1] = dr["pw"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());                    
                }
            }
            return result;
        }

        //주소 일치여부
        public bool IsAddressAccord(string address)
        {
            // 첫번째 Connection 실패 오류 해결을 위한 임시방편
            using (MySqlConnection connection1 = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection1.Open();
                }
                catch (Exception ex)
                {
                }
            }

            bool bResult = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    sqlquery = string.Format("SELECT in_sayu FROM alert WHERE address ='{0}'", address);                    
                    MySqlCommand cmd = new MySqlCommand(sqlquery, connection);
                    MySqlDataReader dr = cmd.ExecuteReader();                    
                    if (dr.HasRows)
                    {
                        bResult = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }
            }
            return bResult;
        }


        //AlertTable 주의등급, 입력사유 리턴
        public string[] GetReason(string address)
        {
            // 첫번째 Connection 실패 오류 해결을 위한 임시방편
            using (MySqlConnection connection1 = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection1.Open();
                }
                catch (Exception ex)
                {
                }
            }


            string[] result = new string[2];
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    sqlquery = string.Format("SELECT in_sayu, cast(in_number as CHAR(2)) AS in_number FROM alert WHERE address ='{0}'", address);
                    MySqlCommand cmd = new MySqlCommand(sqlquery, connection);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result[0] = dr["in_sayu"].ToString();
                        result[1] = dr["in_number"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }
            }
            return result;
        }

        public void InsertSniff(string[] sniff)
        {

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
                sql.AppendFormat("Insert into work(in_date, address, in_title, in_money ) ");
                sql.AppendFormat("values('{0}','{1}','{2}',{3})"
                    , DateTime.Now.ToShortDateString()
                    , sniff[0]
                    , sniff[1]
                    , int.Parse(sniff[2])
                    ); 
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sql.ToString(), connection);

                    if (command.ExecuteNonQuery() == 1)
                    {
                        Console.WriteLine("인서트 성공");
                    }
                    else
                    {
                        Console.WriteLine("인서트 실패");
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
}
