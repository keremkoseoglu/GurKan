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

            ////////// SÜTUN 1 //////////

            // Baþlýk satýrý
            printHeading(e, "GÜRÝÞ AL RAQQAH CEMENT", ref ypos1, 1);

            // Baþlýk (no)
            if (tartim.weightId != 0) printPair(e, "FÝÞ NO ", tartim.weightId.ToString(), ref ypos1, 1); 

            // Giriþ tarihi
            if (tartim.firstWeightDate != null) printPair(e, "GÝRÝÞ TARÝHÝ", tartim.firstWeightDate.ToShortDateString(), ref ypos1, 1);

            // Çýkýþ tarihi
            if (tartim.secondWeightDate != null && tartim.secondWeightDate.Year > 2000) printPair(e, "ÇIKIÞ TARÝHÝ", tartim.secondWeightDate.ToShortDateString(), ref ypos1, 1);

            // Malzeme kodu, adý, vs
            if (tartim.material != null)
            {
                printPair(e, "MALZEME KODU", Common.pack(tartim.material.id), ref ypos1, 1);
                printPair(e, "MALZEME ADI", tartim.material.turkishName + " / " + tartim.material.arabicName, ref ypos1, 1);
            }

            // Birim (Sabit)
            printPair(e, "BÝRÝM", "KG", ref ypos1, 1);

            // Firma kodu, adý
            if (tartim.counterParty != null)
            {
                printPair(e, "FÝRMA KODU", Common.pack(tartim.counterParty.id), ref ypos1, 1);
                printPair(e, "FÝRMA ADI", tartim.counterParty.turkishName + " / " + tartim.counterParty.arabicName, ref ypos1, 1);
            }

            // Ýlk tartým, son tartim, net
            if (tartim.scenario != Tartim.SCENARIO.FREE)
            {
                if (tartim.firstWeight != null) printPair(e, "ÝLK TARTIM", tartim.firstWeight.ToString(), ref ypos1, 1);
                if (tartim.secondWeight != null) printPair(e, "SON TARTIM", tartim.secondWeight.ToString(), ref ypos1, 1);
            }
            if (tartim.netWeight != null) printPair(e, "NET", tartim.netWeight.ToString(), ref ypos1, 1);
            
            // Sürücü
            printPair(e, "SÜRÜCÜ", tartim.driver, ref ypos1, 1);
            
            // Notlar
            printPair(e, "AÇIKLAMA", tartim.notes, ref ypos1, 1);

            // Kantarcý
            printPair(e, "KANTARCI", tartim.employee, ref ypos1, 1);

            // Eksiksiz teslim aldým
            printString(e, "EKSÝKSÝZ TESLÝM ALDIM.       ÝMZA: ", fontDefault, 250, ypos1, 1);
            ypos1 += spaceLine;

            /////////////// SÜTUN 2 /////////////////

            // Baþlýk skip
            printHeading(e, " ", ref ypos2, 2);

            // Plaka
            if (tartim.plateNumber != null) printPair(e, "PLAKA", tartim.plateNumber.plateNumber, ref ypos2, 2);

            // Giriþ saati
            if (tartim.firstWeightDate != null) printPair(e, "GÝRÝÞ SAATÝ", tartim.firstWeightDate.ToShortTimeString(), ref ypos2, 2);

            // Çýkýþ saati
            if (tartim.secondWeightDate != null && tartim.secondWeightDate.Year > 2000) printPair(e, "ÇIKIÞ SAATÝ", tartim.secondWeightDate.ToShortTimeString(), ref ypos2, 2);

            // 2 satýr skip (malzeme)
            if (tartim.material != null) for (int n = 0; n < 2; n++) printPair(e, " ", " ", ref ypos2, 2);

            // Geldiði yer + gittiði yer
            printPair(e, "GELDÝÐÝ YER", tartim.areaFrom, ref ypos2, 2);
            printPair(e, "GÝTTÝÐÝ YER", tartim.areaTo, ref ypos2, 2);

            // 1 satýr skip
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
