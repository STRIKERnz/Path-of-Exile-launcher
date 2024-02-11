using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;

namespace PathOfExile_Launcher
{
    public partial class Launcher : Form
    {
        private string iniFilePath = "settings.ini";
        private int selectedProgramPath = 0;
        private List<string> allProgramPaths = new List<string>();
        private List<string> processList = new List<string>();




        public Launcher()
        {
            InitializeComponent();
            LoadSettings();

        }

        private void btnAddPath_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files|*.*|AutoHotKey Files|*.ahk|Shortcut Files|*.lnk";
                openFileDialog.Title = "Select a Program";

                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog.FileName))
                {
                    string newPath = openFileDialog.FileName;
                    allProgramPaths.Add(newPath);

                    // Display the new path in a ListBox or another appropriate control
                    listBoxPaths.Items.Add(newPath);
                }
            }
        }

        private void btnRemovePath_Click(object sender, EventArgs e)
        {
            // Check if an item is selected in the ListBox
            if (listBoxPaths.SelectedItem != null)
            {
                // Remove the selected item from the ListBox and the additionalProgramPaths list
                string selectedPath = listBoxPaths.SelectedItem.ToString();
                listBoxPaths.Items.Remove(selectedPath);
                allProgramPaths.Remove(selectedPath);
            }
            else
            {
                MessageBox.Show("Please select a path to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CloseAllOpenedPrograms()
        {
            ////foreach (var path in allProgramPaths)
            ////{
            ////    try
            ////    {

            ////        //string processName = Path.GetFileNameWithoutExtension(path);
            ////        //Process.GetProcessesByName(processName).ToList().ForEach(p => p.Kill());
            ////    }
            ////    catch (Exception ex)
            ////    {
            ////        MessageBox.Show($"Error closing program: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ////    }
            ////}

            //foreach (var program in processList)
            //{
            //    if (program == "PathOfExile.exe")
            //    {
            //        Process.GetProcessesByName("Path of Exile").ToList().ForEach(p => p.Kill());
            //        continue;
            //    }

            //    Process.GetProcessesByName(program).ToList().ForEach(p => p.Kill());
            //}
        }

        private void btnCloseAllPrograms_Click(object sender, EventArgs e)
        {
            CloseAllOpenedPrograms();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(allProgramPaths[selectedProgramPath]) && File.Exists(allProgramPaths[selectedProgramPath]))
            {
                try
                {
                    // Minimize the launcher
                    this.WindowState = FormWindowState.Minimized;

                    // Launch additional programs
                    foreach (var path in allProgramPaths)
                    {
                        string additionalProgramDirectory = Path.GetDirectoryName(path);

                        ProcessStartInfo additionalStartInfo = new ProcessStartInfo
                        {
                            FileName = path,
                            WorkingDirectory = additionalProgramDirectory
                        };

                        Process startedProgram = Process.Start(additionalStartInfo);
                       // MessageBox.Show($"Program {startedProgram.ProcessName}","info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       processList.Add(startedProgram.ProcessName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error launching program: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a valid program path before launching.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSettings()
        {
            if (File.Exists(iniFilePath))
            {
                try
                {
                    // Read all lines from the ini file
                    string[] _allProgramPaths = File.ReadAllLines(iniFilePath);

                    // Ensure there is at least one path
                    if (_allProgramPaths.Length > 0)
                    {
                        allProgramPaths.AddRange(_allProgramPaths);

                        // Update the ListBox or another appropriate control with additional paths
                        listBoxPaths.Items.AddRange(allProgramPaths.ToArray());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveSettings()
        {
            try
            {
                // Write all paths to the ini file
                File.WriteAllLines(iniFilePath, allProgramPaths);

                MessageBox.Show("Settings saved successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
