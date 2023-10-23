using System.Text;

namespace GyotaiMente.Class
{
    public class ConstSql
    {
        /*
         * 大業態SQL
         */
        public static StringBuilder CreateSqlBig(string queryWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT [ms01d_big_kbn1_cd]");
            sb.AppendLine("      ,[ms01d_big_kbn1_name]");
            sb.AppendLine("  FROM [KOURIDB].[dbo].[ms01d_big]");
            sb.AppendLine("   WHERE 1 = 1 ");
            sb.AppendLine(queryWhere);
            sb.AppendLine("  ORDER BY [ms01d_big_kbn1_cd] ");
            return sb;

        }

        public static StringBuilder RegistSqlBig(string code, string name)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("  IF (SELECT COUNT(*) FROM [KOURIDB].[dbo].[ms01d_big] WHERE [ms01d_big_kbn1_cd] = '" + code + "' AND [ms01d_big_kbn1_name] = '" + name + "') <> 0 ");
            sb.AppendLine("  BEGIN ");
            sb.AppendLine("  INSERT INTO [KOURIDB].[dbo].[ms01d_big] ([ms01d_big_kbn1_cd],[ms01d_big_kbn1_name]) ");
            sb.AppendLine("  VALUES ('" + code + "','" + name + "'); ");
            sb.AppendLine("  END ");
            return sb;

        }

