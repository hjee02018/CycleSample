using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CycleSample.DB;
using System.Configuration;
//using DocumentFormat.OpenXml.Office2010.CustomUI;
//using DocumentFormat.OpenXml.Drawing.Charts;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace CycleSample
{
    public partial class Form1 : Form
    {

        private DBOracleSql sqlQuery = new DBOracleSql();
        // 🔹 ContextMenuStrip을 생성
        private ContextMenuStrip contextMenu = new ContextMenuStrip();
        // 🔹 CycleDatatable 별도 생성
        System.Data.DataTable dtFiltered = new DataTable(); 

        public Form1()
        {
            InitializeComponent();

            // 🔹 컨텍스트 메뉴 아이템 추가
            contextMenu.Items.Add("수정", null, OnEditClicked);
            contextMenu.Items.Add("삭제", null, OnDeleteClicked);
            contextMenu.Items.Add("확인", null, OnCheckClicked);

            // 🔹 DataGridView 우클릭 이벤트 핸들러 등록
            dtViewEquipLog.MouseDown += dtViewEquipLog_MouseDown;

            InitializeOracle();

            // cmbSite 아이템 초기화
            cmbSite.Items.Add("SITE");
            cmbSite.Items.Add("KY1");
            cmbSite.Items.Add("TN1");
            cmbSite.SelectedIndex = 0;
            
            // cmbSYSID 아이템 초기화
            UpdateSYSIDItems(cmbSite.SelectedItem.ToString());

            // cmbPLCNO 아이템 초기화
            UpdatePLCNOItems(cmbSYSID.SelectedItem.ToString());

            //
            cmbStatus.Items.Add("All");
            cmbStatus.Items.Add("Conveyor");
            cmbStatus.Items.Add("Transfer");
            cmbStatus.Items.Add("Lift");
            cmbStatus.SelectedIndex= 0;
            cmbStatus.SelectedIndex= 0;

            //
            cmbStatt.Items.Add("All");
            cmbStatt.Items.Add("CarrierDetect-1");
            cmbStatt.Items.Add("CarrierDetect-0");
            cmbStatt.Items.Add("ShuttleActive");
            cmbStatt.Items.Add("ShuttleIdle");
            cmbStatt.SelectedIndex= 0;

            //
            cmbRunType.Items.Add("FOIL/ROLL Transfer ");
            cmbRunType.Items.Add("FOIL Conveyor");
            cmbRunType.Items.Add("VD Lifter");
            cmbRunType.Items.Add("POWDER (RTV)");
            cmbRunType.SelectedIndex = 0;

            //
            cmbAction.Items.Add("ALL");
            cmbAction.Items.Add("IN");
            cmbAction.Items.Add("OUT");
            cmbAction.SelectedIndex = 0;


            //
            cmbInOutType.Items.Add("IN");
            cmbInOutType.Items.Add("OUT");

            // DB 접속 정보 기본 세팅
            txtDBIP.Text = ConfigurationManager.AppSettings["OracleMainIP"];
            txtDBPORT.Text = ConfigurationManager.AppSettings["OraclePort"];
            txtDBSID.Text = ConfigurationManager.AppSettings["OracleSID"];
            txtUSERID.Text = ConfigurationManager.AppSettings["OracleConnectionID"];
            txtUSERPW.Text = ConfigurationManager.AppSettings["OracleConnectionPassword"];

            // 
            dtFromDate.Value = DateTime.Now.AddDays(-2);
            dtToDate.Value = DateTime.Now;
        }
       
        /// <summary>
        /// 그리드 & 뷰 초기화
        /// </summary>
        private void InitializeData()
        {
     
        }

        /// <summary>
        /// 검색 조건 파라미터 생성
        /// </summary>
        /// <returns></returns>
        private ConcurrentDictionary<string, string> GetSearchParameters()
        {
            var dicParams = new ConcurrentDictionary<string, string>();

            // 기본 조회 조건
            dicParams["SITE"] = cmbSite.Text.ToString().Trim();
            dicParams["SYS_ID"] = cmbSYSID.Text.ToString().Trim();

            // 날짜 (8자리)와 시간 (6자리)을 별도로 가져오기
            dicParams["FROM_DATE"]  = dtFromDate.Value.ToString("yyyyMMdd");
            dicParams["TO_DATE"]    = dtToDate.Value.ToString("yyyyMMdd");
            dicParams["FROM_TIME"]  = dtFromTime.Value.ToString("HHmmss");
            dicParams["TO_TIME"]    = dtToTime.Value.ToString("HHmmss");

            // PLC NO
            dicParams["TRACK_ID"]   = cmbPLCNO.Text.ToString().Trim();

            // RMK
            if(cmbStatus.SelectedIndex!=0)
                dicParams["RMK"] = cmbStatus.Text.ToString().Trim();

            // STATUS
            if(cmbStatt.SelectedIndex!=0)
                dicParams["STATUS"] = cmbStatt.Text.ToString().Trim();

            // ACTION 
            if (cmbAction.SelectedIndex != 0)
                dicParams["ACTION"] = cmbAction.Text.ToString().Trim();

            if(cmbRunType.SelectedIndex==1)
                dicParams["INOUT"] = cmbInOutType.Text.ToString().Trim();

            return dicParams;
        }

        /// <summary>
        /// CMBPLCNO 갱신
        /// </summary>
        /// <param name="site"></param>
        private void UpdatePLCNOItems(string site)
        {
            InitializeOracle();

            cmbPLCNO.Items.Clear(); // 기존 아이템을 지우기

            if (!GlobalClass.dbOracle.ConnectionStatus)
            {
                MessageBox.Show("DB 접속 상태를 확인하세요", "실패", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                ConcurrentDictionary<string, string> dicParams = new ConcurrentDictionary<string, string>();

                dicParams.Clear();
                if (cmbSite.SelectedIndex != 0)
                {
                    dicParams["SYS_ID"] = cmbSYSID.Text.ToString().Trim();
                    string sql = sqlQuery.SELECT_PLCNO_LIST(dicParams);
                    System.Data.DataTable dt = GlobalClass.dbOracle.SelectSQL(sql);
                    string[] sysIdArray = dt.AsEnumerable().Select(row => row["PLC_NO"].ToString()).ToArray();
                    cmbPLCNO.Items.AddRange(sysIdArray);
                }
                else
                {
                    cmbPLCNO.Items.Add("SYS_ID 를 선택하세요");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            cmbPLCNO.SelectedIndex = 0; // 기본 선택값 설정
        }

        /// <summary>
        /// CMBSYSID 갱신
        /// </summary>
        /// <param name="site"></param>
        private void UpdateSYSIDItems(string site)
        {
            InitializeOracle();

            cmbSYSID.Items.Clear(); // 기존 아이템을 지우기

            if (!GlobalClass.dbOracle.ConnectionStatus)
            {
                MessageBox.Show("DB 접속 상태를 확인하세요", "실패", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                ConcurrentDictionary<string, string> dicParams = new ConcurrentDictionary<string, string>();

                dicParams.Clear();
                if (cmbSite.SelectedIndex != 0)
                {
                    dicParams["SITE"] = cmbSite.Text.ToString().Trim();
                    string sql = sqlQuery.SELECT_SYSID_LIST(dicParams);
                    System.Data.DataTable dt = GlobalClass.dbOracle.SelectSQL(sql);
                    string[] sysIdArray = dt.AsEnumerable().Select(row => row["SYS_ID"].ToString()).ToArray();
                    cmbSYSID.Items.AddRange(sysIdArray);
                }
                else
                {
                    cmbSYSID.Items.Add("SITE를 선택하세요");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            cmbSYSID.SelectedIndex = 0; // 기본 선택값 설정
        }

        /// <summary>
        /// EQUIP LOG 조회 함수
        /// </summary>
        private void SearchViewEquipLog()
        {
            // 데이터 초기화
            InitializeData();

            dtViewEquipLog.DataSource = null; // 기존 바인딩 해제
            dtViewEquipLog.Rows.Clear();      // 모든 행 제거

            // 검색 조건 파라미터 조회

            if (cmbRunType.SelectedIndex == 1 && cmbInOutType.SelectedIndex == -1)
            {
                MessageBox.Show("IN/OUT 유형 지정값을 선택하시오.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var dicParams = GetSearchParameters();
            string sql = sqlQuery.SELECT_T_EQUIP_LOG(dicParams);
            
            System.Data.DataTable DT = GlobalClass.dbOracle.SelectSQL(sql);

            if (DT.Rows.Count > 0)
            {
                for (int nGridLoop = 0; nGridLoop < DT.Rows.Count; nGridLoop++)
                {
                    object idColumn = DT.Rows[nGridLoop]["ID_T_EQUIP_LOG"];
                    string idToUpdate = "";
                    if (idColumn is byte[] byteArray) // RAW(32) 타입 -> 16진수 문자열 변환
                        idToUpdate = BitConverter.ToString(byteArray).Replace("-", "");

                    dtViewEquipLog.Rows.Add(
                        idToUpdate,
                        //DT.Rows[nGridLoop]["ID_T_EQUIP_LOG"].ToString().Trim(),
                        DT.Rows[nGridLoop]["SITE"].ToString().Trim(),
                        DT.Rows[nGridLoop]["SYS_ID"].ToString().Trim(),
                        DT.Rows[nGridLoop]["TRACK_ID"].ToString().Trim(),
                        DT.Rows[nGridLoop]["STATUS"].ToString().Trim(),
                        DT.Rows[nGridLoop]["RMK"].ToString().Trim(),
                        DT.Rows[nGridLoop]["CYCLE_COUNT"].ToString().Trim(),
                        DT.Rows[nGridLoop]["ACTION"].ToString().Trim(),
                        DT.Rows[nGridLoop]["CYCLE_TIME"].ToString().Trim(),
                        DT.Rows[nGridLoop]["REG_DTM"].ToString().Trim()
                    );
                }
                lbTotal.Text = "/ "+DT.Rows.Count.ToString().Trim()+" 건";
            }
            else
            {
                dtViewEquipLog.Rows.Clear();
                MessageBox.Show("조회된 EQUIP LOG 데이터가 없습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Cycle Data Select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!GlobalClass.dbOracle.ConnectionStatus)
            {
                MessageBox.Show("DB 접속 상태를 확인하세요", "실패", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                SearchViewEquipLog();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                GC.Collect();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ORACLE 접속 초기화
        /// </summary>
        public void InitializeOracle()
        {
            try
            {
                //LogUtil.Log(LogUtil._INFO_LEVEL, this.GetType().Name, "---------- Oracle Database Initialize..");

                GlobalClass.dbOracle = null;
                GlobalClass.dbOracle = new DbOracle();

#if DEBUG
                GlobalClass.dbOracle.ConnectionIp = ConfigurationManager.AppSettings["OracleMainIP"];
                GlobalClass.dbOracle.ConnectionPort = int.Parse(ConfigurationManager.AppSettings["OraclePort"]);

                GlobalClass.dbOracle.ConnectionSID = ConfigurationManager.AppSettings["OracleSID"];

                GlobalClass.dbOracle.ConnectionID = ConfigurationManager.AppSettings["OracleConnectionID"];
                GlobalClass.dbOracle.ConnectionPassword = ConfigurationManager.AppSettings["OracleConnectionPassword"];

                // 하드코딩 VER.
                //GlobalClass.dbOracle.ConnectionIp = "hmx-logisol-oracle-db-dev.c5ruasqdgoz7.ap-northeast-2.rds.amazonaws.com";
                //GlobalClass.dbOracle.ConnectionPort = 1521;

                //GlobalClass.dbOracle.ConnectionSID = "OHMXDB";

                //GlobalClass.dbOracle.ConnectionID = "KY_K_POWDER";
                //GlobalClass.dbOracle.ConnectionPassword = "12345";
#else
                GlobalClass.dbOracle.ConnectionIp = ConfigurationManager.AppSettings["OracleMainIP"];
                GlobalClass.dbOracle.ConnectionPort = int.Parse(ConfigurationManager.AppSettings["OraclePort"]);

                GlobalClass.dbOracle.ConnectionSID = ConfigurationManager.AppSettings["OracleSID"];

                GlobalClass.dbOracle.ConnectionID = ConfigurationManager.AppSettings["OracleConnectionID"];
                GlobalClass.dbOracle.ConnectionPassword = ConfigurationManager.AppSettings["OracleConnectionPassword"];
#endif

                // Default : True
                if (Boolean.TryParse(ConfigurationManager.AppSettings["OracleConnectionPool"], out bool getValue))
                {
                    GlobalClass.dbOracle.ConnectionPoll = getValue;
                }
                else
                {
                    GlobalClass.dbOracle.ConnectionPoll = true;
                }
                GlobalClass.dbOracle.ConnectionMaxPooSize = int.Parse(ConfigurationManager.AppSettings["OracleConnectionMaxPoolSize"]);
                GlobalClass.dbOracle.ConnectionMinPooSize = int.Parse(ConfigurationManager.AppSettings["OracleConnectionMinPoolSize"]);

                GlobalClass.dbOracle.ConnectionTimeout = int.Parse(ConfigurationManager.AppSettings["OracleConnectionTimeout"]);

                string returnValue = GlobalClass.dbOracle.SetConnectionString();

                //LogUtil.Log(LogUtil._INFO_LEVEL, this.GetType().Name, "---------- Oracle Database Connection String - " + returnValue);
                //LogUtil.Log(LogUtil._INFO_LEVEL, this.GetType().Name, "---------- Oracle Database Connection Status - " + GlobalClass.dbOracle.ConnectionStatus.ToString());

            }
            catch (Exception ex)
            {
                //LogUtil.Log(LogUtil._ERROR_LEVEL, this.GetType().Name, ex.ToString());
            }
        }

        /// <summary>
        /// DB Connection Test
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDBTest_Click(object sender, EventArgs e)
        {
            GlobalClass.dbOracle.ConnectionIp = txtDBIP.Text.ToString().Trim();
            GlobalClass.dbOracle.ConnectionPort = int.Parse(txtDBPORT.Text);
            GlobalClass.dbOracle.ConnectionSID = txtDBSID.Text.ToString().Trim();
            GlobalClass.dbOracle.ConnectionID = txtUSERID.Text.ToString().Trim();
            GlobalClass.dbOracle.ConnectionPassword = txtUSERPW.Text.ToString().Trim();

            string returnValue = GlobalClass.dbOracle.SetConnectionString();

            if (GlobalClass.dbOracle.ConnectionStatus)
            {
                MessageBox.Show("DB Connection Success", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbDBStatus.Text = "DB Connection Success!!";
                lbDBStatus.ForeColor = Color.ForestGreen;
            }
            else
            {
                MessageBox.Show("DB Connection Failed.....", "실패", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbDBStatus.Text = "유효하지 않은 접속정보 입니다...";
                lbDBStatus.ForeColor = Color.Firebrick;
            }
        }

        /// <summary>
        /// 조회된 data에서 cycle 토대로 CYCLE_COUNT 갱신 (! 1000번째 확인 시 종료)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!GlobalClass.dbOracle.ConnectionStatus)
            {
                MessageBox.Show("DB 접속 상태를 확인하세요", "실패", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // 데이터 초기화
                InitializeData();

                // 검색 조건 파라미터 조회
                var dicParams = GetSearchParameters();

                // SQL 실행
                string sql = sqlQuery.SELECT_T_EQUIP_LOG(dicParams);
                System.Data.DataTable DT = GlobalClass.dbOracle.SelectSQL(sql);

                MessageBox.Show(sql, "!! 사이클 분석", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (DT.Rows.Count > 0)
                {
                    dtViewEquipLog.DataSource = DT;
                    dtViewEquipLog.ClearSelection();

                    // ---- 사이클 카운트 로직 (Type1 :  FOIL*ROLL 이재기/ Type2 : FOIL 컨베이어) ----
                    int cycleCount = 0;
                    int lastCycleValue = 0;
                    int i = 0;

                    // 1) FOIL/ROLL TRANSFER 이재기
                    if (cmbRunType.SelectedIndex == 0)
                    {
                        if (dtFiltered == null || dtFiltered.Columns.Count == 0) dtFiltered = DT.Clone();

                        while (i <= DT.Rows.Count - 6)
                        {
                            string track1 = DT.Rows[i]["TRACK_ID"].ToString().Trim();
                            string status1 = DT.Rows[i]["STATUS"].ToString().Trim();
                            string rmk1 = DT.Rows[i]["RMK"].ToString().Trim();

                            string track2 = DT.Rows[i + 1]["TRACK_ID"].ToString().Trim();
                            string status2 = DT.Rows[i + 1]["STATUS"].ToString().Trim();
                            string rmk2 = DT.Rows[i + 1]["RMK"].ToString().Trim();

                            string track3 = DT.Rows[i + 2]["TRACK_ID"].ToString().Trim();
                            string status3 = DT.Rows[i + 2]["STATUS"].ToString().Trim();
                            string rmk3 = DT.Rows[i + 2]["RMK"].ToString().Trim();

                            string track4 = DT.Rows[i + 3]["TRACK_ID"].ToString().Trim();
                            string status4 = DT.Rows[i + 3]["STATUS"].ToString().Trim();
                            string rmk4 = DT.Rows[i + 3]["RMK"].ToString().Trim();

                            string track5 = DT.Rows[i + 4]["TRACK_ID"].ToString().Trim();
                            string status5 = DT.Rows[i + 4]["STATUS"].ToString().Trim();
                            string rmk5 = DT.Rows[i + 4]["RMK"].ToString().Trim();

                            string track6 = DT.Rows[i + 5]["TRACK_ID"].ToString().Trim();
                            string status6 = DT.Rows[i + 5]["STATUS"].ToString().Trim();
                            string rmk6 = DT.Rows[i + 5]["RMK"].ToString().Trim();

                            // ① ShuttleActive
                            if (status1 == "ShuttleActive" && track1.EndsWith("-102"))
                            {
                                // ② Conveyor (Detect Changed)
                                if (track2.EndsWith("-102") && status2 == "CarrierDetect-1" &&
                                    status3 == "CarrierDetect-0" && status4 == "CarrierDetect-1" &&
                                    status5 == "CarrierDetect-0" && track5.EndsWith("-102"))
                                {
                                    // ③ ShuttleIdle
                                    if (status6 == "ShuttleIdle" && track6.EndsWith("-102"))
                                    {
                                        // 🔹 DB Update
                                        object idColumn = DT.Rows[i + 5]["ID_T_EQUIP_LOG"];
                                        string idToUpdate = ""; // 업데이트 할 컬럼의 PK
                                        if (idColumn is byte[] byteArray) idToUpdate = BitConverter.ToString(byteArray).Replace("-", "");

                                        // a) CYCLE_COUNT (lastCycleValue)
                                        cycleCount++;
                                        lastCycleValue = cycleCount;

                                        // b) INOUT TYPE
                                        string actionType = "";
                                        if (track3.EndsWith("-101")) actionType = "IN";
                                        else if (track3.EndsWith("-011")) actionType = "OUT";

                                        // c) CYCLE TIME (DIFF Check)
                                        string cycleTime = "";
                                        DateTime regDtmActive = Convert.ToDateTime(DT.Rows[i + 0]["REG_DTM"]);  // Shuttle Active
                                        DateTime regDtmIdle = Convert.ToDateTime(DT.Rows[i + 5]["REG_DTM"]);    // Shuttle Idle
                                        TimeSpan diffTime = regDtmIdle - regDtmActive;                          // Diff Check
                                        cycleTime = $"{diffTime.Minutes:D2}:{diffTime.Seconds:D2}";

                                        string updateQuery = $"UPDATE T_EQUIP_LOG " +
                                                             $"SET CYCLE_COUNT = '{lastCycleValue}', " +
                                                             $"\"ACTION\" = '{actionType}', " +  // "ACTION" 사용
                                                             $"CYCLE_TIME = '{cycleTime}' " +
                                                             $"WHERE ID_T_EQUIP_LOG = '{idToUpdate}'";

                                        int result = GlobalClass.dbOracle.ExecuteSQL(updateQuery);

                                        if (result > 0)
                                            Console.WriteLine($"[DB 업데이트 성공] (1) Transfer ID_T_EQUIP_LOG={idToUpdate}, CYCLE_COUNT={lastCycleValue}로 업데이트됨.");
                                        else
                                            Console.WriteLine($"[DB 업데이트 실패] (1) Transfer ID_T_EQUIP_LOG={idToUpdate}에 해당하는 데이터가 없음.");

                                        //for (int j = 0; j < 6; j++)
                                        //{
                                        //    DataRow newRow = dtFiltered.NewRow();

                                        //    for (int colIndex = 1; colIndex < DT.Columns.Count; colIndex++)
                                        //    {
                                        //        // 각 열의 값을 확인하여 Byte[]로 할당
                                        //        //if (DT.Rows[i + j][colIndex] is byte[] byteArr)
                                        //        //    newRow[colIndex] = byteArr.Clone();  // Byte[] 타입 열 처리
                                        //        //else
                                        //            newRow[colIndex] = DT.Rows[i + j][colIndex];  // 다른 타입은 그대로 복사
                                        //    }
                                        //    dtFiltered.Rows.Add(newRow);
                                        //}

                                        //// 🔹 사이클 조건을 만족하는 6개 행을 dtFiltered에 저장
                                        for (int j = 0; j < 6; j++)
                                        {
                                            dtFiltered.Rows.Add(DT.Rows[i + j].ItemArray.Clone() is byte[]);
                                            //MessageBox.Show(dtFiltered.Rows.Count.ToString().Trim());
                                        }
                                        // 다음 사이클
                                        i += 6;
                                    }
                                    else i++;
                                }
                                else i++;
                            }
                            else i++;
                        }

                        // 결과 출력
                        MessageBox.Show($"총 사이클 개수: {cycleCount}\n마지막 사이클의 CYCLE_COUNT: {lastCycleValue}",
                                        "사이클 분석", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lbTotCnt.Text = cycleCount.ToString() + " 건";

                        SearchViewEquipLog();
                    }
                    else if (cmbRunType.SelectedIndex == 1)// 2) FOIL CONVEYOR
                    {
                        int stepVal = 0;
                        string actionType = "";
                        int startIndex = 0;
                        while (i < DT.Rows.Count)
                        {
                            // Step Sequence 활용
                            string track = DT.Rows[i]["TRACK_ID"].ToString().Trim();
                            string status = DT.Rows[i]["STATUS"].ToString().Trim();
                            string rmk = DT.Rows[i]["RMK"].ToString().Trim();

                            // ① STEP -1
                            if (stepVal == 0)
                            {
                                if (track.EndsWith("-101") && status == "ConveyorActive")
                                {
                                    stepVal++;
                                    actionType = "IN";
                                    startIndex = i;
                                }
                                else if (track.EndsWith("-106") && status == "ConveyorActive")
                                {
                                    stepVal++;
                                    actionType = "OUT";
                                    startIndex = i;
                                }

                                i++;
                                continue;
                            }

                            // ② STEP -2
                            if ((track.EndsWith("-102") && status == "CarrierDetect-1" && stepVal == 1 && actionType == "IN") ||
                                (track.EndsWith("-105") && status == "CarrierDetect-1" && stepVal == 1 && actionType == "OUT"))
                            {
                                stepVal++;
                                continue;
                            }

                            // ③ STEP -3 (CYCLE_COUNT ++)
                            if ((track.EndsWith("-103") && status == "ConveyorIdle" && stepVal == 2 && actionType == "IN")
                                || (track.EndsWith("-104") && status == "ConveyorIdle" && stepVal == 2 && actionType == "OUT"))
                            {
                                cycleCount++;
                                // 🔹 DB Update
                                object idColumn = DT.Rows[i]["ID_T_EQUIP_LOG"];
                                string idToUpdate = "";
                                if (idColumn is byte[] byteArray)
                                    idToUpdate = BitConverter.ToString(byteArray).Replace("-", "");

                                // 🔹 CYCLE TIME (DIFF Check)
                                string cycleTime = "";
                                DateTime regDtmActive = Convert.ToDateTime(DT.Rows[startIndex]["REG_DTM"]);  // Shuttle Active
                                DateTime regDtmIdle = Convert.ToDateTime(DT.Rows[i]["REG_DTM"]);             // Shuttle Idle
                                TimeSpan diffTime = regDtmIdle - regDtmActive;                               // Diff Check
                                cycleTime = $"{diffTime.Minutes:D2}:{diffTime.Seconds:D2}";

                                lastCycleValue = cycleCount;
                                string updateQuery = $"UPDATE T_EQUIP_LOG " +
                                                     $"SET CYCLE_COUNT = '{lastCycleValue}', " +
                                                     $"\"ACTION\" = '{actionType}', " +  // "ACTION" 사용
                                                     $"CYCLE_TIME = '{cycleTime}' " +
                                                     $"WHERE ID_T_EQUIP_LOG = '{idToUpdate}'";

                                int result = GlobalClass.dbOracle.ExecuteSQL(updateQuery);

                                stepVal = 0;

                                if (result > 0)
                                    Console.WriteLine($"[DB 업데이트 성공] (1) Transfer ID_T_EQUIP_LOG={idToUpdate}, CYCLE_COUNT={lastCycleValue}로 업데이트됨.");
                                else
                                    Console.WriteLine($"[DB 업데이트 실패] (1) Transfer ID_T_EQUIP_LOG={idToUpdate}에 해당하는 데이터가 없음.");
                            }
                            i++;
                        }

                        // 결과 출력
                        MessageBox.Show($"총 사이클 개수: {cycleCount}\n마지막 사이클의 CYCLE_COUNT: {lastCycleValue}", "사이클 분석", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lbTotCnt.Text = cycleCount.ToString() + " 건";

                        SearchViewEquipLog();
                    }
                    else if (cmbRunType.SelectedIndex == 2) //2) VD LIFTER
                    {
                        int stepVal = 0;
                        string actionType = "";
                        int startIndex = 0;

                        while (i < DT.Rows.Count)
                        {
                            // Step Sequence 활용
                            string track = DT.Rows[i]["TRACK_ID"].ToString().Trim();
                            string status = DT.Rows[i]["STATUS"].ToString().Trim();
                            string rmk = DT.Rows[i]["RMK"].ToString().Trim();

                            // ① STEP -1
                            if (stepVal == 0)
                            {
                                if (track.EndsWith("-101") && status == "ConveyorActive")
                                {
                                    stepVal++;
                                    actionType = "IN";
                                    startIndex = i;
                                }
                                else if (track.EndsWith("-106") && status == "ConveyorActive")
                                {
                                    stepVal++;
                                    actionType = "OUT";
                                    startIndex = i;
                                }
                                i++;
                                continue;
                            }
                        }
                    }
                    else
                    {
                        dtViewEquipLog.Rows.Clear();
                        MessageBox.Show("조회된 EQUIP LOG 데이터가 없습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSYSID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSysID = cmbSYSID.SelectedItem.ToString();
            UpdatePLCNOItems(selectedSysID);
        }

        private void cmbSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSite = cmbSite.SelectedItem.ToString();
            UpdateSYSIDItems(selectedSite);
        }

        // 시작점~끝점의 ID 값 추출
        private void dtViewEquipLog_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right) // 우클릭 시
            {
                DataGridView.HitTestInfo hit = dtViewEquipLog.HitTest(e.X, e.Y);

                if (hit.RowIndex >= 0 && hit.ColumnIndex >= 0) // 유효한 셀인지 확인
                {
                    dtViewEquipLog.ClearSelection(); // 기존 선택 해제
                    dtViewEquipLog.Rows[hit.RowIndex].Selected = true; // 해당 행 선택
                    dtViewEquipLog.CurrentCell = dtViewEquipLog.Rows[hit.RowIndex].Cells[hit.ColumnIndex]; // 현재 셀 설정

                    // 🔹 마우스 위치에서 컨텍스트 메뉴 표시
                    contextMenu.Show(dtViewEquipLog, new Point(e.X, e.Y));
                }
            }
        }

        // 🔹 "수정" 클릭 시 실행되는 이벤트 핸들러
        private void OnEditClicked(object sender, EventArgs e)
        {
            if (dtViewEquipLog.CurrentRow != null)
            {
                MessageBox.Show($"수정할 데이터: {dtViewEquipLog.CurrentRow.Cells[0].Value}");
            }
        }

        // 🔹 "삭제" 클릭 시 실행되는 이벤트 핸들러
        private void OnDeleteClicked(object sender, EventArgs e)
        {
            if (dtViewEquipLog.CurrentRow != null)
            {
                MessageBox.Show($"삭제할 데이터: {dtViewEquipLog.CurrentRow.Cells[0].Value}");
            }
        }

        // 🔹 "확인" 클릭 시 실행되는 이벤트 핸들러
        private void OnCheckClicked(object sender, EventArgs e)
        {
            if (dtViewEquipLog.CurrentRow != null)
            {
                // 🔹 ID_T_EQUIP 값 가져오기
                var idValue = dtViewEquipLog.CurrentRow.Cells[0].Value;

                // 🔹 값이 null인지 확인
                if (idValue != null)
                {
                    if (idValue is byte[] byteArray)
                    {
                        // 🔹 byte[] → Hex 문자열 변환
                        string hexString = BitConverter.ToString(byteArray).Replace("-", "");
                        MessageBox.Show($"선택된 ID_T_EQUIP 값 (HEX): {hexString}");
                    }
                    else
                    {
                        MessageBox.Show($"선택된 ID_T_EQUIP 값: {idValue.ToString()}");
                    }
                }
                else
                {
                    MessageBox.Show("ID_T_EQUIP 값이 없습니다.");
                }
            }
        }

        /// <summary>
        /// CYCLE_COUNT 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {

            int cycleCount = 0;

            var dicParams = GetSearchParameters();
            //dicParams["CYCLE_COUNT"] = "0";

            dicParams["CYCLE_COUNT"] = "";
            dicParams["ACTION"] = "";
            dicParams["CYCLE_TIME"] = "";
            string sql = sqlQuery.UPDATE_T_EQUIP_LOG_RESET(dicParams);
            
            int result = GlobalClass.dbOracle.ExecuteSQL(sql);

            if (result > 0)
                Console.WriteLine($"[DB 업데이트 성공] CYCLE_COUNT=0 으로 초기화됨.");
            else
                Console.WriteLine($"[DB 업데이트 실패]");

            MessageBox.Show(sql, "RESET", MessageBoxButtons.OK, MessageBoxIcon.Information);

            SearchViewEquipLog();
        }

        private void cmbPLCNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            // RUN TYPE(TEST TYPE) Change 필요
        }


        /// <summary>
        /// CSV 추출 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExtract_Click(object sender, EventArgs e)
        {

            // ① SAVE RAW DATA
            string fileName = "CycleRawResult_";
            try
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                if (excelApp == null)
                {
                    SaveFileDialog saveFileDialog = Util.GetCsvSave(fileName);
                    if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Util.Save_csv(saveFileDialog.FileName, dtViewEquipLog, true); 
                    }
                }
                else
                {
                    Util.ConfirmExcel(ref dtViewEquipLog, fileName);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString(), "TYPE1", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SaveFileDialog saveFileDialog = Util.GetCsvSave(fileName);
                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Util.Save_csv(saveFileDialog.FileName, dtViewEquipLog, true); 
                }
            }

            // ② SAVE CYCLE DATA ONLY (-ING)
            string fileName2 = "CycleResult_";
            DataGridView dtgFiltered = new DataGridView(); 
            try
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                if (excelApp == null)
                {
                    SaveFileDialog saveFileDialog = Util.GetCsvSave(fileName2);
                    if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        dtgFiltered.DataSource = dtFiltered;  // 여기서 DataSource 설정
                        Util.Save_csv(saveFileDialog.FileName, dtgFiltered, true);
                    }
                }
                else
                {
                    Util.ConfirmExcel(ref dtgFiltered, fileName2);
                }
            }
            catch (Exception ex)
            {
                SaveFileDialog saveFileDialog = Util.GetCsvSave(fileName2);
                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show(dtFiltered.Rows.Count.ToString().Trim()); 
                    dtgFiltered.DataSource = dtFiltered;  
                    dtgFiltered.Update();
                    MessageBox.Show(dtgFiltered.Rows.Count.ToString().Trim());

                    Util.Save_csv(saveFileDialog.FileName, dtgFiltered, true);
                }
            }
        }

        // DataGridView에서 선택된 행만을 DataTable로 변환
        private DataTable GetSelectedRows(DataGridView dgv)
        {
            DataTable dt = ((DataTable)dgv.DataSource).Clone(); // 원본 테이블의 구조를 복사
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        dr[i] = row.Cells[i].Value;
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        private void cmbRunType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRunType.SelectedIndex == 1)
            {
                lbINOUTType.Visible = true;
                cmbInOutType.Visible = true;
            }
            else
            {
                lbINOUTType.Visible = false;
                cmbInOutType.Visible = false;
            }
        }
    }
}
