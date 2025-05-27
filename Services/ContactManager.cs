using Agenda.Models;
using System.Text.Json;

namespace Agenda.Services;

class ContactManager
{
  public static void AddContact(Contact user)
  {
    if (!Contact.EmailIsValid(user.Email))
    {
      return;
    }
    Console.Clear();
    Console.WriteLine($"Adicionando {user.Name}");
    string jsonString = File.ReadAllText("Data/contactList.json");
    List<Contact>? contactList = JsonSerializer.Deserialize<List<Contact>>(jsonString);
    contactList?.Add(user);
    string newJson = JsonSerializer.Serialize(contactList);
    File.WriteAllText("Data/contactList.json", newJson);
  }

  public static void ShowAllContacts()
  {
    Console.Clear();
    string jsonString = File.ReadAllText("Data/contactList.json");
    List<Contact>? contactList = JsonSerializer.Deserialize<List<Contact>>(jsonString);
    if (contactList != null && contactList.Count != 0)
    {
      Console.WriteLine($"[{contactList.Count} contatos encontrados.]\n");
      foreach (var user in contactList)
      {
        Console.WriteLine($"Nome: {user.Name}");
        Console.WriteLine($"\u2022 Email: {user.Email}");
        Console.WriteLine($"\u2022 Telefone: {user.Phone}\n");
      }
    }
    else
    {
      Console.WriteLine("Sem contatos disponíveis.");
    }
  }

  public static void SearchContact(string nameInput)
  {
    string jsonString = File.ReadAllText("Data/contactList.json");
    List<Contact>? contactList = JsonSerializer.Deserialize<List<Contact>>(jsonString);
    if (contactList != null)
    {
      List<Contact> filteredContacts = [.. contactList
      .Where(user => user.Name
      .Contains(nameInput, StringComparison.CurrentCultureIgnoreCase))];

      if (filteredContacts.Count <= 0)
      {
        Console.WriteLine("Não foram encontrados usuários");
        return;
      }
      foreach (var user in filteredContacts)
      {
        Console.WriteLine($"Nome: {user.Name}");
        Console.WriteLine($"\u2022 Email: {user.Email}");
        Console.WriteLine($"\u2022 Telefone: {user.Phone}\n");
      }
    }
  }

  public static void EditContact(string emailInput)
  {
    //TODO: verifica email existente na lista,
    // input pra qual atributo mudar,
    // input pra qual nova entrada,
    // atualiza lista e salva
  }

  public static void RemoveContact(string emailInput)
  {
    //TODO: verifica email existente na lista,
    // remove contato da lista
    // salva lista
  }
}