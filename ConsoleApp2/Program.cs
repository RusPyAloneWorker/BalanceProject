using ConsoleApp2;

public class Math
{
	public static void Main()
	{
		var myCashBalance = new CashBalance(new DollarCurrency(), 1_000);
		var currencyExchangeRates = new Dictionary<(Currency from, Currency to), double>()
		{
			{ (new RubleCurrency(), new EuroCurrency()), 1.18 },
			{ (new DollarCurrency(), new RubleCurrency()), 0.98 },
		};
		
		var applicationCurrencyCourse = new ApplicationCurrencyCourse(currencyExchangeRates);
		var applicationCurrencyConverter = new ApplicationCurrencyConverter(applicationCurrencyCourse);
		var calculator = new CashCalculator(applicationCurrencyConverter);
		
		Console.WriteLine(calculator.AddToBalance(myCashBalance, 1555));
		Console.WriteLine(calculator.DeductFromBalance(myCashBalance, 15));
		Console.WriteLine(calculator.ConvertBalance(myCashBalance, new RubleCurrency()));
		Console.WriteLine(calculator.ConvertBalance(myCashBalance, new EuroCurrency()));
	}
}