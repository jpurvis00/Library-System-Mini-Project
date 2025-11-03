using Dumpify;

namespace LibrarySystemMiniProject;

public class MenuService : IMenuService
{
    // private readonly IDataServices _dataServices;
    // private readonly ILibraryServices _libraryServices;

    public MenuService(IDataServices dataServices, ILibraryServices libraryServices)
    {
        // _dataServices = dataServices;
        // _libraryServices = libraryServices;
    }

    public int MenuDisplayCheckedOutBooks(string appTitle, List<Book> options)
    {
        Console.WriteLine(appTitle);
        for (int i = 0; i < options.Count(); i++)
        {
            Console.WriteLine($"    {i + 1}: {options[i].Title}");
        }

        Console.Write("Please choose a book to return: ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            return choice;
        }

        return -1;
    }

    public int MenuDisplayAndGetChoice(string appTitle, string[] options)
    {
        Console.WriteLine(appTitle);
        for (int i = 0; i < options.Count(); i++)
        {
            Console.WriteLine($"    {i + 1}: {options[i]}");
        }

        Console.Write("Please choose an option: ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            return choice;
        }

        return -1;
    }

    public int ShowAndSelectMember(List<Member> members)
    {
        Console.WriteLine("\n==== Members ====");

        for (int i = 0; i < members.Count(); i++)
        {
            Console.WriteLine(
                $"    {i + 1}: {members[i].FullName} = {(members[i].Expired ? "Membership expired" : "Membership valid")}"
            );
        }

        Console.Write("Please choose a member: ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            return choice - 1;
        }

        return -1;
    }

    public int ShowAndSelectAvailableBooks(List<Book> availableBooks)
    {
        Console.WriteLine("\n==== Available Books ====");

        for (int i = 0; i < availableBooks.Count(); i++)
        {
            Console.WriteLine($"    {i + 1}: {availableBooks[i].Title}");
        }

        Console.Write("Please choose a book: ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            return choice - 1;
        }

        return -1;
    }

    public bool RenewMembership(Member member)
    {
        Console.WriteLine("\n==== Renew Membership ====");
        Console.WriteLine($"ould you like to renew {member.FullName} membership?");
        Console.WriteLine(" 1. Yes");
        Console.WriteLine(" 2. No");

        Console.Write("Please choose an option: ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            if (choice == 1)
            {
                return true;
            }
            else if (choice == 2)
            {
                return false;
            }
        }

        return false;
    }

    public void SuccessMsgDisplay(string message)
    {
        Console.WriteLine($"\n✓ {message}\n");
    }

    public void ErrorMsgDisplay(string message)
    {
        Console.WriteLine($"\n❌ {message}\n");
    }
}
