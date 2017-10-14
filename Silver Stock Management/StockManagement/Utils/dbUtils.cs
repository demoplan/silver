using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace StockManagement.Utils
{
    class dbUtils
    {
        //Public currForm As Object = vbNull
        //public static object currInFocus = Constants.vbNull;
        //public static int formCount;
        public static OleDbConnection dbcon = new OleDbConnection();
        public static OleDbConnection lgCon = new OleDbConnection();
        public static DataSet ds = new DataSet();
        public static string str;
        public static string Cpath;
        public static void loginConnection()
        {
            try
            {
                string Path = Application.StartupPath + "\\Data\\company.mdb";
                lgCon.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path + ";Jet OLEDB:database password=Newuser@123";
                lgCon.Open();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                MessageBox.Show("There is some problem in database connection");
                LoggingManager.WriteToLog(0, "Error : loginConnection() : " + err.Message);
            }
        }


        public static OleDbConnection getConnection()
        {
            try
            {
                string Path = Application.StartupPath + "\\Data\\SM.accdb";
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";Jet OLEDB:database password=sRISRI@123";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                return connection;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                MessageBox.Show("There is some problem in database connection");
                LoggingManager.WriteToLog(0, "Error : Connection() : " + err.Message);
                return null;
            }

        }
        public static void connection()
        {
            try
            {
                string Path = Application.StartupPath + "\\Data\\SM.accdb";
                Cpath = Path;
                dbcon.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";Jet OLEDB:database password=sRISRI@123";
                if (dbcon.State == ConnectionState.Closed)
                    dbcon.Open();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                MessageBox.Show("There is some problem in database connection");
                LoggingManager.WriteToLog(0, "Error : Connection() : " + err.Message);
                disConnect();
            }

        }
        public static void disConnect()
        {
            try
            {
                dbcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                LoggingManager.WriteToLog(0, "Error : disConnect() : " + ex.Message);
            }

        }
        public static OleDbDataReader loginFetch(string str)
        {
            OleDbCommand Cmd_fetch = null;
            OleDbDataReader Fetch_dr = null;
            Cmd_fetch = new OleDbCommand(str, lgCon);
            Fetch_dr = Cmd_fetch.ExecuteReader();
            return Fetch_dr;
        }

        public static OleDbDataReader fetch(string str)
        {
            if (dbcon.ConnectionString.Length == 0)
            {
                connection();
            }

            if (dbcon.State == ConnectionState.Closed)
            {
                dbcon.Open();
            }
            OleDbCommand Cmd_fetch = null;
            OleDbDataReader Fetch_dr = null;
            Cmd_fetch = new OleDbCommand(str, dbcon);
            Fetch_dr = Cmd_fetch.ExecuteReader();
            Cmd_fetch.Dispose();
            return Fetch_dr;
        }

        public static OleDbDataReader fetch(string str, ref System.Data.OleDb.OleDbTransaction t)
        {
            if (dbcon.State == ConnectionState.Closed)
            {
                dbcon.Open();
            }
            OleDbCommand Cmd_fetch = null;
            OleDbDataReader Fetch_dr = null;
            Cmd_fetch = new OleDbCommand(str, dbcon);
            Cmd_fetch.Transaction = t;
            Fetch_dr = Cmd_fetch.ExecuteReader();
            Cmd_fetch.Dispose();
            return Fetch_dr;
        }
        public static string loginFetchString(string str)
        {
            OleDbCommand Cmd_fetch = null;
            OleDbDataReader Fetch_dr = null;
            string RetStr = null;
            Cmd_fetch = new OleDbCommand(str, lgCon);
            Fetch_dr = Cmd_fetch.ExecuteReader();

            if (Fetch_dr.HasRows)
            {
                Fetch_dr.Read();
                if (Fetch_dr.GetString(0) == null)
                {
                    RetStr = "";
                }
                else
                {
                    RetStr = Fetch_dr.GetString(0);
                }
            }
            else
            {
                RetStr = "";
            }
            Fetch_dr.Close();
            Fetch_dr = null;
            return RetStr;
        }
        public static string FetchString(string str)
        {
            if (dbcon.State == ConnectionState.Closed)
            {
                dbcon.Open();
            }
            OleDbCommand Cmd_fetch = null;
            OleDbDataReader Fetch_dr = null;
            string RetStr = null;
            Cmd_fetch = new OleDbCommand(str, dbcon);
            Fetch_dr = Cmd_fetch.ExecuteReader();

            if (Fetch_dr.HasRows)
            {
                Fetch_dr.Read();
                if (Fetch_dr.GetString(0) == null)
                {
                    RetStr = "";
                }
                else
                {
                    RetStr = Fetch_dr.GetString(0);
                }
            }
            else
            {
                RetStr = "";
            }
            Fetch_dr.Close();
            Fetch_dr = null;
            return RetStr;
        }

        public static int FetchInteger(string str)
        {
            if (dbcon.State == ConnectionState.Closed)
            {
                dbcon.Open();
            }
            OleDbCommand Cmd_fetch = null;
            OleDbDataReader Fetch_dr = null;
            int RetStr = -1;
            Cmd_fetch = new OleDbCommand(str, dbcon);
            Fetch_dr = Cmd_fetch.ExecuteReader();

            if (Fetch_dr.HasRows)
            {
                Fetch_dr.Read();
                if (Fetch_dr.IsDBNull(0))
                {
                    RetStr = -1;
                }
                else
                {
                    RetStr = Fetch_dr.GetInt32(0);
                }
            }
            else
            {
                RetStr = -1;
            }
            Fetch_dr.Close();
            Fetch_dr = null;
            return RetStr;
        }

        public static double FetchDouble(string str)
        {
            if (dbcon.State == ConnectionState.Closed)
            {
                dbcon.Open();
            }
            OleDbCommand Cmd_fetch = null;
            OleDbDataReader Fetch_dr = null;
            double returnValue = 0.0;
            Cmd_fetch = new OleDbCommand(str, dbcon);
           Fetch_dr = Cmd_fetch.ExecuteReader();

            if (Fetch_dr.HasRows)
            {
                Fetch_dr.Read();
                if (Fetch_dr.IsDBNull(0))
                {
                    returnValue = 0;
                }
                else
                {
                    returnValue = Fetch_dr.GetDouble(0);
                }
            }
            else
            {
                returnValue = 0;
            }
            Fetch_dr.Close();
            Fetch_dr = null;
            return returnValue;
        }

        public static string FetchString(string str, ref OleDbTransaction t)
        {
            if (dbcon.State == ConnectionState.Closed)
            {
                dbcon.Open();
            }
            OleDbCommand Cmd_fetch = null;
            OleDbDataReader Fetch_dr = null;
            string RetStr = null;
            Cmd_fetch = new OleDbCommand(str, dbcon);
            Cmd_fetch.Transaction = t;
            Fetch_dr = Cmd_fetch.ExecuteReader();

            if (Fetch_dr.HasRows)
            {
                Fetch_dr.Read();
                if (Fetch_dr.GetString(0) == null)
                {
                    RetStr = "";
                }
                else
                {
                    RetStr = Fetch_dr.GetString(0);
                }
            }
            else
            {
                RetStr = "";
            }
            Fetch_dr.Close();
            Fetch_dr = null;
            return RetStr;
        }

        public static void saveToDB(string str)
        {
            try
            {
                if (dbcon.State == ConnectionState.Closed)
                {
                    dbcon.Open();
                }

                OleDbCommand Cmd_fetch = null;
                Cmd_fetch = new OleDbCommand(str, dbcon);
                Cmd_fetch.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string err = null;
                err = "ERROR::Module1::saveToDB():" + ex.Message;
                MessageBox.Show(err);
            }
        }
        public static void LoginSaveToDB(string str)
        {
            try
            {
                OleDbCommand Cmd_fetch = null;
                //Dim Fetch_dr As OleDbDataReader
                Cmd_fetch = new OleDbCommand(str, lgCon);
                Cmd_fetch.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                string err = null;
                err = "ERROR::Module1::LoginSaveToDB():" + ex.Message;
                MessageBox.Show(err);
                LoggingManager.WriteToLog(0, "Error : LoginSaveToDB() : " + err);
            }
        }
        public static void loginSaveToDB2(string str, System.Data.OleDb.OleDbTransaction t)
        {
            try
            {
                OleDbCommand Cmd_fetch = null;
                //Dim Fetch_dr As OleDbDataReader
                Cmd_fetch = new OleDbCommand(str, lgCon);
                Cmd_fetch.Transaction = t;
                Cmd_fetch.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                string err = null;
                err = "ERROR::Module1::loginSaveToDB2():" + ex.Message;
                MessageBox.Show(err);
                LoggingManager.WriteToLog(0, "Error : LoginSaveToDB() : " + err);
            }
        }
        public static void saveToDB2(string str, System.Data.OleDb.OleDbTransaction t)
        {
            try
            {
                if (dbcon.State == ConnectionState.Closed)
                {
                    dbcon.Open();
                }

                OleDbCommand Cmd_fetch = null;
                Cmd_fetch = new OleDbCommand(str, dbcon);
                Cmd_fetch.Transaction = t;
                Cmd_fetch.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string err = null;
                err = "ERROR::Module1::saveToDB2():" + ex.Message;
                MessageBox.Show(err);
                LoggingManager.WriteToLog(0, "Error : saveToDB2() : " + err);
                throw new Exception("Rollback Transaction");
            }
        }

        public static void saveToDB2(string str, System.Data.OleDb.OleDbTransaction t,OleDbConnection connection)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                OleDbCommand Cmd_fetch = null;
                Cmd_fetch = new OleDbCommand(str, connection);
                Cmd_fetch.Transaction = t;
                Cmd_fetch.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string err = null;
                err = "ERROR::Module1::saveToDB2():" + ex.Message;
                MessageBox.Show(err);
                LoggingManager.WriteToLog(0, "Error : saveToDB2() : " + err);
                throw new Exception("Rollback Transaction");
            }
        }

        public static DataTable fill_ComboData(string str)
        {
            DataTable dtCombo = new DataTable();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataReader drStone = null;

                dtCombo.Columns.Clear();
                dtCombo.Columns.Add("ID", typeof(System.Int32));
                dtCombo.Columns.Add("DESCRIPTION", typeof(System.String));
                drStone = fetch(str);
                while (drStone.Read())
                {
                    if (drStone[1].GetType().ToString().Equals("System.String"))
                    {
                        dtCombo.Rows.Add(drStone.GetInt32(0), drStone.GetString(1));
                    }
                    else if (drStone[1].GetType().ToString().Equals("System.Int32"))
                    {
                        dtCombo.Rows.Add(drStone.GetInt32(0), drStone.GetInt32(1));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                LoggingManager.WriteToLog(0, "Error : fill_ComboData() : " + ex.Message);
            }
            return dtCombo;
        }
        public static void setComboProperty(ref ComboBox cmb, string str, ref DataTable dt)
        {
            dt = fill_ComboData(str);
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmb.DisplayMember = "DESCRIPTION";
            cmb.ValueMember = "ID";
            cmb.DataSource = dt;
        }

        private static string Encrypt(string strText, string strEncrKey)
        {

            byte[] IV = {
			0x12,
			0x34,
			0x56,
			0x78,
			0x90,
			0xab,
			0xcd,
			0xef
		};

            try
            {

                byte[] byKey = System.Text.Encoding.UTF8.GetBytes(strEncrKey.Substring(1, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = System.Text.Encoding.UTF8.GetBytes(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private static string Decrypt(string strText, string sDecrKey)
        {
            byte[] byKey = {
			
		};
            byte[] IV = {
			0x12,
			0x34,
			0x56,
			0x78,
			0x90,
			0xab,
			0xcd,
			0xef
		};
            byte[] inputByteArray = new byte[strText.Length + 1];

            try
            {

                byKey = System.Text.Encoding.UTF8.GetBytes(sDecrKey.Substring(1, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                inputByteArray = Convert.FromBase64String(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);

                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;

                return encoding.GetString(ms.ToArray());

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static bool securityCheck()
        {
            string result = null;
            str = "SELECT KVALUE FROM SETTING WHERE KEY='LINQ'";
            result = FetchString(str);
            return false;
        }

        public static bool search(ref string Field, ref string Condition, ref string destDb)
        {
            OleDbDataReader dr = null;
            dr = fetch("select " + Field + " from " + destDb + " where " + Condition);
            if (dr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void onlyDecimal(object sender, ref System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        public static void onlyInteger(object sender, ref System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        public static void Decimal3digit(ref TextBox txtbox)
        {
            try
            {
                double value = 0;
                if (double.TryParse(txtbox.Text, out value))
                {
                    txtbox.Text = string.Format("{0:0,0.000}", double.Parse(txtbox.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static string Decimal3digit(string txtbox)
        {
            try
            {
                double value = 0;
                if (double.TryParse(txtbox, out value))
                {
                    txtbox = string.Format("{0:0,0.000}", double.Parse(txtbox));
                }
                return txtbox;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        public static void Decimal2digit(ref TextBox txtbox)
        {
            try
            {
                double value = 0;
                if (double.TryParse(txtbox.Text, out value))
                {
                    txtbox.Text = string.Format("{0:0,0.00}", double.Parse(txtbox.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static string Decimal2digit(string txtbox)
        {
            try
            {
                double value = 0;
                if (double.TryParse(txtbox, out value))
                {
                    txtbox = string.Format("{0:0,0.00}", double.Parse(txtbox));
                }
                return txtbox;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        public static int getUniqueNumber(string sqlQry)
        {
            Random r = new Random();
            int num;
            while (true)
            {
                num = r.Next(1000000, 100000000);
                sqlQry = sqlQry + num;
                if (isUnique(sqlQry))
                {
                    break;
                }
            }
            return num;
        }

        public static int get5DigitUniqueNumber(string sqlQry,List<int> runningList)
        {
            Random r = new Random();
            int num;
            while (true)
            {
                num = r.Next(10000, 100000);
                sqlQry = sqlQry + num;
                if (!runningList.Contains(num) && isUnique(sqlQry))
                {
                    runningList.Add(num);
                    break;
                }
            }
            Console.WriteLine(num);
            return num;
        }

        private static bool isUnique(string sqlQry)
        {
            //string sqlQry = "SELECT TID FROM TRANS WHERE TID = " + num;
            string qryResult = dbUtils.FetchString(sqlQry);
            if (qryResult.Length == 0)
                return true;
            else
                return false;
        }

        public enum Effect { Roll, Slide, Center, Blend }

        public static void Animate(Control ctl, Effect effect, int msec, int angle)
        {
            int flags = effmap[(int)effect];
            if (ctl.Visible) { flags |= 0x10000; angle += 180; }
            else
            {
                if (ctl.TopLevelControl == ctl) flags |= 0x20000;
                else if (effect == Effect.Blend) throw new ArgumentException();
            }
            flags |= dirmap[(angle % 360) / 45];
            bool ok = AnimateWindow(ctl.Handle, msec, flags);
            if (!ok) throw new Exception("Animation failed");
            ctl.Visible = !ctl.Visible;
        }

        private static int[] dirmap = { 1, 5, 4, 6, 2, 10, 8, 9 };
        private static int[] effmap = { 0, 0x40000, 0x10, 0x80000 };

        [DllImport("user32.dll")]
        private static extern bool AnimateWindow(IntPtr handle, int msec, int flags);

        public string Double2String(double doubleValue)
        {
            return doubleValue.ToString();
        }

        public string Int162String(Int16 intValue)
        {
            return intValue.ToString();
        }

        public string Int322String(Int32 intValue)
        {
            return intValue.ToString();
        }

        public static string NumbersToWords(int inputNumber)
        {
            int inputNo = inputNumber;

            if (inputNo == 0)
                return "Zero";

            int[] numbers = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("Rupees ");
            if (inputNo < 0)
            {
                sb.Append("Minus ");
                inputNo = -inputNo;
            }

            string[] words0 = {"" ,"One ", "Two ", "Three ", "Four ",
            "Five " ,"Six ", "Seven ", "Eight ", "Nine "};
            string[] words1 = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ",
            "Fifteen ","Sixteen ","Seventeen ","Eighteen ", "Nineteen "};
            string[] words2 = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ",
            "Seventy ","Eighty ", "Ninety "};
            string[] words3 = { "Thousand ", "Lakh ", "Crore " };

            numbers[0] = inputNo % 1000; // units
            numbers[1] = inputNo / 1000;
            numbers[2] = inputNo / 100000;
            numbers[1] = numbers[1] - 100 * numbers[2]; // thousands
            numbers[3] = inputNo / 10000000; // crores
            numbers[2] = numbers[2] - 100 * numbers[3]; // lakhs

            for (int i = 3; i > 0; i--)
            {
                if (numbers[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (numbers[i] == 0) continue;
                u = numbers[i] % 10; // ones
                t = numbers[i] / 10;
                h = numbers[i] / 100; // hundreds
                t = t - 10 * h; // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                   // if (h > 0 || i == 0) sb.Append("and ");
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            sb.Append("Only");
            return sb.ToString().TrimEnd();
        }
    }
}
