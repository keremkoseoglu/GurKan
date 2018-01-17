using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Text;

namespace Gurkan
{
    public class Steelyard
    {
        private string _kanid, _kantx;
        private Weight _daraa;
        private decimal _salesToleranceLow, _salesToleranceHigh;
        private bool newRecord, _testMode;
        protected SerialPort _serialPort;
        private string _model;
        private string _adre1, _adre2, _adre3, _adre4, _adre5, _adre6;

        private string[] serialData;
        private const int SERIAL_SIZE = 50;
        private bool dataReceivedActive;

        private SQL sql;

        public delegate void WeightCapturedDelegate(object sender, SteelyardWeightCapturedEventArgs e);
        public event WeightCapturedDelegate weightCaptured;

        public Steelyard(SQL S)
        {
            newRecord = true;
            sql = S;
        }

        public Steelyard(string Id, SQL S)
        {
            sql = S;
            read(Id);
        }

        public override string ToString()
        {
            return id + " - " + text;
        }

        #region DATABASE_STUFF

        public static void createOrModifyFromSAP(
            SQL S, 
            string Id, 
            string Text, 
            decimal SalesToleranceLow, 
            decimal SalesToleranceHigh,
            string Model,
            string ComPort,
            int BaudRate,
            int DataBits,
            string Parity,
            string StopBits,
            string FreeMode,
            string Address1,
            string Address2,
            string Address3,
            string Address4,
            string Address5,
            string Address6)
        {
            // Bu kantar tanýmý var mý? Varsa güncelleyeceðiz, yoksa yaratacaðýz
            Steelyard s = new Steelyard(S); ;

            bool exists = false;
            try
            {
                s = new Steelyard(Id, S);
                exists = true;
            } 
            catch (Exception ex)
            {
            }

            // Ortak parametreler
            s.text = Text;
            s.salesToleranceLow = SalesToleranceLow;
            s.salesToleranceHigh = SalesToleranceHigh;
            s.model = Model;
            s.portName = ComPort;
            s.baudRate = BaudRate;
            s.dataBits = DataBits;
            s.parity = Parity;
            s.stopBits = StopBits;
            s.testMode = FreeMode == "X";
            s.addressLine = new string[6] { Address1, Address2, Address3, Address4, Address5, Address6 };

            // Taným yoksa, yeni yaratacaðýz
            if (!exists)
            {
                s.id = Id;
            }

            // Kaydet
            s.save();
        }

        private void read(string Id)
        {
            // SQL'den alalým
            sql.initializeStoredProcedure("SP_GENERAL_GET_SINGLE");
            sql.addStoredProcedureParameter("@KANID", Id);
            DataTable dt = sql.executeStoredProcedureReader();

            if (dt == null || dt.Rows.Count <= 0) throw new Exception("Kantar tanýmlý deðil");
            DataRow dr = dt.Rows[0];

            id = dr["KANID"].ToString();
            _testMode = dr["FREEM"].ToString() == "X";
            model = dr["MODEL"].ToString();
            text = dr["KANTX"].ToString();
            try { salesToleranceLow = (decimal)dr["SALOT"]; } catch {}
            try { salesToleranceHigh = (decimal)dr["SAHIT"]; } catch {}
            try { weight = new Weight((decimal)dr["DARAA"], Weight.UOM.KG); } catch (Exception ex) { weight = new Weight(0, Weight.UOM.KG); }

            addressLine = new string[6] { 
                dr["ADRE1"].ToString(), 
                dr["ADRE2"].ToString(), 
                dr["ADRE3"].ToString(), 
                dr["ADRE4"].ToString(), 
                dr["ADRE5"].ToString(), 
                dr["ADRE6"].ToString() };

            // Seri port
            _serialPort = new SerialPort();
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
            try { baudRate = (int)dr["BAUDR"]; } catch { }
            try { dataBits = (int)dr["DATAB"]; } catch { }
            try { portName = dr["COMPO"].ToString(); } catch { }
            try { parity = dr["PARIT"].ToString(); } catch { }
            try { stopBits = dr["STOPB"].ToString(); } catch { }

            // Flag
            newRecord = false;
        }

