// See https://aka.ms/new-console-template for more information

//ZADANIA TYPY DANYCH

while(true)
{
    Console.Write("Wybierz zadanie(1-5) lub zakończ działanie programu (e): ");
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
        case "e":
            return;
        case "E":
            return;
        default: Console.WriteLine("Podałeś złą wartość!");
            break;
    }
    Console.WriteLine();

}

void Task1()
{
    /* 1. Stwórz program, w którym zadeklarujesz zmienne dotyczące danych pracownika firmy. Dane 
    które chcesz przetrzymywać to:
        a.Imię,
        b.Nazwisko
        c.Wiek
        d.Płeć(‘m’ albo ‘k’)
        e.PESEL
        f.Numer pracownika(np. 2509324094)
    Zadeklaruj zmienne odpowiednich typów, które mogą przetrzymywać te informacje*/

    string name = "Jack";
    string lastName = "Dowson";
    byte age = 28;
    char sex = 'm';
    string pesel = "94021201710";
    string identityNo = "2362415121";

    Console.WriteLine(name);
    Console.WriteLine(lastName);
    Console.WriteLine(age);
    Console.WriteLine(sex);
    Console.WriteLine(pesel);
    Console.WriteLine(identityNo);
}

void Task2()
{
    /* 2. Napisz program, w którym stworzysz 3 zmienne z jedną literą, a następnie wypiszesz je w 
odwrotnej kolejności niż zostały zadeklarowane.*/

    char x = 'x';
    char y = 'y';
    char z = 'z';

    Console.WriteLine(z);
    Console.WriteLine(y);
    Console.WriteLine(x);
}

void Task3()
{
    /*3. Napisz program, który na podstawie podanej szerokości i długości prostokąta wyliczy długość 
    przekątnej. (Aby, obliczyć kwadrat liczby użyj metody Math.Pow())*/
    Console.Write("Długość podstawy: ");
    double x = Int32.Parse(Console.ReadLine());
    Console.Write("Długość boku: ");
    double y = Int32.Parse(Console.ReadLine());
    double result = Math.Sqrt(Math.Pow(x,2) + Math.Pow(y,2));
    Console.WriteLine("Długość przekątnej: " + result);
}

void Task4()
{
    /*4.Napisz program w którym stworzysz 2 zmienne liczbowe, oraz jedną tekstową, a następnie 
    przypiszesz im następujące wartości:
    a. 10
    b.Szkoła Dotneta
    c. 12,5
    Pamiętaj o użyciu poprawnych typów danych.*/

    int x;
    string text;
    float y;

    x = 10;
    text = "Szkoła Dotneta";
    y = 12.5f;

    Console.WriteLine($"{x}, {text}, {y}");
}

void Task5()
{
    /*5. Napisz program w którym poprosisz użytkownika o jego dane personalne tj. Imię, nazwisko,
numer telefonu, adres email, wzrost, waga (np. 85, 7), itp (postaraj się wymyślić jak najwięcej) 
i spróbuj przekonwertować odpowiedź do odpowiedniego typu danych używając metody: 
typDanych.Parse(odpowiedźOdUżytkownika). */
    Console.Write("Jak masz na imię?: ");
    string name = Console.ReadLine();
    Console.Write("Jak się nazywasz?: ");
    string lastName = Console.ReadLine();
    Console.Write("Ile masz lat?: ");
    byte age = Byte.Parse(Console.ReadLine());
    Console.Write("Ile masz wzrostu(cm)?: ");
    byte height = Byte.Parse(Console.ReadLine());
    Console.Write("Ile ważysz?: ");
    byte weight = Byte.Parse(Console.ReadLine());
    Console.Write("Twój adres email: ");
    string email = Console.ReadLine();
    Console.Write("Twój telefon: ");
    int phone = Int32.Parse(Console.ReadLine());
    Console.Write("Gdzie mieszkasz?: ");
    string city = Console.ReadLine();

    Console.WriteLine($"{name}, {lastName}, {age}, {height}, {weight}, {email}, {phone}, {city}");
}
