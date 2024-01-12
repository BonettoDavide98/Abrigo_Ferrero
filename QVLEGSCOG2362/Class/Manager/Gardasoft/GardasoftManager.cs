using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QVLEGSCOG2362.Class
{
    public class GardasoftManager
    {

        private string ip = "";
        private int port = 0;
        TcpIpCommunicationClient tcpIp;
        string terminatore = "\n\r";

        public GardasoftManager(string ip, int port)
        {
            this.ip = ip;
            this.port = port;

            tcpIp = new TcpIpCommunicationClient(this.ip, this.port);
        }

        public bool EnableEthMessage(out string error)
        {
            string command = "GT1";

            string response = tcpIp.StartClient(command);

            if (command == response.Replace(terminatore, ""))
            {
                error = "";
                return true;
            }
            else
            {
                error = response;
                return false;
            }
        }

        //width e delay devono essere in K (1 = 1000)
        public bool SetParamOutput(int channel, double width, double delay, out string error)
        {
            string command = "RT" + channel.ToString() + "," + width.ToString("0.000", System.Globalization.CultureInfo.InvariantCulture) + "K" + "," + delay.ToString("0.000", System.Globalization.CultureInfo.InvariantCulture) + "K";

            string response = tcpIp.StartClient(command);

            if (command == response.Replace(terminatore, ""))
            {
                error = "";
                return true;
            }
            else
            {
                error = response;
                return false;
            }
        }

        public bool SetRetriggerTime(int channel, double delay, out string error)
        {
            string command = "RR" + channel.ToString() + "," + delay.ToString("0.000", System.Globalization.CultureInfo.InvariantCulture) + "K";

            string response = tcpIp.StartClient(command);

            if (command == response.Replace(terminatore, ""))
            {
                error = "";
                return true;
            }
            else
            {
                error = response;
                return false;
            }
        }

        public bool SetFreeRunningTrigger(int millisecond, out string error)
        {
            string command = "RB1," + millisecond.ToString() + "MS";

            string response = tcpIp.StartClient(command);

            if (command == response.Replace(terminatore, ""))
            {
                error = "";
                return true;
            }
            else
            {
                error = response;
                return false;
            }
        }

        //0 -> encoder off, 1 -> encoder one wire, 2 -> encoder two wire
        public bool SetEncoderMode(int mode, out string error)
        {
            string command = "RE" + mode.ToString();

            string response = tcpIp.StartClient(command);

            if (command == response.Replace(terminatore, ""))
            {
                error = "";
                return true;
            }
            else
            {
                error = response;
                return false;
            }
        }

        public string GetEncoderCount()
        {
            string command = "EN";

            string response = tcpIp.StartClient(command);

            return response;
        }

        public bool GetInputState(int channel)
        {
            bool ret = false;

            string command = "RI" + channel.ToString();

            string response = tcpIp.StartClient(command);

            response = response.Replace(terminatore, "");

            if (response.Contains(command + "VL"))
            {
                ret = (response.Replace(command + "VL", "") == "0") ? false : true;
            }

            return ret;
        }

        public bool GetOutputState(int channel)
        {
            bool ret = false;

            string command = "RO" + channel.ToString();

            string response = tcpIp.StartClient(command);

            response = response.Replace(terminatore, "");

            if (response.Contains(command + "VL"))
            {
                ret = (response.Replace(command + "VL", "") == "0") ? false : true;
            }

            return ret;
        }

        public bool DisableKeyboard(bool disable, out string error)
        {
            string command = "KB" + (disable ? "1" : "0");

            string response = tcpIp.StartClient(command);

            if (command == response.Replace(terminatore, ""))
            {
                error = "";
                return true;
            }
            else
            {
                error = response;
                return false;
            }
        }

        public bool OverrideOutputState(int channel, bool state, out string error)
        {
            string command = "RV" + channel.ToString() + "," + (state ? "1" : "0");

            string response = tcpIp.StartClient(command);

            if (command == response.Replace(terminatore, ""))
            {
                error = "";
                return true;
            }
            else
            {
                error = response;
                return false;
            }
        }

        public bool OverrideInputState(int channel, bool state, out string error)
        {
            string command = "MI" + channel.ToString() + "," + (state ? "1" : "0");

            string response = tcpIp.StartClient(command);

            if (command == response.Replace(terminatore, ""))
            {
                error = "";
                return true;
            }
            else
            {
                error = response;
                return false;
            }
        }

        public bool SaveConfiguration(out string error)
        {
            string command = "AW";

            string response = tcpIp.StartClient(command);

            if (command == response.Replace(terminatore, ""))
            {
                error = "";
                return true;
            }
            else
            {
                error = response;
                return false;
            }
        }

        public string GetFirmwareVersion()
        {
            string command = "VR";

            string response = tcpIp.StartClient(command);

            return response;
        }

        public string GetConfiguration()
        {
            string command = "ST";

            string response = tcpIp.StartClient(command);

            return response;
        }

        public string GetAnyErrorMessage()
        {
            string command = "GR";

            string response = tcpIp.StartClient(command);

            return response;
        }

    }
}
