using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace Gurkan
{
    public class Printout
    {
        protected Tartim tartim;
        protected PrintDocument printDocument;
        protected PrintDialog printDialog;

        private System.Drawing.Font _font;
        private System.Drawing.Font _fontBold;
        private System.Drawing.Font _fontSmall;
        private System.Drawing.Font _fontTiny;
        private System.Drawing.Font _fontSmallBold;
        private System.Drawing.Font _fontHeading;
        private System.Drawing.Font _fontTitle;

        public Printout()
        {
        }

        #region PRINTING_STUFF

        public void print(Tartim T)
        {
            tartim = T;

            printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.PrinterSettings = printDialog.PrinterSettings;
                printDocument.Print();
            }
        }

        protected string formatString(string S)
        {
            if (Program.config.PrintoutAllowTRChar) return S;

            string ret = S;
            ret = ret.Replace("ý", "i");
            ret = ret.Replace("ð", "g");
            ret = ret.Replace("Ð", "G");
            ret = ret.Replace("ü", "u");
            ret = ret.Replace("Ü", "U");
            ret = ret.Replace("þ", "s");
            ret = ret.Replace("Þ", "S");
            ret = ret.Replace("Ý", "I");
            ret = ret.Replace("ö", "o");
            ret = ret.Replace("Ö", "O");
            ret = ret.Replace("ç", "c");
            ret = ret.Replace("Ç", "C");

            return ret;
        }

        #endregion


        #region Properties

        protected Font fontBold
        {
            get
            {
                if (_fontBold == null)
                {
                    _fontBold = new Font(Program.config.PrintoutFontFamily, Program.config.PrintoutFontSize, FontStyle.Bold);
                }

                return _fontBold;
            }
        }

        protected Font fontDefault
        {
            get
            {
                if (_font == null)
                {
                    _font = new Font(Program.config.PrintoutFontFamily, Program.config.PrintoutFontSize);
                }

                return _font;
            }
        }

        protected Font fontSmallBold
        {
            get
            {
                if (_fontSmallBold == null)
                {
                    _fontSmallBold = new Font(Program.config.PrintoutFontFamily, Program.config.PrintoutFontSize - 2, FontStyle.Bold);
                }

                return _fontSmallBold;
            }
        }

        protected Font fontSmall
        {
            get
            {
                if (_fontSmall == null)
                {
                    _fontSmall = new Font(Program.config.PrintoutFontFamily, Program.config.PrintoutFontSize - 2);
                }

                return _fontSmall;
            }
        }

        protected Font fontTiny
        {
            get
            {
                if (_fontTiny == null)
                {
                    _fontTiny = new Font(Program.config.PrintoutFontFamily, Program.config.PrintoutFontSize - 4);
                }

                return _fontTiny;
            }
        }

        protected Font fontHeading
        {
            get
            {
                if (_fontHeading == null)
                {
                    _fontHeading = new Font(Program.config.PrintoutFontFamily, Program.config.PrintoutFontSize + 4, FontStyle.Bold);
                }

                return _fontHeading;
            }
        }

        protected Font fontTitle
        {
            get
            {
                if (_fontTitle == null)
                {
                    _fontTitle = new Font(Program.config.PrintoutFontFamily, Program.config.PrintoutFontSize, FontStyle.Bold);
                }

                return _fontTitle;
            }
        }

        protected Brush brushDefault
        {
            get
            {
                return Brushes.Black;
            }
        }

        protected Pen penDefault { get { return new Pen(brushDefault); } }

        protected float spaceLeftMargin { get { return Program.config.PrintoutLeftMargin; } }
        protected float spaceTopMargin { get { return Program.config.PrintoutTopMargin; } }
        protected float spaceLine { get { return Program.config.PrintoutLineSpacing; } }
        protected float spaceTab { get { return Program.config.PrintoutTabSize; } }

        #endregion
    }
}
