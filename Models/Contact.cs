namespace Agenda.Models;

partial class Contact
{
  public required string Name { get; set; }
  public required string Phone { get; set; }
  public required string Email { get; set; }

  public static bool EmailIsValid(string email)
  {
    return MyRegex().IsMatch(email);
  }

  [System.Text.RegularExpressions.GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
  private static partial System.Text.RegularExpressions.Regex MyRegex();
}