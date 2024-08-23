namespace ConsoleApp2;

/// <summary>
/// Калькулятор денежных сумм.
/// </summary>
public class CashCalculator
{
	/// <summary>
	/// Конвертер валют.
	/// </summary>
	private readonly CurrencyConverter _currencyConverter;

	public CashCalculator(CurrencyConverter currencyConverter)
	{
		_currencyConverter = currencyConverter;
	}

	/// <summary>
	/// Пополнить баланс.
	/// </summary>
	/// <param name="balance">Баланс.</param>
	/// <param name="value">Сумма для пополнения.</param>
	/// <returns>Баланс с новой суммой</returns>
	public CashBalance AddToBalance(CashBalance balance, decimal value)
	{
		return new CashBalance(balance.Currency, balance.Amount + value);
	}
	
	/// <summary>
	/// Вычесть сумму из баланса.
	/// </summary>
	/// <param name="balance">Баланс.</param>
	/// <param name="value">Сумма для вычета.</param>
	/// <returns>Баланс с новой суммой</returns>
	public CashBalance DeductFromBalance(CashBalance balance, decimal value)
	{
		return new CashBalance(balance.Currency, balance.Amount - value);
	}

	/// <summary>
	/// Конвертация баланса.
	/// </summary>
	/// <param name="balance">Баланс.</param>
	/// <param name="currency">Валюта.</param>
	/// <returns>Баланс с конвертированной суммой и валютой.</returns>
	public CashBalance ConvertBalance(CashBalance balance, Currency currency)
	{
		var newCurrencyAmount= _currencyConverter.Convert(balance.Currency, currency, balance.Amount);

		return new CashBalance(currency, newCurrencyAmount);
	} 
}