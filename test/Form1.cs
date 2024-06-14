using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace test
{
    public partial class Form1 : Form
    {
        //variable init
        Pen start = new Pen(Color.YellowGreen, 5); //Start
        Pen end = new Pen(Color.Red, 5); //End
        Pen line = new Pen(Color.Blue, 2); //Line
        Pen pen1_big = new Pen(Color.Black, 7); //Dot big
        Pen start_big = new Pen(Color.YellowGreen, 7); //Start big
        Pen end_big = new Pen(Color.Red, 7); //End big
        Pen line_big = new Pen(Color.Blue, 4); //Line big
        Pen center = new Pen(Color.Yellow, 3); //Center point
        const int dot_quantity = 50; //線段數量上限
        int[] dot = {0, 0}; //當前創建的點
        int[,,] dot_map = new int[dot_quantity, 4, 2]; //點的座標
        double[] speed = new double[dot_quantity]; //機器速度(伏特 V)
        int[] Point_num = new int[dot_quantity]; //中間點的數量
        int[] num = { -1, -1}; //當前選擇的點 Move 用
        int big = -1; //當前選擇的線段
        int pictureBox_size;
        double Proportion; //輸出與輸入轉換用比例
        Boolean creat = false; //創建模式
        Boolean picture = true; //更換圖片
        public Form1()
        {
            InitializeComponent();
            InitializeDoubleBuffering(this);
            InitializeDotMap(); //Map reset
            Label_Line.Text = String.Format("Line = ");
            Label_Point.Text = String.Format("Point = ");
            Label_Mode.Text = "Mode : Adjustment";
            pictureBox_size = (int)(this.Size.Height * 0.88);
            Change_size();
        }

        private void InitializeDoubleBuffering(Control control)
        {
            control.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(control, true, null);
            foreach (Control child in control.Controls)
            {
                InitializeDoubleBuffering(child);
            }
        }

        private void InitializeDotMap()
        {
            for (int i = 0; i < dot_quantity; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    dot_map[i, j, 0] = 0;
                    dot_map[i, j, 1] = 0;
                }
            }
        }

        public void draw_background()
        {
            Bitmap buffer = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics GPS = Graphics.FromImage(buffer))
            {
                for (int i = 0; i <= dot[0]; i++)
                {
                    if (dot_map[i, 3, 0] != 0)
                    {
                        if (big == i)
                        {
                            GPS.DrawBezier(line_big, new Point(dot_map[i, 0, 0], dot_map[i, 0, 1]), new Point(dot_map[i, 1, 0], dot_map[i, 1, 1]), new Point(dot_map[i, 2, 0], dot_map[i, 2, 1]), new Point(dot_map[i, 3, 0], dot_map[i, 3, 1]));
                            draw_center_dot(GPS, i);
                            GPS.DrawEllipse(start_big, dot_map[i, 0, 0] - 3.5f, dot_map[i, 0, 1] - 3.5f, 7, 7);
                            GPS.DrawEllipse(pen1_big, dot_map[i, 1, 0] - 3.5f, dot_map[i, 1, 1] - 3.5f, 7, 7);
                            GPS.DrawEllipse(pen1_big, dot_map[i, 2, 0] - 3.5f, dot_map[i, 2, 1] - 3.5f, 7, 7);
                            GPS.DrawEllipse(end_big, dot_map[i, 3, 0] - 3.5f, dot_map[i, 3, 1] - 3.5f, 7, 7);
                        }
                        else
                        {
                            GPS.DrawBezier(line, new Point(dot_map[i, 0, 0], dot_map[i, 0, 1]), new Point(dot_map[i, 1, 0], dot_map[i, 1, 1]), new Point(dot_map[i, 2, 0], dot_map[i, 2, 1]), new Point(dot_map[i, 3, 0], dot_map[i, 3, 1]));
                            GPS.DrawEllipse(start, dot_map[i, 0, 0] - 2.5f, dot_map[i, 0, 1] - 2.5f, 5, 5);
                            GPS.DrawEllipse(end, dot_map[i, 3, 0] - 2.5f, dot_map[i, 3, 1] - 2.5f, 5, 5);
                        }
                    }
                    else if (dot_map[i, 0, 0] != 0)
                    {
                        GPS.DrawEllipse(start_big, dot_map[i, 0, 0] - 3.5f, dot_map[i, 0, 1] - 3.5f, 7, 7);
                    }
                }
            }

            // 將緩衝位圖繪製到 PictureBox
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = buffer;
        }

        private void draw_center_dot(Graphics GPS, int i) //輸出中間的點
        {
            double[] arcLengths = CalculateLength(i);
            double totalLength = arcLengths[100];
            double segmentLength = totalLength / Point_num[i];

            for (int k = 1; k <= Point_num[i]; k++)
            {
                double targetLength = k * segmentLength;
                double t = FindTForLength(targetLength, arcLengths);
                int x = (int)Math.Round(CalculateBezierPoint(t, dot_map[i, 0, 0], dot_map[i, 1, 0], dot_map[i, 2, 0], dot_map[i, 3, 0]));
                int y = (int)Math.Round(CalculateBezierPoint(t, dot_map[i, 0, 1], dot_map[i, 1, 1], dot_map[i, 2, 1], dot_map[i, 3, 1]));
                GPS.DrawEllipse(center, x - 1.5f, y - 1.5f, 3, 3);
            }
        }

        //計算貝茲曲線中的點----------------------------------------------------------------------
        private double Distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }

        private double CalculateBezierPoint(double t, double p0, double p1, double p2, double p3)
        {
            return (1 - t) * (1 - t) * (1 - t) * p0 +
                   3 * t * (1 - t) * (1 - t) * p1 +
                   3 * t * t * (1 - t) * p2 +
                   t * t * t * p3;
        }

        private double FindTForLength(double length, double[] arcLengths)
        {
            int low = 0;
            int high = arcLengths.Length - 1;
            while (low < high)
            {
                int mid = (low + high) / 2;
                if (arcLengths[mid] < length)
                    low = mid + 1;
                else
                    high = mid;
            }
            return (double)low / (arcLengths.Length - 1);
        }

        private double[] CalculateLength(int i)
        {
            int numSegments = 100; // 分段數
            double[] arcLengths = new double[numSegments + 1];
            arcLengths[0] = 0;

            // 計算貝塞爾曲線的近似弧長
            double prevX = dot_map[i, 0, 0];
            double prevY = dot_map[i, 0, 1];
            for (int j = 1; j <= numSegments; j++)
            {
                double t = (double)j / numSegments;
                double x = CalculateBezierPoint(t, dot_map[i, 0, 0], dot_map[i, 1, 0], dot_map[i, 2, 0], dot_map[i, 3, 0]);
                double y = CalculateBezierPoint(t, dot_map[i, 0, 1], dot_map[i, 1, 1], dot_map[i, 2, 1], dot_map[i, 3, 1]);
                arcLengths[j] = arcLengths[j - 1] + Distance(prevX, prevY, x, y);
                prevX = x;
                prevY = y;
            }

            return arcLengths;
        }
        //----------------------------------------------------------------------------------------
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) //移動點
        {
            if (num[0] != -1 && e.Button == MouseButtons.Left)
            {
                dot_map[num[0], num[1], 0] = e.X;
                dot_map[num[0], num[1], 1] = e.Y;
                draw_background();
            }
            else if (num[0] != -1)
            {
                num[0] = -1;
                Listbox_updata();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) //選擇或是創建點
        {
            if (num[0] == -1) //當前沒有在移動點
            {
                if (dot[0] != dot_quantity && creat)
                {
                    Create_Dot(e);
                }
                else
                {
                    Select_Dot(e);
                }
            }
            else
            {
                num[0] = -1;
                draw_background();
            }
            Listbox_updata();
        }

        private void Create_Dot(MouseEventArgs e) {
            big = dot[0];
            speed[dot[0]] = 6;
            Point_num[dot[0]] = 30;
            Label_Line.Text = $"Line = {dot[0] + 1}";
            Label_Point.Text = $"Point = {dot[1]}";
            if (dot[1] == 0) //點擊第一下創建起點
            {
                dot_map[dot[0], 0, 0] = e.X;
                dot_map[dot[0], 0, 1] = e.Y;
                dot[1] = 3;
            }
            else //點擊第二下創建剩下三個點
            {
                dot_map[dot[0], 3, 0] = e.X;
                dot_map[dot[0], 3, 1] = e.Y;
                int x = dot_map[dot[0], 0, 0] - dot_map[dot[0], 3, 0];
                int y = dot_map[dot[0], 0, 1] - dot_map[dot[0], 3, 1];
                dot_map[dot[0], 1, 0] = dot_map[dot[0], 0, 0] - (x / 3);
                dot_map[dot[0], 1, 1] = dot_map[dot[0], 0, 1] - (y / 3);
                dot_map[dot[0], 2, 0] = dot_map[dot[0], 0, 0] - (x / 3 * 2);
                dot_map[dot[0], 2, 1] = dot_map[dot[0], 0, 1] - (y / 3 * 2);
                double n = Math.Sqrt(Math.Pow(dot_map[dot[0], 0, 0] - dot_map[dot[0], 3, 0], 2) + Math.Pow(dot_map[dot[0], 0, 1] - dot_map[dot[0], 3, 1], 2));
                dot[0] += 1;
                dot[1] = 0;
                creat = false;
                Label_Mode.Text = "Mode : Adjustment";
                Bar_Speed.Value = 1800;
                hScrollBar1.Value = (int)(n * Proportion / 10);
            }
            draw_background();
            Listbox_updata();
        }

        private void Select_Dot(MouseEventArgs e)
        {
            //一個一個點下去跑看是否在鼠標點擊範圍內
            for (int i = 0; i < dot_quantity; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if ((dot_map[i, j, 0] + 7 > e.X && dot_map[i, j, 0] - 7 < e.X) && (dot_map[i, j, 1] + 7 > e.Y && dot_map[i, j, 1] - 7 < e.Y) && dot_map[i, j, 1] != 0)
                    {
                        num[0] = i;
                        num[1] = j;
                        Label_Line.Text = String.Format("Line = " + (big + 1).ToString());
                        Label_Point.Text = String.Format("Point = " + num[1].ToString());
                        draw_background();
                        big = i;
                        Bar_Speed.Value = (int)((speed[big] + 12) * 100);
                        label2.Text = speed[big].ToString();
                        hScrollBar1.Value = Point_num[big];
                        label3.Text = Point_num[big].ToString();
                        break;
                    }
                    else if (dot_map[i, j, 0] == 0)
                    {
                        break;
                    }
                }
            }
        }

        private void Listbox_updata()
        {
            listBox1.Items.Clear();
            double n = 400.0 / pictureBox1.Size.Height;
            int selectedIndex = -1;  // 用來記錄需要選中的索引

            if (big != -1) //把正在編輯的點至頂
            {
                selectedIndex = 0; //記錄當前 "Line" 塊的起始索引
                listBox1.Items.Add(string.Format("Line {0,2:d}", (big + 1)));
                listBox1.Items.Add(string.Format("Point_Start    =    [{0,3:d}, {1,3:d}]", (int)(dot_map[big, 0, 0] * n), (int)((pictureBox1.Size.Height - dot_map[big, 0, 1]) * n)));
                listBox1.Items.Add(string.Format("Point_Center1 = [{0,3:d}, {1,3:d}]", (int)(dot_map[big, 1, 0] * n), (int)((pictureBox1.Size.Height - dot_map[big, 1, 1]) * n)));
                listBox1.Items.Add(string.Format("Point_Center2 = [{0,3:d}, {1,3:d}]", (int)(dot_map[big, 2, 0] * n), (int)((pictureBox1.Size.Height - dot_map[big, 2, 1]) * n)));
                listBox1.Items.Add(string.Format("Point_End    =    [{0,3:d}, {1,3:d}]", (int)(dot_map[big, 3, 0] * n), (int)((pictureBox1.Size.Height - dot_map[big, 3, 1]) * n)));
                listBox1.Items.Add(string.Format("Speed = {0:F1}", speed[big]));
                listBox1.Items.Add(string.Format("Point = {0,2:d}", Point_num[big]));
                listBox1.Items.Add("------------------------------------------------------");
            }

            for (int i = 0; i < dot[0]; i++) //輸出剩下的點
            {
                if (i != big)
                {
                    listBox1.Items.Add(string.Format("Line {0,2:d}", (i + 1)));
                    listBox1.Items.Add(string.Format("Point_Start    =    [{0,3:d}, {1,3:d}]", (int)(dot_map[i, 0, 0] * n), (int)((pictureBox1.Size.Height - dot_map[i, 0, 1]) * n)));
                    listBox1.Items.Add(string.Format("Point_Center1 = [{0,3:d}, {1,3:d}]", (int)(dot_map[i, 1, 0] * n), (int)((pictureBox1.Size.Height - dot_map[i, 1, 1]) * n)));
                    listBox1.Items.Add(string.Format("Point_Center2 = [{0,3:d}, {1,3:d}]", (int)(dot_map[i, 2, 0] * n), (int)((pictureBox1.Size.Height - dot_map[i, 2, 1]) * n)));
                    listBox1.Items.Add(string.Format("Point_End    =    [{0,3:d}, {1,3:d}]", (int)(dot_map[i, 3, 0] * n), (int)((pictureBox1.Size.Height - dot_map[i, 3, 1]) * n)));
                    listBox1.Items.Add(string.Format("Speed = {0:F1}", speed[i]));
                    listBox1.Items.Add(string.Format("Point = {0,2:d}", Point_num[i]));
                    listBox1.Items.Add("------------------------------------------------------");
                }
            }

            // 在最後設置選中項目，確保選中索引有效
            if (selectedIndex != -1 && selectedIndex < listBox1.Items.Count)
            {
                listBox1.SetSelected(selectedIndex, true);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Label_Messenger.Text != "輸入錯誤")
            {
                try
                {
                    for (int i = 1; i <= dot[0]; i++)
                    {
                        if ("Line  " + i.ToString() == listBox1.SelectedItem.ToString())
                        {
                            big = i - 1;
                            Bar_Speed.Value = (int)((speed[big] + 12) * 100);
                            label2.Text = speed[big].ToString();
                            hScrollBar1.Value = Point_num[big];
                            label3.Text = Point_num[big].ToString();
                            draw_background();
                            break;
                        }
                    }
                    if (big == -1)
                    {
                        draw_background();
                        Label_Line.Text = "Line = ";
                        Label_Point.Text = "Point = ";
                    }
                    else
                    {
                        Label_Line.Text = String.Format("Line = " + (big + 1).ToString());
                    }
                }
                catch (Exception)
                {
                    big = -1;
                }
            } 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Label_Messenger.Text = "";
        }

        private void Button_Creat_Click(object sender, EventArgs e)
        {
            creat = true;
            Label_Mode.Text = "Mode : Create";
            Listbox_updata();
        }

        private void Button_Delete_Click(object sender, EventArgs e) //刪除線段
        {
            if (big != -1 && dot[0] >= 0)
            {
                for (int i = big; i < dot[0] - 1; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        dot_map[i, j, 0] = dot_map[i + 1, j, 0];
                        dot_map[i, j, 1] = dot_map[i + 1, j, 1];
                    }
                }
                for (int j = 0; j < 4; j++)
                {
                    dot_map[dot[0] - 1, j, 0] = 0;
                    dot_map[dot[0] - 1, j, 1] = 0;
                }
                dot[0] -= 1;
                dot[1] = 0;
                big = -1;
                draw_background();
                Listbox_updata();
            }
        }

        private void Button_Change_Click(object sender, EventArgs e) //更改底圖
        {
            pictureBox1.BackgroundImage = (picture) ? Properties.Resources.Background_Image_2 : Properties.Resources.Background_Image_1;
            picture = !(picture);
            Button_Change.Text = (picture) ? "Tournament" : "Skill";
        }

        private void Button_Open_Click(object sender, EventArgs e)
        {
            Open_File();
        }

        private void Open_File()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "請選擇要開啟的檔案";
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        // 清空 dot_map
                        for (int i = 0; i < dot_quantity; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                dot_map[i, j, 0] = 0;
                                dot_map[i, j, 1] = 0;
                            }
                            speed[i] = 0;
                            Point_num[1] = 0;
                        }

                        using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                        {
                            string line;
                            dot[0] = 0;
                            dot[1] = 0;

                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] parts = line.Split(' ');

                                if (parts.Length != 10)
                                {
                                    throw new FormatException("文件格式錯誤");
                                }

                                for (int i = 0; i < 4; i++)
                                {
                                    dot_map[dot[0], i, 0] = (int)(Int32.Parse(parts[i * 2]) / Proportion);
                                    dot_map[dot[0], i, 1] = (int)(pictureBox1.Size.Height - Int32.Parse(parts[i * 2 + 1]) * Proportion);
                                }

                                speed[dot[0]] = Int32.Parse(parts[8]);
                                Point_num[dot[0]] = Int32.Parse(parts[9]);
                                dot[0] += 1;
                            }
                        }

                        num[0] = -1;
                        num[1] = -1;
                        creat = false;
                        big = dot[0] - 1;
                        Label_Mode.Text = "Mode : Adjustment";
                        draw_background();
                        Listbox_updata();
                        Label_Messenger.Text = "文件開啟成功";
                    }
                    catch (FormatException)
                    {
                        Label_Messenger.Text = "文件格式錯誤";
                    }
                    catch (Exception)
                    {
                        Label_Messenger.Text = "加載文件時出錯";
                    }
                }
            }
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                Save_File();
            }
            else
            {
                Label_Messenger.Text = "未輸入檔案名稱";
            }
        }

        private void Save_File()
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "文本文件 (*.txt)|*.txt|所有文件 (*.*)|*.*";
                    saveFileDialog.Title = "請選擇要儲存的位置";
                    saveFileDialog.FileName = textBox1.Text.Trim();
                    saveFileDialog.OverwritePrompt = false;

                    DialogResult result = saveFileDialog.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                    {
                        string filePath = saveFileDialog.FileName;
                        List<string> outputLines = new List<string>();
                        List<string> outputPoint = new List<string>();
                        double n = 400.0 / pictureBox1.Size.Height;

                        for (int i = 0; i < dot[0]; i++)
                        {
                            outputPoint.Add(Point(i)); //儲存用檔案
                            outputLines.AddRange(Line(i)); //機器讀取用檔案
                        }

                        // 將點和曲線數據寫入文件
                        File.WriteAllLines(filePath, outputPoint);

                        // 生成另一個文件名（加上 "_Line" 後綴）以保存曲線數據
                        string filePath_Line = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + "_Line.txt");
                        File.WriteAllLines(filePath_Line, outputLines);

                        Label_Messenger.Text = "文件保存成功";
                    }
                }
            }
            catch (Exception)
            {
                Label_Messenger.Text = "保存文件時出錯";
            }
        }

        private String Point(int i) //輸出儲存用檔案
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}",
                (int)(dot_map[i, 0, 0] * Proportion), (int)((pictureBox1.Size.Height - dot_map[i, 0, 1]) * Proportion),
                (int)(dot_map[i, 1, 0] * Proportion), (int)((pictureBox1.Size.Height - dot_map[i, 1, 1]) * Proportion),
                (int)(dot_map[i, 2, 0] * Proportion), (int)((pictureBox1.Size.Height - dot_map[i, 2, 1]) * Proportion),
                (int)(dot_map[i, 3, 0] * Proportion), (int)((pictureBox1.Size.Height - dot_map[i, 3, 1]) * Proportion),
                speed[i], Point_num[i]);
        }

        private List<string> Line(int i) //輸出機器讀取用檔案
        {
            List<string> Lines = new List<string>();

            Lines.Add(Point_num[i].ToString());
            Lines.Add(speed[i].ToString());
            Lines.Add($"{Math.Round(dot_map[i, 0, 0] * Proportion)} {Math.Round((pictureBox1.Size.Height - dot_map[i, 0, 1]) * Proportion)}");
            double[] arcLengths = CalculateLength(i);
            double totalLength = arcLengths[100];
            double segmentLength = totalLength / (Point_num[i] - 1);

            for (int k = 1; k <= Point_num[i] - 1; k++)
            {
                double targetLength = k * segmentLength;
                double t = FindTForLength(targetLength, arcLengths);
                int x = (int)Math.Round(CalculateBezierPoint(t, dot_map[i, 0, 0], dot_map[i, 1, 0], dot_map[i, 2, 0], dot_map[i, 3, 0]));
                int y = (int)Math.Round(CalculateBezierPoint(t, dot_map[i, 0, 1], dot_map[i, 1, 1], dot_map[i, 2, 1], dot_map[i, 3, 1]));
                Lines.Add($"{Math.Round(x * Proportion)} {Math.Round((pictureBox1.Size.Height - y) * Proportion)}");
            }

            return Lines;
        }

        private void Bar_Speed_ValueChanged(object sender, EventArgs e) //調整機器速度
        {
            double n = Math.Round(Bar_Speed.Value / 100.0 - 12, 1);
            label2.Text = n.ToString();
            if (big != -1)
            {
                speed[big] = n;
                Label_Messenger.Text = "";
            }
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e) //調整中間點數量
        {
            int n = hScrollBar1.Value;
            label3.Text = n.ToString();
            if (big != -1)
            {
                Point_num[big] = n;
                Label_Messenger.Text = "";
                draw_background();
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Change_size();
            this.Invalidate();
        }

        private void Change_size() //大小及位置調整
        {
            try
            {
                this.SuspendLayout();  // 暫停佈局
                int size = (int)(this.Size.Height * 0.88);
                double n = (size * 1.0) / (pictureBox_size * 1.0);
                Proportion = 400.0 / pictureBox1.Size.Height;
                for (int i = 0; i < dot[0]; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        dot_map[i, j, 0] = (int)(dot_map[i, j, 0] * n);
                        dot_map[i, j, 1] = (int)(dot_map[i, j, 1] * n);
                    }
                }
                pictureBox1.Location = new Point(20, 40);
                pictureBox_size = size;
                pictureBox1.Size = new Size(size, size);
                Label_Messenger.Location = new Point((int)(size - 160), Label_Messenger.Location.Y);
                label1.Location = new Point((int)(size + 20), label1.Location.Y);
                textBox1.Location = new Point((int)(size + 145), textBox1.Location.Y);
                label6.Location = new Point((int)(size + 40), label6.Location.Y);
                Bar_Speed.Location = new Point((int)(size + 120), Bar_Speed.Location.Y);
                label2.Location = new Point((int)(size + 300), label2.Location.Y);
                label4.Location = new Point((int)(size + 40), label4.Location.Y);
                hScrollBar1.Location = new Point((int)(size + 120), hScrollBar1.Location.Y);
                label3.Location = new Point((int)(size + 300), label3.Location.Y);
                Button_Create.Location = new Point((int)(size + 65), Button_Create.Location.Y);
                Button_Change.Location = new Point((int)(size + 65), Button_Change.Location.Y);
                Button_Delete.Location = new Point((int)(size + 65), Button_Delete.Location.Y);
                listBox1.Location = new Point((int)(size + 65), listBox1.Location.Y);
                Button_Exit.Location = new Point((int)(size + 196), Button_Exit.Location.Y);
                Button_Open.Location = new Point((int)(size + 196), Button_Open.Location.Y);
                Button_Save.Location = new Point((int)(size + 196), Button_Save.Location.Y);
                //消除殘影
                int num = Bar_Speed.Value;
                Bar_Speed.Value = Bar_Speed.Maximum - Bar_Speed.Value;
                Bar_Speed.Value = num;
                num = hScrollBar1.Value;
                hScrollBar1.Value = hScrollBar1.Maximum - hScrollBar1.Value;
                hScrollBar1.Value = num;
            }
            catch
            {

            }
            finally
            {
                draw_background();
                this.ResumeLayout();  // 恢復佈局
            }
        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}