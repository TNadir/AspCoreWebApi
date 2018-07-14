using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.BO.Repositories;
using BackEnd.Data.Domen;
using BackEnd.Service.Interface;

namespace BackEnd.Service.Services
{
    public class BillService : IBillService
    {
        private readonly IRepository<Bill> repo;
        public BillService(IRepository<Bill> _repo)
        {
            this.repo = _repo;

        }
        public async Task<List<Bill>> GetBill()
        {
            return await this.repo.GetAllAsync();
        }
    }
}