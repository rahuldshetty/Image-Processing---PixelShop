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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {

        List<Tab> tabList;
        public Form1()
        {
            
            InitializeComponent();
            tabList = new List<Tab>();


        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                if(dlg.ShowDialog()==DialogResult.OK)
                {
                    Tab tb = new Tab(chart1);
                    tb.loadImage(new Bitmap(dlg.FileName));
                    tb.filepath = dlg.FileName;
                    tb.filename = System.IO.Path.GetFileName(dlg.FileName);
                    tb.tab.Text = tb.filename;
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
                    MetroFramework.MetroMessageBox.Show(this, "Save your changes before closing.", "Save Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MetroFramework.MetroMessageBox.Show(this, "Save your changes before closing.", "Save Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void histogramEquilizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].performHisto();
        }

        private void deNoiseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void diffuseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pixelateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void waterSwirlToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void brigthnessAndContrastToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void solarizeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void oldPhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void laplacianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].laplacian();
        }

        private void laplacianOfGaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].LGauss();

        }

        private void inverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].invert();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            trackBar1.Value = tabList[selectedTab].currentBrightness;
            trackBar2.Value = tabList[selectedTab].currentContrast;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
          
        }

        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dilationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].dilation(3,3);
        }

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].erosion(3, 3);
        }

        private void dilation5X5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].dilation(5, 5);
        }

        private void erosion5X5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].erosion(5, 5);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].erosion(3, 3);
            tabList[selectedTab].dilation(3, 3);

        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].dilation(3, 3);
            tabList[selectedTab].erosion(3, 3);
           
        }

        private void prewittHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].prewittHorizontal();
        }

        private void prewittVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].prewittVertical();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void previourTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int prevTab = (getSelectedTab() - 1);
            if (prevTab < 0) prevTab += tabList.Count;
            tabControl1.SelectedTab = tabList[prevTab].tab;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].undo();
        }

        private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int nextTab = (getSelectedTab()+1) % tabList.Count;
            tabControl1.SelectedTab = tabList[nextTab].tab;           
            
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].updateBrightness(trackBar1.Value);
        }

        private void trackBar2_Scroll(object sender, ScrollEventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].updateContrast(trackBar2.Value);
        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void heloToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            File.Show(metroLink1, 0, metroLink1.Height);
        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            Edit.Show(metroLink2, 0, metroLink2.Height);
        }

        private void metroLink3_Click(object sender, EventArgs e)
        {
            View.Show(metroLink3, 0, metroLink3.Height);
        }

        private void metroLink4_Click(object sender, EventArgs e)
        {
            Image.Show(metroLink4, 0, metroLink4.Height);
        }

        private void metroLink5_Click(object sender, EventArgs e)
        {
            Adjustments.Show(metroLink5, 0, metroLink5.Height);
        }

        private void metroLink6_Click(object sender, EventArgs e)
        {
            Help.Show(metroLink6, 0, metroLink6.Height);
        }

      
    }
        



}
