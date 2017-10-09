using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameReserveApp
{
    public partial class PopUpControl : Form
    {
        public PopUpControl(string message)
        {
            InitializeComponent();
            popUpMessageLabel.Text = message;
           
        }

        /// <summary>
        /// Ok button click function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }      

       
    }
}
