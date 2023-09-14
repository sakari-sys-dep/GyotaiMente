 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;


namespace Kouri_Form.Class
{
    public class constSql
    {
        //public StringBuilder sb = new StringBuilder();


        public const string DB_ITEM_LAYOUT_KBN = "@LAYOUT_KBN";
        public const string DB_ITEM_SCREEN_NO = "@SCREEN_NO";
        public static StringBuilder CreateSqlSelectMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT [menu_id] ");
            sb.AppendLine("      ,[menu_screen_no] ");
            sb.AppendLine("      ,[menu_layout_kbn] ");
            sb.AppendLine("      ,[menu_no] ");
            sb.AppendLine("      ,[menu_pg_id] ");
            sb.AppendLine("      ,[menu_text] ");
            sb.AppendLine("      ,[menu_address] ");
            sb.AppendLine("      ,[menu_display_seq] ");
            sb.AppendLine("      ,[menu_run_proc_name] ");
            sb.AppendLine("      ,[menu_stop_flg] ");
            sb.AppendLine("      ,[menu_create_datetime] ");
            sb.AppendLine("      ,[menu_create_user_id] ");
            sb.AppendLine("      ,[menu_update_datetime] ");
            sb.AppendLine("      ,[menu_update_user_id] ");
            sb.AppendLine("  FROM [dbo].[mst_kouri_menu] ");
            sb.AppendLine(" WHERE [menu_stop_flg] = 0 ");
            sb.AppendLine("   AND [menu_screen_no]  = @SCREEN_NO ");
            sb.AppendLine("   AND [menu_layout_kbn] = @LAYOUT_KBN ");
            sb.AppendLine(" ORDER BY [menu_display_seq], [menu_no], [menu_id] ");
            return sb;
        }

