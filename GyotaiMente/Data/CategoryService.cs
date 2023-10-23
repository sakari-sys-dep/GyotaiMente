using GyotaiMente.Class;
using GyotaiMente.Models;
using Microsoft.Data.SqlClient;

namespace GyotaiMente.Data
{
    public interface ICategoryService
    {
        IEnumerable<Big> GetBig();
        IEnumerable<Small> GetSmall(string ID);
        IEnumerable<Kei1> GetKei1(string ID);
        IEnumerable<Kei2> GetKei2(string ID);
        IEnumerable<Kanri> GetKanri();
        IEnumerable<KanriCategory> GetKanriCategories(string ID);
        IEnumerable<Tanto> GetTanto(string ID);
    }

    public class CategoryService : ICategoryService
    {
        public IEnumerable<Big> GetBig()
        {
            List<Big> list = new List<Big>();

            DBManager db = new DBManager();
            db.Connect(Const.CONNECTION_KEY_KOURIDB);
            Dictionary<string, object> paramDict = new Dictionary<string, object>();

            SqlDataReader rdr = db.ExecuteQueryReder(ConstSql.CreateDropDownListBig().ToString(), paramDict);
            while (rdr.Read())
            {
                list.Add(new Big
                {
                    Value = rdr["VALUE"].ToString()!,
                    Text = rdr["TEXT"].ToString()!
                });
            };
            db.Disconnect();
            return list;
        }

        public IEnumerable<Small> GetSmall(string ID)
        {
            List<Small> list = new List<Small>();
            DBManager db = new DBManager();
            db.Connect(Const.CONNECTION_KEY_KOURIDB);
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            SqlDataReader rdr = db.ExecuteQueryReder(ConstSql.CreateDropDownListSmall().ToString(), paramDict);
            while (rdr.Read())
            {
                list.Add(new Small
                {
                    Value = rdr["VALUE"].ToString()!,
                    Text = rdr["TEXT"].ToString()!,
                    SmallValue = rdr["WHEREVALUE"].ToString()!
                });
            };
            if (!string.IsNullOrEmpty(ID))
            {
                return list.Where(s => s.SmallValue == ID);
            }
            else
            {
                return list;
            }
        }

        public IEnumerable<Kei1> GetKei1(string ID)
        {
            List<Kei1> list = new List<Kei1>();
            DBManager db = new DBManager();
            db.Connect(Const.CONNECTION_KEY_KOURIDB);
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            SqlDataReader rdr = db.ExecuteQueryReder(ConstSql.CreateDropDownListKei1().ToString(), paramDict);
            while (rdr.Read())
            {
                list.Add(new Kei1
                {
                    Value = rdr["VALUE"].ToString()!,
                    Text = rdr["TEXT"].ToString()!,
                    Key1Value = rdr["WHEREVALUE"].ToString()!,
                });
            };
            if (!string.IsNullOrEmpty(ID))
            {
                return list.Where(s => s.Key1Value == ID);
            }
            else
            {
                return list;
            }
        }

        public IEnumerable<Kei2> GetKei2(string ID)
        {
            List<Kei2> list = new List<Kei2>();
            DBManager db = new DBManager();
            db.Connect(Const.CONNECTION_KEY_KOURIDB);
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            SqlDataReader rdr = db.ExecuteQueryReder(ConstSql.CreateDropDownListKei2().ToString(), paramDict);
            while (rdr.Read())
            {
                list.Add(new Kei2
                {
                    Value = rdr["VALUE"].ToString()!,
                    Text = rdr["TEXT"].ToString()!,
                    Key2Value = rdr["WHEREVALUE"].ToString()!,
                });
            };
            if (!string.IsNullOrEmpty(ID))
            {
                return list.Where(s => s.Key2Value == ID);
            }
            else
            {
                return list;
            }
        }

        public IEnumerable<Kanri> GetKanri()
        {
            List<Kanri> list = new List<Kanri>();

            DBManager db = new DBManager();
            db.Connect(Const.CONNECTION_KEY_KOURIDB);
            Dictionary<string, object> paramDict = new Dictionary<string, object>();

            SqlDataReader rdr = db.ExecuteQueryReder(ConstSql.CreateSqlDropDownListKanri().ToString(), paramDict);
            while (rdr.Read())
            {
                list.Add(new Kanri
                {
                    Value = rdr["VALUE"].ToString()!,
                    Text = rdr["TEXT"].ToString()!
                });
            };
            db.Disconnect();
            return list;
        }

        public IEnumerable<KanriCategory> GetKanriCategories(string ID)
        {
            List<KanriCategory> list = new List<KanriCategory>();
            DBManager db = new DBManager();
            db.Connect(Const.CONNECTION_KEY_KOURIDB);
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            SqlDataReader rdr = db.ExecuteQueryReder(ConstSql.CreateSqlDropDownListKanriCategory().ToString(), paramDict);
            while (rdr.Read())
            {
                list.Add(new KanriCategory
                {
                    Value = rdr["VALUE"].ToString()!,
                    Text = rdr["TEXT"].ToString()!,
                    KanriCategoryValue = rdr["WHEREVALUE"].ToString()!
                });
            };
            if (!string.IsNullOrEmpty(ID))
            {
                return list.Where(s => s.KanriCategoryValue == ID);
            }
            else
            {
                return list;
            }
        }

        public IEnumerable<Tanto> GetTanto(string ID)
        {
            List<Tanto> list = new List<Tanto>();
            DBManager db = new DBManager();
            db.Connect(Const.CONNECTION_KEY_KOURIDB);
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            SqlDataReader rdr = db.ExecuteQueryReder(ConstSql.CreateSqlDropDownListTanto().ToString(), paramDict);
            while (rdr.Read())
            {
                list.Add(new Tanto
                {
                    Value = rdr["VALUE"].ToString()!,
                    Text = rdr["TEXT"].ToString()!,
                    TantoValue = rdr["WHEREVALUE"].ToString()!
                });
            };
            if (!string.IsNullOrEmpty(ID))
            {
                return list.Where(s => s.TantoValue == ID);
            }
            else
            {
                return list;
            }
        }
    }
}
