using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.hhdspmcLib;

namespace Datasniff
{
    public class Listener
    {
        private Monitoring monitor;
		private System.Windows.Forms.TabPage page;
		public System.Windows.Forms.ListBox events;
		public System.Windows.Forms.ListBox encoding;

		public Listener(System.Windows.Forms.TabPage page, Monitoring m, System.Windows.Forms.ListBox encoding2)
        {
            monitor = m;
			this.page = page;
			events = new System.Windows.Forms.ListBox();
			events.IntegralHeight = false;
			events.SelectionMode = System.Windows.Forms.SelectionMode.None;
			// 추가 Code			
			encoding = encoding2;
			encoding.SelectionMode = System.Windows.Forms.SelectionMode.None;

			page.Controls.Add(events);
			events.Location = new System.Drawing.Point(2, 4);
			events.Width = page.Width - 4;
			events.Height = page.Height - 5;

			monitor.OnBaudRate += new _IMonitoringEvents_OnBaudRateEventHandler(monitor_OnBaudRate);
			monitor.OnClearStats += new _IMonitoringEvents_OnClearStatsEventHandler(monitor_OnClearStats);
			monitor.OnClose += new _IMonitoringEvents_OnCloseEventHandler(monitor_OnClose);
			monitor.OnCommStatus += new _IMonitoringEvents_OnCommStatusEventHandler(monitor_OnCommStatus);
			monitor.OnConnection += new _IMonitoringEvents_OnConnectionEventHandler(monitor_OnConnection);
			monitor.OnDTR += new _IMonitoringEvents_OnDTREventHandler(monitor_OnDTR);
			monitor.OnDTRRTS += new _IMonitoringEvents_OnDTRRTSEventHandler(monitor_OnDTRRTS);
			monitor.OnGetModemStatus += new _IMonitoringEvents_OnGetModemStatusEventHandler(monitor_OnGetModemStatus);
			monitor.OnGetProperties += new _IMonitoringEvents_OnGetPropertiesEventHandler(monitor_OnGetProperties);
			monitor.OnHandflow += new _IMonitoringEvents_OnHandflowEventHandler(monitor_OnHandflow);
			monitor.OnLineControl += new _IMonitoringEvents_OnLineControlEventHandler(monitor_OnLineControl);
			monitor.OnOpen += new _IMonitoringEvents_OnOpenEventHandler(monitor_OnOpen);
			monitor.OnPurge += new _IMonitoringEvents_OnPurgeEventHandler(monitor_OnPurge);
			monitor.OnRead += new _IMonitoringEvents_OnReadEventHandler(monitor_OnRead);
			monitor.OnReset += new _IMonitoringEvents_OnResetEventHandler(monitor_OnReset);
			monitor.OnRTS += new _IMonitoringEvents_OnRTSEventHandler(monitor_OnRTS);
			monitor.OnSerialChars += new _IMonitoringEvents_OnSerialCharsEventHandler(monitor_OnSerialChars);
			monitor.OnSetBreak += new _IMonitoringEvents_OnSetBreakEventHandler(monitor_OnSetBreak);
			monitor.OnSetQueueSize += new _IMonitoringEvents_OnSetQueueSizeEventHandler(monitor_OnSetQueueSize);
			monitor.OnStats += new _IMonitoringEvents_OnStatsEventHandler(monitor_OnStats);
			monitor.OnTimeouts += new _IMonitoringEvents_OnTimeoutsEventHandler(monitor_OnTimeouts);
			monitor.OnTransmit += new _IMonitoringEvents_OnTransmitEventHandler(monitor_OnTransmit);
			monitor.OnWaitMask += new _IMonitoringEvents_OnWaitMaskEventHandler(monitor_OnWaitMask);
			monitor.OnWaitOnMask += new _IMonitoringEvents_OnWaitOnMaskEventHandler(monitor_OnWaitOnMask);
			monitor.OnWrite += new _IMonitoringEvents_OnWriteEventHandler(monitor_OnWrite);
			monitor.OnXOFF += new _IMonitoringEvents_OnXOFFEventHandler(monitor_OnXOFF);
			monitor.OnXON += new _IMonitoringEvents_OnXONEventHandler(monitor_OnXON);
		}

