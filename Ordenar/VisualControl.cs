using System.Drawing;
using System.Windows.Forms;

namespace Ordenar
{
    public class VisualControl : UserControl
    {
        public static byte BARRA { get { return 0; } }
        public static byte BOLA { get { return 1; } }
        public static byte LINHA { get { return 2; } }

        private string _txt;
        private Font f;
        private byte _modo;
        private Color _CorFrente;
        private Color _CorFundo;
        private int _width;
        private int _height;
        private Pen _pen1;
        private Brush _brush1;
        private Pen _pen2;
        private Brush _brush2;

        private Label info;

        public byte modo
        {
            get { return _modo; }
            set
            {
                _modo = value;
                if (_modo != BARRA)
                {
                    BorderStyle = BorderStyle.None;
                }
                else
                {
                    BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }

        public Color CorFrente
        {
            get { return _CorFrente; }
            set
            {
                _CorFrente = value;
                if (modo == BARRA) this.ForeColor = _CorFrente;
            }
        }

        public Color CorFundo
        {
            get { return _CorFundo; }
            set
            {
                _CorFundo = value;
                if (modo == BARRA) this.BackColor = _CorFundo;
            }
        }

        public int Largura
        {
            get { return _width; }
            set
            {
                _width = value;
                this.Width = _width;
            }
        }

        public int Altura
        {
            get { return _height; }
            set
            {
                _height = value;
                this.Height = _height;
            }
        }


        public string txt
        {
            get { return _txt; }
            set
            {
                _txt = value;
                if (Width > 10 && modo == BARRA)
                {
                    info.Text = _txt;
                    f = info.Font;
                    info.Font = new Font(f.Name, Width / 3);
                    info.ForeColor = Color.White;
                    info.Height = (int)f.SizeInPoints * f.Height;
                }
                else
                {
                    info.Visible = false;
                }
            }
        }

        public VisualControl()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            info = new Label();
            info.Text = " ";
            _CorFrente = this.ForeColor;
            _CorFundo = this.BackColor;
            _width = this.Width;
            _height = this.Height;
            _modo = 0;

            info.Location = new Point(1, 5);

            Controls.AddRange(new Control[]
            {
                    info
            });
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_modo == BOLA)
            {
                _brush1 = new SolidBrush(CorFrente);
                _pen1 = new Pen(_brush1);
                _brush2 = new SolidBrush(CorFundo);
                _pen2 = new Pen(_brush1);
                e.Graphics.DrawEllipse(_pen1, 0, 0, _width - 2, _width - 2);
                e.Graphics.FillEllipse(_brush2, 0, 0, _width - 2, _width - 2);
            }
            if (_modo==LINHA)
            {
                _brush1 = new SolidBrush(CorFrente);
                _pen1 = new Pen(_brush1);
                e.Graphics.DrawLine(_pen1, _width / 2, 0, _width / 2, _height);
            }
        }
    }
}
