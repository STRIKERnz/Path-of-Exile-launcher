using System;
using System.Security.Cryptography;
using System.Windows.Forms;


namespace PathOfExile_Launcher
{
    partial class Launcher
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.Button btnAddPath;
        private System.Windows.Forms.ListBox listBoxPaths;
        private System.Windows.Forms.Button btnRemovePath;
        //private System.Windows.Forms.Button btnCloseAllPrograms;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.btnAddPath = new System.Windows.Forms.Button();
            this.listBoxPaths = new System.Windows.Forms.ListBox();
            this.btnRemovePath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLaunch
            // 
            resources.ApplyResources(this.btnLaunch, "btnLaunch");
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // btnAddPath
            // 
            resources.ApplyResources(this.btnAddPath, "btnAddPath");
            this.btnAddPath.Name = "btnAddPath";
            this.btnAddPath.UseVisualStyleBackColor = true;
            this.btnAddPath.Click += new System.EventHandler(this.btnAddPath_Click);
            // 
            // listBoxPaths
            // 
            this.listBoxPaths.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxPaths, "listBoxPaths");
            this.listBoxPaths.Name = "listBoxPaths";
            this.listBoxPaths.SelectedIndexChanged += new System.EventHandler(this.listBoxPaths_SelectedIndexChanged);
            // 
            // btnRemovePath
            // 
            resources.ApplyResources(this.btnRemovePath, "btnRemovePath");
            this.btnRemovePath.Name = "btnRemovePath";
            this.btnRemovePath.UseVisualStyleBackColor = true;
            this.btnRemovePath.Click += new System.EventHandler(this.btnRemovePath_Click);
            // 
            // Launcher
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnAddPath);
            this.Controls.Add(this.listBoxPaths);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemovePath);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Launcher";
            this.ResumeLayout(false);

        }

        private void listBoxPaths_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }
    }
}
