
namespace Datasniff
{
    partial class MainForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.log = new System.Windows.Forms.RichTextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ColName = new System.Windows.Forms.ColumnHeader();
            this.Port = new System.Windows.Forms.ColumnHeader();
            this.Connected = new System.Windows.Forms.ColumnHeader();
            this.OpenedBy = new System.Windows.Forms.ColumnHeader();
            this.StartMon = new System.Windows.Forms.Button();
            this.StopMon = new System.Windows.Forms.Button();
            this.ClearLog = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.encodingData = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sniff_address = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(597, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sniff Data";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(597, 487);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Log";
            // 
            // log
            // 
            this.log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.log.Location = new System.Drawing.Point(598, 516);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(750, 182);
            this.log.TabIndex = 11;
            this.log.Text = "";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColName,
            this.Port,
            this.Connected,
            this.OpenedBy});
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(10, 9);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(565, 258);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ColName
            // 
            this.ColName.Name = "ColName";
            this.ColName.Text = "Name";
            // 
            // Port
            // 
            this.Port.Name = "Port";
            this.Port.Text = "Port";
            // 
            // Connected
            // 
            this.Connected.Name = "Connected";
            this.Connected.Text = "Connected";
            // 
            // OpenedBy
            // 
            this.OpenedBy.Name = "OpenedBy";
            this.OpenedBy.Text = "Opened By";
            // 
            // StartMon
            // 
            this.StartMon.Location = new System.Drawing.Point(10, 271);
            this.StartMon.Name = "StartMon";
            this.StartMon.Size = new System.Drawing.Size(115, 29);
            this.StartMon.TabIndex = 1;
            this.StartMon.Text = "Start Monitoring";
            this.StartMon.Click += new System.EventHandler(this.StartMon_Click);
            // 
            // StopMon
            // 
            this.StopMon.Location = new System.Drawing.Point(144, 271);
            this.StopMon.Name = "StopMon";
            this.StopMon.Size = new System.Drawing.Size(115, 29);
            this.StopMon.TabIndex = 1;
            this.StopMon.Text = "Stop Monitoring";
            this.StopMon.Click += new System.EventHandler(this.StopMon_Click);
            // 
            // ClearLog
            // 
            this.ClearLog.Location = new System.Drawing.Point(286, 271);
            this.ClearLog.Name = "ClearLog";
            this.ClearLog.Size = new System.Drawing.Size(115, 29);
            this.ClearLog.TabIndex = 1;
            this.ClearLog.Text = "Clear Log";
            this.ClearLog.Click += new System.EventHandler(this.ClearLog_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Location = new System.Drawing.Point(10, 306);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(565, 392);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.Layout += new System.Windows.Forms.LayoutEventHandler(this.tabControl1_Layout);
            // 
            // encodingData
            // 
            this.encodingData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.encodingData.FormattingEnabled = true;
            this.encodingData.ItemHeight = 15;
            this.encodingData.Location = new System.Drawing.Point(598, 37);
            this.encodingData.Name = "encodingData";
            this.encodingData.Size = new System.Drawing.Size(749, 229);
            this.encodingData.TabIndex = 17;
            this.encodingData.SelectedIndexChanged += new System.EventHandler(this.encodingData_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(719, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Test Sniff Data 추가";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(597, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Encoding Data";
            // 
            // sniff_address
            // 
            this.sniff_address.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sniff_address.Location = new System.Drawing.Point(598, 306);
            this.sniff_address.Name = "sniff_address";
            this.sniff_address.Size = new System.Drawing.Size(749, 178);
            this.sniff_address.TabIndex = 21;
            this.sniff_address.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 710);
            this.Controls.Add(this.sniff_address);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.encodingData);
            this.Controls.Add(this.log);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.StartMon);
            this.Controls.Add(this.StopMon);
            this.Controls.Add(this.ClearLog);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox log;
        private System.Windows.Forms.ListBox encodingData;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox sniff_address;
    }
}