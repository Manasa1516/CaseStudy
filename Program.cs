using CarRentalSystem;
using CarRentalSystem.Exceptions;
using CarRentalSystem.model;
using CarRentalSystem.Repository;
using CarRentalSystem.Service;
class Program
{
    static void Main(string[] args)
    {
        ICarLeaseService userService = new CarLeaseService();
        bool exit = false;

        while (!exit)
        {
            string menu = "\n \n Press1:: Car Management \n Press2::Customer Management \n Press3::Lease Management \n Press4::Payment Handling \n Press0::Exit";
            Console.WriteLine(" \n Welcome To Our Car Rental System choose from the Below options To continue");
            Console.WriteLine(menu);
            Console.WriteLine("Enter your choice");
            int choice = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (choice)
            {
                case 0:
                    exit = true;
                    break;

                case 1:
                    string menu1 = "\n Press1:: Add Car \n Press2::Remove Car \n Press3::List Available Cars \n Press4::List Rented Cars\n Press5::Find Car By Id \n Press0::Back to Main Menu";
                    Console.WriteLine(menu1);
                    Console.WriteLine("Enter your choice");
                    int choice1 = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (choice1)
                    {
                        case 0:
                            break;

                        case 1:
                            userService.RegisterVehicle();
                            break;
                        case 2:
                            userService.RemoveVehicle();
                            break;
                        case 3:
                            userService.GetAllVehicles();
                            break;
                        case 4:
                            userService.GetAllRentedVehicles();
                            break;
                        case 5:
                            userService.FindVehicleById();
                            break;

                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                    break;

                case 2:
                    string menu2 = "\n Press1:: Add Customer \n Press2::Remove Customer \n Press3::List Customers \n Press4::Find Customer By Id \n Press0::Back to Main Menu";
                    Console.WriteLine(menu2);
                    Console.WriteLine("Enter your choice");
                    int choice2 = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (choice2)
                    {
                        case 0:
                            break;

                        case 1:
                            userService.AddCustomer();
                            break;
                        case 2:
                            userService.RemoveCustomer();
                            break;
                        case 3:
                            userService.GetAllCustomers();
                            break;
                        case 4:
                            userService.FindCustomersById();
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                    break;

                case 3:
                    string menu3 = "\n Press1:: Create Lease \n Press2::Get Lease Info \n Press3::List Active Leases \n Press4::List Lease History \n Press0::Back to Main Menu";
                    Console.WriteLine(menu3);
                    Console.WriteLine("Enter your choice");
                    int choice3 = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (choice3)
                    {
                        case 0:
                            break;

                        case 1:
                            userService.AddLease();
                            break;
                        case 2:
                            userService.FindLeaseById();
                            break;
                        case 3:
                            userService.GetActiveLeases();
                            break;
                        case 4:
                            userService.GetInActiveLeases();
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                    break;

                case 4:
                    string menu4 = "\n Press1:: Record Payment \n Press2::List Payments \n Press0::Back to Main Menu";
                    Console.WriteLine(menu4);
                    Console.WriteLine("Enter your choice");
                    int choice4 = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (choice4)
                    {
                        case 0:
                            break;

                        case 1:
                            userService.AddPayment();
                            break;
                        case 2:
                            userService.GetAllPayments();
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }

    }

}