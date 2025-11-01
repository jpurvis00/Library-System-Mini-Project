namespace LibrarySystemMiniProject;

public class Library
{
    public string Name { get; set; } = "Oldham County Library";
    public string Address { get; set; } = "1111 Main St.";
    public List<Book> Books { get; set; } = new List<Book>();
}
