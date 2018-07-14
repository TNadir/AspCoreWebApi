using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Data.Domen;

namespace BackEnd.Service.Interface
{
    public interface IBillService
    {
        Task<List<Bill>> GetBill();
    }
}