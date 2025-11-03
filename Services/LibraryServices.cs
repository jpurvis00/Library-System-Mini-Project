namespace LibrarySystemMiniProject;

public class LibraryServices : ILibraryServices
{
    public List<Book> GetCheckedoutBooks(List<Book> books)
    {
        return books.Where(b => b.CheckedOut == true).ToList();
    }

    public List<Book> GetAvailableBooks(List<Book> books)
    {
        return books.Where(b => b.CheckedOut == false).ToList();
    }

    public List<Book> GetAllBooks(List<Book> books)
    {
        return books.ToList();
    }

    public List<Member> ShowMembersWithStatus(List<Member> members, bool expired)
    {
        return members.Where(m => m.Expired == expired).ToList();
    }

    public void CheckOutBook(Member member, Book book) {
        book.CheckedOut = true;
        book.CheckoutDate = DateTime.Today;
        book.DueDate = DateTime.Today.AddDays(14);
    }

    public void ReturnBook(Member member, Book book) { }
}
