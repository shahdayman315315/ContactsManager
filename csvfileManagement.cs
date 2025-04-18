using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager
{
    internal class csvfileManagement
    {
        public static void SavetoFile(Contact contact)
        {
            if (!File.Exists("file.csv"))
            {
                
                File.Create("file.csv").Close(); 
            }
            using (StreamWriter sw = new StreamWriter("file.csv", true))
            {
                sw.WriteLine($"{contact.Name},{contact.PhoneNumber},{contact.Email}");
            }
        }

        internal static List<Contact> ReadFromFile()
        {
            List<Contact> contacts = new List<Contact>();
            
            using (StreamReader sr = new StreamReader("file.csv"))
            {
                string line;
                while ((line = sr.ReadLine()) != null) {
                    string[] contactinfo = line.Split(',');
                    Contact contact = new Contact();
                    contact.Name = contactinfo[0];
                    contact.PhoneNumber = contactinfo[1];
                    contact.Email = contactinfo[2];
                    contacts.Add(contact);
                }
            }
            return contacts;
        }

        internal static void UpdateFile(List<Contact> contacts)
        {
            using (StreamWriter sw = new StreamWriter("file.csv",false))
            {
                foreach (var contact in contacts)
                {
                    sw.WriteLine($"{contact.Name},{contact.PhoneNumber},{contact.Email}");
                }
            }
        }
        
    }

}
