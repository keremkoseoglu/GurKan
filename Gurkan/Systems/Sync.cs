using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;

namespace Gurkan
{
    public class Sync
    {
        private static bool integrationActive;

        private SAP sap;
        private SQL sql;

        /*public delegate void syncEventDelegate(object sender, SyncEventArgs e);
        public event syncEventDelegate syncEvent; */

        public Sync()
        {
            sap = new SAP();
            sql = new SQL();
        }

        public void doSync()
        {

            while (1 == 1)
            {
                // Bekle
                Thread.Sleep(Program.config.IntPeriod * 1000);

                // Yürüt
                doSyncManual();
            }
            
        }

        public void doSyncManual()
        {
            // Entegrasyon aktif ise, ikinci kez baþlayamaz
            if (isIntegrationActive) return;

            // Entegrasyon aktif
            integrationActive = true;
            setIntegrationStatus(Common.STATUS.WORKING);

            // Baþla
            try
            {
                // Baðlantýlarý aç
                sql.connect();

                // SAP --> SQL
                sapToSql();

                // SQL --> SAP
                sap.setSqlData(sql);

                // Baðlantýlarý kapat
                sql.disconnect();

                // Entegrasyon aktif
                setIntegrationStatus(Common.STATUS.GREEN);
            } catch (Exception ex)
            {
                setIntegrationStatus(Common.STATUS.RED);
                Program.logger.appendLog("Senkronizasyon hatasý: " + ex.ToString());
            }

            integrationActive = false;
        }

        public bool isIntegrationActive
        {
            get { return integrationActive; }
        }

        private void setIntegrationStatus(Common.STATUS S)
        {
            if (Program.frmMain == null) return;

            Program.frmMain.setIntegrationStatus(S);
        }

