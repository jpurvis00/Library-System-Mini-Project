using Dumpify;

namespace LibrarySystemMiniProject;

public class LibraryApp
{
    private readonly IDataServices _dataServices;
    private readonly ILibraryServices _libraryServices;
    private readonly IMemberServices _memberServices;
    private readonly IMenuService _menuService;
    private readonly string[] _menuOptions =
    {
        "Borrow book",
        "Return Book",
        "Update membership status",
        "Exit",
    };

    public LibraryApp(
        IDataServices dataServices,
        ILibraryServices libraryServices,
        IMemberServices memberServices,
        IMenuService menuService
    )
    {
        _dataServices = dataServices;
        _libraryServices = libraryServices;
        _memberServices = memberServices;
        _menuService = menuService;
    }

    public void Run()
    {
        var books = _dataServices.LoadBooks();
        var members = _dataServices.LoadMembers();
        int selectedMember;

        if (books == null && members == null)
        {
            return;
        }

        var run = true;
        while (run)
        {
            var userChoice = ShowMainMenu();

            // "Borrow book",
            // "Return Book",
            // "Update membership status",
            // "Exit",
            switch (userChoice)
            {
                case 1:
                    selectedMember = DisplayAndSelectMember(members);
                    BorrowBook(selectedMember, members, books);
                    break;
                case 2:
                    // ReturnBook(members, books);
                    break;
                case 3:
                    // UpdateMemberStatus(member);
                    break;
                case 4:
                    run = false;
                    break;
                default:
                    _menuService.ErrorMsgDisplay("User choice is invalid. Please choose again.");
                    break;
            }
        }

        members.DumpConsole();
        // string json = JsonSerializer.Serialize(members, new JsonSerializerOptions { WriteIndented = true });
        // File.WriteAllText("Data/members.json", json);
    }

    private int DisplayAndSelectMember(List<Member>? members)
    {
        return _menuService.ShowAndSelectMember(members);
    }

    private int ShowMainMenu()
    {
        return _menuService.MenuDisplayAndGetChoice("\n==== Library Services ====", _menuOptions);
    }

    private void BorrowBook(int selectedMember, List<Member> members, List<Book>? books)
    {
        if (books == null)
        {
            _menuService.ErrorMsgDisplay(
                "Something has gone wrong or there are no books in the system."
            );
            return;
        }

        members[selectedMember].DumpConsole();

        // Check to see if the members membership is expired. Offer the chance to renew if it is.
        if (members[selectedMember].Expired)
        {
            var renew = _menuService.RenewMembership(members[selectedMember]);

            if (renew)
            {
                members[selectedMember].Expired = false;
                _dataServices.SaveMember(members);
            }
            else
            {
                _menuService.ErrorMsgDisplay(
                    "Members with expired memberships can not check out books."
                );
                return;
            }
        }

        // Get all available books. Select the book to check out. Mark it as checked out and save it
        // back to the json file.
        var availableBooks = _libraryServices.GetAvailableBooks(books);
        var bookChoice = _menuService.ShowAndSelectAvailableBooks(availableBooks);

        availableBooks[bookChoice].CheckedOut = true;
        availableBooks[bookChoice].CheckoutDate = DateTime.Today;
        availableBooks[bookChoice].DueDate = DateTime.Today.AddDays(14);

        _dataServices.SaveBooks(books);

        // availableBooks[bookChoice].DumpConsole();
        //implement adding book to the members books list.
        //Should I implement a member history as well?
    }
}
