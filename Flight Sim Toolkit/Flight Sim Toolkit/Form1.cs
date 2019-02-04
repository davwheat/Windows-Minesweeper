using Flight_Sim_Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordRPC;
using DiscordRPC.Logging;
using Timer = System.Timers.Timer;

namespace Flight_Sim_Toolkit
{
    public partial class Form1 : Form
    {
        public DiscordRpcClient client;
        private Timestamps currentTimestampInfo;
        private readonly Timer discordClientTimer = new Timer(250);

        public Form1()
        {
            InitializeComponent();
            SetAppStatus("Waiting for initialisation...");


        }

        void SetAppStatus(string status)
        {
            currentStatusLabel.Text = status;
        }

        void Debug(string msg)
        {
            debugTextbox.AppendText(new DebugMessage(msg).ToString());
        }
        void Debug(string msg, MessageType type)
        {
            debugTextbox.AppendText(new DebugMessage(type, msg).ToString());
        }
        void Debug(DebugMessage msg)
        {
            debugTextbox.AppendText(msg.ToString());
        }

        public void Initialise()
        {
            /*
            Create a discord client
            NOTE: 	If you are using Unity3D, you must use the full constructor and define
                     the pipe connection as DiscordRPC.IO.NativeNamedPipeClient
            */
            client = new DiscordRpcClient("528209654887612427")
            {
                //Set the logger
                Logger = new ConsoleLogger { Level = LogLevel.Warning }
            };

            currentTimestampInfo = Timestamps.Now;

            //Subscribe to events
            client.OnReady += (sender, e) =>
            {
                debugTextbox.AppendText($"\nReceived Ready from user {e.User.Username}");
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                debugTextbox.AppendText($"\nReceived Update! {e.Presence}");
            };

            //Connect to the RPC
            client.Initialize();

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            SetPresence("Flight Sim Toolkit", "Preparing flight...");

            discordClientTimer.Start();
        }

        public void SetPresence(string top, string bottom, Assets assets = null, Timestamps timestamps = null, bool useCurrentTimestamps = true)
        {
            if (assets == null)
                assets = new Assets { LargeImageKey = "default", LargeImageText = "Flight Sim Toolkit" };

            if (timestamps == null && useCurrentTimestamps)
                timestamps = currentTimestampInfo;
            else if (timestamps == null)
            {
                client.SetPresence(new RichPresence()
                {
                    Details = "Flying a plane",
                    State = "Preflight Checks",
                    Assets = assets
                });
            }

            client.SetPresence(new RichPresence()
            {
                Details = "Flying a plane",
                State = "Preflight Checks",
                Assets = assets,
                Timestamps = timestamps
            });
        }

        private void SettingChanged(object sender, EventArgs e)
        {
            var cb = (CheckBox) sender;

            switch (cb.Name)
            {
                default:
                    break;

                case "discordCheckbox":
                    Properties.Settings.Default.discordConnect = cb.Checked;
                    Properties.Settings.Default.Save();
                    break;

                case "scenariosCheckbox":
                    Properties.Settings.Default.randomScenarios = cb.Checked;
                    Properties.Settings.Default.Save();
                    break;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            discordClientTimer.Stop();
            // Tell Discord to clear the presence
            if (client != null && client.IsInitialized)
            {
                client.Dispose();
            }
        }

        private void initialiseFlightBtn_Click(object sender, EventArgs e)
        {
            DisableInitialisationControls();

            var validation = ValidateFlightInfo();

            if (!validation.Item1)
            {
                MessageBox.Show($"Failed to initialise flight: {validation.Item2}.");
                EnableInitialisationControls();
                return;
            }

            if (Properties.Settings.Default.discordConnect)
            {

            }
        }

        private Tuple<bool, string> ValidateFlightInfo()
        {
            if (flightNumberTextbox.Text == "" && callsignTextbox.Text == "")
            {
                return new Tuple<bool, string>(false, "You must enter a flight number or callsign");
            }

            if (departureICAOtextbox.Text == "" || arrivalICAOtextbox.Text == "" || onlineNetworkSelect.SelectedText == "" || aircraftName.Text == "")
            {
                return new Tuple<bool, string>(false, "Please fill in all required fields");
            }

            return new Tuple<bool, string>(true, "Success!");
        }

        private void callsignTextbox_TextChanged(object sender, EventArgs e)
        {
            initialiseViaVatsimAPIbtn.Enabled = ((TextBox) sender).TextLength > 0;
        }

        private void DisableInitialisationControls()
        {
            initControlsBox1.Enabled = false;
            initControlsBox2.Enabled = false;
            initialiseFlightBtn.Enabled = false;
        }

        private void EnableInitialisationControls()
        {
            initControlsBox1.Enabled = true;
            initControlsBox2.Enabled = true;
            initialiseFlightBtn.Enabled = true;
        }

        private void initialiseViaVatsimAPIbtn_Click(object sender, EventArgs e)
        {
            DisableInitialisationControls();

            try
            {

            }
            catch (VATSIMDownloadFailureException exception)
            {
                MessageBox.Show(exception.Message);
                
            }

            EnableInitialisationControls();
        }
    }
}
