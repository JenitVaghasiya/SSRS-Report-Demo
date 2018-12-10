using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


public partial class _Default : System.Web.UI.Page
{
    string Connectionstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
       
    }

    private void BindReport(string p, int p_2)
    {
        SSRSReport report = new SSRSReport();
        SqlParameter[] sqlParams = new SqlParameter[] {
         new SqlParameter("@Add_Source_Id", 25) ,
         new SqlParameter("@Add_Source_Type", "Employee")
      };

        string ReportDataSource = "DataSet1";
        bool bind = report.CreateReport(Connectionstring, "Get_Address_sp", sqlParams, ref ReportViewer1, ReportDataSource);
        if (bind)
        {
            ReportViewer1.Visible = true;
        }
    }

    protected void btndisplay_Click(object sender, EventArgs e)
    {
        BindReport("Employee", 14);
    }
}