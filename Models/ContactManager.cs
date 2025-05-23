using System.Text.RegularExpressions;

namespace Agenda.Models;

class ContactManager
{
  // Regex email pattern
  public const string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

  // Functions
  public static void Addcontact(string name, string phone, string email)
  {
    if (!Regex.IsMatch(email, emailPattern))
    {
      return;
    }
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