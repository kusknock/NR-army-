using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using System.Numerics;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using Accord.Video.DirectShow;
using Accord.Video;
using System.IO;

namespace ConvolutionMethod
{
    unsafe public partial class MainForm : Form
    {
        /// <summary>
        /// Структура для создания прямоугольника выделения
        /// TODO: перенести BoundVisibleImage в эту структуру 
        /// </summary>

        class SelectionRectangle
        {
            Point startPoint;

            Point currentPoint;

            Rectangle currentRect;

            bool squareSelection;

            double coefficientScaleImage;

            public Rectangle CurrentRect
            {
                get
                {
                    if (!currentPoint.IsEmpty)
                        ProcessCurrentRectangle(currentPoint);

                    return currentRect;
                }

                set
                {
                    currentRect = value;
                }
            }

            public Point StartPoint
            {
                get
                {
                    return startPoint;
                }

                set
                {
                    startPoint = value;
                }
            }

            public Point CurrentPoint
            {
                get
                {
                    return currentPoint;
                }

                set
                {
                    currentPoint = value;
                }
            }

            public bool SquareSelection
            {
                get
                {
                    return squareSelection;
                }

                set
                {
                    squareSelection = value;
                }
            }

            public double CoefficientScaleImage
            {
                get
                {
                    return coefficientScaleImage;
                }

                set
                {
                    coefficientScaleImage = value;
                }
            }

            private void ProcessCurrentRectangle(Point _currentPoint)
            {
                string selection = _currentPoint.X > startPoint.X && _currentPoint.Y > startPoint.Y ? "rightDown" :

                    _currentPoint.X < startPoint.X && _currentPoint.Y < startPoint.Y ? "leftUp" :

                    _currentPoint.X < startPoint.X ? "rightUp" :

                    _currentPoint.Y < startPoint.Y ? "leftDown" : string.Empty;

                currentRect = GetRectangle(selection, new Point[2]
                {
                    new Point(startPoint.X, startPoint.Y),
                    new Point(_currentPoint.X, _currentPoint.Y)
                });
            }

            private Rectangle GetRectangle(string condition, Point[] points)
            {
                Point start, end;

                Size sizeRect = new Size();

                start = end = new Point();

                switch (condition)
                {
                    case "rightDown":
                        {
                            start = points[0];
                            end = points[1];

                            if (squareSelection)
                            {
                                end = end.X - start.X < end.Y - start.Y ?
                                    new Point(end.X, start.Y + (end.X - start.X)) :
                                    new Point(start.X + (end.Y - start.Y), end.Y);
                            }

                            sizeRect = new Size(Math.Abs(end.X - start.X), Math.Abs(end.Y - start.Y));

                            break;
                        }
                    case "leftDown":
                        {
                            if (squareSelection)
                            {
                                points[1] = points[1].X - points[0].X < points[0].Y - points[1].Y ?
                                    new Point(points[0].X - (points[1].X - points[0].X), points[0].Y - (points[1].X - points[0].X)) :
                                    new Point(points[0].X - (points[0].Y - points[1].Y), points[0].Y - (points[0].Y - points[1].Y));
                            }

                            start = new Point(points[0].X, points[1].Y);
                            end = points[0];

                            sizeRect = new Size(Math.Abs(end.X - points[1].X), Math.Abs(end.Y - points[1].Y));

                            break;
                        }
                    case "rightUp":
                        {

                            if (squareSelection)
                            {
                                points[1] = points[0].X - points[1].X < points[1].Y - points[0].Y ?
                                    new Point(points[0].X - (points[0].X - points[1].X), points[0].Y - (points[0].X - points[1].X)) :
                                    new Point(points[0].X - (points[1].Y - points[0].Y), points[0].Y - (points[1].Y - points[0].Y));
                            }

                            start = new Point(points[1].X, points[0].Y);
                            end = points[0];

                            sizeRect = new Size(Math.Abs(end.X - points[1].X), Math.Abs(end.Y - points[1].Y));

                            break;
                        }
                    case "leftUp":
                        {
                            start = points[1];
                            end = points[0];

                            if (squareSelection)
                            {
                                start = end.X - start.X < end.Y - start.Y ?
                                    new Point(end.X - (end.X - start.X), end.Y - (end.X - start.X)) :
                                    new Point(end.X - (end.Y - start.Y), end.Y - (end.Y - start.Y));
                            }

                            sizeRect = new Size(Math.Abs(end.X - start.X), Math.Abs(end.Y - start.Y));

                            break;
                        }

                    default: break;
                }

                Rectangle rect = new Rectangle(start, sizeRect);

                return rect;
            }
        }

        float nm = (float)Math.Pow(10, -9);
        float mm = (float)Math.Pow(10, -3);

        float wave = 0;
        float dx = 0;
        float d = 0;
        float tetha = 0;

        float sizeStep = 0;
        int steps = 0;
        int N = 0;

        float[] originalImage;
        float[] colorFilterData;

        float[] simulationImage;
        float[] reconstructionImage;

        float[] phaseReconImage;
        float[] phaseGenImage;

        int widthImage, heightImage;

        bool selection = false, rule = false; // режим выделения области 

        int dCircle = 100, dScale = 100;

        NumericUpDown scrollDCirle, scrollScale;

        SelectionRectangle sr0 = new SelectionRectangle();

        SelectionRectangle sr1 = new SelectionRectangle();

        SelectionRectangle sr2 = new SelectionRectangle();

        Rectangle visibleImageRectangle = new Rectangle();

        delegate void Func();

        delegate float Diff(Bitmap current);

        Diff func;

        Dictionary<string, int> colorChannel = new Dictionary<string, int>();

        List<Bitmap> reconstructionImages = new List<Bitmap>();

        List<Bitmap> reconstructionPhaseImages = new List<Bitmap>();

        List<float> distances = new List<float>();

        List<Rectangle> zonesAnalyze = new List<Rectangle>();

        Dictionary<string, Dictionary<string, List<float>>> measuresZone = 
            new Dictionary<string, Dictionary<string, List<float>>>();

        VideoCaptureDevice videoSource;

        FilterInfoCollection videoDevices;

        bool startCam = false;

        public MainForm()
        {
            InitializeComponent();

            InitializeCombobox();
        }

        private void InitializeParameters()
        {
            float.TryParse(txbWave.Text.Replace('.', ','), out wave);
            wave *= nm;

            float.TryParse(txbDx.Text.Replace('.', ','), out dx);
            dx *= mm;

            float.TryParse(txbDist.Text.Replace('.', ','), out d);
            d *= mm;

            float.TryParse(txbSizeStep.Text.Replace('.', ','), out sizeStep);
            sizeStep *= mm;

            steps = (int)numStep.Value;
        }

        private void InitializeCombobox()
        {
            if (!InvokeRequired)
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                foreach (FilterInfo fi in videoDevices)
                    cmbCam.Items.Add(fi.Name);

                cmbCam.SelectedIndex = 0;

                cmbChannel.SelectedIndex = 0;

                cmbMeasure.SelectedIndex = 0;
            }
        }

        private void InitializeDictionary()
        {
            if (colorChannel.Count != 0)
                return;

            colorChannel.Add("R", 2);
            colorChannel.Add("G", 1);
            colorChannel.Add("B", 0);
        }

        private void ReloadParameters()
        {
            wave = 0;
            dx = 0;
            d = 0;
            N = 0;
            tetha = 0;

            sizeStep = 0;
            steps = 0;

            originalImage = null;
            colorFilterData = null;

            simulationImage = null;
            reconstructionImage = null;

            phaseReconImage = null;
            phaseGenImage = null;

            widthImage = 0;
            heightImage = 0;

            ClearLists();

            InitializeParameters();
            InitializeDictionary();

            trackBar1.Enabled = false;

            picGenHolo.Image = picReconHolo.Image = picAnalyze.Image = picScale.Image = picScale2.Image = null;

            EnabledControls(true);
        }

