using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace Gurkan
{
    public class PrintoutDelivery : Printout
    {
        private const float BOX_MARGIN = 10 ;
        private const float BOX_SIZE = 800;

        public PrintoutDelivery()
        {
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
        }

        void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            float ypos = spaceTopMargin;

            // Logo
            e.Graphics.DrawImage(Image.FromFile(Application.StartupPath + "\\logo\\" + tartim.steelyard.id + ".bmp"), spaceLeftMargin, ypos);

            // Sevk irsaliyesi
            e.Graphics.DrawString("بيان ارسالية", fontHeading, brushDefault, 600, ypos);
            ypos += spaceLine;
            e.Graphics.DrawString(formatString("SEVK İRSALİYESİ"), fontHeading, brushDefault, 600, ypos);
            ypos += spaceLine;

            // İrsaliye No
            e.Graphics.DrawString(tartim.weightId.ToString(), fontHeading, brushDefault, 450, ypos);
            e.Graphics.DrawString(formatString(":İrsaliye No / الرقم"), fontHeading, brushDefault, 550, ypos);
            ypos += spaceLine * 2;

            // Adresin ilk satırı ve irsaliye tarihi
            e.Graphics.DrawString(tartim.steelyard.addressLine[0], fontSmallBold, brushDefault, spaceLeftMargin, ypos);
            e.Graphics.DrawString(tartim.secondWeightDate.ToShortDateString(), fontSmall, brushDefault, 450, ypos);
            e.Graphics.DrawString(formatString(":İrsaliye Tarihi / تاريخ اصدار البيان"), fontSmallBold, brushDefault, 525, ypos);
            ypos += spaceLine;

            // Adresin ikinci satırı ve fiili sevk tarihi
            e.Graphics.DrawString(tartim.steelyard.addressLine[1], fontSmall, brushDefault, spaceLeftMargin, ypos);
            e.Graphics.DrawString(tartim.secondWeightDate.ToShortDateString(), fontSmall, brushDefault, 450, ypos);
            e.Graphics.DrawString(formatString(":Fiili Sevk Tarihi / تاريخ الارسال الفعلي"), fontSmallBold, brushDefault, 525, ypos);
            ypos += spaceLine;

            // Diğer adres satırları
            e.Graphics.DrawString(tartim.steelyard.addressLine[2], fontSmall, brushDefault, spaceLeftMargin, ypos);
            ypos += spaceLine;
            e.Graphics.DrawString(tartim.steelyard.addressLine[3], fontSmall, brushDefault, spaceLeftMargin, ypos);
            ypos += spaceLine;
            e.Graphics.DrawString(tartim.steelyard.addressLine[4], fontSmall, brushDefault, spaceLeftMargin, ypos);
            ypos += spaceLine;
            e.Graphics.DrawString(tartim.steelyard.addressLine[5], fontSmall, brushDefault, spaceLeftMargin, ypos);
            ypos += spaceLine;

            // Kutuyu çizelim
            e.Graphics.DrawRectangle(penDefault, spaceLeftMargin, ypos, BOX_SIZE, 750);
            ypos += BOX_MARGIN;

            // Müşteri satırı
            e.Graphics.DrawString(tartim.counterParty.idPacked, fontDefault, brushDefault, spaceLeftMargin + BOX_MARGIN, ypos);
            e.Graphics.DrawString(formatString(":Müşteri No / رقم حساب الزبون"), fontSmallBold, brushDefault, 215, ypos);

            e.Graphics.DrawString(tartim.counterParty.turkishName, fontSmall, brushDefault, 450, ypos);
            e.Graphics.DrawString(formatString(":Müşteri Adı"), fontSmallBold, brushDefault, 680, ypos);

            ypos += spaceLine;

            e.Graphics.DrawString(tartim.counterParty.arabicName, fontSmall, brushDefault, 450, ypos);
            e.Graphics.DrawString(":اسم و شهرة الزبون", fontSmallBold, brushDefault, 680, ypos);

            e.Graphics.DrawLine(penDefault, 440, ypos - spaceLine - BOX_MARGIN, 440, ypos + spaceLine);
            ypos += spaceLine;
            e.Graphics.DrawLine(penDefault, spaceLeftMargin, ypos, BOX_SIZE + BOX_MARGIN, ypos);
            ypos += BOX_MARGIN;

            // Araç / Nakliyeci / Adres başlıkları
            e.Graphics.DrawString(formatString("Araç Plaka / رقم السيارة"), fontSmallBold, brushDefault, spaceLeftMargin + BOX_MARGIN, ypos);
            e.Graphics.DrawString(formatString("Nakliyeci / اسم و شهرة السائق"), fontSmallBold, brushDefault, 215, ypos);
            e.Graphics.DrawString(formatString("Müşterinin Adresi / عنوان الزبون"), fontSmallBold, brushDefault, 450, ypos);

            e.Graphics.DrawLine(penDefault, 205, ypos - BOX_MARGIN, 205, ypos + spaceLine);
            e.Graphics.DrawLine(penDefault, 440, ypos - BOX_MARGIN, 440, ypos + spaceLine);
            ypos += spaceLine;
            e.Graphics.DrawLine(penDefault, spaceLeftMargin, ypos, BOX_SIZE + BOX_MARGIN, ypos);
            ypos += BOX_MARGIN;

            // Araç / Nakliyeci / Adres değerleri
            e.Graphics.DrawString(tartim.plateNumber.plateNumber, fontDefault, brushDefault, spaceLeftMargin + BOX_MARGIN, ypos);
            if (tartim.transporter != null) e.Graphics.DrawString(formatString(tartim.transporter.turkishName), fontSmall, brushDefault, 215, ypos);
            e.Graphics.DrawString(formatString(tartim.counterParty.turkishAddress), fontSmall, brushDefault, 450, ypos);

            ypos += spaceLine;
            if(tartim.transporter != null) e.Graphics.DrawString(formatString(tartim.transporter.arabicName), fontSmall, brushDefault, 215, ypos);
            e.Graphics.DrawString(formatString(tartim.counterParty.arabicAddress), fontSmall, brushDefault, 450, ypos);

            e.Graphics.DrawLine(penDefault, 205, ypos - spaceLine - BOX_MARGIN, 205, ypos + spaceLine);
            e.Graphics.DrawLine(penDefault, 440, ypos - spaceLine - BOX_MARGIN, 440, ypos + spaceLine);
            ypos += spaceLine;
            e.Graphics.DrawLine(penDefault, spaceLeftMargin, ypos, BOX_SIZE + BOX_MARGIN, ypos);
            ypos += BOX_MARGIN;

            // Alınan malın
            e.Graphics.DrawString("A L I N A N   M A L I N / البضاعة المسلمة", fontSmallBold, brushDefault, 250, ypos);
            ypos += spaceLine;
            e.Graphics.DrawLine(penDefault, spaceLeftMargin, ypos, BOX_SIZE + BOX_MARGIN, ypos);
            ypos += BOX_MARGIN;

            // Malzemeye ait başlıklar
            e.Graphics.DrawString("Torba Adedi / عدد الاكياس", fontSmallBold, brushDefault, spaceLeftMargin + BOX_MARGIN, ypos);
            e.Graphics.DrawString("Ton / طن", fontSmallBold, brushDefault, 215, ypos);
            e.Graphics.DrawString(formatString("Ambalaj Şekli / شكل التعبئة"), fontSmallBold, brushDefault, 450, ypos);
            e.Graphics.DrawString("Cinsi / النوع", fontSmallBold, brushDefault, 650, ypos);

            e.Graphics.DrawLine(penDefault, 205, ypos - BOX_MARGIN, 205, ypos + spaceLine);
            e.Graphics.DrawLine(penDefault, 440, ypos - BOX_MARGIN, 440, ypos + spaceLine);
            e.Graphics.DrawLine(penDefault, 640, ypos - BOX_MARGIN, 640, ypos + spaceLine);
            ypos += spaceLine;
            e.Graphics.DrawLine(penDefault, spaceLeftMargin, ypos, BOX_SIZE + BOX_MARGIN, ypos);
            ypos += BOX_MARGIN;

            // Malzemeye ait değerler - satır 1
            e.Graphics.DrawString(tartim.bagCount.ToString(), fontDefault, brushDefault, spaceLeftMargin + BOX_MARGIN, ypos);

            e.Graphics.DrawString(tartim.netWeight.weightTextInTons + " / " + tartim.weightTextAR, fontTiny, brushDefault, 215, ypos);
            e.Graphics.DrawString(formatString(":Yazılı / كتابة"), fontSmallBold, brushDefault, 320, ypos);

            e.Graphics.DrawString(formatString(tartim.material.materialGroup.turkishName), fontSmall, brushDefault, 450, ypos);
            e.Graphics.DrawString(formatString(tartim.material.turkishName), fontTiny, brushDefault, 650, ypos);

            ypos += spaceLine;

            // Malzemeye ait değerler - satır 2
            e.Graphics.DrawString(tartim.netWeight.getWeight(Weight.UOM.TON).ToString(), fontSmall, brushDefault, 215, ypos);
            e.Graphics.DrawString(":Rakam / بالرقم", fontSmallBold, brushDefault, 320, ypos);
            e.Graphics.DrawString(tartim.material.materialGroup.arabicName, fontSmall, brushDefault, 450, ypos);
            e.Graphics.DrawString(tartim.material.arabicName, fontTiny, brushDefault, 650, ypos);

            e.Graphics.DrawLine(penDefault, 205, ypos - spaceLine - BOX_MARGIN, 205, ypos + spaceLine);
            e.Graphics.DrawLine(penDefault, 440, ypos - spaceLine - BOX_MARGIN, 440, ypos + spaceLine);
            e.Graphics.DrawLine(penDefault, 640, ypos - spaceLine - BOX_MARGIN, 640, ypos + spaceLine);
            ypos += spaceLine;
            e.Graphics.DrawLine(penDefault, spaceLeftMargin, ypos, BOX_SIZE + BOX_MARGIN, ypos);
            ypos += BOX_MARGIN;

            // İmza bölümleri - satır 1
            e.Graphics.DrawString("حارس الباب الخارجي", fontSmallBold, brushDefault, spaceLeftMargin + BOX_MARGIN, ypos);
            e.Graphics.DrawString("موظف القبان", fontSmallBold, brushDefault, 215, ypos);
            e.Graphics.DrawString("مسؤول التعبئة", fontSmallBold, brushDefault, 450, ypos);
            e.Graphics.DrawString("القسم التجاري", fontSmallBold, brushDefault, 650, ypos);
            ypos += spaceLine;

            // İmza bölümleri - satır 2
            e.Graphics.DrawString(formatString("KAPI GÜVENLİK"), fontSmallBold, brushDefault, spaceLeftMargin + BOX_MARGIN, ypos);
            e.Graphics.DrawString(formatString("KANTAR GÖREVLİSİ"), fontSmallBold, brushDefault, 215, ypos);
            e.Graphics.DrawString(formatString("PAKETLEME GÖREVLİSİ"), fontSmallBold, brushDefault, 450, ypos);
            e.Graphics.DrawString(formatString("TİCARET BÖLÜMÜ"), fontSmallBold, brushDefault, 650, ypos);

            e.Graphics.DrawLine(penDefault, 205, ypos - spaceLine - BOX_MARGIN, 205, ypos + 200);
            e.Graphics.DrawLine(penDefault, 440, ypos - spaceLine - BOX_MARGIN, 440, ypos + 200);
            e.Graphics.DrawLine(penDefault, 640, ypos - spaceLine - BOX_MARGIN, 640, ypos + 200);
            ypos += 200;
            e.Graphics.DrawLine(penDefault, spaceLeftMargin, ypos, BOX_SIZE + BOX_MARGIN, ypos);
            ypos += BOX_MARGIN;

            // Son onay bölümü
            e.Graphics.DrawString("لقد استلمت البضاعة المذكورة أعلاه سليمة وزنا بالطن و عدد بالاكياس خالية من اية عيوب و أتعهد بتسليمها للزبون المذكور ", fontSmallBold, brushDefault, spaceLeftMargin + BOX_MARGIN, ypos);
            ypos += spaceLine;
            e.Graphics.DrawString(formatString("Yukarıda cinsi tonu ve torba adedi yazılı olan malı hasarsız ve eksiksiz teslim aldım ve"), fontSmallBold, brushDefault, spaceLeftMargin + BOX_MARGIN, ypos);
            ypos += spaceLine;
            e.Graphics.DrawString(formatString("sahibine aynı şekilde teslim edeceğime teahüt ederim."), fontSmallBold, brushDefault, spaceLeftMargin + BOX_MARGIN, ypos);
            ypos += spaceLine * 2;
            e.Graphics.DrawString("اسم وشهرة المستلم و توقيعه", fontSmallBold, brushDefault, spaceLeftMargin + BOX_MARGIN, ypos);
            ypos += spaceLine;
            e.Graphics.DrawString(formatString("Teslim Alanın Adı Soyadı ve İmzası"), fontSmallBold, brushDefault, spaceLeftMargin + BOX_MARGIN, ypos);


        }
    }
}
