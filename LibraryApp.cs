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
                    selectedMember = DisplayAndSelectMember(members);
                    ReturnBook(selectedMember, members, books);
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

    private void ReturnBook(int selectedMember, List<Member>? members, List<Book>? books)
    {
        if (selectedMember == -1 || books == null || members == null)
        {
            _menuService.ErrorMsgDisplay("There is an error.");
            return;
        }

        var checkedOutBooks = _memberServices.ShowMemberBooks(members[selectedMember]);
        _menuService.MenuDisplayCheckedOutBooks("\n==== Return Book ====", checkedOutBooks);

        // checkedOutBooks.DumpConsole();
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

        // Check to see if the members membership is expired. Offer the chance to renew if it is.
        if (members[selectedMember].Expired)
        {
            var renew = _menuService.RenewMembership(members[selectedMember]);

            if (renew)
            {
                _memberServices.ChangeMembershipStatus(members[selectedMember], false);
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

        _libraryServices.CheckOutBook(members[selectedMember], availableBooks[bookChoice]);
        _memberServices.CheckOutBook(members[selectedMember], availableBooks[bookChoice]);

        _dataServices.SaveBooks(books);
        _dataServices.SaveMember(members);

        members[selectedMember].DumpConsole();
        // availableBooks[bookChoice].DumpConsole();
        //implement adding book to the members books list.
        //Should I implement a member history as well?
    }
}
