using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loopie.Code.Content
{
    public partial class ClickableObj : UserControl
    {
        public ClickableObj(string Image)
        {
            InitializeComponent();
            this.BackgroundImage = new Bitmap(Image);
            this.MouseClick += MouseClickHandle;
        }

        private void MouseClickHandle(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Soon");
        }

        private void ClickableObj_Load(object sender, EventArgs e)
        {

        }
    }
}