        public static StringBuilder UpdateSqlBig(string code, string newcode, string name)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" BEGIN ");
            sb.AppendLine(" 	UPDATE [KOURIDB].[dbo].[ms01d_big] ");
            sb.AppendLine(" 	 SET [ms01d_big_kbn1_cd] = '" + newcode + "', ");
            sb.AppendLine(" 	[ms01d_big_kbn1_name] = '" + name + "' ");
            sb.AppendLine(" 	 WHERE [ms01d_big_kbn1_cd] = '" + code + "'; ");
            sb.AppendLine(" END ");
            return sb;

        }

        public static StringBuilder DeleteSqlBig(string code)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" DELETE FROM [KOURIDB].[dbo].[ms01d_big] ");
            sb.AppendLine("        WHERE [ms01d_big_kbn1_cd] ='" + code + "'");
            return sb;

        }

        public static StringBuilder ExcelSqlBig(string queryWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT [ms01d_big_kbn1_cd] AS 大業態コード ");
            sb.AppendLine("      ,[ms01d_big_kbn1_name] AS 大業態名 ");
            sb.AppendLine("  FROM [KOURIDB].[dbo].[ms01d_big]");
            sb.AppendLine("   WHERE 1 = 1 ");
            sb.AppendLine(queryWhere);
            sb.AppendLine("  ORDER BY [ms01d_big_kbn1_cd] ");
            return sb;

        }

        /*
　　　　 * 小業態SQL
        */
        public static StringBuilder CreateSqlSmall(string queryWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT [ms01d_small_kbn1_cd] ");
            sb.AppendLine("       ,[ms01d_small_kbn2_cd] ");
            sb.AppendLine("       ,[ms01d_small_kbn2_name] ");
            sb.AppendLine("   FROM [KOURIDB].[dbo].[ms01d_small] ");
            sb.AppendLine("   WHERE 1 = 1 ");
            sb.AppendLine(queryWhere);
            sb.AppendLine("  ORDER BY [ms01d_small_kbn1_cd] ");
            sb.AppendLine("          ,[ms01d_small_kbn2_cd] ");
            return sb;

        }

        public static StringBuilder RegistSqlSmall(string code, string code2, string name)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("  IF (SELECT COUNT(*) FROM [KOURIDB].[dbo].[ms01d_big] WHERE [ms01d_small_kbn1_cd] = '" + code + "' AND [ms01d_small_kbn2_cd] = '" + code2 + "'AND [ms01d_small_kbn2_name] = '" + name + "') <> 0 ");
            sb.AppendLine("  BEGIN ");
            sb.AppendLine("  INSERT INTO [KOURIDB].[dbo].[ms01d_small] ([ms01d_small_kbn1_cd],[ms01d_small_kbn2_cd],[ms01d_small_kbn2_name]) ");
            sb.AppendLine("  VALUES ('" + code + "','" + code2 + "','" + name + "'); ");
            sb.AppendLine("  END ");
            return sb;

        }

        public static StringBuilder UpdateSqlSmall(string code, string code2, string newcode, string newcode2, string newname)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" BEGIN ");
            sb.AppendLine(" 	UPDATE [KOURIDB].[dbo].[ms01d_small] ");
            sb.AppendLine(" 	 SET [ms01d_small_kbn1_cd] = '" + newcode + "', ");
            sb.AppendLine(" 	[ms01d_small_kbn2_cd] = '" + newcode2 + "', ");
            sb.AppendLine(" 	[ms01d_small_kbn2_name] = '" + newname + "' ");
            sb.AppendLine(" 	 WHERE [ms01d_small_kbn1_cd] = '" + code + "' ");
            sb.AppendLine(" 	   AND [ms01d_small_kbn2_cd] = '" + code2 + "'; ");
            sb.AppendLine(" END ");
            return sb;

        }

        public static StringBuilder DeleteSqlSmall(string code, string code2)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" DELETE FROM [KOURIDB].[dbo].[ms01d_small] ");
            sb.AppendLine("        WHERE [ms01d_small_kbn1_cd] ='" + code + "'");
            sb.AppendLine("    AND [ms01d_small_kbn2_cd] ='" + code2 + "'");
            return sb;

        }

        public static StringBuilder ExcelSqlSmall(string queryWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT [ms01d_small_kbn1_cd] AS 大業態コード ");
            sb.AppendLine(" 　　　,[ms01d_big_kbn1_name] AS 大業態名 ");
            sb.AppendLine("       ,[ms01d_small_kbn2_cd] AS 小業態コード");
            sb.AppendLine("       ,[ms01d_small_kbn2_name] AS 小業態名");
            sb.AppendLine("   FROM [KOURIDB].[dbo].[ms01d_small] ");
            sb.AppendLine("   LEFT OUTER JOIN [KOURIDB].[dbo].[ms01d_big] ON [ms01d_small_kbn1_cd] = [ms01d_big_kbn1_cd] ");
            sb.AppendLine("   WHERE 1 = 1 ");
            sb.AppendLine(queryWhere);
            sb.AppendLine("  ORDER BY [ms01d_small_kbn1_cd] ");
            sb.AppendLine("          ,[ms01d_small_kbn2_cd] ");
            return sb;

        }

        /*
　　　　 * 系列１SQL
        */
        public static StringBuilder CreateSqlKei1(string queryWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT [kbn1_cd] ");
            sb.AppendLine("       ,[kbn2_cd] ");
            sb.AppendLine("       ,[kei1_cd] ");
            sb.AppendLine("       ,[kei1_name] ");
            sb.AppendLine("   FROM [KOURIDB].[dbo].[ms02d] ");
            sb.AppendLine("   WHERE 1 = 1 ");
            sb.AppendLine(queryWhere);
            sb.AppendLine("  ORDER BY [kbn1_cd] ");
            sb.AppendLine("       ,[kbn2_cd] ");
            sb.AppendLine("       ,[kei1_cd] ");
            return sb;

        }

        public static StringBuilder RegistSqlKei1(string code, string code2, string code3, string name)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("  IF (SELECT COUNT(*) FROM [KOURIDB].[dbo].[ms01d_big] WHERE [kbn1_cd] = '" + code + "' AND [kbn2_cd] = '" + code2 + "'AND [kei1_cd] = '" + code3 + "' AND [kei1_name] = '" + name + "') <> 0 ");
            sb.AppendLine("  BEGIN ");
            sb.AppendLine("  INSERT INTO [KOURIDB].[dbo].[ms02d] ([kbn1_cd],[kbn2_cd],[kei1_cd],[kei1_name]) ");
            sb.AppendLine("  VALUES ('" + code + "','" + code2 + "','" + code3 + "','" + name + "'); ");
            sb.AppendLine("  END ");
            return sb;

        }

        public static StringBuilder UpdateSqlKei1(string code, string code2, string code3, string newcode, string newcode2, string newcode3, string name)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" BEGIN ");
            sb.AppendLine(" 	UPDATE [KOURIDB].[dbo].[ms02d] ");
            sb.AppendLine(" 	 SET [kbn1_cd] = '" + newcode + "', ");
            sb.AppendLine(" 	[kbn2_cd] = '" + newcode2 + "', ");
            sb.AppendLine(" 	[kei1_cd] = '" + newcode3 + "', ");
            sb.AppendLine(" 	[kei1_name] = '" + name + "' ");
            sb.AppendLine(" 	 WHERE [kbn1_cd] = '" + code + "' ");
            sb.AppendLine(" 	   AND [kbn2_cd] = '" + code2 + "' ");
            sb.AppendLine(" 	   AND [kei1_cd] = '" + code3 + "' ");
            sb.AppendLine(" END ");
            return sb;

        }

        public static StringBuilder DeleteSqlKei1(string code, string code2, string code3)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" DELETE FROM [KOURIDB].[dbo].[ms02d] ");
            sb.AppendLine("        WHERE [kbn1_cd] ='" + code + "'");
            sb.AppendLine("    AND [kbn2_cd] ='" + code2 + "'");
            sb.AppendLine("    AND [kei1_cd] ='" + code3 + "'");
            return sb;

        }

        public static StringBuilder ExcelSqlKei1(string queryWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT [kbn1_cd] AS 大業態コード ");
            sb.AppendLine("       ,[ms01d_big_kbn1_name] AS 大業態名 ");
            sb.AppendLine("       ,[kbn2_cd] AS 小業態コード ");
            sb.AppendLine("       ,[ms01d_small_kbn2_name] AS 小業態名");
            sb.AppendLine("       ,[kei1_cd] AS 系列１コード");
            sb.AppendLine("       ,[kei1_name] AS 系列１名");
            sb.AppendLine("   FROM [KOURIDB].[dbo].[ms02d] ");
            sb.AppendLine("   LEFT OUTER JOIN [KOURIDB].[dbo].[ms01d_big] ON [kbn1_cd] = [ms01d_big_kbn1_cd] ");
            sb.AppendLine("   LEFT OUTER JOIN [KOURIDB].[dbo].[ms01d_small] ON [kbn1_cd] = [ms01d_small_kbn1_cd] AND [kbn2_cd] = [ms01d_small_kbn2_cd] ");
            sb.AppendLine("   WHERE 1 = 1 ");
            sb.AppendLine(queryWhere);
            sb.AppendLine("  ORDER BY [kbn1_cd] ");
            sb.AppendLine("       ,[kbn2_cd] ");
            sb.AppendLine("       ,[kei1_cd] ");
            return sb;

        }

        /*
　　　　 * 系列２SQL
        */
        public static StringBuilder CreateSqlKei2(string queryWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT A.[kbn1_cd] ");
            sb.AppendLine("       ,A.[kbn2_cd] ");
            sb.AppendLine("       ,A.[kei1_cd] ");
            sb.AppendLine("       ,A.[kei2_cd] ");
            sb.AppendLine("       ,A.[kei2_name] ");
            sb.AppendLine("       ,[siten_cd] ");
            sb.AppendLine("       ,[siten_name] ");
            sb.AppendLine("       ,[buka_cd] ");
            sb.AppendLine("       ,[buka_name] ");
            sb.AppendLine("       ,[tanto_cd] ");
            sb.AppendLine("       ,[tanto_name] ");
            //sb.AppendLine("       ,[stop_flag] ");
            //sb.AppendLine("       ,[target_flag] ");
            //sb.AppendLine("       ,[chain_flag] ");
            //sb.AppendLine("       ,[chain_cd] ");
            //sb.AppendLine("       ,[cgc] ");
            //sb.AppendLine("       ,[ajs] ");
            //sb.AppendLine("       ,[nichiryu] ");
            //sb.AppendLine("       ,[hachishakai] ");
            //sb.AppendLine("       ,[coop] ");
            //sb.AppendLine("       ,[zennisyoku] ");
            //sb.AppendLine("       ,[lalss_cd] ");
            //sb.AppendLine("       ,[manage_flag] ");
            //sb.AppendLine("       ,[eep_cd] ");
            //sb.AppendLine("       ,[rsrv1_cd] ");
            //sb.AppendLine("       ,[rsrv2_cd] ");
            //sb.AppendLine("       ,[rsrv3_cd] ");
            //sb.AppendLine("       ,[rsrv4_cd] ");
            //sb.AppendLine("       ,[rsrv5_cd] ");
            sb.AppendLine("   FROM [KOURIDB].[dbo].[ms03d] A ");
            sb.AppendLine("   WHERE 1 = 1 ");
            sb.AppendLine(queryWhere);
            sb.AppendLine("  ORDER BY [kbn1_cd] ");
            sb.AppendLine("       ,[kbn2_cd] ");
            sb.AppendLine("       ,[kei1_cd] ");
            sb.AppendLine("       ,[kei2_cd] ");
            return sb;

        }

        public static StringBuilder RegistSqlKei2(string code, string code2, string code3, string code4, string name)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("  IF (SELECT COUNT(*) FROM [KOURIDB].[dbo].[ms01d_big] WHERE [kbn1_cd] = '" + code + "' AND [kbn2_cd] = '" + code2 + "'AND [kei1_cd] = '" + code3 + "' AND [kei2_cd] = '" + code4 + "' AND [kei2_name] = '" + name + "') <> 0 ");
            sb.AppendLine("  BEGIN ");
            sb.AppendLine("  INSERT INTO [KOURIDB].[dbo].[ms03d] ([kbn1_cd],[kbn2_cd],[kei1_cd],[kei2_cd],[kei2_name]) ");
            sb.AppendLine("  VALUES ('" + code + "','" + code2 + "','" + code3 + "','" + code4 + "','" + name + "'); ");
            sb.AppendLine("  END ");
            return sb;

        }

        public static StringBuilder UpdateSqlKei2(string code, string code2, string code3, string code4, string newcode, string newcode2, string newcode3, string newcode4, string name)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" BEGIN ");
            sb.AppendLine(" 	UPDATE [KOURIDB].[dbo].[ms03d] ");
            sb.AppendLine(" 	 SET [kbn1_cd] = '" + newcode + "', ");
            sb.AppendLine(" 	     [kbn2_cd] = '" + newcode2 + "', ");
            sb.AppendLine(" 	     [kei1_cd] = '" + newcode3 + "', ");
            sb.AppendLine(" 	     [kei2_cd] = '" + newcode4 + "', ");
            sb.AppendLine(" 	     [kei2_name] = '" + name + "' ");
            sb.AppendLine(" 	 WHERE [kbn1_cd] = '" + code + "' ");
            sb.AppendLine(" 	   AND [kbn2_cd] = '" + code2 + "' ");
            sb.AppendLine(" 	   AND [kei1_cd] = '" + code3 + "' ");
            sb.AppendLine(" 	   AND [kei2_cd] = '" + code4 + "' ");
            sb.AppendLine(" END ");
            return sb;

        }

        public static StringBuilder DeleteSqlKei2(string code, string code2, string code3, string code4)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" DELETE FROM [KOURIDB].[dbo].[ms03d] ");
            sb.AppendLine("        WHERE [kbn1_cd] ='" + code + "'");
            sb.AppendLine("    AND [kbn2_cd] ='" + code2 + "'");
            sb.AppendLine("    AND [kei1_cd] ='" + code3 + "'");
            sb.AppendLine("    AND [kei2_cd] ='" + code4 + "'");
            return sb;

        }

        public static StringBuilder ExcelSqlKei2(string queryWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT A.[kbn1_cd] AS 大業態コード ");
            sb.AppendLine("       ,[ms01d_big_kbn1_name] AS 大業態名 ");
            sb.AppendLine("       ,A.[kbn2_cd] AS 小業態コード ");
            sb.AppendLine("       ,[ms01d_small_kbn2_name] AS 小業態名");
            sb.AppendLine("       ,A.[kei1_cd] AS 系列１コード ");
            sb.AppendLine("       ,B.[kei1_name] AS 系列１名");
            sb.AppendLine("       ,A.[kei2_cd] AS 系列２コード");
            sb.AppendLine("       ,A.[kei2_name] AS 系列２名");
            sb.AppendLine("       ,[siten_cd] AS 支店コード");
            sb.AppendLine("       ,[siten_name] AS 支店名");
            sb.AppendLine("       ,[buka_cd] AS 部課コード");
            sb.AppendLine("       ,[buka_name] AS 部課名");
            sb.AppendLine("       ,[tanto_cd] AS 担当者コード");
            sb.AppendLine("       ,[tanto_name] AS 担当者名");
            //sb.AppendLine("       ,[stop_flag] ");
            //sb.AppendLine("       ,[target_flag] ");
            //sb.AppendLine("       ,[chain_flag] ");
            //sb.AppendLine("       ,[chain_cd] ");
            //sb.AppendLine("       ,[cgc] ");
            //sb.AppendLine("       ,[ajs] ");
            //sb.AppendLine("       ,[nichiryu] ");
            //sb.AppendLine("       ,[hachishakai] ");
            //sb.AppendLine("       ,[coop] ");
            //sb.AppendLine("       ,[zennisyoku] ");
            //sb.AppendLine("       ,[lalss_cd] ");
            //sb.AppendLine("       ,[manage_flag] ");
            //sb.AppendLine("       ,[eep_cd] ");
            //sb.AppendLine("       ,[rsrv1_cd] ");
            //sb.AppendLine("       ,[rsrv2_cd] ");
            //sb.AppendLine("       ,[rsrv3_cd] ");
            //sb.AppendLine("       ,[rsrv4_cd] ");
            //sb.AppendLine("       ,[rsrv5_cd] ");
            sb.AppendLine("   FROM [KOURIDB].[dbo].[ms03d] A ");
            sb.AppendLine("   LEFT OUTER JOIN [KOURIDB].[dbo].[ms01d_big] ON A.[kbn1_cd] = [ms01d_big_kbn1_cd] ");
            sb.AppendLine("   LEFT OUTER JOIN [KOURIDB].[dbo].[ms01d_small] ON A.[kbn1_cd] = [ms01d_small_kbn1_cd] AND A.[kbn2_cd] = [ms01d_small_kbn2_cd] ");
            sb.AppendLine("   LEFT OUTER JOIN [KOURIDB].[dbo].[ms02d] B ON A.[kbn1_cd] = B.[kbn1_cd] AND  A.[kbn2_cd] = B.[kbn2_cd] AND  A.[kei1_cd] = B.[kei1_cd]");
            sb.AppendLine("   WHERE 1 = 1 ");
            sb.AppendLine(queryWhere);
            sb.AppendLine("  ORDER BY A.[kbn1_cd] ");
            sb.AppendLine("       ,A.[kbn2_cd] ");
            sb.AppendLine("       ,A.[kei1_cd] ");
            sb.AppendLine("       ,A.[kei2_cd] ");
            return sb;

        }

        /*
　　　　 * 店コードSQL
        */
        public static StringBuilder CreateSqlTen(string queryWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT A.[kbn1_cd] ");
            sb.AppendLine("       ,A.[kbn2_cd] ");
            sb.AppendLine("       ,A.[kei1_cd] ");
            sb.AppendLine("       ,A.[kei2_cd] ");
            sb.AppendLine("       ,A.[ten_cd] ");
            sb.AppendLine("       ,B.[km01d_yagou_k] ");
            sb.AppendLine("   FROM [KOURIDB].[dbo].[ms04d] A ");
            sb.AppendLine("   LEFT OUTER JOIN [DBRET].[dbo].[km01d] B ON FORMAT(CONVERT(numeric,A.[ten_cd]),'00000000') = B.km01d_tor_cd ");
            sb.AppendLine("   WHERE 1 = 1 ");
            sb.AppendLine(queryWhere);
            sb.AppendLine("  ORDER BY A.[kbn1_cd] ");
            sb.AppendLine("       ,A.[kbn2_cd] ");
            sb.AppendLine("       ,A.[kei1_cd] ");
            sb.AppendLine("       ,A.[kei2_cd] ");
            return sb;

        }

        public static StringBuilder UpdateSqlTen(string code, string code2, string code3, string code4, string ten_cd, string newcode, string newcode2, string newcode3, string newcode4)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" BEGIN ");
            sb.AppendLine(" 	UPDATE [KOURIDB].[dbo].[ms04d] ");
            sb.AppendLine(" 	 SET [kbn1_cd] = '" + newcode + "', ");
            sb.AppendLine(" 	     [kbn2_cd] = '" + newcode2 + "', ");
            sb.AppendLine(" 	     [kei1_cd] = '" + newcode3 + "', ");
            sb.AppendLine(" 	     [kei2_cd] = '" + newcode4 + "' ");
            sb.AppendLine(" 	 WHERE [kbn1_cd] = '" + code + "' ");
            sb.AppendLine(" 	   AND [kbn2_cd] = '" + code2 + "' ");
            sb.AppendLine(" 	   AND [kei1_cd] = '" + code3 + "' ");
            sb.AppendLine(" 	   AND [kei2_cd] = '" + code4 + "' ");
            sb.AppendLine(" 	   AND [ten_cd] = '" + ten_cd + "' ");
            sb.AppendLine(" END ");
            return sb;

        }

        //public static StringBuilder DeleteSqlTen(string code, string code2, string code3, string code4, string code5)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine(" DELETE FROM [KOURIDB].[dbo].[ms04d] ");
        //    sb.AppendLine("        WHERE [kbn1_cd] ='" + code + "'");
        //    sb.AppendLine("    AND [kbn2_cd] ='" + code2 + "'");
        //    sb.AppendLine("    AND [kei1_cd] ='" + code3 + "'");
        //    sb.AppendLine("    AND [kei2_cd] ='" + code4 + "'");
        //    sb.AppendLine("    AND [ten_cd] ='" + code5 + "'");
        //    return sb;

        //}

        public static StringBuilder ExcelSqlTen(string queryWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT A.[kbn1_cd]　AS 大業態コード ");
            sb.AppendLine("       ,[ms01d_big_kbn1_name] AS 大業態名 ");
            sb.AppendLine("       ,A.[kbn2_cd]　AS 小業態コード ");
            sb.AppendLine("       ,[ms01d_small_kbn2_name] AS 小業態名 ");
            sb.AppendLine("       ,A.[kei1_cd] 　AS 系列１コード ");
            sb.AppendLine("       ,C.[kei1_name] AS 系列１名 ");
            sb.AppendLine("       ,A.[kei2_cd] 　AS 系列２コード ");
            sb.AppendLine("       ,D.[kei2_name] AS 系列２名 ");
            sb.AppendLine("       ,A.[ten_cd] 　AS 店コード ");
            sb.AppendLine("       ,B.[km01d_yagou_k] AS 店名");
            sb.AppendLine("   FROM [KOURIDB].[dbo].[ms04d] A ");
            sb.AppendLine("   LEFT OUTER JOIN [DBRET].[dbo].[km01d] B ON A.ten_cd = B.km01d_tor_cd ");
            sb.AppendLine("   LEFT OUTER JOIN [KOURIDB].[dbo].[ms01d_big] ON A.[kbn1_cd] = [ms01d_big_kbn1_cd] ");
            sb.AppendLine("   LEFT OUTER JOIN [KOURIDB].[dbo].[ms01d_small] ON A.[kbn1_cd] = [ms01d_small_kbn1_cd] AND A.[kbn2_cd] = [ms01d_small_kbn2_cd] ");
            sb.AppendLine("   LEFT OUTER JOIN [KOURIDB].[dbo].[ms02d] C ON A.[kbn1_cd] = C.[kbn1_cd] AND  A.[kbn2_cd] = C.[kbn2_cd] AND  A.[kei1_cd] = C.[kei1_cd] ");
            sb.AppendLine("   LEFT OUTER JOIN [KOURIDB].[dbo].[ms03d] D ON A.[kbn1_cd] = D.[kbn1_cd] AND  A.[kbn2_cd] = D.[kbn2_cd] AND  A.[kei1_cd] = D.[kei1_cd] AND  A.[kei2_cd] = D.[kei2_cd] ");
            sb.AppendLine("   WHERE 1 = 1 ");
            sb.AppendLine(queryWhere);
            sb.AppendLine("  ORDER BY A.[kbn1_cd] ");
            sb.AppendLine("       ,A.[kbn2_cd] ");
            sb.AppendLine("       ,A.[kei1_cd] ");
            sb.AppendLine("       ,A.[kei2_cd] ");
            return sb;

        }

        public static StringBuilder UpdateSqlTanto(string kbn1_cd, string kbn2_cd, string kei1_cd, string kei2_cd, string sitencd, string sitennm, string bukacd, string bukanm, string tantocd, string tantonm)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" BEGIN ");
            sb.AppendLine(" 	UPDATE [KOURIDB].[dbo].[ms03d] ");
            sb.AppendLine(" 	 SET [siten_cd] = '" + sitencd + "', ");
            sb.AppendLine(" 	     [siten_name] = '" + sitennm + "', ");
            sb.AppendLine(" 	     [buka_cd] = '" + bukacd + "', ");
            sb.AppendLine(" 	     [buka_name] = '" + bukanm + "', ");
            sb.AppendLine(" 	     [tanto_cd] = '" + tantocd + "', ");
            sb.AppendLine(" 	     [tanto_name] = '" + tantonm + "' ");
            sb.AppendLine(" 	 WHERE [kbn1_cd] = '" + kbn1_cd + "' ");
            sb.AppendLine(" 	   AND [kbn2_cd] = '" + kbn2_cd + "' ");
            sb.AppendLine(" 	   AND [kei1_cd] = '" + kei1_cd + "' ");
            sb.AppendLine(" 	   AND [kei2_cd] = '" + kei2_cd + "' ");
            sb.AppendLine(" END ");
            return sb;

        }

        public static StringBuilder CreateSqlDropDownListKanri()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT TBL1.siten_cd     AS VALUE ");
            sb.AppendLine("       ,TBL1.siten_cd  +'：'+ TBL1.siten_name  AS TEXT ");
            sb.AppendLine(" FROM [KOURIDB].[dbo].[ms03d] TBL1 ");
            sb.AppendLine(" INNER JOIN ( SELECT tanto_cd ");
            sb.AppendLine("                  ,SUBSTRING(MIN(tanto_cd),1,2) AS siten_cd ");
            sb.AppendLine("                  ,SUBSTRING(MIN(tanto_cd),1,4) AS buka_cd ");
            sb.AppendLine("            FROM [KOURIDB].[dbo].[ms03d] ");
            sb.AppendLine("            GROUP BY tanto_cd ) TBL0 ");
            sb.AppendLine("  ON TBL1.tanto_cd = TBL0.tanto_cd ");
            sb.AppendLine(" AND TBL1.siten_cd = TBL0.siten_cd ");
            sb.AppendLine(" AND TBL1.buka_cd  = TBL0.buka_cd GROUP BY TBL1.siten_cd,TBL1.siten_name ");
            sb.AppendLine(" ORDER BY 1,2 ");
            return sb;
        }

        public static StringBuilder CreateSqlDropDownListKanriCategory()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT  TBL1.buka_cd                      AS VALUE ");
            sb.AppendLine("        ,TBL1.buka_cd   +'：'+ TBL1.buka_name AS TEXT  ");
            sb.AppendLine("       ,TBL1.siten_cd              AS WHEREVALUE ");
            sb.AppendLine("FROM [KOURIDB].[dbo].[ms03d] TBL1 ");
            sb.AppendLine("INNER JOIN ( SELECT tanto_cd ");
            sb.AppendLine("                  ,SUBSTRING(MIN(tanto_cd),1,2) AS siten_cd");
            sb.AppendLine("                  ,SUBSTRING(MIN(tanto_cd),1,4) AS buka_cd         ");
            sb.AppendLine("            FROM [KOURIDB].[dbo].[ms03d] ");
            sb.AppendLine("            GROUP BY tanto_cd ) TBL0 ");
            sb.AppendLine("  ON TBL1.tanto_cd = TBL0.tanto_cd");
            sb.AppendLine(" AND TBL1.siten_cd = TBL0.siten_cd");
            sb.AppendLine(" AND TBL1.buka_cd  = TBL0.buka_cd GROUP BY TBL1.buka_cd,TBL1.buka_name,TBL1.siten_cd");
            sb.AppendLine(" ORDER BY 1,2,3");
            return sb;
        }

        public static StringBuilder CreateSqlDropDownListTanto()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT  TBL1.tanto_cd                      AS VALUE ");
            sb.AppendLine("        ,TBL1.tanto_cd   +'：'+ TBL1.tanto_name AS TEXT  ");
            sb.AppendLine("       ,TBL1.buka_cd              AS WHEREVALUE ");
            sb.AppendLine("FROM [KOURIDB].[dbo].[ms03d] TBL1 ");
            sb.AppendLine("INNER JOIN ( SELECT tanto_cd ");
            sb.AppendLine("                  ,SUBSTRING(MIN(tanto_cd),1,2) AS siten_cd");
            sb.AppendLine("                  ,SUBSTRING(MIN(tanto_cd),1,4) AS buka_cd         ");
            sb.AppendLine("            FROM [KOURIDB].[dbo].[ms03d] ");
            sb.AppendLine("            GROUP BY tanto_cd ) TBL0 ");
            sb.AppendLine("  ON TBL1.tanto_cd = TBL0.tanto_cd");
            sb.AppendLine(" AND TBL1.siten_cd = TBL0.siten_cd");
            sb.AppendLine(" AND TBL1.buka_cd  = TBL0.buka_cd GROUP BY TBL1.tanto_cd,TBL1.tanto_name,TBL1.buka_cd");
            sb.AppendLine(" ORDER BY 1,2,3");
            return sb;
        }

        /*
        * 大業態ドロップダウンリストSQL
         */
        public static StringBuilder CreateDropDownListBig()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT [ms01d_big_kbn1_cd] AS VALUE");
            sb.AppendLine("      ,[ms01d_big_kbn1_cd]   +'：'+ [ms01d_big_kbn1_name] AS TEXT  ");
            sb.AppendLine("  FROM [KOURIDB].[dbo].[ms01d_big]");
            sb.AppendLine("  ORDER BY [ms01d_big_kbn1_cd] ");
            return sb;

        }

        public static StringBuilder CreateDropDownListSmall()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT  [ms01d_small_kbn2_cd]                      AS VALUE ");
            sb.AppendLine("        ,[ms01d_small_kbn2_cd]   +'：'+ [ms01d_small_kbn2_name] AS TEXT  ");
            sb.AppendLine("       ,[ms01d_small_kbn1_cd]              AS WHEREVALUE ");
            sb.AppendLine("   FROM [KOURIDB].[dbo].[ms01d_small] ");
            sb.AppendLine("  ORDER BY [ms01d_small_kbn1_cd] ");
            sb.AppendLine("          ,[ms01d_small_kbn2_cd] ");
            return sb;

        }

        public static StringBuilder CreateDropDownListKei1()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT  [kei1_cd]                      AS VALUE ");
            sb.AppendLine("        ,[kei1_cd]   +'：'+ [kei1_name] AS TEXT  ");
            sb.AppendLine("        ,[kbn1_cd] + [kbn2_cd]          AS WHEREVALUE ");
            sb.AppendLine("   FROM [KOURIDB].[dbo].[ms02d] ");
            sb.AppendLine("  ORDER BY [kbn1_cd] ");
            sb.AppendLine("       ,[kbn2_cd] ");
            sb.AppendLine("       ,[kei1_cd] ");
            return sb;

        }

        public static StringBuilder CreateDropDownListKei2()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT  [kei2_cd]                      AS VALUE ");
            sb.AppendLine("        ,[kei2_cd]   +'：'+ [kei2_name] AS TEXT  ");
            sb.AppendLine("        ,[kbn1_cd] + [kbn2_cd] + [kei1_cd]          AS WHEREVALUE ");
            sb.AppendLine("   FROM [KOURIDB].[dbo].[ms03d] ");
            sb.AppendLine("  ORDER BY [kbn1_cd] ");
            sb.AppendLine("       ,[kbn2_cd] ");
            sb.AppendLine("       ,[kei1_cd] ");
            sb.AppendLine("       ,[kei2_cd] ");
            return sb;

        }
    }
}
