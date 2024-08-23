namespace ConsoleApp2;

/// <summary>
/// Конвертер валют.
/// </summary>
public abstract class CurrencyConverter
{
	/// <summary>
	/// Курс валют.
	/// </summary>
	private readonly CurrencyCourse _currencyCourse;

	protected CurrencyConverter(CurrencyCourse currencyCourse)
	{
		_currencyCourse = currencyCourse;
	}

	/// <summary>
	/// Конвертировать сумму денег из одной валюты в другую. 
	/// </summary>
	/// <param name="from">Конретация валюты из.</param>
	/// <param name="to">Валюта, в которую конвертируют.</param>
	/// <param name="value">Сумма денег.</param>
	/// <returns>Итоговая сумма денег.</returns>
	public decimal Convert(Currency from, Currency to, decimal value)
	{
		var exchangeRate = _currencyCourse.GetCurrenciesExchangeRate(from, to);

		return value * (decimal)exchangeRate;
	}
	
	/// <summary>
	/// Конвертировать сумму денег из одной валюты в другую. 
	/// </summary>
	/// <param name="from">Конретация валюты из.</param>
	/// <param name="to">Валюта, в которую конвертируют.</param>
	/// <param name="cashBalance">Сумма денег.</param>
	/// <returns>Итоговая сумма денег.</returns>
	public decimal Convert(Currency from, Currency to, CashBalance cashBalance)
	{
		var exchangeRate = _currencyCourse.GetCurrenciesExchangeRate(from, to);

		return cashBalance.Amount * (decimal)exchangeRate;
	}
}

/// <summary>
/// Конвертер валют.
/// </summary>
public class ApplicationCurrencyConverter : CurrencyConverter
{
	public ApplicationCurrencyConverter(CurrencyCourse currencyCourse) 
		: base(currencyCourse)
	{ }
}