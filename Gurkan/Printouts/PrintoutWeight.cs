using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace Gurkan
{
    public class PrintoutWeight : Printout
    {
        public PrintoutWeight()
        {
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float ypos1 = spaceTopMargin;
            float ypos2 = spaceTopMargin;

            ////////// S�TUN 1 //////////

            // Ba�l�k sat�r�
            printHeading(e, "G�R�� AL RAQQAH CEMENT", ref ypos1, 1);

            // Ba�l�k (no)
            if (tartim.weightId != 0) printPair(e, "F�� NO ", tartim.weightId.ToString(), ref ypos1, 1); 

            // Giri� tarihi
            if (tartim.firstWeightDate != null) printPair(e, "G�R�� TAR�H�", tartim.firstWeightDate.ToShortDateString(), ref ypos1, 1);

            // ��k�� tarihi
            if (tartim.secondWeightDate != null && tartim.secondWeightDate.Year > 2000) printPair(e, "�IKI� TAR�H�", tartim.secondWeightDate.ToShortDateString(), ref ypos1, 1);

            // Malzeme kodu, ad�, vs
            if (tartim.material != null)
            {
                printPair(e, "MALZEME KODU", Common.pack(tartim.material.id), ref ypos1, 1);
                printPair(e, "MALZEME ADI", tartim.material.turkishName + " / " + tartim.material.arabicName, ref ypos1, 1);
            }

            // Birim (Sabit)
            printPair(e, "B�R�M", "KG", ref ypos1, 1);

            // Firma kodu, ad�
            if (tartim.counterParty != null)
            {
                printPair(e, "F�RMA KODU", Common.pack(tartim.counterParty.id), ref ypos1, 1);
                printPair(e, "F�RMA ADI", tartim.counterParty.turkishName + " / " + tartim.counterParty.arabicName, ref ypos1, 1);
            }

            // �lk tart�m, son tartim, net
            if (tartim.scenario != Tartim.SCENARIO.FREE)
            {
                if (tartim.firstWeight != null) printPair(e, "�LK TARTIM", tartim.firstWeight.ToString(), ref ypos1, 1);
                if (tartim.secondWeight != null) printPair(e, "SON TARTIM", tartim.secondWeight.ToString(), ref ypos1, 1);
            }
            if (tartim.netWeight != null) printPair(e, "NET", tartim.netWeight.ToString(), ref ypos1, 1);
            
            // S�r�c�
            printPair(e, "S�R�C�", tartim.driver, ref ypos1, 1);
            
            // Notlar
            printPair(e, "A�IKLAMA", tartim.notes, ref ypos1, 1);

            // Kantarc�
            printPair(e, "KANTARCI", tartim.employee, ref ypos1, 1);

            // Eksiksiz teslim ald�m
            printString(e, "EKS�KS�Z TESL�M ALDIM.       �MZA: ", fontDefault, 250, ypos1, 1);
            ypos1 += spaceLine;

            /////////////// S�TUN 2 /////////////////

            // Ba�l�k skip
            printHeading(e, " ", ref ypos2, 2);

            // Plaka
            if (tartim.plateNumber != null) printPair(e, "PLAKA", tartim.plateNumber.plateNumber, ref ypos2, 2);

            // Giri� saati
            if (tartim.firstWeightDate != null) printPair(e, "G�R�� SAAT�", tartim.firstWeightDate.ToShortTimeString(), ref ypos2, 2);

            // ��k�� saati
            if (tartim.secondWeightDate != null && tartim.secondWeightDate.Year > 2000) printPair(e, "�IKI� SAAT�", tartim.secondWeightDate.ToShortTimeString(), ref ypos2, 2);

            // 2 sat�r skip (malzeme)
            if (tartim.material != null) for (int n = 0; n < 2; n++) printPair(e, " ", " ", ref ypos2, 2);

            // Geldi�i yer + gitti�i yer
            printPair(e, "GELD��� YER", tartim.areaFrom, ref ypos2, 2);
            printPair(e, "G�TT��� YER", tartim.areaTo, ref ypos2, 2);

            // 1 sat�r skip
            printPair(e, " ", " ", ref ypos2, 2);

            // Kantar
            printPair(e, "KANTAR", tartim.steelyard.ToString(), ref ypos2, 2);
        }

        protected void printPair(System.Drawing.Printing.PrintPageEventArgs E, string Title, string Value, ref float YPos, int Column)
        {
            if (Value == null || Value.Length <= 0) return;

            printString(E, formatString(Title), fontTitle, spaceLeftMargin, YPos, Column);
            printString(E, formatString(Value), fontDefault, spaceLeftMargin + spaceTab, YPos, Column);
            YPos += spaceLine;
        }

        protected void printString(System.Drawing.Printing.PrintPageEventArgs E, string Value, Font F, float XPos, float YPos, int Column)
        {
            float x = XPos;
            if (Column > 1) x += Program.config.PrintoutTabSize * 3;

            E.Graphics.DrawString(formatString(Value), F, brushDefault, x, YPos);
        }

        protected void printHeading(System.Drawing.Printing.PrintPageEventArgs E, string Value, ref float YPos, int Column)
        {
            printString(E, Value, fontHeading, spaceLeftMargin, YPos, Column);
            YPos += spaceLine * 2;
        }
    }
}