		private char Char(byte val)
		{
			return val < 32 || val > 127 ? '.' : (char)val;
		}

		private string SmartRenderData(Array array)
		{
			int length = Math.Min(array.Length, 32);
			string result = "";
			for (int i = 0; i < length; i++)
				result += array.GetValue(i).ToString();
			return result;
		}

		private void monitor_OnBaudRate(DateTime time, uint BaudRate, bool bGet)
		{
			Dump(time, (bGet ? "Get" : "Set") + " baudrate: " + BaudRate);
		}

		private void monitor_OnClearStats(DateTime time)
		{
			Dump(time, "Clear stats");
		}

		private void monitor_OnClose(DateTime time)
		{
			Dump(time, "Device is closed");
		}

		private void monitor_OnCommStatus(DateTime time, uint Errors, uint HoldReasons, uint AmountInInQueue, uint AmountInOutQueue, bool EofReceived, bool WaitForImmediate)
		{
			Dump(time, "Comm Status: Errors=" + Errors + ", HoldReasons=" + HoldReasons + ", AmountInInQueue=" + AmountInInQueue + ", AmountInOutQueue=" + AmountInOutQueue +
				", EofReceived=" + EofReceived + ", WaitForImmediate=" + WaitForImmediate);
		}

		private void monitor_OnConnection(DateTime time, Interop.hhdspmcLib.ConnectionState cs, string Name)
		{
			Dump(time, (cs == Interop.hhdspmcLib.ConnectionState.DeviceConnected ? "Connected to \"" : "Disconnected from \"") +
				Name + "\"");
		}

		private void monitor_OnDTR(DateTime time, bool bSet)
		{
			Dump(time, "DTR " + (bSet ? "ON" : "OFF"));
		}

		private void monitor_OnDTRRTS(DateTime time, bool DTR, bool RTS)
		{
			Dump(time, "DTR=" + DTR + ", RTS=" + RTS);
		}

		private void monitor_OnGetModemStatus(DateTime time, MODEMSTATUS ModemStatus)
		{
			Dump(time, "Get modem status: " + ModemStatus);
		}

		private void monitor_OnGetProperties(DateTime time, ushort PacketLength, ushort PacketVersion, uint MaxTxQueue, uint MaxRxQueue, uint CurrentTxQueue, uint CurrentRxQueue, BAUDRATES MaxBaudRate, PROVIDERTYPE PROVIDERTYPE, PROVIDERCAPS PROVIDERCAPS, PROVIDERSETTABLE ProviderSettableParams, BAUDRATES SettableBaudRates, DATABITS_ST SettableData, STOPPARITY_ST SettableStopParity)
		{
			Dump(time, "Get properties...");
		}

		private void monitor_OnHandflow(DateTime time, uint ControlHandShake, uint FlowReplace, uint XonLimit, uint XoffLimit, bool bGet)
		{
			Dump(time, (bGet ? "Get" : "Set") + " handflow: ControlHandShake=" + ControlHandShake + ", FlowReplace=" + FlowReplace + ", XonLimit=" + XonLimit +
				", XoffLimit=" + XoffLimit);
		}

		private void monitor_OnLineControl(DateTime time, uint WordLength, STOPBITS StopBits, PARITY Parity, bool bGet)
		{
			String[] StopBitsStrings = new String[] { "1", "1.5", "2" };
			String[] ParityStrings = new String[] { "NO_PARITY", "ODD_PARITY", "EVEN_PARITY	", "MARK_PARITY", "SPACE_PARITY" };

			Dump(time, (bGet ? "Get" : "Set") + " line control: WordLength=" + WordLength + ", StopBits=" + StopBitsStrings[(int)StopBits] + ", Parity=" + ParityStrings[(int)Parity]);
		}

		private void monitor_OnOpen(DateTime time, string Name, uint ProcessId)
		{
			Dump(time, "Device is opened by " + Name + "(" + ProcessId + ")");
		}

		private void monitor_OnPurge(DateTime time, PURGE Purge)
		{
			Dump(time, "Purge: " + Purge);
		}

		private void monitor_OnRead(DateTime time, Array array)
		{
			Dump(time, "Data Read: " + SmartRenderData(array));
		}

