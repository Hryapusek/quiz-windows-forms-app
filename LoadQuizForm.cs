using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tema6
{
    public partial class LoadQuizForm : Form
    {
        public DialogResult result = DialogResult.Cancel;

        public String PathToFile { get; private set; }

        public LoadQuizForm()
        {
            InitializeComponent();
        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Xml Documents|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK) {
                PathToFile = ofd.FileName;
                result = DialogResult.OK;
                this.Close();
            }
        }
    }
}
