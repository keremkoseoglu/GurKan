using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gurkan
{
    public partial class FormWeight1 : Form
    {

        private Tartim[] tartimCandidates;
        private Tartim tartim;

        private Counterparty[] counterParty;
        private Counterparty[] transporter;
        private Material[] material;
        private Tartim.SCENARIO scenario;

        private bool enableDocumentEvent;

        public FormWeight1(Tartim.SCENARIO Scenario)
        {
            InitializeComponent();
            scenario = Scenario;
            init();
        }

        private void init()
        {
            setEverythingEnabled(false);
            enableDocumentEvent = false;
            txtOpera.Text = Program.lastOperator;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void setEverythingEnabled(bool Enabled)
        {
                btnSave.Enabled =
                cmbDocument.Enabled =
                cmbMaterial.Enabled =
                cmbParty.Enabled =
                cmbTransporter.Enabled =
                txtDrive.Enabled = 
                txtMubel.Enabled = 
                txtFree.Enabled =
                txtFrom.Enabled =
                txtMaterialTextAR.Enabled =
                txtOpera.Enabled = 
                txtPartyNameAR.Enabled =
                txtTo.Enabled =
                txtTransporterNameAR.Enabled =
                weightMain.Enabled =
                Enabled;
        }

        private void btnPlate_Click(object sender, EventArgs e)
        {
            plateNumberEntered();
        }

        private void plateNumberEntered()
        {
            // Form
            setEverythingEnabled(false);

            // Bu plakaya istinaden bulabildi�imiz tart�m / teslimatlar� bulal�m
            try
            {
                tartimCandidates = Tartim.getTartims(plateMain.plateNumber, Tartim.ORDER.FIRST);
            } catch (TartimVehicleAlreadyPassedException ex)
            {
                MessageBox.Show("Bu ara� ilk tart�mdan zaten ge�mi�");
                return;
            }


            // E�er herhangi bir�ey bulamad�ysak, formu serbest b�rakmal�y�z
            if (tartimCandidates == null)
            {
                tartim = new Tartim();
                tartim.scenario = scenario;

                setComboBoxFree(cmbDocument);
                cmbDocument.Enabled = false;

                setComboBoxAndTextBoxFree(cmbParty, txtPartyNameAR);
                setComboBoxAndTextBoxFree(cmbMaterial, txtMaterialTextAR);
                setComboBoxAndTextBoxFree(cmbTransporter, txtTransporterNameAR);
                setTextBoxFree(txtFrom);
                setTextBoxFree(txtTo);
                setTextBoxFree(txtFree);
                setTextBoxFree(txtMubel);
                setTextBoxFree(txtOpera); txtOpera.Text = Program.lastOperator;
                setTextBoxFree(txtDrive);
                

                if (scenario == Tartim.SCENARIO.SALES)
                {
                    counterParty = Counterparty.getAll(Counterparty.TYPE.CLIENT);
                }
                else
                {
                    counterParty = Counterparty.getAllVendors(Counterparty.VENDOR_TYPE.VENDOR);
                }

                cmbParty.Items.Add("--- L�TFEN SE��N�Z ---");
                for (int n = 0; n < counterParty.Length; n++)
                {
                    cmbParty.Items.Add(counterParty[n].ToString());
                }
                cmbParty.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbParty.SelectedIndex = 0;
                txtPartyNameAR.Enabled = false;

                material = Material.getAll(scenario);
                cmbMaterial.Items.Add("--- L�TFEN SE��N�Z ---");
                for (int n = 0; n < material.Length; n++)
                {
                    cmbMaterial.Items.Add(material[n].ToString());
                }
                cmbMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbMaterial.SelectedIndex = 0;
                txtMaterialTextAR.Enabled = false;

                transporter = Counterparty.getAllVendors(Counterparty.VENDOR_TYPE.TRANSPORTER);
                cmbTransporter.Items.Add(scenario == Tartim.SCENARIO.SALES ? "(M��terinin Arac�)" : "--- L�TFEN SE��N�Z ---");
                for (int n = 0; n < transporter.Length; n++)
                {
                    cmbTransporter.Items.Add(transporter[n].ToString());
                }
                cmbTransporter.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbTransporter.SelectedIndex = 0;
                txtTransporterNameAR.Enabled = false;

                weightMain.Enabled = true;
            }
            // E�er bir�eyler bulduysak, formu ona g�re doldural�m
            else
            {
                if (tartimCandidates.Length == 1)
                {
                    tartim = tartimCandidates[0];
                    setComboBoxFree(cmbDocument);
                    cmbDocument.Enabled = false;
                    cmbDocument.Text = tartim.document.ToString();

                    displayTartim();
                }
                else
                {
                    cmbDocument.DropDownStyle = ComboBoxStyle.DropDownList;

                    cmbDocument.Items.Clear();
                    cmbDocument.Items.Add("-- L�TFEN �LG�L� BELGEY� SE��N --");
                    for (int n = 0; n < tartimCandidates.Length; n++)
                    {
                        cmbDocument.Items.Add(tartimCandidates[n].ToString());
                    }
                    cmbDocument.SelectedIndex = 0;
                    cmbDocument.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbDocument.Enabled = true;
                    enableDocumentEvent = true;
                }
            }

        }

        private void displayTartim()
        {
            setComboBoxAndTextBoxSlave(cmbParty, tartim.counterParty.ToString(), txtPartyNameAR, tartim.counterParty.arabicName);
            setComboBoxAndTextBoxSlave(cmbMaterial, tartim.material.ToString(), txtMaterialTextAR, tartim.material.arabicName);
            setComboBoxAndTextBoxSlave(cmbTransporter, tartim.transporter.ToString(), txtTransporterNameAR, tartim.transporter.arabicName);
            txtFrom.Enabled = true;
            txtTo.Enabled = true;
            txtFree.Enabled = true;
            txtOpera.Enabled = true;
            txtDrive.Enabled = true;
            weightMain.Enabled = true;
        }

        private void setComboBoxFree(ComboBox C)
        {
            C.DropDownStyle = ComboBoxStyle.DropDown;
            C.Enabled = true;
            C.Items.Clear();
            C.Text = "";
        }

        private void setComboBoxSlave(ComboBox C, string Text)
        {
            C.DropDownStyle = ComboBoxStyle.DropDown;
            C.Enabled = false;
            C.Items.Clear();
            C.Text = Text;
        }

        private void setTextBoxFree(TextBox T)
        {
            T.Enabled = true;
            T.Text = "";
        }

        private void setTextBoxSlave(TextBox T, string Text)
        {
            T.Enabled = false;
            T.Text = Text;
        }

        private void setComboBoxAndTextBoxFree(ComboBox C, TextBox T)
        {
            setComboBoxFree(C);
            setTextBoxFree(T);
        }

        private void setComboBoxAndTextBoxSlave(ComboBox C, string ComboText, TextBox T, string TextText)
        {
            setComboBoxSlave(C, ComboText);
            setTextBoxSlave(T, TextText);
        }

        private void cmbDocument_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!enableDocumentEvent) return;
            if (cmbDocument.SelectedIndex <= 0) return;
            if (tartimCandidates == null) return;
            if (tartimCandidates.Length < 0) return;

            tartim = tartimCandidates[cmbDocument.SelectedIndex - 1];
            displayTartim();

            cmbDocument.Enabled = false;
            enableDocumentEvent = false;
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void weightMain_weightTaken(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            tartim.areaFrom = txtFrom.Text;
            tartim.areaTo = txtTo.Text;
            tartim.counterPartyDocumentNumber = txtMubel.Text;
            tartim.firstWeight = weightMain.weight;
            tartim.notes = txtFree.Text;
            tartim.platformWeight = Program.steelyard.weight;
            tartim.driver = txtDrive.Text;
            tartim.employee = txtOpera.Text;

            if (tartim.document == null)
            {
                if (cmbParty.SelectedIndex == 0 ||
                    cmbMaterial.SelectedIndex == 0 ||
                    (scenario != Tartim.SCENARIO.SALES && cmbTransporter.SelectedIndex == 0))
                {
                    MessageBox.Show("L�tfen verilerin tamam�n� se�in");
                    return;
                }

                tartim.counterParty = counterParty[cmbParty.SelectedIndex - 1];
                tartim.material = material[cmbMaterial.SelectedIndex - 1];
                tartim.plateNumber = plateMain.plateNumber;
                tartim.scenario = scenario;
                if (cmbTransporter.SelectedIndex > 0) tartim.transporter = transporter[cmbTransporter.SelectedIndex - 1];
            }

            try
            {
                tartim.saveFirst();
            } catch (TartimMissingFieldException ex)
            {
                MessageBox.Show("Eksik alan: " + ex.missingField, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Program.lastOperator = tartim.employee;
            tartim = Tartim.getTartims(plateMain.plateNumber, Tartim.ORDER.SECOND)[0];

            setEverythingEnabled(false);
            plateMain.Enabled = false;
        }

        private void cmbParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tartim == null) return;
            if (tartim.document != null) return;
            if (cmbParty.SelectedIndex == 0) return;
            txtPartyNameAR.Text = counterParty[cmbParty.SelectedIndex - 1].arabicName;
        }

        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tartim == null) return;
            if (tartim.document != null) return;
            if (cmbMaterial.SelectedIndex == 0) return;
            txtMaterialTextAR.Text = material[cmbMaterial.SelectedIndex - 1].arabicName;
        }

        private void cmbTransporter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tartim == null) return;
            if (tartim.document != null) return;
            if (cmbTransporter.SelectedIndex == 0) return;
            txtTransporterNameAR.Text = transporter[cmbTransporter.SelectedIndex - 1].arabicName;
        }
    }
}