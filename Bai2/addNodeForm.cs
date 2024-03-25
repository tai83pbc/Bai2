using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai2
{
    public partial class addNodeForm : Form
    {
        private string _text;
        public string text
        {
            get
            {
                _text = txt_Name.Text;
                return _text;
            }
        }
        public addNodeForm()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
