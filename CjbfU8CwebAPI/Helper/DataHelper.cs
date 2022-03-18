using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
namespace CjbfU8CwebAPI.Helper
{
    public static class DataHelper
    {
        public static string getStrResultFromSQLscript(string sql, string strType)//从数据库查询返回字段值
        {
            string strResult = "";
            int iResult = 0;
            OleDbConnection conn = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["U8Cloud"].ConnectionString;
                conn.ConnectionString = connString;
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                if (strType == "reader")//get reader
                {
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        strResult = dr[0].ToString();
                    }
                    dr.Close();
                    dr.Dispose();
                }
                else if (strType == "nonquery")//exec update insert delete
                {
                    iResult = cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                LogHelper.Default.WriteInfo( sql);
                LogHelper.Default.WriteError("DataHelper", ex);
            }
            finally
            {
                conn.Close();
            }
            return strResult;
        }

        public static DataTable getDataTableFromSql(string sql)//从数据库查询返回数据表
        {
            DataTable dtResult = null;
            OleDbConnection conn = new OleDbConnection();
            
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["U8Cloud"].ConnectionString;
                conn.ConnectionString = connString;
                conn.Open();
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(sql,conn);
                DataSet dsResult = new DataSet();
                myDataAdapter.Fill(dsResult, "result");
                dtResult = dsResult.Tables[0];
            }
            catch (Exception ex)
            {
                LogHelper.Default.WriteInfo(sql);
                LogHelper.Default.WriteError("DataHelper", ex);
                dtResult = null;
            }
            finally
            {
                conn.Close();
            }
            return dtResult;
        }

    }
}