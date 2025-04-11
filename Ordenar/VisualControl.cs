using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ordenar
{
    public class VisualControl
    {
        public static byte BARRA { get { return 0; } }
        public static byte BOLA { get { return 1; } }
        public static byte LINHA { get { return 2; } }
        public static byte TRIANGULO { get { return 3; } }
        //public static byte CIRCULO { get { return 4; } }

        private string _txt;
        private byte _modo;
        private Color _CorFrente;
        private Color _CorFundo;
        private int _width;
        private int _height;
        private int _left;
        private int _top;
        private int _originalIdx;
        //private double _angle;

        public byte modo
        {
            get { return _modo; }
            set
            {
                _modo = value;
            }
        }

        public Color CorFrente
        {
            get { return _CorFrente; }
            set
            {
                _CorFrente = value;
            }
        }

        public Color CorFundo
        {
            get { return _CorFundo; }
            set
            {
                _CorFundo = value;
            }
        }

        public int Left
        {
            get { return _left; }
            set { _left = value; }
        }

        public int Top
        {
            get { return _top; }
            set { _top = value; }
        }

        public int Largura
        {
            get { return _width; }
            set
            {
                _width = value;
            }
        }

        public int Altura
        {
            get { return _height; }
            set
            {
                _height = value;
            }
        }


        public string txt
        {
            get { return _txt; }
            set
            {
                _txt = value;
            }
        }

        public int OriginalIdx
        {
            get => _originalIdx;
            set => _originalIdx = value;
        }
        /*public double Angle
        {
            get => _angle;
            set => _angle = value;
        }*/

        public VisualControl()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            _modo = BARRA;
        }

        public override string ToString()
        {
            return "Visual Control - " + modo.ToString() + " - " + txt;
        }
    }
}
