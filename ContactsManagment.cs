using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ContactsManager
{
    internal class ContactsManagment
    {
        public static void AddContact()
        {
            Contact contact = new Contact();
            Console.WriteLine("Enter Name:");
            contact.Name = Console.ReadLine();
            Console.WriteLine("Enter Phone Number:");
            contact.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Email:");
            contact.Email = Console.ReadLine();
            List<Contact> contacts = csvfileManagement.ReadFromFile();
            Contact contactFound = contacts.FirstOrDefault(c => c.Name.Equals(contact.Name, StringComparison.OrdinalIgnoreCase));
            if (contactFound == null)
            {
                csvfileManagement.SavetoFile(contact);
                Logger.log("New contact has been added.");

            }
            else
            {
                Console.WriteLine("Contact already Exists.");
            }
        }

        public static void EditContact()
        {
            Console.WriteLine("Enter the name of the contact you want to edit:");
            string name = Console.ReadLine();
            List<Contact> contacts = csvfileManagement.ReadFromFile();
            Contact contactToEdit = contacts.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (contactToEdit != null)
            {
                Console.WriteLine("Enter new Phone Number:");
                contactToEdit.PhoneNumber = Console.ReadLine();
                Console.WriteLine("Enter new Email:");
                contactToEdit.Email = Console.ReadLine();
                csvfileManagement.UpdateFile(contacts);
                Logger.log("Contact has been Edited");

            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
        public static void DeleteContact()
        {
            Console.WriteLine("Enter The Name of The Conatct You want to Delete");
            string name = Console.ReadLine();
            List<Contact> contacts = csvfileManagement.ReadFromFile();
            Contact contactToDelete = contacts.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (contactToDelete != null)
            {
                contacts.Remove(contactToDelete);
                csvfileManagement.UpdateFile(contacts);
                Console.WriteLine("Contact Deleted Successfully.");
                Logger.log("Contact has been Deleted");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }


        }

        public static void ViewContacts()
        {
            List<Contact> contacts = csvfileManagement.ReadFromFile();
            if(contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }
            foreach (Contact contact in contacts)
            {
                Console.WriteLine($"Name: {contact.Name}, Phone Number: {contact.PhoneNumber}, Email: {contact.Email}");
            }
        }
       
    }
    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
    public class Logger
    {
        public static string logfile = "log.txt";
        public static void log(string message)
        {
            if (!File.Exists(logfile))
            {
                File.Create(logfile).Close();
            }
            using (StreamWriter sw = new StreamWriter(logfile, true))
            {
                sw.WriteLine($"{DateTime.Now}: {message}");
            }
        }
        public static void ReadLog()
        {
            List<string> logs = new List<string>();
            using(StreamReader sr = new StreamReader(logfile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    logs.Add(line);
                }
            }
            foreach (var log in logs)
            {
                Console.WriteLine(log);
            }
        }
    } 
    
}