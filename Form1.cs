#nullable disable
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace Hik_IPS
{
    public partial class Form1 : Form
    {
        private readonly NetworkCredential cameraCredentials = new();
        private string cameraName, ipA, portN, ipsV, sunriseS, sunriseO, sunsetS, sunsetO;
        private readonly DateTime[] middleMonth = new DateTime[13];
        private readonly DateTime[,] dayP = new DateTime[13, 3];

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            LoadIniFile();
            UpdateTodaySunTimes();
            ControlsOn(true);
        }

        private void LoadIniFile()
        {
            if (File.Exists("Hik_IPS_Settings.ini"))
            {
                var iniFile = File.OpenRead("Hik_IPS_Settings.ini");
                var iniReader = new StreamReader(iniFile);
                Username.Text = iniReader.ReadLine();
                cameraCredentials.UserName = Username.Text;
                Latitude.Text = iniReader.ReadLine();
                Longitude.Text = iniReader.ReadLine();
                while (!iniReader.EndOfStream)
                {
                    CameraGrid.Rows.Add(iniReader.ReadLine(), iniReader.ReadLine(), iniReader.ReadLine(),
                                        iniReader.ReadLine(), iniReader.ReadLine(), iniReader.ReadLine(),
                                        iniReader.ReadLine(), iniReader.ReadLine(), iniReader.ReadLine());
                    CameraGrid[1, CameraGrid.Rows.Count - 1].Value = "  ?";
                }
                iniFile.Close();
            }
            if (CameraGrid.RowCount > 0) { CameraGrid.CurrentCell.Selected = false; }
        }

        private void UpdateIniFile()
        {
            string iniFileText = Username.Text + Environment.NewLine + Latitude.Text + Environment.NewLine + Longitude.Text;
            for (int gridRow = 0, loopTo = CameraGrid.Rows.Count - 1; gridRow <= loopTo; gridRow++)
            {
                for (int gridCol = 0; gridCol <= 8; gridCol++)
                    iniFileText += Environment.NewLine + CameraGrid[gridCol, gridRow].Value.ToString();
            }
            File.WriteAllText("Hik_IPS_Settings.ini", iniFileText);
        }

        private void ControlsOn(bool setOn)
        {
            IpsOff.Enabled = setOn;
            IpsOn.Enabled = setOn;
            Username.Enabled = setOn;
            Password.Enabled = setOn;
            Latitude.Enabled = setOn;
            Longitude.Enabled = setOn;
            if (!string.IsNullOrEmpty(CameraIp.Text) & !string.IsNullOrEmpty(CameraPort.Text))
            {
                AddCamera.Enabled = setOn;
            }
            CameraIp.Enabled = setOn;
            CameraPort.Enabled = setOn;
            if (CameraGrid.RowCount == 0)
            {
                Edit.Enabled = false;
                IpsOff.Enabled = false;
                IpsOn.Enabled = false;
            }
            else
            {
                CameraGrid.CurrentCell.Selected = false;
            }
            Application.DoEvents();
        }

        public void IpsOff_Click(object sender, EventArgs e)
        {
            SetIps(false);
        }

        public void IpsOn_Click(object sender, EventArgs e)
        {
            SetIps(true);
        }

        public void SetIps(bool ipsOn)
        {
            ControlsOn(false);
            Edit.Enabled = false;
            int currentMonth = DateTime.Now.Month;
            int addMonths = 0;
            while (addMonths < 12)
            {
                middleMonth[currentMonth] = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15).AddMonths(addMonths);
                dayP[currentMonth, 1] = UtcSunTime(middleMonth[currentMonth], Convert.ToDouble(Latitude.Text), Convert.ToDouble(Longitude.Text), "Sunrise").ToLocalTime();
                dayP[currentMonth, 2] = UtcSunTime(middleMonth[currentMonth], Convert.ToDouble(Latitude.Text), Convert.ToDouble(Longitude.Text), "Sunset").ToLocalTime();
                currentMonth += 1;
                if (currentMonth > 12) { currentMonth = 1; }
                addMonths += 1;
            }
            for (int gridRow = 0, loopTo = CameraGrid.Rows.Count - 1; gridRow <= loopTo; gridRow++)
            {
                cameraName = CameraGrid[0, gridRow].Value.ToString();
                ipA = CameraGrid[2, gridRow].Value.ToString();
                portN = CameraGrid[3, gridRow].Value.ToString();
                ipsV = CameraGrid[4, gridRow].Value.ToString();
                sunriseS = ConvertScene(CameraGrid[5, gridRow].Value.ToString());
                sunriseO = CameraGrid[6, gridRow].Value.ToString();
                sunsetS = ConvertScene(CameraGrid[7, gridRow].Value.ToString());
                sunsetO = CameraGrid[8, gridRow].Value.ToString();
                if (ipsV == "V1.0")
                {
                    if (!V1IpsRequest(ipsOn))
                    {
                        break;
                    }
                }
                else if (!V2IpsRequest(ipsOn))
                {
                    break;
                }
                if (ipsOn)
                {
                    CameraGrid[1, gridRow].Value = "ON";
                    CameraGrid[1, gridRow].Style.ForeColor = Color.Green;
                }
                else
                {
                    CameraGrid[1, gridRow].Value = "OFF";
                    CameraGrid[1, gridRow].Style.ForeColor = Color.Red;
                }
                CameraGrid.CurrentCell = CameraGrid[1, gridRow];
                Application.DoEvents();
                Thread.Sleep(100);
            }
            ControlsOn(true);
            Edit.Enabled = true;
        }

        public bool V1IpsRequest(bool ipsOn)
        {
            string reqC = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<DisplayParamSwitch>";
            if (!ipsOn)
            {
                reqC += "<mode>disable</mode>";
            }
            reqC += "<mode>timingSwitch</mode><TimingSwitch><PeriodList>";
            reqC += "<Period><id>" + "1" + "</id><enabled>true</enabled><TimeRange>" + "<beginTime>" + "00:00:00" + "</beginTime>" + "<endTime>" + dayP[DateTime.Now.Month, 1].AddMinutes(Convert.ToDouble(sunriseO)).ToString("HH:mm:ss") + "</endTime></TimeRange>" + "<linkScene>" + sunsetS + "</linkScene></Period>";
            reqC += "<Period><id>" + "2" + "</id><enabled>true</enabled><TimeRange>" + "<beginTime>" + dayP[DateTime.Now.Month, 1].AddMinutes(Convert.ToDouble(sunriseO)).ToString("HH:mm:ss") + "</beginTime>" + "<endTime>" + dayP[DateTime.Now.Month, 2].AddMinutes(Convert.ToDouble(sunsetO)).ToString("HH:mm:ss") + "</endTime></TimeRange>" + "<linkScene>" + sunriseS + "</linkScene></Period>";
            reqC += "<Period><id>" + "3" + "</id><enabled>true</enabled><TimeRange>" + "<beginTime>" + dayP[DateTime.Now.Month, 2].AddMinutes(Convert.ToDouble(sunsetO)).ToString("HH:mm:ss") + "</beginTime>" + "<endTime>" + "23:59:59" + "</endTime></TimeRange>" + "<linkScene>" + sunsetS + "</linkScene></Period>";
            reqC += "<Period><id>" + "4" + "</id><enabled>false</enabled><TimeRange>" + "<beginTime>" + "00:00:00" + "</beginTime>" + "<endTime>" + "00:00:00" + "</endTime></TimeRange>" + "<linkScene>" + sunsetS + "</linkScene></Period>";
            reqC += "</PeriodList></TimingSwitch></DisplayParamSwitch>";
            return IpsRequest(reqC);
        }

        public bool V2IpsRequest(bool ipsOn)
        {
            string reqC = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<DisplayParamSwitch version=\"2.0\" xmlns=\"http://www.hikvision.com/ver20/XMLSchema\">";
            if (!ipsOn)
            {
                reqC += "<mode>disable</mode>";
            }
            reqC += "<mode>month</mode><Month><PeriodList size=\"12\">";
            for (int x = 1; x <= 12; x++)
            {
                reqC += "<Period><id>" + x.ToString() + "</id><TimeRangeList>";
                reqC += "<TimeRange><beginTime>" + "00:00:00" + "</beginTime>" + "<endTime>" + dayP[x, 1].AddMinutes(Convert.ToDouble(sunriseO)-1).ToString("HH:mm:ss") + "</endTime>" + "<linkScene>" + sunsetS + "</linkScene></TimeRange>";
                reqC += "<TimeRange><beginTime>" + dayP[x, 1].AddMinutes(Convert.ToDouble(sunriseO)).ToString("HH:mm:ss") + "</beginTime>" + "<endTime>" + dayP[x, 2].AddMinutes(Convert.ToDouble(sunsetO)-1).ToString("HH:mm:ss") + "</endTime>" + "<linkScene>" + sunriseS + "</linkScene></TimeRange>";
                reqC += "<TimeRange><beginTime>" + dayP[x, 2].AddMinutes(Convert.ToDouble(sunsetO)).ToString("HH:mm:ss") + "</beginTime>" + "<endTime>" + "24:00:00" + "</endTime>" + "<linkScene>" + sunsetS + "</linkScene></TimeRange>";
                reqC += "</TimeRangeList></Period>";
            }
            reqC += "</PeriodList></Month></DisplayParamSwitch>";
            return IpsRequest(reqC);
        }

        public bool IpsRequest(string reqContent)
        {
            try
            {
                var cameraHandler = new HttpClientHandler() { Credentials = cameraCredentials };
                var cameraClient = new HttpClient(cameraHandler) { Timeout = TimeSpan.FromSeconds(15) };
                var cameraRequest = new HttpRequestMessage()
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri("http://" + ipA + ":" + portN + "/ISAPI/Image/Channels/1/displayParamSwitch"),
                    Content = new StringContent(reqContent, Encoding.UTF8)
                };
                var cameraResponse = cameraClient.Send(cameraRequest);
                cameraResponse.EnsureSuccessStatusCode();
            }
            catch (Exception exceptionError)
            {
                if (exceptionError.Message.Contains("401"))
                {
                    MessageBox.Show("Invalid username/password", "IPS request error");
                }
                else
                {
                    MessageBox.Show(string.Format("Error: {0}", exceptionError.Message), "IPS request error");
                }
                return false;
            }
            return true;
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (Edit.Text == "Edit")
            {
                Edit.Text = "Done";
                CameraGrid.ReadOnly = false;
                CameraGrid.Columns[0].ReadOnly = true;
                CameraGrid.Columns[1].ReadOnly = true;
                CameraGrid.Columns[2].ReadOnly = true;
                CameraGrid.Columns[3].ReadOnly = true;
                CameraGrid.Columns[4].ReadOnly = true;
                CameraGrid.AllowUserToAddRows = false;
                CameraGrid.ShowEditingIcon = true;
                DeleteCamera.Enabled = true;
                ControlsOn(false);
                CameraGrid.CurrentCell = CameraGrid[0, CameraGrid.CurrentCell.RowIndex];
                CameraGrid.CurrentCell.Selected = true;
            }
            else
            {
                for (int x = 0, loopTo = CameraGrid.Rows.Count - 1; x <= loopTo; x++)
                {
                    if (CheckScene(Convert.ToString(CameraGrid[4, x].Value), Convert.ToString(CameraGrid[5, x].Value)) == false)
                    {
                        MessageBox.Show(CameraGrid[0, x].Value + " scene " + CameraGrid[5, x].Value + " is not valid for IPS version " + CameraGrid[4, x].Value, "Error invalid scene");
                        CameraGrid.CurrentCell = CameraGrid[4, x];
                        return;
                    }
                    if (CheckScene(Convert.ToString(CameraGrid[4, x].Value), Convert.ToString(CameraGrid[7, x].Value)) == false)
                    {
                        MessageBox.Show(CameraGrid[0, x].Value + " scene " + CameraGrid[7, x].Value + " is not valid for IPS version " + CameraGrid[4, x].Value, "Error invalid scene");
                        CameraGrid.CurrentCell = CameraGrid[4, x];
                        return;
                    }
                }
                Edit.Text = "Edit";
                CameraGrid.ReadOnly = true;
                CameraGrid.ShowEditingIcon = false;
                DeleteCamera.Enabled = false;
                ControlsOn(true);
                UpdateIniFile();
            }
        }

        private static bool CheckScene(string inVer, string inScene)
        {
            string V1Scenes = "Morning Day Nightfall Night Low Illumination Indoor Outdoor Street Custom1 Custom2";
            string v2Scenes = "Normal Low Illumination Back light Front light Custom1 Custom2";
            if (inVer == "V1.0" & !V1Scenes.Contains(inScene))
            {
                return false;
            }
            if (inVer == "V2.0" & !v2Scenes.Contains(inScene))
            {
                return false;
            }
            return true;
        }

        private void DeleteCamera_Click(object sender, EventArgs e)
        {
            CameraGrid.Rows.RemoveAt(CameraGrid.CurrentRow.Index);
            UpdateIniFile();
            if (CameraGrid.RowCount == 0)
            {
                DeleteCamera.Enabled = false;
            }
        }

        private async void AddCamera_Click(object sender, EventArgs e)
        {
            for (int x = 1, loopTo = CameraGrid.RowCount; x <= loopTo; x++)
            {
                if (CameraGrid[2, x - 1].Value.ToString() == CameraIp.Text && CameraGrid[3, x - 1].Value.ToString() == CameraPort.Text)
                {
                    MessageBox.Show("Camera at " + CameraIp.Text + ":" + CameraPort.Text + " already added.", "Error adding camera");
                    return;
                }
            }
            ControlsOn(false);
            Edit.Enabled = false;
            try
            {
                var cameraHandler = new HttpClientHandler() { Credentials = cameraCredentials };
                var cameraClient = new HttpClient(cameraHandler) { Timeout = TimeSpan.FromSeconds(15) };

                var cameraRequest = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("http://" + CameraIp.Text + ":" + CameraPort.Text + "/ISAPI/Streaming/channels/101/capabilities")
                };
                var cameraResponse = cameraClient.Send(cameraRequest);
                cameraResponse.EnsureSuccessStatusCode();
                string cameraStream = await cameraResponse.Content.ReadAsStringAsync().ConfigureAwait(true);
                string Xml = cameraStream.ToString();
                Xml = Xml.Replace(" version=\"2.0\" xmlns=\"http://www.hikvision.com/ver20/XMLSchema\"", "");
                var xElement = XElement.Parse(Xml, options: LoadOptions.None);
                cameraName = xElement.Element("channelName").Value.ToString();
                var cameraRequest2 = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("http://" + CameraIp.Text + ":" + CameraPort.Text + "/ISAPI/Image/Channels/1/displayParamSwitch")
                };
                var cameraResponse2 = cameraClient.Send(cameraRequest2);
                cameraResponse2.EnsureSuccessStatusCode();
                string cameraStream2 = await cameraResponse2.Content.ReadAsStringAsync().ConfigureAwait(true);
                if (cameraStream2.Contains("<mode>timingSwitch</mode>"))
                {
                    ipsV = "V1.0";
                    sunriseS = "Day";
                    sunsetS = "Night";
                }
                else if (cameraStream2.Contains("DisplayParamSwitch version=\"2.0\""))
                {
                    ipsV = "V2.0";
                    sunriseS = "Normal";
                    sunsetS = "Low Illumination";
                }
                else
                {
                    MessageBox.Show("Camera does not use IPS.", "Error adding camera...");
                    CameraIp.Focus();
                    return;
                }
            }
            catch (Exception exceptionError)
            {
                if (exceptionError.Message.Contains("401"))
                {
                    MessageBox.Show("Invalid camera username/password.", "Error adding camera");
                }
                else if (exceptionError.Message.Contains("404"))
                {
                    MessageBox.Show("Invalid camera IP address or port number.",  "Error adding camera");
                }
                else if (exceptionError.Message.Contains("target machine actively refused it"))
                {
                    MessageBox.Show("Invalid camera port number: " + CameraPort.Text, "Error adding camera");
                }
                else if (exceptionError.Message.Contains("Invalid URI"))
                {
                    MessageBox.Show("Invalid camera IP address or port number.", "Error adding camera");
                }
                else if (exceptionError.Message.Contains("No such host"))
                {
                    MessageBox.Show("Camera not found at IP address: " + CameraIp.Text, "Error adding camera");
                }
                else if (exceptionError.Message.Contains("unreachable network"))
                {
                    MessageBox.Show("Camera not found at IP address: " + CameraIp.Text, "Error adding camera");
                }
                else if (exceptionError.Message.Contains("Timeout"))
                {
                    MessageBox.Show("No reply from IP address: " + CameraIp.Text, "Error adding camera");
                }
                else
                {
                    MessageBox.Show("Error: {0}" + exceptionError.Message, "Error adding camera");
                }
                Edit.Enabled = true;
                ControlsOn(true);
                return;
            }
            CameraGrid.Rows.Add(cameraName, "?", CameraIp.Text, CameraPort.Text, ipsV, sunriseS, "0", sunsetS, "0");
            CameraGrid.CurrentCell = CameraGrid[0, CameraGrid.Rows.Count - 1];
            CameraIp.Text = "";
            CameraPort.Text = "";
            Edit.Enabled = true;
            ControlsOn(true);
            UpdateIniFile();
        }

        private void CameraIp_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CameraIp.Text) & !string.IsNullOrEmpty(CameraPort.Text))
            {
                AddCamera.Enabled = true;
            }
            else
            {
                AddCamera.Enabled = false;
            }
        }

        private void CameraPort_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CameraIp.Text) & !string.IsNullOrEmpty(CameraPort.Text))
            {
                AddCamera.Enabled = true;
            }
            else
            {
                AddCamera.Enabled = false;
            }
        }

        private void Username_Leave(object sender, EventArgs e)
        {
            cameraCredentials.UserName = Username.Text;
            UpdateIniFile();
        }

        private void Password_Leave(object sender, EventArgs e)
        {
            cameraCredentials.Password = Password.Text;
        }

        private void UpdateTodaySunTimes()
        {
            SunriseToday.Text = UtcSunTime(DateTime.Now, Convert.ToDouble(Latitude.Value), Convert.ToDouble(Longitude.Value), "Sunrise").ToLocalTime().ToString("hh:mm:ss tt");
            SunsetToday.Text = UtcSunTime(DateTime.Now, Convert.ToDouble(Latitude.Value), Convert.ToDouble(Longitude.Value), "Sunset").ToLocalTime().ToString("hh:mm:ss tt");
        }

        private void Latitude_ValueChanged(object sender, EventArgs e)
        {
            if (Latitude.Value >= -90 && Latitude.Value <= 90) UpdateTodaySunTimes();
        }

        private void Longitude_ValueChanged(object sender, EventArgs e)
        {
            if (Longitude.Value >= -180 && Longitude.Value <= 180) UpdateTodaySunTimes();
        }

        private void Latitude_Leave(object sender, EventArgs e)
        {
            UpdateIniFile();
        }

        private void Longitude_Leave(object sender, EventArgs e)
        {
            UpdateIniFile();
        }

        private static string ConvertScene(string inScene)
        {
            inScene = inScene.Replace(" ", "");
            string firstChar = inScene.Substring(0, 1);
            firstChar = firstChar.ToLower();
            string ConvertSceneRet = string.Concat(firstChar, inScene.Substring(1, inScene.Length - 1));
            return ConvertSceneRet;
        }

        public static DateTime UtcSunTime(DateTime sunDate, double locationLat, double locationLon, string sunType)
        {
            // DateTime UtcSunTimeRet = default;
            // return the UTC of sunrise or sunset in hours (modfied returns datetime)
            // return -1 if sun never rises, -2 if it never sets (modified assumes sun allways rises/sets)
            // locationLat and locationLon are the locationLat/locationLon of the location in degrees
            // sunZenith is the sunZenith in degrees
            // =90.8333333 for official sunset
            // =96 for civil twilight
            // =102 for nautical twilight
            // =108 for astronomical twilight
            // sunriseOrSunset =True for sunrise, False for sunset

            double sunZenith = 90.8333333333333;
            Boolean sunriseOrSunset;
            if (sunType == "Sunrise") { sunriseOrSunset = true; } else {  sunriseOrSunset = false; }
            double toRad = Math.PI / 180d;
            // 1. first calculate the day of the year
            double dayCalc1 = Convert.ToDouble(275 * sunDate.Month / 9d);
            double dayCalc2 = Convert.ToDouble((sunDate.Month + 9) / 12d);
            double dayCalc3 = 1d + Convert.ToDouble((Thread.CurrentThread.CurrentCulture.Calendar.GetYear(sunDate) - 4d * Convert.ToDouble(Thread.CurrentThread.CurrentCulture.Calendar.GetYear(sunDate) / 4d) + 2d) / 3d);
            double dayOfYear = dayCalc1 - dayCalc2 * dayCalc3 + Thread.CurrentThread.CurrentCulture.Calendar.GetDayOfMonth(sunDate) - 30d;
            // 2. convert the longitude to hour value and calculate an approximate time
            double lonHour = locationLon / 15d;
            double sunLocalMeanTime;
            if (sunriseOrSunset)
            {
                sunLocalMeanTime = dayOfYear + (6d - lonHour) / 24d;
            }
            else
            {
                sunLocalMeanTime = dayOfYear + (18d - lonHour) / 24d;
            }
            // 3. calculate the Sun's mean anomaly
            double meanAnomaly = 0.9856d * sunLocalMeanTime - 3.289d;
            // 4. calculate the Sun's true longitude
            double sunTrueLon = meanAnomaly + 1.916d * Math.Sin(toRad * meanAnomaly) + 0.02d * Math.Sin(toRad * 2d * meanAnomaly) + 282.634d;
            // sunTrueLon = sunTrueLon Mod 360 ?
            if (sunTrueLon < 0d)
            {
                sunTrueLon += 360d;
            }
            else if (sunTrueLon >= 360d)
            {
                sunTrueLon -= 360d;
            }
            // 5a. calculate the Sun's right ascension
            double sunRightAscension = 1d / toRad * Math.Atan(0.91764d * Math.Tan(toRad * sunTrueLon));
            // sunRightAscension = sunRightAscension Mod 360 ?
            if (sunRightAscension < 0d)
            {
                sunRightAscension += 360d;
            }
            else if (sunRightAscension >= 360d)
            {
                sunRightAscension -= 360d;
            }
            // 5b. right ascension value needs to be in the same quadrant as sunTrueLon
            double sunTrueLonQuadrant = Convert.ToDouble(sunTrueLon / 90d) * 90d;
            double SunRightAscQuadrant = Convert.ToDouble(sunRightAscension / 90d) * 90d;
            sunRightAscension += sunTrueLonQuadrant - SunRightAscQuadrant;
            // 5c. right ascension value needs to be converted into hours
            sunRightAscension /= 15d;
            // 6. calculate the Sun's declination
            double sunSinDeclination = 0.39782d * Math.Sin(toRad * sunTrueLon);
            double sunCosDeclination = Math.Cos(Math.Asin(sunSinDeclination));
            // 7a. calculate the Sun's local hour angle
            double sunLocalHourAngle = (Math.Cos(toRad * sunZenith) - sunSinDeclination * Math.Sin(toRad * locationLat)) / (sunCosDeclination * Math.Cos(toRad * locationLat));
            // If (sunLocalHourAngle > 1) Then 'The sun never rises on this location (on the specified date)
            // UtcSunTime = -1 'ElseIf (sunLocalHourAngle < -1) Then 
            // The sun never sets on this location (on the specified date) 'UtcSunTime = -2 'Else
            double sunHours; // 7b. finish calculating H and convert into hours
            if (sunriseOrSunset)
            {
                sunHours = 360d - 1d / toRad * Math.Acos(sunLocalHourAngle);
            }
            else
            {
                sunHours = 1d / toRad * Math.Acos(sunLocalHourAngle);
            }
            sunHours /= 15d; // 8. calculate local mean time of rising/setting
            sunLocalMeanTime = sunHours + sunRightAscension - 0.06571d * sunLocalMeanTime - 6.622d;
            double sunUtcTime = sunLocalMeanTime - lonHour; // 9. adjust back to UTC
                                                            // sunUtcTime = sunUtcTime Mod 24 ?
            if (sunUtcTime < 0d)
            {
                sunUtcTime += 24d;
            }
            else if (sunUtcTime >= 24d)
            {
                sunUtcTime -= 24d;
            }
            DateTime UtcSunTimeRet = new DateTime(System.Threading.Thread.CurrentThread.CurrentCulture.Calendar.GetYear(sunDate), sunDate.Month, System.Threading.Thread.CurrentThread.CurrentCulture.Calendar.GetDayOfMonth(sunDate), (int)Math.Round(Math.Truncate(sunUtcTime)), (int)Math.Round(Math.Truncate((sunUtcTime - Math.Truncate(sunUtcTime)) * 60d)), 0);
            return UtcSunTimeRet;
        }
    }
}
