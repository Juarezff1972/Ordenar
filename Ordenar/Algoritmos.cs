using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ordenar
{
    internal class Algoritmos
    {
        // //////////////////////////////////////////////////////
        private const bool ASCENDING = true;

        private readonly string PIVOT_FIRST = "Primeiro";
        private readonly string PIVOT_LAST = "Último";
        private readonly string PIVOT_MEDIAN3 = "Mediana";
        private readonly string PIVOT_MID = "Médio";
        private readonly string PIVOT_RANDOM = "Aleatório";
        private int compar;
        private int delay;
        private string g_quicksort_pivot;
        private Label l1;
        private Label l2;
        private Label l3;
        private Label l4;
        private Label l5;
        private ProgressBar pb1;
        private TrackBar piv1;
        private TrackBar piv2;
        private PictureBox painel;
        private int recursoes;
        private int trocas;
        private int segmentos;
        private int externos;
        private ArrayItem[] vetor;

        public event AuxEventHandler auxVetor;

        public Algoritmos()
        {

        }

        public void Dispara(long[] v)
        {
            VetorAuxEventArgs e = new();
            e.vetor = v;
            if (auxVetor != null) auxVetor.Invoke(this, e);
        }

        public void Dispara(int[] v)
        {
            long[] v1 = new long[v.Length];
            for (int i = 0; i < v1.Length; i++)
            {
                v1[i] = (long)v[i];
            }
            Dispara(v1);
        }

        public void Dispara(Array[] a)
        {
            long[] v1 = new long[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                int[] c = Array.FindAll((int[])a[i], x => x == 1);
                v1[i] = c.Length;
            }
            Dispara(v1);
        }

        public void SetPictureBox(PictureBox pn)
        {
            painel = pn;
        }

        public void SetProgress(ProgressBar p)
        {
            pb1 = p;
        }

        public void SetPivot(TrackBar pv, int p)
        {
            if (p == 1)
            {
                piv1 = pv;
            }
            if (p == 2)
            {
                piv2 = pv;
            }
        }

        public static ColorRGB HSL2RGB(double h, double sl, double l)
        {
            double v;
            double r, g, b;

            r = l;
            g = l;
            b = l;
            v = (l <= 0.5) ? (l * (1.0 + sl)) : (l + sl - l * sl);

            if (v > 0)
            {
                double m;
                double sv;
                int sextant;
                double fract, vsf, mid1, mid2;

                m = l + l - v;
                sv = (v - m) / v;
                h *= 6.0;
                sextant = (int)h;
                fract = h - sextant;
                vsf = v * sv * fract;
                mid1 = m + vsf;
                mid2 = v - vsf;

                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;

                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;

                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;

                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;

                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;

                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }

            ColorRGB rgb;
            rgb.R = Convert.ToByte(r * 255.0f);
            rgb.G = Convert.ToByte(g * 255.0f);
            rgb.B = Convert.ToByte(b * 255.0f);

            return rgb;
        }

        /*public static void RGB2HSL(ColorRGB rgb, out double h, out double s, out double l)
        {
            double r = rgb.R / 255.0;
            double g = rgb.G / 255.0;
            double b = rgb.B / 255.0;
            double v;
            double m;
            double vm;
            double r2, g2, b2;

            h = 0; // default to black
            s = 0;
            l = 0;
            v = Math.Max(r, g);
            v = Math.Max(v, b);
            m = Math.Min(r, g);
            m = Math.Min(m, b);
            l = (m + v) / 2.0;

            if (l <= 0.0)
            {
                return;
            }

            vm = v - m;
            s = vm;

            if (s > 0.0)
            {
                s /= (l <= 0.5) ? (v + m) : (2.0 - v - m);
            }
            else
            {
                return;
            }

            r2 = (v - r) / vm;
            g2 = (v - g) / vm;
            b2 = (v - b) / vm;

            if (r == v)
            {
                h = (g == m ? 5.0 + b2 : 1.0 - g2);
            }
            else if (g == v)
            {
                h = (b == m ? 1.0 + r2 : 3.0 - b2);
            }
            else
            {
                h = (r == m ? 3.0 + g2 : 5.0 - r2);
            }

            h /= 6.0;
        }*/

        private void Swap(int a, int b)
        {
            ArrayItem c;
            c = vetor[a];
            vetor[a].som = false;
            vetor[b].som = false;
            vetor[a] = vetor[b];
            vetor[b] = c;
            vetor[a].SetColorIDX(8);
            vetor[b].SetColorIDX(3);
            vetor[a].Indice = b;
            vetor[b].Indice = a;
            vetor[a].Mudou = true;
            vetor[b].Mudou = true;
            trocas++;
            l1.Text = "Trocas: " + trocas.ToString();
            if (delay > 0)
            {
                l1.Refresh();
                ChecaSegmentos();
            }
            vetor[a].som = true;
            vetor[b].som = true;

        }

        private void ChecaSegmentos()
        {
            pb1.Maximum = vetor.Length;
            segmentos = 1;
            int i;
            for (i = 1; i < vetor.Length - 1; i++)
            {
                vetor[i].som = false;
                vetor[i - 1].som = false;
                if (vetor[i].CompareTo(vetor[i - 1]) == -1)
                {
                    segmentos++;
                }
                vetor[i].som = true;
                vetor[i - 1].som = true;
            }
            pb1.Value = vetor.Length - (segmentos - 1);
            l4.Text = "Segmentos: " + segmentos.ToString();
            l5.Text = "Escrita em vetores externos: " + externos.ToString();
            if (delay > 0)
            {
                l4.Refresh();
                l5.Refresh();
                pb1.Refresh();
            }
        }

        public struct ColorRGB
        {
            public byte B;
            public byte G;
            public byte R;

            public ColorRGB(System.Drawing.Color value)
            {
                this.R = value.R;
                this.G = value.G;
                this.B = value.B;
            }

            public static explicit operator ColorRGB(Color c)
            {
                return new ColorRGB(c);
            }

            public static implicit operator Color(ColorRGB rgb)
            {
                Color c = Color.FromArgb(rgb.R, rgb.G, rgb.B);
                return c;
            }

            public override string ToString()
            {
                return Color.FromArgb(this.R, this.G, this.B).ToString();
            }
        }

        private void RmRecursao()
        {
            recursoes--;
            l2.Text = "Recursões: " + recursoes.ToString();
            l2.Refresh();
        }

        private void Pausa()
        {
            switch (delay)
            {
                case 0:
                    //return;
                    break;
                case 1:
                    ChecaSegmentos();
                    painel.Refresh();
                    break;
                default:
                    painel.Refresh();
                    ChecaSegmentos();
                    System.Threading.Thread.Sleep(delay);
                    break;
            }
        }

        private static int PrevPowerOfTwo(int x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            return x - (x >> 1);
        }

        private static int Comp(int v1, int v2)
        {
            return (v1 == v2 ? 0 : v1 < v2 ? -1 : +1);
        }

        private void ContaComparacao()
        {
            compar++;
            l3.Text = "Comparações: " + compar.ToString();
            l3.Refresh();
        }

        private static int GreatestPowerOfTwoLessThan(int n)
        {
            int k = 1;
            while (k < n)
            {
                k <<= 1;
            }

            return k >> 1;
        }

        private void AdRecursao()
        {
            recursoes++;
            l2.Text = "Recursões: " + recursoes.ToString();
            l2.Refresh();
        }

        public void SetVetor(ArrayItem[] v)
        {
            vetor = v;
        }

        public void SetDelay(int d)
        {
            delay = d;
        }

        public void SetLabel(int i, Label l)
        {
            switch (i)
            {
                case 1:
                    l1 = l;
                    break;
                case 2:
                    l2 = l;
                    break;
                case 3:
                    l3 = l;
                    break;
                case 4:
                    l4 = l;
                    break;
                case 5:
                    l5 = l;
                    break;
            }
        }

        public void Desmarcar()
        {
            for (int m = 0; m < vetor.Length; m++)
            {
                double i = m / (double)vetor.Length;
                ColorRGB c = HSL2RGB(i, 0.5, 0.5);
                Color cc = Color.FromArgb(c.R, c.G, c.B);

                vetor[m].SetColor1(cc);
                vetor[m].SetColor2(cc);
                vetor[m].Indice = m;
                vetor[m].Mudou = true;
                System.Threading.Thread.Sleep(5);
            }
        }

        public void LimpaTXT()
        {
            trocas = 0;
            recursoes = 0;
            compar = 0;
            segmentos = 0;
            externos = 0;
            l1.Text = "Trocas: " + trocas.ToString();
            l3.Text = "Comparações: " + compar.ToString();
            l2.Text = "Recursões: " + recursoes.ToString();
            l4.Text = "Segmentos: " + segmentos.ToString();
            l5.Text = "Escrita em vetores externos: " + externos.ToString();
            l1.Refresh();
            l2.Refresh();
            l3.Refresh();
            l4.Refresh();
            l5.Refresh();
        }

        // //////////////////////////////////////////////////////
        /*private bool isPowerOfTwo(int x)
        {
            int y = (~(x & (x - 1)));

            return ((x != 0) && (y != 0));
        }*/
        /*public void setLogText(TextBox t)
        {
            logText = t;
            logText.Text = "Log";
        }*/
        #region Algoritmos de Ordenação
        // //////////////////////////////////////////////////////
        public void BinaryInsertionSort()
        {
            ChecaSegmentos();
            piv1.Visible = true;
            for (int i = 1; i < vetor.Length; ++i)
            {
                int key = vetor[i].Valor;
                piv1.Value = i + 1;
                vetor[i].SetColorIDX(1);
                Pausa();

                int lo = 0, hi = i;
                while (lo < hi)
                {
                    int mid = (lo + hi) / 2;
                    if (key <= vetor[mid].Valor)
                    {
                        hi = mid;
                    }
                    else
                    {
                        lo = mid + 1;
                    }
                }
                // item has to go into position lo

                int j = i - 1;
                while (j >= lo)
                {
                    Swap(j, j + 1);
                    Pausa();
                    j--;
                }

                vetor[j + 1].SetColorIDX(2);
                Pausa();
                vetor[i].SetColorIDX(0);
            }
            Pausa();
        }
        // //////////////////////////////////////////////////////
        public void BitonicSort()
        {
            BitonicSort(0, vetor.Length, ASCENDING);
        }

        private void Bitonic_compare(int i, int j, bool dir)
        {
            ContaComparacao();
            if (dir == (vetor[i].CompareTo(vetor[j]) == 1))
            {
                Swap(i, j);
            }
        }

        private void BitonicMerge(int lo, int n, bool dir)
        {
            AdRecursao();
            if (n > 1)
            {
                int m = GreatestPowerOfTwoLessThan(n);
                piv2.Value = m + 1;
                vetor[m].SetColorIDX(1);
                Pausa();
                vetor[m].SetColorIDX(4);
                for (int i = lo; i < lo + n - m; i++)
                {
                    Bitonic_compare(i, i + m, dir);
                }

                BitonicMerge(lo, m, dir);
                BitonicMerge(lo + m, n - m, dir);
            }
            RmRecursao();
        }

        private void BitonicSort(int lo, int n, bool dir)
        {
            ChecaSegmentos();
            AdRecursao();
            piv1.Visible = true;
            piv2.Visible = true;
            if (n > 1)
            {
                int m = n / 2;
                piv1.Value = m + 1;
                vetor[m].SetColorIDX(1);
                Pausa();
                //vetor[m].SetColorIDX(2);
                BitonicSort(lo, m, !dir);
                BitonicSort(lo + m, n - m, dir);
                BitonicMerge(lo, n, dir);
            }
            RmRecursao();
        }
        // //////////////////////////////////////////////////////
        public void BubbleSort()
        {
            ChecaSegmentos();
            piv1.Visible = true;
            for (int i = 0; i < vetor.Length - 1; ++i)
            {
                vetor[i].SetColorIDX(1);
                piv1.Value = i + 1;
                for (int j = 0; j < vetor.Length - 1 - i; ++j)
                {
                    vetor[j].SetColorIDX(2);
                    ContaComparacao();
                    if (vetor[j].CompareTo(vetor[j + 1]) == 1)
                    {
                        Swap(j, j + 1);
                        //Pausa();
                    }
                    Pausa();
                }
                vetor[i].SetColorIDX(3);
            }
            Pausa();
        }
        // //////////////////////////////////////////////////////
        public void BubbleSort2()
        {
            int i;
            int j;
            int max;
            int maxidx = 0;
            ChecaSegmentos();
            piv1.Visible = true;
            for (i = vetor.Length - 1; i >= 0; i--)
            {
                max = 0;
                for (j = 0; j < i; j++)
                {
                    vetor[j].SetColorIDX(1);
                    Pausa();
                    vetor[j].SetColorIDX(0);
                    ContaComparacao();

                    if (max < vetor[j].Valor)
                    {
                        vetor[maxidx].SetColorIDX(0);
                        max = vetor[j].Valor;
                        maxidx = j;
                        piv1.Value = maxidx + 1;
                        vetor[j].SetColorIDX(2);
                        Pausa();
                    }
                }
                ContaComparacao();
                if (vetor[i].CompareTo(vetor[maxidx]) == -1)
                {
                    Swap(i, maxidx);
                }
                Pausa();
            }
            ChecaSegmentos();
        }
        // //////////////////////////////////////////////////////
        public void BubbleSort3()
        {
            int i;
            //int j;
            int max;
            int maxidx = 0;
            int minidx = vetor.Length - 1;
            int min;
            int inicio = 0;
            int final = vetor.Length;
            ChecaSegmentos();
            piv1.Visible = true;
            piv2.Visible = true;
            while (inicio < final)
            {
                max = 0;
                min = vetor.Max().Valor + 1;
                vetor[final - 1].SetColorIDX(10);
                vetor[inicio].SetColorIDX(10);
                for (i = inicio; i < final; i++)
                {
                    vetor[i].SetColorIDX(1);
                    Pausa();
                    vetor[i].SetColorIDX(0);
                    if (max < vetor[i].Valor)
                    {
                        vetor[maxidx].SetColorIDX(0);
                        max = vetor[i].Valor;
                        maxidx = i;
                        piv1.Value = maxidx + 1;
                    }
                    ContaComparacao();
                    if (min > vetor[i].Valor)
                    {
                        vetor[minidx].SetColorIDX(0);
                        min = vetor[i].Valor;
                        minidx = i;
                        piv2.Value = minidx + 1;
                    }
                    vetor[i].SetColorIDX(0);
                    vetor[maxidx].SetColorIDX(2);
                    vetor[minidx].SetColorIDX(3);
                    Pausa();
                }
                ContaComparacao();
                if (vetor[final - 1].CompareTo(vetor[maxidx]) == -1)
                {
                    Swap(maxidx, final - 1);

                    if ((final - 1) == minidx)
                    {
                        minidx = maxidx;
                    }
                }
                ContaComparacao();
                if (vetor[inicio].CompareTo(vetor[minidx]) == 1)
                {
                    Swap(minidx, inicio);
                }
                vetor[final - 1].SetColorIDX(10);
                vetor[inicio].SetColorIDX(9);
                Pausa();
                final--;
                inicio++;
            }
            ChecaSegmentos();
        }
        // //////////////////////////////////////////////////////
        public void CocktailShakerSort()
        {
            int lo = 0;
            int hi = vetor.Length - 1;
            int mov = lo;

            ChecaSegmentos();
            piv1.Visible = true;
            while (lo < hi)
            {
                for (int i = hi; i > lo; --i)
                {
                    ContaComparacao();
                    if (vetor[i - 1].CompareTo(vetor[i]) == 1)
                    {
                        Swap(i - 1, i);
                        mov = i;
                    }
                    piv1.Value = i;
                    vetor[i - 1].SetColorIDX(1);
                    vetor[i].SetColorIDX(9);
                    Pausa();
                    vetor[i - 1].SetColorIDX(0);
                }
                lo = mov;

                for (int i = lo; i < hi; ++i)
                {
                    ContaComparacao();
                    if (vetor[i].CompareTo(vetor[i + 1]) == 1)
                    {
                        Swap(i, i + 1);
                        mov = i;
                    }
                    piv1.Value = i;
                    vetor[i + 1].SetColorIDX(1);
                    vetor[i].SetColorIDX(10);
                    Pausa();
                    vetor[i + 1].SetColorIDX(0);
                }
                hi = mov;
            }
            Pausa();
        }
        // //////////////////////////////////////////////////////
        public void CombSort()
        {
            const double shrink = 1.3;

            bool swapped = false;
            int gap = vetor.Length;
            ChecaSegmentos();
            piv1.Visible = true;
            while ((gap > 1) || swapped)
            {
                if (gap > 1)
                {
                    gap = (int)((float)gap / shrink);
                }

                swapped = false;

                for (int i = 0; gap + i < vetor.Length; ++i)
                {
                    piv1.Value = i + gap + 1;
                    vetor[i].SetColorIDX(1);
                    ContaComparacao();
                    if (vetor[i].CompareTo(vetor[i + gap]) == 1)
                    {
                        Swap(i, i + gap);
                        Pausa();
                        swapped = true;
                    }
                }
            }
            Pausa();
        }
        // //////////////////////////////////////////////////////
        public void CountingSort()
        {
            int max = vetor.Length - 1;
            int mc = vetor.Max().Valor;
            long[] cnt = new long[mc + 1];
            int[] b = new int[max + 1];
            long idx;

            ChecaSegmentos();
            piv1.Visible = true;
            cnt.Initialize();
            int j;

            for (j = 0; j <= max; j++)
            {
                piv1.Value = j + 1;
                int l = vetor[j].Valor;
                cnt[l]++;
                b[j] = vetor[j].Valor;
                externos++;
                vetor[j].SetColorIDX(1);
                Dispara(cnt);
                Pausa();
            }
            for (int i = 1; i <= mc; i++)
            {
                cnt[i] = cnt[i] + cnt[i - 1];
                Dispara(cnt);
                externos++;
            }
            for (j = max; j >= 0; j--)
            {
                piv1.Value = j + 1;
                idx = vetor[j].Valor;
                b[cnt[idx] - 1] = vetor[j].Valor;
                externos++;
                vetor[cnt[idx] - 1].SetColorIDX(2);
                cnt[idx]--;
                Dispara(cnt);
                Pausa();
            }
            for (j = 0; j <= max; j++)
            {
                vetor[j].Valor = b[j];
                vetor[j].SetColorIDX(1);
                Pausa();
            }
            ChecaSegmentos();
        }
        // //////////////////////////////////////////////////////
        public void CycleSort()
        {
            int cycle_start;
            int tmp;
            ChecaSegmentos();
            piv1.Visible = true;
            piv2.Visible = true;
            for (cycle_start = 0; cycle_start < vetor.Length - 1; cycle_start++)
            {
                int item = vetor[cycle_start].Valor;
                int pos = cycle_start;

                for (int i = cycle_start + 1; i < vetor.Length; i++)
                {
                    piv1.Value = i + 1;
                    vetor[i].SetColorIDX(1);
                    Pausa();
                    ContaComparacao();
                    if (vetor[i].Valor < item)
                    {
                        pos++;
                    }

                    vetor[i].SetColorIDX(0);
                }

                if (pos != cycle_start)
                {
                    while (item == vetor[pos].Valor)
                    {
                        ContaComparacao();
                        pos++;
                        piv2.Value = pos + 1;
                    }

                    tmp = vetor[pos].Valor;
                    vetor[pos].Valor = item;
                    item = tmp;
                    vetor[pos].SetColorIDX(3);
                    Pausa();

                    while (pos != cycle_start)
                    {
                        piv1.Value = pos + 1;
                        pos = cycle_start;
                        for (int i = cycle_start + 1; i < vetor.Length; i++)
                        {
                            vetor[i].SetColorIDX(1);
                            Pausa();
                            ContaComparacao();
                            if (vetor[i].Valor < item)
                            {
                                pos++;
                            }
                            piv2.Value = i;

                            vetor[i].SetColorIDX(0);
                        }
                        while (item == vetor[pos].Valor)
                        {
                            ContaComparacao();
                            pos++;
                            piv2.Value = pos + 1;
                        }
                        tmp = vetor[pos].Valor;
                        vetor[pos].Valor = item;
                        item = tmp;
                        vetor[pos].SetColorIDX(3);
                        Pausa();
                    }
                }
            }
            ChecaSegmentos();
        }
        // //////////////////////////////////////////////////////
        public void FlashSort(int length)
        {

            int m = (int)((0.2 * length) + 2);
            int min, max, maxIndex;
            min = max = vetor[0].Valor;
            maxIndex = 0;

            ChecaSegmentos();
            piv1.Visible = true;
            piv2.Visible = true;
            piv1.Maximum = length + 1;
            piv2.Maximum = length + 1;
            piv1.Value = 1;
            piv2.Value = 1;

            for (int i = 1; i < length - 1; i += 2)
            {
                int small;
                int big;
                int bigIndex;

                if (vetor[i].Valor < vetor[i + 1].Valor)
                {
                    small = vetor[i].Valor;
                    big = vetor[i + 1].Valor;
                    bigIndex = i + 1;
                }
                else
                {
                    big = vetor[i].Valor;
                    bigIndex = i;
                    small = vetor[i + 1].Valor;
                }

                if (big > max)
                {
                    max = big;
                    maxIndex = bigIndex;
                }

                if (small < min)
                {
                    min = small;
                }
                piv1.Value = min + 1;
                piv2.Value = max + 1;
                Pausa();
            }
            if (vetor[length - 1].Valor < min)
            {
                min = vetor[length - 1].Valor;
            }
            else if (vetor[length - 1].Valor > max)
            {
                max = vetor[length - 1].Valor;
                maxIndex = length - 1;
            }
            piv1.Value = min + 1;
            piv2.Value = max + 1;
            Pausa();

            if (max == min)
            {
                return;
            }

            int[] L = new int[m + 1];

            for (int t = 1; t <= m; t++)
            {
                L[t] = 0;
            }
            double c = (m - 1.0) / (max - min);
            int K;
            for (int h = 0; h < length; h++)
            {
                K = ((int)((vetor[h].Valor - min) * c)) + 1;
                L[K] += 1;
                externos++;
            }
            for (K = 2; K <= m; K++)
            {
                L[K] = L[K] + L[K - 1];
                Dispara(L);
                externos++;
            }
            Swap(maxIndex, 0);
            Pausa();
            ChecaSegmentos();
            int j = 0;
            K = m;
            int numMoves = 0;
            while (numMoves < length)
            {
                while (j >= L[K])
                {
                    j++;
                    K = ((int)((vetor[j].Valor - min) * c)) + 1;
                }
                int evicted = vetor[j].Valor;
                while (j < L[K])
                {
                    K = ((int)((evicted - min) * c)) + 1;
                    int location = L[K] - 1;
                    (evicted, vetor[location].Valor) = (vetor[location].Valor, evicted);
                    L[K] -= 1;
                    Dispara(L);
                    externos++;
                    numMoves++;
                    Pausa();
                    ChecaSegmentos();
                }
            }
            InsertSort();
        }

        public void FlashSort()
        {

            FlashSort(vetor.Length);

        }
        // //////////////////////////////////////////////////////
        public void GnomeSort()
        {
            ChecaSegmentos();
            for (int i = 1; i < vetor.Length;)
            {
                vetor[i].SetColorIDX(1);
                ContaComparacao();
                if (vetor[i].CompareTo(vetor[i - 1]) >= 0)
                {
                    ++i;
                }
                else
                {
                    Swap(i, i - 1);
                    if (i > 1)
                    {
                        --i;
                    }

                    Pausa();
                }
            }
            Pausa();
        }
        /// ////////////////////////////////////////////////////////////////////////////////////////
        public void HeapSort()
        {
            int n = vetor.Length, i = n / 2;
            double cores;

            ChecaSegmentos();

            for (int j = i; j < n; ++j)
            {
                cores = Math.Log(PrevPowerOfTwo(j + 1)) / Math.Log(2) + 4;
                vetor[i].SetColorIDX((byte)cores);
            }
            Pausa();

            while (true)
            {
                if (i > 0)
                {
                    i--;
                }
                else
                {
                    n--;
                    if (n == 0)
                    {
                        Pausa();
                        return;
                    }

                    Swap(0, n);

                    vetor[n].SetColorIDX(1);
                    if (n + 1 < vetor.Length)
                    {
                        vetor[n + 1].SetColorIDX(0);
                    }

                    Pausa();
                }

                int parent = i;
                int child = i * 2 + 1;

                while (child < n)
                {
                    ContaComparacao();
                    if (child + 1 < n && (vetor[child + 1].CompareTo(vetor[child]) == 1))
                    {
                        child++;
                    }
                    ContaComparacao();
                    if (vetor[child].CompareTo(vetor[parent]) == 1)
                    {
                        Swap(parent, child);
                        parent = child;
                        child = parent * 2 + 1;
                    }
                    else
                    {
                        break;
                    }
                    Pausa();
                }
                cores = Math.Log(PrevPowerOfTwo(i + 1)) / Math.Log(2) + 4;
                vetor[i].SetColorIDX((byte)cores);
                Pausa();
            }
        }
        // //////////////////////////////////////////////////////
        public void InsertSort()
        {
            ChecaSegmentos();
            for (int i = 1; i < vetor.Length; ++i)
            {
                int key = vetor[i].Valor;
                vetor[i].SetColorIDX(1);
                Pausa();

                int j = i - 1;
                while (j >= 0 && vetor[j].Valor > key)
                {
                    ContaComparacao();
                    Swap(j, j + 1);
                    j--;
                    Pausa();
                }
                vetor[i].SetColorIDX(0);
            }
            Pausa();
        }
        // //////////////////////////////////////////////////////
        public void InsertSort2()
        {
            ChecaSegmentos();
            for (int i = 1; i < vetor.Length; ++i)
            {
                int tmp, key = vetor[i].Valor;
                vetor[i].SetColorIDX(1);

                int j = i - 1;
                while (j >= 0 && (tmp = vetor[j].Valor) > key)
                {
                    vetor[j].SetColorIDX(1);
                    ContaComparacao();
                    vetor[j + 1].Valor = tmp;
                    vetor[j + 1].SetColorIDX(2);
                    j--;
                    Pausa();
                }
                vetor[j + 1].Valor = key;

                vetor[i].SetColorIDX(3);
            }
            Pausa();
        }
        // //////////////////////////////////////////////////////
        public void OddEvenSort()
        {
            bool sorted = false;
            ChecaSegmentos();
            while (!sorted)
            {
                sorted = true;

                for (int i = 1; i < vetor.Length - 1; i += 2)
                {
                    ContaComparacao();
                    if (vetor[i].CompareTo(vetor[i + 1]) == 1)
                    {
                        Swap(i, i + 1);
                        sorted = false;
                        Pausa();
                    }
                    vetor[i].SetColorIDX(1);
                }

                for (int i = 0; i < vetor.Length - 1; i += 2)
                {
                    ContaComparacao();
                    if (vetor[i].CompareTo(vetor[i + 1]) == 1)
                    {
                        Swap(i, i + 1);
                        sorted = false;
                        Pausa();
                    }
                    vetor[i].SetColorIDX(2);
                }
                Pausa();
            }
            Pausa();
        }
        // //////////////////////////////////////////////////////
        private void Flip(int k)
        {
            int left = 0;
            while (left < k)
            {
                Swap(k, left);
                k--;
                left++;
            }
        }

        private int MaxIndex(int k)
        {
            int index = 0;
            for (int i = 0; i < k; i++)
            {
                vetor[index].SetColorIDX(5);
                ContaComparacao();
                if (vetor[i].CompareTo(vetor[index]) == 1)
                {
                    index = i;
                }
            }
            return index;
        }

        public void PancakeSort(int n)
        {
            int maxdex;
            while (n > 1)
            {
                maxdex = MaxIndex(n);
                Pausa();
                if (maxdex != n)
                {
                    Flip(maxdex);
                    Pausa();
                    Flip(n - 1);
                    Pausa();
                }
                n--;
            }
        }

        public void PancakeSort()
        {
            ChecaSegmentos();
            PancakeSort(vetor.Length);
        }
        // //////////////////////////////////////////////////////
        public void pigeonholeSort()
        {
            int min = vetor[0].Valor;
            int max = vetor[0].Valor;
            int range, i, j, index;
            int n = vetor.Length;

            piv1.Visible = true;
            piv2.Visible = true;
            piv1.Maximum = n + 1;
            piv2.Maximum = n + 1;
            piv1.Value = 1;
            piv2.Value = 1;

            ChecaSegmentos();

            for (int a = 0; a < n; a++)
            {
                if (vetor[a].Valor > max)
                {
                    max = vetor[a].Valor;
                }
                if (vetor[a].Valor < min)
                {
                    min = vetor[a].Valor;
                }
                piv1.Value = min + 1;
                piv2.Value = max + 1;
                Pausa();
            }

            range = max - min + 1;
            int[] pigeonHoles = new int[range];

            for (i = 0; i < n; i++)
            {
                pigeonHoles[vetor[i].Valor - min]++;
                Dispara(pigeonHoles);
                externos++;
                Pausa();
            }

            index = 0;

            for (j = 0; j < range; j++)
            {
                while (pigeonHoles[j]-- > 0)
                {
                    Dispara(pigeonHoles);
                    externos++;
                    vetor[index++].Valor = j + min;
                    ChecaSegmentos();
                    Pausa();
                }
            }
            return;
        }
        // //////////////////////////////////////////////////////
        public void SetQuickSortPivot(string q)
        {
            g_quicksort_pivot = q;
        }

        public void QuickSortDualPivot()
        {
            piv1.Visible = true;
            piv2.Visible = true;
            QuickSortDualPivotYaroslavskiy(0, vetor.Length - 1);
            //Desmarcar();
            Pausa();
        }

        public void QuickSortLL()
        {
            piv1.Visible = true;
            piv2.Visible = true;
            QuickSortLL(0, vetor.Length);
            Pausa();
        }

        public void QuickSortLR()
        {
            piv1.Visible = true;
            piv2.Visible = true;

            QuickSortLR(0, vetor.Length - 1);
            Pausa();
        }

        public void QuickSortTernaryLR()
        {
            piv1.Visible = true;
            piv2.Visible = true;

            QuickSortTernaryLR(0, vetor.Length - 1);
            Pausa();
        }

        private void QuickSortDualPivotYaroslavskiy(int left, int right)
        {
            ChecaSegmentos();
            AdRecursao();

            if (right > left)
            {
                piv1.Value = left + 1;
                piv2.Value = right + 1;
                ContaComparacao();
                if (vetor[left].CompareTo(vetor[right]) == 1)
                {
                    Swap(left, right);
                    Pausa();
                }

                int p1 = vetor[left].Valor;
                int q = vetor[right].Valor;

                vetor[left].SetColorIDX(1);
                vetor[right].SetColorIDX(1);

                int l = left + 1;
                int g = right - 1;
                int k = l;

                vetor[l].SetColorIDX(3);
                vetor[g].SetColorIDX(4);
                vetor[k].SetColorIDX(5);
                Pausa();

                while (k <= g)
                {
                    //MarkArr[k] = 1;
                    vetor[k].SetColorIDX(1);
                    ContaComparacao();
                    if (vetor[k].Valor < p1)
                    {
                        Swap(k, l);
                        ++l;
                        Pausa();
                    }
                    else if (vetor[k].Valor >= q)
                    {
                        while (vetor[g].Valor > q && k < g)
                        {
                            --g;
                        }

                        Swap(k, g);
                        --g;
                        Pausa();

                        if (vetor[k].Valor < p1)
                        {
                            Swap(k, l);
                            ++l;
                            Pausa();
                        }
                    }
                    ++k;
                }
                --l;
                ++g;
                Swap(left, l);
                Swap(right, g);
                Pausa();

                QuickSortDualPivotYaroslavskiy(left, l - 1);
                QuickSortDualPivotYaroslavskiy(l + 1, g - 1);
                QuickSortDualPivotYaroslavskiy(g + 1, right);
            }
            RmRecursao();
        }

        private int QuickSortSelectPivot(int lo, int hi)
        {
            piv1.Value = lo + 1;
            piv2.Value = hi;
            Random rnd = new Random();
            if (g_quicksort_pivot == PIVOT_FIRST)
            {
                return lo;
            }

            if (g_quicksort_pivot == PIVOT_LAST)
            {
                return hi - 1;
            }

            if (g_quicksort_pivot == PIVOT_MID)
            {
                return (lo + hi) / 2;
            }

            if (g_quicksort_pivot == PIVOT_RANDOM)
            {
                return lo + (rnd.Next() % (hi - lo));
            }

            if (g_quicksort_pivot == PIVOT_MEDIAN3)
            {
                int mid = (lo + hi) / 2;

                // cases if two are equal
                if (vetor[lo].CompareTo(vetor[mid]) == 0)
                {
                    return lo;
                }

                if (vetor[lo].CompareTo(vetor[hi - 1]) == 0 || vetor[mid].CompareTo(vetor[hi - 1]) == 0)
                {
                    return hi - 1;
                }

                // cases if three are different
                return vetor[lo].CompareTo(vetor[mid]) == -1
                    ? (vetor[mid].CompareTo(vetor[hi - 1]) == -1 ? mid : (vetor[lo].CompareTo(vetor[hi - 1]) == -1 ? hi - 1 : lo))
                    : (vetor[mid].CompareTo(vetor[hi - 1]) == 1 ? mid : (vetor[lo].CompareTo(vetor[hi - 1]) == -1 ? lo : hi - 1));
            }

            return lo;
        }

        private void QuickSortLL(int lo, int hi)
        {
            AdRecursao();
            if (lo + 1 < hi)
            {
                int mid = QuickSortLLPartition(lo, hi);

                QuickSortLL(lo, mid);
                QuickSortLL(mid + 1, hi);
            }
            RmRecursao();
            ChecaSegmentos();
        }

        private int QuickSortLLPartition(int lo, int hi)
        {

            // pick pivot and move to back
            int p1 = QuickSortSelectPivot(lo, hi);

            int pivot = vetor[p1].Valor;
            Swap(p1, hi - 1);
            int i = lo;
            vetor[lo].SetColorIDX(2);
            vetor[hi - 1].SetColorIDX(2);
            Pausa();

            for (int j = lo; j < hi - 1; ++j)
            {
                ContaComparacao();
                if (vetor[j].Valor <= pivot)
                {
                    Swap(i, j);
                    ++i;
                    vetor[j].SetColorIDX(1);
                    Pausa();
                }
            }

            Swap(i, hi - 1);
            Pausa();
            vetor[hi - 1].SetColorIDX(0);
            Pausa();
            return i;
        }

        private void QuickSortLR(int lo, int hi)
        {
            AdRecursao();
            // pick pivot and watch
            int p1 = QuickSortSelectPivot(lo, hi + 1);

            int pivot = vetor[p1].Valor;

            vetor[p1].SetColorIDX(1);
            //Pausa();

            int i = lo, j = hi;
            vetor[i].SetColorIDX(2);
            vetor[j].SetColorIDX(2);
            Pausa();

            while (i <= j)
            {
                while (vetor[i].Valor < pivot)
                {
                    ContaComparacao();
                    i++;
                }

                while (vetor[j].Valor > pivot)
                {
                    ContaComparacao();
                    j--;
                }

                if (i <= j)
                {
                    Swap(i, j);

                    // follow pivot if it is swapped
                    if (p1 == i)
                    {
                        p1 = j;
                    }
                    else if (p1 == j)
                    {
                        p1 = i;
                    }

                    i++;
                    j--;

                    vetor[p1].SetColorIDX(1);
                    Pausa();
                }
            }

            Pausa();

            if (lo < j)
            {
                QuickSortLR(lo, j);
            }

            if (i < hi)
            {
                QuickSortLR(i, hi);
            }

            RmRecursao();
            ChecaSegmentos();
        }

        private void QuickSortTernaryLR(int lo, int hi)
        {
            ChecaSegmentos();
            AdRecursao();

            if (hi <= lo)
            {
                return;
            }

            int cmp;

            // pick pivot and swap to back
            int piv = QuickSortSelectPivot(lo, hi + 1);
            Swap(piv, hi);
            vetor[hi].SetColorIDX(1);
            Pausa();

            int pivot = vetor[hi].Valor;

            // schema: |p ===  |i <<< | ??? |j >>> |q === |piv
            int i = lo;
            int j = hi - 1;
            int p1 = lo;
            int q = hi - 1;

            vetor[i].SetColorIDX(2);
            vetor[j].SetColorIDX(2);
            Pausa();

            for (; ; )
            {
                // partition on left
                while (i <= j && ((cmp = Comp(vetor[i].Valor, pivot)) <= 0))
                {
                    if (cmp == 0)
                    {
                        vetor[p1].SetColorIDX(3);
                        Swap(i, p1++);
                        Pausa();
                    }
                    ++i;
                }

                // partition on right
                while (i <= j && ((cmp = Comp(vetor[j].Valor, pivot)) >= 0))
                {
                    if (cmp == 0)
                    {
                        vetor[q].SetColorIDX(3);
                        Swap(j, q--);
                        Pausa();
                    }
                    --j;
                }

                if (i > j)
                {
                    break;
                }

                // swap item between < > regions
                Swap(i++, j--);
                Pausa();
            }

            // swap pivot to right place
            Swap(i, hi);
            Pausa();

            int num_less = i - p1;
            int num_greater = q - j;

            // swap equal ranges into center, but avoid swapping equal elements
            j = i - 1; i += 1;

            int pe = lo + Math.Min(p1 - lo, num_less);
            for (int k = lo; k < pe; k++, j--)
            {
                Swap(k, j);
                Pausa();
            }

            int qe = hi - 1 - Math.Min(hi - 1 - q, num_greater - 1); // one already greater at end
            for (int k = hi - 1; k > qe; k--, i++)
            {
                Swap(i, k);
                Pausa();
            }
            //Pausa();

            QuickSortTernaryLR(lo, lo + num_less - 1);
            QuickSortTernaryLR(hi - num_greater + 1, hi);
            RmRecursao();
            ChecaSegmentos();
        }
        // //////////////////////////////////////////////////////
        public void RadixSortLSD()
        {
            piv1.Visible = true;
            piv2.Visible = true;
            // radix and base calculations
            const int RADIX = 10;

            uint pmax = (uint)Math.Ceiling(Math.Log(vetor.Max().Valor + 1) / Math.Log(RADIX));
            ChecaSegmentos();
            for (uint p1 = 0; p1 < pmax; ++p1)
            {
                int base1 = (int)Math.Pow(RADIX, p1);

                // count digits and copy data
                int[] count = new int[RADIX];
                count.Initialize();
                int[] copy = new int[vetor.Length];
                copy.Initialize();

                for (int i = 0; i < vetor.Length; ++i)
                {
                    vetor[i].SetColorIDX(1);
                    Pausa();
                    copy[i] = vetor[i].Valor;
                    externos++;
                    int r = copy[i] / base1 % RADIX;
                    piv1.Value = i + 1;
                    count[r]++;
                    Dispara(count);
                    externos++;
                    vetor[i].SetColorIDX(0);
                }

                // exclusive prefix sum
                int[] bkt = new int[RADIX + 1];
                bkt.Initialize();
                for (int z = 0; z < count.Length; z++)
                {
                    for (int y = 0; y <= z; y++)
                    {
                        bkt[z + 1] += count[y];
                        Dispara(count);
                        externos++;
                    }
                    piv2.Value = z + 1;
                }

                // mark bucket boundaries
                for (int i = 0; i < bkt.Length - 1; ++i)
                {
                    if (bkt[i] >= vetor.Length)
                    {
                        continue;
                    }

                    vetor[bkt[i]].SetColorIDX(3);
                    Pausa();
                    vetor[bkt[i]].SetColorIDX(0);
                }
                Pausa();

                // redistribute items back into array (stable)
                for (int i = 0; i < vetor.Length; ++i)
                {
                    int r = copy[i] / base1 % RADIX;
                    vetor[bkt[r]++].Valor = copy[i];
                    vetor[bkt[r] - 1].SetColorIDX(1);
                    Pausa();
                    vetor[bkt[r] - 1].SetColorIDX(0);
                }
                Pausa();
            }
            Pausa();
        }

        private void RadixSortMSD(int lo, int hi, int depth)
        {
            ChecaSegmentos();
            AdRecursao();
            piv1.Visible = true;
            piv2.Visible = true;
            vetor[lo].SetColorIDX(1);
            vetor[hi - 1].SetColorIDX(2);
            Pausa();

            // radix and base calculations
            const uint RADIX = 10;

            uint pmax = (uint)Math.Floor(Math.Log(vetor.Max().Valor + 1) / Math.Log(RADIX));

            uint base1 = (uint)Math.Pow(RADIX, pmax - depth);

            // count digits
            //std::vector<size_t> count(RADIX, 0);
            int[] count = new int[RADIX];
            count.Initialize();

            for (int i = lo; i < hi; ++i)
            {
                vetor[i].SetColorIDX(1);
                Pausa();
                uint r = (uint)vetor[i].Valor / base1 % RADIX;
                piv1.Value = i + 1;
                count[r]++;
                Dispara(count);
                externos++;
                vetor[i].SetColorIDX(0);
            }

            // inclusive prefix sum
            //std::vector<size_t> bkt(RADIX, 0);
            //std::partial_sum(count.begin(), count.end(), bkt.begin());
            int[] bkt = new int[RADIX];
            bkt.Initialize();
            for (int z = 0; z < count.Length; z++)
            {
                for (int y = 0; y <= z; y++)
                {
                    bkt[z] += count[y];
                    externos++;
                }
                Dispara(bkt);

            }

            // mark bucket boundaries
            for (int i = 0; i < bkt.Length; ++i)
            {
                if (bkt[i] == 0)
                {
                    continue;
                }

                piv2.Value = lo + bkt[i];

                vetor[lo + bkt[i] - 1].SetColorIDX(8);
                Pausa();
                vetor[lo + bkt[i] - 1].SetColorIDX(0);
            }

            // reorder items in-place by walking cycles
            for (int i = 0, j; i < (hi - lo);)
            {
                while ((j = --bkt[(vetor[lo + i].Valor / base1 % RADIX)]) > i)
                {
                    Swap(lo + i, lo + j);
                    Pausa();
                    piv1.Value = lo + i + 1;
                    piv2.Value = lo + j + 1;
                }
                //Pausa();
                i += count[(vetor[lo + i].Valor / base1 % RADIX)];
            }

            // no more depth to sort?
            if (depth + 1 > pmax)
            {
                return;
            }

            // recurse on buckets
            int sum = lo;
            for (int i = 0; i < RADIX; ++i)
            {
                if (count[i] <= 1)
                {
                    continue;
                }

                RadixSortMSD(sum, sum + count[i], depth + 1);
                sum += count[i];
            }
            Pausa();
            RmRecursao();
        }

        public void RadixSortMSD()
        {
            RadixSortMSD(0, vetor.Length, 0);
            Pausa();
        }
        // //////////////////////////////////////////////////////
        public void SelectionSort()
        {
            ChecaSegmentos();
            piv1.Visible = true;
            piv2.Visible = true;
            for (int i = 0; i < vetor.Length - 1; ++i)
            {
                int jMin = i;
                for (int j = i + 1; j < vetor.Length; ++j)
                {
                    piv2.Value = j + 1;
                    ContaComparacao();
                    if (vetor[j].CompareTo(vetor[jMin]) == -1)
                    {
                        vetor[j].SetColorIDX(2);
                        vetor[jMin].SetColorIDX(2);
                        jMin = j;
                        Pausa();
                    }
                }


                Swap(i, jMin);

                // mark the last good element
                if (i > 0)
                {
                    vetor[i - 1].SetColorIDX(3);
                }

                piv1.Value = i + 1;
                vetor[i].SetColorIDX(1);
                Pausa();
                vetor[i].SetColorIDX(0);
            }
            Pausa();
        }
        // //////////////////////////////////////////////////////
        public void ShellSort()
        {
            int[] incs = { 1391376, 463792, 198768, 86961, 33936, 13776, 4592, 1968, 861, 336, 112, 48, 21, 7, 3, 1 };
            ChecaSegmentos();
            piv1.Visible = true;
            for (int k = 0; k < 16; k++)
            {
                for (int h = incs[k], i = h; i < vetor.Length; i++)
                {
                    int v = vetor[i].Valor;
                    int j = i;
                    vetor[i].SetColorIDX(1);
                    piv1.Value = j + 1;
                    while (j >= h && vetor[j - h].Valor > v)
                    {
                        ContaComparacao();
                        vetor[j].SetColorIDX(3);
                        vetor[j].Valor = vetor[j - h].Valor;
                        j -= h;
                        Pausa();
                        vetor[j].SetColorIDX(4);
                    }
                    vetor[j].SetColorIDX(1);
                    vetor[j].Valor = v;
                    Pausa();
                    vetor[i].SetColorIDX(0);
                }
            }
            Pausa();
        }
        // //////////////////////////////////////////////////////
        private void Merge(int lo, int mid, int hi)
        {
            int[] outA;

            ChecaSegmentos();
            piv1.Visible = true;
            piv2.Visible = true;
            // mark merge boundaries
            vetor[lo].SetColorIDX(2);
            vetor[mid].SetColorIDX(1);
            vetor[hi - 1].SetColorIDX(2);
            Pausa();

            // allocate output
            outA = new int[hi - lo];
            //std::vector < value_type > out(hi - lo);

            // merge
            int i = lo; int j = mid; int o = 0; // first and second halves
            while (i < mid && j < hi)
            {
                // copy out for fewer time steps
                int ai = vetor[i].Valor;
                int aj = vetor[j].Valor;
                piv1.Value = i + 1;
                piv2.Value = j + 1;
                ContaComparacao();
                if (ai < aj)
                {
                    ++i;
                    outA[o++] = ai;
                }
                else
                {
                    ++j;
                    outA[o++] = aj;
                }
                Dispara(outA);
                externos++;
            }

            // copy rest
            while (i < mid)
            {
                outA[o++] = vetor[i++].Valor;
                Dispara(outA);
            }

            while (j < hi)
            {
                outA[o++] = vetor[j++].Valor;
                Dispara(outA);
            }
            externos++;

            vetor[mid].SetColorIDX(0);
            vetor[lo].SetColorIDX(0);
            // copy back
            for (i = 0; i < hi - lo; ++i)
            {
                vetor[lo + i].Valor = outA[i];
                vetor[lo + i].SetColorIDX(1);
                Pausa();
            }

            vetor[hi - 1].SetColorIDX(1);
            Pausa();
        }

        private void MergeSort(int lo, int hi)
        {
            ChecaSegmentos();
            AdRecursao();
            if (lo + 1 < hi)
            {
                int mid = (lo + hi) / 2;

                MergeSort(lo, mid);
                MergeSort(mid, hi);

                Merge(lo, mid, hi);
            }
            RmRecursao();
        }

        public void MergeSort()
        {
            MergeSort(0, vetor.Length);
            //Desmarcar();

            Pausa();
        }
        // //////////////////////////////////////////////////////
        private void SlowSort(int i, int j)
        {
            ChecaSegmentos();
            AdRecursao();
            piv1.Visible = true;
            if (i >= j)
            {
                RmRecursao();
                return;
            }

            int m = (i + j) / 2;

            piv1.Value = m + 1;

            vetor[j].SetColorIDX(1);
            Pausa();
            SlowSort(i, m);
            SlowSort(m + 1, j);

            ContaComparacao();
            if (vetor[m].CompareTo(vetor[j]) == 1)
            {
                Swap(m, j);
            }


            //Pausa();
            vetor[j].SetColorIDX(0);
            SlowSort(i, j - 1);

            vetor[j].SetColorIDX(1);
            Pausa();
            RmRecursao();
        }
        public void SlowSort()
        {
            SlowSort(0, vetor.Length - 1);
            ChecaSegmentos();
        }

        // //////////////////////////////////////////////////////
        public void GravitySort()
        {
            int max = vetor.Max().Valor;
            Array[] abacus;
            int i;
            int j;
            int droppos;
            int count;
            int x;
            int y;

            ChecaSegmentos();
            piv1.Visible = true;
            piv1.Maximum = max;
            piv2.Visible = true;
            piv2.Maximum = vetor.Length;

            abacus = new Array[vetor.Length];
            for (i = 0; i < abacus.Length; i++)
            {
                abacus[i] = new int[max];
            }
            for (i = 0; i < vetor.Length; i++)
            {
                for (j = 0; j < vetor[i].Valor; j++)
                {
                    abacus[i].SetValue(1, abacus[0].Length - j - 1);
                    piv1.Value = abacus[0].Length - j;
                    Dispara(abacus);
                    externos++;
                    //Pausa();
                }
                piv2.Value = i + 1;
            }
            piv1.Maximum = abacus[0].Length;
            for (i = 0; i < abacus[0].Length; i++)
            {
                for (j = 0; j < abacus.Length; j++)
                {
                    if ((int)abacus[j].GetValue(i) == 1)
                    {
                        droppos = j;
                        while (droppos + 1 < abacus.Length && (int)abacus[droppos].GetValue(i) == 1)
                        {
                            droppos++;
                        }
                        if ((int)abacus[droppos].GetValue(i) == 0)
                        {
                            abacus[j].SetValue(0, i);
                            abacus[droppos].SetValue(1, i);
                            Dispara(abacus);
                            externos++;
                        }
                    }
                }
                count = 0;
                for (x = 0; x < abacus.Length; x++)
                {
                    count = 0;
                    for (y = 0; y < abacus[0].Length; y++)
                    {
                        count += (int)abacus[x].GetValue(y);
                    }
                    vetor[x].Valor = count;
                }
                ChecaSegmentos();
                piv1.Value = i + 1;
                Pausa();
            }
        }
        // //////////////////////////////////////////////////////
        private int[] tmp;

        private int vencedor(int pos1, int pos2)
        {
            int u = pos1 >= vetor.Length ? pos1 : tmp[pos1];
            int v = pos2 >= vetor.Length ? pos2 : tmp[pos2];
            if (tmp[u] <= tmp[v]) return u;
            return v;
        }

        private void criaArvore(ref int valor)
        {
            for (int i = 0; i < vetor.Length; i++) tmp[vetor.Length + i] = vetor[i].Valor;
            for (int i = 2 * vetor.Length - 1; i > 1; i -= 2)
            {
                int k = i / 2;
                int j = i - 1;
                tmp[k] = vencedor(i, j);
                Dispara(tmp);
                externos++;
                piv2.Value = tmp[k];
                Pausa();
            }
            valor = tmp[tmp[1]];
            tmp[tmp[1]] = int.MaxValue;
        }

        private void recriar(ref int valor)
        {
            int i = tmp[1];
            while (i > 1)
            {
                int j, k = i / 2;
                if (i % 2 == 0 && i < 2 * vetor.Length - 1)
                    j = i + 1;
                else
                    j = i - 1;
                tmp[k] = vencedor(i, j);
                externos++;
                i = k;
                piv2.Value = tmp[k];
                Dispara(tmp);
                Pausa();
            }
            valor = tmp[tmp[1]];
            tmp[tmp[1]] = int.MaxValue;
        }

        public void tournamentSort()
        {
            int valor = 0;
            int max = vetor.Length;

            ChecaSegmentos();
            piv1.Visible = true;
            piv1.Maximum = max;
            piv2.Visible = true;
            piv2.Maximum = 2 * vetor.Length - 1;

            tmp = new int[vetor.Length << 1];
            criaArvore(ref valor);
            for (int i = 0; i < vetor.Length; i++)
            {
                vetor[i].Valor = valor;
                recriar(ref valor);
                ChecaSegmentos();
                piv1.Value = i + 1;
                Pausa();
            }
        }

        // //////////////////////////////////////////////////////
        const int NUMBER_OF_BUCKETS = 128;

        private int MaximoDigitos()
        {
            int max = int.MinValue;
            int temp = 0;
            for (int i = 0; i < vetor.Length; i++)
            {
                temp = (int)(Math.Log(vetor[i].Valor) / Math.Log(NUMBER_OF_BUCKETS)) + 1;
                if (temp > max)
                    max = temp;
            }
            return max;
        }

        private int Digitos(int i, int d)
        {
            return (i / d) % NUMBER_OF_BUCKETS;
        }

        private void AmericanSort(int inicio, int tam, int divisor)
        {
            int[] contagem = new int[NUMBER_OF_BUCKETS];
            int[] offset = new int[NUMBER_OF_BUCKETS];
            int digitos = 0;
            AdRecursao();
            //passo 1
            piv1.Value = 1;
            piv1.Maximum = tam;
            for (int i = inicio; i < tam; i++)
            {
                int d = vetor[i].Valor;
                digitos = Digitos(d, divisor);
                contagem[digitos]++;
                Dispara(contagem);
                externos++;
                piv1.Value = i + 1;
            }
            offset[0] = inicio;
            piv2.Value = 1;
            piv2.Maximum = NUMBER_OF_BUCKETS;
            for (int i = 1; i < NUMBER_OF_BUCKETS; i++)
            {
                offset[i] = contagem[i - 1] + offset[i - 1];
                Dispara(offset);
                externos++;
                piv2.Value = i;
            }
            ChecaSegmentos();
            //passo 2
            for (int b = 0; b < NUMBER_OF_BUCKETS; b++)
            {
                while (contagem[b] > 0)
                {
                    int origem = offset[b];
                    int fonte = origem;
                    int num = vetor[fonte].Valor;
                    do
                    {
                        digitos = Digitos(num, divisor);
                        int destino = offset[digitos];
                        offset[digitos]++;
                        contagem[digitos]--;
                        int temp = vetor[destino].Valor;
                        vetor[destino].Valor = num;
                        num = temp;
                        fonte = destino;
                        Dispara(contagem);
                        Pausa();
                        ChecaSegmentos();
                    } while (fonte != origem);
                }
                piv2.Value = b + 1;
            }
            if (divisor > 1)
            {
                for (int i = 0; i < NUMBER_OF_BUCKETS; i++)
                {
                    int comeco = (i > 0) ? offset[i - 1] : inicio;
                    int final = offset[i];
                    if (final - comeco > 1)
                        AmericanSort(comeco, final, divisor / NUMBER_OF_BUCKETS);
                }
            }
            RmRecursao();
        }
        public void AmericanSort()
        {
            piv1.Visible = true;
            piv2.Visible = true;
            int digitos = MaximoDigitos();
            int max = 1;
            for (int i = 0; i < digitos - 1; i++)
            {
                max *= NUMBER_OF_BUCKETS;
            }
            AmericanSort(0, vetor.Length, max);
        }
        // //////////////////////////////////////////////////////
        public void SimplisticGravitySort()
        {
            int[] aux;
            int min = vetor[0].Valor;
            int max = min;
            int pointer;
            int index;
            int fator = vetor.Length / 10;
            for (int mainPointer = 1; mainPointer < vetor.Length; mainPointer++)
            {
                min = Math.Min(vetor[mainPointer].Valor, min);
                max = Math.Max(vetor[mainPointer].Valor, max);
            }
            aux = new int[max - min];
            for (int mainPointer = 0; mainPointer < vetor.Length; mainPointer++)
            {
                index = mainPointer;
                for (pointer = 0; vetor[index].Valor > min; pointer++)
                {
                    vetor[index].Valor = --vetor[index].Valor;
                    aux[pointer] = ++aux[pointer];
                    externos++;
                    if ((pointer % fator) == 0) Pausa();
                    vetor[index].som = false;
                }
                Dispara(aux);
                vetor[index].som = true;
            }
            for (int mainPointer = vetor.Length - 1; mainPointer >= 0; mainPointer--)
            {
                index = mainPointer;
                for (pointer = 0; pointer < aux.Length && aux[pointer] != 0; pointer++)
                {
                    vetor[index].Valor = ++vetor[index].Valor;
                    aux[pointer] = --aux[pointer];
                    externos++;
                    if ((pointer % fator) == 0) Pausa();
                    vetor[index].som = false;
                }
                Dispara(aux);
                vetor[index].som = true;
            }
        }
        // //////////////////////////////////////////////////////
        public void SandpaperSort()
        {
            for (int i = 0; i < vetor.Length - 1; i++)
            {
                for (int j = i + 1; j < vetor.Length; j++)
                {
                    if (vetor[i].Valor > vetor[j].Valor)
                    {
                        Swap(i, j);
                        Pausa();
                    }
                }
            }
        }
        // //////////////////////////////////////////////////////

        public void DiamondSort()
        {
            int n = 1;
            for (; n < vetor.Length; n *= 2) ;

            int m = 4;
            for (; m <= n; m *= 2)
            {
                for (int k = 0; k < m / 2; k++)
                {
                    int cnt = k <= m / 4 ? k : m / 2 - k;
                    for (int j = 0; j < vetor.Length; j += m)
                    {
                        if (j + cnt + 1 < vetor.Length)
                        {
                            for (int i = j + cnt; i + 1 < Math.Min(vetor.Length, j + m - cnt); i += 2)
                            {
                                if (vetor[i].Valor > vetor[i + 1].Valor)
                                {
                                    Swap(i, i + 1);
                                    Pausa();
                                }
                            }
                        }
                    }
                }
            }
            m /= 2;
            for (int k = 0; k <= m / 2; k++)
            {
                for (int i = k; i + 1 < Math.Min(vetor.Length, m - k); i += 2)
                {
                    if (vetor[i].Valor > vetor[i + 1].Valor)
                    {
                        Swap(i, i + 1);
                        Pausa();
                    }
                }
            }
        }
        // //////////////////////////////////////////////////////
        #endregion
        public override string ToString()
        {
            return vetor.ToString();
        }
    }
}