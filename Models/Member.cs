namespace LibrarySystemMiniProject;

public class Member
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public bool Expired { get; set; }
    public DateTime MembershipDate { get; set; }
    public List<Book> BooksCheckedOut { get; set; } = new List<Book>();
    public string FullName => $"{FirstName} {LastName}";
}
