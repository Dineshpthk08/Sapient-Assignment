using System;

namespace MedicineTracker.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Text { get; set; }
    }
}
