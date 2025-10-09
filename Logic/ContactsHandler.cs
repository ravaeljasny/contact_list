namespace contactlist.Logic;

using System.Collections.ObjectModel;

public class ContactsDatabase(Collection<Contact> contacts)
{
  public Collection<Contact> Contacts = contacts;

  public IEnumerator<Contact> GetEnumerator() => this.Contacts.GetEnumerator();
}

public class ContactsHandler(ContactsDatabase contacts)
{
  private ContactsDatabase dbContext = contacts;

  public static void Remove(ContactsDatabase contacts, int id)
  {
    var db = contacts;
    var targetContact = db.Contacts.FirstOrDefault(c => c.Id == id);
    if (targetContact == null)
    {
      return;
    }

    targetContact.IsDeleted = true;
    targetContact.DeletionTimestamp = DateTime.UtcNow;
  }

  public void Display(ContactsDatabase contacts)
  {
    foreach (var c in contacts.Contacts.Where(c => !c.IsDeleted))
    {
      Console.WriteLine($"{c.Id}: {c.Name}, {c.PhoneNumber}, {c.Email}");
    }
  }

  public void Add(Contact contact)
  {
    var db = this.dbContext.Contacts;

    // this should be incremented automatically from the real database
    contact.Id = db.Count + 1;

    db.Add(contact);
  }
}
