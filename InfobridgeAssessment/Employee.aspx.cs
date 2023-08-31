using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InfobridgeAssessment
{
    public partial class Employee : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;

        public Employee()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            con = new SqlConnection(connectionString);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                string name = txtName.Text;
                string sex = txtSex.Text; 
                string phone = txtPhone.Text;
                string address = txtAdd.Text;
                string dob = txtDob.Text;
                
  
                    //image = Path.GetFileName(txtUploadImg.FileName);
                    //string imagePath = Server.MapPath("~/Images/") + image;
                    //txtUploadImg.SaveAs(imagePath);

                    string image = Path.GetFileName(txtUploadImg.FileName);
                    txtUploadImg.SaveAs(Server.MapPath("Images/") + image);
                

                string qry = "INSERT INTO Employee (Id, Name, DateofBirth, Sex, Phone, Address, Image) VALUES (@Id, @Name, @DateofBirth, @Sex, @Phone, @Address, @Image)";
                cmd = new SqlCommand(qry, con);

                    con.Open();

                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@DateofBirth", dob);
                        cmd.Parameters.AddWithValue("@Sex", sex);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@Address", address);
                        cmd.Parameters.AddWithValue("@Image", image);

                      cmd.ExecuteNonQuery();
                    con.Close();

                msgBox.Text="Data is Added";
                GetEmployees();
            }
            catch (Exception ex)
            {
                msgBox.Text= "Error in add:- " + ex.Message;
            }
        }

        void GetEmployees()
        {

            string qry = "SELECT * FROM Employee";
            cmd = new SqlCommand(qry, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {

                int id = int.Parse(txtId.Text);
                string qry = "SELECT * FROM Employee WHERE @Id=id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Clear_Form();
            }
            catch (Exception ex)
            {
               msgBox.Text= "Error in View:- " + ex.Message;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                int id = int.Parse(txtId.Text);
                string name = txtName.Text, sex =txtSex.Text, phone = txtPhone.Text, address = txtAdd.Text, dob = txtDob.Text,
                image = txtUploadImg.FileName;
                string qry = "Update Employee set name=@Name,DateofBirth=@DateofBirth,sex=@Sex,phone=@Phone,address=@address,image=@Image where @Id=id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@DateofBirth", dob);
                cmd.Parameters.AddWithValue("@Sex", sex);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Image", image);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                msgBox.Text="Updated Successfully";
                GetEmployees();
                Clear_Form();

            }
            catch (Exception ex)
            {
                msgBox.Text= "Error in Edit:- " + ex.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                int id = int.Parse(txtId.Text);
                string qry = "Delete Employee Where @Id=id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();
                msgBox.Text = "Successfully Deleted";

                GetEmployees();
                Clear_Form();
            }
            catch (Exception ex)
            {
               msgBox.Text= "Error in Delete:- " + ex.Message;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void Clear_Form()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtSex.Text = "";
            txtPhone.Text = "";
            txtDob.Text = "";
            txtAdd.Text = "";
            msgBox.Text = "";
        }
    }
}