        private void save()
        {
            if (newRecord)
            {
                sql.initializeStoredProcedure("SP_GENERAL_INSERT");
                addStoredProcedureParameters();
                sql.executeStoredProcedureNonQuery();

                newRecord = false;
            }
            else
            {
                sql.initializeStoredProcedure("SP_GENERAL_UPDATE");
                addStoredProcedureParameters();
                sql.executeStoredProcedureNonQuery();
            }
        }

        public void savePlatformWeight()
        {
            sql.connect();
            sql.initializeStoredProcedure("SP_GENERAL_SET_PLATFORM_WEIGHT");
            sql.addStoredProcedureParameter("@KANID", id);
            sql.addStoredProcedureParameter("@DARAA", weight.getWeight());
            sql.executeStoredProcedureNonQuery();
        }

        private void addStoredProcedureParameters()
        {
            sql.addStoredProcedureParameter("@KANID", id);
            sql.addStoredProcedureParameter("@KANTX", text);
            sql.addStoredProcedureParameter("@SALOT", salesToleranceLow);
            sql.addStoredProcedureParameter("@SAHIT", salesToleranceHigh);
            sql.addStoredProcedureParameter("@MODEL", model);
            sql.addStoredProcedureParameter("@COMPO", portName);
            sql.addStoredProcedureParameter("@BAUDR", baudRate);
            sql.addStoredProcedureParameter("@DATAB", dataBits);
            sql.addStoredProcedureParameter("@PARIT", parity);
            sql.addStoredProcedureParameter("@STOPB", stopBits);
            sql.addStoredProcedureParameter("@FREEM", _testMode ? "X" : "");
            sql.addStoredProcedureParameter("@ADRE1", addressLine[0]);
            sql.addStoredProcedureParameter("@ADRE2", addressLine[1]);
            sql.addStoredProcedureParameter("@ADRE3", addressLine[2]);
            sql.addStoredProcedureParameter("@ADRE4", addressLine[3]);
            sql.addStoredProcedureParameter("@ADRE5", addressLine[4]);
            sql.addStoredProcedureParameter("@ADRE6", addressLine[5]);
        }

        #endregion

