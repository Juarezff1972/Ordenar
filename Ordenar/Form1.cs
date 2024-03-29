﻿using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;


namespace Ordenar
{
    public delegate void EscritaEventHandler(object sender, VetorEventArgs e);
    public delegate void MudarEventHandler(object sender, VetorEventArgs e);
    public delegate void LerEventHandler(object sender, VetorEventArgs e);
    public delegate void AuxEventHandler(object sender, VetorAuxEventArgs e);

    public partial class Form1 : Form
    {
        const string BINARYINSERTIONSORT = "BinaryInsertionSort";
        const string BITONICSORT = "BitonicSort";
        const string BUBBLESORT = "BubbleSort";
        const string BUBBLESORT2 = "BubbleSort2";
        const string BUBBLESORT3 = "BubbleSort3";
        const string COCKTAILSHAKERSORT = "CocktailShakerSort";
        const string COMBSORT = "CombSort";
        const string COUNTINGSORT = "CountingSort";
        const string CYCLESORT = "CycleSort";
        const string FLASHSORT = "FlashSort";
        const string GNOMESORT = "GnomeSort";
        const string GRAVITYSORT = "GravitySort";
        const string HEAPSORT = "HeapSort";
        const string INSERTSORT = "InsertSort";
        const string INSERTSORT2 = "InsertSort2";
        const string MERGESORT = "MergeSort";
        const string ODDEVENSORT = "OddEvenSort";
        const string PANCAKESORT = "PancakeSort";
        const string PIGEONHOLESORT = "PigeonHoleSort";
        const string QUICKSORTDUALPIVOT = "QuickSortDualPivot";
        const string QUICKSORTLL = "QuickSortLL";
        const string QUICKSORTLR = "QuickSortLR";
        const string QUICKSORTTERNARYLR = "QuickSortTernaryLR";
        const string RADIXSORTLSD = "RadixSortLSD";
        const string RADIXSORTMSD = "RadixSortMSD";
        const string SELECTIONSORT = "SelectionSort";
        const string SHELLSORT = "ShellSort";
        const string SLOWSORT = "SlowSort";
        const string TOURNAMENTSORT = "TournamentSort";
        const string AMERICANSORT = "AmericanFlagSort";
        const string SIMPLISTICGRAVITYSORT = "SimplisticGravitySort";
        const string SANDPAPERSORT = "SandpaperSort";
        const string DIAMONDSORT = "DiamondSort";

        const string GRAFICO_NENHUM = "Nenhum";
        const string GRAFICO_LINHA = "Gráfico de Linha";
        const string GRAFICO_CURVA = "Gráfico de Curva";

        private int escritas;

        private PointF[] points;
        private long[] auxVetor;
        private int maxPoint = 0;
        //Graphics auxGr;
        //GraphicsState auxGrState;

        private int[] m_array;
        private int maximo;
        private byte ordem;
        private ArrayItem[] vetor;
        private VisualControl[] barras;

        private bool fim;

