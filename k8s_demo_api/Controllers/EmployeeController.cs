using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k8s_demo_api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace k8s_demo_api.Controllers {
    [Route("api/[controller]")]
    public class EmployeeController : Controller {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Employee> Get() {
            return GetEmployees();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Employee Get(int id) {
            return GetEmployees().FirstOrDefault(v => v.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Employee value) {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee value) {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }


        private IEnumerable<Employee> GetEmployees() {
            return JsonConvert.DeserializeObject<IEnumerable<Employee>>(System.IO.File.ReadAllText("./TestData/employee.json"));
        }
    }
}
