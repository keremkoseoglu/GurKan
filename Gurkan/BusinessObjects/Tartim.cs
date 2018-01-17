using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Gurkan
{
    public class Tartim
    {
        public enum SCENARIO { PURCHASING, SALES, FREE, NULL };
        public enum ORDER { FIRST, SECOND };

        //public delegate void TartimEventDelegate(object sender, TartimE

        public delegate void DeliveryUpperBoundExceededDelegate(object sender, TartimDeliveryUpperBoundExceededEventArgs e);
        public event DeliveryUpperBoundExceededDelegate deliveryUpperBoundExceeded;
        public event DeliveryUpperBoundExceededDelegate deliveryLowerBoundExceeded;

        private int _tarid;
        private string _gelal, _gital, _stext, _mubel, _opera, _drive;
        private DateTime _erda1, _erda2;
        private bool _sapak;

        private Steelyard _kanid;
        private Counterparty _muhid;
        private Counterparty _lifsp;
        private Material _matnr;
        private Weight _daraa, _agir1, _agir2, _netag, _belag;
        private PlateNumber _traid;
        private SCENARIO _tarti;
        private bool _bitti;
        private int _bagco;
        private string _wtext_ar;

        private Document _document;

        #region Initialization

        public Tartim()
        {
            // Varsayýlan deðerler
            setDefaultValues();
        }

        public Tartim(DataRow TartimDataRow)
        {
            setDefaultValues();
            fromTartimDataRow(TartimDataRow);
        }

        public override string ToString()
        {
            if (document == null) return ""; else return document.ToString();
        }

        #region SEARCH

        public static Tartim[] getTartims(PlateNumber P, ORDER O)
        {
            Tartim[] ret;

            DataTable dt;

            // Öncelik 1: Bu plaka için mevcutta yarým kalmýþ bir tartým var mý?
            Program.sql.initializeStoredProcedure("SP_TARTIM_GET_OPEN_BY_PLATE_NUMBER");
            Program.sql.addStoredProcedureParameter("@TRAID", P.plateNumber);
            dt = Program.sql.executeStoredProcedureReader();
            if (dt != null && dt.Rows.Count > 0)
            {
                if (O == ORDER.FIRST)
                {
                    throw new TartimVehicleAlreadyPassedException();
                }

                ret = new Tartim[1];
                ret[0] = new Tartim();
                ret[0].fromTartimDataRow(dt.Rows[0]);
                return ret;
            }

            // Öncelik 2: Bu plaka için mevcutta bir(kaç) teslimat var mý?
            ret = getTartims(P);
            if (ret != null) return ret;

            // Dönüþ
            return null;
        }

        public static Tartim[] getTartims(PlateNumber P)
        {
            Tartim[] ret;

            Program.sql.initializeStoredProcedure("SP_LIKP_GET_BY_PLATE_NUMBER");
            Program.sql.addStoredProcedureParameter("@TRAID", P.plateNumber);
            DataTable dt = Program.sql.executeStoredProcedureReader();
            if (dt != null && dt.Rows.Count > 0)
            {
                ret = new Tartim[dt.Rows.Count];
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    ret[n] = new Tartim();
                    ret[n].fromLikpDataRow(dt.Rows[n]);
                }
                return ret;
            }

            return null;
        }

        public static Tartim[] getTartims(SCENARIO S)
        {
            Tartim[] ret;

            Program.sql.connect();
            Program.sql.initializeStoredProcedure("SP_TARTIM_GET_OPEN_BY_TARTI");
            Program.sql.addStoredProcedureParameter("@TARTI", parseScenario(S));
            DataTable dt = Program.sql.executeStoredProcedureReader();
            if (dt == null || dt.Rows.Count <= 0) return null;

            ret = new Tartim[dt.Rows.Count];
            for (int n = 0; n < dt.Rows.Count; n++) ret[n] = new Tartim(dt.Rows[n]);

            return ret;
        }

        public static Tartim[] getTartims(DateTime Date1, DateTime Date2, Tartim.SCENARIO Scenario, PlateNumber Plate)
        {
            Program.sql.connect();
            Program.sql.initializeStoredProcedure("SP_TARTIM_SEARCH");
            Program.sql.addStoredProcedureParameter("@DATE1", new DateTime(Date1.Year, Date1.Month, Date1.Day, 0, 0, 0));
            Program.sql.addStoredProcedureParameter("@DATE2", new DateTime(Date2.Year, Date2.Month, Date2.Day, 23, 59, 59));
            if (Scenario != Tartim.SCENARIO.NULL) Program.sql.addStoredProcedureParameter("@TARTI", Tartim.parseScenario(Scenario));
            if (Plate != null && Plate.plateNumber != null && Plate.plateNumber.Trim().Length > 0) Program.sql.addStoredProcedureParameter("@TRAID", Plate.plateNumber);
            DataTable dt = Program.sql.executeStoredProcedureReader();

            if (dt == null) return null;

            Tartim[] ret = new Tartim[dt.Rows.Count];
            for (int n = 0; n < dt.Rows.Count; n++) ret[n] = new Tartim(dt.Rows[n]);
            return ret;
        }

        #endregion

        private void setDefaultValues()
        {
            platformWeight = Program.steelyard.weight;
            _kanid = Program.steelyard;
        }

        private void fromTartimDataRow(DataRow D)
        {
            this.scenario = parseScenario(D["TARTI"].ToString());

            this.areaFrom = D["GELAL"].ToString();
            this.areaTo = D["GITAL"].ToString();
            try { this.bagCount = (int)D["BAGCO"]; } catch { }
            try { this.counterParty = new Counterparty(this.scenario == SCENARIO.SALES ? Counterparty.TYPE.CLIENT : Counterparty.TYPE.VENDOR, D["MUHID"].ToString(), false); } catch { }
            this.counterPartyDocumentNumber = D["MUBEL"].ToString();
            this.driver = D["DRIVE"].ToString();
            this.employee = D["OPERA"].ToString();
            try { this.firstWeight = new Weight((decimal)D["AGIR1"], D["MEINS"].ToString()); } catch { }
            this.firstWeightDate = (DateTime)D["ERDA1"];
            this.isOver = D["BITTI"].ToString() == "X";
            this.material = new Material(D["MATNR"].ToString());
            this.notes = D["STEXT"].ToString();
            this.plateNumber = new PlateNumber(D["TRAID"].ToString());
            try { this.platformWeight = new Weight((decimal)D["DARAA"], D["MEINS"].ToString()); } catch { }
            try { this.secondWeight = new Weight((decimal)D["AGIR2"], D["MEINS"].ToString()); } catch { }
            try { this.secondWeightDate = (DateTime)D["ERDA2"]; } catch { }
            this._sapak = D["SAPAK"].ToString() == "X";
            try { this.transporter = new Counterparty(Counterparty.TYPE.VENDOR, D["LIFSP"].ToString(), false); } catch { }
            this.weightId = (int)D["TARID"];
            this.weightTextAR = D["WTEXT_AR"].ToString();


            try { _netag = new Weight((decimal)D["NETAG"], D["MEINS"].ToString()); } catch { }

            try
            {
                this.document = new Document(
                    D["BELGE"].ToString(),
                    new Weight((decimal)D["BELAG"], D["BELME"].ToString()),
                    this.material,
                    this.counterParty,
                    this.transporter);
            } catch { }
        }

        public void fromLikpDataRow(DataRow D)
        {
            this.scenario = SCENARIO.SALES;

            if (D == null) return;

            this.counterParty = new Counterparty(Counterparty.TYPE.CLIENT, D["KUNWE"].ToString(), false);
            this.material = new Material(D["MATNR"].ToString());
            this.plateNumber = new PlateNumber(D["TRAID"].ToString());
            try { this.transporter = new Counterparty(Counterparty.TYPE.VENDOR, D["LIFSP"].ToString(), false); } catch { this.transporter = null; }

            this.document = new Document(
                D["VBELN"].ToString(),
                new Weight((decimal)D["LFIMG"], D["MEINS"].ToString()),
                this.material,
                this.counterParty,
                this.transporter);
        }

        #endregion

        #region Properties

        public string areaFrom { get { return _gelal; } set { _gelal = value; } }
        public string areaTo { get { return _gital; } set { _gital = value; } }
        public int bagCount { get { return _bagco; } set { _bagco = value; } }
        public Counterparty counterParty
        {
            get
            {
                return _muhid;
            }
            set
            {
                _muhid = value;
            }
        }

        public string counterPartyDocumentNumber
        {
            get { return _mubel; }
            set { _mubel = value.ToUpper(); }
        }

        public Document document
        {
            get { return _document; }
            set 
            { 
                _document = value;
                compareNetWeightWithDocumentWeight();
            }
        }

        public string driver { get { return _drive; } set { _drive = value; } }

        public string employee { get { return _opera; } set { _opera = value; } }

        public Weight firstWeight
        {
            get
            {
                return _agir1;
            }
            set
            {
                _agir1 = value;
                calculateNetWeight();
            }
        }
        public DateTime firstWeightDate
        {
            get { return _erda1; }
            set { _erda1 = value; }
        }
        public bool isOver { get { return _bitti; } set { _bitti = value; } }
        public Material material
        {
            get
            {
                return _matnr;
            }

            set
            {
                _matnr = new Material(value.id);
            }
        }
        public Weight netWeight { get { return _netag; } }

        public string notes { get { return _stext; } set { _stext = value; } }
        
        public PlateNumber plateNumber { get { return _traid; } set { _traid = value; } }
        public Weight platformWeight { get { return _daraa; } set { _daraa = value; } }
        public SCENARIO scenario { get { return _tarti; } set { _tarti = value; } }
        public Weight secondWeight
        {
            get
            {
                return _agir2;
            }
            set
            {
                _agir2 = value;
                calculateNetWeight();
            }
        }
        public DateTime secondWeightDate
        {
            get { return _erda2; }
            set { _erda2 = value; }
        }
        public Steelyard steelyard
        {
            get
            {
                if (_kanid == null) _kanid = new Steelyard(Program.config.KantarID, Program.sql);
                return _kanid;
            }
        }
        public bool transferredToSAP
        {
            get { return _sapak; }
        }
        public Counterparty transporter
        {
            get
            {
                return _lifsp;
            }
            set
            {
                if (value == null) { _lifsp = new Counterparty(Counterparty.TYPE.VENDOR, "", true); return; }
                _lifsp = new Counterparty(Counterparty.TYPE.VENDOR, value.id, false);
            }
        }
        public int weightId { get { return _tarid; } set { _tarid = value; } }

        public string weightTextAR { get { return _wtext_ar; } set { _wtext_ar = value; } }
        public string weightTextTR { get { if (netWeight == null) return ""; return netWeight.weightText; } }

        public bool hasDocument
        {
            get
            {
                if (document == null) return false;
                if (document.number.Length <= 0) return false;
                return true;
            }
        }

        #endregion

        public void delete()
        {
            Program.sql.connect();
            Program.sql.initializeStoredProcedure("SP_TARTIM_DELETE");
            Program.sql.addStoredProcedureParameter("@TARID", this.weightId);
            Program.sql.executeStoredProcedureNonQuery();
        }

        private void calculateNetWeight()
        {
            _netag = new Weight();

            if (_agir1 == null || (scenario != SCENARIO.FREE && _agir2 == null))
            {
                _netag.setWeight(0, Weight.UOM.KG);
                return;
            }
            else
            {
                switch (scenario)
                {
                    case SCENARIO.PURCHASING:
                        _netag.setWeight(_agir1.getWeight() - _agir2.getWeight(), _agir1.uom);
                        break;
                    case SCENARIO.SALES:

                        // Hesap
                        _netag.setWeight(_agir2.getWeight() - _agir1.getWeight(), _agir2.uom);

                        // Tolerans kontrolü
                        compareNetWeightWithDocumentWeight();

                        break;
                    case SCENARIO.FREE:
                        _netag.setWeight(_agir1.getWeight() - steelyard.weight.getWeight(), _agir1.uom);
                        break;
                }

                // Negatif net aðýrlýk olamaz
                if (_netag.getWeight() < 0)
                {
                    throw new TartimNegativeWeightException();
                }
            }
        }

        private void compareNetWeightWithDocumentWeight()
        {
            // Kontrol: Malzeme belli deðilse, burada birþey yapamayýz
            if (material == null) return;

            // Devam
            if (_agir1 != null && _agir2 != null && document != null && document.weight != null)
            {
                decimal diff = _netag.getWeight() - document.weight.getWeight();

                decimal difp = 0;
                if (document.weight.getWeight() == 0)
                {
                    difp = 100;
                }
                else
                {
                    difp = document.weight.getWeight() == 0 ? 100 : (diff / document.weight.getWeight()) * 100;
                }

                if (material.highSalesLimitMustBeControlled && difp > material.highSalesLimitRate)
                {
                    if (material.highSalesLimitExceedAction == Material.SALES_LIMIT_EXCEED_ACTION.ERROR)
                    {
                        throw new TartimSalesToleranceLimitExceededException(difp);
                    }
                    else
                    {
                        deliveryUpperBoundExceeded(this, new TartimDeliveryUpperBoundExceededEventArgs(difp));
                    }
                }

                if (material.lowSalesLimitMustBeControlled && difp < material.lowSalesLimitRate * -1)
                {
                    if (material.lowSalesLimitExceedAction == Material.SALES_LIMIT_EXCEED_ACTION.ERROR)
                    {
                        throw new TartimSalesToleranceLimitExceededException(difp);
                    }
                    else
                    {
                        deliveryLowerBoundExceeded(this, new TartimDeliveryUpperBoundExceededEventArgs(difp));
                    }
                }

            }
        }

        private void validateMandantoryFields()
        {
            // Satýnalma sürecinde irsaliye no zorunlu
            if (scenario == SCENARIO.PURCHASING && (counterPartyDocumentNumber == null || counterPartyDocumentNumber.Length <= 0))
            {
                throw new TartimMissingFieldException("Muhatap Belge No");
            }
        }

        public void saveFirst()
        {
            validateMandantoryFields();

            Program.sql.connect();
            Program.sql.initializeStoredProcedure("SP_TARTIM_FIRST");
	        Program.sql.addStoredProcedureParameter("@KANID", steelyard.id);
	        Program.sql.addStoredProcedureParameter("@TARTI", parseScenario(scenario));
	        Program.sql.addStoredProcedureParameter("@TRAID", plateNumber.plateNumber);
	        if (document != null) Program.sql.addStoredProcedureParameter("@BELGE", document.number);
	        Program.sql.addStoredProcedureParameter("@MUHID", counterParty.id);
	        Program.sql.addStoredProcedureParameter("@NAME1_TR", counterParty.turkishName);
	        Program.sql.addStoredProcedureParameter("@NAME1_AR", counterParty.arabicName);
	        Program.sql.addStoredProcedureParameter("@MATNR", material.id);
	        Program.sql.addStoredProcedureParameter("@MAKTX_TR", material.turkishName);
	        Program.sql.addStoredProcedureParameter("@MAKTX_AR", material.arabicName);
            if (transporter != null)
            {
                Program.sql.addStoredProcedureParameter("@LIFSP", transporter.id);
                Program.sql.addStoredProcedureParameter("@NAKTR", transporter.turkishName);
                Program.sql.addStoredProcedureParameter("@NAKAR", transporter.arabicName);
            }
	        Program.sql.addStoredProcedureParameter("@GELAL", areaFrom);
	        Program.sql.addStoredProcedureParameter("@GITAL", areaTo);
	        Program.sql.addStoredProcedureParameter("@STEXT", notes);
	        Program.sql.addStoredProcedureParameter("@DARAA", steelyard.weight.getWeight());
	        Program.sql.addStoredProcedureParameter("@MEINS", steelyard.weight.uomText);
	        Program.sql.addStoredProcedureParameter("@AGIR1", firstWeight.getWeight());
            if (document != null && document.weight != null)
            {
                Program.sql.addStoredProcedureParameter("@BELAG", document.weight.getWeight());
                Program.sql.addStoredProcedureParameter("@BELME", document.weight.uomText);
            }
            Program.sql.addStoredProcedureParameter("@MUBEL", counterPartyDocumentNumber);
            Program.sql.addStoredProcedureParameter("@OPERA", employee);
            Program.sql.addStoredProcedureParameter("@DRIVE", driver);
            Program.sql.executeStoredProcedureNonQuery();
        }

        public void saveSecond()
        {
            validateMandantoryFields();

            Program.sql.connect();
            Program.sql.initializeStoredProcedure("SP_TARTIM_SECOND");
            Program.sql.addStoredProcedureParameter("@TARID", this.weightId);
            Program.sql.addStoredProcedureParameter("@GELAL", this.areaFrom);
            Program.sql.addStoredProcedureParameter("@GITAL", this.areaTo);
            Program.sql.addStoredProcedureParameter("@STEXT", this.notes);
            Program.sql.addStoredProcedureParameter("@AGIR2", this.secondWeight.getWeight());
            Program.sql.addStoredProcedureParameter("@NETAG", this.netWeight.getWeight());
            Program.sql.addStoredProcedureParameter("@MUBEL", counterPartyDocumentNumber);
            Program.sql.addStoredProcedureParameter("@OPERA", employee);
            Program.sql.addStoredProcedureParameter("@DRIVE", driver);

            Program.sql.addStoredProcedureParameter("@BAGCO", bagCount);
            Program.sql.addStoredProcedureParameter("@WTEXT_TR", weightTextTR);
            Program.sql.addStoredProcedureParameter("@WTEXT_AR", weightTextAR);

            Program.sql.executeStoredProcedureNonQuery();
        }

        public void update()
        {
            validateMandantoryFields();

            Program.sql.connect();
            Program.sql.initializeStoredProcedure("SP_TARTIM_UPDATE");
            Program.sql.addStoredProcedureParameter("@TARID", this.weightId);
            Program.sql.addStoredProcedureParameter("@TRAID", plateNumber.plateNumber);
            if (document != null) Program.sql.addStoredProcedureParameter("@BELGE", document.number);
            Program.sql.addStoredProcedureParameter("@MUHID", counterParty.id);
            Program.sql.addStoredProcedureParameter("@NAME1_TR", counterParty.turkishName);
            Program.sql.addStoredProcedureParameter("@NAME1_AR", counterParty.arabicName);
            Program.sql.addStoredProcedureParameter("@MATNR", material.id);
            Program.sql.addStoredProcedureParameter("@MAKTX_TR", material.turkishName);
            Program.sql.addStoredProcedureParameter("@MAKTX_AR", material.arabicName);
            if (transporter != null)
            {
                Program.sql.addStoredProcedureParameter("@LIFSP", transporter.id);
                Program.sql.addStoredProcedureParameter("@NAKTR", transporter.turkishName);
                Program.sql.addStoredProcedureParameter("@NAKAR", transporter.arabicName);
            }
            Program.sql.addStoredProcedureParameter("@GELAL", areaFrom);
            Program.sql.addStoredProcedureParameter("@GITAL", areaTo);
            Program.sql.addStoredProcedureParameter("@STEXT", notes);
            if (document != null && document.weight != null)
            {
                Program.sql.addStoredProcedureParameter("@BELAG", document.weight.getWeight());
                Program.sql.addStoredProcedureParameter("@BELME", document.weight.uomText);
            }
            Program.sql.addStoredProcedureParameter("@MUBEL", counterPartyDocumentNumber);
            Program.sql.addStoredProcedureParameter("@OPERA", employee);
            Program.sql.addStoredProcedureParameter("@DRIVE", driver);
            Program.sql.executeStoredProcedureNonQuery();
        }



        #region SCENARIO

        public static string parseScenario(SCENARIO S)
        {
            if (S == SCENARIO.SALES) return "B";
            if (S == SCENARIO.PURCHASING) return "A";
            return null;
        }

        public static SCENARIO parseScenario(string S)
        {
            if (S == "B") return SCENARIO.SALES;
            if (S == "A") return SCENARIO.PURCHASING;
            return SCENARIO.NULL;
        }

        public static string getScenarioText(SCENARIO S)
        {
            switch (S)
            {
                case SCENARIO.FREE:
                    return "Serbest Tartým";
                case SCENARIO.NULL:
                    return null;
                case SCENARIO.PURCHASING:
                    return "Satýnalma";
                case SCENARIO.SALES:
                    return "Satýþ";
            }

            return null;
        }

        public static string getScenarioText(string Scenario)
        {
            return getScenarioText(parseScenario(Scenario));
        }

        #endregion

        #region PRINTING
        public void printWeightDocument()
        {
            PrintoutWeight pw = new PrintoutWeight();
            pw.print(this);
        }
        public void printDeliveryDocument()
        {
            PrintoutDelivery pd = new PrintoutDelivery();
            pd.print(this);
        }
        #endregion
    }
}
