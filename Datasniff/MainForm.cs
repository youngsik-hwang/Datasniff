using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interop.hhdspmcLib;

namespace Datasniff
{
    public partial class MainForm : Form, _ISerialMonitorEvents
    {
        struct Monitoring
        {
            public Interop.hhdspmcLib.Monitoring monitor;
            public Listener listener;
        };

        private ListView listView1;
        private ColumnHeader ColName;
        private ColumnHeader Port;
        private ColumnHeader Connected;
        private ColumnHeader OpenedBy;
        private TabControl tabControl1;
        private Button StartMon;
        private Button StopMon;
        private Button ClearLog;

        private SerialMonitor sm = null;
        private ArrayList CurrentMonitors;

        private int euckrCodepage = 51949;
        private string startE = "27 64";
        private string endE = "27 105";
        private int numE = 0;

        delegate void RefreshDevicesInMainThreadDelegate();
        void _ISerialMonitorEvents.OnChange()
        {
            this.Invoke(new RefreshDevicesInMainThreadDelegate(RefreshDevices));
        }

        public MainForm()
        {
            InitializeComponent();
            log.Text = string.Empty;

            try
            {
                sm = new Interop.hhdspmcLib.SerialMonitor();
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Error opening the HHDSPMC control", "Error");
                return;
            }

            CurrentMonitors = new ArrayList();
            RefreshDevices();

            // register connection point
            // init connection point 
            int cookie;

            IConnectionPointContainer icpc = (IConnectionPointContainer)sm;
            IConnectionPoint icp;
            Guid IID_IMyEvents = typeof(_ISerialMonitorEvents).GUID;
            icpc.FindConnectionPoint(ref IID_IMyEvents, out icp);
            icp.Advise(this, out cookie);
        }

        private void RefreshDevices()
        {
            listView1.Items.Clear();
            ImageList imlist = new ImageList();

            foreach (Device device in sm.Devices)
            {
                imlist.Images.Add(Icon.FromHandle(device.Icon));
                ListViewItem item = new ListViewItem(
                    new String[] { device.Name, device.Port, device.Present ? "Yes" : "No", device.OpenedBy }, imlist.Images.Count - 1);

                item.Tag = false;
                if (!device.Present)
                    item.ForeColor = Color.FromKnownColor(KnownColor.GrayText);
                listView1.Items.Add(item);
            }
            listView1.SmallImageList = imlist;
            OnRefresh();
        }

        private void OnRefresh()
        {
            foreach (ColumnHeader col in listView1.Columns)
                col.Width = -1;
            listView1.Columns[listView1.Columns.Count - 1].Width = -2;
        }


        #region sample 함수 *****

        private void CloseButton_Click(object sender, System.EventArgs e)
        {
            Dispose();
        }

        private void StartMon_Click(object sender, System.EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                if ((bool)listView1.SelectedItems[0].Tag)
                {
                    MessageBox.Show(this, "This device is already monitored");
                    return;
                }
                Interop.hhdspmcLib.Monitoring monitor = sm.CreateMonitor();
                Device device = sm.Devices[listView1.SelectedIndices[0]];
                String TabName = device.Port;
                if (TabName.Length == 0)
                    TabName = device.Name;
                TabPage page = new TabPage(TabName);
                tabControl1.Controls.Add(page);
                Listener listener = new Listener(page, monitor, encodingData);
                monitor.Connect(device);

                Monitoring m = new Monitoring();
                m.listener = listener;
                m.monitor = monitor;
                CurrentMonitors.Add(m);
                ListViewItem item = listView1.SelectedItems[0];
                item.Tag = true;
                item.Font = new Font(item.Font, item.Font.Style | FontStyle.Bold);
            }
        }