        public Form1()
        {
            InitializeComponent();
            //auxGr = AuxVetor1.CreateGraphics();

            fim = false;
            ordem = 1;

            tipoVisual2.Items.Clear();
            tipoVisual2.Items.Add(GRAFICO_NENHUM);
            tipoVisual2.Items.Add(GRAFICO_LINHA);
            tipoVisual2.Items.Add(GRAFICO_CURVA);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string x;

            pivot1.Maximum = (int)numericUpDown2.Value;
            pivot2.Maximum = (int)numericUpDown2.Value;
            pivot1.Visible = false;
            pivot2.Visible = false;

            AuxEventHandler d = new AuxEventHandler(OnAuxVetor);

            x = comboBox1.SelectedItem.ToString();
            Algoritmos algo;
            algo = new Algoritmos();
            algo.SetLabel(1, label3);
            algo.SetLabel(2, label4);
            algo.SetLabel(3, label5);
            algo.SetLabel(4, label8);
            algo.SetLabel(5, label10);
            algo.SetVetor(vetor);
            algo.SetQuickSortPivot(qsPivotSel1.Text);
            algo.LimpaTXT();
            algo.SetDelay((int)Math.Pow(2, (int)numericUpDown1.Value));
            //algo.SetPictureBox(area1);
            algo.SetProgress(progressBar1);
            algo.SetPivot(pivot1, 1);
            algo.SetPivot(pivot2, 2);
            algo.auxVetor += d;

            button1.Enabled = false;
            button2.Enabled = false;

            escritas = 0;
            label6.Text = "Escritas: " + escritas.ToString();
            label6.Refresh();

            Form1.ActiveForm.Text = x;
            switch (x)
            {
                case INSERTSORT:
                    algo.InsertSort();
                    break;

                case SELECTIONSORT:
                    algo.SelectionSort();
                    break;

                case INSERTSORT2:
                    algo.InsertSort2();
                    break;

                case BINARYINSERTIONSORT:
                    algo.BinaryInsertionSort();
                    break;

                case MERGESORT:
                    algo.MergeSort();
                    break;

                case BUBBLESORT:
                    algo.BubbleSort();
                    break;

                case BUBBLESORT2:
                    algo.BubbleSort2();
                    break;

                case BUBBLESORT3:
                    algo.BubbleSort3();
                    break;

                case COCKTAILSHAKERSORT:
                    algo.CocktailShakerSort();
                    break;

                case GNOMESORT:
                    algo.GnomeSort();
                    break;

                case COMBSORT:
                    algo.CombSort();
                    break;

                case ODDEVENSORT:
                    algo.OddEvenSort();
                    break;

                case SHELLSORT:
                    algo.ShellSort();
                    break;

                case QUICKSORTLR:
                    algo.QuickSortLR();
                    break;

                case QUICKSORTLL:
                    algo.QuickSortLL();
                    break;

                case QUICKSORTTERNARYLR:
                    algo.QuickSortTernaryLR();
                    break;

                case QUICKSORTDUALPIVOT:
                    algo.QuickSortDualPivot();
                    break;

                case HEAPSORT:
                    algo.HeapSort();
                    break;

                case RADIXSORTMSD:
                    algo.RadixSortMSD();
                    break;

                case RADIXSORTLSD:
                    algo.RadixSortLSD();
                    break;

                case COUNTINGSORT:
                    algo.CountingSort();
                    break;

                case BITONICSORT:
                    algo.BitonicSort();
                    break;

                case SLOWSORT:
                    algo.SlowSort();
                    break;

                case CYCLESORT:
                    algo.CycleSort();
                    break;

                case PANCAKESORT:
                    algo.PancakeSort();
                    break;

                case GRAVITYSORT:
                    algo.GravitySort();
                    break;

                case FLASHSORT:
                    algo.FlashSort();
                    break;

                case PIGEONHOLESORT:
                    algo.pigeonholeSort();
                    break;

                case TOURNAMENTSORT:
                    algo.tournamentSort();
                    break;

                case AMERICANSORT:
                    algo.AmericanSort();
                    break;

                case SIMPLISTICGRAVITYSORT:
                    algo.SimplisticGravitySort();
                    break;

                case SANDPAPERSORT:
                    algo.SandpaperSort();
                    break;

                case DIAMONDSORT:
                    algo.DiamondSort();
                    break;

                default:
                    break;
            }
            fim = true;
            algo.Desmarcar();
            fim = false;

            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            auxVetor = null;
            AuxVetor1.Refresh();
            Resetar();
            area1.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string x;
            x = comboBox1.SelectedItem.ToString();
            qsPivotSel1.Visible = false;
            if (x.StartsWith("Quick"))
            {
                qsPivotSel1.Visible = true;
                qsPivotSel1.SelectedIndex = 2;
            }
        }

