namespace _01_ContactList.Interfaces;

public interface IJsonService
{
    void SaveToJson(string contentAsJson);
    string ReadFromJson();
}

