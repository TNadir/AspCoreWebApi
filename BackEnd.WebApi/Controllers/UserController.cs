using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Data.Domen;
using BackEnd.Service.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("AllowAnyOrigin")]
    public class UserController : Controller
    {
        private readonly IUser userService;
        public UserController(IUser userService)
        {
            this.userService = userService;

        }
        // GET api/user
        [HttpGet]
        [ActionName("all")]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.userService.GetAll());
        }

        [HttpGet]
        [ActionName("finduser")]
        public async Task<IActionResult> FindUser(string email, string password)
        {
            var list = await this.userService.FindBy(x => x.Email == email && x.Password == password);
            return Ok(list);
        }

        [HttpGet]
        [ActionName("validateuser")]
        public async Task<IActionResult> ValidateUser(string email)
        {
            var list = await this.userService.FindBy(x => x.Email == email);
            return Ok(list);
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await this.userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST api/user
        [HttpPost]
        [ActionName("adduser")]
        public async Task<IActionResult> Post([FromBody]Users user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usr = await this.userService.Insert(user);

            // return CreatedAtAction("asdasd", new { id = usr.Id }, usr);
            return Ok(usr);
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
