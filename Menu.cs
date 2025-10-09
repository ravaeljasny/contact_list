namespace ContactList
{
  internal static class Menu
  {
    public static void ShowMenu()
    {
      string userChoice;
      ContactsDatabase contacts = new([]);
      ContactsHandler handler = new(contacts);

      var exit = string.Empty;
      while (exit != "exit")
      {
        Console.WriteLine("Contact List Menu:");
        Console.WriteLine("1. View Contacts");
        Console.WriteLine("2. Add Contact");
        Console.WriteLine("3. Remove Contact");
        Console.WriteLine("4. Exit");
        Console.Write("Choose an option (1-4): ");
        userChoice = Console.ReadLine();

        if (!int.TryParse(userChoice, out int choice))
        {
          Console.WriteLine("You need to type in a number.");
          Console.Write("Choose an option (1-4): ");
          userChoice = Console.ReadLine();
        }

        // === WIP: Do it later
        // if (choice < 1 || choice > 5)
        // {
        //    Console.WriteLine("You need to choose between 1 and 5.");
        //    Console.Write("Choose an option (1-5): ");
        //    userChoice = Console.ReadLine();
        // }
        switch (choice)
        {
          case 1:
            Console.WriteLine("View Contacts selected.");

            Console.WriteLine("=======================");
            handler.Display(contacts);
            Console.WriteLine("=======================");
            break;
          case 2:
            Console.WriteLine("Add Contact selected.");

            QueryContactData(contacts);
            break;
          case 3:
            Console.WriteLine("Delete Contact selected.");
            Console.Write("Enter Contact ID to delete: ");

            int id = Convert.ToInt16(Console.ReadLine());
            ContactsHandler.Remove(contacts, id);
            break;
          case 4:
            exit = "exit";
            break;
          default:
            break;
        }
      }
    }

    public static void QueryContactData(ContactsDatabase contacts)
    {
      Console.Write("Enter Name: ");
      string name = Console.ReadLine() ?? string.Empty;
      Console.Write("Enter Phone Number: ");
      string phoneNumber = Console.ReadLine() ?? string.Empty;
      Console.Write("Enter Email: ");
      string email = Console.ReadLine() ?? string.Empty;
      ContactsHandler handler = new(contacts);
      handler.Add(new(name, phoneNumber, email));
    }
  }
}
