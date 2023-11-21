using HotelProject.BL.Model;
using HotelProject.DL.Repositories;

namespace ConsoleAppTestDL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //test if getallregistrations works
            RegistrationRepositoryADO registrationRepositoryADO = new RegistrationRepositoryADO(@"Data Source=Daniel\SQLEXPRESS;Initial Catalog=HotelDonderdag;Integrated Security=True");
            foreach (var item in registrationRepositoryADO.GetAllRegistrations())
            {
                System.Console.WriteLine(item.ToString());
            }

        }
    }
}