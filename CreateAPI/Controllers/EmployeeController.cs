using CreateAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CreateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllEmployees")]
        public Response GetAllEmployees()
        {
            SqlConnection sc = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetAllEmployees(sc);
            return response;
        }
        [HttpGet]
        [Route("GetAllEmployeeById/{id}")]
        public Response GetAllEmployeeById(int id)
        {
            SqlConnection sc = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetAllEmployeeById(sc, id);
            return response;
        }
        [HttpPost]
        [Route("AddEmployee")]
        public Response AddEmployee(Employee employee)
        {
            SqlConnection sc = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.AddEmployee(sc, employee);
            return response;
        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public Response UpdateEmployee(Employee employee)
        {
            SqlConnection sc = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.UpdateEmployee(sc, employee);
            return response;
        }
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public Response DeleteEmployee(int id)
        {
            SqlConnection sc = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.DeleteEmployee(sc, id);
            return response;
        }
    }
}
