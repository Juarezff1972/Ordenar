using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ordenar
{
    public partial class Form3 : Form
    {
        private float _max;
        private float _pb;

        public float max
        {
            get
            {
                return _max;
            }
            set
            {
                _max = value;
                progressBar1.Maximum = (int)_max;
            }
        }

        public float pb
        {
            get
            {
                return _pb;
            }
            set
            {
                _pb = value;
                progressBar1.Value = (int)_pb;
                this.Text = ((int)_pb).ToString();
            }
        }

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = "0";
        }
    }
}
