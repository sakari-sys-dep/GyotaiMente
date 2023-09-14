using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Kouri_Form.Class
{
    public class DBManager
    {
        private SqlConnection _con = null;
        private SqlTransaction _trn = null;

        #region データベース接続
        /// <summary>
        /// データベース接続
        /// </summary>
        /// <param name="tot">タイムアウト（秒）</param>
        /// <param name="key">接続情報取得キー</param>
        public void Connect(string key, int tot)
        {
            try
            {
                string cst = "";
                //初期化
                if (_con == null)
                {
                    _con = new SqlConnection();
                }
                //データベースの接続情報をWeb.configより取得する
                cst = ConfigurationManager.ConnectionStrings[key].ToString();
                //タイムアウトの設定
                if (tot > -1)
                {
                    cst = cst + ";Connect Timeout=" + tot.ToString();
                }
                //データベースの接続情報をセット
                _con.ConnectionString = cst;
                //データベースへの接続
                _con.Open();
            }catch
            {
                throw;
            }
        }
        #endregion

        #region データベース切断
        /// <summary>
        /// データベース切断
        /// </summary>
        public void Disconnect()
        {
            try
            {
                if (_con != null)
                {
                    _con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region トランザクションの開始
        /// <summary>
        /// トランザクションの開始
        /// </summary>
        public void BeginTransaction()
        {
            try
            {
                _trn = _con.BeginTransaction();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region コミット
        /// <summary>
        /// コミット
        /// </summary>
        public void CommitTransaction()
        {
            try
            {
                if (_trn != null)
                {
                    _trn.Commit();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _trn = null;
            }
        }
        #endregion

        #region ロールバック
        /// <summary>
        /// ロールバック
        /// </summary>
        public void RollbackTransaction()
        {
            try
            {
                if (_trn != null)
                {
                    _trn.Rollback();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _trn = null;
            }
        }
        #endregion

        #region デストラクタ
        /// <summary>
        /// デストラクタ
        /// </summary>
        /// <remarks></remarks>
        ~DBManager()
        {
            Disconnect();
        }
        #endregion



        #region クエリの実行（reader）
        /// <summary>
        /// クエリの実行（reader）
        /// </summary>
        /// <param name="query">ＳＱＬ</param>
        /// <param name="paramDict">パラメータ</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader ExecuteQueryReder(string query, Dictionary<string, Object> paramDict)
        {
            try
            {
                SqlCommand sqlCom = new SqlCommand
                {
                    //クエリー送信先、トランザクションの指定
                    Connection = _con,
                    Transaction = _trn,

                    CommandText = query,
                    CommandTimeout = 0

                };

                //パラメータの設定
                foreach (KeyValuePair<string, Object> item in paramDict)
                {
                    sqlCom.Parameters.Add(new SqlParameter(item.Key, item.Value));
                }

                // SQLを実行
                SqlDataReader reader = sqlCom.ExecuteReader();

                return reader;
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// クエリの実行（reader）パラメータなし
        /// </summary>
        /// <param name="query">ＳＱＬ</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader ExecuteQueryReder(string query)
        {
            return this.ExecuteQueryReder(query, new Dictionary<string, Object>());
        }
        #endregion

        #region クエリの実行（DataTable）
        /// <summary>
        /// クエリの実行（DataTable）
        /// </summary>
        /// <param name="query">ＳＱＬ</param>
        /// <param name="paramDict">パラメータ</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteQueryDataTable(string query, Dictionary<string, Object> paramDict)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlCommand sqlCom = new SqlCommand
                {
                    //クエリー送信先、トランザクションの指定
                    Connection = _con,
                    Transaction = _trn,

                    CommandText = query,
                    CommandTimeout = 0
                };

                foreach (KeyValuePair<string, Object> item in paramDict)
                {
                    sqlCom.Parameters.Add(new SqlParameter(item.Key, item.Value));
                }

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCom);

                adapter.Fill(dt);

                adapter.Dispose();
                sqlCom.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return dt;
        }

        /// <summary>
        /// クエリの実行（DataTable）
        /// </summary>
        /// <param name="query">ＳＱＬ</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteQueryDataTable(string query)
        {
            return this.ExecuteQueryDataTable(query, new Dictionary<string, Object>());
        }
        #endregion

        #region クエリの実行(更新処理）
        /// <summary>
        /// クエリの実行(更新処理）
        /// </summary>
        /// <param name="query">ＳＱＬ</param>
        /// <param name="paramDict">パラメータ</param>
        public void ExecuteNonQuery(string query, Dictionary<string, Object> paramDict)
        {
            try
            {
                SqlCommand sqlCom = new SqlCommand
                {
                    //クエリー送信先、トランザクションの指定
                    Connection = _con,
                    Transaction = _trn,
                    CommandText = query,
                    CommandTimeout = 0
                };

                foreach (KeyValuePair<string, Object> item in paramDict)
                {
                    sqlCom.Parameters.Add(new SqlParameter(item.Key, item.Value));
                }

                // SQLを実行
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion


        #region ストアドプロシージャの実行
        /// <summary>
        /// ストアドプロシージャの実行
        /// </summary>
        /// <param name="procedureName">ストアドプロシージャ名</param>
        /// <param name="paramDict">パラメータ</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteProcedure(string procedureName, Dictionary<string, Object> paramDict)
        {
            // コマンド作成
            SqlCommand sqlCom = _con.CreateCommand();
            sqlCom.CommandTimeout = 0;

            // ストアド プロシージャを指定
            sqlCom.CommandType = CommandType.StoredProcedure;

            // ストアド プロシージャ名を指定
            sqlCom.CommandText = procedureName;

            foreach (KeyValuePair<string, Object> item in paramDict)
            {
                sqlCom.Parameters.Add(new SqlParameter(item.Key, item.Value));
            }

            // ストアド プロシージャを実行し、SELECT結果をdataSetへ格納
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCom))
            {
                adapter.Fill(dt);
            }

            return dt;
        }
        /// <summary>
        /// ストアドプロシージャの実行
        /// </summary>
        /// <param name="procedureName">ストアドプロシージャ名</param>
        /// <param name="paramDict">パラメータ</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteProcedureTrn(string procedureName, Dictionary<string, Object> paramDict)
        {
            // コマンド作成
            //SqlCommand sqlCom = _con.CreateCommand();
            SqlCommand sqlCom = new SqlCommand
            {
                //クエリー送信先、トランザクションの指定
                Connection = _con,
                Transaction = _trn,
                CommandTimeout = 0
            };

            // ストアド プロシージャを指定
            sqlCom.CommandType = CommandType.StoredProcedure;

            // ストアド プロシージャ名を指定
            sqlCom.CommandText = procedureName;

            foreach (KeyValuePair<string, Object> item in paramDict)
            {
                sqlCom.Parameters.Add(new SqlParameter(item.Key, item.Value));
            }

            // ストアド プロシージャを実行し、SELECT結果をdataSetへ格納
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCom))
            {
                adapter.Fill(dt);
            }

            return dt;
        }
        /// <summary>
        /// ストアドプロシージャの実行
        /// </summary>
        /// <param name="procedureName">ストアドプロシージャ名</param>
        /// <param name="paramDict">パラメータ</param>
        /// <returns>ストアドのリターン値</returns>
        public string ExecuteProcedureNonQuery(string procedureName, Dictionary<string, Object> paramDict)
        {

            // コマンド作成
            //SqlCommand sqlCom = _con.CreateCommand();
            SqlCommand sqlCom = new SqlCommand
            {
                //クエリー送信先、トランザクションの指定
                Connection = _con,
                Transaction = _trn,
                CommandTimeout = 0

            };

            // ストアド プロシージャを指定
            sqlCom.CommandType = CommandType.StoredProcedure;

            // ストアド プロシージャ名を指定
            sqlCom.CommandText = procedureName;

            foreach (KeyValuePair<string, Object> item in paramDict)
            {
                sqlCom.Parameters.Add(new SqlParameter(item.Key, item.Value));
            }

            SqlParameter ret = new SqlParameter("aiueo", SqlDbType.Int); // (1) SqlParameter のインスタンスを作って・・・
            ret.Direction = ParameterDirection.ReturnValue; // (2) Direction を指定して・・・
            sqlCom.Parameters.Add(ret); // (3) Parameters に Add する。この順番を守ること！

            sqlCom.ExecuteNonQuery();

            return ret.Value.ToString();
        }
        #endregion


        public static int GetTableData(string connName, string sql, ref DataTable tb)
        {
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            return GetTableData(connName, sql, paramDict, ref tb);
        }

        public static int GetTableData(string connName, string sql, Dictionary<string, Object> paramDict, ref DataTable tb)
        {
            DBManager db = new DBManager();
            try
            {
                db.Connect(connName, -1);
                tb = db.ExecuteQueryDataTable(sql, paramDict);
                db.Disconnect();
                return tb.Rows.Count;
            }
            catch (Exception)
            {
                db.Disconnect();
                throw;
            }
        }

    }
}