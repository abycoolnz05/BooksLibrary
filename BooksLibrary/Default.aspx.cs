using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BooksLibrary
{
    public partial class Default : System.Web.UI.Page          //Connection String to connect to the db
    {
        string connectionString = @"Data Source=ABHIMONIKA\SQLEXPRESS;Initial Catalog=BooksLibrary;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridviewBooks();                            //Functions
                PopulateGridviewStudents();
            }
        }

             void PopulateGridviewBooks()

        {
            DataTable dtbl = new DataTable();                                               //Datatable
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Books",sqlCon);    //Open Sql Connection
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                gvBooks.DataSource = dtbl;
                gvBooks.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvBooks.DataSource = dtbl;                                                  //Add rows to datatable
                gvBooks.DataBind();
                gvBooks.Rows[0].Cells.Clear();
                gvBooks.Rows[0].Cells.Add(new TableCell());
                gvBooks.Rows[0].Cells[0].Text = " No Data Found..!";
                gvBooks.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;

            }
            
        }

        protected void gvBooks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {                                                                             //Add new Rows to Books Db
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO Books(Title,Year,Author,Genre) VALUES (@Title,@Year,@Author,@Genre)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@Title", (gvBooks.FooterRow.FindControl("txtTitleFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Year", (gvBooks.FooterRow.FindControl("txtYearFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Author", (gvBooks.FooterRow.FindControl("txtAuthorFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Genre", (gvBooks.FooterRow.FindControl("txtGenreFooter") as TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        PopulateGridviewBooks();
                        lblSuccessMessage.Text = " New Record Added";
                        lblErrorMessage.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvBooks_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBooks.EditIndex = e.NewEditIndex;                                                     //Edit Rows  to Books Db
            PopulateGridviewBooks();
        }

        protected void gvBooks_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBooks.EditIndex = -1;                                                                 //Cancel Edit 
            PopulateGridviewBooks();
        }

        protected void gvBooks_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {              
                   using (SqlConnection sqlCon = new SqlConnection(connectionString))                //Update Rows in Books Db
                {
                        sqlCon.Open();
                        string query = "UPDATE Books SET Title=@Title, Year=@Year, Author=@Author, Genre=@Genre WHERE BooksID = @id";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@Title", (gvBooks.Rows[e.RowIndex].FindControl("txtTitle") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Year", (gvBooks.Rows[e.RowIndex].FindControl("txtYear") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Author", (gvBooks.Rows[e.RowIndex].FindControl("txtAuthor") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Genre", (gvBooks.Rows[e.RowIndex].FindControl("txtGenre") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvBooks.DataKeys[e.RowIndex].Value.ToString()));
                        sqlCmd.ExecuteNonQuery();
                        gvBooks.EditIndex = -1;
                        PopulateGridviewBooks();
                        lblSuccessMessage.Text = " Selected Rows Updated";
                        lblErrorMessage.Text = "";
                    }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvBooks_RowDeleting(object sender, GridViewDeleteEventArgs e)        //Delete Rows In Books Db
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE From Books  WHERE BooksID = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
  
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvBooks.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridviewBooks();
                    lblSuccessMessage.Text = " Selected Rows Deleted!";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        void PopulateGridviewStudents()

        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM Students", sqlCon);    //Students Db
                sqlData.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                gvStudents.DataSource = dtbl;
                gvStudents.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvStudents.DataSource = dtbl;
                gvStudents.DataBind();
                gvStudents.Rows[0].Cells.Clear();
                gvStudents.Rows[0].Cells.Add(new TableCell());
                gvStudents.Rows[0].Cells[0].Text = " No Data Found..!";
                gvStudents.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;

            }
        }

        protected void gvStudents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {           
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))              //Add rows in Students Db
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO Students(FirstName,LastName,Contact,Email) VALUES (@FirstName,@LastName,@Contact,@Email)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@FirstName", (gvStudents.FooterRow.FindControl("txtFirstNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@LastName", (gvStudents.FooterRow.FindControl("txtLastNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Contact", (gvStudents.FooterRow.FindControl("txtContactFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Email", (gvStudents.FooterRow.FindControl("txtEmailFooter") as TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        PopulateGridviewBooks();
                        lblSuccess.Text = " New Record Added";
                        lblError.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                lblSuccess.Text = " New Row Inserted";
                lblError.Text = ex.Message;
            }
        }

        protected void gvStudents_RowEditing(object sender, GridViewEditEventArgs e)        //Select Rows to Edit
        {
            gvStudents.EditIndex = e.NewEditIndex;
            PopulateGridviewStudents();
        }

        protected void gvStudents_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)  //Cancel Row Editing
        {
            gvStudents.EditIndex = -1;
            PopulateGridviewStudents();
        }

        protected void gvStudents_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))          //Update Selected Rows in Students db
                {
                    sqlCon.Open();
                    string query = "UPDATE Students SET FirstName=@FirstName, LastName=@LastName, Contact=@Contact, Email=@Email WHERE StudentID = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@FirstName", (gvStudents.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastName", (gvStudents.Rows[e.RowIndex].FindControl("txtLastName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Contact", (gvStudents.Rows[e.RowIndex].FindControl("txtContact") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email", (gvStudents.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvStudents.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvStudents.EditIndex = -1;
                    PopulateGridviewBooks();
                    lblSuccessMessage.Text = " Selected Rows Updated";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "";
                lblError.Text = ex.Message;
            }
        }

        protected void gvStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();                                                              //Delete From Students table in db
                    string query = "DELETE From Students  WHERE StudentID = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvStudents.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridviewStudents();
                    lblSuccess.Text = " Selected Rows Deleted!";
                    lblError.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "";
                lblError.Text = ex.Message;
            }
        }
    }




    

        
 
}
