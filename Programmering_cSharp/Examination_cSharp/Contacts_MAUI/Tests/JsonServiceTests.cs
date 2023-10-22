using Contacts_MAUI.Interfaces;
using Contacts_MAUI.Services;
using Xunit;

namespace Contacts_MAUI.Tests;

public class JsonServiceTests
{

    [Fact]
    public void ReadFromJson_Should_WhenFilepathIsWrong_ReturnNull()
    {
        // Arrange
        IJsonService jsonService = new JsonService();
        string fakeFilePath = "wrongpath.json";

        // Act
        string result = jsonService.ReadFromJson(fakeFilePath);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void SaveToJson_Should_WhenWriteToFileWorks_ReturnTrue()
    {
        // Arrange
        IJsonService jsonService = new JsonService();
        string filePath = "/Users/markuskarlsson/test123test.json";
        string jsonContent = "Test string";

        // Act
        bool result = jsonService.SaveToJson(jsonContent, filePath);

        // Assert
        Assert.True(result);

        // Cleanup
        if (File.Exists(filePath))
            File.Delete(filePath);
    }

}

