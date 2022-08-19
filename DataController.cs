using AppConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class DataController
    {
        public static ConfigurationMgr mgr = ConfigurationMgr.Instance();
        public static SqlConnection con = new SqlConnection(mgr.ConnectionString.ToString());

        public static DataSet DomainList(int chk)
        {
            string sqlrd = "";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            if(chk ==1 )
            {
                sqlrd = "SELECT DomainName ,Count(DomainName) as cnt , " +
                "(CASE WHEN SyncType = '1' THEN 'TargetAD'" +
                " WHEN SyncType = '2' THEN 'Local' END)" +
                " AS SyncType FROM adPWD_Domains " +
                "GROUP BY(DomainName),SyncType";
            }
            else if(chk == 2)
            {
                sqlrd = "SELECT DomainName ," +
                "(CASE WHEN SyncType = '1' THEN 'Local'" +
                " WHEN SyncType = '2' THEN 'Global AD' END)" +
                "  AS SyncType,orderCycle,lastInventoryTime FROM adPWD_Domains ";
            }

            cmd.CommandText = sqlrd;

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter Dadap = new SqlDataAdapter();
            Dadap.SelectCommand = cmd;

            DataSet ds = new DataSet();

            Dadap.Fill(ds, "[adPWDSync].[dbo].[adPWD_Domains]");
            con.Close();
            return ds;
        }


        public static DataSet ServerCheck()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            string sqlrd = "SELECT ServerName , 'Running' as chk FROM [adPWD_Servers] where ServerName is Not Null Group by ServerName";

            cmd.CommandText = sqlrd;

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter Dadap = new SqlDataAdapter();
            Dadap.SelectCommand = cmd;

            DataSet ds = new DataSet();

            Dadap.Fill(ds, "[adPWDSync].[dbo].[adPWD_Servers]");
            con.Close();
            return ds;
        }

        public static DataSet DomainList(string strs)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            string sqlrd = $"SELECT dc.ControllerName as DCName, " +
                "(CASE WHEN dc.OutBoundFailCnt > 0  THEN 'Fail'" +
                " WHEN dc.OutBoundFailCnt = 0 THEN 'Success' END)" +
                " AS Status, dc.ControllerIP AS IP," +
                " Replace(Convert(varchar(50), dc.OutBoundTime, 0), '  ', '/') as LastUpdateTime" +
                " FROM[adPWD_DomainController] as dc" +
                " left join[adPWD_Domains] as d" +
                " on dc.DomainId = d.DomainID" +
                $" Where d.DomainName ='{strs}'";
            
            cmd.CommandText = sqlrd;

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter Dadap = new SqlDataAdapter();
            Dadap.SelectCommand = cmd;

            DataSet ds = new DataSet();

            Dadap.Fill(ds, "[adPWDSync].[dbo].[adPWD_DomainController]");
            con.Close();
            return ds;
        }

        
        public static DataSet DomainControllerList()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            string sqlrd = $"SELECT d.DomainName, dc.ControllerName as "+ "'DC Name'" +
                ", dc.ControllerIP as " +"'DC IP'" +", dc.ServerIP as " +"' PWDManager Server IP'"+", dc.InBoundCycle as "+ "'Hearbeat Cycle(inbound) / Sec'"+
                ", dc.OutBoundCycle as " + "'Hearbeat Cycle(outbound) / Sec'"+", dc.InBoundTime as "+"'Hearbeat Time(inbound) / Sec'" +",dc.OutBoundTime as "+"'Hearbeat Tiime(outbound) / Sec'"+
                ", dc.OutBoundFailCnt as "+"'Heartbeat Fail Count '"+", dc.version FROM adPwd_Domains as d ,adPwd_DomainController as dc where d.DomainID = dc.DomainID;";

            cmd.CommandText = sqlrd;

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter Dadap = new SqlDataAdapter();
            Dadap.SelectCommand = cmd;

            DataSet ds = new DataSet();

            Dadap.Fill(ds, "[adPWDSync].[dbo].[adPWD_DomainController]");
            con.Close();
            return ds;
        }
        public static DataSet DomainControllerSetting(string key)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            string sqlrd = $"SELECT d.DomainName, dc.ControllerName as " + "'DC Name'" +
                ", dc.ControllerIP as " + "'DC IP'" + ", dc.ServerIP as " + "' PWDManager Server IP'" + ", dc.InBoundCycle as " + "'Hearbeat Cycle(inbound) / Sec'" +
                ", dc.OutBoundCycle as " + "'Hearbeat Cycle(outbound) / Sec'" + ", dc.InBoundTime as " + "'Hearbeat Time(inbound) / Sec'" + ",dc.OutBoundTime as " + "'Hearbeat Tiime(outbound) / Sec'" +
                ", dc.OutBoundFailCnt as " + "'Heartbeat Fail Count '" + ", dc.version FROM adPwd_Domains as d ,adPwd_DomainController as dc where d.DomainID = dc.DomainID" +
                $" and d.DomainName = '{key}';";

            cmd.CommandText = sqlrd;

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter Dadap = new SqlDataAdapter();
            Dadap.SelectCommand = cmd;

            DataSet ds = new DataSet();

            Dadap.Fill(ds, "[adPWDSync].[dbo].[adPWD_DomainController]");
            con.Close();
            return ds;
        }
        public static void DomainControllerSetting_Update(string [] dtlst)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            string sqlrd = $"  UPDATE  [adPWD_DomainController] SET InBoundCycle = {dtlst[4]} ,OutBoundCycle = {dtlst[5]} FROM [adPWD_DomainController] as dc left join adPWD_Domains as d " +
                $"on dc.DomainID = d.DomainID" +
                $" Where d.DomainName = '{dtlst[0]}'";

            cmd.CommandText = sqlrd;

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter Dadap = new SqlDataAdapter();
            Dadap.SelectCommand = cmd;

            DataSet ds = new DataSet();

            Dadap.Fill(ds, "[adPWDSync].[dbo].[adPWD_DomainController]");
            con.Close();
        }
        public static DataSet DomainListDetails(string key)
        {
            string sqlrd = "";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            sqlrd = $"SELECT DomainName ," +
            $"(CASE WHEN SyncType = '1' THEN 'Local'" +
            $" WHEN SyncType = '2' THEN 'Global AD' END)" +
            $"  AS SyncType,orderCycle,lastInventoryTime, SyncType as SyncTypeNum FROM adPWD_Domains " +
            $"where DomainName = '{key}'";
                
            cmd.CommandText = sqlrd;

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter Dadap = new SqlDataAdapter();
            Dadap.SelectCommand = cmd;

            DataSet ds = new DataSet();

            Dadap.Fill(ds, "[adPWDSync].[dbo].[adPWD_Domains]");
            con.Close();
            return ds;
        }
        public static void DomainListDetailsUpdate(string[] dtlst)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            string sqlrd = $" UPDATE adPWD_Domains SET SyncType = {Int32.Parse(dtlst[4])} , orderCycle = {dtlst[2]} FROM adPWD_Domains where DomainName = '{dtlst[0]}'";

            cmd.CommandText = sqlrd;

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter Dadap = new SqlDataAdapter();
            Dadap.SelectCommand = cmd;

            DataSet ds = new DataSet();

            Dadap.Fill(ds, "[adPWDSync].[dbo].[adPWD_Domains]");
            con.Close();
        }
        public static DataSet ServerList()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            string sqlrd = $" SELECT ServerName, ServerIP,ServerPort,lastInventoryTime, InBoundCycle, InBoundTime, OutBoundTime,OutBoundFailCnt FROM[adPWD_Servers]";

            cmd.CommandText = sqlrd;

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter Dadap = new SqlDataAdapter();
            Dadap.SelectCommand = cmd;

            DataSet ds = new DataSet();

            Dadap.Fill(ds, "[adPWDSync].[dbo].[adPWD_Servers]");
            con.Close();

            return ds;
        }


        public static DataSet ServerDetails(string key, string key2)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            string sqlrd = $" SELECT ServerName, ServerIP,ServerPort,lastInventoryTime, InBoundCycle, InBoundTime, OutBoundTime,OutBoundFailCnt FROM[adPWD_Servers] where ServerName ='{key}' and ServerIP = '{key2}' ";

            cmd.CommandText = sqlrd;

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter Dadap = new SqlDataAdapter();
            Dadap.SelectCommand = cmd;

            DataSet ds = new DataSet();

            Dadap.Fill(ds, "[adPWDSync].[dbo].[adPWD_Servers]");
            con.Close();

            return ds;
        }
        public static void ServerList_Update(string[] dtlst,string key)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string sqlrd = $" UPDATE [adPWD_Servers] SET ServerName ='{dtlst[0]}', ServerIP='{dtlst[1]}',ServerPort='{Int32.Parse(dtlst[2].ToString())}',InBoundCycle='{Int32.Parse(dtlst[4].ToString())}'  where ServerName ='{key}'";

            cmd.CommandText = sqlrd;

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter Dadap = new SqlDataAdapter();
            Dadap.SelectCommand = cmd;

            DataSet ds = new DataSet();

            Dadap.Fill(ds, "[adPWDSync].[dbo].[adPWD_Servers]");
            con.Close();
        }

    }
}
