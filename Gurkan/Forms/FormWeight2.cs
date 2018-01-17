using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gurkan
{
    public partial class FormWeight2 : Form
    {
        private Tartim[] tartims;
        private Tartim tartim;
        private bool enablePlateEvents;
        private Tartim.SCENARIO scenario;

        public FormWeight2(Tartim.SCENARIO Scenario)
        {
            InitializeComponent();

            // Senaryo
            scenario = Scenario;

            // Tart�mlar� �ekelim ve Combobox'a doldural�m
            tartims = Tartim.getTartims(scenario);
            if (tartims == null)
            {
                MessageBox.Show("Herhangi bir a��k tart�m bulunamad�");
                this.Close();
                return;
            }

            cmbPlate.Items.Clear();
            for (int n = 0; n < tartims.Length; n++) cmbPlate.Items.Add(tartims[n].plateNumber.plateNumber);

            // Senaryoya ba�l� olarak belli alanlar� kapataca��z
            if (scenario != Tartim.SCENARIO.SALES) txtBag.Enabled = false;

            // Event'leri serbest b�rak
            enablePlateEvents = true;
        }

        private void cmbPlate_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Event'ler aktif de�ilse geri d�nelim
            if (!enablePlateEvents) return;

            // Se�ilen tart�m ile formu doldural�m
            tartim = tartims[cmbPlate.SelectedIndex];
            tartim.deliveryUpperBoundExceeded += new Tartim.DeliveryUpperBoundExceededDelegate(tartim_deliveryUpperBoundExceeded);
            tartim.deliveryLowerBoundExceeded += new Tartim.DeliveryUpperBoundExceededDelegate(tartim_deliveryLowerBoundExceeded);
            if (tartim.document != null)
            {
                tartim.fromLikpDataRow(Document.getDelivery(tartim.document.number));
                txtDocument.Text = tartim.document.ToString();
                if (tartim.document.weight != null) txtDocWeight.Text = tartim.document.weight.getWeight().ToString();
            }
            txtFree.Text = tartim.notes;
            txtFree.Enabled = true;
            txtFrom.Text = tartim.areaFrom;
            txtFrom.Enabled = true;
            txtMaterial.Text = tartim.material.ToString();
            txtMubel.Enabled = true;
            txtMubel.Text = tartim.counterPartyDocumentNumber;
            txtParty.Text = tartim.counterParty.ToString();
            txtTo.Text = tartim.areaTo;
            txtTo.Enabled = true;
            if (tartim.transporter != null) txtTransporter.Text = tartim.transporter.ToString();
            txtWeight1.Text = tartim.firstWeight.getWeight().ToString();

            txtDrive.Text = tartim.driver;
            txtDrive.Enabled = true;
            txtOpera.Text = tartim.employee;
            txtOpera.Enabled = true;

            weightMain.Enabled = true;
        }

        void tartim_deliveryLowerBoundExceeded(object sender, TartimDeliveryUpperBoundExceededEventArgs e)
        {
            lblTolerance.Text = "A��rl�k, teslimattaki a��rl���n %" + System.Math.Round(e.exceedRate).ToString() + " alt�nda, onay al�n�z";
            lblTolerance.Visible = true;
            MessageBox.Show(lblTolerance.Text);
        }

        void tartim_deliveryUpperBoundExceeded(object sender, TartimDeliveryUpperBoundExceededEventArgs e)
        {
            lblTolerance.Text = "A��rl�k, teslimattaki a��rl���n %" + System.Math.Round(e.exceedRate).ToString() + " �zerinde, onay al�n�z";
            lblTolerance.Visible = true;
            MessageBox.Show(lblTolerance.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void weightMain_weightTaken(object sender, EventArgs e)
        {
            // �kinci a��rl��� alal�m ve net a��rl��� ekrana yazd�ral�m
            lblTolerance.Visible = false;
            try
            {
                tartim.secondWeight = weightMain.weight;
            } 
            catch (TartimSalesToleranceLimitExceededException ex)
            {
                txtNetWeight.Text = tartim.netWeight.getWeight().ToString();
                lblTolerance.Text = "A��rl�k, teslimattaki a��rl�ktan %" + System.Math.Round(System.Math.Abs(ex.exceedRate)).ToString() + " farkl�, ara� ��kamaz";
                btnSave.Enabled = false;

                lblTolerance.Visible = true;
                return;
            } 
            catch (TartimNegativeWeightException ex)
            {
                lblTolerance.Text = "Negatif a��rl�k, bir hata var";
                lblTolerance.Visible = true;
                return;
            }
            txtNetWeight.Text = tartim.netWeight.getWeight().ToString();
            txtSpellTR.Text = tartim.weightTextTR;

            // Buraya gelebildiysek tolerans vs hatas� yoktur
            cmbPlate.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            tartim.areaFrom = txtFrom.Text;
            tartim.areaTo = txtTo.Text;
            try { tartim.bagCount = Int32.Parse(txtBag.Text); } catch { }
            tartim.counterPartyDocumentNumber = txtMubel.Text;
            tartim.notes = txtFree.Text;
            tartim.employee = txtOpera.Text;
            tartim.driver = txtDrive.Text;
            tartim.secondWeightDate = DateTime.Now; // Bunu parametre olarak SQL'e g�ndermeyece�iz, ��kt�larda g�z�ks�n diye at�yoruz
            tartim.weightTextAR = txtSpellAR.Text;

            try
            {
                tartim.saveSecond();
            } catch (TartimMissingFieldException ex)
            {
                MessageBox.Show("Eksik alan: " + ex.missingField, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            btnSave.Enabled = false;
            btnPrint.Enabled = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            tartim.printWeightDocument();
            if (scenario == Tartim.SCENARIO.SALES) tartim.printDeliveryDocument();
        }



    }
}