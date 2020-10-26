using System.Linq;
using System.Threading.Tasks;
using MedicineTracker.Models;

namespace MedicineTracker.Repositories.Interfaces
{
    public interface IMedicineRepository
    {
        Task<bool> Create(Medicine medicine);

        Task<bool> Update(Medicine medicine);

        Medicine Get(int Id);

        IOrderedQueryable<Medicine> GetAll();

        Task<bool> Delete(int Id);
    }
}
