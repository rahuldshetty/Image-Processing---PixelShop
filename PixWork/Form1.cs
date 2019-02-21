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
            foreach(Tab tb in tabList)
            {
                if(tb.getChangeState()== false)
                {
                    MessageBox.Show("Save your changes before closing.", "Save Prompt");
                    return;
                }
            }
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

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].convertToGray();
        }

    }

    class Tab
    {
        public PictureBox pictureBox;
        public string filepath;
        public TabPage tab;
        public Bitmap bitmap;
        public int width, height;

        private bool isChangesSaved;
        private bool isGray;

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
            isGray = false;


        }

        public void loadImage(Bitmap image)
        {
            bitmap = image;
            pictureBox.Image = image;
            width = bitmap.Width;
            height = bitmap.Height;
        }

        
        public void saveImage(string path)
        {
            filepath = path;
            tab.Text = path;
            bitmap.Save(path);
            isChangesSaved = true;
            tab.Text = filepath;
        }

        public bool getChangeState()
        {
            return isChangesSaved;
        }

        public void convertToGray()
        {
            Bitmap temp = new Bitmap(width, height);
            for(int i=0;i<width;i++)
                for(int j=0;j<height;j++)
                {
                    Color pixel = bitmap.GetPixel(i, j);
                    int grayscale = (int)(pixel.R * 0.3) + (int)(pixel.G * 0.59) + (int)(pixel.B * 0.11);
                    Color newpixel = Color.FromArgb(grayscale, grayscale, grayscale);
                    temp.SetPixel(i, j, newpixel);

                }
            isGray = true;
        
            updateChange();

             bitmap = temp;
            pictureBox.Image = bitmap;

        }

        public void updateChange()
        {
            isChangesSaved = false;
            tab.Text += "*";
        }
        

    }



}
