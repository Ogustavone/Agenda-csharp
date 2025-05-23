namespace Agenda.Models;

class ContactManager
{
  public static void Addcontact(string name, string phone, string email)
  {
    Console.Clear();
    Console.WriteLine("Models.ContactManager > function Addcontact");
    Console.WriteLine($"\nParametros = {name}, {phone}, {email}");
    //TODO: Adição dos parâmetros em um arquivo json.
  }
  public static void ShowAllContacts()
  {
    Console.Clear();
    Console.WriteLine("Models.ContactManager > Function ShowAllContacts");
    //TODO: Paginação e tratamento dos dados json.
  }
}