        public const string DB_ITEM_MENU_PG_ID = "@MENU_PG_ID";
        public static StringBuilder CreateSqlSelectRunProc()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT TOP 1 [menu_id] ");
            sb.AppendLine("      ,[menu_screen_no] ");
            sb.AppendLine("      ,[menu_layout_kbn] ");
            sb.AppendLine("      ,[menu_no] ");
            sb.AppendLine("      ,[menu_pg_id] ");
            sb.AppendLine("      ,[menu_text] ");
            sb.AppendLine("      ,[menu_address] ");
            sb.AppendLine("      ,[menu_display_seq] ");
            sb.AppendLine("      ,[menu_run_proc_name] ");
            sb.AppendLine("      ,[menu_stop_flg] ");
            sb.AppendLine("      ,[menu_create_datetime] ");
            sb.AppendLine("      ,[menu_create_user_id] ");
            sb.AppendLine("      ,[menu_update_datetime] ");
            sb.AppendLine("      ,[menu_update_user_id] ");
            sb.AppendLine("  FROM [dbo].[mst_kouri_menu] ");
            sb.AppendLine(" WHERE [menu_stop_flg] = 0 ");
            sb.AppendLine("   AND [menu_pg_id]  = @MENU_PG_ID ");
            sb.AppendLine(" ORDER BY [menu_display_seq], [menu_no], [menu_id] ");
            return sb;
        }


        public const string SETTING_PG_ID = "@SETTING_PG_ID";
        public static StringBuilder CreateSqlSelectSettingValue()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT [kouri_setting_pg_id] ");
            sb.AppendLine("       ,[kouri_setting_item_name] ");
            sb.AppendLine("       ,[kouri_setting_item_object] ");
            sb.AppendLine("       ,[kouri_setting_visible] ");
            sb.AppendLine("       ,[kouri_setting_initial_value] ");
            sb.AppendLine("       ,[kouri_setting_focus] ");
            sb.AppendLine("       ,[kouri_setting_remarks] ");
            sb.AppendLine("   FROM [dbo].[mst_kouri_setting] ");
            sb.AppendLine("  WHERE [kouri_setting_pg_id] = @SETTING_PG_ID ");
            return sb;
        }

        public const string RUN_PROC_NAME = "@RUN_PROC_NAME";
        public static StringBuilder CreateSqlSelectProcParamValue()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT [proc_param_run_proc_name] ");
            sb.AppendLine("       ,[proc_param_name] ");
            sb.AppendLine("       ,[proc_param_value] ");
            sb.AppendLine("       ,[proc_param_value_get_location] ");
            sb.AppendLine("   FROM [dbo].[mst_kouri_proc_param] ");
            sb.AppendLine("  WHERE [proc_param_run_proc_name] = @RUN_PROC_NAME ");
            return sb;
        }

        public const string KM04D_TEN_CD = "@KM04D_TEN_CD";
        public const string KM04D_MAINT = "@KM04D_MAINT";
        public const string KM04D_BR_NAME_A = "@KM04D_BR_NAME_A";
        public const string KM04D_BR_NAME_K = "@KM04D_BR_NAME_K";
        public const string KM04D_NAME_A = "@KM04D_NAME_A";
        public const string KM04D_NAME_K = "@KM04D_NAME_K";
        public const string KM04D_OROSI_CD = "@KM04D_OROSI_CD";
        public const string KM04D_PRI_KBN = "@KM04D_PRI_KBN";
        public static StringBuilder CreateSqlSelectKM04D()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT [km04d_ten_cd] ");
            sb.AppendLine("       ,[km04d_maint] ");
            sb.AppendLine("       ,[km04d_br_name_a] ");
            sb.AppendLine("       ,[km04d_br_name_k] ");
            sb.AppendLine("       ,[km04d_name_a] ");
            sb.AppendLine("       ,[km04d_name_k] ");
            sb.AppendLine("       ,LEFT([km04d_orosi_cd], 3) AS[km04d_orosi_cd] ");
            sb.AppendLine("       ,RIGHT([km04d_orosi_cd], 2) AS[km04d_orosi_eda] ");
            sb.AppendLine("       ,[km04d_pri_kbn] ");
            sb.AppendLine("   FROM [DBRET].[dbo].[km04d] ");
            sb.AppendLine("  WHERE [km04d_ten_cd] = @KM04D_TEN_CD ");
            return sb;
        }

        public static StringBuilder CreateSqlUpdateKM04D()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" MERGE [dbo].[km04d] KM04D ");
            sb.AppendLine(" USING ( ");
            sb.AppendLine("         SELECT ");
            sb.AppendLine("              @KM04D_TEN_CD    AS km04d_ten_cd ");
            sb.AppendLine("             ,@KM04D_MAINT     AS km04d_maint ");
            sb.AppendLine("             ,@KM04D_BR_NAME_A AS km04d_br_name_a ");
            sb.AppendLine("             ,@KM04D_BR_NAME_K AS km04d_br_name_k ");
            sb.AppendLine("             ,@KM04D_NAME_A    AS km04d_name_a ");
            sb.AppendLine("             ,@KM04D_NAME_K    AS km04d_name_k ");
            sb.AppendLine("             ,@KM04D_OROSI_CD  AS km04d_orosi_cd ");
            sb.AppendLine("             ,@KM04D_PRI_KBN   AS km04d_pri_kbn ");
            sb.AppendLine("       ) UPD ");
            sb.AppendLine("    ON KM04D.km04d_ten_cd = UPD.km04d_ten_cd ");
            sb.AppendLine(" WHEN MATCHED THEN ");
            sb.AppendLine("     UPDATE SET ");
            sb.AppendLine("          KM04D.km04d_maint = UPD.km04d_maint ");
            sb.AppendLine("         ,KM04D.km04d_br_name_a = UPD.km04d_br_name_a ");
            sb.AppendLine("         ,KM04D.km04d_br_name_k = UPD.km04d_br_name_k ");
            sb.AppendLine("         ,KM04D.km04d_name_a = UPD.km04d_name_a ");
            sb.AppendLine("         ,KM04D.km04d_name_k = UPD.km04d_name_k ");
            sb.AppendLine("         ,KM04D.km04d_orosi_cd = UPD.km04d_orosi_cd ");
            sb.AppendLine("         ,KM04D.km04d_pri_kbn = UPD.km04d_pri_kbn ");
            sb.AppendLine(" WHEN NOT MATCHED THEN ");
            sb.AppendLine("     INSERT ");
            sb.AppendLine("     ( ");
            sb.AppendLine("          [km04d_ten_cd] ");
            sb.AppendLine("         ,[km04d_maint] ");
            sb.AppendLine("         ,[km04d_br_name_a] ");
            sb.AppendLine("         ,[km04d_br_name_k] ");
            sb.AppendLine("         ,[km04d_name_a] ");
            sb.AppendLine("         ,[km04d_name_k] ");
            sb.AppendLine("         ,[km04d_orosi_cd] ");
            sb.AppendLine("         ,[km04d_pri_kbn] ");
            sb.AppendLine("     ) ");
            sb.AppendLine("     VALUES ");
            sb.AppendLine("     ( ");
            sb.AppendLine("          UPD.km04d_ten_cd ");
            sb.AppendLine("         ,'A' ");
            sb.AppendLine("         ,UPD.km04d_br_name_a ");
            sb.AppendLine("         ,UPD.km04d_br_name_k ");
            sb.AppendLine("         ,UPD.km04d_name_a ");
            sb.AppendLine("         ,UPD.km04d_name_k ");
            sb.AppendLine("         ,UPD.km04d_orosi_cd ");
            sb.AppendLine("         ,UPD.km04d_pri_kbn ");
            sb.AppendLine("     ); ");
            return sb;
        }

        public static StringBuilder CreateSqlDeleteKM04D()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" UPDATE [dbo].[km04d] ");
            sb.AppendLine("    SET [km04d_maint] = 'D' ");
            sb.AppendLine("  WHERE [km04d_ten_cd] = @KM04D_TEN_CD ");
            return sb;
        }


        public static StringBuilder CreateSqlSelectSamFile()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT TOP 1 ");
            sb.AppendLine("        [convert_value] ");
            sb.AppendLine("   FROM [DBRET].[dbo].[mst_conversion_for_kouri] ");
            sb.AppendLine("  WHERE [definition_cd] = 15010 ");
            sb.AppendLine("    AND [key_item_01] = 'SAM_FILE' ");
            return sb;
        }
        public static StringBuilder CreateSqlSelectSamProc()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT TOP 1 ");
            sb.AppendLine("        [convert_value] ");
            sb.AppendLine("   FROM [DBRET].[dbo].[mst_conversion_for_kouri] ");
            sb.AppendLine("  WHERE [definition_cd] = 15010 ");
            sb.AppendLine("    AND [key_item_01] = 'SAM_PROC' ");
            return sb;
        }

        public static StringBuilder CreateSqlSelectManualFile()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT TOP 1 ");
            sb.AppendLine("        [convert_value] ");
            sb.AppendLine("   FROM [DBRET].[dbo].[mst_conversion_for_kouri] ");
            sb.AppendLine("  WHERE [definition_cd] = 15010 ");
            sb.AppendLine("    AND [key_item_01] = 'IMPORT_FILE' ");
            return sb;
        }

        public static StringBuilder CreateSqlSelectManualTorikomiProc()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT TOP 1 ");
            sb.AppendLine("        [convert_value] ");
            sb.AppendLine("   FROM [DBRET].[dbo].[mst_conversion_for_kouri] ");
            sb.AppendLine("  WHERE [definition_cd] = 15010 ");
            sb.AppendLine("    AND [key_item_01] = 'TORIKOMI_PROC' ");
            return sb;
        }
        public static StringBuilder CreateSqlSelectManualUpdateProc()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT TOP 1 ");
            sb.AppendLine("        [convert_value] ");
            sb.AppendLine("   FROM [DBRET].[dbo].[mst_conversion_for_kouri] ");
            sb.AppendLine("  WHERE [definition_cd] = 15010 ");
            sb.AppendLine("    AND [key_item_01] = 'UPDATE_PROC' ");
            return sb;
        }
        public static StringBuilder CreateSqlSelectManualTorikomiCheck()
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine(" SELECT [INP_DATE]  AS INP_DATE ");
            //sb.AppendLine("       ,[INP_OROSI] AS INP_OROSI ");
            //sb.AppendLine("       ,KM04D.[km04d_name_k] AS km04d_name_k ");
            //sb.AppendLine("       ,COUNT(*)    AS REC_COUNT ");
            //sb.AppendLine("   FROM [Kouridb].[dbo].[KM08D_EXCEL] XLS ");
            //sb.AppendLine("     LEFT OUTER JOIN (SELECT [km04d_orosi_cd], MAX([km04d_name_k]) AS km04d_name_k ");
            //sb.AppendLine("                        FROM [dbret].[dbo].[km04d] ");
            //sb.AppendLine("                       GROUP BY [km04d_orosi_cd] ");
            //sb.AppendLine("                      ) KM04D ");
            //sb.AppendLine("       ON XLS.INP_OROSI = KM04D.km04d_orosi_cd ");
            //sb.AppendLine("  GROUP BY [INP_DATE] ");
            //sb.AppendLine("          ,[INP_OROSI] ");
            //sb.AppendLine("          ,KM04D.[km04d_name_k] ");
            sb.AppendLine(" SELECT [date]  AS INP_DATE ");
            sb.AppendLine("       ,[orosi] AS INP_OROSI ");
            sb.AppendLine("       ,KM04D.[km04d_name_k] AS km04d_name_k ");
            sb.AppendLine("       ,COUNT(*)    AS REC_COUNT ");
            sb.AppendLine("   FROM [DBRET].[dbo].[trn_toban] XLS ");
            sb.AppendLine("     LEFT OUTER JOIN (SELECT [km04d_orosi_cd], MAX([km04d_name_k]) AS km04d_name_k ");
            sb.AppendLine("                        FROM [dbret].[dbo].[km04d] ");
            sb.AppendLine("                       GROUP BY [km04d_orosi_cd] ");
            sb.AppendLine("                      ) KM04D ");
            sb.AppendLine("       ON XLS.[orosi] = KM04D.km04d_orosi_cd ");
            sb.AppendLine("  GROUP BY [date] ");
            sb.AppendLine("          ,[orosi] ");
            sb.AppendLine("          ,KM04D.[km04d_name_k] ");
            return sb;
        }

        public static StringBuilder CreateSqlSelectUpdateKM08DProc()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT TOP 1 ");
            sb.AppendLine("        [convert_value] ");
            sb.AppendLine("   FROM [DBRET].[dbo].[mst_conversion_for_kouri] ");
            sb.AppendLine("  WHERE [definition_cd] = 15020 ");
            sb.AppendLine("    AND [key_item_01]   = 'UPDATE_KM08D' ");
            return sb;
        }
        public static StringBuilder CreateSqlSelectKouriCnvFile()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT TOP 1 ");
            sb.AppendLine("        [convert_value] ");
            sb.AppendLine("   FROM [DBRET].[dbo].[mst_conversion_for_kouri] ");
            sb.AppendLine("  WHERE [definition_cd] = 15030 ");
            sb.AppendLine("    AND [key_item_01] = 'KOURI_CNV_FILE' ");
            return sb;
        }
        public static StringBuilder CreateSqlSelectKouriCnvProc()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT TOP 1 ");
            sb.AppendLine("        [convert_value] ");
            sb.AppendLine("   FROM [DBRET].[dbo].[mst_conversion_for_kouri] ");
            sb.AppendLine("  WHERE [definition_cd] = 15030 ");
            sb.AppendLine("    AND [key_item_01] = 'KORUI_CNV_PROC' ");
            return sb;
        }
        public static StringBuilder CreateSqlSelectKouriCheckProc()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT TOP 1 ");
            sb.AppendLine("        [convert_value] ");
            sb.AppendLine("   FROM [DBRET].[dbo].[mst_conversion_for_kouri] ");
            sb.AppendLine("  WHERE [definition_cd] = 15040 ");
            sb.AppendLine("    AND [key_item_01] = 'KOURI_CHECK_PROC' ");
            return sb;
        }
        public static StringBuilder CreateSqlSelectKouriUpdateDailyProc()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT TOP 1 ");
            sb.AppendLine("        [convert_value] ");
            sb.AppendLine("   FROM [DBRET].[dbo].[mst_conversion_for_kouri] ");
            sb.AppendLine("  WHERE [definition_cd] = 15050 ");
            sb.AppendLine("    AND [key_item_01] = 'KOURI_UPDATE_DAILY' ");
            return sb;
        }
        public static StringBuilder CreateSqlSelectKouriUpdateMonthlyProc()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT TOP 1 ");
            sb.AppendLine("        [convert_value] ");
            sb.AppendLine("   FROM [DBRET].[dbo].[mst_conversion_for_kouri] ");
            sb.AppendLine("  WHERE [definition_cd] = 15060 ");
            sb.AppendLine("    AND [key_item_01] = 'KOURI_UPDATE_MONTHLY' ");
            return sb;
        }


        public const string KM01D_ADDR_A = "@KM01D_ADDR_A";
        public const string KM01D_ADDR_K = "@KM01D_ADDR_K";
        public const string KM01D_CAN_DO = "@KM01D_CAN_DO";
        public const string KM01D_DUP_DEL = "@KM01D_DUP_DEL";
        public const string KM01D_DUP_MOTO = "@KM01D_DUP_MOTO";
        public const string KM01D_FAX = "@KM01D_FAX";
        public const string KM01D_KBN = "@KM01D_KBN";
        public const string KM01D_NAME_A = "@KM01D_NAME_A";
        public const string KM01D_NAME_K = "@KM01D_NAME_K";
        public const string KM01D_NEW_CD = "@KM01D_NEW_CD";
        public const string KM01D_NEW_DATE = "@KM01D_NEW_DATE";
        public const string KM01D_OLD_CD = "@KM01D_OLD_CD";
        public const string KM01D_POST = "@KM01D_POST";
        public const string KM01D_RYAKU = "@KM01D_RYAKU";
        public const string KM01D_TEL = "@KM01D_TEL";
        public const string KM01D_TOR_CD = "@KM01D_TOR_CD";
        public const string KM01D_UP_DATE = "@KM01D_UP_DATE";
        public const string KM01D_UP_TANTO = "@KM01D_UP_TANTO";
        public const string KM01D_YAGOU_A = "@KM01D_YAGOU_A";
        public const string KM01D_YAGOU_K = "@KM01D_YAGOU_K";
        public const string KM01D_Z_KEN_CD = "@KM01D_Z_KEN_CD";
        public const string KM01D_Z_SIKUGUN = "@KM01D_Z_SIKUGUN";
        public static StringBuilder CreateSqlSelectKM01D()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT [km01d_maint] ");
            sb.AppendLine("       ,[km01d_addr_a] ");
            sb.AppendLine("       ,[km01d_addr_k] ");
            sb.AppendLine("       ,[km01d_can_cd] ");
            sb.AppendLine("       ,[km01d_dup_del] ");
            sb.AppendLine("       ,[km01d_dup_moto] ");
            sb.AppendLine("       ,[km01d_fax] ");
            sb.AppendLine("       ,[km01d_kbn] ");
            sb.AppendLine("       ,[km01d_name_a] ");
            sb.AppendLine("       ,[km01d_name_k] ");
            sb.AppendLine("       ,[km01d_new_cd] ");
            sb.AppendLine("       ,[km01d_new_date] ");
            sb.AppendLine("       ,[km01d_old_cd] ");
            sb.AppendLine("       ,[km01d_post] ");
            sb.AppendLine("       ,[km01d_ryaku] ");
            sb.AppendLine("       ,[km01d_tel] ");
            sb.AppendLine("       ,[km01d_tor_cd] ");
            sb.AppendLine("       ,[km01d_up_date] ");
            sb.AppendLine("       ,[km01d_up_tanto] ");
            sb.AppendLine("       ,[km01d_yagou_a] ");
            sb.AppendLine("       ,[km01d_yagou_k] ");
            sb.AppendLine("       ,[km01d_z_ken_cd] ");
            sb.AppendLine("       ,[km01d_z_sikugun] ");
            sb.AppendLine("   FROM [DBRET].[dbo].[km01d] ");
            sb.AppendLine("  WHERE [km01d_tor_cd] = @KM01D_TOR_CD ");
            return sb;
        }

        public static StringBuilder CreateSqlDeleteKM01D()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" UPDATE [dbo].[km01d] ");
            sb.AppendLine("    SET [km01d_maint] = 'D' ");
            sb.AppendLine("  WHERE km01d_tor_cd  = @KM01D_TOR_CD ");
            return sb;
        }

        public static StringBuilder CreateSqlUpdateKM01D()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" MERGE [dbo].[km01d] KM01D ");
            sb.AppendLine(" USING (  ");
            sb.AppendLine("         SELECT ");
            sb.AppendLine("            'C'              AS km01d_maint ");
            sb.AppendLine("           ,@KM01D_ADDR_A    AS km01d_addr_a ");
            sb.AppendLine("           ,@KM01D_ADDR_K    AS km01d_addr_k ");
            sb.AppendLine("           ,@KM01D_CAN_DO    AS km01d_can_cd ");
            sb.AppendLine("           ,@KM01D_DUP_DEL   AS km01d_dup_del ");
            sb.AppendLine("           ,@KM01D_DUP_MOTO  AS km01d_dup_moto ");
            sb.AppendLine("           ,@KM01D_FAX       AS km01d_fax ");
            sb.AppendLine("           ,@KM01D_KBN       AS km01d_kbn ");
            sb.AppendLine("           ,@KM01D_NAME_A    AS km01d_name_a ");
            sb.AppendLine("           ,@KM01D_NAME_K    AS km01d_name_k ");
            sb.AppendLine("           ,@KM01D_NEW_CD    AS km01d_new_cd ");
            sb.AppendLine("           ,@KM01D_NEW_DATE  AS km01d_new_date ");
            sb.AppendLine("           ,@KM01D_OLD_CD    AS km01d_old_cd ");
            sb.AppendLine("           ,@KM01D_POST      AS km01d_post ");
            sb.AppendLine("           ,@KM01D_RYAKU     AS km01d_ryaku ");
            sb.AppendLine("           ,@KM01D_TEL       AS km01d_tel ");
            sb.AppendLine("           ,@KM01D_TOR_CD    AS km01d_tor_cd ");
            sb.AppendLine("           ,@KM01D_UP_DATE   AS km01d_up_date ");
            sb.AppendLine("           ,@KM01D_UP_TANTO  AS km01d_up_tanto ");
            sb.AppendLine("           ,@KM01D_YAGOU_A   AS km01d_yagou_a ");
            sb.AppendLine("           ,@KM01D_YAGOU_K   AS km01d_yagou_k ");
            sb.AppendLine("           ,@KM01D_Z_KEN_CD  AS km01d_z_ken_cd ");
            sb.AppendLine("           ,@KM01D_Z_SIKUGUN AS km01d_z_sikugun ");
            sb.AppendLine("       ) UPD ");
            sb.AppendLine("    ON KM01D.km01d_tor_cd = UPD.km01d_tor_cd ");
            sb.AppendLine(" WHEN MATCHED THEN ");
            sb.AppendLine("     UPDATE SET ");
            sb.AppendLine("          KM01D.[km01d_maint] = UPD.km01d_maint ");
            sb.AppendLine("         ,KM01D.[km01d_addr_a] = UPD.km01d_addr_a ");
            sb.AppendLine("         ,KM01D.[km01d_addr_k] = UPD.km01d_addr_k ");
            sb.AppendLine("         ,KM01D.[km01d_can_cd] = UPD.km01d_can_cd ");
            sb.AppendLine("         ,KM01D.[km01d_dup_del] = UPD.km01d_dup_del ");
            sb.AppendLine("         ,KM01D.[km01d_dup_moto] = UPD.km01d_dup_moto ");
            sb.AppendLine("         ,KM01D.[km01d_fax] = UPD.km01d_fax ");
            sb.AppendLine("         ,KM01D.[km01d_kbn] = UPD.km01d_kbn ");
            sb.AppendLine("         ,KM01D.[km01d_name_a] = UPD.km01d_name_a ");
            sb.AppendLine("         ,KM01D.[km01d_name_k] = UPD.km01d_name_k ");
            sb.AppendLine("         ,KM01D.[km01d_new_cd] = UPD.km01d_new_cd ");
            sb.AppendLine("         ,KM01D.[km01d_new_date] = UPD.km01d_new_date ");
            sb.AppendLine("         ,KM01D.[km01d_old_cd] = UPD.km01d_old_cd ");
            sb.AppendLine("         ,KM01D.[km01d_post] = UPD.km01d_post ");
            sb.AppendLine("         ,KM01D.[km01d_ryaku] = UPD.km01d_ryaku ");
            sb.AppendLine("         ,KM01D.[km01d_tel] = UPD.km01d_tel ");
            sb.AppendLine("         ,KM01D.[km01d_tor_cd] = UPD.km01d_tor_cd ");
            sb.AppendLine("         ,KM01D.[km01d_up_date] = UPD.km01d_up_date ");
            sb.AppendLine("         ,KM01D.[km01d_up_tanto] = UPD.km01d_up_tanto ");
            sb.AppendLine("         ,KM01D.[km01d_yagou_a] = UPD.km01d_yagou_a ");
            sb.AppendLine("         ,KM01D.[km01d_yagou_k] = UPD.km01d_yagou_k ");
            sb.AppendLine("         ,KM01D.[km01d_z_ken_cd] = UPD.km01d_z_ken_cd ");
            sb.AppendLine("         ,KM01D.[km01d_z_sikugun] = UPD.km01d_z_sikugun ");
            sb.AppendLine(" WHEN NOT MATCHED THEN ");
            sb.AppendLine("     INSERT ");
            sb.AppendLine("     ( ");
            sb.AppendLine("          [km01d_maint] ");
            sb.AppendLine("         ,[km01d_addr_a] ");
            sb.AppendLine("         ,[km01d_addr_k] ");
            sb.AppendLine("         ,[km01d_can_cd] ");
            sb.AppendLine("         ,[km01d_dup_del] ");
            sb.AppendLine("         ,[km01d_dup_moto] ");
            sb.AppendLine("         ,[km01d_fax] ");
            sb.AppendLine("         ,[km01d_kbn] ");
            sb.AppendLine("         ,[km01d_name_a] ");
            sb.AppendLine("         ,[km01d_name_k] ");
            sb.AppendLine("         ,[km01d_new_cd] ");
            sb.AppendLine("         ,[km01d_new_date] ");
            sb.AppendLine("         ,[km01d_old_cd] ");
            sb.AppendLine("         ,[km01d_post] ");
            sb.AppendLine("         ,[km01d_ryaku] ");
            sb.AppendLine("         ,[km01d_tel] ");
            sb.AppendLine("         ,[km01d_tor_cd] ");
            sb.AppendLine("         ,[km01d_up_date] ");
            sb.AppendLine("         ,[km01d_up_tanto] ");
            sb.AppendLine("         ,[km01d_yagou_a] ");
            sb.AppendLine("         ,[km01d_yagou_k] ");
            sb.AppendLine("         ,[km01d_z_ken_cd] ");
            sb.AppendLine("         ,[km01d_z_sikugun] ");
            sb.AppendLine("     ) VALUES ( ");
            sb.AppendLine("          'A' ");
            sb.AppendLine("         ,UPD.km01d_addr_a ");
            sb.AppendLine("         ,UPD.km01d_addr_k ");
            sb.AppendLine("         ,UPD.km01d_can_cd ");
            sb.AppendLine("         ,UPD.km01d_dup_del ");
            sb.AppendLine("         ,UPD.km01d_dup_moto ");
            sb.AppendLine("         ,UPD.km01d_fax ");
            sb.AppendLine("         ,UPD.km01d_kbn ");
            sb.AppendLine("         ,UPD.km01d_name_a ");
            sb.AppendLine("         ,UPD.km01d_name_k ");
            sb.AppendLine("         ,UPD.km01d_new_cd ");
            sb.AppendLine("         ,UPD.km01d_new_date ");
            sb.AppendLine("         ,UPD.km01d_old_cd ");
            sb.AppendLine("         ,UPD.km01d_post ");
            sb.AppendLine("         ,UPD.km01d_ryaku ");
            sb.AppendLine("         ,UPD.km01d_tel ");
            sb.AppendLine("         ,UPD.km01d_tor_cd ");
            sb.AppendLine("         ,UPD.km01d_up_date ");
            sb.AppendLine("         ,UPD.km01d_up_tanto ");
            sb.AppendLine("         ,UPD.km01d_yagou_a ");
            sb.AppendLine("         ,UPD.km01d_yagou_k ");
            sb.AppendLine("         ,UPD.km01d_z_ken_cd ");
            sb.AppendLine("         ,UPD.km01d_z_sikugun ");
            sb.AppendLine("     );  ");
            return sb;
        }

        public const string KM41D_CENTER_CD = "@KM41D_CENTER_CD";
        public const string KM41D_PRIVATE_CD = "@KM41D_PRIVATE_CD";
        public const string KM41D_TOKUI_CD = "@KM41D_TOKUI_CD";
        public static StringBuilder CreateSqlSelectKM41D()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT [km41d_center_cd] ");
            sb.AppendLine("       ,[km41d_private_cd] ");
            sb.AppendLine("       ,[km41d_maint] ");
            sb.AppendLine("       ,[km41d_tokui_cd] ");
            sb.AppendLine("       ,[km41d_upd_time] ");
            sb.AppendLine("       ,[km41d_upd_ymd] ");
            sb.AppendLine("   FROM [DBRET].[dbo].[km41d] ");
            sb.AppendLine("  WHERE [km41d_center_cd]  = @KM41D_CENTER_CD ");
            sb.AppendLine("    AND [km41d_private_cd] = @KM41D_PRIVATE_CD ");
            return sb;
        }
        public static StringBuilder CreateSqlDeleteKM41D()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" UPDATE [DBRET].[dbo].[km41d] ");
            sb.AppendLine("    SET [km41d_maint] = 'D' ");
            sb.AppendLine("  WHERE [km41d_center_cd]  = @KM41D_CENTER_CD ");
            sb.AppendLine("    AND [km41d_private_cd] = @KM41D_PRIVATE_CD ");
            return sb;
        }

        public static StringBuilder CreateSqlUpdateKM41D()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" MERGE [DBRET].[dbo].[km41d] KM41D ");
            sb.AppendLine(" USING( ");
            sb.AppendLine("     SELECT ");
            sb.AppendLine("          @KM41D_CENTER_CD  AS km41d_center_cd ");
            sb.AppendLine("         ,@KM41D_PRIVATE_CD AS km41d_private_cd ");
            sb.AppendLine("         ,'C'               AS km41d_maint ");
            sb.AppendLine("         ,@KM41D_TOKUI_CD   AS km41d_tokui_cd ");
            sb.AppendLine("       ) UPD ");
            sb.AppendLine("    ON KM41D.km41d_center_cd = UPD.km41d_center_cd ");
            sb.AppendLine("   AND KM41D.km41d_private_cd = UPD.km41d_private_cd ");
            sb.AppendLine(" WHEN MATCHED THEN ");
            sb.AppendLine("     UPDATE SET ");
            sb.AppendLine("          KM41D.km41d_maint = UPD.km41d_maint ");
            sb.AppendLine("         ,KM41D.km41d_tokui_cd = UPD.km41d_tokui_cd ");
            sb.AppendLine("         ,KM41D.km41d_upd_time = CONVERT(INT, FORMAT(GETDATE(), 'HHmmss')) ");
            sb.AppendLine("         ,KM41D.km41d_upd_ymd = CONVERT(VARCHAR, GETDATE(), 112) ");
            sb.AppendLine(" WHEN NOT MATCHED THEN ");
            sb.AppendLine("     INSERT ");
            sb.AppendLine("     ( ");
            sb.AppendLine("          [km41d_center_cd] ");
            sb.AppendLine("         ,[km41d_private_cd] ");
            sb.AppendLine("         ,[km41d_maint] ");
            sb.AppendLine("         ,[km41d_tokui_cd] ");
            sb.AppendLine("         ,[km41d_upd_time] ");
            sb.AppendLine("         ,[km41d_upd_ymd] ");
            sb.AppendLine("     ) VALUES ( ");
            sb.AppendLine("          UPD.km41d_center_cd ");
            sb.AppendLine("         ,UPD.km41d_private_cd ");
            sb.AppendLine("         ,'A' ");
            sb.AppendLine("         ,UPD.km41d_tokui_cd ");
            sb.AppendLine("         ,CONVERT(INT, FORMAT(GETDATE(), 'HHmmss')) ");
            sb.AppendLine("         ,CONVERT(VARCHAR, GETDATE(), 112) ");
            sb.AppendLine("     ); ");
            return sb;
        }


        public const string KM42D_OROSI_TEN = "@KM42D_OROSI_TEN";
        public const string KM42D_PRV_TORI  = "@KM42D_PRV_TORI";
        public const string KM42D_TORI_CD   = "@KM42D_TORI_CD";
        public static StringBuilder CreateSqlSelectKM42D()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT [km42d_orosi_ten] ");
            sb.AppendLine("       ,[km42d_prv_tori] ");
            sb.AppendLine("       ,[km42d_maint] ");
            sb.AppendLine("       ,[km42d_tori_cd] ");
            sb.AppendLine("       ,[km42d_upd_time] ");
            sb.AppendLine("       ,[km42d_upd_ymd] ");
            sb.AppendLine("   FROM [DBRET].[dbo].[km42d] ");
            sb.AppendLine("  WHERE [km42d_orosi_ten]  = @KM42D_OROSI_TEN ");
            sb.AppendLine("    AND [km42d_prv_tori]   = @KM42D_PRV_TORI ");
            return sb;
        }
        public static StringBuilder CreateSqlDeleteKM42D()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" UPDATE [dbo].[km42d] ");
            sb.AppendLine("    SET [km42d_maint] = 'D' ");
            sb.AppendLine("  WHERE [km42d_orosi_ten] = @KM42D_OROSI_TEN ");
            sb.AppendLine("    AND [km42d_prv_tori]  = @KM42D_PRV_TORI ");
            return sb;
        }

        public static StringBuilder CreateSqlUpdateKM42D()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" MERGE [DBRET].[dbo].[km42d] KM42D ");
            sb.AppendLine(" USING ( ");
            sb.AppendLine(" 		SELECT  ");
            sb.AppendLine(" 			 @KM42D_OROSI_TEN AS km42d_orosi_ten ");
            sb.AppendLine(" 			,@KM42D_PRV_TORI  AS km42d_prv_tori ");
            sb.AppendLine(" 			,'C'              AS km42d_maint ");
            sb.AppendLine(" 			,@KM42D_TORI_CD   AS km42d_tori_cd ");
            sb.AppendLine(" 	  ) UPD ");
            sb.AppendLine("    ON KM42D.km42d_orosi_ten = UPD.km42d_orosi_ten ");
            sb.AppendLine("   AND KM42D.km42d_prv_tori  = UPD.km42d_prv_tori ");
            sb.AppendLine(" WHEN MATCHED THEN  ");
            sb.AppendLine(" 	UPDATE SET ");
            sb.AppendLine(" 		 KM42D.km42d_maint   = UPD.km42d_maint ");
            sb.AppendLine(" 		,KM42D.km42d_tori_cd = UPD.km42d_tori_cd ");
            sb.AppendLine(" 		,km42d_upd_time      = CONVERT(INT, FORMAT(GETDATE(), 'HHmmss')) ");
            sb.AppendLine(" 		,km42d_upd_ymd       = CONVERT(VARCHAR, GETDATE(), 112)  ");
            sb.AppendLine(" WHEN NOT MATCHED THEN  ");
            sb.AppendLine(" 	INSERT  ");
            sb.AppendLine(" 	( ");
            sb.AppendLine(" 		 [km42d_orosi_ten] ");
            sb.AppendLine(" 		,[km42d_prv_tori]  ");
            sb.AppendLine(" 		,[km42d_maint]     ");
            sb.AppendLine(" 		,[km42d_tori_cd]   ");
            sb.AppendLine(" 		,[km42d_upd_time]  ");
            sb.AppendLine(" 		,[km42d_upd_ymd]   ");
            sb.AppendLine(" 	) VALUES ( ");
            sb.AppendLine(" 		 UPD.km42d_orosi_ten ");
            sb.AppendLine(" 		,UPD.km42d_prv_tori ");
            sb.AppendLine(" 		,'A' ");
            sb.AppendLine(" 		,UPD.km42d_tori_cd ");
            sb.AppendLine(" 		,CONVERT(INT, FORMAT(GETDATE(), 'HHmmss')) ");
            sb.AppendLine(" 		,CONVERT(VARCHAR, GETDATE(), 112)  ");
            sb.AppendLine(" 	); ");
            return sb;
        }

        public const string KM43D_OROSI_TEN = "@KM43D_OROSI_TEN";
        public const string KM43D_TORI_NM   = "@KM43D_TORI_NM";
        public const string KM43D_TORI_CD   = "@KM43D_TORI_CD";
        public static StringBuilder CreateSqlSelectKM43D()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT [km43d_orosi_ten] ");
            sb.AppendLine("       ,[km43d_tori_nm] ");
            sb.AppendLine("       ,[km43d_maint] ");
            sb.AppendLine("       ,[km43d_tori_cd] ");
            sb.AppendLine("       ,[km43d_upd_time] ");
            sb.AppendLine("       ,[km43d_upd_ymd] ");
            sb.AppendLine("   FROM [DBRET].[dbo].[km43d] ");
            sb.AppendLine("  WHERE [km43d_orosi_ten] = @KM43D_OROSI_TEN ");
            sb.AppendLine("    AND [km43d_tori_nm]   = @KM43D_TORI_NM ");
            return sb;
        }

        public static StringBuilder CreateSqlUpdateKM43D()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" MERGE [DBRET].[dbo].[km43d] KM43D ");
            sb.AppendLine(" USING( ");
            sb.AppendLine("         SELECT ");
            sb.AppendLine("              @KM43D_OROSI_TEN AS km43d_orosi_ten ");
            sb.AppendLine("             ,@KM43D_TORI_NM   AS km43d_tori_nm ");
            sb.AppendLine("             ,'C'              AS km43d_maint ");
            sb.AppendLine("             ,@KM43D_TORI_CD   AS km43d_tori_cd ");
            sb.AppendLine("       ) UPD ");
            sb.AppendLine("    ON KM43D.km43d_orosi_ten = UPD.km43d_orosi_ten ");
            sb.AppendLine("   AND KM43D.km43d_tori_nm   = UPD.km43d_tori_nm ");
            sb.AppendLine(" WHEN MATCHED THEN ");
            sb.AppendLine("     UPDATE SET ");
            sb.AppendLine("          [km43d_maint]     = UPD.km43d_maint ");
            sb.AppendLine("         ,[km43d_tori_cd]   = UPD.km43d_tori_cd ");
            sb.AppendLine("         ,[km43d_upd_time]  = CONVERT(INT, FORMAT(GETDATE(), 'HHmmss')) ");
            sb.AppendLine("         ,[km43d_upd_ymd]   = CONVERT(VARCHAR, GETDATE(), 112) ");
            sb.AppendLine(" WHEN NOT MATCHED THEN ");
            sb.AppendLine("     INSERT ");
            sb.AppendLine("         ( ");
            sb.AppendLine("              [km43d_orosi_ten] ");
            sb.AppendLine("             ,[km43d_tori_nm] ");
            sb.AppendLine("             ,[km43d_maint] ");
            sb.AppendLine("             ,[km43d_tori_cd] ");
            sb.AppendLine("             ,[km43d_upd_time] ");
            sb.AppendLine("             ,[km43d_upd_ymd] ");
            sb.AppendLine("         ) VALUES ( ");
            sb.AppendLine("              UPD.km43d_orosi_ten ");
            sb.AppendLine("             ,UPD.km43d_tori_nm ");
            sb.AppendLine("             ,'A' ");
            sb.AppendLine("             ,UPD.km43d_tori_cd ");
            sb.AppendLine("             ,CONVERT(INT, FORMAT(GETDATE(), 'HHmmss')) ");
            sb.AppendLine("             ,CONVERT(VARCHAR, GETDATE(), 112) ");
            sb.AppendLine("         ); ");
            return sb;
        }

        public static StringBuilder CreateSqlDeleteKM43D()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" UPDATE [dbo].[km43d] ");
            sb.AppendLine("    SET [km43d_maint] = 'D' ");
            sb.AppendLine("  WHERE [km43d_orosi_ten] = @KM43D_OROSI_TEN ");
            sb.AppendLine("    AND [km43d_tori_nm]   = @KM43D_TORI_NM ");
            return sb;
        }


        public const string KM44D_OROSI_TEN = "@KM44D_OROSI_TEN";
        public const string KM44D_PRV_SHO = "@KM44D_PRV_SHO";
        public const string KM44D_IRI_SU = "@KM44D_IRI_SU";
        public const string KM44D_SHOHIN_CD = "@KM44D_SHOHIN_CD";
        public static StringBuilder CreateSqlSelectKM44D()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT [km44d_orosi_ten] ");
            sb.AppendLine("       ,[km44d_prv_sho] ");
            sb.AppendLine("       ,[km44d_iri_su] ");
            sb.AppendLine("       ,[km44d_maint] ");
            sb.AppendLine("       ,[km44d_shohin_cd] ");
            sb.AppendLine("       ,[km44d_upd_time] ");
            sb.AppendLine("       ,[km44d_upd_ymd] ");
            sb.AppendLine("   FROM [DBRET].[dbo].[km44d] ");
            sb.AppendLine("  WHERE [km44d_orosi_ten] = @KM44D_OROSI_TEN ");
            sb.AppendLine("    AND [km44d_prv_sho]   = @KM44D_PRV_SHO ");
            sb.AppendLine("    AND [km44d_iri_su]    = @KM44D_IRI_SU ");
            return sb;
        }

        public static StringBuilder CreateSqlUpdateKM44D()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" MERGE [DBRET].[dbo].[km44d] KM44D ");
            sb.AppendLine(" USING ( ");
            sb.AppendLine(" 	SELECT ");
            sb.AppendLine(" 		 @KM44D_OROSI_TEN AS km44d_orosi_ten ");
            sb.AppendLine(" 		,@KM44D_PRV_SHO   AS km44d_prv_sho ");
            sb.AppendLine(" 		,@KM44D_IRI_SU    AS km44d_iri_su ");
            sb.AppendLine(" 		,'C'              AS km44d_maint ");
            sb.AppendLine(" 		,@KM44d_SHOHIN_CD  AS km44d_shohin_cd ");
            sb.AppendLine(" 	  ) UPD ");
            sb.AppendLine("    ON KM44D.km44d_orosi_ten = UPD.km44d_orosi_ten ");
            sb.AppendLine("   AND KM44D.km44d_prv_sho   = UPD.km44d_prv_sho ");
            sb.AppendLine("   AND KM44D.km44d_iri_su    = UPD.km44d_iri_su ");
            sb.AppendLine(" WHEN MATCHED THEN  ");
            sb.AppendLine(" 	UPDATE SET ");
            sb.AppendLine(" 		 [km44d_maint]     = UPD.km44d_maint ");
            sb.AppendLine(" 		,[km44d_shohin_cd] = UPD.km44d_shohin_cd ");
            sb.AppendLine(" 		,[km44d_upd_time]  = CONVERT(INT, FORMAT(GETDATE(), 'HHmmss')) ");
            sb.AppendLine(" 		,[km44d_upd_ymd]   = CONVERT(VARCHAR, GETDATE(), 112) ");
            sb.AppendLine(" WHEN NOT MATCHED THEN  ");
            sb.AppendLine(" 	INSERT ");
            sb.AppendLine(" 		( ");
            sb.AppendLine(" 			 [km44d_orosi_ten] ");
            sb.AppendLine(" 			,[km44d_prv_sho] ");
            sb.AppendLine(" 			,[km44d_iri_su] ");
            sb.AppendLine(" 			,[km44d_maint] ");
            sb.AppendLine(" 			,[km44d_shohin_cd] ");
            sb.AppendLine(" 			,[km44d_upd_time] ");
            sb.AppendLine(" 			,[km44d_upd_ymd] ");
            sb.AppendLine(" 		) VALUES ( ");
            sb.AppendLine(" 			 UPD.km44d_orosi_ten ");
            sb.AppendLine(" 			,UPD.km44d_prv_sho ");
            sb.AppendLine(" 			,UPD.km44d_iri_su ");
            sb.AppendLine(" 			,'A' ");
            sb.AppendLine(" 			,UPD.km44d_shohin_cd ");
            sb.AppendLine(" 			,CONVERT(INT, FORMAT(GETDATE(), 'HHmmss')) ");
            sb.AppendLine(" 			,CONVERT(VARCHAR, GETDATE(), 112) ");
            sb.AppendLine(" 		); ");
            return sb;
        }

        public static StringBuilder CreateSqlDeleteKM44D()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" UPDATE [dbo].[km44d] ");
            sb.AppendLine("    SET [km44d_maint] = 'D' ");
            sb.AppendLine("  WHERE [km44d_orosi_ten] = @KM44D_OROSI_TEN ");
            sb.AppendLine("    AND [km44d_prv_sho]   = @KM44D_PRV_SHO ");
            sb.AppendLine("    AND [km44d_iri_su]    = @KM44D_IRI_SU ");
            return sb;
        }

        public static StringBuilder CreateSqlSelectShoriDate()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT  ");
            sb.AppendLine("      MAX(YYYYMMDD_FROM) AS YYYYMMDD_FROM ");
            sb.AppendLine("     ,MAX(YYYYMMDD_TO)   AS YYYYMMDD_TO ");
            sb.AppendLine("   FROM ( ");
            sb.AppendLine(" SELECT  ");
            sb.AppendLine("      ''  AS YYYYMMDD_FROM ");
            sb.AppendLine("     ,CONVERT(VARCHAR, DATEFROMPARTS([cal_year], [cal_month], [cal_day]), 112) AS YYYYMMDD_TO ");
            sb.AppendLine("     ,RANK ( ) OVER (ORDER BY DATEFROMPARTS([cal_year], [cal_month], [cal_day]) DESC) AS RANK_DATE ");
            sb.AppendLine("   FROM [Utildb].[dbo].[Cal21] ");
            sb.AppendLine("  WHERE [cal_jigyo]  = 10 ");
            sb.AppendLine("    AND DATEFROMPARTS([cal_year], [cal_month], [cal_day]) <= DATEADD(day, -1, GETDATE()) ");
            sb.AppendLine(" UNION ");
            sb.AppendLine(" SELECT  ");
            sb.AppendLine("      CONVERT(VARCHAR, DATEFROMPARTS([cal_year], [cal_month], [cal_day]), 112) AS YYYYMMDD_FROM ");
            sb.AppendLine("     ,'' AS YYYYMMDD_TO ");
            sb.AppendLine("     ,RANK ( ) OVER (ORDER BY DATEFROMPARTS([cal_year], [cal_month], [cal_day]) DESC) AS RANK_DATE ");
            sb.AppendLine("   FROM [Utildb].[dbo].[Cal21] ");
            sb.AppendLine("  WHERE [cal_jigyo]  = 10 ");
            sb.AppendLine("    AND DATEFROMPARTS([cal_year], [cal_month], [cal_day]) <= DATEADD(day, -1, GETDATE()) ");
            sb.AppendLine("    AND cal_flg = 1 ");
            sb.AppendLine(" ) AA ");
            sb.AppendLine(" WHERE AA.RANK_DATE = 1 ");
            return sb;
        }

        public static StringBuilder CreateSqlSelecteKM31dTodoufuken()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("  [都道府県コード],[都道府県名]");
            sb.AppendLine("  FROM [OBIC7].[dbo].[地域マスタ]");
            sb.AppendLine("  GROUP BY");
            sb.AppendLine(" [都道府県コード],[都道府県名]");
            return sb;
        }

        public const string TIKIMASTER_TODOUHUKEN_CD = "@TODOUHUKEN_CD";
        public static StringBuilder CreateSqlSelecteKM31dTiku()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT [地域コード]");
            sb.AppendLine("      ,[地区名]");
            sb.AppendLine("      ,SUBSTRING([地域コード],3,2)");
            sb.AppendLine("  FROM [OBIC7].[dbo].[地域マスタ]");
            sb.AppendLine("  WHERE");
            sb.AppendLine("  都道府県コード=@TODOUHUKEN_CD");
            return sb;
        }

        public const string KM31D_FUKEN = "@KM31D_FUKEN";
        public const string KM31D_CHIKU = "@KM31D_CHIKU";

        public static StringBuilder CreateSqlSelectekm04dShitenListSearch()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT ");
            sb.AppendLine("km04d.[km04d_orosi_cd],km04d.[km04d_name_k],km04d.[km04d_br_name_k]");
            sb.AppendLine("FROM ");
            sb.AppendLine("[DBRET].[dbo].[km31d] AS km31d");
            sb.AppendLine("JOIN");
            sb.AppendLine("[DBRET].[dbo].[km04d] AS km04d");
            sb.AppendLine("ON km31d.[km31d_orosi_ten] + km31d.[km31d_orosi_brch] = km04d.[km04d_orosi_cd]");
            sb.AppendLine("  WHERE ");
            sb.AppendLine("km31d.[km31d_fuken]=@KM31D_FUKEN");
            sb.AppendLine(" AND ");
            sb.AppendLine("km31d.[km31d_chiku] =@KM31D_CHIKU");
            sb.AppendLine("GROUP BY");
            sb.AppendLine("km04d.[km04d_orosi_cd],km04d.[km04d_name_k],km04d.[km04d_br_name_k];");
            return sb;
        }

        public const string OROSHI_SHITEN_NAME = "@OROSHI_SHITEN_NAME";

        public static StringBuilder CreateSqlSelectkm04dfukenListSearch()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT ");
            sb.AppendLine("km04d.[km04d_orosi_cd]");
            sb.AppendLine(",LEFT(km04d.[km04d_name_k] + SPACE(15), 15)+km04d.[km04d_br_name_k] AS oroshi_shiten_name");
            sb.AppendLine("FROM ");
            sb.AppendLine("[DBRET].[dbo].[km31d] AS km31d");
            sb.AppendLine("JOIN");
            sb.AppendLine("[DBRET].[dbo].[km04d] AS km04d");
            sb.AppendLine("ON km31d.[km31d_orosi_ten] + km31d.[km31d_orosi_brch] = km04d.[km04d_orosi_cd]");
            sb.AppendLine("  WHERE ");
            sb.AppendLine("km31d.[km31d_fuken]=@KM31D_FUKEN");
            sb.AppendLine("AND km04d.[km04d_orosi_cd] LIKE @KM04D_OROSI_CD");
            sb.AppendLine("AND LEFT(km04d.[km04d_name_k] + SPACE(15), 15)+km04d.[km04d_br_name_k] LIKE @OROSHI_SHITEN_NAME");
            sb.AppendLine("GROUP BY");
            sb.AppendLine("km04d.[km04d_orosi_cd],km04d.[km04d_name_k],km04d.[km04d_br_name_k];");
            return sb;
        }



        public static StringBuilder CreateSqlSelectkm04dShitenListSearch()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT ");
            sb.AppendLine("km04d.[km04d_orosi_cd]");
            sb.AppendLine(",LEFT(km04d.[km04d_name_k] + SPACE(15), 15)+km04d.[km04d_br_name_k] AS oroshi_shiten_name");
            sb.AppendLine("FROM ");
            sb.AppendLine("[DBRET].[dbo].[km31d] AS km31d");
            sb.AppendLine("JOIN");
            sb.AppendLine("[DBRET].[dbo].[km04d] AS km04d");
            sb.AppendLine("ON km31d.[km31d_orosi_ten] + km31d.[km31d_orosi_brch] = km04d.[km04d_orosi_cd]");
            sb.AppendLine("  WHERE ");
            sb.AppendLine("km31d.[km31d_fuken]=@KM31D_FUKEN ");
            sb.AppendLine("AND km31d.[km31d_chiku] =@KM31D_CHIKU");
            sb.AppendLine("AND km04d.[km04d_orosi_cd] LIKE @KM04D_OROSI_CD");
            sb.AppendLine("AND LEFT(km04d.[km04d_name_k] + SPACE(15), 15)+km04d.[km04d_br_name_k] LIKE @OROSHI_SHITEN_NAME");
            sb.AppendLine("GROUP BY");
            sb.AppendLine("km04d.[km04d_orosi_cd],km04d.[km04d_name_k],km04d.[km04d_br_name_k];");
            return sb;
        }

        public static StringBuilder CreateSqlSelectekm04dShitenTextSearch()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT ");
            sb.AppendLine("km04d.[km04d_orosi_cd]");
            sb.AppendLine(",LEFT(km04d.[km04d_name_k] + SPACE(15), 15)+km04d.[km04d_br_name_k] AS oroshi_shiten_name");
            sb.AppendLine("FROM ");
            sb.AppendLine("[DBRET].[dbo].[km31d] AS km31d");
            sb.AppendLine("JOIN");
            sb.AppendLine("[DBRET].[dbo].[km04d] AS km04d");
            sb.AppendLine("ON km31d.[km31d_orosi_ten] + km31d.[km31d_orosi_brch] = km04d.[km04d_orosi_cd]");
            sb.AppendLine("  WHERE ");
            sb.AppendLine(" km04d.[km04d_orosi_cd] LIKE @KM04D_OROSI_CD");
            sb.AppendLine("AND LEFT(km04d.[km04d_name_k] + SPACE(15), 15)+km04d.[km04d_br_name_k] LIKE @OROSHI_SHITEN_NAME");
            sb.AppendLine("GROUP BY");
            sb.AppendLine("km04d.[km04d_orosi_cd],km04d.[km04d_name_k],km04d.[km04d_br_name_k];");
            return sb;
        }


        /// <summary>
        /// //////////////////////////////////
        /// </summary>
        /// <returns></returns>
        public static StringBuilder CreateSqlSelecteSHOHN()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("[shohn_shohin_cd] ");
            sb.AppendLine(",[shohn_na_25_kn] ");
            sb.AppendLine("FROM [SHO].[dbo].[SHOHN]");
            return sb;
        }
        public const string SHOHN_NA_25_KN = "@SHOHN_NA_25_KN";
        
        public static StringBuilder CreateSqlSelecteSHOHNTextSearch()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT ");
            sb.AppendLine("[shohn_shohin_cd] ");
            sb.AppendLine(",[shohn_na_25_kn] ");
            sb.AppendLine(",[shohn_box_iri] ");
            sb.AppendLine("FROM [SHO].[dbo].[SHOHN]");
            sb.AppendLine("WHERE");
            sb.AppendLine("[shohn_na_25_kn] LIKE @SHOHN_NA_25_KN");
            return sb;
        }


        public const string SHOHN_SHOHIN_SHOHIN_CD_srt = "@SHOHN_SHOHIN_SHOHIN_CD_srt";

        public const string SHOHN_SHOHIN_SHOHIN_CD_end = "@SHOHN_SHOHIN_SHOHIN_CD_end";
        public static StringBuilder CreateSqlSelecteSHOHNAllItemSearch()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("[shohn_shohin_cd]");
            sb.AppendLine(",[shohn_na_25_kn]");
            sb.AppendLine(",[shohn_box_iri]");
            sb.AppendLine("FROM [SHO].[dbo].[SHOHN]");
            sb.AppendLine("WHERE");
            sb.AppendLine("[shohn_shohin_cd] >= @SHOHN_SHOHIN_SHOHIN_CD_srt");
            sb.AppendLine("AND [shohn_shohin_cd] <= @SHOHN_SHOHIN_SHOHIN_CD_end");
            sb.AppendLine("AND[shohn_na_25_kn] LIKE @SHOHN_NA_25_KN");
            return sb;
        }

        public static StringBuilder CreateSqlSelecteSHOHNStartItemSearch()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("[shohn_shohin_cd]");
            sb.AppendLine(",[shohn_na_25_kn]");
            sb.AppendLine(",[shohn_box_iri]");
            sb.AppendLine("FROM [SHO].[dbo].[SHOHN]");
            sb.AppendLine("WHERE");
            sb.AppendLine("[shohn_shohin_cd] >= @SHOHN_SHOHIN_SHOHIN_CD_srt");
            sb.AppendLine("AND [shohn_shohin_cd] <= (SELECT MAX(shohn_shohin_cd) FROM [SHO].[dbo].[SHOHN])");
            sb.AppendLine("AND[shohn_na_25_kn] LIKE @SHOHN_NA_25_KN");
            return sb;
        }

        public static StringBuilder CreateSqlSelecteSHOHNEndItemSearch()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("[shohn_shohin_cd]");
            sb.AppendLine(",[shohn_na_25_kn]");
            sb.AppendLine(",[shohn_box_iri]");
            sb.AppendLine("FROM [SHO].[dbo].[SHOHN]");
            sb.AppendLine("WHERE");
            sb.AppendLine("[shohn_shohin_cd] >=(SELECT MIN(shohn_shohin_cd) FROM [SHO].[dbo].[SHOHN])");
            sb.AppendLine("AND [shohn_shohin_cd] <= @SHOHN_SHOHIN_SHOHIN_CD_end");
            sb.AppendLine("AND [shohn_na_25_kn] LIKE @SHOHN_NA_25_KN");
            return sb;
        }


        public const string KM08D_DATA_YM = "@KM08D_DATA_YM";
        public const string OROSI_CD_KETUGO = "@OROSI_CD_KETUGO";
        public const string KM08D_TEN_CD = "@KM08D_TEN_CD";
        public static StringBuilder CreateSqlSelectekm08dandSHOHNSearch()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("'' AS delete_flg");
            sb.AppendLine(",km08d.[km08d_sho_cd]");
            sb.AppendLine(",SHOHN.[shohn_na_25_kn] ");
            sb.AppendLine(",SHOHN.[shohn_box_iri] ");
            sb.AppendLine(",km08d.[km08d_hakosu] ");
            sb.AppendLine(",km08d.[km08d_hasu]");
            sb.AppendLine(",km08d.[km08d_hasu] AS km08d_hasu_Goukei");
            sb.AppendLine(",km08d.[km08d_pri_kbn] ");
            sb.AppendLine(",km08d.[km08d_orosi_ten] + km08d.[km08d_orosi_brch] AS km08d_orshi_shiten_cd");
            sb.AppendLine(",km08d.[km08d_ten_cd]");
            sb.AppendLine(",km08d.[km08d_data_ym]");
            sb.AppendLine(",km08d.[km08d_sho_cd] AS km08d_sho_cd_ReadOnly");
            sb.AppendLine(",km08d.[km08d_hakosu] AS km08d_hakosu_ReadOnly");
            sb.AppendLine(",km08d.[km08d_hasu] AS km08d_hasu_ReadOnly");
            sb.AppendLine("FROM");
            sb.AppendLine("[DBRET].[dbo].[km08d] AS km08d");
            sb.AppendLine("JOIN");
            sb.AppendLine("[SHO].[dbo].[SHOHN] AS SHOHN");
            sb.AppendLine("ON km08d.km08d_sho_cd = SHOHN.[shohn_shohin_cd]");
            sb.AppendLine("WHERE");
            sb.AppendLine("km08d.[km08d_pri_kbn] ='0'");
            sb.AppendLine("AND km08d.[km08d_orosi_ten] + km08d.[km08d_orosi_brch]=@OROSI_CD_KETUGO");
            sb.AppendLine("AND km08d.[km08d_ten_cd] =@KM08D_TEN_CD");
            sb.AppendLine("AND [km08d_data_ym]=@KM08D_DATA_YM");
            sb.AppendLine("ORDER BY");
            sb.AppendLine("SHOHN.[shohn_shohin_cd];");
            return sb;
        }


        public const string KM08D_SHO_CD = "@KM08D_SHO_CD";


        public static StringBuilder CreateSqlselectKM04DateCheck()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT ");
            sb.AppendLine("    [km04d_br_name_k]");
            sb.AppendLine("    ,[km04d_name_k]");
            sb.AppendLine("    ,[km04d_orosi_cd]");
            sb.AppendLine("    ,[km04d_ten_cd]");
            sb.AppendLine("FROM [DBRET].[dbo].[km04d]");
            sb.AppendLine("WHERE");
            sb.AppendLine("[km04d_orosi_cd] = @KM04D_OROSI_CD");
            sb.AppendLine("AND [km04d_ten_cd] = @KM04D_TEN_CD;");
            return sb;
        }

        public const string SHOHN_SHOHIN_CD = "@SHOHN_SHOHIN_CD";
        public static StringBuilder CreateSqlselectSHOHNshohincodeCheck()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT TOP 1 ");
            sb.AppendLine("[shohn_box_iri]");
            sb.AppendLine("FROM [SHO].[dbo].[SHOHN]");
            sb.AppendLine("WHERE");
            sb.AppendLine("[shohn_shohin_cd] =@SHOHN_SHOHIN_CD");
            return sb;
        }

        public static StringBuilder CreateSqlselectKM08DataExistenceCheck() 
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT COUNT(*)");
            sb.AppendLine("FROM [DBRET].[dbo].[km08d]");
            sb.AppendLine("WHERE");
            sb.AppendLine("[km08d_orosi_ten]+[km08d_orosi_brch]=@OROSI_CD_KETUGO");
            sb.AppendLine("AND [km08d_ten_cd] =@KM08D_TEN_CD");
            sb.AppendLine("AND [km08d_data_ym] =@KM08D_DATA_YM");
            sb.AppendLine("AND [km08d_sho_cd] =@KM08D_SHO_CD;");
            return sb;
        }

        public const string KM08D_OROSI_BRCH = "@KM08D_OROSI_BRCH";
        public const string KM08D_OROSI_TEN = "@KM08D_OROSI_TEN";

        public const string KM08D_HAKOSU = "@KM08D_HAKOSU";
        public const string KM08D_HASU = "@KM08D_HASU";
        public const string KM08D_PRI_KBN = "@KM08D_PRI_KBN";

        public const string KM08D_YMD = "@KM08D_YMD";

        public static StringBuilder CreateSqlinsertkm08d()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO [DBRET].[dbo].[km08d]");
            sb.AppendLine("([km08d_orosi_brch]");
            sb.AppendLine(",[km08d_orosi_ten]");
            sb.AppendLine(",[km08d_data_ym]");
            sb.AppendLine(",[km08d_hakosu]");
            sb.AppendLine(",[km08d_hasu]");
            sb.AppendLine(",[km08d_pri_kbn]");
            sb.AppendLine(",[km08d_sho_cd]");
            sb.AppendLine(",[km08d_ten_cd]");
            sb.AppendLine(",[km08d_ymd]");
            sb.AppendLine(")");
            sb.AppendLine("VALUES");
            sb.AppendLine("(@KM08D_OROSI_BRCH");
            sb.AppendLine(",@KM08D_OROSI_TEN");
            sb.AppendLine(",@KM08D_DATA_YM");
            sb.AppendLine(",@KM08D_HAKOSU");
            sb.AppendLine(",@KM08D_HASU");
            sb.AppendLine(",@KM08D_PRI_KBN");
            sb.AppendLine(",@KM08D_SHO_CD");
            sb.AppendLine(",@KM08D_TEN_CD");
            sb.AppendLine(",@KM08D_YMD");
            sb.AppendLine(")");
            return sb;
        }

        public const string KM08D_DATA_YM_LASTMONTH = "@KM08D_DATA_YM_LASTMONTH";
        public static StringBuilder CreateSqlinsertkm08dLastMonthDataCheck()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT  TOP 1");
            sb.AppendLine("[km08d_orosi_brch]");
            sb.AppendLine(",[km08d_orosi_ten]");
            sb.AppendLine(",@KM08D_DATA_YM AS km08d_data_ym");
            sb.AppendLine(",[km08d_hakosu]");
            sb.AppendLine(",[km08d_hasu]");
            sb.AppendLine(",[km08d_pri_kbn]");
            sb.AppendLine(",[km08d_sho_cd]");
            sb.AppendLine(",[km08d_ten_cd]");
            sb.AppendLine(",@KM08D_DATA_YM + '99' AS km08d_ymd");
            sb.AppendLine("FROM  [DBRET].[dbo].[km08d]");
            sb.AppendLine("WHERE");
            sb.AppendLine("[km08d_orosi_ten]+[km08d_orosi_brch] =@OROSI_CD_KETUGO");
            sb.AppendLine("AND [km08d_ten_cd] =@KM08D_TEN_CD");
            sb.AppendLine("AND [km08d_data_ym] =@KM08D_DATA_YM_LASTMONTH");
            sb.AppendLine("AND [km08d_sho_cd] =@KM08D_SHO_CD");
            sb.AppendLine("AND NOT EXISTS ");
            sb.AppendLine(" (SELECT");
            sb.AppendLine(" *");
            sb.AppendLine(" FROM");
            sb.AppendLine(" [DBRET].[dbo].[km08d]");
            sb.AppendLine(" WHERE");
            sb.AppendLine(" [km08d_orosi_ten]+[km08d_orosi_brch] =@OROSI_CD_KETUGO");
            sb.AppendLine(" AND [km08d_ten_cd] =@KM08D_TEN_CD");
            sb.AppendLine(" AND [km08d_data_ym] =@KM08D_DATA_YM");
            sb.AppendLine(" AND [km08d_sho_cd] =@KM08D_SHO_CD");
            sb.AppendLine(" );");
            return sb;
        }

        public static StringBuilder CreateSqlinsertkm08dLastMonthDataCopy()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO  [DBRET].[dbo].[km08d]");
            sb.AppendLine("([km08d_orosi_brch]");
            sb.AppendLine(",[km08d_orosi_ten]");
            sb.AppendLine(",[km08d_data_ym]");
            sb.AppendLine(",[km08d_hakosu]");
            sb.AppendLine(",[km08d_hasu]");
            sb.AppendLine(",[km08d_pri_kbn]");
            sb.AppendLine(",[km08d_sho_cd]");
            sb.AppendLine(",[km08d_ten_cd]");
            sb.AppendLine(",[km08d_ymd]");
            sb.AppendLine(")");
            sb.AppendLine("SELECT  TOP 1");
            sb.AppendLine("[km08d_orosi_brch]");
            sb.AppendLine(",[km08d_orosi_ten]");
            sb.AppendLine(",@KM08D_DATA_YM AS km08d_data_ym");
            sb.AppendLine(",[km08d_hakosu]");
            sb.AppendLine(",[km08d_hasu]");
            sb.AppendLine(",[km08d_pri_kbn]");
            sb.AppendLine(",[km08d_sho_cd]");
            sb.AppendLine(",[km08d_ten_cd]");
            sb.AppendLine(",@KM08D_DATA_YM + '99' AS km08d_ymd");
            sb.AppendLine("FROM  [DBRET].[dbo].[km08d]");
            sb.AppendLine("WHERE");
            sb.AppendLine("[km08d_orosi_ten]+[km08d_orosi_brch] =@OROSI_CD_KETUGO");
            sb.AppendLine("AND [km08d_ten_cd] =@KM08D_TEN_CD");
            sb.AppendLine("AND [km08d_data_ym] =@KM08D_DATA_YM_LASTMONTH");
            sb.AppendLine("AND [km08d_sho_cd] =@KM08D_SHO_CD");
            sb.AppendLine("AND NOT EXISTS ");
            sb.AppendLine(" (SELECT");
            sb.AppendLine(" *");
            sb.AppendLine(" FROM");
            sb.AppendLine(" [DBRET].[dbo].[km08d]");
            sb.AppendLine(" WHERE");
            sb.AppendLine(" [km08d_orosi_ten]+[km08d_orosi_brch] =@OROSI_CD_KETUGO");
            sb.AppendLine(" AND [km08d_ten_cd] =@KM08D_TEN_CD");
            sb.AppendLine(" AND [km08d_data_ym] =@KM08D_DATA_YM");
            sb.AppendLine(" AND [km08d_sho_cd] =@KM08D_SHO_CD");
            sb.AppendLine(" );");
            return sb;
        }

        public static StringBuilder CreateSqlUpdatekm08d()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE [dbo].[km08d]");
            sb.AppendLine("SET [km08d_hasu] = @KM08D_HASU");
            sb.AppendLine("WHERE ");
            sb.AppendLine("[km08d_orosi_ten]+[km08d_orosi_brch] =@OROSI_CD_KETUGO");
            sb.AppendLine("AND [km08d_ten_cd] =@KM08D_TEN_CD");
            sb.AppendLine("AND [km08d_data_ym] =@KM08D_DATA_YM");
            sb.AppendLine("AND [km08d_sho_cd] =@KM08D_SHO_CD");
            return sb;
        }
        public static StringBuilder CreateSqldeleteKM08D()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DELETE FROM  [DBRET].[dbo].[km08d]");
            sb.AppendLine("WHERE ");
            sb.AppendLine("  [km08d_orosi_ten]+[km08d_orosi_brch] =@OROSI_CD_KETUGO");
            sb.AppendLine("  AND [km08d_ten_cd] =@KM08D_TEN_CD");
            sb.AppendLine("  AND [km08d_data_ym] =@KM08D_DATA_YM");
            sb.AppendLine("  AND [km08d_sho_cd] =@KM08D_SHO_CD");
            return sb;
        }
    }
}