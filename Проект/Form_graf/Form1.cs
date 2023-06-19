using Dll;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Linq;

namespace Form_graf
{
    public partial class Form1 : Form
    {
        //массивы для хранения закрашиваемых ребер
        static int[] ar_1;
        static int[] ar_2;

        //флаг нажатия
        bool IsClicked = false;

        //координаты смещения
        int deltaX = 0;
        int deltaY = 0;

        //координаты вершин
        List<int> x = new List<int>();
        List<int> y = new List<int>();

        //кол-во вершин
        int n = 1;

        //матрица вершин
        int[,] matrix;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControl_Selected);
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            toolStrip1.Cursor = Cursors.Hand;
            toolStrip2.Cursor = Cursors.Hand;
            //рисуем матрицу
            adjacency_matrix();
        }

         static Bitmap bmp = new Bitmap(660, 372);
         Graphics graf = Graphics.FromImage(bmp);
         Pen pen = new Pen(Color.Black);
         SolidBrush brush = new SolidBrush(Color.White);

        void Draw_graf()
        { 
            //рисуем ребра            
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int u = 0; u < matrix.GetLength(1); u++)
                {
                    if (i != u && u > i)
                    {                      
                        if (matrix[i, u] != 0 || matrix[u, i] != 0)
                        {
                            if (ar_1 != null)
                                for (int j = 0; j < matrix.GetLength(1); j++)
                                {
                                    if (i == ar_1[j] && u == ar_2[j] || u == ar_1[j] && i == ar_2[j])
                                    {
                                        pen = new Pen(Color.DarkOrange);
                                        break;
                                    }
                                }
                            graf.DrawLine(pen, x[i], y[i], x[u], y[u]);
                            pen.Color = Color.Black;
                        }
                        if (matrix[i, u] == matrix[u, i] && matrix[u, i] != 0 && matrix[i, u] != 0)
                        {
                            Draw_arrow(x, y, i, u, true);
                            Draw_arrow(x, y, i, u, false);
                        }
                        if (matrix[i, u] != 0 && matrix[u, i] == 0)
                        {
                            Draw_arrow(x, y, i, u, true);
                        }
                        if (matrix[i, u] == 0 && matrix[u, i] != 0)
                        {
                            Draw_arrow(x, y, i, u, false);
                        }
                        if (matrix[i, u] != 0 && matrix[u, i] != 0 && matrix[u, i] != matrix[i, u])
                        {
                            Draw_arrow(x, y, i, u, true);
                            Draw_arrow(x, y, i, u, false);
                        }
                    }
                }
            }

            //рисуем вершины
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (i == number_select_top)
                    pen.Color = Color.Red;

                graf.FillEllipse(brush, x[i] - 15, y[i] - 15, 30, 30);
                graf.DrawEllipse(pen, x[i] - 15, y[i] - 15, 30, 30);  //рисуем круг
                graf.DrawString((i+1).ToString(), new Font("Microsoft Sans Serif", 10,FontStyle.Bold),
                    Brushes.Black, x[i] - 6, y[i] - 7); //рисуем номер вершины

                pen = new Pen(Color.Black);
            }
            Scene.Image = bmp;
        }

        public void Draw_arrow(List<int> x, List<int> y, int i, int u, bool flag)
        {
            double ugol;
            if (flag == true)
                ugol = Math.Atan2(x[i] - x[u], y[i] - y[u]);
            else
                ugol = Math.Atan2(x[u] - x[i], y[u] - y[i]);

            //стрелка
            float x_middle = (x[i] + x[u]) / 2;
            float y_middle = (y[i] + y[u]) / 2;

            float ex = x_middle;
            float ey = y_middle;

            float a;
            float b;

            if (flag == true)
            {
                x_middle = (x_middle + x[i]) / 2;
                y_middle = (y_middle + y[i]) / 2;
                a = x_middle;
                b = y_middle;
                x_middle = (x_middle + ex) / 2;
                y_middle = (y_middle + ey) / 2;
            }
            else
            {
                x_middle = (x_middle + x[u]) / 2;
                y_middle = (y_middle + y[u]) / 2;
                a = x_middle;
                b = y_middle;
                x_middle = (x_middle + ex) / 2;
                y_middle = (y_middle + ey) / 2;
            }

            int x1 = Convert.ToInt32(x_middle + 30 * Math.Sin(0.3 + ugol));
            int y1 = Convert.ToInt32(y_middle + 30 * Math.Cos(0.3 + ugol));
            int x2 = Convert.ToInt32(x_middle + 30 * Math.Sin(ugol - 0.3));
            int y2 = Convert.ToInt32(y_middle + 30 * Math.Cos(ugol - 0.3));

            PointF[] points = { new PointF(x_middle, y_middle), new PointF(x1, y1), new PointF(x2, y2) };

            graf.FillPolygon(brush, points);
            graf.DrawLine(new Pen(Color.DarkBlue), x_middle, y_middle, x1, y1);
            graf.DrawLine(new Pen(Color.DarkBlue), x_middle, y_middle, x2, y2);
            graf.DrawLine(new Pen(Color.DarkBlue), x1, y1, x2, y2);

            float x3 = (x1 + x2 + x_middle - 15) / 3;
            float y3 = (y1 + y2 + y_middle - 15) / 3;

            if (flag == true)
                graf.DrawString(matrix[i, u].ToString(), new Font("Microsoft YaHei UI", 8, FontStyle.Bold),
           Brushes.Black, x3, y3);
            else
                graf.DrawString(matrix[u, i].ToString(), new Font("Microsoft YaHei UI", 8, FontStyle.Bold),
           Brushes.Black, x3, y3);
        }

        int num = 0;

        void Remove_top(int x)
        {
            matrix = new int[n - 2, n - 2];
            x++;
         
            int q1 = 1;
            int q2 = 1;

            for (int i = 1; i < n; i++)
            {
      
                q2 = 1;
                for (int j = 1; j < n; j++)
                {
                    
                    if (i != x && j!=x)
                    {
                        matrix[i - q1,j - q2] = int.Parse(Table[i, j].Value.ToString());
                    }

                    if (i == x) q1 = 2;
                    if (j == x) q2++;
                    
                }
            }
            n--;
            Cope_in_table();
         
        }
        void Cope_in_table()
        {

            Table.ColumnCount = n;
            Table.RowCount = n;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Table[i, i].Style.BackColor = Color.Gray;

                    if (i>0 && j>0)
                    {
                        Table[i, j].Value = matrix[i-1,j-1];
                    }
                    if (j == 0)
                    {
                        Table[i, j].Value = i;
                        Table[i, j].ReadOnly = true;
                    }
                    if (i == 0)
                    {
                        Table[i, j].Value = j;
                        Table[i, j].ReadOnly = true;
                    }
                    Table[i, i].ReadOnly = true;
                }
            bmp = new Bitmap(660, 372);
            graf = Graphics.FromImage(bmp);
            Draw_graf();
        }

        void Delete(MouseEventArgs e)
        {
            for (int i = 0; i < x.Count; i++)
            {
                if ((Math.Pow(e.X - x[i], 2) + Math.Pow(e.Y - y[i], 2)) <= 225)
                {
                    x.RemoveAt(i);
                    y.RemoveAt(i);
                    Remove_top(i);

                    return;
                }
                for(int j = 0; j < x.Count; j++)
                {
                    if(matrix[i,j]>0)
                    {
                        double up = ((y[i] - y[j]) * e.X + (x[j] - x[i]) * e.Y + (x[i] * y[j] - x[j] * y[i]));
                        double down = Math.Sqrt(((x[j] - x[i]) * (x[j] - x[i])) + ((y[j] - y[i]) * (y[j] - y[i])));
                        double dl = Math.Abs(up / down);
                        if (dl < 3)
                        {
                            Table[i+1, j+1].Value = 0;
                            matrix[i, j] = 0;

                             bmp = new Bitmap(660, 372);
                             graf = Graphics.FromImage(bmp);
                             Draw_graf();
                        }
                    }                                         
                }
            }
        }

        int number_select_top = -1;
        void conect_top(MouseEventArgs e)
        {
            for (int i = 0; i < x.Count; i++)
            {
                if ((Math.Pow(e.X - x[i], 2) + Math.Pow(e.Y - y[i], 2)) <= 225)
                {
                    if(number_select_top!=-1 && number_select_top!=i)
                    {
                        Dll.Conect.top_1 = number_select_top + 1;
                        Dll.Conect.top_2 = i+1;

                        Conect_top.Form1 Conect_top = new Conect_top.Form1();
                        Conect_top.StartPosition = FormStartPosition.CenterScreen;
                        Conect_top.ShowDialog();

                        switch(Dll.Conect.direction)
                        {
                            case 'R':
                                Table[number_select_top + 1, i + 1].Value = Dll.Conect.num_3;
                                break;
                            case 'L':
                                Table[i + 1, number_select_top + 1].Value = Dll.Conect.num_3;
                                break;
                            case 'D':
                                   Table[i + 1, number_select_top + 1].Value = Dll.Conect.num_2;
                                   Table[number_select_top + 1, i + 1].Value  =  Dll.Conect.num_1;
                                break;
                        }
                        Copy();
                        Draw_graf();
                        number_select_top = -1;
                        return;
                    }
                    number_select_top = i;
                    Draw_graf();                  
                    return;
                }
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                conect.Checked = false;
                delete.Checked = false;
                create.Checked = false;

                number_select_top = -1;
                Draw_graf();
            }
                if (conect.Checked == true)
            {
                conect_top(e);
            }
            if (delete.Checked == true)
            {
                Delete(e);
            }
            if (create.Checked == true)
            {
                n++;
                adjacency_matrix();
                x.Add(e.X);
                y.Add(e.Y);
                Draw_graf();
            }
            if(conect.Checked == false && create.Checked==false && delete.Checked==false)
                for (int i = 0; i < x.Count; i++)
                {
                    if ((Math.Pow(e.X - x[i], 2) + Math.Pow(e.Y - y[i], 2)) <= 225)
                    {
                        num = i;
                        IsClicked = true;
                        deltaX = e.X - (int)x[i];
                        deltaY = e.Y - (int)y[i];
                    }
                }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsClicked)
            {
                x[num] = e.X - deltaX;
                y[num] = e.Y - deltaY;

                graf.Clear(Color.WhiteSmoke);
                Draw_graf();
            }
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            IsClicked = false;
        }

        void Clear_tlist()
        {
            ar_1 = null;
            ar_2 = null;
        }
        private void create_Click(object sender, EventArgs e)
        {
            Clear_tlist();
            number_select_top = -1;
            Draw_graf();
            if (create.Checked == true)
                create.Checked = false;
            else
            {
                Visiable(true, false, false);
            }
        }
        class CustomProfessionalColors : ProfessionalColorTable
        {
            public override Color ButtonCheckedGradientBegin
            { get { return Color.FromArgb(179, 215, 243); } }

            public override Color ButtonCheckedGradientEnd
            { get { return Color.FromArgb(179, 215, 243); } }
        }

        private void conect_Click(object sender, EventArgs e)
        {
            Clear_tlist();
            ToolStripManager.Renderer = new ToolStripProfessionalRenderer(new CustomProfessionalColors());

            number_select_top = -1;
            Draw_graf();
            if (conect.Checked == true)
            {
                conect.Checked = false;
            }
            else
            {
                Visiable(false, true,false);
            }
        }

        void Visiable(bool t1,bool t2,bool t3)
        {
            create.Checked = t1;
            conect.Checked = t2;
            delete.Checked = t3;          
        }
        private void delete_Click(object sender, EventArgs e)
        {
            Clear_tlist();
            number_select_top = -1;
            Draw_graf();
            if (delete.Checked == true)
                delete.Checked = false;
            else
            {
                Visiable(false, false, true);
            }
        }

        private void adjacency_matrix()
        {
            matrix = new int[n - 1, n - 1];


               Table.ColumnCount = n;
               Table.RowCount = n;


            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Table[i, i].Style.BackColor = Color.Gray;

                    if (Table[i, j].Value == null)
                        Table[i, j].Value = 0;
                    if (j == 0)
                    {
                        Table[i, j].Value = i;
                        Table[i, j].ReadOnly = true;
                    }
                    if (i == 0)
                    {
                        Table[i, j].Value = j;
                        Table[i, j].ReadOnly = true;
                    }
                    Table[i, i].ReadOnly = true;
                }
            Copy();
        }

        void Copy()
        {
            for (int i = 1; i < n; i++)
                for (int j = 1; j < n; j++)
                {
                    matrix[i - 1, j - 1] = int.Parse(Table[i, j].Value.ToString());
                }
        }
        private void TabControl_Selected(object sender, EventArgs e)
        {
                    Copy();
              bmp = new Bitmap(660, 372);
             graf = Graphics.FromImage(bmp);

             Draw_graf();
        }

        private void plus_Click(object sender, EventArgs e)
        {
            Clear_tlist();
            n++;
            adjacency_matrix();

            Random ran = new Random();
            int ex=0;
            int ey=0;

            for (int j = 0; j < 1; j++)
            {
                ex = ran.Next(50,600);
                ey = ran.Next(70,300);

                for (int i = 0; i < x.Count; i++)
                {
                    if (Math.Sqrt(Math.Pow((ex - x[i]), 2) + Math.Pow((ey - y[i]), 2)) < 50)
                    {
                        j = -1;
                        break;
                    }
                }
            }
            x.Add(ex);
            y.Add(ey);
        }

        private void minus_Click(object sender, EventArgs e)
        {
            Clear_tlist();
            for (int i=0;i<n;i++)
                for (int j = 0; j < n; j++)
                {
                    if (Table[i, j].Selected)
                    {
                        if (i == j)
                        {
                            Remove_top(i-1);
                            x.RemoveAt(i-1);
                            y.RemoveAt(i-1);
                        }
                    }
                }

        }
      
     
        private void save_Click(object sender, EventArgs e)
        {
            string way = "";
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.Cancel)
                    return;
              
                way = sfd.FileName;           
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Произошла ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Dll.XML xml = new XML();
            xml.n = n-1;
            for (int i = 0; i < n-1; i++)
            {
                xml.X.Add(x[i]);
                xml.Y.Add(y[i]);

                for(int j=0;j<n-1;j++)
                {
                    xml.M.Add(matrix[i, j]);
                }
            }
            using (FileStream fs = new FileStream(way, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Dll.XML));
                serializer.Serialize(fs,xml);
            }

            
            MessageBox.Show("Файл сохранен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void open_Click(object sender, EventArgs e)
        {
            Clear_tlist();
            string way = "";
            try
            {
               
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.Cancel)
                    return;

                way = ofd.FileName;
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Произошла ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Dll.XML));
            StreamReader sr = new StreamReader(way);
            Dll.XML file = (XML)serializer.Deserialize(sr);

            n = file.n;

            x.Clear();
            y.Clear();

            matrix = new int[n, n];

            int k = 0;
            for (int i = 0; i < n; i++)
            {
                x.Add(file.X[i]);
                y.Add(file.Y[i]);

                for (int j = 0; j < n; j++)
                {            
                    matrix[i, j] = file.M[k];
                    k++;
                }
            }
            n++;
            Cope_in_table();
            Draw_graf();
        }

        private void Table_MouseClick(object sender, MouseEventArgs e)
        {
            int ei = -1;
            int ej = -1;

            for (int i=0;i<n;i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Table[i, j].Selected && ei == -1)
                    {                      
                        ei = i;
                        ej = j;
                        i = 0;
                    }
                    if(ei != -1)
                    {
                        if(i==ej || j == ei)
                        Table[j, i].Selected = true;
                    }
                }
            }
        }
        private void start_Click(object sender, EventArgs e)
        {
           // try
            {
                Result.Text = "Максимальный поток = ";
                int s = int.Parse(S.Text) - 1;
                int t = int.Parse(T.Text) - 1;
                ar_1 = new int[matrix.GetLength(1) *3];
                ar_2 = new int[matrix.GetLength(1) *3];

                System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
                myStopwatch.Start();

                switch (comboBox2.Text)
                {
                    case "Алгоритм Форда — Фалкерсона":
                        Result.Text += Dll.MaxFlow.Algorithm_Ford_Falkerson(matrix, s, t, ref ar_1, ref ar_2).ToString();
                        break;
                    case "Алгоритм Эдмондса — Карпа":
                        Result.Text += Dll.MaxFlow.Algorithm_Edmonds_Karp(matrix, s, t).ToString();
                        break;
                    case "Алгоритм Диница":
                        Result.Text += Dll.MaxFlow.Algorithm_Dinitz(matrix, s, t).ToString();
                        break;
                    case "Алгоритм проталкивания предпотока":
                        Result.Text += Dll.MaxFlow.PushRelabel(matrix, s, t).ToString();
                        break;
                    case "Алгоритм Дейкстры":
                        Result.Text = Dll.ShortestDistance.Dijkstra(matrix, s, t).ToString();
                        break;
                    case "Алгоритм Форда-Беллмана":
                        Result.Text = Dll.ShortestDistance.BellmanFord(matrix, s, t).ToString();
                        break;
                }
                myStopwatch.Stop();

                Result.Text += "\r\nВремя выполнения алгоритма = " + myStopwatch.ElapsedTicks.ToString() + "тик.";
                int[] a;
                if (Result.Text[0] == 'М')
                    Dll.MaxFlow.Algorithm_Ford_Falkerson(matrix, s, t, ref ar_1, ref ar_2);
                else if(Result.Text[0] == 'Д')
                { 
                   string way = Dll.ShortestDistance.Dijkstra(matrix, s, t).ToString();
                   way = way.Remove(0,way.IndexOf('ь')+4);
                   a = way.Split(' ').Select(x => int.Parse(x)).ToArray();
                   for(int i=0;i<a.Length-1;i++)
                    {
                        ar_1[i] = a[i]-1;
                        ar_2[i] = a[i + 1]-1;
                    }
                 }
                else if (Result.Text[0] == 'П')
                {
                    return;
                }
            }
          /*  catch(Exception E)
            {
               Result.Clear();
               MessageBox.Show(E.Message, "Произошла ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
                Draw_graf();
            
        }
      
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            n = 1;
            graf.Clear(Color.WhiteSmoke);
            adjacency_matrix();
            x.Clear();
            y.Clear();
            Clear_tlist();
            Draw_graf();
        }
    }
}
