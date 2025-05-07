using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.VariantTypes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace CycleSample.DB
{
    public class DBOracleSql
    {

        /// <summary>
        ///  SITE에 해당되는 SYS_ID 가져오기
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string SELECT_SYSID_LIST(ConcurrentDictionary<string, string> param)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.AppendFormat("SELECT DISTINCT SYS_ID ");
                sb.AppendFormat("FROM V_T_TRACK ");

                if (param.ContainsKey("SITE"))
                {
                    if (param.TryGetValue("SITE", out string site))
                        sb.AppendFormat("WHERE SITE = '{0}'   \r\n  ", site);
                }

                sb.AppendFormat("ORDER BY SUBSTR(SYS_ID, 1, 1) DESC, SUBSTR(SYS_ID, 5, 1) DESC, DECODE(SUBSTR(SYS_ID, 3, 1), 'P', 1), SUBSTR(SYS_ID, 3, 1), SUBSTR(SYS_ID, 7, 1)");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                //LogUtil.Log(LogUtil._ERROR_LEVEL, this.GetType().Name, ex.ToString());
                return "";
            }
            finally
            {
                sb = null;
            }
        }


        /// <summary>
        ///  SITE에 해당되는 SYS_ID 가져오기
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string SELECT_PLCNO_LIST(ConcurrentDictionary<string, string> param)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.AppendFormat("SELECT DISTINCT PLC_NO ");
                sb.AppendFormat("FROM T_SYSTEM ");

                if (param.ContainsKey("SYS_ID"))
                {
                    if (param.TryGetValue("SYS_ID", out string sys_id))
                        sb.AppendFormat("WHERE SYS_ID = '{0}'   \r\n  ", sys_id);
                }
                sb.AppendFormat("ORDER BY PLC_NO ASC");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                //LogUtil.Log(LogUtil._ERROR_LEVEL, this.GetType().Name, ex.ToString());
                return "";
            }
            finally
            {
                sb = null;
            }
        }

        /// <summary>
        /// PLCIP에 해당하는 모든 트랙 정보 조회
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string SELECT_T_DEVICEMAP_TRACKLIST(ConcurrentDictionary<string, string> param)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.AppendFormat("SELECT COUNT (*)                   ");
                sb.AppendFormat("  FROM T_TRACK                     ");
                sb.AppendFormat("  WHERE 1=1                        ");


                if (param.ContainsKey("SYS_ID"))
                {
                    if (param.TryGetValue("SYS_ID", out string sis_id))
                        sb.AppendFormat("   AND SYS_ID = '{0}'             \r\n", sis_id);
                }
                if (param.ContainsKey("TRACK_ID"))
                {
                    if (param.TryGetValue("TRACK_ID", out string track_id))
                        sb.AppendFormat("   AND TRACK_ID LIKE '%{0}%'             \r\n", track_id);
                }
                if (param.ContainsKey("SITE"))
                {
                    if (param.TryGetValue("SITE", out string site))
                        sb.AppendFormat("   AND SITE = '{0}'             \r\n", site);
                }
                //sb.AppendFormat(" ORDER BY PLC_IP ASC");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                //LogUtil.Log(LogUtil._ERROR_LEVEL, this.GetType().Name, ex.ToString());
                return "";
            }
            finally
            {
                sb = null;
            }
        }

        /// <summary>
        /// sysID에 해당하는 모든 PLC ID 개수 조회
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string SELECT_T_PLCMAP_TRACKLIST(ConcurrentDictionary<string, string> param)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.AppendFormat("SELECT COUNT (DISTINCT PLC_ID)                   ");
                sb.AppendFormat("  FROM V_T_TRACK                     ");
                sb.AppendFormat("  WHERE 1=1                        ");

                if (param.ContainsKey("SYS_ID"))
                {
                    if (param.TryGetValue("SYS_ID", out string sis_id))
                        sb.AppendFormat("   AND SYS_ID = '{0}'             \r\n", sis_id);
                }
                if (param.ContainsKey("SITE"))
                {
                    if (param.TryGetValue("SITE", out string site))
                        sb.AppendFormat("   AND SITE = '{0}'             \r\n", site);
                }

                return sb.ToString();

            }
            catch (Exception ex)
            {
                //LogUtil.Log(LogUtil._ERROR_LEVEL, this.GetType().Name, ex.ToString());
                return "";
            }
            finally
            {
                sb = null;
            }
        }


        /// <summary>
        /// T_PLCMAP_CHECKLIST에 없는 TRACK 데이터 수집
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>

        public string SELECT_TRACKID_NOTIN_CHECKLIST(ConcurrentDictionary<string, string> param)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.AppendFormat("SELECT DISTINCT TRACK_ID  , EQP_ID        ");
                sb.AppendFormat("  FROM T_TRACK                     ");
                sb.AppendFormat(" WHERE 1 = 1                       ");
                //if (param.ContainsKey("TRACK_ID"))
                //{
                //    if (param.TryGetValue("TRACK_ID", out string track_id))
                //        sb.AppendFormat("   AND TRACK_ID LIKE '%{0}%'             \r\n", track_id);
                //}

                if (param.ContainsKey("SYS_ID"))
                {
                    if (param.TryGetValue("SYS_ID", out string sis_id))
                        sb.AppendFormat("   AND SYS_ID = '{0}'             \r\n", sis_id);
                }

                if (param.ContainsKey("SITE"))
                {
                    if (param.TryGetValue("SITE", out string site))
                        sb.AppendFormat("   AND SITE = '{0}'             \r\n", site);
                }

                sb.AppendFormat(" AND TRACK_ID NOT IN (         " +
                                                        "SELECT TRACK_ID FROM T_DEVICEMAP_CHECKLIST " +
                                                        "WHERE 1=1               ");

                if (param.ContainsKey("SYS_ID"))
                {
                    if (param.TryGetValue("SYS_ID", out string sis_id))
                        sb.AppendFormat("   AND SYS_ID = '{0}'             \r\n", sis_id);
                }

                if (param.ContainsKey("SITE"))
                {
                    if (param.TryGetValue("SITE", out string site))
                        sb.AppendFormat("   AND SITE = '{0}'             \r\n", site);
                }

                if (param.ContainsKey("FROM_DATE") & param.ContainsKey("TO_DATE") && param.ContainsKey("FROM_TIME") && param.ContainsKey("TO_TIME"))
                {
                    string fromDate = param["FROM_DATE"] + param["FROM_TIME"];
                    string toDate = param["TO_DATE"] + param["TO_TIME"];
                    sb.AppendFormat("AND TO_TIMESTAMP(TEST_DATE || TEST_TIME , 'YYYYMMDDHH24MISS') " +
                                    "BETWEEN TO_TIMESTAMP('{0}', 'YYYYMMDDHH24MISS') " +
                                    "AND TO_TIMESTAMP('{1}', 'YYYYMMDDHH24MISS') \r\n ", fromDate, toDate);
                }

                sb.AppendFormat(") ORDER BY TRACK_ID ASC");

                return sb.ToString();

            }
            catch (Exception ex)
            {
                //LogUtil.Log(LogUtil._ERROR_LEVEL, this.GetType().Name, ex.ToString());
                return "";
            }
            finally
            {
                sb = null;
            }
        }

        /// <summary>
        /// T_DEVICEMAP_CHECKLIST에 없는 PLC 데이터 수집        ------  여기 수정 필요
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>

        public string SELECT_PLCID_NOTIN_CHECKLIST(ConcurrentDictionary<string, string> param)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.AppendFormat("SELECT DISTINCT PLC_ID ");
                sb.AppendFormat("  FROM V_T_TRACK                     ");
                sb.AppendFormat(" WHERE 1 = 1                       ");

                if (param.ContainsKey("SYS_ID"))
                {
                    if (param.TryGetValue("SYS_ID", out string sis_id))
                        sb.AppendFormat("   AND SYS_ID = '{0}'             \r\n", sis_id);
                }
                if (param.ContainsKey("SITE"))
                {
                    if (param.TryGetValue("SITE", out string site))
                        sb.AppendFormat("   AND SITE = '{0}'             \r\n", site);
                }

                sb.AppendFormat(" AND PLC_ID NOT IN (         " +
                                                        "SELECT DISTINCT PLC_ID FROM V_T_PLCMAP_CHECKLIST " +
                                                        "WHERE 1=1               ");

                if (param.ContainsKey("SYS_ID"))
                {
                    if (param.TryGetValue("SYS_ID", out string sis_id))
                        sb.AppendFormat("   AND SYS_ID = '{0}'             \r\n", sis_id);
                }

                if (param.ContainsKey("SITE"))
                {
                    if (param.TryGetValue("SITE", out string site))
                        sb.AppendFormat("   AND SITE = '{0}'             \r\n", site);
                }

                if (param.ContainsKey("FROM_DATE") & param.ContainsKey("TO_DATE") && param.ContainsKey("FROM_TIME") && param.ContainsKey("TO_TIME"))
                {
                    string fromDate = param["FROM_DATE"] + param["FROM_TIME"];
                    string toDate = param["TO_DATE"] + param["TO_TIME"];
                    sb.AppendFormat("AND TO_TIMESTAMP(TEST_DATE || TEST_TIME , 'YYYYMMDDHH24MISS') " +
                                    "BETWEEN TO_TIMESTAMP('{0}', 'YYYYMMDDHH24MISS') " +
                                    "AND TO_TIMESTAMP('{1}', 'YYYYMMDDHH24MISS') \r\n ", fromDate, toDate);
                }

                sb.AppendFormat(") ORDER BY PLC_ID ASC");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                //LogUtil.Log(LogUtil._ERROR_LEVEL, this.GetType().Name, ex.ToString());
                return "";
            }
            finally
            {
                sb = null;
            }
        }


        /// <summary>
        /// 트랙 데이터 추출
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string SELECT_T_TRACK_DATA(ConcurrentDictionary<string, string> param)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.AppendFormat("SELECT *");
                sb.AppendFormat("  FROM V_T_TRACK");
                sb.AppendFormat("  WHERE 1=1");

                if (param.ContainsKey("SYS_ID"))
                {
                    if (param.TryGetValue("SYS_ID", out string sis_id))
                        sb.AppendFormat("   AND SYS_ID = '{0}'             \r\n", sis_id);
                }

                if (param.ContainsKey("SITE"))
                {
                    if (param.TryGetValue("SITE", out string site))
                        sb.AppendFormat("   AND SITE = '{0}'             \r\n", site);
                }

                sb.AppendFormat(" ORDER BY PLC_ID ASC");
                //sb.AppendFormat(" ORDER BY PLC_IP ASC");
                return sb.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
                sb = null;
            }
        }


        /// <summary>
        /// PLC 데이터 추출     --- (수정 완료)
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string SELECT_PLCID_DATA(ConcurrentDictionary<string, string> param)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.AppendFormat("SELECT DISTINCT PLC_ID ");
                sb.AppendFormat("FROM V_T_TRACK ");
                sb.AppendFormat("WHERE 1=1");

                if (param.ContainsKey("SYS_ID"))
                {
                    if (param.TryGetValue("SYS_ID", out string sis_id))
                        sb.AppendFormat(" AND SYS_ID ='{0}'     \r\n", sis_id);
                }

                if (param.ContainsKey("SITE"))
                {
                    if (param.TryGetValue("SITE", out string site))
                        sb.AppendFormat(" AND SITE='{0}'   \r\n", site);
                }
                sb.AppendFormat(" ORDER BY PLC_ID ASC");
                return sb.ToString();
            }
            catch (Exception ex)
            {
                return ("V_T_TRACK에서 PLC DATA를 조회하는 데 오류가 발생했습니다:" + ex.Message);
            }
            finally
            {
                sb = null;
            }
        }

        public string UPDATE_T_EQUIP_LOG_RESET(ConcurrentDictionary<string, string>param)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.AppendFormat("   UPDATE T_EQUIP_LOG ");
                sb.AppendFormat("   SET CYCLE_COUNT = '{0}'                     ", param["CYCLE_COUNT"]);
                sb.AppendFormat("   , \"ACTION\" = '{0}' "                       , param["ACTION"]);  
                sb.AppendFormat("   , CYCLE_TIME = '{0}'                        ", param["CYCLE_TIME"]);
                sb.AppendFormat("   WHERE 1=1    ");
                sb.AppendFormat("   AND CYCLE_COUNT <> '0' ");

                //if (param.ContainsKey("SYS_ID"))
                //{
                //    if (param.TryGetValue("SYS_ID", out string sis_id))
                //        sb.AppendFormat("   AND SYS_ID = '{0}'             \r\n", sis_id);
                //}

                //if (param.ContainsKey("SITE"))
                //{
                //    if (param.TryGetValue("SITE", out string site))
                //        sb.AppendFormat("   AND SITE = '{0}'             \r\n", site);
                //}

                //if (param.ContainsKey("TRACK_ID"))
                //{
                //    if (param.TryGetValue("TRACK_ID", out string track_id))
                //        sb.AppendFormat("   AND TRACK_ID LIKE '%{0}%'             \r\n", track_id);
                //}

                //if(param.ContainsKey("RMK"))
                //{
                //    if (param.TryGetValue("RMK", out string rmk))
                //        sb.AppendFormat("   AND RMK LIKE '%{0}%'             \r\n", rmk);
                //}

                //if(param.ContainsKey("ACTION"))
                //{
                //    if (param.TryGetValue("ACTION", out string action))
                //        sb.AppendFormat("   AND ACTION = '{0}'             \r\n", action);
                //}

                return sb.ToString();
            }
            catch (Exception ex)
            {
                return ("T_EQUIP_LOG에서 DATA를 조회하는 데 오류가 발생했습니다:" + ex.Message);
            }
            finally
            {
                sb = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string SELECT_T_EQUIP_LOG(ConcurrentDictionary<string, string> param)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.AppendFormat("SELECT * ");
                sb.AppendFormat("  FROM T_EQUIP_LOG");
                sb.AppendFormat("  WHERE 1=1    ");

                if (param.ContainsKey("SYS_ID"))
                {
                    if (param.TryGetValue("SYS_ID", out string sis_id))
                        sb.AppendFormat("   AND SYS_ID = '{0}'             \r\n", sis_id);
                }

                if (param.ContainsKey("SITE"))
                {
                    if (param.TryGetValue("SITE", out string site))
                        sb.AppendFormat("   AND SITE = '{0}'             \r\n", site);
                }
                
                if (param.ContainsKey("TRACK_ID"))
                {
                    if (param.TryGetValue("TRACK_ID", out string track_id))
                        sb.AppendFormat("   AND TRACK_ID LIKE '%{0}%'             \r\n", track_id);
                }

                if (param.ContainsKey("RMK"))
                {
                    if (param.TryGetValue("RMK", out string rmk))
                        sb.AppendFormat("   AND RMK = '{0}'             \r\n", rmk);
                }

                if (param.ContainsKey("STATUS"))
                {
                    if (param.TryGetValue("STATUS", out string status))
                        sb.AppendFormat("   AND STATUS = '{0}'             \r\n", status);
                }

                if (param.ContainsKey("INOUT"))
                {
                    if (param.TryGetValue("INOUT", out string inout))
                    {
                        if (inout == "IN")
                        {
                            sb.AppendLine("   AND (");
                            sb.AppendLine("        TRACK_ID LIKE '%-101'");
                            sb.AppendLine("     OR TRACK_ID LIKE '%-102'");
                            sb.AppendLine("     OR TRACK_ID LIKE '%-103'");
                            sb.AppendLine("       )");
                        }
                        else if (inout == "OUT")
                        {
                            sb.AppendLine("   AND (");
                            sb.AppendLine("        TRACK_ID LIKE '%-104'");
                            sb.AppendLine("     OR TRACK_ID LIKE '%-105'");
                            sb.AppendLine("     OR TRACK_ID LIKE '%-106'");
                            sb.AppendLine("       )");
                        }
                    }
                }


                if (param.ContainsKey("FROM_DATE") & param.ContainsKey("TO_DATE") && param.ContainsKey("FROM_TIME") && param.ContainsKey("TO_TIME"))
                {
                    string fromDate = param["FROM_DATE"] + param["FROM_TIME"];
                    string toDate = param["TO_DATE"] + param["TO_TIME"];
                    sb.AppendFormat("AND REG_DTM " +
                                    "BETWEEN TO_TIMESTAMP('{0}', 'YYYYMMDDHH24MISS') " +
                                    "AND TO_TIMESTAMP('{1}', 'YYYYMMDDHH24MISS') \r\n", fromDate, toDate);
                }

                sb.AppendFormat(" ORDER BY REG_DTM ASC");
                return sb.ToString();
            }
            catch (Exception ex)
            {
                return ("T_EQUIP_LOG 에서 DATA를 조회하는 데 오류가 발생했습니다:" + ex.Message);
            }
            finally
            {
                sb = null;
            }
        }

        /// <summary>
        /// 조회 조건 만족하는 데이터 조회
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string SELECT_T_DEVICEMAP_CHECKLIST(ConcurrentDictionary<string, string> param)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.AppendFormat("SELECT a.* ");
                sb.AppendFormat("  FROM V_T_DEVICEMAP_CHECKLIST_NEW a JOIN (                 ");
                sb.AppendFormat("  SELECT TRACK_ID, MAX(TO_TIMESTAMP (TEST_DATE || TEST_TIME , 'YYYYMMDDHH24MISS')) AS max_time                 ");
                sb.AppendFormat("  FROM V_T_DEVICEMAP_CHECKLIST_NEW   ");

                if (param.ContainsKey("FROM_DATE") & param.ContainsKey("TO_DATE") && param.ContainsKey("FROM_TIME") && param.ContainsKey("TO_TIME"))
                {
                    string fromDate = param["FROM_DATE"] + param["FROM_TIME"];
                    string toDate = param["TO_DATE"] + param["TO_TIME"];
                    sb.AppendFormat("WHERE TO_TIMESTAMP(TEST_DATE || TEST_TIME , 'YYYYMMDDHH24MISS') " +
                                    "BETWEEN TO_TIMESTAMP('{0}', 'YYYYMMDDHH24MISS') " +
                                    "AND TO_TIMESTAMP('{1}', 'YYYYMMDDHH24MISS') \r\n", fromDate, toDate);
                }

                if (param.ContainsKey("SYS_ID"))
                {
                    if (param.TryGetValue("SYS_ID", out string sis_id))
                        sb.AppendFormat("   AND SYS_ID = '{0}'             \r\n", sis_id);
                }

                if (param.ContainsKey("SITE"))
                {
                    if (param.TryGetValue("SITE", out string site))
                        sb.AppendFormat("   AND SITE = '{0}'             \r\n", site);
                }

                sb.AppendFormat("  GROUP BY TRACK_ID ");
                sb.AppendFormat("  ) b ON a.TRACK_ID = b.TRACK_ID ");
                sb.AppendFormat("  AND TO_TIMESTAMP(a.TEST_DATE || a.TEST_TIME , 'YYYYMMDDHH24MISS') = b.max_time ");
                sb.AppendFormat(" ORDER BY a.TRACK_ID ASC");
                //sb.AppendFormat(" ORDER BY PLC_IP ASC");
                return sb.ToString();
            }
            catch (Exception ex)
            {
                //LogUtil.Log(LogUtil._ERROR_LEVEL, this.GetType().Name, ex.ToString());
                return ("V_T_DEVICEMAP_CHECKLIST에서 DATA를 조회하는 데 오류가 발생했습니다:" + ex.Message);
            }
            finally
            {
                sb = null;
            }
        }


        /// <summary>
        /// 조회 조건 만족하는 데이터 조회
        /// </summary>
        /// <param name="param"></param>    ----------- 
        /// <returns></returns>
        public string SELECT_T_PLCMAP_CHECKLIST(ConcurrentDictionary<string, string> param)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.AppendFormat("SELECT a.* ");
                sb.AppendFormat("  FROM V_T_PLCMAP_CHECKLIST_NEW a JOIN (                 ");
                sb.AppendFormat("  SELECT PLC_ID, MAX(TO_TIMESTAMP (TEST_DATE || TEST_TIME , 'YYYYMMDDHH24MISS')) AS max_time                 ");
                sb.AppendFormat("  FROM V_T_PLCMAP_CHECKLIST_NEW ");

                if (param.ContainsKey("FROM_DATE") & param.ContainsKey("TO_DATE") && param.ContainsKey("FROM_TIME") && param.ContainsKey("TO_TIME"))
                {
                    string fromDate = param["FROM_DATE"] + param["FROM_TIME"];
                    string toDate = param["TO_DATE"] + param["TO_TIME"];
                    sb.AppendFormat("WHERE TO_TIMESTAMP(TEST_DATE || TEST_TIME , 'YYYYMMDDHH24MISS') " +
                                    "BETWEEN TO_TIMESTAMP('{0}', 'YYYYMMDDHH24MISS') " +
                                    "AND TO_TIMESTAMP('{1}', 'YYYYMMDDHH24MISS') \r\n", fromDate, toDate);
                }

                if (param.ContainsKey("SYS_ID"))
                {
                    if (param.TryGetValue("SYS_ID", out string sis_id))
                        sb.AppendFormat("   AND SYS_ID = '{0}'             \r\n", sis_id);
                }

                if (param.ContainsKey("SITE"))
                {
                    if (param.TryGetValue("SITE", out string site))
                        sb.AppendFormat("   AND SITE = '{0}'             \r\n", site);
                }
                sb.AppendFormat("  GROUP BY PLC_ID ");
                sb.AppendFormat("  ) b ON a.PLC_ID = b.PLC_ID ");
                sb.AppendFormat("  AND TO_TIMESTAMP(a.TEST_DATE || a.TEST_TIME , 'YYYYMMDDHH24MISS') = b.max_time ");

                sb.AppendFormat(" ORDER BY a.PLC_ID ASC");
                //sb.AppendFormat(" ORDER BY PLC_IP ASC");RR
                return sb.ToString();
            }
            catch (Exception ex)
            {
                //LogUtil.Log(LogUtil._ERROR_LEVEL, this.GetType().Name, ex.ToString());
                return "";
            }
            finally
            {
                sb = null;
            }
        }
    }
}
