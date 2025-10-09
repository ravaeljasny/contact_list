namespace contactlist.Logic;

public class Contact(string name, string phoneNumber, string email)
{
  // may a deletion time stamp
  public DateTime? DeletionTimestamp = null!;

  public int Id { get; set; }

  public string Name { get; set; } = name;

  public string PhoneNumber { get; set; } = phoneNumber;

  public string Email { get; set; } = email;

  public bool IsDeleted { get; set; }
}