		private void monitor_OnReset(DateTime time)
		{
			Dump(time, "Reset");
		}

		private void monitor_OnRTS(DateTime time, bool bOn)
		{
			Dump(time, "RTS " + (bOn ? "ON" : "OFF"));
		}

		private void monitor_OnSerialChars(DateTime time, byte Eof, byte Error, byte Break, byte Event, byte Xon, byte Xoff, bool bGet)
		{
			Dump(time, (bGet ? "Get" : "Set") + " serial chars: (EOF,Error,Break,Event,XON,XOFF) (" +
				Eof + "," + Error + "," + Break + "," + Event + "," + Xon + "," + Xoff + ")");
		}

		private void monitor_OnSetBreak(DateTime time, bool bOn)
		{
			Dump(time, "Set break " + (bOn ? "ON" : "OFF"));
		}

		private void monitor_OnSetQueueSize(DateTime time, uint InSize, uint OutSize)
		{
			Dump(time, "Set queue size: InSize=" + InSize + ", OutSize=" + OutSize + ")");
		}

		private void monitor_OnStats(DateTime time, uint ReceivedCount, uint TransmittedCount, uint FrameErrorCount, uint SerialOverrunErrorCount, uint BufferOverrunErrorCount, uint ParityErrorCount)
		{
			Dump(time, "Comm stats: ReceivedCount=" + ReceivedCount + ", TransmittedCount=" + TransmittedCount + ", FrameErrorCount=" + FrameErrorCount +
				", SerialOverrunErrorCount=" + SerialOverrunErrorCount + ", BufferOverrunErrorCurrent=" + BufferOverrunErrorCount + ", ParityErrorCount=" +
				ParityErrorCount);
		}

		private void monitor_OnTimeouts(DateTime time, uint ReadIntervalTimeout, uint ReadTotalTimeoutMultiplier, uint ReadTotalTimeoutConstant, uint WriteTotalTimeoutMultiplier, uint WriteTotalTimeoutConstant, bool bGet)
		{
			Dump(time, (bGet ? "Get" : "Set") + " timeouts: ReadIntervalTimeout=" + ReadIntervalTimeout + ", ReadTotalTimeoutMultiplier=" + ReadTotalTimeoutMultiplier +
				", ReadTotalTimeoutConstant=" + ReadTotalTimeoutConstant + ", WriteTotalTimeoutMultiplier=" + WriteTotalTimeoutMultiplier +
				", WriteTotalTimeoutConstant=" + WriteTotalTimeoutConstant);
		}

		private void monitor_OnTransmit(DateTime time, Array array)
		{
			Dump(time, "Data Transmitted: " + SmartRenderData(array));
		}

		private void monitor_OnWaitMask(DateTime time, EVENTS WaitMask, bool bGet)
		{
			Dump(time, (bGet ? "Get" : "Set") + " wait mask: " + WaitMask);
		}

		private void monitor_OnWaitOnMask(DateTime time, EVENTS WaitMask)
		{
			Dump(time, "Wait on mask: " + WaitMask);
		}

		private void monitor_OnWrite(DateTime time, Array array)
		{
			Dump(time, "Data Written: " + SmartRenderData(array));
			Dump2(time, SmartRenderData(array));
		}

		private void monitor_OnXOFF(DateTime time)
		{
			Dump(time, "XOFF");
		}

		private void monitor_OnXON(DateTime time)
		{
			Dump(time, "XON");
		}

		delegate void DumpDelegate(string str);
		delegate void DumpDelegate2(string str);
		void DumpInternal(string str)
		{
			events.SelectedIndex = events.Items.Add(str);
		}
		void DumpInternal2(string str)
		{
			encoding.SelectedIndex = encoding.Items.Add(str);
		}


		private void Dump(DateTime time, string text)
		{
			string str = time.ToLocalTime().ToString("MM/dd/yyyy HH:mm:ss.ff") + "| " + text;
			events.Invoke(new DumpDelegate(DumpInternal), new object[] { str });			
		}
		private void Dump2(DateTime time, string text)
		{
			string str = text;
			encoding.Invoke(new DumpDelegate2(DumpInternal2), new object[] { str });
		}
	}
}
