namespace LibrarySystemMiniProject;

public class MemberServices : IMemberServices
{
    private readonly IMenuService _menuService;

    public MemberServices(IMenuService menuService)
    {
        _menuService = menuService;
    }

    public List<Member> SearchMembers(List<Member> members, string lastName)
    {
        if (!lastName.Equals(""))
        {
            return members.Where(m => m.LastName.Equals(lastName)).ToList();
        }
        else
        {
            return members.ToList();
        }
    }

    public Member? SelectMember(List<Member> members)
    {
        Console.WriteLine("Select a member:");
        for (int i = 0; i < members.Count; i++)
        {
            Console.WriteLine(
                $"    {i + 1}. {members[i].FullName} - {(members[i].Expired ? "Membership expired" : "Membership up to date")}"
            );
        }

        int.TryParse(Console.ReadLine(), out int selected);

        if (selected != 0 && selected <= members.Count)
        {
            return members[selected - 1];
        }
        else
        {
            return null;
        }
    }

    public List<Book>? ShowMemberBooks(Member member)
    {
        if (member == null)
        {
            _menuService.ErrorMsgDisplay("No member has been selected.");
            return null;
        }

        return member.BooksCheckedOut;
    }

    public void ChangeMembershipStatus(Member member, bool expired)
    {
        member.Expired = expired;
    }

    public void CheckOutBook(Member member, Book book)
    {
        member.BooksCheckedOut.Add(book);
    }
}
