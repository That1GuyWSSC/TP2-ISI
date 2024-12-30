
namespace ClienteBasico.Models
{

    public class Product
    {
    
        public long Id { get; set; }

  
        public  string Name { get; set; }

     
        public string Description { get; set; }

     
        public double Price { get; set; }

      
        public long Category_Id { get; set; }

       
        public bool Is_Active { get; set; }
    }
}
