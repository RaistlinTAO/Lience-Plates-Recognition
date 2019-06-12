#region COPYRIGHT & CODE DESCRIPTION

// © 2006-2013 by D.E.M.O.N Studio. All rights reserved
// 
// D.E.M.O.N Studio: Decisively, Earnestly, Masterfully, Observantly, Naturally
// 
// SOLUTION: Lience Plates Recognition
// PROJECT:    Lience Plates Recognition
// FILENAME:  frmMain.cs
// 
// CREATED IN 10:58 PM (23/05/2013)
// 
// LAST EDITED: 12:56 AM (25/05/2013)

#endregion

using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Lience_Plates_Recognition.Logic;
using Lience_Plates_Recognition.Properties;

namespace Lience_Plates_Recognition.UI
{
    public partial class frmMain : Form
    {
        //这个是用于测试的! 切换到摄像头后 使用摄像头自动保存的图片
        //private const int CaptureDuration = 4000; // 截图间隔
        // private readonly string DEBUGIMG = Application.StartupPath + "\\plate3.png";
        //private readonly clsCamera _camera;
        private string _IMAGEPATH = "D:\\Program Files\\ImageMagick-6.8.6-3";
        private string _ORCPATH = "D:\\Program Files\\Tesseract-OCR";
        private bool _Success;

        public frmMain()
        {
            InitializeComponent();
            //_camera = new clsCamera(picSource.Handle, 0, 0, picSource.Width, picSource.Height);
        }

        [DllImport("user32.dll")]
        private static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);

        private void frmMain_Load(object sender, EventArgs e)
        {
            cmdStop.Enabled = false;
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            AddLog("System Initialised");
            //tmAnalyse.Interval = CaptureDuration;
            /*
            _camera.Start();
            AddLog("Camera Started");
            try
            {
                File.Delete(Application.StartupPath + "\\temp\\tmp.avi");
            }
            catch (Exception)
            {
                //throw;
            }
             */
        }

        private void AddLog(string LOG)
        {
            lstResult.Items.Add(DateTime.Now.Minute + ":" + DateTime.Now.Second + " " + LOG);
            lstResult.SelectedIndex += 1;
        }

        private void cmdORC_Click(object sender, EventArgs e)
        {
            var iFolder = new FolderBrowserDialog
                {
                    Description = Resources.frmMain_cmdORC_Click_Select_ORC_Library_Path_
                };
            if (iFolder.ShowDialog() == DialogResult.OK)
            {
                //这里要判断是否正确
                //D:\Program Files\Tesseract-OCR
                if (File.Exists(iFolder.SelectedPath + "\\tesseract.exe"))
                {
                    lblORCPatch.Text = iFolder.SelectedPath;
                    _ORCPATH = iFolder.SelectedPath;
                    AddLog("Set ORC Library Path");
                }
                else
                {
                    MessageBox.Show(Resources.frmMain_cmdORC_Click_Path_not_correct_, Application.ProductName,
                                    MessageBoxButtons.OK);
                }
            }
        }

        private void cmdImage_Click(object sender, EventArgs e)
        {
            var iFolder = new FolderBrowserDialog
                {
                    Description = Resources.frmMain_cmdImage_Click_Select_Image_Library_Path_
                };
            if (iFolder.ShowDialog() == DialogResult.OK)
            {
                //这里要判断是否正确convert.exe
                if (File.Exists(iFolder.SelectedPath + "\\convert.exe"))
                {
                    lblImagePath.Text = iFolder.SelectedPath;
                    _IMAGEPATH = iFolder.SelectedPath;
                    AddLog("Set Image Library Path");
                }
                else
                {
                    MessageBox.Show(Resources.frmMain_cmdORC_Click_Path_not_correct_, Application.ProductName,
                                    MessageBoxButtons.OK);
                }
            }
        }

        private void cmdAnalyse_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";

            if (!File.Exists(txtPicPath.Text))
            {
                return;
            }

            try
            {
                File.Delete(Application.StartupPath + "\\temp.tiff");
            }
            catch (Exception)
            {
                throw;
            }
            try
            {
                File.Delete(Application.StartupPath + "\\out.txt");
            }
            catch (Exception)
            {
                throw;
            }
            cmdAnalyse.Enabled = false;
            _Success = false;
            //_camera.Kinescope(Application.StartupPath + "\\temp\\tmp.avi");

