using MultiMedia;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsMediaLib.Defs;


namespace Ordenar
{
    public delegate void EscritaEventHandler(object sender, VetorEventArgs e);
    public delegate void MudarEventHandler(object sender, VetorEventArgs e);

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

        private int escritas;

        //private Graphics graph;

        private int[] m_array;
        private int maximo;
        private byte ordem;
        private ArrayItem[] vetor;
        private VisualControl[] barras;
        //private static byte[] myWaveData;

        private WaveFormatEx m_Format;
        IntPtr[] m_pWave;
        WBuf[] m_Buff;

        //SoundPlayer[] myAudio;// = new();

        // Sample rate (Or number of samples in one second)
        private const int SAMPLE_FREQUENCY = 44100;
        // 60 seconds or 1 minute of audio
        private float AUDIO_LENGTH_IN_SECONDS = 1.0f;

        public Form1()
        {
            InitializeComponent();
            ordem = 1;
            m_Format = new WaveFormatEx();

            m_Format.wFormatTag = 1; // PCM
            m_Format.nChannels = 2; // Stereo
            m_Format.nSamplesPerSec = SAMPLE_FREQUENCY;
            m_Format.wBitsPerSample = 8;
            m_Format.nBlockAlign = (short)(m_Format.nChannels * (m_Format.wBitsPerSample / 8));
            m_Format.nAvgBytesPerSec = m_Format.nSamplesPerSec * m_Format.nBlockAlign;
            m_Format.cbSize = 0;
        }

        /*public ArrayItem ArrayItem
        {
            get => default;
            set
            {
            }
        }*/

        /*private byte[] createWave(double freq)
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
        }*/

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
            algo.Desmarcar();

