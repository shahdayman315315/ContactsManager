using System.Security.Cryptography.X509Certificates;

namespace ContactsManager
{
    internal class Program
    {
        public static string csvfile = "file.csv";
        static void Main(string[] args)
        {

            while (true)
            {
                Showoptions();
                int selection=int.Parse(Console.ReadLine());
                switch (selection) {

                    case 1:
                        ContactsManagment.AddContact();
                        break;
                    case 2:
                        ContactsManagment.EditContact();
                        break;
                    case 3:
                        ContactsManagment.DeleteContact();
                        break;
                    case 4:
                        ContactsManagment.ViewContacts();
                        break;
                    case 5:
                        Logger.ReadLog();
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        return;


                }
            }


        }

        public static void Showoptions()
        {
            Console.WriteLine("select what you want:\n 1.Add Contact \n 2.Edit Contact \n 3.Delete Conatact \n 4.View Conatcts \n 5.View Log file \n 6.Exit");
        }

       
    
    }

    

    
   


}
