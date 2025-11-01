namespace LibrarySystemMiniProject;

public interface IMenuService
{
    public int MenuDisplayAndGetChoice(string appTitle, string[] options);
    public void ErrorMsgDisplay(string message);
    public void SuccessMsgDisplay(string message);
    public int ShowAndSelectMember(List<Member> members);
    public bool RenewMembership(Member member);
    public int ShowAndSelectAvailableBooks(List<Book> availableBooks);
}
