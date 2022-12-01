using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sistemdeparticule
{
    public partial class particula : UserControl
    {
        public particula()
        {
            InitializeComponent();
        }
        public int life = 50;
        public int startLeft = 0;
        public int startTop = 0;

        private void particula_Load(object sender, EventArgs e)
        {

        }
    }
}
