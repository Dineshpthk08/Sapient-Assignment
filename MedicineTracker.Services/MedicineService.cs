using System;
using System.Linq;
using System.Threading.Tasks;
using MedicineTracker.Models;
using MedicineTracker.Repositories.Interfaces;
using MedicineTracker.Services.Interfaces;

namespace MedicineTracker.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _repository;

        public MedicineService(IMedicineRepository repository)
        {
            _repository = repository;
        }

        public async Task<Medicine> Create(Medicine medicine)
        {
            var success = await _repository.Create(medicine);

            if (success)
                return medicine;
            else
                return null;
        }

        public async Task<Medicine> Update(Medicine medicine)
        {
            var success = await _repository.Update(medicine);

            if (success)
                return medicine;
            else
                return null;
        }

        public Medicine Get(int Id)
        {
            var result = _repository.Get(Id);

            return result;
        }

        public IOrderedQueryable<Medicine> GetAll()
        {
            var result = _repository.GetAll();

            return result;
        }


        public async Task<bool> Delete(int id)
        {
            var success = await _repository.Delete(id);

            return success;
        }
    }
}
