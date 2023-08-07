public class Client
{
    public Client(int id, string name)
    {
        Id = id;
        Name = name; // Initialize non-nullable property 'Name'
    }

    public int Id { get; set; }
    public string Name { get; set; }
}