using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace DiscussionForum
{
    public partial class Home : System.Web.UI.Page
    {
        List<String> lista;

        protected void Page_Load(object sender, EventArgs e)
        {
            lista = new List<string>();

            lista.Add("Networks");
            lista.Add("OOP");
            lista.Add("SP");
            lista.Add("Shell");
            lista.Add("Discrete mathematics");
            lista.Add("Calculus");
            lista.Add("Web design");
            lista.Add("Web development");

            LoadCategories();

            if (!IsPostBack)
                LoadUsers();
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedUser(lstUsers.SelectedValue);
        }


        protected void LoadCategories()
        {



        }

        protected void LoadUsers()
        {
            lstUsers.Items.Clear();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            string sqlString = "SELECT UserID, Username, Fullname FROM Users ORDER BY UserID";
            SqlCommand comm = new SqlCommand(sqlString, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    ListItem element = new ListItem();
                    element.Text = reader["Fullname"].ToString() + " - " + reader["Username"].ToString();
                    element.Value = reader["UserID"].ToString();
                    lstUsers.Items.Add(element);
                }
                reader.Close();
            }
            catch (Exception err)
            {
                lblMessage.Text = err.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void SelectedUser(string ID)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            string sqlString = "SELECT * FROM Users WHERE UserID='" + ID + "'";
            SqlCommand comm = new SqlCommand(sqlString, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    txtPassword.Text = reader["Password"].ToString();
                    reader.Close();
                }
            }
            catch (Exception err)
            {
                lblMessage.Text = err.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "UPDATE Users SET " + "Password='" + txtPassword.Text + "' WHERE UserID='" + lstUsers.SelectedValue + "'";

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                lblMessage.Text = err.Message;
            }
            finally
            {
                conn.Close();
            }

            LoadUsers();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "INSERT INTO Users (Username, Password, Fullname) VALUES (@Username, @Password, @Fullname)";
            comm.Parameters.AddWithValue("@Username", txtUsername.Text);
            comm.Parameters.AddWithValue("@Password", txtPassword.Text);
            comm.Parameters.AddWithValue("@Fullname", txtFullname.Text);

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                lblMessage.Text = err.Message;
            }
            finally
            {
                conn.Close();
            }

            LoadUsers();
        }

        protected void ListBox1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}