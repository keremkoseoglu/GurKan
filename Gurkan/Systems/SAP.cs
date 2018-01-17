using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Gurkan
{
    public class SAP
    {

        SAPWAS.ZGURKAN_F_V15 rfc;

        #region COMMON_STUFF

        public SAP()
        {
            rfc = new SAPWAS.ZGURKAN_F_V15();
            rfc.UseDefaultCredentials = false;
            rfc.Credentials = sapCredentials;
        }

        public void testConnection(out string TurkishText, out string ArabicText)
        {
            TurkishText = ArabicText = "";
            ArabicText = rfc.ZGURKAN_TEST(out TurkishText);
        }

        private System.Net.NetworkCredential sapCredentials
        {
            get
            {
                return new System.Net.NetworkCredential(Program.config.SapUser, Program.config.SapPass);
            }
        }

        #endregion

        #region INTEGRATION

        public void getSapData(out SAPWAS.ZGURKAN_S_KNA1[] Kna1, out SAPWAS.ZGURKAN_S_LFA1[] Lfa1, out SAPWAS.ZGURKAN_S_LIKP[] Likp, out SAPWAS.ZGURKAN_S_MARA[] Mara, out SAPWAS.ZGURKAN01[] Kantar)
        {
            Kantar = rfc.ZGURKAN_GET_SAP_DATA(out Kna1, out Lfa1, out Likp, out Mara);
        }

        public void setSqlData(SQL S)
        {
            // Tartým verileri
            DataTable tartim = S.getSqlData();
            if (tartim != null && tartim.Rows.Count > 0)
            {
                SAPWAS.ZGURKAN_S_TARTIM_TRANSFER[] trt = new Gurkan.SAPWAS.ZGURKAN_S_TARTIM_TRANSFER[tartim.Rows.Count];

                for (int n = 0; n < tartim.Rows.Count; n++ )
                {
                    DataRow dr = tartim.Rows[n];
                    trt[n] = new Gurkan.SAPWAS.ZGURKAN_S_TARTIM_TRANSFER();
                    trt[n].AGIR1 = (decimal)dr["AGIR1"];
                    trt[n].AGIR2 = (decimal)dr["AGIR2"];
                    try { trt[n].BAGCO = (int)dr["BAGCO"]; } catch { }
                    try { trt[n].BELAG = (decimal)dr["BELAG"]; } catch { }
                    trt[n].BELGE = dr["BELGE"].ToString();
                    trt[n].DARAA = (decimal)dr["DARAA"];
                    trt[n].DRIVE = dr["DRIVE"].ToString();
                    trt[n].ERDA1 = parseDate((DateTime)dr["ERDA1"]);
                    trt[n].ERDA2 = parseDate((DateTime)dr["ERDA2"]);
                    trt[n].ERZE1 = parseTime((DateTime)dr["ERDA1"]);
                    trt[n].ERZE2 = parseTime((DateTime)dr["ERDA2"]);
                    trt[n].GELAL = dr["GELAL"].ToString();
                    trt[n].GITAL = dr["GITAL"].ToString();
                    trt[n].KANID = dr["KANID"].ToString();
                    trt[n].LIFSP = dr["LIFSP"].ToString();
                    trt[n].LOEKZ = dr["LOEKZ"].ToString();
                    trt[n].MAKTX_AR = dr["MAKTX_AR"].ToString();
                    trt[n].MAKTX_TR = dr["MAKTX_TR"].ToString();
                    trt[n].MATNR = dr["MATNR"].ToString();
                    trt[n].MEINS = dr["MEINS"].ToString();
                    trt[n].MUBEL = dr["MUBEL"].ToString();
                    trt[n].MUHID = dr["MUHID"].ToString();
                    trt[n].NAKAR = dr["NAKAR"].ToString();
                    trt[n].NAKTR = dr["NAKTR"].ToString();
                    trt[n].NAME1_AR = dr["NAME1_AR"].ToString();
                    trt[n].NAME1_TR = dr["NAME1_TR"].ToString();
                    trt[n].NETAG = (decimal)dr["NETAG"];
                    trt[n].OPERA = dr["OPERA"].ToString();
                    trt[n].STEXT = dr["STEXT"].ToString();
                    trt[n].TARID = dr["TARID"].ToString();
                    trt[n].TARTI = dr["TARTI"].ToString();
                    trt[n].TRAID = dr["TRAID"].ToString();
                    trt[n].WTEXT_AR = dr["WTEXT_AR"].ToString();
                    trt[n].WTEXT_TR = dr["WTEXT_TR"].ToString();
                }

                rfc.ZGURKAN_SET_SQL_DATA(trt);
            }

            for (int n = 0; n < tartim.Rows.Count; n++) S.setTartimTransferred((int)tartim.Rows[n]["TARID"]);
        }

        #endregion

        #region DATA_TYPE
        public static void parseDateTime(DateTime D, out string DatePart, out string TimePart)
        {
            DatePart = parseDate(D);
            TimePart = parseTime(D);
        }

        public static string parseDate(DateTime D)
        {
            string year = D.Year.ToString();
            string month = D.Month.ToString(); while (month.Length < 2) month = "0" + month;
            string day = D.Day.ToString(); while (day.Length < 2) day = "0" + day;

            return year + "-" + month + "-" + day;
        }

        public static string parseTime(DateTime D)
        {
            string hour = D.Hour.ToString(); while (hour.Length < 2) hour = "0" + hour;
            string minute = D.Minute.ToString(); while (minute.Length < 2) minute = "0" + minute;
            string second = D.Second.ToString(); while (second.Length < 2) second = "0" + second;

            return hour + ":" + minute + ":" + second;
        }

        #endregion

    }
}
