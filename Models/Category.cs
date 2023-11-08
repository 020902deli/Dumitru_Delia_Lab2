namespace Dumitru_Delia_Lab2.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
