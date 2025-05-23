using Agenda.Models;
namespace Agenda.Services;

class ContactManager
{
  // Functions
  public static void Addcontact(Contact Contact)
  {
    if (!Contact.EmailIsValid(Contact.Email))
    {
      return;
    }
    Console.Clear();
    Console.WriteLine("Services.ContactManager > function Addcontact");
    Console.WriteLine($"\nParametros = {Contact.Name}, {Contact.Phone}, {Contact.Email}");
    //TODO: Adição dos parâmetros em um arquivo json.
  }
  public static void ShowAllContacts()
  {
    Console.Clear();
    Console.WriteLine("Services.ContactManager > Function ShowAllContacts");
    //TODO: Paginação e tratamento dos dados json.
  }
}