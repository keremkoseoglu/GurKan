using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gurkan
{
    public partial class FormTest : Form
    {
        private string trText, arText;
        private string sqlTr, sqlAr;

        public FormTest()
        {
            InitializeComponent();
        }

        private void FormTest_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            // Disable
            btnTest.Enabled = false;

            // Temizlik
            clearLog();

            // SAP Testi
            appendLog("SAP baðlantýsý test ediliyor...");
            try
            {
                trText = arText = "";
                Program.sap.testConnection(out trText, out arText);
                appendLog("Baðlantý baþarýlý, dönen sonuçlar: ");
                appendLog("Türkçe metin: " + trText);
                appendLog("Arapça metin: " + arText);
            }
            catch (Exception ex)
            {
                appendLog(ex.ToString());
            }

            // SQL baðlantý testi
            appendLog("Veritabaný baðlantý testi yürütülüyor...");
            try
            {
                Program.sql = new SQL();
                Program.sql.connect();
                Program.sql.disconnect();
                appendLog("Veritabanýn baðlantý testi baþarýlý...");
            }
            catch (Exception ex)
            {
                appendLog(ex.ToString());
            }

            // SQL INSERT test
            appendLog("Veritabanýna kayýt atma testi yürütülüyor...");
            try
            {
                Program.sql = new SQL();
                Program.sql.connect();
                Program.sql.insertTestData(trText, arText);
                Program.sql.disconnect();
                appendLog("Veritabanýna kayýt atma testi baþarýlý...");
            }
            catch (Exception ex)
            {
                appendLog(ex.ToString());
            }

            // SQL READ test
            appendLog("Veritabanýndan kayýt okuma testi yürütülüyor...");
            try
            {
                Program.sql = new SQL();
                Program.sql.connect();
                Program.sql.getTestData(out sqlTr, out sqlAr);
                Program.sql.disconnect();
                appendLog("Veritabanýndan kayýt okuma testi baþarýlý...");
                appendLog("Okunan Türkçe metin: " + sqlTr);
                appendLog("Okunan Arapça metin: " + sqlAr);
            }
            catch (Exception ex)
            {
                appendLog(ex.ToString());
            }

            // Yazýcý testi
            appendLog("Yazýcý test ediliyor...");
            try
            {
                printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                    appendLog("Yazcýya çýktý gönderildi...");
                }
                else
                {
                    appendLog("Yazýcý testini iptal ettiniz...");
                }
            }
            catch (Exception ex)
            {
                appendLog(ex.ToString());
            }

            // Kantar testi (bu en sonda olsun)
            appendLog("Kantar test ediliyor...");
            try
            {
                Program.steelyard.weightCaptured += new Steelyard.WeightCapturedDelegate(steelyard_weightCaptured);
                Program.steelyard.getWeight();
            } catch (Exception ex)
            {
                appendLog(ex.ToString());
            }
        }

        void steelyard_weightCaptured(object sender, SteelyardWeightCapturedEventArgs e)
        {
            appendLog("Kantar aðýrlýðý alýndý: " + e.weight.ToString());
            appendLog("Testler tamamlandý...");
            btnTest.Enabled = true;
        }

        private void clearLog()
        {
            txtOutput.Text = "";
        }

        private void appendLog(string Text)
        {
            if (txtOutput.Text.Length > 0) txtOutput.Text += "\r\n";
            txtOutput.Text += Text;
            Application.DoEvents();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("TR Karakter Testi: " + sqlTr, txtOutput.Font, Brushes.Black, 100, 100);
            e.Graphics.DrawString("AR Karakter Testi: " + sqlAr, txtOutput.Font, Brushes.Black, 100, 150);
        }
    }
}