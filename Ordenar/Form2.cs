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
    public partial class Form2 : Form
    {
        public string txt
        {
            get { return algoTxt.Text; }
            set { algoTxt.Text = value; }
        }

        public Form2()
        {
            InitializeComponent();
        }
    }
}
