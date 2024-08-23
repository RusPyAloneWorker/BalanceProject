namespace ConsoleApp2;

/// <summary>
/// Валюта.
/// </summary>
public record class Currency
{
	/// <summary>
	/// Название валюты.
	/// </summary>
	public string Name { set; get; }

	protected Currency(string name)
	{
		Name = !string.IsNullOrWhiteSpace(name) 
			? name 
			: throw new ArgumentException("Name string is empty");
	}
}