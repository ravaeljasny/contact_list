namespace contact_list;

class Program
{
    public static void Main(string[] args)
    {

        ContactsDatabase contacts = new([]);
        ContactsHandler handler = new(contacts);

        handler.Add(new("Mom", "123 456 789", "mom@contact_list.com"));
        handler.Add(new("Dad", "987 654 321", "dad@contact_list.com"));

        handler.Display(contacts);
    }
}
