using System.Text.RegularExpressions;
using Agenda.Models;
using Agenda.Services;

namespace Agenda;

class Program
{
	private static void AddMenu()
	{
		string phoneInput;
		string emailInput;

		Console.Clear();
		Console.WriteLine("\x1b[1m[Adicionar contato]\x1b[0m");
		Console.Write("\nDigite o nome do contato: ");
		var nameInput = Console.ReadLine() ?? string.Empty;
		// Phone input
		Console.Write("\nDigite o telefone: ");
		phoneInput = Console.ReadLine() ?? string.Empty;
		if (!Regex.IsMatch(phoneInput, "^[0-9]*$"))
		{
			Console.WriteLine("Entrada inválida, utilize apenas números para adicionar o telefone.");
			Console.ReadKey();
			return;
		}
		// Email input
		Console.Write("\nDigite o Email do contato: ");
		emailInput = Console.ReadLine() ?? string.Empty;
		if (!Contact.EmailIsValid(emailInput))
		{
			Console.WriteLine("Email inválido, utilize o formato nome@domínio.com");
			Console.ReadKey();
			return;
		}
		Contact newContact = new() { Name = nameInput, Phone = phoneInput, Email = emailInput };
		ContactManager.AddContact(newContact);
	}

	private static void SearchMenu()
	{
		Console.Clear();
		Console.Write("Digite o nome do contato: ");
		var nameInput = Console.ReadLine() ?? string.Empty;
		Console.WriteLine("-------------------------\n");
		ContactManager.SearchContact(nameInput);
	}

	private static void EditMenu()
	{
		Console.Clear();
		Console.Write("Digite o email do contato: ");
		var emailInput = Console.ReadLine() ?? string.Empty;
		ContactManager.EditContact(emailInput);
	}

	private static void RemoveMenu()
	{
		Console.Clear();
		Console.Write("Digite o email do contato: ");
		var emailInput = Console.ReadLine() ?? string.Empty;
		ContactManager.RemoveContact(emailInput);
	}

	private static void Main()
	{
		var exit = false;
		while (!exit)
		{
			Console.Clear();
			Console.WriteLine("\x1b[1m[Gerenciamento de Contatos]\x1b[0m");
			Console.WriteLine("===========================");
			Console.WriteLine("\x1b[1m 1.\x1b[0m Adicionar contato");
			Console.WriteLine("\x1b[1m 2.\x1b[0m Listar contatos");
			Console.WriteLine("\x1b[1m 3.\x1b[0m Buscar contato");
			Console.WriteLine("\x1b[1m 4.\x1b[0m Editar contato");
			Console.WriteLine("\x1b[1m 5.\x1b[0m Remover contato");
			Console.WriteLine("\x1b[1m 6.\x1b[0m Sair");
			Console.WriteLine("===========================");
			Console.Write("\nEscolha uma opção: ");
			var option = int.Parse(Console.ReadLine() ?? string.Empty);

			switch (option)
			{
				case 1:
					AddMenu();
					Console.ReadKey();
					break;
				case 2:
					ContactManager.ShowAllContacts();
					Console.ReadKey();
					break;
				case 3:
					SearchMenu();
					Console.ReadKey();
					break;
				case 4:
					EditMenu();
					Console.ReadKey();
					break;
				case 5:
					RemoveMenu();
					Console.ReadKey();
					break;
				case 6:
					Console.WriteLine("Saindo...");
					exit = true;
					break;
				default:
					Console.WriteLine("Opção inválida. Tente novamente.");
					Console.ReadKey();
					break;
			}
		}
	}
}