// See https://aka.ms/new-console-template for more information

// ZADANIA PĘTLE

using System.Dynamic;

while (true)
{            
    Console.Write("Wybierz zadanie(1-10) lub zakończ działanie programu (e): ");
    string chosenOperation = Console.ReadLine();
    switch (chosenOperation)
    {
        case "1":
            Task1();
            break;
        case "2":
            Task2();
            break;
        case "3":
            Task3();
            break;
        case "4":
            Task4();
            break;
        case "5":
            Task5();
            break;
        case "6":
            Task6();
            break;
        case "7":
            Task7();
            break;
        case "8":
            Task8();
            break;
        case "9":
            Task9();
            break;
        case "10":
            Task10();
            break;
        case "e":
            return;
        case "E":
            return;
        default:
            Console.WriteLine("Podałeś złą wartość!");
            break;
    }
    Console.WriteLine();
}

void Task1()
{
    /*Napisz program, który sprawdzi ile jest liczb pierwszych w zakresie 0 – 100.*/
    bool isPrime = false;
    for(int i =0;i<=100;i++)
    {
        for(int j =2;j<i;j++)
        {
            if (i % j == 0 )
            {
                isPrime = false;
                break;
            }else
            {
                isPrime = true;
            }    
        }
        if(i==2 || isPrime )
        {
            Console.WriteLine(i);
        }
    }

}
void Task2()
{
    /* Napisz program, w którym za pomocą pętli do…while znajdziesz wszystkie liczby parzyste z zakresu 0 – 1000 */
    int x = 0;
    do
    {
        if (x % 2 == 0)
        {
            Console.WriteLine(x);
        }
        x++;
    } while (x <= 1000);
}
void Task3()
{
    /*. Napisz program, który zaimplementuje ciąg Fibonacciego i wyświetli go na ekranie. */
    int fib = 0;
    int fib1 = 1;
    int fib2;
    for(int i = 0; i<=20; i++)
    {
        Console.WriteLine(fib);
        fib2 = fib1;
        fib1 = fib;
        fib = fib1 + fib2;
    }
}
void Task4()
{
    /*Napisz program, który po podaniu liczby całkowitej wyświetli piramidę liczb od 1 do podanej liczby w formie jak poniżej: 
     * 1 
     * 2 3 
     * 4 5 6 
     * 7 8 9 10*/
    Console.Write("Podaj liczbę: ");
    int num = Int32.Parse(Console.ReadLine());
    int counter = 1;
    int toShow = 1 ;
    while (toShow <= num)
    {
        for (int i = 1; i <= counter; i++)
        {
            Console.Write(toShow + " ");
            toShow++;
            if(toShow > num)
            { 
                break;
            }
        }
        counter++;
        Console.WriteLine();
    }

}
void Task5()
{
    /*5. Napisz program, który dla liczb od 1 do 20 wyświetli na ekranie ich 3 potęgę.*/
    int a = 1;
    for(int i = 1;i<=20;i++)
    {
        Console.WriteLine($"3 potęga liczby {a} to: {i*i*i}");
        a++;
    }
}
void Task6()
{
    /*Napisz program, który dla liczb od 0 do 20 obliczy sumę wg wzoru: 1 + ½ + 1/3 + ¼ itd.*/
    double result = 0.0;
    for (int i = 1; i <= 20; i++)
    {
        result += 1.0 / i;
    }
    Console.WriteLine($"Suma wynosi: {result}");
}
void Task7()
{
    /*7. Napisz program, który dla liczby zadanej przez użytkownika narysuje diament o krótszej przekątnej o długości wprowadzonej przez użytkownika i wg wzoru*/
    //Console.Write("Podaj długość przekątnej: ");
    //int a = Int32.Parse(Console.ReadLine());

        Console.Write("Podaj długość przekątnej: ");
        int diagonal;
        Int32.TryParse(Console.ReadLine(), out diagonal);

        int halfDiagonal = diagonal / 2;
        int spaces = halfDiagonal;
      
        for (int i = 1; i <= halfDiagonal + 1; i++)
        {
            for (int j = 1; j <= spaces; j++)
            {
                Console.Write(" ");
            }

            for (int j = 1; j <= 2 * i - 1; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            spaces--;
        }

        spaces = 1;

        for (int i = halfDiagonal; i >= 1; i--)
        {
            for (int j = 1; j <= spaces; j++)
            {
                Console.Write(" ");
            }

            for (int j = 1; j <= 2 * i - 1; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            spaces++;
        }
    }
void Task8()
{
    /*Napisz program, który odwróci wprowadzony przez użytkownika ciąg znaków. Np.
        Testowe dane:
        Abcdefg
        Rezultat
        Gfedcba*/
    Console.Write("Podaj ciąg znaków: ");
    char[] characters = Console.ReadLine().ToCharArray();
    for(int i = characters.Length -1; i>=0; i--)
    {
        Console.Write(characters[i]);
    }
}
void Task9()
{
    /*9. Napisz program, który zamieni liczbę dziesiętną na liczbę binarną.*/
    Console.Write("Podaj liczbę: ");
    int num = Int32.Parse(Console.ReadLine());
    string bin = "";
    for (int i = 0; num>=1; i++)
    {
        int a = num % 2;
        if(a%2 ==0)
        {
            bin = bin + "0";
        }
        else
        {
            bin = bin + "1";
        }
        num = num / 2;
    }
    char[] binaryNum = bin.ToCharArray();
    Array.Reverse(binaryNum);
    Console.WriteLine(binaryNum);
}
void Task10()
{
    /*10. Napisz program, który znajdzie najmniejszą wspólną wielokrotność dla zadanych 2 liczb.*/
    Console.Write("Podaj pierwszą liczbę: ");
    int a = Int32.Parse(Console.ReadLine());
    Console.Write("Podaj drugą liczbę: ");
    int b = Int32.Parse(Console.ReadLine());

    int lcm = Math.Max(a, b);
    bool helper = true;
    while(helper)
    {
        if (lcm % a == 0 && lcm % b == 0)
        {
            Console.WriteLine($"Najmniejsza wspólna wielokrotność liczb {a} i {b} = {lcm}");
            helper= false;            
        }
        lcm++;
    }
}