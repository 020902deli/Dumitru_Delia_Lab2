using Dumitru_Delia_Lab2.Models;

namespace Dumitru_Delia_Lab2.Models.ViewModels
{
    public class CategoriesIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
