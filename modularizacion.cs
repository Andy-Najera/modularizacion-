using System;

class Program
{
    static void Main()
    {
        int opcion;
        
        do
        {
            Console.Clear();
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Calculadora básica");
            Console.WriteLine("2. Validación de contraseña");
            Console.WriteLine("3. Números primos");
            Console.WriteLine("4. Suma de números pares");
            Console.WriteLine("5. Conversión de temperatura");
            Console.WriteLine("6. Contador de vocales");
            Console.WriteLine("7. Cálculo de factorial");
            Console.WriteLine("8. Juego de adivinanza");
            Console.WriteLine("9. Paso por referencia");
            Console.WriteLine("10. Tabla de multiplicar");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");
            
            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 0 || opcion > 10)
            {
                Console.WriteLine("Opción no válida, por favor intente nuevamente.");
                Console.ReadKey();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Calculadora();
                    break;
                case 2:
                    ValidacionContraseña();
                    break;
                case 3:
                    NumeroPrimo();
                    break;
                case 4:
                    SumaPares();
                    break;
                case 5:
                    ConversionTemperatura();
                    break;
                case 6:
                    ContadorVocales();
                    break;
                case 7:
                    CalculoFactorial();
                    break;
                case 8:
                    JuegoAdivinanza();
                    break;
                case 9:
                    PasoPorReferencia();
                    break;
                case 10:
                    TablaMultiplicar();
                    break;
                case 0:
                    Console.WriteLine("¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción no válida, intente nuevamente.");
                    break;
            }

            if (opcion != 0)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcion != 0);
    }

    static void Calculadora()
    {
        double num1, num2;
        string operacion;

        Console.Write("Ingrese el primer número: ");
        while (!double.TryParse(Console.ReadLine(), out num1))
        {
            Console.Write("Por favor ingrese un número válido: ");
        }

        Console.Write("Ingrese el segundo número: ");
        while (!double.TryParse(Console.ReadLine(), out num2))
        {
            Console.Write("Por favor ingrese un número válido: ");
        }

        Console.WriteLine("Seleccione la operación (+, -, *, /): ");
        operacion = Console.ReadLine();

        switch (operacion)
        {
            case "+":
                Console.WriteLine($"Resultado: {Suma(num1, num2)}");
                break;
            case "-":
                Console.WriteLine($"Resultado: {Resta(num1, num2)}");
                break;
            case "*":
                Console.WriteLine($"Resultado: {Multiplicacion(num1, num2)}");
                break;
            case "/":
                if (num2 != 0)
                    Console.WriteLine($"Resultado: {Division(num1, num2)}");
                else
                    Console.WriteLine("No se puede dividir entre cero.");
                break;
            default:
                Console.WriteLine("Operación no válida.");
                break;
        }
    }

    static double Suma(double a, double b) => a + b;
    static double Resta(double a, double b) => a - b;
    static double Multiplicacion(double a, double b) => a * b;
    static double Division(double a, double b) => a / b;

    static void ValidacionContraseña()
    {
        string password;
        do
        {
            Console.Write("Ingrese la contraseña: ");
            password = Console.ReadLine();

            if (password == "1234")
            {
                Console.WriteLine("Acceso concedido.");
                break;
            }
            else
            {
                Console.WriteLine("Contraseña incorrecta, intente nuevamente.");
            }
        } while (password != "1234");
    }

    static void NumeroPrimo()
    {
        int numero;
        Console.Write("Ingrese un número: ");
        while (!int.TryParse(Console.ReadLine(), out numero))
        {
            Console.Write("Por favor ingrese un número válido: ");
        }

        if (EsPrimo(numero))
            Console.WriteLine($"{numero} es un número primo.");
        else
            Console.WriteLine($"{numero} no es un número primo.");
    }

    static bool EsPrimo(int n)
    {
        if (n <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0) return false;
        }
        return true;
    }

    static void SumaPares()
    {
        int numero, suma = 0;

        Console.WriteLine("Ingrese números (ingrese 0 para terminar):");
        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out numero)) continue;

            if (numero == 0) break;

            if (numero % 2 == 0)
                suma += numero;
        }

        Console.WriteLine($"La suma de los números pares ingresados es: {suma}");
    }

    static void ConversionTemperatura()
    {
        double temperatura;
        Console.WriteLine("Seleccione la conversión:");
        Console.WriteLine("1. Celsius a Fahrenheit");
        Console.WriteLine("2. Fahrenheit a Celsius");
        int opcion = int.Parse(Console.ReadLine());

        if (opcion == 1)
        {
            Console.Write("Ingrese los grados Celsius: ");
            if (double.TryParse(Console.ReadLine(), out temperatura))
            {
                Console.WriteLine($"{temperatura}°C es igual a {CelsiusAFahrenheit(temperatura)}°F.");
            }
            else
            {
                Console.WriteLine("Valor no válido.");
            }
        }
        else if (opcion == 2)
        {
            Console.Write("Ingrese los grados Fahrenheit: ");
            if (double.TryParse(Console.ReadLine(), out temperatura))
            {
                Console.WriteLine($"{temperatura}°F es igual a {FahrenheitACelsius(temperatura)}°C.");
            }
            else
            {
                Console.WriteLine("Valor no válido.");
            }
        }
        else
        {
            Console.WriteLine("Opción no válida.");
        }
    }

    static double CelsiusAFahrenheit(double celsius) => celsius * 9 / 5 + 32;
    static double FahrenheitACelsius(double fahrenheit) => (fahrenheit - 32) * 5 / 9;

    static void ContadorVocales()
    {
        Console.Write("Ingrese una frase: ");
        string frase = Console.ReadLine();
        Console.WriteLine($"La cantidad de vocales es: {ContarVocales(frase)}");
    }

    static int ContarVocales(string texto)
    {
        int contador = 0;
        string vocales = "aeiouAEIOU";
        foreach (char c in texto)
        {
            if (vocales.Contains(c))
            {
                contador++;
            }
        }
        return contador;
    }

    static void CalculoFactorial()
    {
        Console.Write("Ingrese un número para calcular su factorial: ");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine($"El factorial de {num} es: {Factorial(num)}");
    }

    static long Factorial(int n)
    {
        long resultado = 1;
        for (int i = 1; i <= n; i++)
        {
            resultado *= i;
        }
        return resultado;
    }

    static void JuegoAdivinanza()
    {
        Random rand = new Random();
        int numeroAleatorio = rand.Next(1, 101);
        int intento;
        do
        {
            Console.Write("Adivine el número entre 1 y 100: ");
            intento = int.Parse(Console.ReadLine());

            if (intento > numeroAleatorio)
                Console.WriteLine("Demasiado alto.");
            else if (intento < numeroAleatorio)
                Console.WriteLine("Demasiado bajo.");
            else
                Console.WriteLine("¡Felicidades, adivinaste el número!");
        } while (intento != numeroAleatorio);
    }

    static void PasoPorReferencia()
    {
        int a, b;
        Console.Write("Ingrese el primer número: ");
        a = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el segundo número: ");
        b = int.Parse(Console.ReadLine());

        Console.WriteLine($"Antes del intercambio: a = {a}, b = {b}");
        Intercambiar(ref a, ref b);
        Console.WriteLine($"Después del intercambio: a = {a}, b = {b}");
    }

    static void Intercambiar(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    static void TablaMultiplicar()
    {
        Console.Write("Ingrese un número para mostrar su tabla de multiplicar: ");
        int num = int.Parse(Console.ReadLine());

        Console.WriteLine($"Tabla de multiplicar de {num}:");
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{num} x {i} = {num * i}");
        }
    }
}