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
            changeProgress();
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                if(dlg.ShowDialog()==DialogResult.OK)
                {
                    Tab tb = new Tab(chart1,chart2,chart3);
                    tb.loadImage(new Bitmap(dlg.FileName));
                    tb.filepath = dlg.FileName;
                    tb.filename = System.IO.Path.GetFileName(dlg.FileName);
                    tb.tab.Text = tb.filename;
                    tabControl1.TabPages.Add(tb.tab);
                    tabList.Add(tb);
                    tabControl1.SelectedTab = tb.tab;
                    metroToggle1.Checked = metroToggle2.Checked=metroToggle3.Checked = true;
                }
            }
            changeProgress();

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
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


        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            changeProgress();
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                if(dlg.ShowDialog()==DialogResult.OK)
                {
                    int selectedTab = getSelectedTab();
                    tabList[selectedTab].saveImage(dlg.FileName);
                    
                }
            }
            changeProgress();
        }

        private void closeToolStripMenuItem2_Click(object sender, EventArgs e)
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

        private void grayscaleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].convertToGray();
            changeProgress();
        }

        private void horizontalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].flipHorizontal();
            changeProgress();
        }

        private void verticalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].flipVertical();
            changeProgress();
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void cCWToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].rotateImage90CCW();
            changeProgress();
        }

        private void cWToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].rotateImage90CW();
            changeProgress();
        }

        private void boxMeanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].meanBlur();
            changeProgress();
        }

        private void lowToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].findEdgeMedium();
            changeProgress();
        }

        private void mediumToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].findEdgeMedium();
        }

        private void highToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int selectedTab = getSelectedTab();
            tabList[selectedTab].findEdgeHigh();
            changeProgress();
        }

        private void gaussian3X3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].gaussBlur();
            changeProgress();
        }

        private void gaussian5X5ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].gaussBlurHigh();
            changeProgress();
        }

      


        private void sobelHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].sobelHorizontal();
            changeProgress();
        }

        private void sobelVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].sobelVertical();
            changeProgress();
        }

        private void lowToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].sharpen();
            changeProgress();
        }

        private void mediumToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].sharpenMed();
            changeProgress();
        }

        private void highToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].sharpenHigh();
            changeProgress();
        }

        private void embossToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].emobss();
            changeProgress();
        }

        private void imageToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void histogramEquilizationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].performHisto(false);
            changeProgress();
        }

      

        private void laplacianToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].laplacian();
            changeProgress();
        }

        private void laplacianOfGaussianToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].LGauss();
            changeProgress();

        }

        private void invertToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].invert();
            changeProgress();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           

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

        private void x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].dilation(3,3);
            changeProgress();
        }

        private void x3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].erosion(3, 3);
            changeProgress();
        }

        private void x5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].dilation(5, 5);
            changeProgress();
        }

        private void x5ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].erosion(5, 5);
            changeProgress();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].erosion(3, 3);
            tabList[selectedTab].dilation(3, 3);
            changeProgress();

        }

        private void closeToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].dilation(3, 3);
            tabList[selectedTab].erosion(3, 3);
            changeProgress();
        }



        private void prewittToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].prewittVertical();
            changeProgress();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void previousTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeProgress();
            int prevTab = (getSelectedTab() - 1);
            if (prevTab < 0) prevTab += tabList.Count;
            tabControl1.SelectedTab = tabList[prevTab].tab;
            changeProgress();
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].undo();
            changeProgress();
        }

        private void nextTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeProgress();
            int nextTab = (getSelectedTab()+1) % tabList.Count;
            tabControl1.SelectedTab = tabList[nextTab].tab;
            changeProgress();


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
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].updateBrightness(trackBar1.Value);
            changeProgress();
        }

        private void trackBar2_Scroll(object sender, ScrollEventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].updateContrast(trackBar2.Value);
            changeProgress();
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

      
        private void metroLink7_Click(object sender, EventArgs e)
        {
            Filters.Show(metroLink7, 0, metroLink7.Height);
        }

        private void metroLink6_Click_1(object sender, EventArgs e)
        {
            Help.Show(metroLink6, 0, metroLink6.Height);
        }

        private void skeletonizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].perimeter();
            changeProgress();
        }

        private void tabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            trackBar1.Value = tabList[selectedTab].currentBrightness;
            trackBar2.Value = tabList[selectedTab].currentContrast;
            tabList[selectedTab].updateHistographh();

            Tab tab = tabList[selectedTab];
            metroToggle1.Checked =tab.redOn;
            metroToggle2.Checked = tab.greenOn;
            metroToggle3.Checked = tab.blueOn;

            changeProgress();
        }



        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Form2 f2 = new Form2(); 
            f2.ShowDialog();

        }

        private void metroLink8_Click(object sender, EventArgs e)
        {

        }

        private void metroLink10_Click(object sender, EventArgs e)
        {

        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].updateComponent(metroToggle1.Checked,metroToggle2.Checked,metroToggle3.Checked);
            changeProgress();
        }

        private void metroToggle2_CheckedChanged(object sender, EventArgs e)
        {
            changeProgress();
            int selectedTab = getSelectedTab();
            tabList[selectedTab].updateComponent(metroToggle1.Checked, metroToggle2.Checked, metroToggle3.Checked);
            changeProgress();
        }

        private void metroToggle3_CheckedChanged(object sender, EventArgs e)
        {
            changeProgress();
                int selectedTab = getSelectedTab();
                tabList[selectedTab].updateComponent(metroToggle1.Checked, metroToggle2.Checked, metroToggle3.Checked);
            changeProgress();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void histogramEquilizationColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeProgress();
                int selectedTab = getSelectedTab();
                tabList[selectedTab].performHisto(true);
            changeProgress();
        }


        private void changeProgress()
        {
            if (metroLabel4.Text == "Idle")
            {
                metroLabel4.Text = "Processing....";
            }
            else
                metroLabel4.Text = "Idle";
        }

    }
        



}