            AddLog("Start Analyse");

            prgMain.Value = 0;
            //1 交给clsImageMagick预先处理图片

            MagicIMGDelegate dn = clsImagemagick.MagicIMG;


            IAsyncResult iar = dn.BeginInvoke(_IMAGEPATH, txtPicPath.Text,
                                              "temp", false, null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            prgMain.Value = 25;

            string iTempPicture = Application.StartupPath + "\\" + dn.EndInvoke(iar);

            AddLog("Image pre-processed!");

            //2 交给ORC 处理文字

            AnalyzePictureDeletgate dn2 = clsORC.AnalyzePicture;

            IAsyncResult iar2 = dn2.BeginInvoke(_ORCPATH, iTempPicture, Application.StartupPath, false, null, null);

            while (iar2.IsCompleted == false)
            {
                Application.DoEvents();
            }

            string iTempReulst = dn2.EndInvoke(iar2).Replace(" ", "");
            iTempReulst = iTempReulst.Replace("\r", "");
            iTempReulst = iTempReulst.Replace("\n", "");
            AddLog("Try to find text in SINGLE LINE");

            prgMain.Value = 50;


            //iTempReulst 就是识别出来的文字了
            ShowResult("", iTempReulst, false);
            if (!_Success)
            {
                File.Delete(Application.StartupPath + "\\temp.tiff");
                CutImageDelegate dn00 = clsImagemagick.CutImage;

                IAsyncResult iar00 = dn00.BeginInvoke(_IMAGEPATH, txtPicPath.Text, null, null);

                while (iar00.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                AddLog("Try to find text in MULTI LINE");
                //////////////////

                ConvertIMGDelegate dnx = clsImagemagick.ConvertImg;
                IAsyncResult iarx = dnx.BeginInvoke(_IMAGEPATH, Application.StartupPath + "\\dest-0.bmp", "tempcrop0",
                                                    null, null);

                while (iarx.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                MagicIMGDelegate dn0 = clsImagemagick.MagicIMG;

                IAsyncResult iar0 = dn0.BeginInvoke(_IMAGEPATH, Application.StartupPath + "\\tempcrop0.tiff",
                                                    "temp", true, null, null);

                while (iar0.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                iTempPicture = Application.StartupPath + "\\" + dn0.EndInvoke(iar0);

                AnalyzePictureDeletgate dn3 = clsORC.AnalyzePicture;

                IAsyncResult iar3 = dn3.BeginInvoke(_ORCPATH, iTempPicture, Application.StartupPath, false, null, null);

                while (iar3.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                iTempReulst = dn3.EndInvoke(iar3);

                prgMain.Value = 65;

                Thread.Sleep(5000);
                //////////////////////////////////

                dnx = clsImagemagick.ConvertImg;
                iarx = dnx.BeginInvoke(_IMAGEPATH, Application.StartupPath + "\\dest-1.bmp", "tempcrop1",
                                       null, null);

                while (iarx.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                dn0 = clsImagemagick.MagicIMG;

                iar0 = dn0.BeginInvoke(_IMAGEPATH, Application.StartupPath + "\\tempcrop1.tiff",
                                       "temp", true, null, null);

                while (iar0.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                iTempPicture = Application.StartupPath + "\\" + dn0.EndInvoke(iar0);

                dn3 = clsORC.AnalyzePicture;

                iar3 = dn3.BeginInvoke(_ORCPATH, iTempPicture, Application.StartupPath, false, null, null);

                while (iar3.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                iTempReulst += dn3.EndInvoke(iar3);
                prgMain.Value = 75;


                ShowResult("", iTempReulst, false);
            }
            //tmAnalyse.Enabled = true;
        }

        private void tmAnalyse_Tick(object sender, EventArgs e)
        {
            //设定截图名称
            /*
            string GrabImage = Application.StartupPath + "\\temp\\" + DateTime.Now.Hour.ToString() +
                               DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            //_camera.GrabImage(GrabImage + ".bmp");
            */
            //File.Delete(Application.StartupPath + "\\tmp.tiff");
            //File.Delete(Application.StartupPath + "\\temp\\out.txt");
            /*
            prgMain.Value = 0;
            //1 交给clsImageMagick预先处理图片

            MagicIMGDelegate dn = clsImagemagick.MagicIMG;


            IAsyncResult iar = dn.BeginInvoke(_IMAGEPATH, GrabImage + ".bmp",
                                              GrabImage.Replace(Application.StartupPath + "\\temp\\", ""), null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            prgMain.Value = 25;

            string iTempPicture = Application.StartupPath + "\\temp\\" + dn.EndInvoke(iar);

            AddLog("Image pre-processed!");

            //2 交给ORC 处理文字

            AnalyzePictureDeletgate dn2 = clsORC.AnalyzePicture;

            IAsyncResult iar2 = dn2.BeginInvoke(_ORCPATH, iTempPicture, Application.StartupPath, false, null, null);

            while (iar2.IsCompleted == false)
            {
                Application.DoEvents();
            }

            string iTempReulst = dn2.EndInvoke(iar2);

            AddLog("Try to find text in SINGLE LINE");

            prgMain.Value = 50;


            //iTempReulst 就是识别出来的文字了
            ShowResult(GrabImage, iTempReulst, false);
            if (!_Success)
            {
                AnalyzePictureDeletgate dn3 = clsORC.AnalyzePicture;

                IAsyncResult iar3 = dn3.BeginInvoke(_ORCPATH, iTempPicture, Application.StartupPath, true, null, null);

                while (iar2.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                iTempReulst = dn3.EndInvoke(iar3);

                AddLog("Try to find text in MULTI LINE");

                prgMain.Value = 75;

                ShowResult(GrabImage, iTempReulst, true);
            }
             * */
        }

        private void ShowResult(string GrabImage, String iTempReulst, bool MultiLine)
        {
            if (clsPaser.CheckNumber(iTempReulst, MultiLine))
            {
                _Success = true;
                //如果匹配车牌 啧啧
                txtResult.Text = iTempReulst.Replace("\r\n", "");
                AddLog("Analysis progress Finished");
                //tmAnalyse.Enabled = false;

                //保存图片
                //File.Copy(GrabImage + ".bmp", Application.StartupPath + "\\" + iTempReulst + ".bmp");

                /*
                //停止录像
                
                //
                try
                {
                    _camera.StopKinescope();
                    _camera.Stop();
                    if (File.Exists(Application.StartupPath + "\\temp\\tmp.avi"))
                    {
                        File.Copy(Application.StartupPath + "\\temp\\tmp.avi", Application.StartupPath + "\\" + iTempReulst + ".avi");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                */
            }
            else
            {
                AddLog("The result is " + iTempReulst);
                //说明识别出来的是无意义的
                AddLog("Analysis Failed");
            }
            cmdAnalyse.Enabled = true;
            prgMain.Value = 100;
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            //_camera.Stop();
            AddLog("Camera Stopped");
            AddLog("Stop Analyse");
            tmAnalyse.Enabled = false;
            cmdAnalyse.Enabled = true;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_camera.Stop();
        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            MessageBox.Show(clsPaser.CheckNumber(txtResult.Text, false) ? "Correct Car" : "Wrong Car");
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            var iLoad = new OpenFileDialog();
            iLoad.Multiselect = false;
            iLoad.Filter = "";
            iLoad.Title = "Select Picture";
            if (iLoad.ShowDialog() == DialogResult.OK)
            {
                picSource.Image = Image.FromFile(iLoad.FileName);
                txtPicPath.Text = iLoad.FileName;
            }
        }

        private delegate string AnalyzePictureDeletgate(string ORCPath, string IMGPath, string APPPath, bool isDouble);

        private delegate void ConvertIMGDelegate(string MagicPATH, string IMGPath, string FName);

        private delegate void CutImageDelegate(string MagicPATH, string IMGPath);

        private delegate string MagicIMGDelegate(string MagicPATH, string IMGPath, string ResultName, bool Multi);

        [Flags]
        private enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }
    }
}