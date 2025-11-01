using System.Text.Json;

namespace LibrarySystemMiniProject;

public class JsonDataServices : IDataServices
{
    public List<Book>? LoadBooks()
    {
        var jsonBooks = File.ReadAllText("Data/books.json");

        if (jsonBooks != null)
        {
            return JsonSerializer.Deserialize<List<Book>>(jsonBooks);
        }
        else
        {
            return null;
        }
    }

    public List<Member>? LoadMembers()
    {
        var jsonMembers = File.ReadAllText("Data/members.json");

        if (jsonMembers != null)
        {
            return JsonSerializer.Deserialize<List<Member>>(jsonMembers);
        }
        else
        {
            return null;
        }
    }

    public void SaveBooks(List<Book> books)
    {
        var updatedBooks = JsonSerializer.Serialize<List<Book>>(
            books,
            new JsonSerializerOptions { WriteIndented = true }
        );

        if (updatedBooks != null)
        {
            File.WriteAllText("Data/books.json", updatedBooks);
        }
    }

    public void SaveMember(List<Member> members)
    {
        var updatedMembers = JsonSerializer.Serialize<List<Member>>(
            members,
            new JsonSerializerOptions { WriteIndented = true }
        );

        if (updatedMembers != null)
        {
            File.WriteAllText("Data/members.json", updatedMembers);
        }
    }
}
