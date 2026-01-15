using System.ComponentModel.DataAnnotations;

namespace WebApi_Courcera.Models
{
    public class Shirt
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Color { get; set; }
        public string Gender { get; set; }
        [PriceValidation]
        public decimal Price { get; set; }
        //public static Shirt GetShirt(int? id,string? name,double)
        //{

        //}
        public static Shirt GetShirtID(int id)
        {
            var shirts = ShirtStore.Shirts;
            if (id < 0 && id > shirts.Count)
            {
                return null;
            }
            var shirt = shirts.FirstOrDefault(s => s.Id == id);
            return shirt;
        }
    }
}
