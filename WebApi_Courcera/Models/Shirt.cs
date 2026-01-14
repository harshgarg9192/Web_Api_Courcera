namespace WebApi_Courcera.Models
{
    public class Shirt
    {
        public int Id;
        public string Name;
        public string color;
        public string gender;
        public double price;
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
