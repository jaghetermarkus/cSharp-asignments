using _01_ContactList.Interfaces;
using _01_ContactList.Services;

IMenuService menuService = new MenuService();
var contactService = new ContactService();

contactService.GetAllContacts();
menuService.MainMenu();