        private void EnabledControls(bool value)
        {
            SetValueControlInOtherThread(groupColor, "Enabled", value);
            SetValueControlInOtherThread(groupParamHolo, "Enabled", value);
            SetValueControlInOtherThread(groupZones, "Enabled", value);
            SetValueControlInOtherThread(groupParamProcess, "Enabled", value);
            SetValueControlInOtherThread(tabControl1, "Enabled", value);
            SetValueControlInOtherThread(btnGenHolo, "Enabled", value);
            SetValueControlInOtherThread(btnReconHolo, "Enabled", value);
        }

        private void ClearLists()
        {
            listZones.Items.Clear();
            chart1.Series.Clear();

            measuresZone = new Dictionary<string, Dictionary<string, List<float>>>();
            distances = new List<float>();
            zonesAnalyze = new List<Rectangle>();
            reconstructionImages = new List<Bitmap>();
            reconstructionPhaseImages = new List<Bitmap>();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeParameters();
            InitializeDictionary();
        }

        private void DrawGraph(Chart graph, float[] data, float[] yPoints, string graphName)
        {
            graph.Series.Clear();

            graph.Series.Add(graphName);
            graph.Series[graphName].ChartType = SeriesChartType.FastLine;
            graph.Series[graphName].ChartArea = "Area";

            for (int index = 0; index < data.Length; index++)
                graph.Series[graphName].Points.AddXY(yPoints[index], data[index]);
        }

