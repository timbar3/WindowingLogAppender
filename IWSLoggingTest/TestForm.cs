/*
   Copyright 2012 Intraweb Software Limited

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 */
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
