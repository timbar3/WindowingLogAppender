using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IWSLoggingTest
{
    public partial class TestForm : Form
    {
        private readonly ILog log = LogManager.GetLogger("IWSLoggingTest.Form1.cs");

        public TestForm()
        {
            log4net.Config.XmlConfigurator.Configure();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.Debug("Logging a debug message");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            log.Debug("Fatal error", new NotSupportedException("Just not supported"));
        }
    }
}