        private void ContaEscrita()
        {
            escritas++;
            label6.Text = "Escritas: " + escritas.ToString();
            label6.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.Add(BINARYINSERTIONSORT);
            this.comboBox1.Items.Add(BITONICSORT);
            this.comboBox1.Items.Add(BUBBLESORT);
            this.comboBox1.Items.Add(BUBBLESORT2);
            this.comboBox1.Items.Add(BUBBLESORT3);
            this.comboBox1.Items.Add(COCKTAILSHAKERSORT);
            this.comboBox1.Items.Add(COMBSORT);
            this.comboBox1.Items.Add(COUNTINGSORT);
            this.comboBox1.Items.Add(CYCLESORT);
            this.comboBox1.Items.Add(FLASHSORT);
            this.comboBox1.Items.Add(GNOMESORT);
            this.comboBox1.Items.Add(GRAVITYSORT);
            this.comboBox1.Items.Add(HEAPSORT);
            this.comboBox1.Items.Add(INSERTSORT);
            this.comboBox1.Items.Add(INSERTSORT2);
            this.comboBox1.Items.Add(MERGESORT);
            this.comboBox1.Items.Add(ODDEVENSORT);
            this.comboBox1.Items.Add(PANCAKESORT);
            this.comboBox1.Items.Add(PIGEONHOLESORT);
            this.comboBox1.Items.Add(QUICKSORTDUALPIVOT);
            this.comboBox1.Items.Add(QUICKSORTLL);
            this.comboBox1.Items.Add(QUICKSORTLR);
            this.comboBox1.Items.Add(QUICKSORTTERNARYLR);
            this.comboBox1.Items.Add(RADIXSORTLSD);
            this.comboBox1.Items.Add(RADIXSORTMSD);
            this.comboBox1.Items.Add(SELECTIONSORT);
            this.comboBox1.Items.Add(SHELLSORT);
            this.comboBox1.Items.Add(SLOWSORT);
            this.comboBox1.Items.Add(TOURNAMENTSORT);
            this.comboBox1.Items.Add(AMERICANSORT);
            this.comboBox1.Items.Add(SIMPLISTICGRAVITYSORT);
            this.comboBox1.Items.Add(SANDPAPERSORT);
            this.comboBox1.Items.Add(DIAMONDSORT);
            this.comboBox1.Sorted = true;

            this.FormBorderStyle = FormBorderStyle.Sizable;
            Resetar();
            comboBox1.SelectedIndex = 0;
        }

        private void Form1_Resize(Object sender, EventArgs e)
        {
            area1.Refresh();
        }

        private void Form1_ResizeEnd(object sender, System.EventArgs e)
        {
            int i;
            if (m_array != null)
            {
                for (i = 0; i < m_array.Length; i++)
                {
                    vetor[i].Mudou = true;
                }
            }

            area1.Refresh();
        }

        private void qsPivotSel1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ordemInicial_SelectedIndexChanged(object sender, EventArgs e)
        {
            ordem = (byte)(ordemInicial.SelectedIndex + 1);
        }

        public virtual void OnAuxVetor(object sender, VetorAuxEventArgs e)
        {
            auxVetor = e.vetor;
            AuxVetor1.Refresh();
        }

        public virtual void OnEscreveu(object sender, VetorEventArgs e)
        {
            ContaEscrita();
        }

        public virtual void OnLer(object sender, VetorEventArgs e)
        {

        }

        private void Pausa()
        {
            int delay = (int)Math.Pow(2, (int)numericUpDown1.Value);
            if (fim) delay = 1;
            switch (delay)
            {
                case 0:
                    //return;
                    break;
                case 1:
                    //ChecaSegmentos();
                    area1.Refresh();
                    break;
                default:
                    area1.Refresh();
                    //ChecaSegmentos();
                    System.Threading.Thread.Sleep(delay);
                    break;
            }
        }

