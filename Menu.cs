namespace contact_list
{
    internal static class Menu
    {
        public static void ShowMenu()
        {

            string userChoice;
            ContactsDatabase contacts = new([]);

            while (true)
            {
                Console.WriteLine("Contact List Menu:");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. View Contacts");
                Console.WriteLine("3. Search Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option (1-5): ");
                userChoice = Console.ReadLine();

                if (!int.TryParse(userChoice, out int choice))
                {
                    Console.WriteLine("You need to type in a number.");
                    Console.Write("Choose an option (1-5): ");
                    userChoice = Console.ReadLine();
                }


                // === WIP: Do it later
                //if (choice < 1 || choice > 5)
                //{
                //    Console.WriteLine("You need to choose between 1 and 5.");
                //    Console.Write("Choose an option (1-5): ");
                //    userChoice = Console.ReadLine();
                //}


                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Add Contact selected.");

                        QueriesAddContact(contacts);
                        break;
                    case 2:
                        Console.WriteLine("View Contacts selected.");
                        Console.WriteLine("=======================");

                        ContactsHandler handlerView = new(new([]));
                        handlerView.Display(contacts);
                        Console.WriteLine("=======================");
                        break;
                    case 4:
                        Console.WriteLine("Delete Contact selected.");
                        Console.Write("Enter Contact ID to delete: ");

                        int id = Convert.ToInt16(Console.ReadLine());
                        ContactsHandler handlerDel = new(contacts);
                        handlerDel.Remove(contacts, id);
                        break;
                    default:
                        break;
                }
            }
        }

        public static void QueriesAddContact(ContactsDatabase contacts)
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
