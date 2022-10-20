using System;
using System.Drawing;
using System.Windows.Forms.Design;

namespace Ordenar
{
    public class ArrayItem : IComparable
    {
        private Color cor1;
        private Color cor2;
        private int IDX;
        //private bool m;
        private int v;
        private int indice;
        private bool mudou;
        private byte[] myWaveData;
        private WBuf Buf;
        public int waveSize = 0;

        public ArrayItem()
        {
            cor1 = Color.Black;
            cor2 = Color.White;
            IDX = 0;
            mudou = true;
        }

        public event EscritaEventHandler Escreveu;
        public event MudarEventHandler Mudar;
        public event LerEventHandler Ler;

        public WBuf MyBuf
        {
            get
            {
                return Buf;
            }
            set
            {
                Buf = value;
            }
        }

        public byte[] WaveData
        {
            get
            {
                return myWaveData;
            }
            set
            {
                myWaveData = value;
            }
        }

        public int Indice
        {
            get
            {
                return indice;
            }
            set
            {
                indice = value;
            }

        }

        /*public bool Marca
        {
            get
            {
                return m;
            }
            set
            {
                m = value;
            }
        }*/

        public int Valor
        {
            get
            {
                VetorEventArgs e = new()
                {
                    indice = Indice,
                    valor = v
                };
                DisparaLer(e);
                return v;
            }
            set
            {
                v = value;
                VetorEventArgs e = new()
                {
                    indice = Indice,
                    valor = Valor
                };
                Dispara(e);
                Mudou = true;
            }
        }

        public void Dispara(VetorEventArgs e)
        {
            if (Escreveu!=null) Escreveu.Invoke(this, e);
        }

        public void DisparaMudar(VetorEventArgs e)
        {
            if (Mudar != null) Mudar.Invoke(this, e);
        }

        public void DisparaLer(VetorEventArgs e)
        {
            if (Ler!=null) Ler.Invoke(this, e);
        }

        public bool Mudou
        {
            get
            {
                return mudou;
            }
            set
            {
                mudou = value;
                if (mudou)
                {
                    VetorEventArgs e = new()
                    {
                        indice = Indice,
                        valor = Valor
                    };

                    DisparaMudar(e);
                }
            }
        }

        public int CompareTo(Object v1)
        {
            int ret;
            ArrayItem a = (ArrayItem)v1;
            ret = 0;

            if (a.Valor == v)
            {
                ret = 0;
            }

            if (a.Valor < v)
            {
                ret = 1;
            }

            if (a.Valor > v)
            {
                ret = -1;
            }

            return ret;
        }

        public Color GetColor(byte idx)
        {
            if (idx == 2)
            {
                return cor2;
            }

            return cor1;
        }

        public int GetColorIDX()
        {
            return IDX;
        }

        public void SetColor1(Color c)
        {
            cor1 = c;
        }

        public void SetColor2(Color c)
        {
            cor2 = c;
        }

        public void SetColorIDX(byte idx)
        {
            IDX = idx;
            switch (idx)
            {
                case 1:
                    SetColor1(Color.FromArgb(255,192,192,0));
                    SetColor2(Color.Orange);
                    break;

                case 2:
                    SetColor1(Color.Red);
                    SetColor2(Color.DarkRed);
                    break;

                case 3:
                    SetColor1(Color.Green);
                    SetColor2(Color.DarkCyan);
                    break;

                case 4:
                    SetColor1(Color.Gray);
                    SetColor2(Color.DarkMagenta);
                    break;

                case 5:
                    SetColor1(Color.AliceBlue);
                    SetColor2(Color.Aquamarine);
                    break;

                case 6:
                    SetColor1(Color.Beige);
                    SetColor2(Color.BurlyWood);
                    break;

                case 7:
                    SetColor1(Color.CornflowerBlue);
                    SetColor2(Color.Chocolate);
                    break;

                case 8:
                    SetColor1(Color.Brown);
                    SetColor2(Color.DarkCyan);
                    break;

                case 9:
                    SetColor1(Color.OrangeRed);
                    SetColor2(Color.DarkKhaki);
                    break;

                case 10:
                    SetColor1(Color.GreenYellow);
                    SetColor2(Color.YellowGreen);
                    break;

                default:
                    SetColor1(Color.Blue);
                    SetColor2(Color.Green);
                    break;
            }
        }

        public override string ToString()
        {
            return v.ToString();
        }

        //public static ArrayItem operator +(ArrayItem a) => a.Valor;
    }
}