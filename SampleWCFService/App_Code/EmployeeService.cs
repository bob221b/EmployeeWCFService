using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for EmployeeService
/// </summary>
public class EmployeeService : IEmployeeService
{
    string constr = ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString;
    SqlConnection con;
    //SqlDataReader r;
    SqlCommand cmd;
    SqlDataAdapter dap;
    DataTable Table = new DataTable("EmployeeTable");
    public string selectqueryfull;
    LogFile log = new LogFile();
    public EmployeeService()
    {
       
    }
    public void connection()
    {
        con = new SqlConnection(constr);
        con.Open();
    }

    public string GetData()
    {
        log.WriteToFile("Service Called at: " + DateTime.Now+"\n");
        connection();
        selectqueryfull = ConfigurationManager.AppSettings["SelectQuery"].ToString();
        cmd = new SqlCommand(selectqueryfull, con);
        dap = new SqlDataAdapter(cmd);
        dap.Fill(Table);
        con.Close();
       // log.WriteToFile
        return dumpTableData(Table);   
    }
    public string dumpTableData(DataTable table)
    {

        string data = string.Empty;
        StringBuilder sb = new StringBuilder();

        if (null != table && null != table.Rows)
        {
            foreach (DataRow dataRow in table.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    sb.Append(item);
                    sb.Append(',');
                }
                sb.AppendLine();
            }

            data = sb.ToString();
        }
        return data;
    }
}