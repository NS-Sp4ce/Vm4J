using System;
using System.Drawing;

namespace Vm4j_exp
{
    class Log
    {

        public delegate void LogAppendDelegate(Color color, string text);
        public void LogAppend(Color color, string text)
        {

            if (Form1.form.logTxtBox.Text.Length > 10000)
            {
                Form1.form.logTxtBox.Clear();
            }
            Form1.form.logTxtBox.SelectionColor = color;
            Form1.form.logTxtBox.HideSelection = false;
            Form1.form.logTxtBox.AppendText(text + Environment.NewLine);
        }

        public void LogError(string text)
        {

            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            Form1.form.logTxtBox.Invoke(la, Color.Red, "[" + DateTime.Now + "] " + text);
        }

        public void LogWarning(string text)
        {

            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            Form1.form.logTxtBox.Invoke(la, Color.Orange, "[" + DateTime.Now + "] " + text);
        }

        public void LogMessage(string text)
        {

            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            Form1.form.logTxtBox.Invoke(la, Color.Black, "[" + DateTime.Now + "] " + text);
        }
        public void LogInfo(string text)
        {

            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            Form1.form.logTxtBox.Invoke(la, Color.Blue, "[" + DateTime.Now + "] " + text);
        }
        public void LogSuccess(string text)
        {

            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            Form1.form.logTxtBox.Invoke(la, Color.Green, "[" + DateTime.Now + "] " + text);
        }

        delegate void DelegateAddItem(System.Windows.Forms.ListViewItem lvi);
    }
}
