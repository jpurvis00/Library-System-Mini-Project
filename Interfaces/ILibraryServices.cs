namespace LibrarySystemMiniProject;

public interface ILibraryServices
{
    public List<Book> GetCheckedoutBooks(List<Book> books);
    public List<Book> GetAllBooks(List<Book> books);
    public List<Member> ShowMembersWithStatus(List<Member> members, bool expired);
    public void BorrowBook(Member member, Book book);
    public void ReturnBook(Member member, Book book);
    public List<Book> GetAvailableBooks(List<Book> books);
}
