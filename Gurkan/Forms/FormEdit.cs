using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gurkan
{
    public partial class FormEdit : Form
    {
        private Tartim tartim;
        private Counterparty[] counterParties;
        private Counterparty[] transporters;
        private Material[] materials;
        private Tartim[] tartimCandidates;

        private bool documentEventsEnabled;

        public FormEdit(Tartim T)
        {
            InitializeComponent();
            
            // Tartým
            tartim = T;
            tartim.deliveryUpperBoundExceeded += new Tartim.DeliveryUpperBoundExceededDelegate(tartim_deliveryUpperBoundExceeded);

            // Ana verileri çekelim
            if (tartim.scenario == Tartim.SCENARIO.PURCHASING)
            {
                counterParties = Counterparty.getAllVendors(Counterparty.VENDOR_TYPE.VENDOR);
            }
            else
            {
                counterParties = Counterparty.getAll(Counterparty.TYPE.CLIENT);
            }
            
            transporters = Counterparty.getAllVendors(Counterparty.VENDOR_TYPE.TRANSPORTER);
            materials = Material.getAll(tartim.scenario);

            // Formu dolduralým
            txtBag.Text = tartim.bagCount.ToString();
            txtDate1.Text = tartim.firstWeightDate.ToShortDateString();
            if (tartim.isOver) txtDate2.Text = tartim.secondWeightDate.ToShortDateString();
            txtDrive.Text = tartim.driver;
            txtFree.Text = tartim.notes;
            txtFrom.Text = tartim.areaFrom;
            txtID.Text = tartim.weightId.ToString();
            txtMubel.Text = tartim.counterPartyDocumentNumber;
            if (tartim.isOver) txtNetWeight.Text = tartim.netWeight.getWeight().ToString();
            txtOpera.Text = tartim.employee;
            txtScenario.Text = Tartim.getScenarioText(tartim.scenario);
            txtSteelYard.Text = tartim.steelyard.ToString();
            txtTo.Text = tartim.areaTo;
            txtWeight1.Text = tartim.firstWeight.getWeight().ToString();
            if (tartim.isOver)
            {
                txtWeight2.Text = tartim.secondWeight.getWeight().ToString();
                txtWtextAR.Text = tartim.weightTextAR;
            }
            plateMain.plateNumber = tartim.plateNumber;
            if (tartim.document != null) plateMain.Enabled = false;

            for (int n = 0; n < counterParties.Length; n++)
            {
                cmbParty.Items.Add(counterParties[n].ToString());
                if (counterParties[n].id == tartim.counterParty.id) cmbParty.SelectedIndex = n;
            }

            for (int n = 0; n < transporters.Length; n++)
            {
                cmbTransporter.Items.Add(transporters[n].ToString());
                if (tartim.transporter != null && transporters[n].id == tartim.transporter.id) cmbTransporter.SelectedIndex = n;
            }

            for (int n = 0; n < materials.Length; n++)
            {
                cmbMaterial.Items.Add(materials[n].ToString());
                if (materials[n].id == tartim.material.id) cmbMaterial.SelectedIndex = n;
            }

            // Belge olayý
            switch (tartim.scenario)
            {
                case Tartim.SCENARIO.PURCHASING:
                    cmbDocument.Enabled = false;
                    break;
                case Tartim.SCENARIO.SALES:
                    if (tartim.hasDocument)
                    {
                        cmbDocument.Items.Add(tartim.document.ToString());
                        cmbDocument.SelectedIndex = 0;

                        tartimCandidates = Tartim.getTartims(plateMain.plateNumber);
                        if (tartimCandidates == null)
                        {
                            cmbDocument.Enabled = false;
                        }
                        else
                        {
                            cmbDocument.Enabled = true;
                            for (int n = 0; n < tartimCandidates.Length; n++)
                            {
                                cmbDocument.Items.Add(tartimCandidates[n].document.ToString());
                            }
                        }

                        cmbParty.Enabled = false;
                        cmbTransporter.Enabled = false;
                        cmbMaterial.Enabled = false;
                        documentEventsEnabled = true;
                    }
                    else
                    {
                        cmbDocument.Enabled = false;
                    }
                    break;
            }

            // SAP'ye aktarýldýysa iyice kýsýtlayacaðýz
            if (tartim.transferredToSAP)
            {
                cmbDocument.Enabled = false;
                cmbMaterial.Enabled = false;
                cmbParty.Enabled = false;
                cmbTransporter.Enabled = false;
                btnSave.Enabled = false;
                txtBag.Enabled = false;
                txtDrive.Enabled = false;
                txtFree.Enabled = false;
                txtFrom.Enabled = false;
                txtTo.Enabled = false;
                txtFree.Enabled = false;
                txtMubel.Enabled = false;
                txtOpera.Enabled = false;
                txtWtextAR.Enabled = false;
                plateMain.Enabled = false;
            }

        }

        void tartim_deliveryUpperBoundExceeded(object sender, TartimDeliveryUpperBoundExceededEventArgs e)
        {
            lblTolerance.Text = "Aðýrlýk, teslimattaki aðýrlýðýn %" + e.exceedRate.ToString() + " üzerinde, onay alýnýz";
            lblTolerance.Visible = true;
            MessageBox.Show(lblTolerance.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblTolerance.Visible = false;
            Document docTmp = tartim.document;

            tartim.areaFrom = txtFrom.Text;
            tartim.areaTo = txtTo.Text;
            tartim.bagCount = Int32.Parse(txtBag.Text);
            tartim.counterPartyDocumentNumber = txtMubel.Text;
            tartim.driver = txtDrive.Text;
            tartim.employee = txtOpera.Text;
            tartim.notes = txtFree.Text;
            tartim.plateNumber = plateMain.plateNumber;
            tartim.weightTextAR = txtWtextAR.Text;

            if (tartim.document == null)
            {
                tartim.counterParty = counterParties[cmbParty.SelectedIndex];
                tartim.material = materials[cmbMaterial.SelectedIndex];
                if (cmbTransporter.SelectedIndex >= 0) tartim.transporter = transporters[cmbTransporter.SelectedIndex];
            }
            else
            {
                if (cmbDocument.SelectedIndex == 0)
                {
                    tartim.counterParty = tartim.document.counterParty;
                    tartim.material = tartim.document.material;
                    tartim.transporter = tartim.document.transporter;
                }
                else
                {
                    try
                    {
                        tartim.document = tartimCandidates[cmbDocument.SelectedIndex - 1].document;
                    } catch (TartimSalesToleranceLimitExceededException ex)
                    {
                        lblTolerance.Text = "Aðýrlýk, teslimattaki aðýrlýktan %" + System.Math.Abs(ex.exceedRate).ToString() + " farklý";

                        lblTolerance.Visible = true;
                        tartim.document = docTmp;
                        return;
                    } 

                    tartim.counterParty = tartimCandidates[cmbDocument.SelectedIndex - 1].counterParty;
                    tartim.material = tartimCandidates[cmbDocument.SelectedIndex - 1].material;
                    if (tartimCandidates[cmbDocument.SelectedIndex - 1].transporter.id != "") tartim.transporter = tartimCandidates[cmbDocument.SelectedIndex - 1].transporter;
                }
            }

            try
            {
                tartim.update();
            } catch (TartimMissingFieldException ex)
            {
                MessageBox.Show("Eksik alan: " + ex.missingField, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = true;
                return;
            }

            btnSave.Enabled = false;
        }

        private void cmbDocument_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!documentEventsEnabled) return;
            if (tartimCandidates == null) return;

            if (cmbDocument.SelectedIndex == 0)
            {
                fillFormFromDocument(tartim.document);
            }
            else
            {
                fillFormFromDocument(tartimCandidates[cmbDocument.SelectedIndex - 1].document);
            }
        }

        private void fillFormFromDocument(Document D)
        {
            for (int n = 0; n < materials.Length; n++) if (materials[n].id == D.material.id) cmbMaterial.SelectedIndex = n;
            for (int n = 0; n < counterParties.Length; n++) if (counterParties[n].id == D.counterParty.id) cmbParty.SelectedIndex = n;
            for (int n = 0; n < transporters.Length; n++) if (D.transporter != null) if (transporters[n].id == D.transporter.id) cmbTransporter.SelectedIndex = n;
        }
    }
}