namespace contact_list
{
    class ContactsHandler
    {
        public ContactsDatabase dbContext;

        public ContactsHandler(ContactsDatabase contacts)
        {
            dbContext = contacts;
        }

        public void Display(ContactsDatabase contacts)
        {
            foreach (var c in contacts.contacts.Where(c => !c.IsDeleted))
            {
                Console.WriteLine($"{c.Id}: {c.Name}, {c.PhoneNumber}, {c.Email}");
            }
        }

        public void Add(Contact contact)
        {
            var db = dbContext.contacts;

            // this should be incremented automatically from the real database
            contact.Id = db.Count + 1;

            db.Add(contact);
        }

        public void Remove(ContactsDatabase contacts, int id)
        {
            var db = contacts.contacts;
            var targetContact = db.FirstOrDefault(c => c.Id == id);
            if (targetContact == null) return;
            targetContact.IsDeleted = true;
            targetContact.DeletionTimestamp = DateTime.UtcNow;
        }
    }

    public class Contact(string name, string phoneNumber, string email)
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = name;
        public string PhoneNumber { get; set; } = phoneNumber;
        public string Email { get; set; } = email;
        public bool IsDeleted { get; set; } = false;
        // may a deletion time stamp
        public DateTime? DeletionTimestamp = null!;
    }

    public class ContactsDatabase
    {
        public List<Contact> contacts;
        public IEnumerator<Contact> GetEnumerator() => contacts.GetEnumerator();
        public ContactsDatabase(List<Contact> contacts) => this.contacts = contacts;
    }
}