        private void sapToSql()
        {
            //////////
            // SAP'den verileri çekelim
            //////////

            SAPWAS.ZGURKAN_S_KNA1[] kna1;
            SAPWAS.ZGURKAN_S_LFA1[] lfa1;
            SAPWAS.ZGURKAN_S_LIKP[] likp;
            SAPWAS.ZGURKAN_S_MARA[] mara;
            SAPWAS.ZGURKAN01[] kantar;

            sap.getSapData(out kna1, out lfa1, out likp, out mara, out kantar);

            //////////
            // Çektiðimiz verileri sýrayla aktaralým
            //////////

            // Müþteriler
            sql.beginTransaction();

            sql.initializeStoredProcedure("SP_KNA1_PURGE");
            sql.executeStoredProcedureNonQuery();

            for (int n = 0; n < kna1.Length; n++)
            {
                sql.initializeStoredProcedure("SP_KNA1_INSERT");
                sql.addStoredProcedureParameter("@KUNNR", kna1[n].KUNNR);
                sql.addStoredProcedureParameter("@NAME1_TR", kna1[n].NAME1_TR);
                sql.addStoredProcedureParameter("@NAME1_AR", kna1[n].NAME1_AR);
                sql.addStoredProcedureParameter("@ADDRE_TR", kna1[n].ADDRE_TR);
                sql.addStoredProcedureParameter("@ADDRE_AR", kna1[n].ADDRE_AR);
                sql.executeStoredProcedureNonQuery();
            }

            sql.commitTransaction();

            // Satýcýlar
            sql.beginTransaction();

            sql.initializeStoredProcedure("SP_LFA1_PURGE");
            sql.executeStoredProcedureNonQuery();

            for (int n = 0; n < lfa1.Length; n++)
            {
                sql.initializeStoredProcedure("SP_LFA1_INSERT");
                sql.addStoredProcedureParameter("@LIFNR", lfa1[n].LIFNR);
                sql.addStoredProcedureParameter("@NAME1_TR", lfa1[n].NAME1_TR);
                sql.addStoredProcedureParameter("@NAME1_AR", lfa1[n].NAME1_AR);
                sql.addStoredProcedureParameter("@VENDO", lfa1[n].VENDO);
                sql.addStoredProcedureParameter("@TRANS", lfa1[n].TRANS);
                sql.executeStoredProcedureNonQuery();
            }

            sql.commitTransaction();

            // Malzemeler
            sql.beginTransaction();

            sql.initializeStoredProcedure("SP_MARA_PURGE");
            sql.executeStoredProcedureNonQuery();

            for (int n = 0; n < mara.Length; n++)
            {
                sql.initializeStoredProcedure("SP_MARA_INSERT");
                sql.addStoredProcedureParameter("@MATNR", mara[n].MATNR);
                sql.addStoredProcedureParameter("@MAKTX_TR", mara[n].MAKTX_TR);
                sql.addStoredProcedureParameter("@MAKTX_AR", mara[n].MAKTX_AR);
                sql.addStoredProcedureParameter("@MATKL", mara[n].MATKL);
                sql.addStoredProcedureParameter("@WGBEZ_TR", mara[n].WGBEZ_TR);
                sql.addStoredProcedureParameter("@WGBEZ_AR", mara[n].WGBEZ_AR);
                sql.addStoredProcedureParameter("@SELLA", mara[n].SELLA);
                sql.addStoredProcedureParameter("@LOLIC", mara[n].LOLIC);
                sql.addStoredProcedureParameter("@LOLIM", mara[n].LOLIM);
                sql.addStoredProcedureParameter("@LOLIA", mara[n].LOLIA);
                sql.addStoredProcedureParameter("@UPLIC", mara[n].UPLIC);
                sql.addStoredProcedureParameter("@UPLIM", mara[n].UPLIM);
                sql.addStoredProcedureParameter("@UPLIA", mara[n].UPLIA);
                sql.executeStoredProcedureNonQuery();
            }

            sql.commitTransaction();


            // Teslimatlar
            sql.beginTransaction();

            sql.initializeStoredProcedure("SP_LIKP_PURGE");
            sql.executeStoredProcedureNonQuery();

            for (int n = 0; n < likp.Length; n++)
            {
                sql.initializeStoredProcedure("SP_LIKP_INSERT");
                sql.addStoredProcedureParameter("@VBELN", likp[n].VBELN);
                sql.addStoredProcedureParameter("@MATNR", likp[n].MATNR);
                sql.addStoredProcedureParameter("@LFIMG", likp[n].LFIMG);
                sql.addStoredProcedureParameter("@MEINS", likp[n].MEINS);
                sql.addStoredProcedureParameter("@KUNWE", likp[n].KUNWE);
                sql.addStoredProcedureParameter("@LIFSP", likp[n].LIFSP);
                sql.addStoredProcedureParameter("@TRAID", likp[n].TRAID);
                sql.addStoredProcedureParameter("@TRAID_FORMATTED", new PlateNumber(likp[n].TRAID.ToString()).plateNumber);
                sql.addStoredProcedureParameter("@LFDAT", SQL.parseSapDate(likp[n].LFDAT));

                sql.executeStoredProcedureNonQuery();
            }

            sql.commitTransaction();

            // Kantarlar
            for (int n = 0; n < kantar.Length; n++)
            {
                Steelyard.createOrModifyFromSAP(
                    sql, 
                    kantar[n].KANID, 
                    kantar[n].KANTX, 
                    kantar[n].SALOT, 
                    kantar[n].SAHIT,
                    kantar[n].MODEL,
                    kantar[n].COMPO,
                    kantar[n].BAUDR,
                    kantar[n].DATAB,
                    kantar[n].PARIT,
                    kantar[n].STOPB,
                    kantar[n].FREEM,
                    kantar[n].ADRE1,
                    kantar[n].ADRE2,
                    kantar[n].ADRE3,
                    kantar[n].ADRE4,
                    kantar[n].ADRE5,
                    kantar[n].ADRE6
                    );
            }

            // Bu kadar
            sql.disconnect();
        }

    }
}
