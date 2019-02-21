using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PixWork
{
    public partial class Form1 : Form
    {

        List<Tab> tabList;

        public Form1()
        {
            tabList = new List<Tab>();
            InitializeComponent();
        }

        private void newImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                if(dlg.ShowDialog()==DialogResult.OK)
                {
                    Tab tb = new Tab();
                    tb.loadImage(new Bitmap(dlg.FileName));
                    tb.filepath = dlg.FileName;
                    tb.tab.Text = dlg.FileName;
                    tabControl1.TabPages.Add(tb.tab);
                    tabList.Add(tb);
                    tabControl1.SelectedTab = tb.tab;

                }
            }


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                if(dlg.ShowDialog()==DialogResult.OK)
                {
                    int selectedTab = getSelectedTab();
                    tabList[selectedTab].saveImage(dlg.FileName);
                    
                }
            }

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            if(tabList[selectedTab].getChangeState()==false)
            {
                MessageBox.Show("Save your changes before closing.","Save Prompt");
            }
            else
            {
                tabControl1.TabPages.Remove(tabList[selectedTab].tab);
                tabList.Remove(tabList[selectedTab]);
            }

        }

        int getSelectedTab()
        {
            return tabControl1.SelectedIndex; 
        }

    }

    class Tab
    {
        public PictureBox pictureBox;
        public string filepath;
        public TabPage tab;
        public Bitmap bitmap;

        private bool isChangesSaved;

        public Tab()
        {
            tab = new TabPage();
            pictureBox = new PictureBox();
            pictureBox.Parent = tab;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.BringToFront();
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            tab.AutoScroll = true;
            isChangesSaved = true;


        }

        public void loadImage(Bitmap image)
        {
            bitmap = image;
            pictureBox.Image = image;
        }

        
        public void saveImage(string path)
        {
            filepath = path;
            tab.Text = path;
            bitmap.Save(path);
            isChangesSaved = true;
        }

        public bool getChangeState()
        {
            return isChangesSaved;
        }

    }



}
