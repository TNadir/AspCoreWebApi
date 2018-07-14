using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Data.Domen;
using BackEnd.Service.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("AllowAnyOrigin")]
    public class BillController : Controller
    {
        private readonly IBillService billService;

        public BillController(IBillService billService)
        {
            this.billService = billService;
        }

        
        [HttpGet]
        [ActionName("all")]
        public async Task<ActionResult> Get()
        {
            return Ok(await this.billService.GetBill());
        }


    }
}