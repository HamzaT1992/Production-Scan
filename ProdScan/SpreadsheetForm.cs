﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ProdScan
{
    public partial class SpreadsheetForm : Telerik.WinControls.UI.RadForm
    {
        public SpreadsheetForm()
        {
            InitializeComponent();
            ((RadRibbonFormBehavior)this.FormBehavior).AllowTheming = false;
        }
    }
}