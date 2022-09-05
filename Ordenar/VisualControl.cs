using System.Drawing;
using System.Windows.Forms;

namespace Ordenar
{
    public class VisualControl : UserControl
    {
        private string _txt;
        private Font f;

        private Label info;

        public string txt
        {
            get { return _txt; }
            set
            {
                _txt = value;
                if (Width > 10)
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

            info.Location = new Point(1, 5);

            Controls.AddRange(new Control[]
            {
                    info
            });
        }
    }
}
