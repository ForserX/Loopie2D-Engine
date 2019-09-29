using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace Loopie.Code.Content
{
   // [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class ContextBox : UserControl
    {
        public ContextBox()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // No
        }

        public void FastInit(string Image, string Text)
        {
            this.BackgroundImage = new Bitmap(Image);
            label1.Text = Text;

            this.Width = label1.Width + 4;
            this.Height = label1.Height + 4;
        }
    }
}