        private void DrawAllGraph(Chart graph, float[] yPoints, Dictionary<string, List<float>> allGraph)
        {
            graph.Series.Clear();

            for (int index = 0; index < allGraph.Count; index++)
            {
                string key = allGraph.ElementAt(index).Key;
                float[] data = allGraph.ElementAt(index).Value.ToArray();

                graph.Series.Add(key);
                graph.Series[key].ChartType = SeriesChartType.FastLine;
                graph.Series[key].ChartArea = "Area";

                for (int i = 0; i < data.Length; i++)
                    graph.Series[key].Points.AddXY(yPoints[i], data[i]);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CloseVideo();

            if (picReconHolo.Image == null)
                return;

            if (tabControl1.SelectedIndex == 2 || tabControl1.SelectedIndex == 1)
                rbtnAmp.Enabled = rbtnPhase.Enabled = true;
            else
                rbtnAmp.Enabled = rbtnPhase.Enabled = false;

            //-----------------
            if (tabControl1.SelectedIndex == 3)
                listZones.Enabled = true;
            else
                listZones.Enabled = false;

            //-----------------
            if (tabControl1.SelectedIndex == 2)
            { 
                toolStrip1.Enabled = true;
                visibleImageRectangle = BoundVisibleImage(picReconHolo, sr0);
            }
            else
                toolStrip1.Enabled = false; 
        }

        private void rbtnPhase_CheckedChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if (phaseGenImage == null)
                    return;

                picGenHolo.Image = GetGrayImageFromImageData(phaseGenImage, widthImage, heightImage);
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                if (reconstructionPhaseImages.Count == 0 || reconstructionPhaseImages == null)
                    picReconHolo.Image = GetGrayImageFromImageData(phaseReconImage, widthImage, heightImage);
                else if (phaseReconImage == null)
                    picReconHolo.Image = reconstructionPhaseImages[trackBar1.Value];
            }
        }

        private void rbtnAmp_CheckedChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if (simulationImage == null)
                    return;

                picGenHolo.Image = GetGrayImageFromImageData(simulationImage, widthImage, heightImage);
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                if (reconstructionImages.Count == 0 || reconstructionImages == null)
                    picReconHolo.Image = GetGrayImageFromImageData(reconstructionImage, widthImage, heightImage);
                else if (reconstructionImage == null)
                    picReconHolo.Image = reconstructionImages[trackBar1.Value];
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (rbtnAmp.Checked)
                picReconHolo.Image = reconstructionImages[trackBar1.Value];
            else
                picReconHolo.Image = reconstructionPhaseImages[trackBar1.Value];

            lblCurrentDistance.Text = string.Format("{0} mm", distances[trackBar1.Value].ToString("0.00"));

            picAnalyze.Image = reconstructionImages[trackBar1.Value];
        }

        private void txbWave_TextChanged(object sender, EventArgs e)
        {
            InitializeParameters();
            InitializeDictionary();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "BMP File| *.bmp|JPEG File|*.jpg| GIF File|*.gif",
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            ReloadParameters();

            picSourceImage.Image = new Bitmap(ofd.FileName);

            widthImage = picSourceImage.Image.Width;

            heightImage = picSourceImage.Image.Height;

            originalImage = GetImageDataFromBitmap(new Bitmap(ofd.FileName), widthImage, heightImage);

            N = Math.Min(widthImage, heightImage);

            lblSize.Text = string.Format("{0}x{0}", N);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            OtherThreadWork(GettingChannelFromImage);
        }

        private void btnGenHolo_Click(object sender, EventArgs e)
        {
            if (colorFilterData == null)
                return;

            toolStripStatusLabel1.Text = "Обработка (1 из 1)";

            toolStripProgressBar1.Value = 0;

            OtherThreadWork(GenerationHologramm);

            toolStripProgressBar1.Value = 100;

            toolStripStatusLabel1.Text = "Готово";
        }

        private void btnReconHolo_Click(object sender, EventArgs e)
        {
            if (colorFilterData == null)
                return;
            else if (simulationImage == null)
                simulationImage = (float[])colorFilterData.Clone();

            ClearLists();

            if (steps == 1)
            {
                toolStripStatusLabel1.Text = "Обработка (1 из 1)";

                toolStripProgressBar1.Value = 0;

                OtherThreadWork(ReconstructionFixedDistance);

                toolStripProgressBar1.Value = 100;

                toolStripStatusLabel1.Text = "Готово";

                return;
            }

            OtherThreadWork(ReconstructionDynamicDistance);

            lblCurrentDistance.Text = string.Format("{0} mm", (d / mm).ToString("0.00"));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseVideo();

            //TODO: CloseThread();
        }

        private void ContextMenuLeftMouseClick(object sender, MouseEventArgs e)
        {
            btnSaveAsBitmap.Click += (s, ev) =>
            {
                SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "BMP File| *.bmp|JPEG File|*.jpg| GIF File|*.gif",
                };

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                ((PictureBox)sender).Image.Save(sfd.FileName);

                return;
            };

            if (((PictureBox)sender).Image == null) return;

            if (e.Button == MouseButtons.Right)
                contextMenuStrip1.Show((Control)sender, e.Location);
            else contextMenuStrip1.Hide();
        }

        private void btnSaveAllReconImages_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() != DialogResult.OK)
                return;

            Func f = () =>
            {
                string path = fbd.SelectedPath;

                for (int i = 0; i < reconstructionImages.Count; i++)
                {
                    reconstructionImages[i].Save(path + $"\\wave_{wave / nm}nm, pixel_{dx / mm}mm, dist_{(d + i * sizeStep) / mm}mm.bmp");

                    SetValueControlInOtherThread(toolStripProgressBar1, "Value", 95 * i / reconstructionImages.Count);

                    SetValueControlInOtherThread(toolStripStatusLabel1, "Text", $"Сохранение ({i + 1} из {reconstructionImages.Count})");
                }

                SetValueControlInOtherThread(toolStripProgressBar1, "Value", 100);

                SetValueControlInOtherThread(toolStripStatusLabel1, "Text", $"Готово");
            };

            OtherThreadWork(f);
        }

        #region Ruler

        private void picScale2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                picScale2.Refresh();
                rule = false;
                return;
            }

            picScale2.MouseMove += (s, ev) =>
            {
                if (rule)
                {
                    sr2.CurrentPoint = ev.Location;

                    DrawRuler(sr2.StartPoint, sr2.CurrentPoint, BoundVisibleImage(picScale2, sr2));
                }
            };

            if (sr2.StartPoint == Point.Empty)
            {
                sr2.StartPoint = e.Location;
                rule = true;
            }
            else
            {
                sr2.StartPoint = Point.Empty;
                rule = false;
            }
        }

        private void DrawRuler(Point a, Point b, Rectangle visibleImageRectangle)
        {
            Rectangle visibleBound = new Rectangle(
                new Point(visibleImageRectangle.Location.X, visibleImageRectangle.Location.Y),
                new Size(visibleImageRectangle.Size.Width, visibleImageRectangle.Size.Height));   

            if (!visibleBound.Contains(a))
                return;

            string nameOfSmallerProp = picScale2.Width <= picScale2.Height ? "Width" : "Height";

            double componentSize = GetPropertiesValue<int>(picScale2, nameOfSmallerProp, null) - 3;

            double imageSize = GetPropertiesValue<int>(picScale2.Image, nameOfSmallerProp, null);

            double coefficientScaleImage = imageSize / componentSize;

            if (!visibleBound.Contains(b))
            {
                int x = b.X < visibleBound.Left ? visibleBound.Left :
                    b.X > visibleBound.Right ? visibleBound.Right : b.X;

                int y = b.Y < visibleBound.Top ? visibleBound.Top :
                    b.Y > visibleBound.Bottom ? visibleBound.Bottom : b.Y;

                b = new Point(x, y);
            }

            picScale2.Refresh();

            Point coefficientOfSubstract = (visibleImageRectangle.Width + 3) == picScale2.Width ?
                new Point(0, ((picScale2.Height - 3) - visibleImageRectangle.Height) / 2) :
                new Point(((picScale2.Width - 3) - visibleImageRectangle.Width) / 2, 0);

            Point scalePointA = new Point((int)((a.X - coefficientOfSubstract.X) * coefficientScaleImage),
                (int)((a.Y - coefficientOfSubstract.Y) * coefficientScaleImage));

            Point scalePointB = new Point((int)((b.X - coefficientOfSubstract.X) * coefficientScaleImage),
                (int)((b.Y - coefficientOfSubstract.Y) * coefficientScaleImage));

            using (var g = picScale2.CreateGraphics())
            {
                double d1 = Math.Pow(Math.Abs(scalePointB.X - scalePointA.X), 2);
                double d2 = Math.Pow(Math.Abs(scalePointB.Y - scalePointA.Y), 2);

                double d = Math.Sqrt(d1 + d2);

                g.DrawLine(Pens.Red, a, b);

                g.DrawString($"({scalePointA.X}, {scalePointA.Y})", new Font("Calibri", 10f),
                    Brushes.Red, new Point(a.X - 5, a.Y - 5));
                g.DrawString($"({scalePointB.X}, {scalePointB.Y}), d = {d}", new Font("Calibri", 10f),
                    Brushes.Red, new Point(b.X - 5, b.Y - 5));
            }
        }

        #endregion

        #region Scale

        private void picScale_MouseClick(object sender, MouseEventArgs e)
        {
            if (picScale.Image == null)
                return;

            bool click = false;

            picScale.MouseDown += (s, ev) =>
            {
                click = true;
            };

            picScale.MouseUp += (s, ev) =>
            {
                click = false;
            };

            picScale.MouseMove += (s, ev) =>
            {
                if (click) DrawSquareScale(ev.Location, BoundVisibleImage(picScale, sr1));
            };

            ScrollScale(e.Location);

            DrawSquareScale(e.Location, BoundVisibleImage(picScale, sr1));

        }

        private void DrawSquareScale(Point location, Rectangle visibleScaleImageRectangle)
        {
            string nameOfSmallerProp = picScale.Width <= picScale.Height ? "Width" : "Height";

            double componentSize = GetPropertiesValue<int>(picScale, nameOfSmallerProp, null) - 3;

            double imageSize = GetPropertiesValue<int>(picScale.Image, nameOfSmallerProp, null);

            double coefficientScaleImage = imageSize / componentSize;

            dScale = (int)((int)scrollScale.Value / coefficientScaleImage);

            Rectangle visibleBoundForScale = new Rectangle(
                new Point(visibleScaleImageRectangle.Location.X + (dScale / 2), visibleScaleImageRectangle.Location.Y + (dScale / 2)),
                new Size(visibleScaleImageRectangle.Size.Width - dScale, visibleScaleImageRectangle.Size.Height - dScale));

            sr1.StartPoint = new Point(location.X - (dScale / 2), location.Y - (dScale / 2));

            if (!visibleBoundForScale.Contains(location))
            {
                int x = location.X < visibleBoundForScale.Left ? visibleBoundForScale.Left :
                    location.X > visibleBoundForScale.Right ? visibleBoundForScale.Right : location.X;

                int y = location.Y < visibleBoundForScale.Top ? visibleBoundForScale.Top :
                    location.Y > visibleBoundForScale.Bottom ? visibleBoundForScale.Bottom : location.Y;

                sr1.StartPoint = new Point(x - (dScale / 2), y - (dScale / 2));
            }

            sr1.CurrentPoint = new Point(sr1.StartPoint.X + dScale, sr1.StartPoint.Y + dScale);

            picScale.Refresh();

            using (var g = picScale.CreateGraphics())
                g.DrawRectangle(Pens.Red, sr1.CurrentRect);

            var area = GetImageFromSelection(picScale, BoundVisibleImage(picScale, sr1), sr1);

            picScale2.Image = ((Bitmap)picScale.Image).Clone(area, ((Bitmap)picScale.Image).PixelFormat);
        }

        private void ScrollScale(Point location)
        {
            scrollScale = new NumericUpDown()
            {
                Minimum = 5,
                Maximum = picScale.Image.Width,
                Value = scrollScale != null ? scrollScale.Value : 100,
                Location = location,
                Increment = 5,
            };

            Controls.Add(scrollScale);

            scrollScale.Focus();

            scrollScale.ValueChanged += (send, ev) =>
            {
                scrollScale.Focus();

                DrawSquareScale(scrollScale.Location, BoundVisibleImage(picScale, sr1));
            };
        }

        #endregion

        #region Video

        private void btnVideo_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text != "Изображение с камеры")
                return;

            if (startCam)
            {
                videoSource.Stop();

                startCam = false;
            }

            videoSource = new VideoCaptureDevice(videoDevices[cmbCam.SelectedIndex].MonikerString);

            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);

            videoSource.Start();

            startCam = true;
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            //int x = (eventArgs.Frame.Width - eventArgs.Frame.Height) / 2;

            //Rectangle rect = new Rectangle(x, 0, eventArgs.Frame.Height, eventArgs.Frame.Height);

            //Bitmap bmp = new Bitmap(eventArgs.Frame.Clone(rect, eventArgs.Frame.PixelFormat));

            Bitmap bmp = new Bitmap(eventArgs.Frame);

            picVideo.BeginInvoke((MethodInvoker)(() =>
            {
                picVideo.Image = bmp;

                picVideo.Invalidate();
                picVideo.Refresh();
            }));
        }

        private void cmbCam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startCam) return;
            else
            {
                videoSource.Stop();

                startCam = false;
            }

            videoSource = new VideoCaptureDevice(videoDevices[cmbCam.SelectedIndex].MonikerString);

            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);

            videoSource.Start();

            startCam = true;
        }

        private void CloseVideo()
        {
            if (videoSource != null)
            {
                videoSource.Stop();

                picVideo.Image = null;
            }
        }

        #endregion

        #region Difference Calculation

        private void btnCalcDifference_Click(object sender, EventArgs e)
        {
            if (listZones.SelectedItem == null || cmbMeasure.Text == "All Measures")
                return;

            CalculationDifference(zonesAnalyze[listZones.SelectedIndex], listZones.Text);

            DrawGraph(chart1, measuresZone[listZones.Text][cmbMeasure.Text].ToArray(), distances.ToArray(), cmbMeasure.Text);
        }

        private void listZones_SelectedIndexChanged(object sender, EventArgs e)
        {
            picAnalyze.Refresh();

            var area = GetSelectionFromArea(zonesAnalyze[listZones.SelectedIndex], picAnalyze);

            using (var g = picAnalyze.CreateGraphics())
                g.DrawRectangle(Pens.Red, area);

            if (measuresZone.ContainsKey(listZones.Text) && measuresZone[listZones.Text].ContainsKey(cmbMeasure.Text))
                DrawGraph(chart1, measuresZone[listZones.Text][cmbMeasure.Text].ToArray(), distances.ToArray(), cmbMeasure.Text);
            else if (cmbMeasure.Text == "All Measures")
                DrawAllGraph(chart1, distances.ToArray(), measuresZone[listZones.Text]);
            else
                chart1.Series.Clear();

        }

        private void cmbMeasure_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listZones.SelectedItem == null)
                return;

            switch (cmbMeasure.Text)
            {
                case "PSNR":
                    func = PSNR; break;
                case "RMSE":
                    func = RMSE; break;
                case "All Measures":
                    DrawAllGraph(chart1, distances.ToArray(), measuresZone[listZones.Text]); break;
                default: break;
            }

            if (measuresZone[listZones.Text].ContainsKey(cmbMeasure.Text))
                DrawGraph(chart1, measuresZone[listZones.Text][cmbMeasure.Text].ToArray(), distances.ToArray(), cmbMeasure.Text);
        }

        private void CalculationDifference(Rectangle area, string zone)
        {
            if (measuresZone[zone].ContainsKey(cmbMeasure.Text) || cmbMeasure.Text == "All Measures")
                return;

            List<float> measures = new List<float>();

            for (int index = 0; index < reconstructionImages.Count; index++)
            {
                var measure = func(reconstructionImages[index].Clone(area, reconstructionImages[index].PixelFormat));

                measures.Add(measure);
            }

            measuresZone[zone].Add(cmbMeasure.Text, measures);
        }

        private float PSNR(Bitmap current)
        {
            float summDiff = 0f;

            float mean = 0f;

            float psnr = 0f;

            float maxPow = 0f;

            int MN = current.Height * current.Width;

            var currImgData = GetGrayChannelFromImageData(GetImageDataFromBitmap(
                current, current.Width, current.Height), current.Width, current.Height);

            maxPow = (float)Math.Pow(currImgData.Max(), 2);

            for (int index = 0; index < currImgData.Length; index++)
                mean += currImgData[index];

            mean /= MN;

            for (int index = 0; index < currImgData.Length; index++)
                summDiff += (float)Math.Pow(currImgData[index] - mean, 2);

            psnr = 10*(float)Math.Log10(maxPow / summDiff);

            return psnr;
        }

        private float RMSE(Bitmap current)
        {
            float summDiff = 0f;

            float mean = 0f;

            float rmse = 0f;

            int MN = current.Height * current.Width;

            var currImgData = GetGrayChannelFromImageData(GetImageDataFromBitmap(
                current, current.Width, current.Height), current.Width, current.Height);

            for (int index = 0; index < currImgData.Length; index++)
                mean += currImgData[index];

            mean /= MN;

            for (int index = 0; index < currImgData.Length; index++)
                summDiff += (float)Math.Pow(currImgData[index] - mean, 2);

            rmse = (float)Math.Sqrt(summDiff / MN);

            return rmse;
        }

        #endregion

        #region Get Selection

        private Rectangle BoundVisibleImage(PictureBox picHologram, SelectionRectangle sr)
        {
            string nameOfSmallerProp = picHologram.Width <= picHologram.Height ? "Width" : "Height";

            int componentSize = GetPropertiesValue<int>(picHologram, nameOfSmallerProp, null) - 3;

            double imageSize = GetPropertiesValue<int>(picHologram.Image, nameOfSmallerProp, null);

            sr.CoefficientScaleImage = imageSize / componentSize;

            double coefficientScaleComponent = componentSize / imageSize;

            Dictionary<string, double> visibleSize = new Dictionary<string, double>();

            visibleSize.Add("Width", coefficientScaleComponent * picHologram.Image.Width);

            visibleSize.Add("Height", coefficientScaleComponent * picHologram.Image.Height);

            int startPointY = nameOfSmallerProp == "Height" ? 0 : ((GetPropertiesValue<int>(picHologram, "Height", null) - 3) - (int)visibleSize["Height"]) / 2;

            int startPointX = nameOfSmallerProp == "Width" ? 0 : ((GetPropertiesValue<int>(picHologram, "Width", null) - 3) - (int)visibleSize["Width"]) / 2;

            Point startPoint = new Point(startPointX, startPointY);

            Size sizeRectangle = new Size((int)visibleSize["Width"], (int)visibleSize["Height"]);

            Rectangle boundVisibleImage = new Rectangle(startPoint, sizeRectangle);

            return boundVisibleImage;
        }

        private Rectangle GetImageFromSelection(PictureBox picHologram, Rectangle visibleImageRectangle, SelectionRectangle sr)
        {
            Point coefficientOfSubstract = (visibleImageRectangle.Width + 3) == picHologram.Width ?
                new Point(0, ((picHologram.Height - 3) - visibleImageRectangle.Height) / 2) :
                new Point(((picHologram.Width - 3) - visibleImageRectangle.Width) / 2, 0);

            Point scalePoint = new Point((int)((sr.CurrentRect.X - coefficientOfSubstract.X) * sr.CoefficientScaleImage),
                (int)((sr.CurrentRect.Y - coefficientOfSubstract.Y) * sr.CoefficientScaleImage));

            Size scaleSize = new Size((int)(sr.CurrentRect.Width * sr.CoefficientScaleImage),
                (int)(sr.CurrentRect.Height * sr.CoefficientScaleImage));

            if (scaleSize.Width == 0 || scaleSize.Height == 0)
                return Rectangle.Empty;

            return new Rectangle(scalePoint, scaleSize);
        }

        private Rectangle GetSelectionFromArea(Rectangle area, PictureBox picHologram)
        {
            string nameOfSmallerProp = picHologram.Width <= picHologram.Height ? "Width" : "Height";

            double componentSize = GetPropertiesValue<int>(picHologram, nameOfSmallerProp, null) - 3;

            double imageSize = GetPropertiesValue<int>(picHologram.Image, nameOfSmallerProp, null);

            double coefficientScaleImage = imageSize / componentSize;

            double coefficientScaleComponent = componentSize / imageSize;

            Dictionary<string, double> visibleSize = new Dictionary<string, double>();

            visibleSize.Add("Width", coefficientScaleComponent * picHologram.Image.Width);

            visibleSize.Add("Height", coefficientScaleComponent * picHologram.Image.Height);

            int startPointY = nameOfSmallerProp == "Height" ? 0 : ((GetPropertiesValue<int>(picHologram, "Height", null) - 3) - (int)visibleSize["Height"]) / 2;

            int startPointX = nameOfSmallerProp == "Width" ? 0 : ((GetPropertiesValue<int>(picHologram, "Width", null) - 3) - (int)visibleSize["Width"]) / 2;

            Point startPoint = new Point(startPointX, startPointY);

            Size sizeRectangle = new Size((int)visibleSize["Width"], (int)visibleSize["Height"]);

            Rectangle boundVisibleImage = new Rectangle(startPoint, sizeRectangle);

            ///-----------------------

            Point coefficientOfSubstract = (boundVisibleImage.Width + 3) == picHologram.Width ?
                new Point(0, ((picHologram.Height - 3) - boundVisibleImage.Height) / 2) :
                new Point(((picHologram.Width - 3) - boundVisibleImage.Width) / 2, 0);

            Point scalePoint = new Point((int)(area.X / coefficientScaleImage + coefficientOfSubstract.X),
                (int)(area.Y / coefficientScaleImage + coefficientOfSubstract.Y));

            Size scaleSize = new Size((int)(area.Width / coefficientScaleImage),
                (int)(area.Height / coefficientScaleImage));

            return new Rectangle(scalePoint, scaleSize);
        }

        private void WriteRecordZone()
        {
            sr0.StartPoint = Point.Empty;

            sr0.CurrentPoint = Point.Empty;

            picReconHolo.Refresh();

            var area = GetImageFromSelection(picReconHolo, visibleImageRectangle, sr0);

            zonesAnalyze.Add(area);

            listZones.Items.Add($"Зона ({area.X}, {area.Y})");

            measuresZone.Add($"Зона ({area.X}, {area.Y})", new Dictionary<string, List<float>>());
        }

        private void DrawEllipseSelection(Point location)
        {
            dCircle = (int)((int)scrollDCirle.Value/sr0.CoefficientScaleImage);

            Rectangle visibleBoundForCircleSelection = new Rectangle(
                new Point(visibleImageRectangle.Location.X + (dCircle / 2), visibleImageRectangle.Location.Y + (dCircle / 2)),
                new Size(visibleImageRectangle.Size.Width - dCircle, visibleImageRectangle.Size.Height - dCircle));

            sr0.StartPoint = new Point(location.X - (dCircle / 2), location.Y - (dCircle / 2));

            if (!visibleBoundForCircleSelection.Contains(location))
            {
                int x = location.X < visibleBoundForCircleSelection.Left ? visibleBoundForCircleSelection.Left :
                    location.X > visibleBoundForCircleSelection.Right ? visibleBoundForCircleSelection.Right : location.X;

                int y = location.Y < visibleBoundForCircleSelection.Top ? visibleBoundForCircleSelection.Top :
                    location.Y > visibleBoundForCircleSelection.Bottom ? visibleBoundForCircleSelection.Bottom : location.Y;

                sr0.StartPoint = new Point(x - (dCircle / 2), y - (dCircle / 2));
            }

            sr0.CurrentPoint = new Point(sr0.StartPoint.X + dCircle, sr0.StartPoint.Y + dCircle);

            using (var g = picReconHolo.CreateGraphics())
            {
                g.DrawEllipse(Pens.Red, sr0.CurrentRect);
                g.DrawString(scrollDCirle.Value.ToString(), new Font("Calibri", 10f),
                    Brushes.Red, new Point(sr0.StartPoint.X - 5, sr0.StartPoint.Y - 5));
            }
        }

        private void ScrollValueMouseWheel()
        {
            scrollDCirle = new NumericUpDown()
            {
                Minimum = 0,
                Maximum = 1000,
                Value = 100,
            };

            Controls.Add(scrollDCirle);

            scrollDCirle.ValueChanged += (send, ev) =>
            {
                picReconHolo.Refresh();

                scrollDCirle.Focus();

                DrawEllipseSelection(scrollDCirle.Location);
            };
        }

        private void picReconHolo_MouseDown(object sender, MouseEventArgs e)
        {
            if (btnSelection.Checked)
            {
                if (e.Button != MouseButtons.Left)
                    return;

                if (!sr0.CurrentRect.IsEmpty)
                    sr0.CurrentRect = Rectangle.Empty;

                if (picReconHolo.Image == null || !visibleImageRectangle.Contains(e.Location))
                    return;

                sr0.StartPoint = e.Location;

                selection = true;
            }
        }

        private void picReconHolo_MouseMove(object sender, MouseEventArgs e)
        {
            picReconHolo.Refresh();

            if (picReconHolo.Image == null)
                return;

            if (btnSelection.Checked)
            {
                if (sr0.StartPoint.IsEmpty)
                    return;

                sr0.CurrentPoint = e.Location;

                if (!visibleImageRectangle.Contains(sr0.CurrentPoint))
                {
                    int x = e.X < visibleImageRectangle.Left ? visibleImageRectangle.Left :
                        e.X > visibleImageRectangle.Right ? visibleImageRectangle.Right : e.X;

                    int y = e.Y < visibleImageRectangle.Top ? visibleImageRectangle.Top :
                        e.Y > visibleImageRectangle.Bottom ? visibleImageRectangle.Bottom : e.Y;

                    sr0.CurrentPoint = new Point(x, y);
                }

                if (selection)
                    using (var g = picReconHolo.CreateGraphics())
                        g.DrawRectangle(Pens.Red, sr0.CurrentRect);
            }

            if (btnCircle.Checked)
            {
                scrollDCirle.Location = e.Location;

                scrollDCirle.Focus();

                DrawEllipseSelection(e.Location);
            }
        }

        private void picReconHolo_MouseUp(object sender, MouseEventArgs e)
        {
            if (sr0.CurrentRect.IsEmpty || sr0.StartPoint.IsEmpty
                || e.Button != MouseButtons.Left || !btnSelection.Checked)
                return;

            WriteRecordZone();
        }

        private void picReconHolo_MouseClick(object sender, MouseEventArgs e)
        {
            if (picReconHolo.Image == null || !visibleImageRectangle.Contains(e.Location))
                return;

            if (btnSelection.Checked)
                selection = false;

            if(btnCircle.Checked)
                WriteRecordZone();

            ContextMenuLeftMouseClick(sender, e);
        }

        private void btnCircle_CheckStateChanged(object sender, EventArgs e)
        {
            btnSelection.Checked = false;

            ScrollValueMouseWheel();
        }

        private void btnSelection_CheckStateChanged(object sender, EventArgs e)
        {
            btnCircle.Checked = false;

            if(scrollDCirle != null)
                scrollDCirle.Dispose();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (picReconHolo.Image == null)
                return;

            visibleImageRectangle = BoundVisibleImage(picReconHolo, sr0);
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            if (picReconHolo.Image == null)
                return;

            visibleImageRectangle = BoundVisibleImage(picReconHolo, sr0);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift) sr0.SquareSelection = true;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Shift) sr0.SquareSelection = false;
        }

        #endregion

        #region Other Threads

        // Получение значения свойства для заданного типа
        T GetPropertiesValue<T>(object obj, string name, object[] index)
        {
            var type = obj.GetType();

            var property = type.GetProperty(name);

            var value = property.GetValue(obj, index);

            if (value == null) { return default(T); }

            return (T)value;
        }

        void SetPropertiesValue(object obj, string name, object value)
        {
            var type = obj.GetType();

            var property = type.GetProperty(name);

            property.SetValue(obj, value);
        }

        private void OtherThreadWork(Func func)
        {
            Thread newThread = new Thread(new ThreadStart(() => 
            {
                EnabledControls(false);

                func();

                EnabledControls(true);
            }));

            newThread.Start();
        }

        private object GetValueControlInOtherThread(object c, string name, object[] index)
        {
            object value = null;

            if (!InvokeRequired)
            {
                value = GetPropertiesValue<object>(c, name, index);
            }
            else
            {
                Func func = () =>
                {
                    value = GetPropertiesValue<object>(c, name, index);
                };

                Invoke(func);
            }

            return value;
        }

        private void SetValueControlInOtherThread(object c, string name, object value)
        {
            if (!InvokeRequired)
            {
                SetPropertiesValue(c, name, value);
            }
            else
            {
                Func func = () =>
                {
                    SetPropertiesValue(c, name, value);
                };

                Invoke(func);
            }
        }

        #endregion

        #region Image Processing

        private float[,,] Get3dImgData(Bitmap myBitmap)
        {
            float[,,] ImgData = new float[myBitmap.Width, myBitmap.Height, 3];
            BitmapData byteArray = myBitmap.LockBits(new Rectangle(0, 0, myBitmap.Width, myBitmap.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int ByteOfSkip = byteArray.Stride - byteArray.Width * 3;

            byte* imgPtr = (byte*)(byteArray.Scan0);

            for (int y = 0; y < byteArray.Height; y++)
            {
                for (int x = 0; x < byteArray.Width; x++)
                {
                    ImgData[x, y, 2] = *(imgPtr);
                    ImgData[x, y, 1] = *(imgPtr + 1);
                    ImgData[x, y, 0] = *(imgPtr + 2);
                    imgPtr += 3;
                }
                imgPtr += ByteOfSkip;
            }
            myBitmap.UnlockBits(byteArray);

            return ImgData;
        }

        private float[] GetImageDataFromBitmap(Bitmap myBitmap, int widthImage, int heightImage)
        {
            float[] ImgData = new float[widthImage * heightImage * 3];
            BitmapData byteArray = myBitmap.LockBits(new Rectangle(0, 0, widthImage, heightImage),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int ByteOfSkip = byteArray.Stride - byteArray.Width * 3;

            byte* imgPtr = (byte*)(byteArray.Scan0);

            for (int y = 0, index = 0; y < heightImage; y++)
            {
                for (int x = 0; x < widthImage; x++)
                {
                    ImgData[index++] = *(imgPtr);
                    ImgData[index++] = *(imgPtr + 1);
                    ImgData[index++] = *(imgPtr + 2);
                    imgPtr += 3;
                }
                imgPtr += ByteOfSkip;
            }
            myBitmap.UnlockBits(byteArray);

            return ImgData;
        }

        private Bitmap GetBitmapFromImageData(float[] ImgData, int widthImage, int heightImage)
        {
            Bitmap myBitmap = new Bitmap(widthImage, heightImage, PixelFormat.Format24bppRgb);

            BitmapData byteArray = myBitmap.LockBits(new Rectangle(0, 0, widthImage, heightImage),
                                           ImageLockMode.WriteOnly,
                                           PixelFormat.Format24bppRgb);
            //Padding bytes
            int ByteOfSkip = byteArray.Stride - myBitmap.Width * 3;

            byte* imgPtr = (byte*)byteArray.Scan0;

            for (int y = 0, index = 0; y < heightImage; y++)
            {
                for (int x = 0; x < widthImage; x++)
                {
                    *imgPtr = (byte)ImgData[index++];             //B
                    *(imgPtr + 1) = (byte)ImgData[index++];       //G
                    *(imgPtr + 2) = (byte)ImgData[index++];       //R
                    imgPtr += 3;
                }
                imgPtr += ByteOfSkip; // Padding bytes
            }
            myBitmap.UnlockBits(byteArray);

            return myBitmap;
        }

        private float[] GetColorChannelFromImageData(float[] ImgData, int channel, int widthImage, int heightImage)
        {
            float[] cfImgData = new float[widthImage * heightImage];

            for (int y = 0, index = 0; y < widthImage * heightImage * 3; y += 3)
                cfImgData[index++] = ImgData[y + channel];

            return cfImgData;
        }

        private float[] GetGrayChannelFromImageData(float[] ImgData, int widthImage, int heightImage)
        {
            float[] cfImgData = new float[widthImage * heightImage];

            for (int y = 0, index = 0; y < widthImage * heightImage * 3; y += 3)
                cfImgData[index++] = 0.299f * ImgData[y + 2] + 0.587f *
                    ImgData[y + 1] + 0.114f * ImgData[y];

            return cfImgData;
        }

        private Bitmap GetColorChannelBitmapFromImageData(float[] ImgData, int channel, int widthImage, int heightImage)
        {
            float[] colorChannels = { 0, 0, 0 };

            float[] cfImg = new float[widthImage * heightImage * 3];

            for (int y = 0, index = 0; y < widthImage * heightImage; y++)
            {
                colorChannels[channel] = ImgData[y];

                cfImg[index++] = colorChannels[0];
                cfImg[index++] = colorChannels[1];
                cfImg[index++] = colorChannels[2];
            }

            return GetBitmapFromImageData(cfImg, widthImage, heightImage);
        }

        private Bitmap GetGrayImageFromImageData(float[] ImgData, int widthImage, int heightImage)
        {
            float[] cfImg = new float[widthImage * heightImage * 3];

            for (int y = 0, index = 0; y < widthImage * heightImage; y++)
            {
                cfImg[index++] = ImgData[y];
                cfImg[index++] = ImgData[y];
                cfImg[index++] = ImgData[y];
            }

            return GetBitmapFromImageData(cfImg, widthImage, heightImage);
        }

        private void GettingChannelFromImage()
        {
            string channel = (string)GetValueControlInOtherThread(cmbChannel, "Text", null);

           // string channel = cmbChannel.Text;

            if (channel == "Gray")
            {
                colorFilterData = GetGrayChannelFromImageData(originalImage, widthImage, heightImage);

                picSourceImage.Image = GetGrayImageFromImageData(colorFilterData, widthImage, heightImage);
            }
            else
            {
                if (channel == "Original")
                {
                    colorFilterData = null;

                    picSourceImage.Image = GetBitmapFromImageData(originalImage, widthImage, heightImage);

                    return;
                }

                colorFilterData = GetColorChannelFromImageData(originalImage,
                    colorChannel[channel], widthImage, heightImage);

                picSourceImage.Image = GetColorChannelBitmapFromImageData(colorFilterData,
                    colorChannel[channel], widthImage, heightImage);
            }
        }

        #endregion

        #region Digital Holography

        // расчет ядра свертки 
        private Complex[] CalculationConvolutionKernel()
        {
            Complex[] h = new Complex[widthImage * heightImage];

            Complex expWave = Complex.Exp((Complex.ImaginaryOne * 2 * Math.PI * d) / wave) /
                (Complex.ImaginaryOne * d * wave);

            for (int i = 0, index = 0; i < widthImage; i++)
            {
                for (int j = 0; j < heightImage; j++)
                {
                    double shift = Math.Pow(i - N / 2, 2) + Math.Pow(j - N / 2, 2);

                    h[index++] = expWave * Complex.Exp((Complex.ImaginaryOne * Math.PI * dx * dx * shift)
                        / (wave * d));
                }
            }

            return h;
        }

        #region Generation hologramm

        // расчет двумерного БПФ умноженного на ядро свертки
        private Complex[] CalcFourierImageDataConvKernel()
        {
            Complex[] ConvKernel = ForwardFFT(CalculationConvolutionKernel());

            Complex[] FourierImageData = ForwardFFT(colorFilterData);

            Complex[] resultComplex = new Complex[ConvKernel.Length];

            for (int i = 0; i < ConvKernel.Length; i++)
                resultComplex[i] = ConvKernel[i] * FourierImageData[i];

            return InverseFFT(resultComplex);
        }

        // сумма комплексных амплитуд объектной и опорной волны
        private float[] SummComplexAmplitude()
        {
            float[] intensity = new float[widthImage * heightImage];

            Complex[] objectWave = CalcFourierImageDataConvKernel();

            int indexMax = Array.IndexOf(ComplexToArray(objectWave), ComplexToArray(objectWave).Max());

            Complex maxE = objectWave[indexMax];

            Complex referenceWave = maxE * Complex.Exp((2 * Math.PI / wave) *
                (-Complex.ImaginaryOne) * dx * tetha);

            Complex[] summRefObjWaves = new Complex[intensity.Length];

            for (int i = 0; i < intensity.Length; i++)
                summRefObjWaves[i] = objectWave[i] + referenceWave;

            phaseGenImage = ShiftImage(GetPhase(summRefObjWaves));

            for (int i = 0; i < intensity.Length; i++)
                intensity[i] = (float)Math.Pow(Complex.Abs(summRefObjWaves[i]), 2);

            return ShiftImage(intensity);
        }

        private void GenerationHologramm()
        {
            float[] intensity = SummComplexAmplitude();

            float Imax = intensity.Max();

            for (int i = 0; i < intensity.Length; i++)
                intensity[i] = 255 * intensity[i] / Imax;

            simulationImage = (float[])intensity.Clone();

            picGenHolo.Image = GetGrayImageFromImageData(simulationImage, widthImage, heightImage);
        }

        #endregion

        #region Reconstruction hologramm

        // сумма комплексных амплитуд объектной и опорной волны
        private float[] SummHologrammComplexAmplitude()
        {
            Complex[] intensityComplex = new Complex[widthImage * heightImage];

            Complex[] resultFft = new Complex[intensityComplex.Length];

            float[] result = new float[intensityComplex.Length];

            float maxE = simulationImage.Max();

            Complex referenceWave = maxE * Complex.Exp((2 * Math.PI / wave) *
                (-Complex.ImaginaryOne) * dx * tetha);

            for (int i = 0; i < intensityComplex.Length; i++)
                intensityComplex[i] = simulationImage[i] + referenceWave;

            Complex[] ConvKernel = ForwardFFT(CalculationConvolutionKernel());

            Complex[] FourierImageData = ForwardFFT(intensityComplex);

            for (int i = 0; i < ConvKernel.Length; i++)
                resultFft[i] = ConvKernel[i] * FourierImageData[i];

            resultFft = InverseFFT(resultFft);

            for (int i = 0; i < ConvKernel.Length; i++)
                result[i] = (float)Math.Pow(Complex.Abs(resultFft[i]), 2);

            phaseReconImage = ShiftImage(GetPhase(resultFft));

            return ShiftImage(result);
        }

        private void ReconstructionFixedDistance()
        {
            float[] intensity = SummHologrammComplexAmplitude();

            float Imax = intensity.Max();

            for (int i = 0; i < intensity.Length; i++)
                intensity[i] = 255 * intensity[i] / Imax;

            reconstructionImage = (float[])intensity.Clone();

            picReconHolo.Image = GetGrayImageFromImageData(reconstructionImage, widthImage, heightImage);

            picAnalyze.Image = new Bitmap(picReconHolo.Image);

            picScale.Image = new Bitmap(picReconHolo.Image);

            visibleImageRectangle = BoundVisibleImage(picReconHolo, sr0);
        }

        private void ReconstructionDynamicDistance()
        {
            //trackBar1.Enabled = true;
            SetValueControlInOtherThread(trackBar1, "Enabled", true);

            SetValueControlInOtherThread(btnSaveAllReconImages, "Enabled", true);

            //trackBar1.Maximum = steps - 1;
            SetValueControlInOtherThread(trackBar1, "Maximum", steps - 1);

            for (int index = 0; index < steps; index++)
            {
                distances.Add(d / mm);

                //toolStripStatusLabel1.Text = $"Обработка ({index + 1} из {steps})"; // статус обработки в статус баре
                SetValueControlInOtherThread(toolStripStatusLabel1, "Text", $"Обработка ({index + 1} из {steps})");

                //toolStripProgressBar1.Value = 95 * index / steps; // прогресс бар
                SetValueControlInOtherThread(toolStripProgressBar1, "Value", 95 * index / steps);

                Complex[] intensityComplex = new Complex[widthImage * heightImage];

                float maxE = simulationImage.Max();

                Complex referenceWave = maxE * Complex.Exp((2 * Math.PI / wave) *
                    (-Complex.ImaginaryOne) * dx * tetha);

                for (int i = 0; i < intensityComplex.Length; i++)
                    intensityComplex[i] = simulationImage[i] + referenceWave;

                Complex[] resultFft = new Complex[intensityComplex.Length];

                float[] result = new float[intensityComplex.Length];

                Complex[] ConvKernel = ForwardFFT(CalculationConvolutionKernel());

                Complex[] FourierImageData = ForwardFFT(intensityComplex);

                for (int i = 0; i < ConvKernel.Length; i++)
                    resultFft[i] = ConvKernel[i] * FourierImageData[i];

                resultFft = InverseFFT(resultFft);

                reconstructionPhaseImages.Add(GetGrayImageFromImageData(ShiftImage(GetPhase(resultFft)), widthImage, heightImage));

                reconstructionImages.Add(GetGrayImageFromImageData(ShiftImage(GetAbs(resultFft)), widthImage, heightImage));

                d += sizeStep;
            }

            InitializeParameters();

            picReconHolo.Image = reconstructionImages[0];

            picAnalyze.Image = new Bitmap(picReconHolo.Image);

            picScale.Image = new Bitmap(picReconHolo.Image);

            visibleImageRectangle = BoundVisibleImage(picReconHolo, sr0);

            //toolStripProgressBar1.Value = 100; // прогресс бар
            SetValueControlInOtherThread(toolStripProgressBar1, "Value", 100);

            Thread.Sleep(2000);

            //toolStripStatusLabel1.Text = "Готово"; // статус обработки в статус баре
            SetValueControlInOtherThread(toolStripStatusLabel1, "Text", "Готово");
        }

        #endregion

        #region FFT

        private void Fft1d(int dir, int m, ref double[] x, ref double[] y)
        {
            long nn, i, i1, j, k, i2, l, l1, l2;
            double c1, c2, tx, ty, t1, t2, u1, u2, z;
            /* Calculate the number of points */
            nn = 1;
            for (i = 0; i < m; i++)
                nn *= 2;
            /* Do the bit reversal */
            i2 = nn >> 1;
            j = 0;
            for (i = 0; i < nn - 1; i++)
            {
                if (i < j)
                {
                    tx = x[i];
                    ty = y[i];
                    x[i] = x[j];
                    y[i] = y[j];
                    x[j] = tx;
                    y[j] = ty;
                }
                k = i2;
                while (k <= j)
                {
                    j -= k;
                    k >>= 1;
                }
                j += k;
            }
            /* Compute the FFT */
            c1 = -1.0;
            c2 = 0.0;
            l2 = 1;
            for (l = 0; l < m; l++)
            {
                l1 = l2;
                l2 <<= 1;
                u1 = 1.0;
                u2 = 0.0;
                for (j = 0; j < l1; j++)
                {
                    for (i = j; i < nn; i += l2)
                    {
                        i1 = i + l1;
                        t1 = u1 * x[i1] - u2 * y[i1];
                        t2 = u1 * y[i1] + u2 * x[i1];
                        x[i1] = x[i] - t1;
                        y[i1] = y[i] - t2;
                        x[i] += t1;
                        y[i] += t2;
                    }
                    z = u1 * c1 - u2 * c2;
                    u2 = u1 * c2 + u2 * c1;
                    u1 = z;
                }
                c2 = Math.Sqrt((1.0 - c1) / 2.0);
                if (dir == 1)
                    c2 = -c2;
                c1 = Math.Sqrt((1.0 + c1) / 2.0);
            }
            /* Scaling for forward transform */
            if (dir == 1)
            {
                for (i = 0; i < nn; i++)
                {
                    x[i] /= (double)nn;
                    y[i] /= (double)nn;

                }
            }

            //  return(true) ;
            return;
        }

        private Complex[,] Fft2d(Complex[,] c, int nx, int ny, int dir)
        {
            int i, j;
            int m;//Power of 2 for current number of points
            double[] real;
            double[] imag;
            Complex[,] output;//=new COMPLEX [nx,ny];
            output = c; // Copying Array
            // Transform the Rows 
            real = new double[nx];
            imag = new double[nx];

            for (j = 0; j < ny; j++)
            {
                for (i = 0; i < nx; i++)
                {
                    real[i] = c[i, j].Real;
                    imag[i] = c[i, j].Imaginary;
                }
                // Calling 1D FFT Function for Rows
                m = (int)Math.Log(nx, 2);//Finding power of 2 for current number of points e.g. for nx=512 m=9
                Fft1d(dir, m, ref real, ref imag);

                for (i = 0; i < nx; i++)
                {
                    //  c[i,j].real = real[i];
                    //  c[i,j].imag = imag[i];

                    output[i, j] = new Complex(real[i], imag[i]);
                    //output[i, j].real = real[j];
                    //output[i, j].imag = imag[j];
                }
            }
            // Transform the columns  
            real = new double[ny];
            imag = new double[ny];

            for (i = 0; i < nx; i++)
            {
                for (j = 0; j < ny; j++)
                {
                    //real[j] = c[i,j].real;
                    //imag[j] = c[i,j].imag;
                    real[j] = output[i, j].Real;
                    imag[j] = output[i, j].Imaginary;
                }
                // Calling 1D FFT Function for Columns
                m = (int)Math.Log((double)ny, 2);//Finding power of 2 for current number of points e.g. for nx=512 m=9
                Fft1d(dir, m, ref real, ref imag);
                for (j = 0; j < ny; j++)
                {
                    //c[i,j].real = real[j];
                    //c[i,j].imag = imag[j];

                    output[i, j] = new Complex(real[j], imag[j]);

                    //output[i, j].real = real[j];
                    //output[i, j].imag = imag[j];
                }
            }

            // return(true);
            return (output);
        }

        private Complex[] Fft2dFor1dArray(Complex[] c, int nx, int ny, int dir)
        {
            int i, j;
            int m;//Power of 2 for current number of points
            double[] real;
            double[] imag;
            Complex[] output;//=new COMPLEX [nx,ny];
            output = c; // Copying Array
            // Transform the Rows 
            real = new double[nx];
            imag = new double[nx];

            for (j = 0; j < ny; j++)
            {
                for (i = 0; i < nx; i++)
                {
                    real[i] = c[j * nx + i].Real;
                    imag[i] = c[j * nx + i].Imaginary;
                }
                // Calling 1D FFT Function for Rows
                m = (int)Math.Log(nx, 2);//Finding power of 2 for current number of points e.g. for nx=512 m=9
                Fft1d(dir, m, ref real, ref imag);

                for (i = 0; i < nx; i++)
                {
                    //  c[i,j].real = real[i];
                    //  c[i,j].imag = imag[i];

                    output[j * nx + i] = new Complex(real[i], imag[i]);
                    //output[i, j].real = real[j];
                    //output[i, j].imag = imag[j];
                }
            }
            // Transform the columns  
            real = new double[ny];
            imag = new double[ny];

            for (i = 0; i < nx; i++)
            {
                for (j = 0; j < ny; j++)
                {
                    //real[j] = c[i,j].real;
                    //imag[j] = c[i,j].imag;
                    real[j] = output[j * nx + i].Real;
                    imag[j] = output[j * nx + i].Imaginary;
                }
                // Calling 1D FFT Function for Columns
                m = (int)Math.Log(ny, 2);//Finding power of 2 for current number of points e.g. for nx=512 m=9
                Fft1d(dir, m, ref real, ref imag);
                for (j = 0; j < ny; j++)
                {
                    //c[i,j].real = real[j];
                    //c[i,j].imag = imag[j];

                    output[j * nx + i] = new Complex(real[j], imag[j]);

                    //output[i, j].real = real[j];
                    //output[i, j].imag = imag[j];
                }
            }

            // return(true);
            return (output);
        }

        private Complex[] ArrayToComplex(float[] Input)
        {
            Complex[] Complex = new Complex[widthImage * heightImage];

            for (int y = 0; y < widthImage * heightImage; y++)
            {
                Complex[y] = new Complex(Input[y], 0);
            }

            return Complex;
        }

        private float[] ComplexToArray(Complex[] Input)
        {
            float[] data = new float[widthImage * heightImage];

            for (int y = 0; y < widthImage * heightImage; y++)
            {
                data[y] = (float)Math.Ceiling(Input[y].Magnitude);
            }

            return data;
        }

        private Complex[] ForwardFFT(float[] Input)
        {
            return Fft2dFor1dArray(ArrayToComplex(Input),
                widthImage, heightImage, 1);
        }

        private Complex[] ForwardFFT(Complex[] Input)
        {
            return Fft2dFor1dArray(Input,
                widthImage, heightImage, 1);
        }

        private Complex[] InverseFFT(Complex[] Input)
        {
            return Fft2dFor1dArray(Input, widthImage, heightImage, -1);
        }

        private T[] ShiftImage<T>(T[] Input)
        {
            int i, j;
            T[] Shifted = new T[widthImage * heightImage];

            for (i = 0; i < widthImage / 2; i++)
                for (j = 0; j < heightImage / 2; j++)
                {
                    Shifted[(i + (widthImage / 2)) * heightImage + (j + (heightImage / 2))] = Input[i * heightImage + j];
                    Shifted[i * heightImage + j] = Input[(i + (widthImage / 2)) * heightImage + (j + (heightImage / 2))];
                    Shifted[(i + (widthImage / 2)) * heightImage + j] = Input[i * heightImage + (j + (heightImage / 2))];
                    Shifted[i * heightImage + (j + (widthImage / 2))] = Input[(i + (widthImage / 2)) * heightImage + j];
                }

            return Shifted;
        }

        private float[] GetPhase(Complex[] Input)
        {
            float[] result = new float[Input.Length];

            for (int i = 0; i < Input.Length; i++)
                result[i] = (float)Input[i].Phase;

            float phaseMax = result.Max();

            for (int i = 0; i < result.Length; i++)
                result[i] = 255 * result[i] / phaseMax;

            return result;
        }

        private float[] GetAbs(Complex[] Input)
        {
            float[] intensity = new float[Input.Length];

            for (int i = 0; i < Input.Length; i++)
                intensity[i] = (float)Math.Pow(Complex.Abs(Input[i]), 2);

            float Imax = intensity.Max();

            for (int i = 0; i < intensity.Length; i++)
                intensity[i] = 255 * intensity[i] / Imax;

            return intensity;
        }

        private void ReadImage(Bitmap Obj)
        {
            int i, j;
            int[,] GreyImage = new int[widthImage, heightImage];  //[Row,Column]
            Bitmap image = Obj;
            BitmapData bitmapData1 = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                     ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                byte* imagePointer1 = (byte*)bitmapData1.Scan0;

                for (i = 0; i < bitmapData1.Height; i++)
                {
                    for (j = 0; j < bitmapData1.Width; j++)
                    {
                        //TODO:

                        GreyImage[j, i] = imagePointer1[2];// (int)((imagePointer1[0] + imagePointer1[1] + imagePointer1[2]) / 3.0);
                        //4 bytes per pixel
                        imagePointer1 += 4;
                    }//end for j
                    //4 bytes per pixel
                    imagePointer1 += bitmapData1.Stride - (bitmapData1.Width * 4);
                }//end for i
            }//end unsafe
            image.UnlockBits(bitmapData1);

            ForwardFFT(GreyImage);
            return;
        }

        private void ForwardFFT(int[,] Input)
        {
            int nx = Input.GetLength(0);
            int ny = Input.GetLength(1);

            //Initializing Fourier Transform Array
            int i, j;
            Complex[,] Fourier = new Complex[widthImage, heightImage];
            Complex[,] Output = new Complex[widthImage, heightImage];
            //Copy Image Data to the Complex Array
            for (i = 0; i <= widthImage - 1; i++)
                for (j = 0; j <= heightImage - 1; j++)
                {
                    Fourier[i, j] = new Complex(Input[i, j], 0);

                    //Fourier[i, j].Real = (double)GreyImage[i, j];
                    //Fourier[i, j].Imaginary = 0;
                }
            //Calling Forward Fourier Transform
            Output = Fft2d(Fourier, nx, ny, 1);
            return;
        }

        #endregion

        #endregion
    }
}