        public virtual void OnMudar(object sender, VetorEventArgs e)
        {

            if (barras == null) return;
            decimal ratio = (decimal)(area1.Height - 1) / (decimal)maximo;
            float itens = area1.Width / (float)m_array.Length;
            int tam;
            int i = e.indice;
            if (barras[i] != null)
            {
                tam = (int)Math.Round(ratio * vetor[i].Valor);
                barras[i].Top = area1.Height - tam;
                barras[i].Altura = tam;
                barras[i].Left = (int)(i * itens);
                barras[i].Largura = (int)itens;
                barras[i].CorFundo = vetor[i].GetColor(1);
                barras[i].CorFrente = vetor[i].GetColor(2);
                barras[i].txt = vetor[i].Valor.ToString();
                if (maxPoint < barras[i].Top) maxPoint = barras[i].Top;
                if (tipoVisual.Text == "Bolas")
                {
                    points[i] = new PointF(barras[i].Left + (barras[i].Largura / 2), barras[i].Top + (barras[i].Largura / 2));
                }
                else
                {
                    points[i] = new PointF(barras[i].Left + (barras[i].Largura / 2), barras[i].Top);
                }
                Pausa();
            }
        }

        private void Resetar()
        {
            int nums = (int)numericUpDown2.Value;
            int i;
            int j;
            int k;
            int max;
            Form3 f;

            //auxGr.Clear(Color.DarkGray);
            f = new Form3();

            area1.CreateGraphics().Clear(area1.BackColor);

            escritas = 0;
            label6.Text = "Escritas: " + escritas.ToString();
            label6.Refresh();
            f.Show();
            m_array = Enumerable.Range(1, nums).ToArray();
            if (ordem == 3)
            {
                m_array = m_array.Reverse().ToArray();
            }
            if (ordem == 1)
            {
                Random rnd = new();
                m_array = m_array.OrderBy(c => rnd.Next()).ToArray();
            }
            if (ordem == 4)
            {
                max = m_array.Max();
                f.max = m_array.Length;
                double ang;
                for (i = 0; i < m_array.Length; i++)
                {
                    ang = ((float)m_array[i] / max) * Math.PI * 2;
                    m_array[i] = (int)Math.Round((Math.Sin(ang) * max / 2) + (max / 2));
                    f.pb = i;
                }
            }
            if (ordem == 5)
            {
                max = m_array.Max();
                f.max = m_array.Length;
                double ang;
                for (i = 0; i < m_array.Length; i++)
                {
                    ang = ((float)m_array[i] / max) * Math.PI * 2;
                    m_array[i] = (int)Math.Round((Math.Cos(ang) * max / 2) + (max / 2));
                    f.pb = i;
                }
            }
            if (ordem == 6)
            {
                max = m_array.Max();
                i = 0;
                j = m_array.Length - 1;
                k = max;
                f.max = j;
                while (i < j)
                {
                    m_array[i] = max - k + 1;
                    m_array[j] = (max - k) + 2;
                    i++;
                    j--;
                    k -= 2;
                    f.pb = i;
                }

            }
            maximo = m_array.Max();

            vetor = new ArrayItem[m_array.Length];
            vetor.Initialize();

            area1.Refresh();

            barras = new VisualControl[m_array.Length];
            float itens = area1.Width / (float)m_array.Length;

            decimal ratio = (decimal)(area1.Height - 1) / (decimal)maximo;
            int tam;

            int l1;
            l1 = vetor.Length;

            points = new PointF[l1];
            f.max = l1;
            for (i = 0; i < l1; i++)
            {
                vetor[i] = new ArrayItem
                {
                    Indice = i,
                    Valor = m_array[i]
                };
                //vetor[i].Valor = m_array[i];
                vetor[i].SetColorIDX(0);


                tam = (int)Math.Round(ratio * m_array[i]);
                byte m = 0;
                if (tipoVisual.Text == "Barras") m = VisualControl.BARRA;
                if (tipoVisual.Text == "Bolas") m = VisualControl.BOLA;
                if (tipoVisual.Text == "Linhas Verticais") m = VisualControl.LINHA;
                if (tipoVisual.Text == "Triângulo") m = VisualControl.TRIANGULO;
                barras[i] = new VisualControl
                {
                    Left = (int)(i * itens),
                    Largura = (int)itens,
                    Top = area1.Height - tam,
                    Altura = tam,
                    modo = m,
                    CorFundo = Color.Blue,
                    CorFrente = Color.Red,
                    txt = m_array[i].ToString(),
                };

                EscritaEventHandler d1 = new EscritaEventHandler(OnEscreveu);
                MudarEventHandler d2 = new MudarEventHandler(OnMudar);
                LerEventHandler d3 = new LerEventHandler(OnLer);

                vetor[i].Escreveu += d1;
                vetor[i].Mudar += d2;
                vetor[i].Ler += d3;

                if (maxPoint < barras[i].Top) maxPoint = barras[i].Top;

                switch (tipoVisual.Text)
                {
                    case "Barras":
                        points[i] = new PointF(barras[i].Left + (barras[i].Largura / 2), barras[i].Top);
                        break;
                    case "Bolas":
                        points[i] = new PointF(barras[i].Left + (barras[i].Largura / 2), barras[i].Top + (barras[i].Largura / 2));
                        break;
                    case "Linhas Verticais":
                        points[i] = new PointF(barras[i].Left + (barras[i].Largura / 2), barras[i].Top);
                        break;
                    case "Triângulo":
                        points[i] = new PointF(barras[i].Left + (barras[i].Largura / 2), barras[i].Top);
                        break;
                    case "Espiral":
                        points[i] = new PointF(barras[i].Left + (barras[i].Largura / 2), barras[i].Top);
                        break;

                }
                f.pb = i;
            }

            ArrayItem zzz = vetor.Max();
            f.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //AUDIO_LENGTH_IN_SECONDS = (float)numericUpDown1.Value / 2;
        }

