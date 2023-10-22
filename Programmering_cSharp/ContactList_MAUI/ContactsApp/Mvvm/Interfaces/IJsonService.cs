namespace ContactsApp.Interfaces
{
    public interface IJsonService
    {
        bool SaveToJson(string contentAsJson, string filePath);
        string ReadFromJson(string filePath);
    }
}