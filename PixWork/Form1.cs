using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].flipHorizontal();
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].flipVertical();
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].invert();
        }

        private void cCWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].rotateImage90CCW();
        }

        private void cWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].rotateImage90CW();
        }

        private void boxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].meanBlur();
        }

        private void lowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].findEdgeLow();
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].findEdgeMedium();
        }

        private void highToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].findEdgeHigh();
        }

        private void gaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].gaussBlur();
        }

        private void gaussian5X5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].gaussBlurHigh();
        }

      

        private void sobelEdgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].sobelHorizontal();
        }

        private void sobelEdgeVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].sobelVertical();
        }

        private void sharpenLowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].sharpen();
        }

        private void sharpenMediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].sharpenMed();
        }

        private void sharpenHighToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].sharpenHigh();
        }

        private void embossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].emobss();
        }

        private void imageToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
        



}