            button1.Enabled = true;
            button2.Enabled = true;
            int iRet;
            for (int i = 0; i < m_array.Length; i++)
            {
                iRet = waveOut.Close(m_pWave[i]);
                Console.WriteLine(iRet);
            }
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



        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            ordem = 5;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            ordem = 6;
        }

        public virtual void OnEscreveu(object sender, VetorEventArgs e)
        {
            if (checkBox1.Checked)
            {
                double freq;
                freq = 55.0 * Math.Pow(2.0, (100.0 * e.valor / (m_array.Length - 1.0)) / 12.0);
                if (vetor[e.indice].MyBuf == null) vetor[e.indice].MyBuf = new WBuf(m_pWave[e.indice], m_Format.nSamplesPerSec * (int)Math.Ceiling(AUDIO_LENGTH_IN_SECONDS * 10) * m_Format.nBlockAlign);
                int iSize = vetor[e.indice].MyBuf.GenerateLa(m_Format, (int)AUDIO_LENGTH_IN_SECONDS, (int)freq);
                vetor[e.indice].waveSize = iSize;
            }

            //vetor[e.indice].WaveData = createWave(freq);

            ContaEscrita();
        }

        public virtual void OnMudar(object sender, VetorEventArgs e)
        {
            //Console.Out.WriteLine(e.ToString());
            int iRet;

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
                barras[i].Altura = tam;
                barras[i].Left = (int)(i * itens);
                barras[i].Largura = (int)itens;
                barras[i].CorFundo = vetor[i].GetColor(1);
                barras[i].CorFrente = vetor[i].GetColor(2);
                barras[i].txt = vetor[i].Valor.ToString();
                barras[i].Refresh();
                if (checkBox1.Checked)
                {
                    if (AUDIO_LENGTH_IN_SECONDS > 0)
                    {
                        //Stream s = new MemoryStream(vetor[i].WaveData);
                        //SoundPlayer sp = new();
                        //myAudio[i].Stream = new MemoryStream(vetor[i].WaveData);
                        //myAudio[i].Play();
                        iRet = waveOut.Write(m_pWave[i], vetor[i].MyBuf.GetPtr(), vetor[i].waveSize);
                        //waveOut.ThrowExceptionForError(iRet);
                        //myAudio[i].Play(vetor[i].WaveData, AudioPlayMode.Background);
                    }
                }
            }
        }

        private void Resetar()
        {
            int nums = (int)numericUpDown2.Value;
            int i;
            int j;
            int k;
            int max;

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
                max = m_array.Max();
                double ang;
                for (i = 0; i < m_array.Length; i++)
                {
                    ang = ((float)m_array[i] / max) * Math.PI * 2;
                    m_array[i] = (int)Math.Round((Math.Sin(ang) * max / 2) + (max / 2));
                }
            }
            if (ordem == 5)
            {
                max = m_array.Max();
                double ang;
                for (i = 0; i < m_array.Length; i++)
                {
                    ang = ((float)m_array[i] / max) * Math.PI * 2;
                    m_array[i] = (int)Math.Round((Math.Cos(ang) * max / 2) + (max / 2));
                }
            }
            if (ordem == 6)
            {
                max = m_array.Max();
                i = 0;
                j = m_array.Length - 1;
                k = max;
                while (i < j)
                {
                    m_array[i] = max - k + 1;
                    m_array[j] = (max - k) + 2;
                    i++;
                    j--;
                    k -= 2;
                }

            }
            maximo = m_array.Max();

            vetor = new ArrayItem[m_array.Length];
            vetor.Initialize();

            //myAudio = new SoundPlayer[m_array.Length];
            m_Buff = new WBuf[m_array.Length];
            m_pWave = new IntPtr[m_array.Length];


            if (barras != null)
            {
                for (i = 0; i < barras.Length; i++)
                {
                    panel1.Controls.Remove(barras[i]);
                }
            }

            barras = new VisualControl[m_array.Length];
            float itens = panel1.Width / (float)m_array.Length;

            decimal ratio = (decimal)(panel1.Height - 1) / (decimal)maximo;
            int tam;
            int iRet;

            for (i = 0; i < vetor.Length; i++)
            {
                //myAudio[i] = new();
                m_pWave[i] = new();
                iRet = waveOut.Open(out m_pWave[i], 0, m_Format, IntPtr.Zero, IntPtr.Zero, WaveOpenFlags.None);

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
                freq = 55.0 * Math.Pow(2.0, (100.0 * (m_array[i] / 2) / (m_array.Length - 1.0)) / 12.0);
                //vetor[i].WaveData = createWave(freq); //m_array[i] * 50
                //Console.Beep((int)(55 * Math.Pow(2, m_array[i] / 12)), 500);

                vetor[i].MyBuf = new WBuf(m_pWave[i], m_Format.nSamplesPerSec * (int)Math.Ceiling(AUDIO_LENGTH_IN_SECONDS * 10) * m_Format.nBlockAlign);
                int iSize = vetor[i].MyBuf.GenerateLa(m_Format, (int)AUDIO_LENGTH_IN_SECONDS, (int)freq);
                vetor[i].waveSize = iSize;

                while (!vetor[i].MyBuf.IsBufferFree())
                {
                    System.Threading.Thread.Sleep(1);
                }
                //iRet = waveOut.Write(m_pWave[i], m_Buff[i].GetPtr(), iSize);

                tam = (int)Math.Round(ratio * m_array[i]);
                byte m = 0;
                if (tipoVisual.Text == "Barras") m = VisualControl.BARRA;
                if (tipoVisual.Text == "Bolas") m = VisualControl.BOLA;
                if (tipoVisual.Text == "Linhas") m = VisualControl.LINHA;
                barras[i] = new VisualControl
                {
                    Left = (int)(i * itens),
                    Largura = (int)itens,
                    Top = panel1.Height - tam,
                    Altura = tam,
                    modo = m,
                    CorFundo = Color.Blue,
                    CorFrente = Color.Red,
                    txt = m_array[i].ToString()
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
            AUDIO_LENGTH_IN_SECONDS = (float)numericUpDown1.Value / 2;
        }
    }
}