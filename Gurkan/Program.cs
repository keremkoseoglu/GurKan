using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Gurkan
{
    static class Program
    {
        public static FormMain frmMain;
        public static FormTest frmTest;
        public static FormWeight1 frmW1;
        public static FormWeight2 frmW2;
        public static FormPlatformWeight frmPlatformWeight;
        public static FormFreeWeight frmFreeWeight;
        public static FormReprint frmReprint;
        public static FormEdit frmEdit;

        public static SAP sap;
        public static SQL sql;
        public static Settings1 config;
        public static Logger logger;
        public static Steelyard steelyard;

        public static Sync sync;

        public static string lastOperator;

        public static ThreadStart syncStart;
        public static Thread syncThread;

        private static string _appName;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            config = new Settings1();
            sap = new SAP();
            sql = new SQL();
            logger = new Logger(Application.StartupPath);
            lastOperator = "";

            try
            {
                steelyard = new Steelyard(config.KantarID, sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ayar dosyasýnda kantar ID'si hatalý, kontrol edin: " + ex.ToString());
                return;
            }

            sync = new Sync();
            syncStart = new ThreadStart(sync.doSync);
            syncThread = new Thread(syncStart);
            syncThread.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmMain = new FormMain();
            frmMain.setIntegrationStatus(Common.STATUS.GRAY);
            Application.Run(frmMain);

        }

        public static string appName
        {
            get
            {
                if (_appName == null || _appName.Length <= 0)
                {
                    Version v = new Version(Application.ProductVersion);
                    _appName = "Güriþ Kantar Programý " + v.Major + "." + v.Minor;
                }
                return _appName;
            }
        }


    }
}