        private void grafico(PaintEventArgs e)
        {
            Pen pen;
            switch (tipoVisual2.Text)
            {
                case GRAFICO_LINHA:
                    pen = new(Color.White)
                    {
                        Width = 1
                    };

                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);

                    pen.DashCap = DashCap.Triangle;
                    pen.CustomEndCap = bigArrow;
                    pen.CustomStartCap = bigArrow;
                    //pen.LineJoin = LineJoin.Round;
                    pen.DashStyle = DashStyle.Solid;
                    //pen.EndCap = LineCap.DiamondAnchor;
                    //pen.StartCap=LineCap.DiamondAnchor;

                    if (points != null) e.Graphics.DrawLines(pen, points);

                    break;
                case GRAFICO_CURVA:
                    pen = new(Color.White)
                    {
                        Width = 1
                    };

                    if (points != null) e.Graphics.DrawCurve(pen, points);

                    break;
                default:
                    break;
            }
        }

        private void area1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen;
            int max;
            int i;
            int l;
            double pr;
            double pr1;
            double pa;
            double pa1;
            double px;
            double px1;
            double px2;
            double apx;
            double py;
            double py1;
            double py2;
            double apy;
            double ag1;
            double ag2;
            //int p;
            //double p1;
            Brush b;
            int rw;
            int rh;
            Pen _pen1;
            Brush _brush1;
            Brush _brush2;
            Brush _brushtxt;
            float itens;
            Font font;
            PointF[] p;

            rw = e.ClipRectangle.Width;
            rh = e.ClipRectangle.Height;

