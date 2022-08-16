using AddressBookRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookUI
{
    public class ProgramUI
    {
        private readonly AddressBook_Repo _repo = new AddressBook_Repo();
        public void Run()
        {
            Seed();
            Menu();
        }

        private void Seed()
        {
            ContactCreate contact = new ContactCreate()
            {
                Name = "sdgfhg",
                Email = "Sfdgfhdgf@dfgf.dfgfdg"
            };
            _repo.AddContact(contact);
        }
        private void Menu()
        {
            Console.Clear();
            Console.WriteLine("Please select an option:\n" +
                "1. See a list of Contacts");

            string response = Console.ReadLine() ?? "";
            switch(response)
            {
                case "1":
                    ListAllContacts();
                    break;
                default:
                    break;
            }
        }

        private void ListAllContacts()
        {
            Console.Clear();
            foreach (Contact contact in _repo.ListAllContacts())
            {
                Console.WriteLine(
                    $"{contact.Id}: {contact.Name}\n" +
                    $"Email: {contact.Email}\n" +
                    $"Phone: {contact.Phone}\n" +
                    $"Address: {contact.Address}"
                );
            }
        }
    }
}
