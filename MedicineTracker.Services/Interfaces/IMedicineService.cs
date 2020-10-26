using System.Linq;
using System.Threading.Tasks;
using MedicineTracker.Models;

namespace MedicineTracker.Services.Interfaces
{
    public interface IMedicineService
    {
        Task<Medicine> Create(Medicine medicine);

        Task<Medicine> Update(Medicine medicine);

        Medicine Get(int Id);

        IOrderedQueryable<Medicine> GetAll();

        Task<bool> Delete(int Id);
    }
}
