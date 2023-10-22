using _01_ContactList.Interfaces;
using _01_ContactList.Models;
using Newtonsoft.Json;

namespace _01_ContactList.Services;

public class JsonService
{
    private static readonly string filePath = @"/Users/markuskarlsson/nackademin/csharp/myProjects/ContactList/01_ContactList/ListOfContacts.Json";

    public static void SaveToJson(string contentAsJson)
    {

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }

        using var sw = new StreamWriter(filePath);
        sw.WriteLine(contentAsJson);
    }

    public static string ReadFromJson()
    {
        if (File.Exists(filePath))
        {
            using var sr = new StreamReader(filePath);

            return sr.ReadToEnd();
        }
        return null!;
    }

}

