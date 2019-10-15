namespace ProdScan
{
    partial class ProdJour
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.fluentTheme1 = new Telerik.WinControls.Themes.FluentTheme();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radWaitingBar1 = new Telerik.WinControls.UI.RadWaitingBar();
            this.fadingRingWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.FadingRingWaitingBarIndicatorElement();
            this.radDateTimePicker1 = new Telerik.WinControls.UI.RadDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            this.radGridView1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDateTimePicker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGridView1
            // 
            this.radGridView1.Controls.Add(this.radWaitingBar1);
            this.radGridView1.Controls.Add(this.radDateTimePicker1);
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowDeleteRow = false;
            this.radGridView1.MasterTemplate.AllowDragToGroup = false;
            this.radGridView1.MasterTemplate.AllowEditRow = false;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridView1.MasterTemplate.MultiSelect = true;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ShowNoDataText = false;
            this.radGridView1.Size = new System.Drawing.Size(568, 323);
            this.radGridView1.TabIndex = 0;
            this.radGridView1.ThemeName = "Fluent";
            // 
            // radWaitingBar1
            // 
            this.radWaitingBar1.BackColor = System.Drawing.Color.White;
            this.radWaitingBar1.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.radWaitingBar1.Location = new System.Drawing.Point(249, 126);
            this.radWaitingBar1.Name = "radWaitingBar1";
            this.radWaitingBar1.ShowText = true;
            this.radWaitingBar1.Size = new System.Drawing.Size(70, 70);
            this.radWaitingBar1.TabIndex = 2;
            this.radWaitingBar1.Text = "Chargement";
            this.radWaitingBar1.ThemeName = "Fluent";
            this.radWaitingBar1.Visible = false;
            this.radWaitingBar1.WaitingIndicators.Add(this.fadingRingWaitingBarIndicatorElement1);
            this.radWaitingBar1.WaitingIndicatorSize = new System.Drawing.Size(100, 14);
            this.radWaitingBar1.WaitingStep = 8;
            this.radWaitingBar1.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.FadingRing;
            // 
            // fadingRingWaitingBarIndicatorElement1
            // 
            this.fadingRingWaitingBarIndicatorElement1.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.fadingRingWaitingBarIndicatorElement1.BackColor2 = System.Drawing.Color.White;
            this.fadingRingWaitingBarIndicatorElement1.BackColor3 = System.Drawing.Color.White;
            this.fadingRingWaitingBarIndicatorElement1.BackColor4 = System.Drawing.Color.White;
            this.fadingRingWaitingBarIndicatorElement1.Name = "fadingRingWaitingBarIndicatorElement1";
            this.fadingRingWaitingBarIndicatorElement1.Text = "Chargement";
            this.fadingRingWaitingBarIndicatorElement1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            // 
            // radDateTimePicker1
            // 
            this.radDateTimePicker1.CalendarSize = new System.Drawing.Size(290, 320);
            this.radDateTimePicker1.Location = new System.Drawing.Point(202, 0);
            this.radDateTimePicker1.Name = "radDateTimePicker1";
            this.radDateTimePicker1.Size = new System.Drawing.Size(164, 24);
            this.radDateTimePicker1.TabIndex = 1;
            this.radDateTimePicker1.TabStop = false;
            this.radDateTimePicker1.Text = "mardi 8 octobre 2019";
            this.radDateTimePicker1.ThemeName = "Fluent";
            this.radDateTimePicker1.Value = new System.DateTime(2019, 10, 8, 12, 21, 0, 822);
            this.radDateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // ProdJour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 323);
            this.Controls.Add(this.radGridView1);
            this.Name = "ProdJour";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProdJour";
            this.ThemeName = "Fluent";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.radGridView1.ResumeLayout(false);
            this.radGridView1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDateTimePicker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.FluentTheme fluentTheme1;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker1;
        private Telerik.WinControls.UI.RadWaitingBar radWaitingBar1;
        private Telerik.WinControls.UI.FadingRingWaitingBarIndicatorElement fadingRingWaitingBarIndicatorElement1;
    }
}
