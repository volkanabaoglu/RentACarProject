using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Drawing;

namespace Console
{
    public class Class1
    {
        public static void Main(string[] args)
        {
            CarJoinTest();


        }
        private static void CarJoinTest()
        {
            CarManger carManager = new CarManger(new EfCarDal());


            foreach (var item in carManager.GetCarDetails())
            {
                System.Console.WriteLine(item.BrandName + "  " + item.ColorName + "  " + item.DailyPrice);
            }
        }
    }
}