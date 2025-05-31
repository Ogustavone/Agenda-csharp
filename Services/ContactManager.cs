using Agenda.Models;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Agenda.Services;

class ContactManager
{
  /// <summary>
  /// Returns a list of contacts from JSON file.
  /// </summary>
  /// <returns>List of classes(Contact) or empty list if null.</returns>
  private static List<Contact> GetContacts()
  {
    string jsonString = File.ReadAllText("Data/contactList.json");
    List<Contact>? contactList = JsonSerializer.Deserialize<List<Contact>>(jsonString);
    return contactList ?? [];
  }

  /// <summary>
  /// Gets a single contact from JSON file
  /// Returns null when not found.
  /// </summary>
  /// <returns>Object(Contact) or null</returns>
  private static Contact? GetContactByEmail(string emailInput)
  {
    var contactList = GetContacts();
    return contactList.FirstOrDefault(c => c.Email == emailInput);
  }

  public static void AddContact(Contact user)
  {
    if (!Contact.EmailIsValid(user.Email)) return;
    Console.Clear();
    Console.WriteLine($"Adicionando {user.Name}");
    var contactList = GetContacts();
    contactList.Add(user);
    string newJson = JsonSerializer.Serialize(contactList);
    File.WriteAllText("Data/contactList.json", newJson);
  }

  public static void ShowAllContacts()
  {
    Console.Clear();
    var contactList = GetContacts();
    if (contactList.Count != 0)
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
    var contactList = GetContacts();
    var filteredContacts = contactList.Where(user => user.Name
    .Contains(nameInput, StringComparison.CurrentCultureIgnoreCase)).ToList();

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

  public static void EditContact(string emailInput)
  {
    Console.Clear();
    Contact? user = GetContactByEmail(emailInput);
    if (user == null)
    {
      Console.WriteLine("Usuário não encontrado...");
      return;
    }
    Console.WriteLine($"Nome: {user.Name}");
    Console.WriteLine($"\u2022 Email: {user.Email}");
    Console.WriteLine($"\u2022 Telefone: {user.Phone}\n");
    Console.Write("Qual atributo você deseja alterar (Email/Telefone)? ");
    var selectionInput = Console.ReadLine() ?? string.Empty;
    var contactList = GetContacts();

    if (selectionInput.Equals("telefone", StringComparison.OrdinalIgnoreCase))
    {
      Console.Write("\nDigite o novo telefone: ");
      var phoneInput = Console.ReadLine() ?? string.Empty;
      if (!Regex.IsMatch(phoneInput, "^[0-9]*$"))
      {
        Console.WriteLine("Entrada inválida, utilize apenas números para adicionar o telefone.");
        return;
      }

      var index = contactList.FindIndex(c => c.Email.Equals(user.Email));
      if (index != -1)
      {
        contactList[index].Phone = phoneInput;
      }
    }
    else if (selectionInput.Equals("email", StringComparison.OrdinalIgnoreCase))
    {
      Console.Write("Digine o novo email: ");
      emailInput = Console.ReadLine() ?? string.Empty;
      if (!Contact.EmailIsValid(emailInput))
      {
        Console.WriteLine("Email inválido, utilize o formato nome@domínio.com");
        return;
      }

      var index = contactList.FindIndex(c => c.Email.Equals(user.Email));
      if (index != -1)
      {
        contactList[index].Email = emailInput;
      }
    }
    else
    {
      Console.WriteLine("Atributo inválido.");
      return;
    }

    string newJson = JsonSerializer.Serialize(contactList);
    File.WriteAllText("Data/contactList.json", newJson);
    Console.WriteLine("Contato atualizado com sucesso!");
  }

  public static void RemoveContact(string emailInput)
  {
    Console.Clear();
    Contact? user = GetContactByEmail(emailInput);
    if (user == null)
    {
      Console.WriteLine("Usuário não encontrado...");
      return;
    }

    Console.Write($"Tem certeza que deseja remover {user.Name}? (s/n): ");
    var confirmation = Console.ReadLine() ?? string.Empty;
    bool continueCheck = confirmation.Equals("s", StringComparison.OrdinalIgnoreCase);

    var contactList = GetContacts();
    var index = contactList.FindIndex(c => c.Email.Equals(user.Email));
    if (index != -1 && continueCheck)
    {
      contactList.RemoveAt(index);
    }

    string newJson = JsonSerializer.Serialize(contactList);
    File.WriteAllText("Data/contactList.json", newJson);
    Console.WriteLine($"{user.Name} removido com sucesso.");
  }
}