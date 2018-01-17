using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gurkan
{
    public partial class FormReprint : Form
    {
        private Tartim[] tartims;

        public FormReprint()
        {
            InitializeComponent();
            cmbScenario.SelectedIndex = 0;
        }

        private void FormReprint_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refreshTartims()
        {
            button1.Enabled = false;

            dgMain.Rows.Clear();

            getTartims();
            if (tartims == null || tartims.Length <= 0)
            {
                button1.Enabled = true;
                return;
            }

            for (int n = 0; n < tartims.Length; n++)
            {
                dgMain.Rows.Add();
                dgMain.Rows[n].Cells["SUREC"].Value = Tartim.getScenarioText(tartims[n].scenario);
                dgMain.Rows[n].Cells["ERDA1"].Value = tartims[n].firstWeightDate;
                dgMain.Rows[n].Cells["TRAID"].Value = tartims[n].plateNumber.ToString();
                if (tartims[n].counterParty != null) dgMain.Rows[n].Cells["NAME1_TR"].Value = tartims[n].counterParty.ToString();
                dgMain.Rows[n].Cells["NETAG"].Value = tartims[n].netWeight.getWeight();
                dgMain.Rows[n].Cells["MAKTX_TR"].Value = tartims[n].material.ToString();
                dgMain.Rows[n].Cells["BITTI"].Value = tartims[n].isOver ? ilMain.Images[5] : ilMain.Images[6];
                dgMain.Rows[n].Cells["SAPAK"].Value = tartims[n].transferredToSAP ? ilMain.Images[5] : ilMain.Images[6];
            }


            button1.Enabled = true;
            btnPrint.Enabled = true;
            btnPrint2.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refreshTartims();
        }

        private void getTartims()
        {
            Tartim.SCENARIO s = Tartim.SCENARIO.NULL;

            switch (cmbScenario.SelectedIndex)
            {
                case 0:
                    s = Tartim.SCENARIO.NULL;
                    break;
                case 1:
                    s = Tartim.SCENARIO.PURCHASING;
                    break;
                case 2:
                    s = Tartim.SCENARIO.SALES;
                    break;
            }

            tartims = Tartim.getTartims(date1.Value, date2.Value, s, ucPlate1.plateNumber);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (tartims == null) return;
            if (dgMain.SelectedRows == null) return;
            if (dgMain.SelectedRows.Count <= 0) return;

            if (!tartims[dgMain.SelectedRows[0].Index].isOver)
            {
                MessageBox.Show("Tamamlanmamýþ bir tartýmýn çýktýsý alýnamaz");
                return;
            }

            if (tartims[dgMain.SelectedRows[0].Index].scenario != Tartim.SCENARIO.SALES)
            {
                MessageBox.Show("Sadece satýþ sürecinde irsaliye yazdýrýlabilir");
                return;
            }
            
            tartims[dgMain.SelectedRows[0].Index].printDeliveryDocument();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tartims == null) return;
            if (dgMain.SelectedRows == null) return;
            if (dgMain.SelectedRows.Count <= 0) return;

            Tartim t = tartims[dgMain.SelectedRows[0].Index];
            if (t.transferredToSAP) { MessageBox.Show("Aktarýmý tamamlanmýþ bir tartýmý silemezsiniz"); return; }

            if (MessageBox.Show("Seçtiðiniz tartým silinecek, devam?", "Onay", MessageBoxButtons.YesNo) == DialogResult.No) return;
            t.delete();

            refreshTartims();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tartims == null) return;
            if (dgMain.SelectedRows == null) return;
            if (dgMain.SelectedRows.Count <= 0) return;

            Tartim ta = tartims[dgMain.SelectedRows[0].Index];
            if (ta.transferredToSAP) MessageBox.Show("Aktarýmý tamamlanmýþ bir tartýmý sadece görüntüleyebilirsiniz");

            Program.frmEdit = new FormEdit(ta);
            Program.frmEdit.Show();

        }

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            if (tartims == null) return;
            if (dgMain.SelectedRows == null) return;
            if (dgMain.SelectedRows.Count <= 0) return;

            if (!tartims[dgMain.SelectedRows[0].Index].isOver)
            {
                MessageBox.Show("Tamamlanmamýþ bir tartýmýn çýktýsý alýnamaz");
                return;
            }

            tartims[dgMain.SelectedRows[0].Index].printWeightDocument();
        }

    }
}