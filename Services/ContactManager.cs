using Agenda.Models;
using System.Text.Json;

namespace Agenda.Services;

class ContactManager
{
  public static void AddContact(Contact User)
  {
    if (!Contact.EmailIsValid(User.Email))
    {
      return;
    }
    Console.Clear();
    Console.WriteLine($"Adicionando {User.Name}");
    string jsonString = File.ReadAllText("Data/contactList.json");
    List<Contact>? ContactList = JsonSerializer.Deserialize<List<Contact>>(jsonString);
    ContactList?.Add(User);
    string newJson = JsonSerializer.Serialize(ContactList);
    File.WriteAllText("Data/contactList.json", newJson);
  }

  public static void ShowAllContacts()
  {
    Console.Clear();
    string jsonString = File.ReadAllText("Data/contactList.json");
    List<Contact>? ContactList = JsonSerializer.Deserialize<List<Contact>>(jsonString);
    if (ContactList != null && ContactList.Count != 0)
    {
      Console.WriteLine($"[{ContactList.Count} contatos encontrados.]\n");
      foreach (var User in ContactList)
      {
        Console.WriteLine($"Nome: {User.Name}");
        Console.WriteLine($"\u2022 Email: {User.Email}");
        Console.WriteLine($"\u2022 Telefone: {User.Phone}\n");
      }
    }
    else
    {
      Console.WriteLine("Sem contatos disponíveis.");
    }
  }
}