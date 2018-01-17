using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Gurkan
{
    public class SQL
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlTransaction transaction;

        #region BASICS

        public SQL()
        {
        }

        public void connect()
        {
            if (connection != null) connection.Close();
            connection = new SqlConnection();
            connection.ConnectionString = Program.config.SqlConnectionString;
            connection.Open();
        }

        public void disconnect()
        {
            connection.Close();
            connection = null;
        }

        public void beginTransaction()
        {
            connect();
            transaction = connection.BeginTransaction();
        }

        public void initializeStoredProcedure(string name)
        {
            if (transaction == null) connect();
            command = new SqlCommand(name, connection);
            command.CommandType = CommandType.StoredProcedure;
            if (transaction != null) command.Transaction = transaction;
        }


        public void addStoredProcedureParameter(string name, object value)
        {
            command.Parameters.Add(new SqlParameter(name, value));
        }

        public void executeStoredProcedureNonQuery()
        {
            command.ExecuteNonQuery();
        }

        public DataTable executeStoredProcedureReader()
        {
            return convertReaderToTable(command.ExecuteReader());
        }

        public void commitTransaction()
        {
            transaction.Commit();
            transaction = null;
        }

        public DataTable selectData(string Query)
        {
            connect();
            command = new SqlCommand(Query, connection);
            return convertReaderToTable(command.ExecuteReader());
        }

        private DataTable convertReaderToTable(SqlDataReader S)
        {
            if (S == null) return null;
            DataTable ret = new DataTable();

            DataTable schema = S.GetSchemaTable();
            for (int n = 0; n < schema.Rows.Count; n++) ret.Columns.Add(new DataColumn((String)schema.Rows[n]["ColumnName"], (Type)schema.Rows[n]["DataType"]));

            while (S.Read())
            {
                DataRow dr = ret.NewRow();
                for (int n = 0; n < S.FieldCount; n++) dr[n] = S.GetValue(n);
                ret.Rows.Add(dr);
            }

            return ret;
        }

        #endregion

        #region TEST_DATA

        public void insertTestData(string TurkishText, string ArabicText)
        {
            beginTransaction();
            initializeStoredProcedure("SP_SYSTEM_TEST_PURGE");
            executeStoredProcedureNonQuery();
            executeStoredProcedureNonQuery();

            insertTestDataSingle("TR", TurkishText);
            insertTestDataSingle("AR", ArabicText);

            commitTransaction();
        }

        private void insertTestDataSingle(string Spras, string Stext)
        {
            initializeStoredProcedure("SP_SYSTEM_TEST_INSERT");
            addStoredProcedureParameter("@SPRAS", Spras);
            addStoredProcedureParameter("@STEXT", Stext);
            executeStoredProcedureNonQuery();
        }

        public void getTestData(out string TurkishText, out string ArabicText)
        {
            ArabicText = TurkishText = "";

            command = new SqlCommand("SELECT * FROM SYSTEM_TEST", connection);
            DataTable dt = convertReaderToTable(command.ExecuteReader());
            foreach (DataRow dr in dt.Rows)
            {
                string spras = dr["SPRAS"].ToString();
                string stext = dr["STEXT"].ToString();

                switch (spras)
                {
                    case "AR":
                        ArabicText = stext;
                        break;
                    case "TR":
                        TurkishText = stext;
                        break;
                }
            }
        }

        #endregion

        #region SAP_INTEGRATION

        public DataTable getSqlData()
        {
            return selectData("SELECT * FROM VW_TARTIM_TO_SAP");
        }

        public void setTartimTransferred(int Tarid)
        {
            initializeStoredProcedure("SP_TARTIM_SET_TRANSFERRED");
            addStoredProcedureParameter("@TARID", Tarid);
            executeStoredProcedureNonQuery();
        }

        #endregion


        #region DATA_TYPES
        public static DateTime parseSapDate(string Date)
        {
            if ((Date.Length <= 0) || (Date == "00000000")) return new DateTime();

            int y = Int32.Parse(Date.Substring(0, 4));
            int m = Int32.Parse(Date.Substring(5, 2));
            int d = Int32.Parse(Date.Substring(8, 2));
            return new DateTime(y, m, d);
        }
        #endregion
    }
}
