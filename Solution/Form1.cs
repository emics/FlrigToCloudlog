using System.Configuration;
using System.Globalization;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Reflection;
using XmlRpc;
using Timer = System.Threading.Timer;

namespace FlrigToCloudlog
{
    public partial class Form1 : Form
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        public static ConfigData conf = new ConfigData();
        static FlrigClient flrigClient;
        Timer timer;
        Timer timerQueue;
        string LastSend = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
        bool isActiveRig = false;
        bool isActiveAdif = false;
        UdpServer udpServer = new UdpServer(2878);
        public static List<Queue> toDo = new List<Queue>();
        int updateAdifInterval = 15;

        public Form1()
        {
            InitializeComponent();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            Start();
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettings();
            if (conf.startMinimized)
            {
                Start();
                this.WindowState = FormWindowState.Minimized;                
            }
                
        }
        private void LoadSettings()
        {
            conf.cloudlogApiKey = ConfigurationManager.AppSettings["cloudlogApiKey"];
            conf.cloudlogUrl = ConfigurationManager.AppSettings["cloudlogUrl"];
            conf.flrigServerUrl = ConfigurationManager.AppSettings["flrigServerUrl"];
            conf.updateDelaySeconds = Convert.ToInt16(ConfigurationManager.AppSettings["updateDelaySeconds"]);
            conf.startMinimized = Convert.ToBoolean(ConfigurationManager.AppSettings["startMinimized"]);
            conf.udpPort = Convert.ToInt16(ConfigurationManager.AppSettings["udpPort"]);
            conf.idStation = Convert.ToInt16(ConfigurationManager.AppSettings["idStationLocation"]);
            conf.udpServer = Convert.ToBoolean(ConfigurationManager.AppSettings["udpServer"]);
            conf.rigServer = Convert.ToBoolean(ConfigurationManager.AppSettings["rigServer"]);

            txtCloudApiKey.Text = conf.cloudlogApiKey;
            txtCloudUrl.Text = conf.cloudlogUrl;
            txtFlRigUrl.Text = conf.flrigServerUrl;
            numDelaySec.Text = conf.updateDelaySeconds.ToString();
            numIdStation.Text = conf.idStation.ToString();
            numListenPort.Text = conf.udpPort.ToString();
            chkboxMinimized.Checked = conf.startMinimized;
            chkboxUDPServer.Checked = conf.udpServer;
            chkboxRigServer.Checked = conf.rigServer;

            if (chkboxRigServer.Checked)
                pbFlrig.Image = Properties.Resources.red;
            else
                pbFlrig.Image = Properties.Resources.gray;
            if (chkboxUDPServer.Checked)
                pbUDP.Image = Properties.Resources.red;
            else
                pbUDP.Image = Properties.Resources.gray;

            WriteStatus("Config Loaded. Press Start to run!");
        }
        private void SaveSettings(string key, string value)
        {
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
        }
        private void SaveSettings(string key, bool value)
        {
            config.AppSettings.Settings[key].Value = value.ToString();
            config.Save(ConfigurationSaveMode.Modified);
        }
        private void txtCloudApiKey_Leave(object sender, EventArgs e)
        {
            conf.cloudlogApiKey = txtCloudApiKey.Text;
            SaveSettings("cloudlogApiKey", txtCloudApiKey.Text);
        }
        private void txtCloudUrl_Leave(object sender, EventArgs e)
        {
            conf.cloudlogUrl = txtCloudUrl.Text;
            SaveSettings("cloudlogUrl", txtCloudUrl.Text);
        }
        private void txtFlRigUrl_Leave(object sender, EventArgs e)
        {
            conf.flrigServerUrl = txtFlRigUrl.Text;
            SaveSettings("flrigServerUrl", txtFlRigUrl.Text);
        }
        private void numDelaySec_Leave(object sender, EventArgs e)
        {
            conf.updateDelaySeconds = (int)numDelaySec.Value;
            SaveSettings("updateDelaySeconds", numDelaySec.Text);
        }
        private void numListenPort_Leave(object sender, EventArgs e)
        {
            conf.udpPort = (int)numListenPort.Value;
            SaveSettings("udpPort", numListenPort.Text);
        }
        private void numIdStation_Leave(object sender, EventArgs e)
        {
            conf.idStation = (int)numIdStation.Value;
            SaveSettings("idStationLocation", numIdStation.Text);
        }
        private void chkboxUDPServer_Leave(object sender, EventArgs e)
        {
            //conf.udpServer = (chkboxUDPServer.Checked) ? true : false;
            //SaveSettings("udpServer", conf.udpServer);
            //if (chkboxUDPServer.Checked)
            //    pbUDP.Image = Properties.Resources.red;
            //else
            //    pbUDP.Image = Properties.Resources.gray;
        }
        private void chkboxRigServer_Leave(object sender, EventArgs e)
        {
            //conf.rigServer = (chkboxRigServer.Checked) ? true : false;
            //SaveSettings("rigServer", conf.rigServer);
            //if (chkboxUDPServer.Checked)
            //    pbFlrig.Image = Properties.Resources.red;
            //else
            //    pbFlrig.Image = Properties.Resources.gray;
        }
        private void chkboxMinimized_Leave(object sender, EventArgs e)
        {
            conf.startMinimized = (chkboxMinimized.Checked) ? true : false;
            SaveSettings("startMinimized", conf.startMinimized);
        }
        public void setFlrigLight(Bitmap color)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<Bitmap>(setFlrigLight), new object[] { color });
                return;
            }
            pbFlrig.Image = color;
        }
        public void setUdpLight(Bitmap color)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<Bitmap>(setUdpLight), new object[] { color });
                return;
            }
            pbUDP.Image = color;
        }
        public void WriteStatus(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(WriteStatus), new object[] { value });
                return;
            }
            ssLabel.Text = value;
            statusStrip.Refresh();
        }
        public void WriteRigData(string value, System.Windows.Forms.Label label)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string, System.Windows.Forms.Label>(WriteRigData), new object[] { value, label });
                return;
            }
            setFlrigLight(Properties.Resources.orange);
            label.Text = value;
        }
        public void WriteAdifData(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(WriteAdifData), new object[] { value });
                return;
            }
            pbUDP.Image = Properties.Resources.orange;
            lblAdifData.Text = adifParser(value);
        }
        async void DoUpdate(object state)
        {
            OldData oldData = (OldData)state;
            setFlrigLight(Properties.Resources.orange);
            try
            {
                var frequency = await flrigClient.GetVfoAsync();
                var mode = await flrigClient.GetModeAsync();
                if (!String.IsNullOrEmpty(mode) && !String.IsNullOrEmpty(frequency))
                {
                    mode = MapMode(mode, frequency);
                }
                var powerWatts = await flrigClient.GetPowerAsync();

                if (frequency == oldData.Frequency && mode == oldData.Mode && oldData.PowerWatts == powerWatts)
                {
                    WriteStatus($"No Rig update needed, last send at {LastSend}");
                    setFlrigLight(Properties.Resources.green);
                    return;
                }

                var trxName = await flrigClient.GetXcvrAsync();
                var timestamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
                WriteRigData($"Rig:  {trxName}", lblRigDataName);
                WriteRigData($"Freq:  {(Convert.ToInt32(frequency) / 1000).ToString("N0")} Mhz", lblRigDataFrequency);
                WriteRigData($"Mode:  {mode}", lblRigDataMode);
                var data = new Dictionary<string, string>
                {
                    { "key", Form1.conf.cloudlogApiKey },
                    { "radio", trxName },
                    { "frequency", frequency.ToString() },
                    { "power", powerWatts.ToString() },
                    { "mode", mode },
                    { "timestamp", timestamp }
                };

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.PostAsJsonAsync(conf.cloudlogUrl + "/api/radio", data);
                    response.EnsureSuccessStatusCode();
                    LastSend = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
                    WriteStatus($"Data Rig sent to cloudlog: {response.StatusCode} at {LastSend}");
                    setFlrigLight(Properties.Resources.green);
                }

                oldData.Frequency = frequency;
                oldData.Mode = mode;
                oldData.PowerWatts = powerWatts;
            }
            catch (HttpRequestException e)
            {
                WriteStatus($"Send data Rig to cloudlog failed: {e.Message}");
                setFlrigLight(Properties.Resources.orange);
            }
            catch (SocketException e)
            {
                WriteStatus($"Receive data from flrig failed: {e.Message}");
                setFlrigLight(Properties.Resources.orange);
            }
        }
        static string MapMode(string mode, string frequency)
        {
            var uMode = mode.ToUpper();
            if (uMode.StartsWith("RTTY"))
                return "RTTY";
            if (uMode.StartsWith("DATA") || uMode.StartsWith("DIG"))
            {
                switch (frequency)
                {
                    case "1840000":
                    case "3573000":
                    case "7074000":
                    case "14074000":
                    case "28074000":
                    case "144174000":
                    case "432174000":
                    case "432500000":
                    case "1296174000":
                        return "FT8";
                    case "3575000":
                    case "7047500":
                    case "14080000":
                    case "21140000":
                    case "28180000":
                    case "144120000":
                    case "144170000":
                    case "432065000":
                    case "1296065000":
                        return "FT4";
                    default:
                        return "DATA";
                }
            }
            var index = uMode.IndexOf('-');
            if (index == -1)
                return uMode;
            return uMode.Substring(0, index - 1);
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized
            //hide it from the task bar
            //and show the system tray icon (represented by the NotifyIcon control)
            if (this.WindowState == FormWindowState.Minimized)
            {
                if (isActiveRig || isActiveAdif)
                {
                    notifyIcon.BalloonTipText = "Running!";
                    notifyIcon.Text = "FlrigToCloudlog - Running!";
                }
                else
                {
                    notifyIcon.BalloonTipText = "Stopped";
                    notifyIcon.Text = "FlrigToCloudlog - Stopped";
                }

                Hide();
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(1000);
            }
        }
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            chkboxShow.Checked = false;
            txtCloudApiKey.PasswordChar = '*';
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;

        }
        private void MenuItemShow_Click(object sender, EventArgs e)
        {
            Show();
            chkboxShow.Checked = false;
            txtCloudApiKey.PasswordChar = '*';
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }
        private void MenuItemStart_Click(object sender, EventArgs e)
        {
            Start();
        }
        private void Start()
        {
            btnStop.Enabled = true;
            btnStart.Enabled = false;
            MenuItemStop.Enabled = true;
            MenuItemStart.Enabled = false;
            txtCloudApiKey.Enabled = false;
            txtCloudUrl.Enabled = false;
            txtFlRigUrl.Enabled = false;
            numDelaySec.Enabled = false;
            numListenPort.Enabled = false;
            numIdStation.Enabled = false;
            chkboxMinimized.Enabled = false;
            chkboxUDPServer.Enabled = false;
            chkboxRigServer.Enabled = false;

            WriteStatus("Starting...");
            if (chkboxRigServer.Checked)
            {
                flrigClient = new FlrigClient(conf.flrigServerUrl);
                OldData oldData = new OldData();
                timer = new(DoUpdate, oldData, TimeSpan.Zero, TimeSpan.FromSeconds(conf.updateDelaySeconds));
                pbFlrig.Image = Properties.Resources.green;
                isActiveRig = true;
            }
            if (chkboxUDPServer.Checked)
            {
                udpServer = new UdpServer((int)numListenPort.Value);
                udpServer.Start();
                timerQueue = new(SendDataToCloud, toDo, TimeSpan.Zero, TimeSpan.FromSeconds(updateAdifInterval));
                pbUDP.Image = Properties.Resources.green;
                isActiveAdif = true;
            }

            if (conf.startMinimized)
                this.WindowState = FormWindowState.Minimized;
            notifyIcon.BalloonTipText = "Running!";
            notifyIcon.Text = "FlrigToCloudlog - Running!";
        }
        private void MenuItemStop_Click(object sender, EventArgs e)
        {
            Stop();
        }
        private void Stop()
        {
            if (isActiveRig)
            {
                pbFlrig.Image = Properties.Resources.red;
                timer.Dispose();
                isActiveRig = false;
            }
            else
                pbFlrig.Image = Properties.Resources.gray;

            if (isActiveAdif)
            {
                pbUDP.Image = Properties.Resources.red;
                udpServer.Stop();
                timerQueue.Dispose();
                isActiveAdif = false;
            }
            else
                pbUDP.Image = Properties.Resources.gray;

            btnStart.Enabled = true;
            btnStop.Enabled = false;
            MenuItemStop.Enabled = false;
            MenuItemStart.Enabled = true;
            txtCloudApiKey.Enabled = true;
            txtCloudUrl.Enabled = true;
            txtFlRigUrl.Enabled = true;
            numDelaySec.Enabled = true;
            numListenPort.Enabled = true;
            numIdStation.Enabled = true;
            chkboxMinimized.Enabled = true;
            chkboxUDPServer.Enabled = true;
            chkboxRigServer.Enabled = true;

            WriteStatus("Stopped!");
            notifyIcon.BalloonTipText = "Stopped";
            notifyIcon.Text = "FlrigToCloudlog - Stopped";

        }
        private void chkboxShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkboxShow.Checked)
                txtCloudApiKey.PasswordChar = '\0';
            else
                txtCloudApiKey.PasswordChar = '*';
        }
        private void labelAbout_Click(object sender, MouseEventArgs e)
        {
            About frm = new About();
            frm.ShowDialog();
        }
        private void chkboxUDPServer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkboxUDPServer.Checked)
            {
                numListenPort.Enabled = true;
                numIdStation.Enabled = true;
                pbUDP.Image = Properties.Resources.red;
            }
            else
            {
                numListenPort.Enabled = false;
                numIdStation.Enabled = false;
                pbUDP.Image = Properties.Resources.gray;
            }
            conf.udpServer = (chkboxUDPServer.Checked) ? true : false;
            SaveSettings("udpServer", conf.udpServer);
        }
        private void chkboxRigServer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkboxRigServer.Checked)
            {
                numDelaySec.Enabled = true;
                pbFlrig.Image = Properties.Resources.red;
            }
            else
            {
                numDelaySec.Enabled = false;
                pbFlrig.Image = Properties.Resources.gray;
            }

            conf.rigServer = (chkboxRigServer.Checked) ? true : false;
            SaveSettings("rigServer", conf.rigServer);
        }
        async private void SendDataToCloud(object state)
        {
            List<Queue> listQueue = (List<Queue>)state;
            foreach (var q in listQueue)
            {
                if (!q.published)
                {
                    setUdpLight(Properties.Resources.orange);
                    WriteAdifData(q.txt);
                    q.published = true;
                }

                if (!q.send)
                {
                    setUdpLight(Properties.Resources.orange);
                    var data = new Dictionary<string, string>
                    {
                        { "key", conf.cloudlogApiKey },
                        { "station_profile_id", numIdStation.Value.ToString() },
                        { "type", "adif" },
                        { "string", q.txt }
                    };

                    using (var httpClient = new HttpClient())
                    {
                        var response = await httpClient.PostAsJsonAsync(Form1.conf.cloudlogUrl + "/api/qso/", data);
                        response.EnsureSuccessStatusCode();
                        switch (response.StatusCode)
                        {
                            case System.Net.HttpStatusCode.OK:
                            case System.Net.HttpStatusCode.Created:
                            case System.Net.HttpStatusCode.Accepted:
                                q.send = true;
                                WriteStatus($"ADIF Data [{adifTagParser(q.txt, "<CALL:")}] sent to cloudlog at {DateTime.Now.ToString("yyyy/MM/dd HH:mm")}");
                                break;
                            default:
                                WriteStatus($"Send ADIF to cloudlog failed: {response.StatusCode} {response.Content}");
                                break;
                        }
                    }
                }
            }
            if (isActiveAdif)
                setUdpLight(Properties.Resources.green);
            else
            {
                if (chkboxUDPServer.Checked)
                    setUdpLight(Properties.Resources.red);
                else
                    setUdpLight(Properties.Resources.gray);
            }
        }
        private static string adifParser(string text)
        {
            String newText = text;
            string tagCallName = "<CALL:";
            string tagName = "<NAME:";
            string tagMode = "<MODE:";
            string tagBand = "<BAND:";
            string tagDate = "<QSO_DATE:";
            string tagTime = "<TIME_ON:";
            string tagCountry = "<COUNTRY:";
            string tagContinent = "<CONT:";
            string tagRstS = "<RST_SENT:";
            string tagRstR = "<RST_RCVD:";


            newText = $"{adifTagParser(text, tagCallName)}\r\n"
                    + $"{adifTagParser(text, tagName)}\r\n"
                    + $"Band: {adifTagParser(text, tagBand)} Mode: {adifTagParser(text, tagMode)}\r\n"
                    + $"{DateTime.ParseExact(adifTagParser(text, tagDate), "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd")} "
                    + $"{DateTime.ParseExact(adifTagParser(text, tagTime), "HHmmss", CultureInfo.InvariantCulture).ToString("HH:mm")} UTC\r\n"
                    + $"{adifTagParser(text, tagCountry)} {adifTagParser(text, tagContinent)}\r\n"
                    + $"RST Sent:{adifTagParser(text, tagRstS)}  RST Rcvd:{adifTagParser(text, tagRstR)}";


            return newText;
        }
        private static string adifTagParser(string text, string tag)
        {
            String newText = "";
            try
            {
                int pos = text.IndexOf(tag);
                if (pos > -1)
                {
                    int posBracketClose = text.IndexOf(">", pos);
                    int l = posBracketClose - (pos + tag.Length);
                    string len = text.Substring(pos + tag.Length, l);
                    newText = text.Substring(pos + tag.Length + len.Length + ">".Length, Convert.ToInt16(len));
                }
            }
            catch { }
            return newText;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
            Thread.Sleep(3000);
        }
    }

    public class ConfigData
    {
        public string flrigServerUrl { get; set; }
        public string cloudlogUrl { get; set; }
        public string cloudlogApiKey { get; set; }
        public int updateDelaySeconds { get; set; }
        public bool startMinimized { get; set; }
        public int udpPort { get; set; }
        public bool udpServer { get; set; }
        public bool rigServer { get; set; }
        public int idStation { get; set; }
    }

    class OldData
    {
        public string Frequency { get; set; }
        public string Mode { get; set; }
        public string PowerWatts { get; set; }
    }

    class FlrigClient
    {
        private string _baseUrl;
        public FlrigClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }
        public async Task<string> GetVfoAsync()
        {
            // Implement this method to get VFO frequency from flrig
            // Example: 
            //var response = await HttpClient.GetAsync(_baseUrl + "/get_vfo");
            //response.EnsureSuccessStatusCode();
            //return await response.Content.ReadAsStringAsync();
            try {
                XmlRpcClient client = new XmlRpcClient();
                client.Url = _baseUrl;
                XmlRpcResponse response = client.Execute("rig.get_vfo");
                if (response.IsFault())
                {
                    throw new SocketException(100, response.GetFaultString());
                }
                else
                {
                    return response.GetString();
                }
            }
            catch (Exception ex)
            {
                throw new SocketException(100,ex.Message);
            }
            
            return null;
        }
        public async Task<string> GetModeAsync()
        {
            try
            {
                XmlRpcClient client = new XmlRpcClient();
                client.Url = _baseUrl;
                XmlRpcResponse response = client.Execute("rig.get_mode");
                if (response.IsFault())
                {
                    throw new SocketException(100, response.GetFaultString());
                }
                else
                {
                    return response.GetString();
                }
            }
            catch (Exception ex)
            {
                throw new SocketException(100, ex.Message);
            }
            return null;
        }
        public async Task<string> GetPowerAsync()
        {
            try
            {
                XmlRpcClient client = new XmlRpcClient();
                client.Url = _baseUrl;
                XmlRpcResponse response = client.Execute("rig.get_power");
                if (response.IsFault())
                {
                    throw new SocketException(100, response.GetFaultString());
                }
                else
                {
                    return response.GetString();
                }
            }
            catch (Exception ex)
            {
                throw new SocketException(100, ex.Message);
            }
            return null;
        }
        public async Task<string> GetXcvrAsync()
        {
            try
            {
                XmlRpcClient client = new XmlRpcClient();
                client.Url = _baseUrl;
                XmlRpcResponse response = client.Execute("rig.get_xcvr");
                if (response.IsFault())
                {
                    throw new SocketException(100, response.GetFaultString());
                }
                else
                {
                    return response.GetString();
                }
            }
            catch (Exception ex)
            {
                throw new SocketException(100, ex.Message);
            }
            return null;
        }
    }

    public class Queue
    {
        public string txt { get; set; }
        public bool published { get; set; }
        public bool send { get; set; }
    }
}
