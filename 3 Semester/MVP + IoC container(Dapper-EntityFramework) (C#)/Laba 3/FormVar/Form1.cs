using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Domain;

namespace FormVar
{
    public partial class Form1 : Form
    {
        SQLEmpRepository rep = new SQLEmpRepository();
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void DataListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
