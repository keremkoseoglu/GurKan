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
            appendLog("SAP ba�lant�s� test ediliyor...");
            try
            {
                trText = arText = "";
                Program.sap.testConnection(out trText, out arText);
                appendLog("Ba�lant� ba�ar�l�, d�nen sonu�lar: ");
                appendLog("T�rk�e metin: " + trText);
                appendLog("Arap�a metin: " + arText);
            }
            catch (Exception ex)
            {
                appendLog(ex.ToString());
            }

            // SQL ba�lant� testi
            appendLog("Veritaban� ba�lant� testi y�r�t�l�yor...");
            try
            {
                Program.sql = new SQL();
                Program.sql.connect();
                Program.sql.disconnect();
                appendLog("Veritaban�n ba�lant� testi ba�ar�l�...");
            }
            catch (Exception ex)
            {
                appendLog(ex.ToString());
            }

            // SQL INSERT test
            appendLog("Veritaban�na kay�t atma testi y�r�t�l�yor...");
            try
            {
                Program.sql = new SQL();
                Program.sql.connect();
                Program.sql.insertTestData(trText, arText);
                Program.sql.disconnect();
                appendLog("Veritaban�na kay�t atma testi ba�ar�l�...");
            }
            catch (Exception ex)
            {
                appendLog(ex.ToString());
            }

            // SQL READ test
            appendLog("Veritaban�ndan kay�t okuma testi y�r�t�l�yor...");
            try
            {
                Program.sql = new SQL();
                Program.sql.connect();
                Program.sql.getTestData(out sqlTr, out sqlAr);
                Program.sql.disconnect();
                appendLog("Veritaban�ndan kay�t okuma testi ba�ar�l�...");
                appendLog("Okunan T�rk�e metin: " + sqlTr);
                appendLog("Okunan Arap�a metin: " + sqlAr);
            }
            catch (Exception ex)
            {
                appendLog(ex.ToString());
            }

            // Yaz�c� testi
            appendLog("Yaz�c� test ediliyor...");
            try
            {
                printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                    appendLog("Yazc�ya ��kt� g�nderildi...");
                }
                else
                {
                    appendLog("Yaz�c� testini iptal ettiniz...");
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
            appendLog("Kantar a��rl��� al�nd�: " + e.weight.ToString());
            appendLog("Testler tamamland�...");
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