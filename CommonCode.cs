using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CycleSample
{
    public class CommonCode
    {
    }

    public class PasswordEncryption
    {
        public enum HashType { MD5, SHA256, SHA384, SHA512 }

        public static string Base64Encode(string data)
        {
            try
            {
                byte[] encData_byte = new byte[data.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(data);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception e)
            {
                throw new Exception("Error in Base64Encode: " + e.Message);
            }
        }

        public string EncryptionSHA256(string message)
        {
            //입력받은 문자열을 바이트배열로 변환
            byte[] array = Encoding.Default.GetBytes(message);
            byte[] hashValue;
            string result = string.Empty;

            //바이트배열을 암호화된 32byte 해쉬값으로 생성
            using (SHA256 mySHA256 = SHA256.Create())
            {
                hashValue = mySHA256.ComputeHash(array);
            }
            //32byte 해쉬값을 16진수로변환하여 64자리로 만듬
            for (int i = 0; i < hashValue.Length; i++)
            {
                result += hashValue[i].ToString("x2");
            }

            return result;
        }

        /// <summary>
        /// MD5 암호화
        /// </summary>
        /// <param name="text">암호화 할 평문</param>
        /// <param name="encoding">System.Text.Encoding</param>
        /// <returns>지정된 인코딩으로 암호화한 문자열</returns>
        public string EncryptMD5(string text, Encoding encoding)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            byte[] data = md5.ComputeHash(encoding.GetBytes(text));

            var sb = new StringBuilder();
            foreach (byte b in data)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// SHA256 암호화
        /// </summary>
        /// <param name="text">암호화 할 평문</param>
        /// <param name="encoding">System.Text.Encoding</param>
        /// <returns>지정된 인코딩으로 암호화한 문자열</returns>
        public string EncryptSHA256(string text, Encoding encoding)
        {
            var sha = new System.Security.Cryptography.SHA256Managed();
            byte[] data = sha.ComputeHash(encoding.GetBytes(text));

            var sb = new StringBuilder();
            foreach (byte b in data)
            {
                sb.Append(b.ToString("x2"));
            }

            return Convert.ToBase64String(encoding.GetBytes(sb.ToString()));
        }

        /// <summary>
        /// 경동 나비엔 SHA256 암호화
        /// </summary>
        /// <param name="password">암호화 할 평문</param>
        /// <returns>지정된 인코딩으로 암호화한 문자열</returns>
        public string EncryptSHA2562(string password)
        {
            string strReturnValue = "";
            try
            {
                byte[] arrRawdata = Encoding.Default.GetBytes(password);
                var sha256 = new SHA256Managed();
                byte[] convHash = sha256.ComputeHash(arrRawdata);
                strReturnValue = Convert.ToBase64String(convHash);

                return strReturnValue;
            }
            catch (Exception ex)
            {
                //LogUtil.Log(LogUtil._ERROR_LEVEL, "CommonClass", ex.Message);
                return strReturnValue;
            }
        }

        /// <summary>
        /// SHA384 암호화
        /// </summary>
        /// <param name="text">암호화 할 평문</param>
        /// <param name="encoding">System.Text.Encoding</param>
        /// <returns>지정된 인코딩으로 암호화한 문자열</returns>
        public string EncryptSHA384(string text, Encoding encoding)
        {
            var sha = new System.Security.Cryptography.SHA384Managed();
            byte[] data = sha.ComputeHash(encoding.GetBytes(text));

            var sb = new StringBuilder();
            foreach (byte b in data)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// SHA512 암호화
        /// </summary>
        /// <param name="text">암호화 할 평문</param>
        /// <param name="encoding">System.Text.Encoding</param>
        /// <returns>지정된 인코딩으로 암호화한 문자열</returns>
        public string EncryptSHA512(string text, Encoding encoding)
        {
            var sha = new System.Security.Cryptography.SHA512Managed();
            byte[] data = sha.ComputeHash(encoding.GetBytes(text));

            var sb = new StringBuilder();
            foreach (byte b in data)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 평문화 Hash 암호화 문자열 비교
        /// </summary>
        /// <param name="text">평문</param>
        /// <param name="oldHash">Hash 암호화 문자열</param>
        /// <param name="type">MD5, SHA256, SHA384, SHA512</param>
        /// <param name="encoding">System.Text.Encoding</param>
        /// <returns>평문을 지정된 인코딩으로 암호화한 후 비교 결과 True/False</returns>
        public bool IsSameHash(string text, string oldHash, HashType type, Encoding encoding)
        {
            string newHash = null;
            switch (type)
            {
                case HashType.MD5:
                    newHash = EncryptMD5(text, encoding);
                    break;
                case HashType.SHA256:
                    newHash = EncryptSHA256(text, encoding);
                    break;
                case HashType.SHA384:
                    newHash = EncryptSHA384(text, encoding);
                    break;
                case HashType.SHA512:
                    newHash = EncryptSHA512(text, encoding);
                    break;
                default:
                    return false;
            }
            var comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(newHash, oldHash) == 0;
        }

    }

    public static class OracleTypeHelper
    {
        public static Guid ToOracleGuid(this string raw16String)
        {
            return new Guid(StringToBytes(raw16String));
        }

        private static byte[] StringToBytes(string hex)
        {
            if (hex.Length % 2 == 1)
            {
                throw new Exception("The hex string cannot have an odd number of digits");
            }

            byte[] arr = new byte[hex.Length >> 1];
            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexValue(hex[i << 1]) << 4) + (GetHexValue(hex[(i << 1) + 1])));
            }

            return arr;
        }

        private static int GetHexValue(char hex)
        {
            int val = hex;
            return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }

        public static string ToOracleString(this Guid self)
        {
            var bytes = self.ToByteArray();
            int len = bytes.Length * 2;
            char[] chars = new char[len];
            int bi = 0;
            int ci = 0;
            while (ci < len)
            {
                byte b = bytes[bi++];
                chars[ci] = GetHexValue(b / 16);
                chars[ci + 1] = GetHexValue(b % 16);
                ci += 2;
            }

            return new string(chars, 0, chars.Length);
        }

        private static char GetHexValue(int i)
        {
            return i < 10 ? (char)(i + 48) : (char)(i - 10 + 65);
        }
    }



    public static class Util
    {

        //화면 Thread 처리
        public static void InvokeIfNeeded(this Control control, Action action)
        {
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }

        public static void InvokeIfNeeded<T>(this Control control, Action<T> action, T arg)
        {
            if (control.InvokeRequired)
                control.Invoke(action, arg);
            else
                action(arg);
        }

        public static void DoubleBuffered(this Control control, bool enabled)
        {
            var prop = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            prop.SetValue(control, enabled, null);
        }


        public static string PasswordValidationCheck(string strPassword)
        {
            string strReturnValue = string.Empty;
            string strPattern;

            Regex regex = null;

            try
            {
                // 특수문자가 있는지 검사
                strPattern = @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]";
                regex = new Regex(strPattern);
                bool blnIncludeSpecialChar = regex.IsMatch(strPassword);

                // 숫자가 있는지 검사
                strPattern = @"[0-9]+";
                regex = new Regex(strPattern);
                bool blnIncludeNumber = regex.IsMatch(strPassword);
                
                // 알파벳 - 대문자구분
                strPattern = @"[A-Z]+";
                regex = new Regex(strPattern);
                bool blnIncludeAlphbetUpper = regex.IsMatch(strPassword);

                // 알파벳 - 소문자구분
                strPattern = @"[a-z]+";
                regex = new Regex(strPattern);
                bool blnIncludeAlphbetLower = regex.IsMatch(strPassword);

                // 알파벳 
                strPattern = @"[a-zA-Z]";
                regex = new Regex(strPattern);
                bool blnIncludeAlphbet = regex.IsMatch(strPassword);

                regex = null;

                bool blnIncludeSameChar = false;            //동일문자 카운트
                bool blnIncludeContinuosChar = false;       //연속문자 검사(123, abc...)

                byte[] ascii = Encoding.ASCII.GetBytes(strPassword); 

                for (int i = 0; i < ascii.Length - 3; i++)
                {
                    int intAscii0 = ascii[i + 0];
                    int intAscii1 = ascii[i + 1];
                    int intAscii2 = ascii[i + 2];
                    int intAscii3 = ascii[i + 3];

                    // 동일 문자 = ascii 값이 동일
                    if (intAscii0 == intAscii1 && intAscii1 == intAscii2 && intAscii2 == intAscii3)
                    {
                        blnIncludeSameChar = true;
                    }

                    // 연속문자 == 연속이므로 ascii 값의 차이가 1이 난다.
                    // 연속된 문자열(123,321,abc,cba 등)을 사용할 수 없습니다
                    if (System.Math.Abs(intAscii0 - intAscii1) == 1 && System.Math.Abs(intAscii1 - intAscii2) == 1)
                    {
                        blnIncludeContinuosChar = true;
                    }
                }

                // 6자리 이상 
                if (strPassword.Length < 6)
                {
                    strReturnValue = "비밀번호는 6자리 이상을 사용하셔야 됩니다.";
                }
                else
                {
                    // 영문 + 숫자 + 특수문자
                    if (blnIncludeAlphbet && blnIncludeNumber && blnIncludeSpecialChar)
                    {
                        if (blnIncludeSameChar)
                        {
                            strReturnValue = "동일문자(111,222,aaa 등)를 4번 이상 사용할 수 없습니다";
                        }
                    }
                    else
                    {
                        strReturnValue = "영문 + 숫자 + 특수문자가 조합되어야 합니다.";
                    }
                }
            }
            catch (Exception ex)
            {
                //LogUtil.Log(LogUtil._ERROR_LEVEL, "CommonCode", ex.Message);
                return strReturnValue;
            }
            finally
            {
                regex = null;
            }

            return strReturnValue;
        }

        public static Dictionary<string, string> SortDictionary(Dictionary<string, string> dict)
        {
            // 내림차순인 경우 OrderByDescending() 함수로 변경
            return dict.OrderBy(item => item.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        /// <summary>
        /// Date Format Conversion (14 to date)
        /// </summary>
        /// <param name="date"></param>
        /// <returns>DateTime</returns>
        public static DateTime DateFormat14ToDate(string date)
        {
            DateTime dateTimeReturnValue;

            if (date.Length == 14)
            {
                dateTimeReturnValue = DateTime.Parse(String.Format("{0}-{1}-{2} {3}:{4}:{5}", date.Substring(0, 4), date.Substring(4, 2), date.Substring(6, 2), date.Substring(8, 2), date.Substring(10, 2), date.Substring(12, 2)));
            }
            else if (date.Length > 14)
            {
                date = date.Substring(0, 14);
                dateTimeReturnValue = DateTime.Parse(String.Format("{0}-{1}-{2} {3}:{4}:{5}", date.Substring(0, 4), date.Substring(4, 2), date.Substring(6, 2), date.Substring(8, 2), date.Substring(10, 2), date.Substring(12, 2)));
            }
            else
            {
                dateTimeReturnValue = DateTime.Parse(date);
            }

            return dateTimeReturnValue;
        }

        public static string DateFormat14ToDate(string date, string format)
        {
            string dateTimeReturnValue;

            if (date.Length == 14)
            {
                dateTimeReturnValue = DateTime.Parse(String.Format("{0}-{1}-{2} {3}:{4}:{5}", date.Substring(0, 4), date.Substring(4, 2), date.Substring(6, 2), date.Substring(8, 2), date.Substring(10, 2), date.Substring(12, 2))).ToString(format);
            }
            else
            {
                dateTimeReturnValue = date;
            }

            return dateTimeReturnValue;
        }

        /// <summary>
        /// value null check
        /// </summary>
        /// <param name="val">value</param>
        /// <param name="nullString">null일시 변환값</param>
        /// <returns></returns>
        public static string GetNull(string val, string nullString)
        {
            string strReturnValue = string.Empty;

            if (string.IsNullOrEmpty(val))
            {
                strReturnValue = nullString;
            }
            else if (val.Trim().Equals("null"))
            {
                strReturnValue = nullString;
            }
            else
            {
                strReturnValue = val;
            }
            return strReturnValue;
        }

        /// <summary>
        /// value null check
        /// </summary>
        /// <param name="val">value</param>
        /// <param name="nullString">null일시 변환값</param>
        /// <returns></returns>
        public static string GetCustomValue(string val, string customString)
        {
            string strReturnValue = string.Empty;

            if (string.IsNullOrEmpty(val))
            {
                strReturnValue = customString;
            }
            else if (val.Trim().Equals("null"))
            {
                strReturnValue = customString;
            }
            else if (val.Trim().Equals(""))
            {
                strReturnValue = customString;
            }
            else
            {
                strReturnValue = val;
            }
            return strReturnValue;
        }

        public static DateTime GetDateTimeByMilliseconds(long date)
        {
            DateTime resultTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds((double)date) + TimeSpan.FromHours(9);
            return resultTime;
        }

        public static long GetMillisecondsByDateTime(DateTime date)
        {
            long resultTime = (long)date.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            return resultTime;
        }


        public static string OracleToDotNet(string text)
        {
            byte[] bytes = ParseHex(text);
            Guid guid = new Guid(bytes);
            return guid.ToString("N").ToUpperInvariant();
        }

        public static string DotNetToOracle(string text)
        {
            Guid guid = new Guid(text);
            return BitConverter.ToString(guid.ToByteArray()).Replace("-", "");
        }

        public static byte[] ParseHex(string text)
        {
            // Not the most efficient code in the world, but
            // it works...
            byte[] ret = new byte[text.Length / 2];
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = Convert.ToByte(text.Substring(i * 2, 2), 16);
            }
            return ret;
        }


        public static string ByteToHex(byte[] bytes)
        {
            string hex = BitConverter.ToString(bytes);
            return hex.Replace("-", "");
        }
        public static byte[] HexToByte(string convertString)
        {
            byte[] convertArr = new byte[convertString.Length / 2];

            for (int i = 0; i < convertArr.Length; i++)
            {
                convertArr[i] = Convert.ToByte(convertString.Substring(i * 2, 2), 16);
            }
            return convertArr;
        }

        public static string HexStringFromByteArray(byte[] bytes)
        {
            string s = "";

            foreach (byte b in bytes)
            {
                s += string.Format("{0:X2}", b);
            }

            return s;
        }

        public static byte[] ObjectToByte(object obj)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(stream, obj);
                    return stream.ToArray();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }
            return null;
        }

        public static string ConvertByteToHexString(byte[] convertArr)
        {
            string convertArrString = string.Empty;
            convertArrString = string.Concat(Array.ConvertAll(convertArr, byt => byt.ToString("X2")));
            return convertArrString;
        }

        public static double GetPercentage(double value, double total, int decimalplaces)
        {
            return System.Math.Round(value * 100 / total, decimalplaces);
        }

        #region Export Excel

        public static void CopyAlltoClipboard(ref DataGridView rawdata)
        {
            rawdata.SelectAll();
            DataObject dataObj = rawdata.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        public static void GridToExcel(ref DataGridView rawdata)
        {
            CopyAlltoClipboard(ref rawdata);

            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }


        public static void ConfirmExcel(ref DataGridView rawdata)
        { 
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save as Excel File";
            sfd.Filter = "Excel Files(2003)|*.xls|Excel Files(2007)|*.xlsx";
            sfd.FileName = "";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                dataGridViewExportToExcel(sfd.FileName, rawdata);
            }
        }

        public static void ConfirmExcel(ref DataGridView rawdata, string rawname)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save as Excel File";
            sfd.Filter = "Excel Files(2003)|*.xls|Excel Files(2007)|*.xlsx";
            
            sfd.FileName = rawname + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                dataGridViewExportToExcel(sfd.FileName, rawdata);
            }
        }

        // using System.Data;
        // using Excel = Microsoft.Office.Interop.Excel;
        public static void dataGridViewExportToExcel(string fileName, DataGridView dgv)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            if (excelApp == null)
            {
                MessageBox.Show("엑셀이 설치되지 않았습니다");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbook wb = excelApp.Workbooks.Add(true);
            Microsoft.Office.Interop.Excel._Worksheet workSheet = wb.Worksheets.get_Item(1) as Microsoft.Office.Interop.Excel._Worksheet;
            workSheet.Name = "C#";

            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("출력할 데이터가 없습니다");
                return;
            }

            /*Range cell1 = workSheet.Cells[1, 1];
            cell1.RowHeight = 40;
            workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, dgv.Columns.Count]].Merge();


            // 헤더 출력
            for (int i = 0; i < dgv.Columns.Count - 1; i++)
            {
                workSheet.Cells[2, i + 1] = dgv.Columns[i].HeaderText;
            }

            //내용 출력
            for (int r = 0; r < dgv.Rows.Count; r++)
            {
                for (int i = 0; i < dgv.Columns.Count - 1; i++)
                {
                    workSheet.Cells[r + 3, i + 1] = dgv.Rows[r].Cells[i].Value;
                }
            }*/

            // 헤더 출력
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                workSheet.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
            }

            //내용 출력
            for (int r = 0; r < dgv.Rows.Count; r++)
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    workSheet.Cells[r + 2, i + 1] = dgv.Rows[r].Cells[i].Value;
                }
            }

            workSheet.Columns.AutoFit(); // 글자 크기에 맞게 셀 크기를 자동으로 조절

            // 엑셀 2003 으로만 저장이 됨
            wb.SaveAs(fileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            wb.Close(Type.Missing, Type.Missing, Type.Missing);
            excelApp.Quit();
            releaseObject(excelApp);
            releaseObject(workSheet);
            releaseObject(wb);
        }

        public static SaveFileDialog GetCsvSave(string fileName)
        {
            //Getting the location and file name of the excel to save from user.
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.CheckPathExists = true;
            saveDialog.AddExtension = true;
            saveDialog.ValidateNames = true;

            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string filepath = Path.GetDirectoryName(path);


            saveDialog.InitialDirectory = filepath;// Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            saveDialog.DefaultExt = ".csv";
            saveDialog.Filter = "csv (*.csv) | *.csv";
            saveDialog.FileName = fileName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

            return saveDialog;
        }

        public static void CSVSave(string fileName, DataGridView dgview, bool header)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8))
                {
                    // 1️⃣ 헤더 저장 여부 확인
                    if (header)
                    {
                        List<string> headerValues = new List<string>();
                        foreach (DataGridViewColumn col in dgview.Columns)
                        {
                            if (col.Visible) // 숨겨진 컬럼 제외
                                headerValues.Add(col.HeaderText);
                        }
                        sw.WriteLine(string.Join(",", headerValues));
                    }

                    // 2️⃣ 선택된 행만 저장
                    foreach (DataGridViewRow row in dgview.SelectedRows)
                    {
                        if (!row.IsNewRow) // 새 행이 아니면 저장
                        {
                            List<string> rowValues = new List<string>();
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (cell.OwningColumn.Visible) // 숨겨진 컬럼 제외
                                {
                                    string cellValue = cell.Value?.ToString() ?? ""; // Null 방지
                                    cellValue = "\"" + cellValue.Replace("\"", "\"\"") + "\""; // CSV 포맷 유지
                                    rowValues.Add(cellValue);
                                }
                            }
                            sw.WriteLine(string.Join(",", rowValues));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CSV 저장 중 오류 발생: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static void Save_csv(string fileName, DataGridView dgview, bool header)
        {
            string delimiter = ",";  // 구분자
            FileStream fs = new FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter csvExport = new StreamWriter(fs, System.Text.Encoding.UTF8); //UTF8로 엔코딩
            if (dgview.Rows.Count == 0) return;
            
            // header가 true면 헤더정보 출력
            if (header)
            {
                for (int i = 1; i < dgview.Columns.Count; i++)
                {
                    csvExport.Write(dgview.Columns[i].HeaderText);
                    if (i != dgview.Columns.Count - 1)
                    {
                        csvExport.Write(delimiter);
                    }
                }
            }

            csvExport.Write(csvExport.NewLine); // add new line
            
            // 데이터 출력
            foreach (DataGridViewRow row in dgview.Rows)
            {
                if (!row.IsNewRow)
                {
                    for (int i = 1; i < dgview.Columns.Count; i++)
                    {
                        csvExport.Write(row.Cells[i].Value);
                        if (i != dgview.Columns.Count - 1)
                        {
                            csvExport.Write(delimiter);
                        }
                    }
                    csvExport.Write(csvExport.NewLine); // write new line
                }
            }

            csvExport.Flush();
            csvExport.Close();
            fs.Close();
        }

        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception e)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        #endregion

        // Json to Datatable
        // DataTable dt = JsonConvert.DeserializeObject<DataTable>(strJson);

        public static void SetDoubleBuffering(System.Windows.Forms.Control control, bool value)
        {
            System.Reflection.PropertyInfo controlProperty = typeof(System.Windows.Forms.Control)
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            controlProperty.SetValue(control, value, null);
        }

        public static Control[] GetAllControlsUsingRecursive(Control containerControl)
        {
            List<Control> allControls = new List<Control>();

            foreach (Control control in containerControl.Controls)
            {
                allControls.Add(control);

                if (control.Controls.Count > 0)
                {
                    allControls.AddRange(GetAllControlsUsingRecursive(control));
                }
            }
            return allControls.ToArray();
        }

        public static bool GetPingCheck(string ip)
        {
            bool bValue = false;

            try
            {
                Ping pingSender = new Ping();
                PingOptions pingOptions = new PingOptions()
                {
                    DontFragment = true
                };

                byte[] bytBuffer = Encoding.ASCII.GetBytes("getpingcheck");
                PingReply piReply = pingSender.Send(ip, 2000, bytBuffer, pingOptions);

                if (piReply.Status == IPStatus.Success)
                {
                    bValue = true;
                }
                else
                {
                    bValue = false;
                }
            }
            catch (Exception ex)
            {
                bValue = false;
            }
            return bValue;
        }

        #region App.config Control

        public static string GetAppConfig(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static void SetAppConfig(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection cfgCollection = config.AppSettings.Settings;

            cfgCollection.Remove(key);
            cfgCollection.Add(key, value);

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }

        public static void AddAppConfig(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection cfgCollection = config.AppSettings.Settings;

            cfgCollection.Add(key, value);

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }

        public static void RemoveAppConfig(string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection cfgCollection = config.AppSettings.Settings;

            try
            {
                cfgCollection.Remove(key);

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            }
            catch { }
        }

        #endregion


        #region To days
        public static double ConvertMillisecondsToDays(double milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds).TotalDays;
        }

        public static double ConvertSecondsToDays(double seconds)
        {
            return TimeSpan.FromSeconds(seconds).TotalDays;
        }

        public static double ConvertMinutesToDays(double minutes)
        {
            return TimeSpan.FromMinutes(minutes).TotalDays;
        }

        public static double ConvertHoursToDays(double hours)
        {
            return TimeSpan.FromHours(hours).TotalDays;
        }
        #endregion

        #region To hours
        public static double ConvertMillisecondsToHours(double milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds).TotalHours;
        }

        public static double ConvertSecondsToHours(double seconds)
        {
            return TimeSpan.FromSeconds(seconds).TotalHours;
        }

        public static double ConvertMinutesToHours(double minutes)
        {
            return TimeSpan.FromMinutes(minutes).TotalHours;
        }

        public static double ConvertDaysToHours(double days)
        {
            return TimeSpan.FromHours(days).TotalHours;
        }
        #endregion

        #region To minutes
        public static double ConvertMillisecondsToMinutes(double milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds).TotalMinutes;
        }

        public static double ConvertSecondsToMinutes(double seconds)
        {
            return TimeSpan.FromSeconds(seconds).TotalMinutes;
        }

        public static double ConvertHoursToMinutes(double hours)
        {
            return TimeSpan.FromHours(hours).TotalMinutes;
        }

        public static double ConvertDaysToMinutes(double days)
        {
            return TimeSpan.FromDays(days).TotalMinutes;
        }
        #endregion

        #region To seconds
        public static double ConvertMillisecondsToSeconds(double milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds).TotalSeconds;
        }

        public static double ConvertMinutesToSeconds(double minutes)
        {
            return TimeSpan.FromMinutes(minutes).TotalSeconds;
        }

        public static double ConvertHoursToSeconds(double hours)
        {
            return TimeSpan.FromHours(hours).TotalSeconds;
        }

        public static double ConvertDaysToSeconds(double days)
        {
            return TimeSpan.FromDays(days).TotalSeconds;
        }
        #endregion

        #region To milliseconds
        public static double ConvertSecondsToMilliseconds(double seconds)
        {
            return TimeSpan.FromSeconds(seconds).TotalMilliseconds;
        }

        public static double ConvertMinutesToMilliseconds(double minutes)
        {
            return TimeSpan.FromMinutes(minutes).TotalMilliseconds;
        }

        public static double ConvertHoursToMilliseconds(double hours)
        {
            return TimeSpan.FromHours(hours).TotalMilliseconds;
        }

        public static double ConvertDaysToMilliseconds(double days)
        {
            return TimeSpan.FromDays(days).TotalMilliseconds;
        }

        public static string ConvertUseYNKor(string UserYN)
        {
            string strReturnValue = string.Empty;

            if (UserYN.ToUpper().Equals("Y"))
            {
                strReturnValue = "허가";
            }
            else if (UserYN.ToUpper().Equals("N"))
            {
                strReturnValue = "금지";
            }
            return strReturnValue;
        }

        public static bool ConvertUseYNBool(string UserYN)
        {
            bool bReturnValue = false;

            if (UserYN.ToUpper().Equals("Y") || UserYN.ToUpper().IndexOf("Y") > 0 || UserYN.ToUpper().IndexOf("가능") >= 0)
            {
                bReturnValue = true;
            }
            else if (UserYN.ToUpper().Equals("N") || UserYN.ToUpper().IndexOf("N") > 0 || UserYN.ToUpper().IndexOf("불가") >= 0)
            {
                bReturnValue = false;
            }
            return bReturnValue;
        }

        public static string ConvertUseYDesc(string UserYN)
        {
            string strReturnValue = string.Empty;

            if (UserYN.Equals("True"))
            {
                strReturnValue = "가능";
            }
            else
            {
                strReturnValue = "불가";
            }
            return strReturnValue;
        }
        #endregion
    }
}
