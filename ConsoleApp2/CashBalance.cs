namespace ConsoleApp2;

/// <summary>
/// Баланс денег.
/// </summary>
public class CashBalance
{
	public CashBalance(Currency currency, decimal amount)
	{
		Currency = currency is null 
			? throw new NullReferenceException("Currency class is null")
			: currency;
		Amount = amount;
	}

	/// <summary>
	/// Сумма денег на счете.
	/// </summary>
	public decimal Amount { private set; get; } 
	
	/// <summary>
	/// Валюта баланса.
	/// </summary>
	public Currency Currency { private set; get; }

	public override string ToString()
	{
		return $"Currency: {Currency.Name}, Amount: {Amount}";
	}
}