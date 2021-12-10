using Microsoft.AspNetCore.Mvc;
using uuf.PersonManagement.Logic;
using uuf.PersonManagement.Model;
using uuf.PersonManagement.Model.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace uuf.PersonManagement.Ui.Web.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        private Core _core;

        public EmployeeAPIController(IRepository repository)
        {
            _core = new Core(repository);
        }

        // GET: api/<EmployeeAPIController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _core.Repository.GetAll<Employee>();
        }

        // GET api/<EmployeeAPIController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _core.Repository.GetById<Employee>(id);
        }

        // POST api/<EmployeeAPIController>
        [HttpPost]
        public void Post([FromBody] Employee value)
        {
            _core.Repository.Add(value);
            _core.Repository.Save();
        }

        // PUT api/<EmployeeAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee value)
        {
            var loaded = Get(id);
            _core.Repository.Update(value);
            _core.Repository.Save();
        }

        // DELETE api/<EmployeeAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var loaded = Get(id);
            _core.Repository.Delete(loaded);
            _core.Repository.Save();
        }
    }
}
