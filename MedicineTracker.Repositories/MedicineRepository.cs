using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MedicineTracker.Context;
using MedicineTracker.Models;
using MedicineTracker.Repositories.Interfaces;

namespace MedicineTracker.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly IServiceScope _scope;
        private readonly MedicineDatabaseContext _databaseContext;

        public MedicineRepository(IServiceProvider services)
        {
            _scope = services.CreateScope();

            _databaseContext = _scope.ServiceProvider.GetRequiredService<MedicineDatabaseContext>();
        }

        public async Task<bool> Create(Medicine medicine)
        {
            var success = false;

            _databaseContext.Medicines.Add(medicine);

            var numberOfItemsCreated = await _databaseContext.SaveChangesAsync();

            if (numberOfItemsCreated == 1)
                success = true;

            return success;
        }

        public async Task<bool> Update(Medicine medicine)
        {
            var success = false;

            var existingBlogPost = Get(medicine.Id);

            if (existingBlogPost != null)
            {
                existingBlogPost.Name = medicine.Name;
                existingBlogPost.Brand = medicine.Brand;
                existingBlogPost.Quantity = medicine.Quantity;
                existingBlogPost.Price = medicine.Price;
                existingBlogPost.ExpiryDate = medicine.ExpiryDate;
                existingBlogPost.Text = medicine.Text;

                _databaseContext.Medicines.Attach(existingBlogPost);

                var numberOfItemsUpdated = await _databaseContext.SaveChangesAsync();

                if (numberOfItemsUpdated == 1)
                    success = true;
            }

            return success;
        }

        public Medicine Get(int Id)
        {
            var result = _databaseContext.Medicines
                                .Where(x => x.Id == Id)
                                .FirstOrDefault();

            return result;
        }

        public IOrderedQueryable<Medicine> GetAll()
        {
            var result = _databaseContext.Medicines
                                .OrderByDescending(x => x.Name);

            return result;
        }

        public async Task<bool> Delete(int Id)
        {
            var success = false;

            var existingBlogPost = Get(Id);

            if (existingBlogPost != null)
            {
                _databaseContext.Medicines.Remove(existingBlogPost);

                var numberOfItemsDeleted = await _databaseContext.SaveChangesAsync();

                if (numberOfItemsDeleted == 1)
                    success = true;
            }

            return success;
        }
    }
}
