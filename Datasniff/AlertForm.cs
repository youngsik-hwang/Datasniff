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
    public partial class AlertForm : Form
    {
        private Image im;        
        public AlertForm()
        {
            InitializeComponent();

            this.Paint += new PaintEventHandler(fm_Paint);
            im = Properties.Resources.star;
        }

        public void fm_Paint(Object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;            
        }

        public void DataReceive(string data)
        {
            Member member = new Member();
            string []tmpResult = member.GetReason(data);

            // 사유 표시
            reason.Text = tmpResult[0];

            // 별 그리기
            if (!string.IsNullOrEmpty(tmpResult[1])) { 
                using (Graphics g = CreateGraphics())
                {
                    int left = 150;
                    int top = 30;
                    for (int i = 1; i <= int.Parse(tmpResult[1]);i++)
                    {
                        g.DrawImage(im, left, top, 30, 30);
                        left += 50;
                    }                
                }
            }
        }

        private void check_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