            switch (tipoVisual.Text)
            {
                case "Barras":
                    if (points != null)
                    {
                        l = points.Length;
                        itens = rw / l;
                        //SetStyle(ControlStyles.Opaque, false);

                        rw = (int)itens - 2;
                        apx = rw / 2;

                        rh = e.ClipRectangle.Height;
                        font = new(FontFamily.GenericSerif, itens / 2);
                        _brushtxt = new SolidBrush(Color.White);

                        for (i = 0; i < l; i++)
                        {
                            _brush1 = new SolidBrush(barras[i].CorFrente);
                            _pen1 = new Pen(_brush1);
                            _brush2 = new SolidBrush(barras[i].CorFundo);
                            /*pen = new(barras[i].CorFrente);
                            {
                                Width = 1;
                            };*/
                            px = (double)points[i].X;
                            py = (double)points[i].Y;
                            e.Graphics.FillRectangle(_brush2, (float)(px - apx), (float)py, (float)(rw), (float)rh);
                            e.Graphics.DrawRectangle(_pen1, (float)(px - apx), (float)py, (float)(rw), (float)rh);
                            if (itens >= 16) e.Graphics.DrawString(barras[i].txt, font, _brushtxt, (float)(px-apx), (float)py);
                        }
                        grafico(e);
                    }
                    break;
                case "Linhas Verticais":
                    if (points != null)
                    {
                        l = points.Length;
                        for (i = 0; i < l; i++)
                        {
                            pen = new(barras[i].CorFundo);
                            {
                                Width = 1;
                            };
                            px = (double)points[i].X;
                            py = (double)points[i].Y;
                            e.Graphics.DrawLine(pen, (float)px, (float)py, (float)px, (float)rh);
                        }
                        grafico(e);
                    }
                    break;
                case "Bolas":
                    if (points != null)
                    {
                        l = points.Length;
                        itens = rw / l;

                        rw = (int)itens - 2;
                        rh = e.ClipRectangle.Height;
                        font = new(FontFamily.GenericSerif, itens/2);
                        _brushtxt = new SolidBrush(Color.White);

                        for (i = 0; i < l; i++)
                        {
                            pen = new(barras[i].CorFundo);
                            {
                                Width = 1;
                            };
                            px = (double)points[i].X - rw / 2;
                            py = (double)points[i].Y - rw / 2;
                            //SetStyle(ControlStyles.Opaque, false);
                            _brush1 = new SolidBrush(barras[i].CorFrente);
                            _pen1 = new Pen(_brush1);
                            _brush2 = new SolidBrush(barras[i].CorFundo);
                            e.Graphics.FillEllipse(_brush2, (float)px, (float)py, rw, rw);
                            e.Graphics.DrawEllipse(_pen1, (float)px, (float)py, rw, rw);
                            if (itens >= 16) e.Graphics.DrawString(barras[i].txt, font, _brushtxt, (float)px, (float)py);
                        }
                        grafico(e);
                    }
                    break;
                case "Triângulo":
                    if (points != null)
                    {
                        l = points.Length;
                        itens = rw / l;

                        rw = (int)itens - 2;
                        rh = e.ClipRectangle.Height;
                        font = new(FontFamily.GenericSerif, itens / 2);

                        for (i = 0; i < l; i++)
                        {
                            pen = new(barras[i].CorFundo);
                            {
                                Width = 1;
                            };
                            px = (double)points[i].X;// - rw / 2;
                            py = (double)points[i].Y;// - rw / 2;
                            //SetStyle(ControlStyles.Opaque, false);
                            _brush1 = new SolidBrush(barras[i].CorFrente);
                            _pen1 = new Pen(_brush1);
                            _brush2 = new SolidBrush(barras[i].CorFundo);
                            p = new PointF[3];
                            apx = rw / 3;
                            apy = rw / 2;
                            p[0].X = (float)px;
                            p[0].Y = (float)py;
                            p[1].X = (float)px - (float)apx;
                            p[1].Y = (float)py + (float)apy;
                            p[2].X = (float)px + (float)apx;
                            p[2].Y = (float)py + (float)apy;
                            e.Graphics.FillPolygon(_brush2, p);
                            e.Graphics.DrawPolygon(_pen1, p);
                        }
                        grafico(e);
                    }
                    break;
                case "Espiral":
                    if (points != null)
                    {
                        max = (int)numericUpDown2.Value;
                        l = points.Length;
                        apx = 0;
                        apy = 0;
                        pa1 = 0;
                        pr1 = 0;
                        rw = e.ClipRectangle.Width / 2;
                        rh = e.ClipRectangle.Height / 2;
                        for (i = 0; i < l; i++)
                        {
                            pa = ((double)i / (double)max) * 2.0 * Math.PI;
                            pr = (double)points[i].Y / 2.0;

                            //e.ClipRectangle.X
                            px = rw + pr * Math.Cos(pa); // calculate x-coordinate
                            py = rh + pr * Math.Sin(pa); // calculate y-coordinate
                            pen = new(barras[i].CorFundo);
                            {
                                Width = 1;
                            };
                            if (tipoVisual2.Text == GRAFICO_LINHA)
                            {
                                if (i > 0)
                                {
                                    e.Graphics.DrawLine(pen, (float)apx, (float)apy, (float)px, (float)py);
                                }
                                apx = px;
                                apy = py;
                            }
                            if (tipoVisual2.Text == GRAFICO_CURVA)
                            {
                                if (i == 0)
                                {
                                    pa1 = pa;
                                    pr1 = pr;
                                }
                                if (i > 0)
                                {
                                    pr1 = (pr + pr1) / 2;
                                    ag1 = (pa + pa1) / 2;
                                    ag2 = (ag1 + pa) / 2;
                                    px1 = rw + pr1 * Math.Cos(ag1);
                                    py1 = rh + pr1 * Math.Sin(ag1);
                                    px2 = rw + pr1 * Math.Cos(ag2);
                                    py2 = rh + pr1 * Math.Sin(ag2);

                                    e.Graphics.DrawBezier(pen, (float)apx, (float)apy, (float)px1, (float)py1, (float)px2, (float)py2, (float)px, (float)py);
                                }
                                apx = px;
                                apy = py;
                                pa1 = pa;
                                pr1 = pr;
                            }

                            b = new SolidBrush(barras[i].CorFrente);
                            e.Graphics.FillEllipse(b, (float)px - 2, (float)py - 2, 5, 5);
                            e.Graphics.DrawEllipse(pen, (float)px - 2, (float)py - 2, 6, 6);
                        }
                    }
                    break;
                default:
                    grafico(e);

                    break;
            }
        }

        private void AuxVetor1_Paint(object sender, PaintEventArgs e)
        {
            if (auxVetor != null)
            {
                e.Graphics.Clear(AuxVetor1.BackColor);
                //int min = auxVetor.Min();
                long max = auxVetor.Max();
                int l = auxVetor.Length;
                int i;
                int t;
                Pen p;// = new Pen(Color.White);
                int y;
                int w;
                w = AuxVetor1.Height / l;//5;
                //Debug.WriteLine("w=" + w.ToString() + " | " + l.ToString() + " | " + AuxVetor1.Height);
                for (i = 0; i < l; i++)
                {
                    double m = i / (double)l;
                    Algoritmos.ColorRGB c = Algoritmos.HSL2RGB(m, 0.5, 0.5);
                    Color cc = Color.FromArgb(c.R, c.G, c.B);
                    p = new Pen(cc);
                    p.Width = w;
                    t = (int)(((float)auxVetor[i] / (float)max) * (float)(AuxVetor1.Width - 10));
                    if (t < 0) t = 0;
                    y = (int)(((float)i / (float)l) * (float)(AuxVetor1.Height)) + w / 2;
                    if (y < 0) y = 0;
                    try
                    {
                        e.Graphics.DrawLine(p, 0, y, t, y);
                    }
                    catch (OverflowException)
                    {
                        //Debug.WriteLine("Exception: p={0} / y={1} / t={2}.", p, y, t);
                    }

                    //Debug.WriteLine(t.ToString() + " | " + i.ToString() + " - " + y.ToString());
                }
            }
            else
            {
                e.Graphics.Clear(AuxVetor1.BackColor);
            }
        }

        private void AuxVetor1_Resize(object sender, EventArgs e)
        {
            AuxVetor1.CreateGraphics().Clear(AuxVetor1.BackColor);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f;
            string x;
            x = comboBox1.SelectedItem.ToString();
            f = new Form2();
            //Form2.ActiveForm.Load();
            f.Show();
            f.txt = "Ainda não implementado";
            if (x != null)
            {
                switch (x)
                {
                    case AMERICANSORT:
                        f.txt = Resource1.AmericanSortString;
                        return;
                    case BINARYINSERTIONSORT:
                        f.txt = Resource1.BinaryInsertionSortString;
                        return;
                    case BITONICSORT:
                        f.txt = Resource1.BitonicSortString;
                        return;
                    case BUBBLESORT:
                        f.txt = Resource1.BubbleSortString;
                        return;
                    case BUBBLESORT2:
                        f.txt = Resource1.BubbleSort2String;
                        return;
                    case BUBBLESORT3:
                        f.txt = Resource1.BubbleSort3String;
                        return;
                    case COCKTAILSHAKERSORT:
                        f.txt = Resource1.CocktailShakerSortString;
                        return;
                    case COMBSORT:
                        f.txt = Resource1.CombSortString;
                        return;
                    case COUNTINGSORT:
                        f.txt = Resource1.CountingSortString;
                        return;
                    case CYCLESORT:
                        f.txt = Resource1.CycleSortString;
                        return;
                    case DIAMONDSORT:
                        f.txt = Resource1.DiamondSortString;
                        return;
                    case FLASHSORT:
                        f.txt = Resource1.FlashSortString;
                        return;
                    case GNOMESORT:
                        f.txt = Resource1.GnomeSortString;
                        return;
                    case GRAVITYSORT:
                        f.txt = Resource1.GravitySortString;
                        return;
                    case HEAPSORT:
                        f.txt = Resource1.HeapSortString;
                        return;
                    case INSERTSORT:
                        f.txt = Resource1.InsertSortString;
                        return;
                    case INSERTSORT2:
                        f.txt = Resource1.InsertSort2String;
                        return;
                    case MERGESORT:
                        f.txt = Resource1.MergeSortString;
                        return;
                    case ODDEVENSORT:
                        f.txt = Resource1.OddEvenSortString;
                        return;
                    case PANCAKESORT:
                        f.txt = Resource1.PancakeSortString;
                        return;
                    case PIGEONHOLESORT:
                        f.txt = Resource1.PigeonHoleSortString;
                        return;
                    case QUICKSORTDUALPIVOT:
                    case QUICKSORTLL:
                    case QUICKSORTLR:
                    case QUICKSORTTERNARYLR:
                        f.txt = Resource1.QuickSortString;
                        return;
                    case RADIXSORTLSD:
                        f.txt = Resource1.RadixSortLSDString;
                        return;
                    case RADIXSORTMSD:
                        f.txt = Resource1.RadixSortMSDString;
                        return;
                    case SANDPAPERSORT:
                        f.txt = Resource1.SandpaperSortString;
                        return;
                    case SELECTIONSORT:
                        f.txt = Resource1.SelectionSortString;
                        return;
                    case SHELLSORT:
                        f.txt = Resource1.ShellSortString;
                        return;
                    case SIMPLISTICGRAVITYSORT:
                        f.txt = Resource1.SimplisticGravitySortString;
                        return;
                    case SLOWSORT:
                        f.txt = Resource1.SlowSortString;
                        return;
                    case TOURNAMENTSORT:
                        f.txt = Resource1.TournamentSortString;
                        return;
                }
            }
        }
    }
}