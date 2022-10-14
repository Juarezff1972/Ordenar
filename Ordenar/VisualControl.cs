using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ordenar
{
    public class VisualControl : UserControl
    {
        public static byte BARRA { get { return 0; } }
        public static byte BOLA { get { return 1; } }
        public static byte LINHA { get { return 2; } }
        public static byte TRIANGULO { get { return 3; } }

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
                    BackColor = Color.Transparent;
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
                if (modo == BARRA)
                    this.BackColor = Color.FromArgb(255, _CorFundo);
                else
                    this.BackColor = Color.Transparent;
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
                if (Width > 10 && (modo == BARRA || modo == BOLA))
                {
                    info.Text = _txt;
                    f = info.Font;
                    info.Font = new Font(f.Name, Width / 3);
                    info.ForeColor = Color.White;
                    //info.Height = (int)f.SizeInPoints * f.Height;
                    info.BackColor = Color.Transparent;
                    info.FlatStyle = FlatStyle.Flat;
                    info.BorderStyle = BorderStyle.None;
                    info.AutoSize = true;
                }
                else
                {
                    info.Visible = false;
                }
            }
        }

        public VisualControl()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, false);
            SetStyle(ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.Transparent;

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
            _modo = BARRA;

            info.Location = new Point(1, 5);

            Controls.AddRange(new Control[]
            {
                    info
            });
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            PointF[] p;
            //if (gr != null) e.Graphics.Restore(gr);
            if (modo == BOLA)
            {
                SetStyle(ControlStyles.Opaque, false);
                _brush1 = new SolidBrush(CorFrente);
                _pen1 = new Pen(_brush1);
                _brush2 = new SolidBrush(CorFundo);
                _pen2 = new Pen(_brush1);
                e.Graphics.FillEllipse(_brush2, 0, 0, _width - 2, _width - 2);
                e.Graphics.DrawEllipse(_pen1, 0, 0, _width - 2, _width - 2);
                this.BackColor = Color.Transparent;
                //gr = e.Graphics.Save();
            }
            if (modo == LINHA)
            {
                SetStyle(ControlStyles.Opaque, false);
                _brush1 = new SolidBrush(CorFrente);
                _pen1 = new Pen(_brush1);
                e.Graphics.DrawLine(_pen1, _width / 2, 0, _width / 2, _height);
                this.BackColor = Color.Transparent;
                //gr = e.Graphics.Save();
            }
            if (modo == TRIANGULO)
            {
                SetStyle(ControlStyles.Opaque, false);
                _brush1 = new SolidBrush(CorFrente);
                _pen1 = new Pen(_brush1);
                _brush2 = new SolidBrush(CorFundo);
                _pen2 = new Pen(_brush1);
                p = new PointF[3];
                int w = _width / 3;
                p[0].X = _width / 2;
                p[0].Y = 0;
                p[1].X = (_width / 2) - w;
                p[1].Y = 2 * w;
                p[2].X = (_width / 2) + w;
                p[2].Y = 2 * w;
                e.Graphics.FillPolygon(_brush2, p);
                e.Graphics.DrawPolygon(_pen1, p);
                this.BackColor = Color.Transparent;
            }
            Draw(e.Graphics);
            base.OnPaint(e);
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            if (_modo != BARRA)
            {
                if (this.Parent != null)
                {
                    Parent.Invalidate(this.Bounds, true);
                }
            }
            base.OnBackColorChanged(e);
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            if (_modo != BARRA) this.Invalidate();
            base.OnParentBackColorChanged(e);
        }

        protected virtual void Draw(Graphics g)
        {

        }

        public override string ToString()
        {
            return "Visual Control - " + modo.ToString() + " - " + txt;
        }
    }
}
