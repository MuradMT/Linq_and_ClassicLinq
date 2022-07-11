using System.Collections;

namespace LearningPath
{
   
    public static class String
    {
        public static string MyExtension(this string x,int y)
        {
            x= x.ToUpper()+y;
            return x;
        }
    }
    public class Car
    {
        //Id, BrandId, ColorId, ModelYear, DailyPrice, Description 
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public DateTime ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; }
    }
    public class CarDto
    {
        public int Id { get; set; }
        public double DailyPrice { get; set; }
        public string Category { get; set; }
    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           

            List<Car> _cars;
            _cars = new List<Car>()
            {
                new Car(){Id=1,BrandId=1,DailyPrice=100,ColorId=1,Description="Mercedes",
                ModelYear=new DateTime(1955,12,6)},
                new Car(){Id=2,BrandId=2,DailyPrice=150,ColorId=2,Description="Ferrari",
                ModelYear=new DateTime(1935,2,16)},
                new Car(){Id=2,BrandId=2,DailyPrice=200,ColorId=2,Description="Lamborgini",
                ModelYear=new DateTime(1965,8,5)},
                new Car(){Id=4,BrandId=4,DailyPrice=300,ColorId=3,Description="Bugatti",
                ModelYear=new DateTime(1925,3,9)},
            };
            List<Category> _categories;
            _categories = new List<Category>()
            {
            new Category() {Id=1, Name="alem"},
            new Category() {Id=2, Name="balem"},
            new Category() {Id=3, Name="calem"}
            };
             
            //var res= _cars.FindAll(p => p.ModelYear > new DateTime(100,1,1)).OrderBy(p=>
            //p.Id).OrderByDescending(p=>p.Description);
            var detail = from p in _cars join c in _categories on p.Id equals c.Id
                         where p.ModelYear > new DateTime(100, 1, 1)
                         orderby p.Id
                         select new CarDto()
                         {DailyPrice=p.DailyPrice,Id=p.Id,Category=c.Name}
                         ;
            foreach (var item in detail)
            {
                Console.WriteLine(item.Category);
            }
            
                     


            //Console.WriteLine(  res.Description);

        }
    }
}