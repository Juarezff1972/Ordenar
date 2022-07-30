using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;


namespace Ordenar
{
    public delegate void EscritaEventHandler(object sender, VetorEventArgs e);
    public delegate void MudarEventHandler(object sender, VetorEventArgs e);

    public partial class Form1 : Form
    {
        private int escritas;

        //private Graphics graph;

        private int[] m_array;
        private int maximo;
        private byte ordem;
        private ArrayItem[] vetor;
        private UserControl[] barras;
        private static byte[] myWaveData;

        SoundPlayer[] myAudio;// = new();

        // Sample rate (Or number of samples in one second)
        private const int SAMPLE_FREQUENCY = 44100;
        // 60 seconds or 1 minute of audio
        private float AUDIO_LENGTH_IN_SECONDS = 1.0f;

        public Form1()
        {
            InitializeComponent();
            ordem = 1;
        }

        /*public ArrayItem ArrayItem
        {
            get => default;
            set
            {
            }
        }*/

        private byte[] createWave(double freq)
        {
            List<Byte> tempBytes = new List<byte>();

            WaveHeader header = new();
            FormatChunk format = new FormatChunk();
            DataChunk data = new DataChunk();


            SineGenerator leftData = new(freq, SAMPLE_FREQUENCY, AUDIO_LENGTH_IN_SECONDS);
            SineGenerator rightData = new(freq, SAMPLE_FREQUENCY, AUDIO_LENGTH_IN_SECONDS);
            data.AddSampleData(leftData.Data, rightData.Data);

            header.FileLength += format.Length() + data.Length();

            tempBytes.AddRange(header.GetBytes());
            tempBytes.AddRange(format.GetBytes());
            tempBytes.AddRange(data.GetBytes());

            myWaveData = tempBytes.ToArray();

            //File.WriteAllBytes("teste"+freq.ToString()+".wav", myWaveData);

            return myWaveData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string x;
            //long t1;
            //long t2;

            pivot1.Maximum = (int)numericUpDown2.Value;
            pivot2.Maximum = (int)numericUpDown2.Value;
            pivot1.Visible = false;
            pivot2.Visible = false;

            x = comboBox1.SelectedItem.ToString();
            //pictureBox1.Refresh();
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
            algo.SetDelay((int)numericUpDown1.Value);
            algo.SetPainel(panel1);
            algo.SetProgress(progressBar1);
            algo.SetPivot(pivot1, 1);
            algo.SetPivot(pivot2, 2);

            button1.Enabled = false;
            button2.Enabled = false;

            escritas = 0;
            label6.Text = "Escritas: " + escritas.ToString();
            label6.Refresh();

            Form1.ActiveForm.Text = x;
            switch (x)
            {
                case "InsertSort":
                    algo.InsertSort();
                    break;

                case "SelectionSort":
                    algo.SelectionSort();
                    break;

                case "InsertSort2":
                    algo.InsertSort2();
                    break;

                case "BinaryInsertionSort":
                    algo.BinaryInsertionSort();
                    break;

                case "MergeSort":
                    algo.MergeSort();
                    break;

                case "BubbleSort":
                    algo.BubbleSort();
                    break;

                case "BubbleSort2":
                    algo.BubbleSort2();
                    break;

                case "BubbleSort3":
                    algo.BubbleSort3();
                    break;

                case "CocktailShakerSort":
                    algo.CocktailShakerSort();
                    break;

                case "GnomeSort":
                    algo.GnomeSort();
                    break;

                case "CombSort":
                    algo.CombSort();
                    break;

                case "OddEvenSort":
                    algo.OddEvenSort();
                    break;

                case "ShellSort":
                    algo.ShellSort();
                    break;

                case "QuickSortLR":
                    algo.QuickSortLR();
                    break;

                case "QuickSortLL":
                    algo.QuickSortLL();
                    break;

                case "QuickSortTernaryLR":
                    algo.QuickSortTernaryLR();
                    break;

                case "QuickSortDualPivot":
                    algo.QuickSortDualPivot();
                    break;

                case "HeapSort":
                    algo.HeapSort();
                    break;

                case "RadixSortMSD":
                    algo.RadixSortMSD();
                    break;

                case "RadixSortLSD":
                    algo.RadixSortLSD();
                    break;

                case "CountingSort":
                    algo.CountingSort();
                    break;

                case "BitonicSort":
                    algo.BitonicSort();
                    break;

                case "SlowSort":
                    algo.SlowSort();
                    break;

                case "CycleSort":
                    algo.CycleSort();
                    break;

                case "PancakeSort":
                    algo.PancakeSort();
                    break;

                default:
                    break;
            }
            algo.Desmarcar();

            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Resetar();
            //pictureBox1.Refresh();
            panel1.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string x;
            x = comboBox1.SelectedItem.ToString();
            qsPivotSel1.Visible = false;
            if (x.StartsWith("Quick"))
            {
                qsPivotSel1.Visible = true;
                qsPivotSel1.SelectedIndex = 0;
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
            this.FormBorderStyle = FormBorderStyle.Sizable;
            Resetar();

            //pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
            comboBox1.SelectedIndex = 0;
        }

        private void Form1_Resize(Object sender, EventArgs e)
        {
            //pictureBox1.Refresh();
            panel1.Refresh();
        }

        private void Form1_ResizeEnd(object sender, System.EventArgs e)
        {
            //pictureBox1.Refresh();
            int i;
            if (m_array != null)
            {
                for (i = 0; i < m_array.Length; i++)
                {
                    vetor[i].Mudou = true;
                }
            }

            panel1.Refresh();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void qsPivotSel1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ordem = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ordem = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ordem = 3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            ordem = 4;
        }

        public virtual void OnEscreveu(object sender, VetorEventArgs e)
        {
            double freq;
            freq = 55.0 * Math.Pow(2.0, (100.0 * e.valor / (m_array.Length - 1.0)) / 12.0);

            vetor[e.indice].WaveData = createWave(freq);
            ContaEscrita();
        }

        public virtual void OnMudar(object sender, VetorEventArgs e)
        {
            //Console.Out.WriteLine(e.ToString());

            if (barras == null) return;
            decimal ratio = (decimal)(panel1.Height - 1) / (decimal)maximo;
            float itens = panel1.Width / (float)m_array.Length;
            int tam;
            int i = e.indice;
            if (barras[i] != null)
            {
                //Audio myAudio = new();
                tam = (int)Math.Round(ratio * vetor[i].Valor);
                barras[i].Top = panel1.Height - tam;
                barras[i].Height = tam;
                barras[i].Left = (int)(i * itens);
                barras[i].Width = (int)itens;
                barras[i].BackColor = vetor[i].GetColor(1);
                barras[i].ForeColor = vetor[i].GetColor(2);
                barras[i].Refresh();
                if (checkBox1.Checked)
                {
                    if (AUDIO_LENGTH_IN_SECONDS > 0)
                    {
                        //Stream s = new MemoryStream(vetor[i].WaveData);
                        //SoundPlayer sp = new();
                        myAudio[i].Stream = new MemoryStream(vetor[i].WaveData);
                        myAudio[i].Play();

                        //myAudio[i].Play(vetor[i].WaveData, AudioPlayMode.Background);
                    }
                }
            }
        }

        private void Resetar()
        {
            int nums = (int)numericUpDown2.Value;
            int i;

            escritas = 0;
            label6.Text = "Escritas: " + escritas.ToString();
            label6.Refresh();

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
                int max = m_array.Max();
                double ang;
                for (i = 0; i < m_array.Length; i++)
                {
                    ang = ((float)m_array[i] / max) * Math.PI * 2;
                    m_array[i] = (int)Math.Round((Math.Sin(ang) * max / 2) + (max / 2));
                }
            }
            maximo = m_array.Max();

            vetor = new ArrayItem[m_array.Length];
            vetor.Initialize();

            myAudio = new SoundPlayer[m_array.Length];

            if (barras != null)
            {
                for (i = 0; i < barras.Length; i++)
                {
                    panel1.Controls.Remove(barras[i]);
                }
            }

            barras = new UserControl[m_array.Length];
            float itens = panel1.Width / (float)m_array.Length;

            decimal ratio = (decimal)(panel1.Height - 1) / (decimal)maximo;
            int tam;

            for (i = 0; i < vetor.Length; i++)
            {
                myAudio[i] = new();
                EscritaEventHandler d1 = new EscritaEventHandler(OnEscreveu);
                MudarEventHandler d2 = new MudarEventHandler(OnMudar);

                vetor[i] = new ArrayItem
                {
                    //Marca = false,

                    Indice = i
                };
                vetor[i].Escreveu += d1;
                vetor[i].Mudar += d2;
                vetor[i].Valor = m_array[i];
                vetor[i].SetColorIDX(0);
                double freq;
                freq = 55.0 * Math.Pow(2.0, (100.0 * m_array[i] / (m_array.Length - 1.0)) / 12.0);
                vetor[i].WaveData = createWave(freq); //m_array[i] * 50
                //Console.Beep((int)(55 * Math.Pow(2, m_array[i] / 12)), 500);
                tam = (int)Math.Round(ratio * m_array[i]);
                barras[i] = new UserControl
                {
                    Left = (int)(i * itens),
                    Width = (int)itens,
                    Top = panel1.Height - tam,
                    Height = tam,
                    BackColor = Color.Blue,
                    BorderStyle = BorderStyle.FixedSingle,
                    ForeColor = Color.Red
                };
                panel1.Controls.Add(barras[i]);
            }

            ArrayItem zzz = vetor.Max();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            AUDIO_LENGTH_IN_SECONDS = 0.1f * (float)numericUpDown1.Value;
        }
    }
}