namespace LibrarySystemMiniProject;

public interface IMemberServices
{
    public List<Member> SearchMembers(List<Member> members, string lastName);
    public Member? SelectMember(List<Member> members);
    public void ChangeMembershipStatus(Member member, bool expired);
    public void CheckOutBook(Member member, Book book);
    public List<Book> ShowMemberBooks(Member member);
}
