namespace Szkola_Dotneta_Zadanie_Petle;

internal class Program
{
	static void Main()
	{
		// Zadanie 1
		var number = 0;
		var numberOfPrimes = 0;
		while (number <= 100)
		{
			if (IsPrime(number))
			{
				numberOfPrimes++;
			}
			number++;
		}

		Console.WriteLine($"W zakresie od 0 do 100 jest {numberOfPrimes} liczb pierwszych\r\n");


		// Zadanie 2
		number = 0;
		var numberOfEvens = 0;
		do
		{
			if (number % 2 == 0)
			{
				numberOfEvens++;
			}

			number++;

		} while (number <= 1000);

		Console.WriteLine($"W zakresie od 0 do 1000 jest {numberOfEvens} liczb parzystych\r\n");


		// Zadanie 3
		var fibonacciNumbers = new List<int> {0,1};
		var limit = 20;

		for (var i = 2; i < limit; i++)
		{
			fibonacciNumbers.Add(fibonacciNumbers[i - 1] + fibonacciNumbers[i - 2]);
		}

		Console.WriteLine($"Oto pierwsze {limit} liczb z ciągu fibonacciego:");
		foreach (var fibNumber in fibonacciNumbers)
		{
			Console.Write($"{fibNumber}, ");
		}

		Console.WriteLine("\r\n");


		// Zadanie 4
		while (true)
		{
			Console.Write("Podaj liczbę do piramidy: ");
			var piramidLimitString = Console.ReadLine();

			if (!int.TryParse(piramidLimitString, out var piramidLimit) || piramidLimit < 1)
			{
				Console.WriteLine("Błąd, jeszcze raz.");
				continue;
			}

			int printedNumber = 1;
			int numbersInRow = 1;
			while (printedNumber <= piramidLimit)
			{
				for (int j = 1; j <= numbersInRow; j++)
				{
					Console.Write($"{printedNumber} ");
					printedNumber++;
				}

				Console.WriteLine();
				numbersInRow++;
			}

			Console.WriteLine();
			break;
		}


		// Zadanie 5
		for (int i = 1; i <= 20; i++)
		{
			int thirdPower = i * i * i;
			Console.WriteLine($"{i}^3 = {thirdPower}");
		}

		Console.WriteLine();


		// Zadanie 6
		decimal sum = 0;
		for (int j = 1; j <= 20; j++)
		{
			////double add = 1 / (double)j;
			sum += 1 / (decimal)j;
		}

		Console.WriteLine($"{sum} \r\n");


		// Zadanie 7
		Console.Write("Podaj długość krótszej przekątnej diamentu (musi być nieparzysta): ");
		while (true)
		{
			var input = Console.ReadLine();

			if (!int.TryParse(input, out var n) || n < 1 || n % 2 == 0)
			{
				Console.WriteLine("Błąd, wprowadź dodatnią, nieparzystą liczbę.");
				continue;
			}

			var middle = n / 2;
			for (var i = 0; i <= middle; i++)
			{
				PrintDiamondLine(n, i);
			}

			for (var i = middle - 1; i >= 0; i--)
			{
				PrintDiamondLine(n, i);
			}

			Console.WriteLine();
			break;
		}


		// Zadanie 8
		Console.Write("Wprowadź ciąg znaków: ");
		while (true)
		{
			var inputString = Console.ReadLine();
			if (inputString == null)
			{
				Console.WriteLine("Błąd, jeszcze raz.");
				continue;
			}

			for (var i = inputString.Length - 1; i >= 0; i--)
			{
				Console.Write(inputString[i]);
			}

			Console.WriteLine("\r\n");
			break;
		}


		// Zadanie 9
		Console.Write("Podaj dodatnią liczbę dziesiętną: ");
		while (true)
		{
			var input = Console.ReadLine();
			if (!int.TryParse(input, out var decimalNumber) || decimalNumber < 0)
			{
				Console.WriteLine("Błąd, wprowadź dodatnią liczbę całkowitą.");
				continue;
			}

			string binaryNumber = ConvertDecimalToBinary(decimalNumber);
			Console.WriteLine($"{decimalNumber} w systemie binarnym to: {binaryNumber}\r\n");
			break;
		}


		// Zadanie 10
		// NWW(a, b) = ∣a × b∣ / NWD(a, b)
		Console.Write("Najmniejsza wspólna wielokrotność\r\n");
		while (true)
		{
			Console.Write("Podaj pierwszą liczbę: ");
			var input1 = Console.ReadLine();

			Console.Write("Podaj drugą liczbę: ");
			var input2 = Console.ReadLine();

			if (!int.TryParse(input1, out var num1) || !int.TryParse(input2, out var num2) || num1 <= 0 || num2 <= 0)
			{
				Console.WriteLine("Błąd, jeszcze raz.");
				continue;
			}

			int nww = Math.Abs(num1 * num2) / CalculateNwd(num1, num2);
			Console.WriteLine($"Najmniejsza wspólna wielokrotność dla {num1} i {num2} to: {nww}");
			break;
		}
	}
	private static int CalculateNwd(int a, int b)
	{
		while (b != 0)
		{
			var temp = b;
			b = a % b;
			a = temp;
		}

		return a;
	}

	private static string ConvertDecimalToBinary(int decimalNumber)
	{
		if (decimalNumber == 0)
		{
			return "0";
		}

		var binary = string.Empty;
		while (decimalNumber > 0)
		{
			int temp = decimalNumber % 2;
			binary = temp + binary;
			decimalNumber /= 2;
		}

		return binary;
	}

	private static void PrintDiamondLine(int n, int i)
	{
		var spaces = n / 2 - i;
		var stars = 2 * i + 1;

		Console.WriteLine(new string(' ', spaces) + new string('*', stars));
	}

	private static bool IsPrime(int number)
	{
		switch (number)
		{
			case <= 1:
				return false;

			case 2 or 3:
				return true;
		}

		if (number % 2 == 0 || number % 3 == 0)
		{
			return false;
		}

		for (var i = 5; i * i <= number; i += 6)
		{
			if (number % i == 0 || number % (i + 2) == 0)
			{
				return false;
			}
		}

		return true;
	}
}