        private void StopMon_Click(object sender, System.EventArgs e)
        {
            TabPage page = tabControl1.SelectedTab;
            if (page != null && page.Controls.Count == 1)
            {
                int i;
                Monitoring cm;
                for (i = 0; i < CurrentMonitors.Count; i++)
                {
                    cm = (Monitoring)CurrentMonitors[i];
                    if (cm.listener.events == page.Controls[0])
                        break;
                }
                if (i == CurrentMonitors.Count)
                    return;

                cm = (Monitoring)CurrentMonitors[i];
                Device device = cm.monitor.ConnectedDevice;
                if (device != null)
                {
                    string Name = device.Name;
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[0].Text == Name)
                        {
                            item.Tag = false;
                            item.Font = ListView.DefaultFont;
                            break;
                        }
                    }
                }
                cm.monitor.Disconnect();
                CurrentMonitors.RemoveAt(i);
                tabControl1.Controls.Remove(page);
            }
        }

        private void tabControl1_Layout(object sender, LayoutEventArgs e)
        {
            foreach (TabPage page in tabControl1.Controls)
            {
                if (page.Controls.Count > 0)
                {
                    Control control = page.Controls[0];
                    //control.Width = page.ClientSize.Width - 4;
                    //control.Height = page.ClientSize.Height - 4;
                }
            }
        }

        private void ClearLog_Click(object sender, EventArgs e)
        {
            TabPage page = tabControl1.SelectedTab;
            if (page != null && page.Controls.Count == 1)
            {
                int i;
                Monitoring cm;

                System.Windows.Forms.ListBox list_tmp = null;

                for (i = 0; i < CurrentMonitors.Count; i++)
                {
                    cm = (Monitoring)CurrentMonitors[i];
                    if (cm.listener.events == page.Controls[0])
                    {
                        list_tmp = cm.listener.events;
                        break;
                    }
                }

                if (list_tmp != null)
                {
                    list_tmp.Items.Clear();
                }
            }
        }

        #endregion
        
        private void SaveWork(string Address)
        {
            //data sniff            
            Member member = new Member();
            string tmp_address = Address;
            string tmp_title = "";
            string tmp_money = "0";

            if (member.IsAddressAccord(tmp_address))
            {
                AlertForm form = new AlertForm();
                form.Show();
                form.DataReceive(tmp_address);
            }
            else
            {
                string[] tmpSniff = new string[3];
                tmpSniff[0] = tmp_address;
                tmpSniff[1] = tmp_title;
                tmpSniff[2] = string.IsNullOrEmpty(tmp_money) ? "0" : tmp_money;
                member.InsertSniff(tmpSniff);

                log.Text += string.Format("{1} [insert] work table address=[{0}] " + "\n", tmp_address, DateTime.Now);
            }

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }        
  

        private void encodingData_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tempStr = string.Empty;
            tempStr = encodingData.SelectedItem.ToString().Trim();            
            sniff_address.Text += GetAddress(tempStr) + "\n\n";

            if (tempStr == "185 232 180 222 193 214 188 210 58 10 13")
            {
                numE = 100;
            }
            else
            {
                numE++;
            }

            if (numE == 101) { 
                SaveWork(GetAddress(tempStr));
            }
        }

        private string GetAddress(string byteValue)
        {
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            Encoding euckr = Encoding.GetEncoding(euckrCodepage);

            string[] s2 = byteValue.Split(" ");
            byte[] b2 = new byte[s2.Length];
            for (int i = 0; i < s2.Length; i++)
            {
                b2[i] = (byte)int.Parse(s2[i]);
            }            
            return euckr.GetString(b2);
            //Debug.WriteLine("EUC-KR로 디코딩된 문자열 : " + decodedStringByEUCKR);
            //sniff_address.Text += decodedStringByEUCKR;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            encodingData.SelectedIndex = encodingData.Items.Add("27 33 24 176 225 193 166 185 230 189 196 32 200 196 186 210 199 246 177 221 32 32 32 32 32 32 32 32 32 32 32 32 32 32 32 32 32 32 32 32 32 32 32 32 32 10 13 27 33 0 ");
            encodingData.SelectedIndex = encodingData.Items.Add("45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 45 10 13 ");
            encodingData.SelectedIndex = encodingData.Items.Add("185 232 180 222 193 214 188 210 58 10 13 ");
            encodingData.SelectedIndex = encodingData.Items.Add("27 33 24 176 230 186 207 32 176 230 187 234 189 195 32 191 193 187 234 181 191 32 56 50 50 45 49 32 49 195 254 32 188 246 192 175 184 174 200 165 185 228 191 213 10 13 27 33 0 ");
            encodingData.SelectedIndex = encodingData.Items.Add("176 230 186 207 32 176 230 187 234 189 195 32 188 186 190 207 183 206 49 53 177 230 32 50 56 32 49 195 254 32 188 246 192 175 184 174 200 165 185 228 191 213 10 13 ");
        }

    }
}
