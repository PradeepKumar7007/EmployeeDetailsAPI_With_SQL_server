using System.Data;
using System.Data.SqlClient;

namespace CreateAPI.Model
{
    public class DAL
    {
        #region GetAllEmployees
        public Response GetAllEmployees(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tblCrudNetCore", connection);
            DataTable dt = new DataTable();
            List<Employee> lstEmployees = new List<Employee>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee emp = new Employee();
                    emp.Id = Convert.ToInt32(dt.Rows[i]["ID"]);
                    emp.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    emp.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    emp.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    lstEmployees.Add(emp);
                }
            }
            if (lstEmployees.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.lstEmployee = lstEmployees;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.lstEmployee = null;
            }
            return response;
        }
        #endregion
        #region GetAllEmployeeByID
        public Response GetAllEmployeeById(SqlConnection connection, int id)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tblCrudNetCore where ID = '"+id+"' and IsActive = 1", connection);
            DataTable dt = new DataTable();
            Employee Employees = new Employee();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Employee emp = new Employee();
                emp.Id = Convert.ToInt32(dt.Rows[0]["ID"]);
                emp.Name = Convert.ToString(dt.Rows[0]["Name"]);
                emp.Email = Convert.ToString(dt.Rows[0]["Email"]);
                emp.IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"]);
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.Employee = emp;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.Employee = null;
            }
            return response;
        }
        #endregion
        #region AddEmployees
        public Response AddEmployee(SqlConnection connection, Employee employee)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Insert into tblCrudNetCore (Name, Email, IsActive, CreatedOn) values ('"+employee.Name+ "', '" + employee.Email + "', '" + employee.IsActive + "', GETDATE())", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Employee Added Successfully.";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Inserted.";
            }
            return response;
        }
        #endregion
        #region UpdateEmployees
        public Response UpdateEmployee(SqlConnection connection, Employee employee)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Update tblCrudNetCore SET Name = '" + employee.Name + "', Email = '" + employee.Email +"' where ID = '" + employee.Id + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Employee Updated Successfully.";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Updated.";
            }
            return response;
        }
        #endregion
        #region DeleteEmployees
        public Response DeleteEmployee(SqlConnection connection, int id)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Delete from tblCrudNetCore where ID = '"+ id +"'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Employee Deleted.";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Employee Deleted.";
            }
            return response;
        }
        #endregion
    }
}
