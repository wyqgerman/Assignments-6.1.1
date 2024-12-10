namespace Assignments_6._1._1 { } 

class HouseNode
{
    public int HouseNumber { get; set; }
    public string Address { get; set; }
    public string HouseType { get; set; }
    public HouseNode Next { get; set; }

    public HouseNode(int houseNumber, string address, string houseType)
    {
        HouseNumber = houseNumber;
        Address = address;
        HouseType = houseType;
        Next = null;
    }

    public override string ToString()
    {
        return $"House Number: {HouseNumber}\nAddress: {Address}\nType: {HouseType}";
    }
}

class HouseLinkedList
{
    private HouseNode head;

    public void AddHouse(int houseNumber, string address, string houseType)
    {
        HouseNode newHouse = new HouseNode(houseNumber, address, houseType);
        if (head == null)
        {
            head = newHouse;
        }
        else
        {
            HouseNode current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newHouse;
        }
    }

    public HouseNode SearchHouse(int houseNumber)
    {
        HouseNode current = head;
        while (current != null)
        {
            if (current.HouseNumber == houseNumber)
            {
                return current;
            }
            current = current.Next;
        }
        return null;
    }

    public void DisplayAllHouses()
    {
        if (head == null)
        {
            Console.WriteLine("No houses in the list.");
            return;
        }

        HouseNode current = head;
        while (current != null)
        {
            Console.WriteLine(current);
            Console.WriteLine(new string('-', 30));
            current = current.Next;
        }
    }
}

class Program { 
    static void Main(string[] args)
    {
        HouseLinkedList houseList = new HouseLinkedList();

        while (true)
        {
            Console.WriteLine("\n--- House Linked List Menu ---");
            Console.WriteLine("1. Add House");
            Console.WriteLine("2. Search House");
            Console.WriteLine("3. Display All Houses");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter house number: ");
                    int houseNumber = int.Parse(Console.ReadLine());

                    Console.Write("Enter address: ");
                    string address = Console.ReadLine();

                    Console.Write("Enter house type (e.g., Ranch, Colonial): ");
                    string houseType = Console.ReadLine();

                    houseList.AddHouse(houseNumber, address, houseType);
                    Console.WriteLine("House added successfully!");
                    break;

                case "2":
                    Console.Write("Enter house number to search: ");
                    int searchNumber = int.Parse(Console.ReadLine());

                    HouseNode house = houseList.SearchHouse(searchNumber);
                    if (house != null)
                    {
                        Console.WriteLine("\nHouse Details:");
                        Console.WriteLine(house);
                    }
                    else
                    {
                        Console.WriteLine("House not found.");
                    }
                    break;

                case "3":
                    Console.WriteLine("\nAll Houses:");
                    houseList.DisplayAllHouses();
                    break;

                case "4":
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}