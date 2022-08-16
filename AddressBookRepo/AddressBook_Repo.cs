namespace AddressBookRepo
{
    public class AddressBook_Repo
    {
        private int _index = 0;
        private readonly Dictionary<int, Contact> _book = new Dictionary<int, Contact>();

        // CRUD
        public void AddContact(Contact contact)
        {
            int id = _index;
            contact.Id = id;
            _book.Add(id, contact);
            _index++;
        }
        // OPTIONAL: Alternative with a Create model (better practice)
        public void AddContact(ContactCreate model)
        {
            Contact contact = new Contact();

            int id = _index;
            contact.Id = id;
            contact.Name = model.Name;
            contact.Address = model.Address;
            contact.Email = model.Email;
            contact.Phone = model.Phone;

            _book.Add(id, contact);

            _index++;
        }

        public List<Contact> ListAllContacts()
        {
            return _book.Values.OrderBy(c => c.Name).ToList();
        }

        public Contact? GetContactByEmail(string email) // this line will need to change a little
        {
            // Complete this method
            // Takes in an email address as a string
            // returns the first Contact found with that address
            Contact? possibleMatchingContact = _book.Values.FirstOrDefault(c => c.Email == email);
            return possibleMatchingContact;

            foreach (Contact ct in _book.Values)
            {
                if (ct.Email == email) return ct;
            }
            return null;
        }

        public List<Contact> GetAllContactsWithPhoneNumbers()
        {
            // 1. make an empty list
            //    foreach through the Values
            //    find the ones with phone numbers
            //    add them to a list
            List<Contact> contacts = new List<Contact>();
            foreach (Contact contact in _book.Values)
            {
                // if phone number exists
                if (contact.Phone != null)
                {
                    // add 
                    contacts.Add(contact);
                }
            }
            return contacts;

            // 2. (LINQ) use Where()
            return _book.Where(kv => kv.Value.Phone != null)
                        .Select(kv => kv.Value)
                        .ToList();

            return _book.Values.Where(c => c.Phone != null).ToList();
        }
        // Contact? is the return type, or output type
        public Contact? GetContactById(int id)
        {
            if (!_book.ContainsKey(id)) return null;
            return _book[id];

            if (_book.ContainsKey(id)) return _book[id];
            return null;
        }

        public Contact? GetContactByName(string name)
        {
            foreach (Contact contact in _book.Values)
            {
                if (contact.Name == name) return contact;
            }
            return null;

            return _book.Values.FirstOrDefault(c => c.Name == name);
        }

        // Update


        // Delete

    }
}