using System.Collections.ObjectModel;

namespace ConsoleApp2;

/// <summary>
/// Курс валют для конвертации.
/// </summary>
public abstract class CurrencyCourse
{
	/// <summary>
	/// Набор курсов конвертации валют.
	/// </summary>
	private Dictionary<(Currency from, Currency to), double> _currencyExchangeRates;
	
	/// <summary>
	/// Набор курсов конвертации валют.
	/// </summary>
	public IReadOnlyDictionary<(Currency from, Currency to), double> CurrencyExchangeRates 
		=> new ReadOnlyDictionary<(Currency from, Currency to), double>(_currencyExchangeRates);

	protected CurrencyCourse(Dictionary<(Currency from, Currency to), double> currencyExchangeRates)
	{
		_currencyExchangeRates = currencyExchangeRates;
	}

	/// <summary>
	/// Возвращает курс из одной валюты в другую
	/// </summary>
	/// <param name="from">Конвертация из.</param>
	/// <param name="to">Валюта, в которую производится конвертация.</param>
	/// <returns>Курс.</returns>
	public double GetCurrenciesExchangeRate(Currency from, Currency to)
	{
		return _currencyExchangeRates.ContainsKey((from, to)) 
			? _currencyExchangeRates.GetValueOrDefault((from, to)) 
			: FindExchangeRateViaThirdCurrency(from, to);
	}

	/// <summary>
	/// Нахождения курса с помощью третьей валюты.
	/// </summary>
	/// <param name="from">Конвертация из.</param>
	/// <param name="to">Валюта, в которую производится конвертация.</param>
	/// <returns>Курс.</returns>
	private double FindExchangeRateViaThirdCurrency(Currency from, Currency to)
	{
		var keys = _currencyExchangeRates.Keys;

		var thirdCurrencies = keys
			.Where(x => x.from.Equals(from))
			.Select(x => x.to);

		var thirdCurrencyThatHasConversion = keys
			.First(x => thirdCurrencies.Any(y => y == x.from) && x.to == to);

		_currencyExchangeRates.TryGetValue((from, thirdCurrencyThatHasConversion.from), out var firstExchangeRate);
		_currencyExchangeRates.TryGetValue((thirdCurrencyThatHasConversion.from, to), out var secondExchangeRate);

		return firstExchangeRate * secondExchangeRate;
	}
}

/// <summary>
/// Курс валют для конвертации.
/// </summary>
public class ApplicationCurrencyCourse : CurrencyCourse
{
	public ApplicationCurrencyCourse(Dictionary<(Currency from, Currency to), double> currencyExchangeRates)
		: base(currencyExchangeRates)
	{ }
}