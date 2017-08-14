using HMSMODEL;
using HospitalDLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace HospitalBLL
{
    public class HospitalComponents
    {

        HospitalHelper _hospitalhelper = new HospitalHelper();
        DataTable dt = new DataTable();
        SqlCommand cmd;
       

        public DataTable getTemplateData()
        {
            dt = _hospitalhelper.getData("select id ,Header ,LEFT(Description,200) as  Description from dbo.tbl_Template");
            if (dt.Rows.Count > 0)
            {

                return dt;
            }
            else
            {
                return dt;
            }

        }

        public bool tabEntery(Template temp)
        {
            //string query = "INSERT INTO tbl_Template(Header, Description,Status) VALUES(@Header, @Description,@Status)";
            cmd = new SqlCommand("sp_SaveTemplates");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Header", temp.Header);
            cmd.Parameters.AddWithValue("@Description", temp.Description);
            cmd.Parameters.AddWithValue("@Status", temp.Status);
            _hospitalhelper.DML(cmd);
            return true;
        }

        public bool editTemplate(Template temp)
        {
            cmd = new SqlCommand("sp_EditTemplates");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Header", temp.Header);
            cmd.Parameters.AddWithValue("@Description", temp.Description);
            cmd.Parameters.AddWithValue("@Status", temp.Status);
            cmd.Parameters.AddWithValue("@id", temp.id);
            _hospitalhelper.DML(cmd);
            return true;

        }
        public bool PatientEntry(PatientEntry patent)
        {
            patent.ID = Guid.NewGuid();
      
            cmd = new SqlCommand("SP_PatientEntry");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EntryId", patent.ID);
            cmd.Parameters.AddWithValue("@FirstName", patent.Description);
            cmd.Parameters.AddWithValue("@LastName", patent.LastName);
            cmd.Parameters.AddWithValue("@Age", patent.Age);
            cmd.Parameters.AddWithValue("@Address", patent.Address);
            cmd.Parameters.AddWithValue("@Description", patent.Description);
            cmd.Parameters.AddWithValue("@Date",DateTime.Today);
            cmd.Parameters.AddWithValue("@Opptype","Save");
           bool result= _hospitalhelper.DML(cmd);
            return result;
           

        }

    }
}
