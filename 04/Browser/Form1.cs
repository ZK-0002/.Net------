using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Browser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Add(new TreeNode("Computer", DriveInfo.GetDrives()
                .Select(x => new TreeNode(x.Name) { Tag = x }).ToArray())
            { Tag = "root" });
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Cast<TreeNode>().ToList().ForEach(x =>
                {
                    try
                    {
                        if (x.Nodes.Count == 0)
                        {
                            TreeNode[] nodes = new TreeNode[] { };
                            if (x.Tag.GetType() == typeof(DriveInfo))
                            {
                                var item = x.Tag as DriveInfo;
                                nodes = Directory.GetDirectories(item.Name)
                                    .Select(y => new DirectoryInfo(y))
                                    .Select(y => new TreeNode(y.Name) { Tag = y })
                                    .ToArray();
                            }
                            if (x.Tag.GetType() == typeof(DirectoryInfo))
                            {
                                var item = x.Tag as DirectoryInfo;
                                nodes = Directory.GetDirectories(item.FullName)
                                    .Select(y => new DirectoryInfo(y))
                                    .Select(y => new TreeNode(y.Name) { Tag = y })
                                    .ToArray();
                            }
                            x.Nodes.AddRange(nodes);
                        }
                    }
                    catch { }
                });
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView1.Items.Clear();

            if (e.Node.Tag != null)
            {
                string selectedPath = e.Node.Tag.ToString();

                if (Directory.Exists(selectedPath))
                {
                    DirectoryInfo[] directories = new DirectoryInfo(selectedPath).GetDirectories();
                    FileInfo[] files = new DirectoryInfo(selectedPath).GetFiles();

                    foreach (DirectoryInfo directory in directories)
                    {
                        listView1.Items.Add(new ListViewItem(new string[] { directory.Name, "Folder", "", directory.CreationTime.ToString() }));
                    }

                    foreach (FileInfo file in files)
                    {
                        string extension = file.Extension.ToLower();
                        string fileType = "File";
                        string fileSize = (file.Length / 1024).ToString() + "KB";

                        if (extension == ".exe")
                        {
                            fileType = "Executable";
                        }
                        else if (extension == ".txt")
                        {
                            fileType = "Text File";
                        }

                        listView1.Items.Add(new ListViewItem(new string[] { file.Name, fileType, fileSize, file.CreationTime.ToString() }));
                    }
                }
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string filePath = Path.Combine(treeView1.SelectedNode.Tag.ToString(), listView1.SelectedItems[0].Text);

                if (File.Exists(filePath))
                {
                    string extension = Path.GetExtension(filePath).ToLower();

                    if (extension == ".exe")
                    {
                        System.Diagnostics.Process.Start(filePath);
                    }
                    else if (extension == ".txt")
                    {
                        System.Diagnostics.Process.Start("notepad.exe", filePath);
                    }
                }
            }
        }
    }
}
