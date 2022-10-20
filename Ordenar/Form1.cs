using MultiMedia;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using WindowsMediaLib.Defs;


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
        //Graphics auxGr;
        //GraphicsState auxGrState;

        private int[] m_array;
        private int maximo;
        private byte ordem;
        private ArrayItem[] vetor;
        private VisualControl[] barras;

        private WaveFormatEx m_Format;
        IntPtr[] m_pWave;

        private const int SAMPLE_FREQUENCY = 44100;
        private float AUDIO_LENGTH_IN_SECONDS = 1.0f;

        public Form1()
        {
            InitializeComponent();
            //auxGr = AuxVetor1.CreateGraphics();

            ordem = 1;
            m_Format = new WaveFormatEx();

            m_Format.wFormatTag = 1; // PCM
            m_Format.nChannels = 2; // Stereo
            m_Format.nSamplesPerSec = SAMPLE_FREQUENCY;
            m_Format.wBitsPerSample = 8;
            m_Format.nBlockAlign = (short)(m_Format.nChannels * (m_Format.wBitsPerSample / 8));
            m_Format.nAvgBytesPerSec = m_Format.nSamplesPerSec * m_Format.nBlockAlign;
            m_Format.cbSize = 0;

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
            algo.SetDelay((int)numericUpDown1.Value);
            algo.SetPictureBox(area1);
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
            if (checkBox1.Checked)
            {
                double freq;
                freq = 55.0 * Math.Pow(2.0, (100.0 * e.valor / (m_array.Length - 1.0)) / 12.0);
                if (vetor[e.indice].MyBuf == null) vetor[e.indice].MyBuf = new WBuf(m_pWave[e.indice], m_Format.nSamplesPerSec * (int)Math.Ceiling(AUDIO_LENGTH_IN_SECONDS * 10) * m_Format.nBlockAlign);
                int iSize = vetor[e.indice].MyBuf.GenerateLa(m_Format, (int)AUDIO_LENGTH_IN_SECONDS, (int)freq);
                vetor[e.indice].waveSize = iSize;
            }
        }

        public virtual void OnMudar(object sender, VetorEventArgs e)
        {
            int iRet;

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
                barras[i].Refresh();
                points[i] = new PointF(barras[i].Left + (barras[i].Largura / 2), barras[i].Top);
                if (checkBox1.Checked)
                {
                    if (AUDIO_LENGTH_IN_SECONDS > 0)
                    {
                        iRet = waveOut.Write(m_pWave[i], vetor[i].MyBuf.GetPtr(), vetor[i].waveSize);
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

            //auxGr.Clear(Color.DarkGray);

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

            m_pWave = new IntPtr[m_array.Length];


            if (barras != null)
            {
                for (i = 0; i < barras.Length; i++)
                {
                    area1.Controls.Remove(barras[i]);
                }
            }

            barras = new VisualControl[m_array.Length];
            float itens = area1.Width / (float)m_array.Length;

            decimal ratio = (decimal)(area1.Height - 1) / (decimal)maximo;
            int tam;
            int iRet;

            int l1;
            l1 = vetor.Length;

            points = new PointF[l1];
            for (i = 0; i < vetor.Length; i++)
            {
                m_pWave[i] = new();
                iRet = waveOut.Open(out m_pWave[i], 0, m_Format, IntPtr.Zero, IntPtr.Zero, WaveOpenFlags.None);

                vetor[i] = new ArrayItem
                {
                    Indice = i
                };
                vetor[i].Valor = m_array[i];
                vetor[i].SetColorIDX(0);
                double freq;
                freq = 55.0 * Math.Pow(2.0, (100.0 * (m_array[i] / 2) / (m_array.Length - 1.0)) / 12.0);

                vetor[i].MyBuf = new WBuf(m_pWave[i], m_Format.nSamplesPerSec * (int)Math.Ceiling(AUDIO_LENGTH_IN_SECONDS * 10) * m_Format.nBlockAlign);
                int iSize = vetor[i].MyBuf.GenerateLa(m_Format, (int)AUDIO_LENGTH_IN_SECONDS, (int)freq);
                vetor[i].waveSize = iSize;

                while (!vetor[i].MyBuf.IsBufferFree())
                {
                    System.Threading.Thread.Sleep(1);
                }

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
                    Visible = true
                };

                EscritaEventHandler d1 = new EscritaEventHandler(OnEscreveu);
                MudarEventHandler d2 = new MudarEventHandler(OnMudar);
                LerEventHandler d3 = new LerEventHandler(OnLer);

                vetor[i].Escreveu += d1;
                vetor[i].Mudar += d2;
                vetor[i].Ler += d3;

                area1.Controls.Add(barras[i]);
                points[i] = new PointF(barras[i].Left + (barras[i].Largura / 2), barras[i].Top);
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

        private void area1_Paint(object sender, PaintEventArgs e)
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
                    //e.Graphics.Clear(Color.Black);
                    break;
            }
        }

        public override string ToString()
        {
            return $"{{{nameof(AcceptButton)}={AcceptButton}, {nameof(ActiveForm)}={ActiveForm}, {nameof(ActiveMdiChild)}={ActiveMdiChild}, {nameof(AllowTransparency)}={AllowTransparency.ToString()}, {nameof(AutoScale)}={AutoScale.ToString()}, {nameof(AutoScaleBaseSize)}={AutoScaleBaseSize.ToString()}, {nameof(AutoScroll)}={AutoScroll.ToString()}, {nameof(AutoSize)}={AutoSize.ToString()}, {nameof(AutoSizeMode)}={AutoSizeMode.ToString()}, {nameof(AutoValidate)}={AutoValidate.ToString()}, {nameof(BackColor)}={BackColor.ToString()}, {nameof(FormBorderStyle)}={FormBorderStyle.ToString()}, {nameof(CancelButton)}={CancelButton}, {nameof(ClientSize)}={ClientSize.ToString()}, {nameof(ControlBox)}={ControlBox.ToString()}, {nameof(DesktopBounds)}={DesktopBounds.ToString()}, {nameof(DesktopLocation)}={DesktopLocation.ToString()}, {nameof(DialogResult)}={DialogResult.ToString()}, {nameof(HelpButton)}={HelpButton.ToString()}, {nameof(Icon)}={Icon}, {nameof(IsMdiChild)}={IsMdiChild.ToString()}, {nameof(IsMdiContainer)}={IsMdiContainer.ToString()}, {nameof(IsRestrictedWindow)}={IsRestrictedWindow.ToString()}, {nameof(KeyPreview)}={KeyPreview.ToString()}, {nameof(Location)}={Location.ToString()}, {nameof(MaximumSize)}={MaximumSize.ToString()}, {nameof(MainMenuStrip)}={MainMenuStrip}, {nameof(Margin)}={Margin.ToString()}, {nameof(MinimumSize)}={MinimumSize.ToString()}, {nameof(MaximizeBox)}={MaximizeBox.ToString()}, {nameof(MdiChildren)}={MdiChildren}, {nameof(MdiParent)}={MdiParent}, {nameof(MinimizeBox)}={MinimizeBox.ToString()}, {nameof(Modal)}={Modal.ToString()}, {nameof(Opacity)}={Opacity.ToString()}, {nameof(OwnedForms)}={OwnedForms}, {nameof(Owner)}={Owner}, {nameof(RestoreBounds)}={RestoreBounds.ToString()}, {nameof(RightToLeftLayout)}={RightToLeftLayout.ToString()}, {nameof(ShowInTaskbar)}={ShowInTaskbar.ToString()}, {nameof(ShowIcon)}={ShowIcon.ToString()}, {nameof(Size)}={Size.ToString()}, {nameof(SizeGripStyle)}={SizeGripStyle.ToString()}, {nameof(StartPosition)}={StartPosition.ToString()}, {nameof(TabIndex)}={TabIndex.ToString()}, {nameof(TabStop)}={TabStop.ToString()}, {nameof(Text)}={Text}, {nameof(TopLevel)}={TopLevel.ToString()}, {nameof(TopMost)}={TopMost.ToString()}, {nameof(TransparencyKey)}={TransparencyKey.ToString()}, {nameof(WindowState)}={WindowState.ToString()}, {nameof(AutoScaleDimensions)}={AutoScaleDimensions.ToString()}, {nameof(AutoScaleMode)}={AutoScaleMode.ToString()}, {nameof(AutoValidate)}={AutoValidate.ToString()}, {nameof(BindingContext)}={BindingContext}, {nameof(ActiveControl)}={ActiveControl}, {nameof(CurrentAutoScaleDimensions)}={CurrentAutoScaleDimensions.ToString()}, {nameof(ParentForm)}={ParentForm}, {nameof(AutoScroll)}={AutoScroll.ToString()}, {nameof(AutoScrollMargin)}={AutoScrollMargin.ToString()}, {nameof(AutoScrollPosition)}={AutoScrollPosition.ToString()}, {nameof(AutoScrollMinSize)}={AutoScrollMinSize.ToString()}, {nameof(DisplayRectangle)}={DisplayRectangle.ToString()}, {nameof(HorizontalScroll)}={HorizontalScroll}, {nameof(VerticalScroll)}={VerticalScroll}, {nameof(DockPadding)}={DockPadding}, {nameof(AccessibilityObject)}={AccessibilityObject}, {nameof(AccessibleDefaultActionDescription)}={AccessibleDefaultActionDescription}, {nameof(AccessibleDescription)}={AccessibleDescription}, {nameof(AccessibleName)}={AccessibleName}, {nameof(AccessibleRole)}={AccessibleRole.ToString()}, {nameof(AllowDrop)}={AllowDrop.ToString()}, {nameof(Anchor)}={Anchor.ToString()}, {nameof(AutoSize)}={AutoSize.ToString()}, {nameof(AutoScrollOffset)}={AutoScrollOffset.ToString()}, {nameof(LayoutEngine)}={LayoutEngine}, {nameof(BackColor)}={BackColor.ToString()}, {nameof(BackgroundImage)}={BackgroundImage}, {nameof(BackgroundImageLayout)}={BackgroundImageLayout.ToString()}, {nameof(BindingContext)}={BindingContext}, {nameof(Bottom)}={Bottom.ToString()}, {nameof(Bounds)}={Bounds.ToString()}, {nameof(CanFocus)}={CanFocus.ToString()}, {nameof(CanSelect)}={CanSelect.ToString()}, {nameof(Capture)}={Capture.ToString()}, {nameof(CausesValidation)}={CausesValidation.ToString()}, {nameof(CheckForIllegalCrossThreadCalls)}={CheckForIllegalCrossThreadCalls.ToString()}, {nameof(ClientRectangle)}={ClientRectangle.ToString()}, {nameof(ClientSize)}={ClientSize.ToString()}, {nameof(CompanyName)}={CompanyName}, {nameof(ContainsFocus)}={ContainsFocus.ToString()}, {nameof(ContextMenuStrip)}={ContextMenuStrip}, {nameof(Controls)}={Controls}, {nameof(Created)}={Created.ToString()}, {nameof(Cursor)}={Cursor}, {nameof(DataBindings)}={DataBindings}, {nameof(DefaultBackColor)}={DefaultBackColor.ToString()}, {nameof(DefaultFont)}={DefaultFont}, {nameof(DefaultForeColor)}={DefaultForeColor.ToString()}, {nameof(DeviceDpi)}={DeviceDpi.ToString()}, {nameof(DisplayRectangle)}={DisplayRectangle.ToString()}, {nameof(IsDisposed)}={IsDisposed.ToString()}, {nameof(Disposing)}={Disposing.ToString()}, {nameof(Dock)}={Dock.ToString()}, {nameof(Enabled)}={Enabled.ToString()}, {nameof(Focused)}={Focused.ToString()}, {nameof(Font)}={Font}, {nameof(ForeColor)}={ForeColor.ToString()}, {nameof(Handle)}={Handle.ToString()}, {nameof(HasChildren)}={HasChildren.ToString()}, {nameof(Height)}={Height.ToString()}, {nameof(IsHandleCreated)}={IsHandleCreated.ToString()}, {nameof(InvokeRequired)}={InvokeRequired.ToString()}, {nameof(IsAccessible)}={IsAccessible.ToString()}, {nameof(IsMirrored)}={IsMirrored.ToString()}, {nameof(Left)}={Left.ToString()}, {nameof(Location)}={Location.ToString()}, {nameof(Margin)}={Margin.ToString()}, {nameof(MaximumSize)}={MaximumSize.ToString()}, {nameof(MinimumSize)}={MinimumSize.ToString()}, {nameof(ModifierKeys)}={ModifierKeys.ToString()}, {nameof(MouseButtons)}={MouseButtons.ToString()}, {nameof(MousePosition)}={MousePosition.ToString()}, {nameof(Name)}={Name}, {nameof(Parent)}={Parent}, {nameof(ProductName)}={ProductName}, {nameof(ProductVersion)}={ProductVersion}, {nameof(RecreatingHandle)}={RecreatingHandle.ToString()}, {nameof(Region)}={Region}, {nameof(Right)}={Right.ToString()}, {nameof(RightToLeft)}={RightToLeft.ToString()}, {nameof(Site)}={Site}, {nameof(Size)}={Size.ToString()}, {nameof(TabIndex)}={TabIndex.ToString()}, {nameof(TabStop)}={TabStop.ToString()}, {nameof(Tag)}={Tag}, {nameof(Text)}={Text}, {nameof(Top)}={Top.ToString()}, {nameof(TopLevelControl)}={TopLevelControl}, {nameof(UseWaitCursor)}={UseWaitCursor.ToString()}, {nameof(Visible)}={Visible.ToString()}, {nameof(Width)}={Width.ToString()}, {nameof(WindowTarget)}={WindowTarget}, {nameof(PreferredSize)}={PreferredSize.ToString()}, {nameof(Padding)}={Padding.ToString()}, {nameof(ImeMode)}={ImeMode.ToString()}, {nameof(Container)}={Container}, {nameof(Site)}={Site}}}";
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
                Debug.WriteLine("w=" + w.ToString() + " | " + l.ToString() + " | " + AuxVetor1.Height);
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
    }
}