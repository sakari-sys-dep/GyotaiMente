using System.Data;
using Microsoft.Data.SqlClient;


/*
 * ADO.NET
 * ODBC 経由でのデータベース操作クラス
 */
namespace GyotaiMente.Class
{
    public class DBManager
    {
        private SqlConnection? _con = null;
        private SqlTransaction? _trn = null;
        IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        /// <summary>
        /// ＤＢ接続
        /// </summary>
        /// <param name="key">接続文字列取得キー</param>
        public void Connect(string key)
        {
            try
            {
                //DBの接続文字列
                string cst = "";
                //初期化
                if (_con == null)
                {
                    _con = new SqlConnection();
                }
                //DBの接続文字列の取得
                cst = configuration.GetConnectionString(key);
                _con.ConnectionString = cst;
                //データベースへ接続
                _con.Open();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// ＤＢ接続
        /// </summary>
        /// <param name="key">接続文字列取得キー</param>
        /// <param name="tot">タイムアウト（秒）</param>
        public void Connect(string key, int tot)
        {
            try
            {
                //DBの接続文字列
                string cst = "";
                //初期化
                if (_con == null)
                {
                    _con = new SqlConnection();
                }
                //DBの接続文字列の取得
                cst = configuration.GetConnectionString(key);
                //タイムアウトの設定
                if (tot > -1)
                {
                    cst = cst + ";Connect Timeout=" + tot.ToString();
                }
                _con.ConnectionString = cst;
                //データベースへ接続
                _con.Open();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// ＤＢ切断
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
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// トランザクションの開始
        /// </summary>
        public void BeginTransaction()
        {
            try
            {
                if (_con != null)
                {
                    _trn = _con.BeginTransaction();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// コミットトランザクション
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
            catch
            {
                throw;
            }
            finally
            {
                _trn = null;
            }
        }

        /// <summary>
        /// ロールバックトランザクション
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
            catch
            {
                throw;
            }
            finally
            {
                _trn = null;
            }
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~DBManager()
        {
            Disconnect();
        }

        /// <summary>
        /// クエリの実行（reader）
        /// </summary>
        /// <param name="sqlQuery">クエリ</param>
        /// <param name="paramDict">パラメータ</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader ExecuteQueryReder(string sqlQuery, Dictionary<string, object> paramDict)
        {
            try
            {
                //クエリー送信先、トランザクションの指定
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _con,
                    Transaction = _trn,
                    CommandText = sqlQuery,
                    CommandTimeout = 0
                };
                //パラメータの設定
                foreach (KeyValuePair<string, object> item in paramDict)
                {
                    cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                }
                //ＳＱＬ実行
                return cmd.ExecuteReader();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// クエリの実行（reader）
        /// </summary>
        /// <param name="sqlQuery">クエリ</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader ExecuteQueryReder(string sqlQuery)
        {
            return ExecuteQueryReder(sqlQuery, new Dictionary<string, object>());
        }

        /// <summary>
        /// クエリの実行（reader）（Async）
        /// </summary>
        /// <param name="sqlQuery">クエリ</param>
        /// <param name="paramDict">パラメータ</param>
        /// <returns>SqlDataReader</returns>
        public async ValueTask<SqlDataReader> ExecuteQueryRederAsync(string sqlQuery, Dictionary<string, object> paramDict)
        {
            try
            {
                //クエリー送信先、トランザクションの指定
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _con,
                    Transaction = _trn,
                    CommandText = sqlQuery,
                    CommandTimeout = 0
                };
                //パラメータの設定
                foreach (KeyValuePair<string, object> item in paramDict)
                {
                    cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                }
                //ＳＱＬ実行
                return await cmd.ExecuteReaderAsync();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// クエリの実行（reader）（Async）
        /// </summary>
        /// <param name="sqlQuery">クエリ</param>
        /// <returns>SqlDataReader</returns>
        public async ValueTask<SqlDataReader> ExecuteQueryRederAsync(string sqlQuery)
        {
            return await ExecuteQueryRederAsync(sqlQuery, new Dictionary<string, object>());
        }

        /// <summary>
        /// クエリの実行（DataTable）
        /// </summary>
        /// <param name="sqlQuery">クエリ</param>
        /// <param name="paramDict">パラメータ</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteQueryDataTable(string sqlQuery, Dictionary<string, object> paramDict)
        {
            DataTable dt = new DataTable();

            try
            {
                //クエリー送信先、トランザクションの指定
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _con,
                    Transaction = _trn,
                    CommandText = sqlQuery,
                    CommandTimeout = 0
                };
                //パラメータの設定
                foreach (KeyValuePair<string, object> item in paramDict)
                {
                    cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                }
                //ＳＱＬ実行
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                adapter.Dispose();
                cmd.Dispose();
            }
            catch
            {
                throw;
            }
            //リターン
            return dt;
        }
        /// <summary>
        /// クエリの実行（DataTable）
        /// </summary>
        /// <param name="sqlQuery">クエリ</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteQueryDataTable(string sqlQuery)
        {
            return ExecuteQueryDataTable(sqlQuery, new Dictionary<string, object>());
        }

        /// <summary>
        /// クエリの実行（更新処理）
        /// </summary>
        /// <param name="sqlQuery">クエリ</param>
        /// <param name="paramDict">パラメータ</param>
        public void ExecuteNonQuery(string sqlQuery, Dictionary<string, object> paramDict)
        {
            try
            {
                //クエリー送信先、トランザクションの指定
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _con,
                    Transaction = _trn,
                    CommandText = sqlQuery,
                    CommandTimeout = 0
                };
                //パラメータの設定
                foreach (KeyValuePair<string, object> item in paramDict)
                {
                    cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                }
                //ＳＱＬ実行
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// クエリの実行（更新処理）
        /// </summary>
        /// <param name="sqlQuery">クエリ</param>
        public void ExecuteNonQuery(string sqlQuery)
        {
            ExecuteNonQuery(sqlQuery, new Dictionary<string, object>());
        }

        /// <summary>
        /// クエリの実行（ストアドプロシージャ）
        /// </summary>
        /// <param name="sqlQuery">クエリ</param>
        /// <param name="paramDict">パラメータ</param>
        public void ExecuteNonProcedure(string sqlQuery, Dictionary<string, object> paramDict)
        {
            try
            {
                //クエリー送信先、トランザクションの指定
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _con,
                    Transaction = _trn,
                    CommandText = sqlQuery,
                    CommandTimeout = 0,
                    CommandType = CommandType.StoredProcedure
                };
                //パラメータの設定
                foreach (KeyValuePair<string, object> item in paramDict)
                {
                    cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                }
                //ＳＱＬ実行
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// クエリの実行（ストアドプロシージャ）
        /// </summary>
        /// <param name="sqlQuery">クエリ</param>
        public void ExecuteNonProcedure(string sqlQuery)
        {
            ExecuteNonProcedure(sqlQuery, new Dictionary<string, object>());
        }

        /// <summary>
        /// クエリの実行（ストアドプロシージャ）（reader）
        /// </summary>
        /// <param name="sqlQuery">クエリ</param>
        /// <param name="paramDict">パラメータ</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader ExecuteProcedureReder(string sqlQuery, Dictionary<string, object> paramDict)
        {
            try
            {
                //クエリー送信先、トランザクションの指定
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _con,
                    Transaction = _trn,
                    CommandText = sqlQuery,
                    CommandTimeout = 0,
                    CommandType = CommandType.StoredProcedure
                };
                //パラメータの設定
                foreach (KeyValuePair<string, object> item in paramDict)
                {
                    cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                }
                //ＳＱＬ実行
                return cmd.ExecuteReader();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// クエリの実行（ストアドプロシージャ）（reader）
        /// </summary>
        /// <param name="sqlQuery">クエリ</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader ExecuteProcedureReder(string sqlQuery)
        {
            return ExecuteProcedureReder(sqlQuery, new Dictionary<string, object>());
        }

        /// <summary>
        /// クエリの実行（ストアドプロシージャ）（DataTable）
        /// </summary>
        /// <param name="sqlQuery">クエリ</param>
        /// <param name="paramDict">パラメータ</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteProcedureDataTable(string sqlQuery, Dictionary<string, object> paramDict)
        {
            DataTable dt = new DataTable();

            try
            {
                //クエリー送信先、トランザクションの指定
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _con,
                    Transaction = _trn,
                    CommandText = sqlQuery,
                    CommandTimeout = 0,
                    CommandType = CommandType.StoredProcedure
                };
                //パラメータの設定
                foreach (KeyValuePair<string, object> item in paramDict)
                {
                    cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                }
                //ＳＱＬ実行
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                adapter.Dispose();
                cmd.Dispose();
            }
            catch
            {
                throw;
            }
            return dt;
        }
        /// <summary>
        /// クエリの実行（ストアドプロシージャ）（DataTable）
        /// </summary>
        /// <param name="sqlQuery">クエリ</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteProcedureDataTable(string sqlQuery)
        {
            return ExecuteProcedureDataTable(sqlQuery, new Dictionary<string, object>());
        }



    }
}
