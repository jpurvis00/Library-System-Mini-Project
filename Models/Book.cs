namespace LibrarySystemMiniProject;

public class Book
{
    public string Title { get; set; } = String.Empty;
    public string Author { get; set; } = String.Empty;
    public string ISBN { get; set; } = String.Empty;
    public bool CheckedOut { get; set; }
    public DateTime? CheckoutDate { get; set; }
    public DateTime? DueDate { get; set; }
}
