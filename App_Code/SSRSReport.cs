using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

/// <summary>
/// Summary description for SSRSReport
/// </summary>
public class SSRSReport
{
    

	public SSRSReport()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool CreateReport(String Connectionstring,string StoreProcedureName ,SqlParameter[] Parameter,ref  Microsoft.Reporting.WebForms.ReportViewer ReportViewer,string ReportDataSource)
    {
        bool reportbind = false;
        using (SqlConnection con = new SqlConnection(Connectionstring))
        {
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = StoreProcedureName;
            com.Parameters.AddRange(Parameter);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(ds);
            ReportDataSource datasource = new ReportDataSource(ReportDataSource, ds.Tables[0]); 
            if ( ds.Tables[0].Rows.Count > 0)
            {
                ReportViewer.LocalReport.DataSources.Clear();
                ReportViewer.LocalReport.DataSources.Add(datasource);
                reportbind = true;
            }                       
        }
       return  reportbind;
    }

}