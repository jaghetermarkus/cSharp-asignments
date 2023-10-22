using _01_ContactList.Interfaces;
using _01_ContactList.Models;
using _01_ContactList.Services;
using Xunit;

namespace _01_ContactList.Tests;

public class ContactService_Tests
{
	[Fact]
	public void DeleteContact_Should_ReturnTrue_When_DeletingContactIsSuccessful()
	{
        // Arrange
        IContactService contactServiceTest = new ContactService();
        IContact contactTest = new Contact();

        // Act
        contactTest.MemberID = 12345;
        contactTest.Id = Guid.NewGuid();
        contactTest.FirstName = "Test";
        contactTest.LastName = "Testsson";
        contactTest.Email = "Test@domain.com";
        contactTest.Created = DateTime.Now;

        contactTest.Address = new Address();
        contactTest.Address.StreetName = "Gatan";
        contactTest.Address.StreetNumber = "1";
        contactTest.Address.PostalCode = "123 45";
        contactTest.Address.City = "Stad";

        contactServiceTest.AddContact(contactTest);
        contactServiceTest.DeleteContact(12345);
        var result = contactServiceTest.GetOneContact(12345);



        // Assert
        Assert.Null(result);
        //Assert.NotNull(result);

    }
}

