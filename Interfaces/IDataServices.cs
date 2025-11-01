namespace LibrarySystemMiniProject;

public interface IDataServices
{
    public List<Book>? LoadBooks();
    public List<Member>? LoadMembers();
    public void SaveBooks(List<Book> books);
    public void SaveMember(List<Member> members);
}
