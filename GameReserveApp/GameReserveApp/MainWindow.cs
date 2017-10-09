using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace GameReserveApp
{
    public partial class MainWindow : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static log4net.ILog Log { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
        }

        private void category_strip_click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            ChangeButtonColor(category_strip);
            foreach (Form form in this.MdiChildren)
            {
                if (form is CategoryListWindow)
                {
                    form.BringToFront();
                    this.ResumeLayout();
                    return;
                }
            }

            CategoryListWindow configure = new CategoryListWindow();
            configure.MdiParent = this;
            configure.FormBorderStyle = FormBorderStyle.None;
            configure.ControlBox = false;
            configure.MaximizeBox = false;
            configure.MinimizeBox = false;
            configure.Dock = DockStyle.Fill;
            configure.Show();
            this.ResumeLayout();
            log.Info("Category tab");

        }

        private void device_strip_Click(object sender, EventArgs e)
        {

        }

        private void allocation_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            ChangeButtonColor(allot_device_strip);
            foreach (Form form in this.MdiChildren)
            {
                if (form is AnimalListWindow)
                {
                    form.BringToFront();
                    this.ResumeLayout();
                    return;
                }
            }
            AnimalListWindow configure = new AnimalListWindow();
            configure.MdiParent = this;
            configure.FormBorderStyle = FormBorderStyle.None;
            configure.ControlBox = false;
            configure.MaximizeBox = false;
            configure.MinimizeBox = false;
            configure.Dock = DockStyle.Fill;
            configure.Show();
            this.ResumeLayout();

        }

        private void report_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            ChangeButtonColor(map_strip);
            foreach (Form form in this.MdiChildren)
            {
                if (form is Report)
                {
                    form.BringToFront();
                    this.ResumeLayout();
                    return;
                }
            }
            Report configure = new Report();
            configure.MdiParent = this;
            configure.FormBorderStyle = FormBorderStyle.None;
            configure.ControlBox = false;
            configure.MaximizeBox = false;
            configure.MinimizeBox = false;
            configure.Dock = DockStyle.Fill;
            configure.Show();
            this.ResumeLayout();

        }

        private void locate_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            ChangeButtonColor(map_strip);
            foreach (Form form in this.MdiChildren)
            {
                if (form is LocateAnimals)
                {
                    form.BringToFront();
                    this.ResumeLayout();
                    return;
                }
            }
            LocateAnimals configure = new LocateAnimals();
            configure.MdiParent = this;
            configure.FormBorderStyle = FormBorderStyle.None;
            configure.ControlBox = false;
            configure.MaximizeBox = false;
            configure.MinimizeBox = false;
            configure.Dock = DockStyle.Fill;
            configure.Show();
            this.ResumeLayout();

        }

        private void ChangeButtonColor(ToolStrip selectedButton)
        {
            foreach (var strip in sidePanel.Controls.OfType<ToolStrip>())
            {
                foreach (var item in strip.Items)
                {
                    if (item.GetType() == typeof(ToolStrip))
                    {
                        ToolStrip button = (ToolStrip)item;
                        if (button == selectedButton)
                        {
                            button.BackColor = Color.FromArgb(0, 0, 154);
                        }
                        else
                        {
                            button.BackColor = Color.Transparent;
                        }
                    }
                }
            }
        }

    }
}