        #region Properties
        public string id { get { return _kanid; } set { _kanid = value; } }
        public string text { get { return _kantx; } set { _kantx = value; } }
        public Weight weight { get { return _daraa; } set { _daraa = value; } }
        public decimal salesToleranceLow { get { return _salesToleranceLow; } set { _salesToleranceLow = value; } }
        public decimal salesToleranceHigh { get { return _salesToleranceHigh; } set { _salesToleranceHigh = value; } }
        public string model { get { return _model; } set { _model = value; } }
        public bool testMode { get { return _testMode; } set { _testMode = value; } }
        public string portName { get { if (_serialPort == null) return ""; return _serialPort.PortName; } set { if (_serialPort == null) return; _serialPort.PortName = value; } }
        public int baudRate { get { if (_serialPort == null) return 0; return _serialPort.BaudRate; } set { if (_serialPort == null) return; _serialPort.BaudRate = value; } }
        public int dataBits { get { if (_serialPort == null) return 0; return _serialPort.DataBits; } set { if (_serialPort == null) return; _serialPort.DataBits = value; } }
        public string parity
        {
            get
            {
                if (_serialPort == null) return "NONE";

                switch (_serialPort.Parity)
                {
                    case Parity.Even:
                        return "EVEN";
                        break;
                    case Parity.Mark:
                        return "MARK";
                        break;
                    case Parity.None:
                        return "NONE";
                        break;
                    case Parity.Odd:
                        return "ODD";
                        break;
                    case Parity.Space:
                        return "SPACE";
                        break;
                }

                return "";
            }

            set
            {
                if (_serialPort == null) return;

                switch (value)
                {
                    case "EVEN":
                        _serialPort.Parity = Parity.Even;
                        return;
                    case "MARK":
                        _serialPort.Parity = Parity.Mark;
                        return;
                    case "NONE":
                        _serialPort.Parity = Parity.None;
                        return;
                    case "ODD":
                        _serialPort.Parity = Parity.Odd;
                        return;
                    case "SPACE":
                        _serialPort.Parity = Parity.Space;
                        return;
                }

                throw new Exception("Parity deðeri hatalý");
            }
        }
        public string stopBits
        {
            get
            {
                if (_serialPort == null) return "NONE";

                switch (_serialPort.StopBits)
                {
                    case StopBits.None:
                        return "NONE";
                        break;
                    case StopBits.One:
                        return "ONE";
                        break;
                    case StopBits.OnePointFive:
                        return "OPF";
                        break;
                    case StopBits.Two:
                        return "TWO";
                        break;
                }

                return "";
            }

            set
            {
                if (_serialPort == null) return;

                switch (value)
                {
                    case "NONE":
                        _serialPort.StopBits = StopBits.None;
                        return;
                    case "ONE":
                        _serialPort.StopBits = StopBits.One;
                        return;
                    case "OPF":
                        _serialPort.StopBits = StopBits.OnePointFive;
                        return;
                    case "TWO":
                        _serialPort.StopBits = StopBits.Two;
                        return;
                }

                throw new Exception("StopBits deðeri hatalý");
            }
        }

        public string[] addressLine
        {
            get
            {
                string[] ret = new string[6];
                ret[0] = _adre1;
                ret[1] = _adre2;
                ret[2] = _adre3;
                ret[3] = _adre4;
                ret[4] = _adre5;
                ret[5] = _adre6;
                return ret;
            }

            set
            {
                _adre1 = value[0];
                _adre2 = value[1];
                _adre3 = value[2];
                _adre4 = value[3];
                _adre5 = value[4];
                _adre6 = value[5];
            }
        }

        #endregion

        #region weight_stuff

        public void getWeight()
        {
            serialData = new string[SERIAL_SIZE];
            _serialPort.Open();
        }

        protected void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Veriyi alalým
            string curData = _serialPort.ReadExisting();

            // Veri mutlaka p+ veya t+ diye baþlamalý
            if (curData.Substring(0, 2) != "p+" && curData.Substring(0, 2) != "t+") return;

            // Bu Event'ten ayný anda bir tane etkin olabilir
            if (dataReceivedActive) return;
            dataReceivedActive = true;

            // Son gelen 50 veriyi saklayacaðýz, birbiriyle ayný olduðu anda aðýrlýk tamdýr
            bool emptyCellFound = false;
            for (int n = 0; n < SERIAL_SIZE; n++)
            {
                if (serialData[n] == "")
                {
                    emptyCellFound = true;
                    serialData[n] = curData;
                    n = SERIAL_SIZE + 1;
                }
            }

            if (!emptyCellFound)
            {
                for (int n = 0; n < SERIAL_SIZE - 1; n++)
                {
                    serialData[n] = serialData[n + 1];
                }
                serialData[SERIAL_SIZE - 1] = curData;


                bool differentCellFound = false;
                for (int n = 0; n < SERIAL_SIZE - 1; n++) if (serialData[n] != serialData[n + 1]) differentCellFound = true;

                if (!differentCellFound)
                {
                    Weight w = new Weight(Decimal.Parse(curData.Substring(2, 6)), Weight.UOM.KG);
                    weightCaptured(this, new SteelyardWeightCapturedEventArgs(w));
                    _serialPort.Close();
                }
            }

            // Flag
            dataReceivedActive = false;
        }

        #endregion
    }
}
