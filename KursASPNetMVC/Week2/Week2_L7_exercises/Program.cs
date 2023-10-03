// See https://aka.ms/new-console-template for more information

// ZADANIA INSTRUKCJE WARUNKOWE

while (true)
{
    Console.Write("Wybierz zadanie(1-13) lub zakończ działanie programu (e): ");
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
        case "11":
            Task11();
            break;
        case "12":
            Task12();
            break;
        case "13":
            Task13();
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
    /*1.Napisz program w C#, który stworzy dwie zmienne int i sprawdzi czy są one równe czy nie. Dane testowe: a : 5 b : 5 Rezultat w terminalu : 5 i 5 są równe */
    int a = 5;
    int b = 5;

    if(a == b)
    {
        Console.WriteLine($"{a} i {b} są równe");
    }
}

void Task2()
{
    /*2.Napisz program w C#, który sprawdzi czy podana przez użytkownika liczba jest parzysta czy nieparzysta. Dane testowe : 15 Rezultat w terminalu : 15 jest liczbą nieparzystą*/
    Console.Write("Podaj liczbę: ");
    int a = Int32.Parse(Console.ReadLine());

    if(a%2 == 0)
    {
        Console.WriteLine($"{a} jest liczbą parzystą");
    }else
    {
        Console.WriteLine($"{a} jest liczbą nieparzystą");
    }
}

void Task3()
{
    /*3. Napisz program w C#, który sprawdzi czy podana przez użytkownika liczba jest dodatnia czy ujemna. Dane testowe : 14 Rezultat w terminalu : 14 jest liczbą dodatnią*/
    Console.Write("Podaj liczbę: ");
    int a = Int32.Parse(Console.ReadLine());
    if(a == 0)
    {
        Console.WriteLine($"{a} nie jest ani dodatnie, ani ujemne");
    }
    else if(a > 0)
    {
        Console.WriteLine($"{a} jest liczbą dodatnią");
    }
    else
    {
        Console.WriteLine($"{a} jest liczbą ujemną");
    }
}

void Task4()
{
    /*4. Napisz program w C#, który sprawdzi czy podany przez użytkownika rok jest rokiem przestępnym. Dane testowe : 2016 Rezultat w terminalu : 2016 jest rokiem przestępnym */
    Console.Write("Podaj rok: ");
    int year = Int32.Parse(Console.ReadLine());
    if((year%4 == 0 && year%100 != 0) || year%400 == 0)
    {
        Console.WriteLine($"{year} jest rokiem przestępnym");
    }else
    {
        Console.WriteLine($"{year} nie jest rokiem przestępnym");
    }
}

void Task5()
{
    /* Napisz program w C#, który sprawdzi czy podany przez użytkownika wiek uprawnia go do ubiegania się o stanowisko posła, premiera, sentarora, prezydenta. Dane testowe : 21 Rezultat w terminalu : Możesz zostać posłem */
    Console.Write("Ile masz lat?: ");
    byte age = Byte.Parse(Console.ReadLine());
    if(age >= 35)
    {
        Console.WriteLine("Możesz zostać premierem, prezydentem, posłem lub senatorem");
    }else if(age >= 30)
    {
        Console.WriteLine("Możesz zostać senatorem lub posłem");
    }else if (age >= 21) 
    {
        Console.WriteLine("Możesz zostać posłem");
    }
    else
    {
        Console.WriteLine("Jesteś za młody");
    }
}

void Task6()
{
    /* 6. Napisz program w C#, który pobierze wzrost użytkownika i przypisze mu wymyśloną kategorię wzrostu. Dane testowe : 140 Rezultat w terminalu : Jesteś krasnoludem */
    Console.Write("Ile masz wzrostu?: ");
    int height = Int32.Parse(Console.ReadLine());
    if(height >= 190)
    {
        Console.WriteLine("Jesteś olbrzymem");
    }else if(height >= 180)
    {
        Console.WriteLine("Jesteś wysoki");
    }else if(height >= 165)
    {
        Console.WriteLine("Jesteś średniego wzrostu");
    }else
    {
        Console.WriteLine("Jesteś niski");
    }
}

void Task7()
{
    /* 7.Napisz program w C#, który pobierze 3 liczby od użytkownika i sprawdzi, która jest największa Dane testowe: 25 63 79 Rezultat w terminalu : 79 jest największa z podanych */
    Console.Write("Podaj pierwszą liczbę: ");
    int a = Int32.Parse(Console.ReadLine());
    Console.Write("Podaj drugą liczbę: ");
    int b = Int32.Parse(Console.ReadLine());
    Console.Write("Podaj trzecią liczbę: ");
    int c = Int32.Parse(Console.ReadLine());

    int max = Math.Max(a,Math.Max( b, c));
    Console.WriteLine($"{max} jest największa");
}

void Task8()
{
    /*8. Napisz program, który sprawdzi, czy kandydat może ubiegać się o miejsce na studiach wg. Następujących kryteriów: Wynik z Matury z matematyki powyżej 70 Wynik z fizyki powyżej 55 Wynik z chemii powyżej 45 Łączny wynik z 3 przedmiotów powyżej 180 Albo Wynik z matematyki i jednego przedmiotu powyżej 150 Dane testowe: Matematyka 80 Fizyka 71 Chemia 0 Rezultat w terminalu : Kandydat dopuszczony do rekrutacji */
    Console.Write("Wynik matury z matematyki: ");
    int math = Int32.Parse(Console.ReadLine());
    Console.Write("Wynik matury z fizyki: ");
    int physics = Int32.Parse(Console.ReadLine());
    Console.Write("Wynik matury z chemii: ");
    int chemistry = Int32.Parse(Console.ReadLine());

    if (((math > 70 || physics > 55 || chemistry > 45) && (math + physics + chemistry) > 180) || ((math + physics) > 150 || (math + chemistry) > 150))
    {
        Console.WriteLine("Kandydat dopuszczony do rekrutacji");
    }
    else
    {
        Console.WriteLine("Kandydat nie spełnia kryteriów");
    }
}

void Task9()
{
    /* 9. Napisz program, który odczyta temperaturę I zwróci nazwę jak w poniższych kryteriach Temp < 0 – cholernie piździ Temp 0 – 10 – zimno Temp 10 – 20 – chłodno Temp 20 – 30 – w sam raz Temp 30 – 40 – zaczyna być słabo, bo gorąco
Temp >= 40 – a weź wyprowadzam się na Alaskę. Dane testowe : 41 Rezultat w terminalu : a weź wyprowadzam się na Alaskę. */
    Console.Write("Podaj temperaturę: ");
    int temp = Int32.Parse(Console.ReadLine());
    if(temp >= 40)
    {
        Console.WriteLine("A weź wyprowadzam się na Alaskę");
    }
    else if(temp >=30 && temp < 40)
    {
        Console.WriteLine("Zaczyna być słabo, bo gorąco");
    }
    else if (temp >= 20 && temp < 30)
    {
        Console.WriteLine("W sam raz");
    }
    else if (temp >= 10 && temp < 20)
    {
        Console.WriteLine("Chłodno");
    }
    else if (temp >= 0 && temp < 10)
    {
        Console.WriteLine("Zimno");
    }
    else if(temp < 0 )
    {
        Console.WriteLine("Cholernie piździ");
    }
}

void Task10()
{
    /* 10.Napisz program, który sprawdzi, czy z 3 podanych długości można stworzyć trójkąt Dane testowe: 40 55 65 Rezultat w terminalu: Można zbudować trójkąt */
    Console.Write("Podaj długość pierwszego odcinka: ");
    int a = Int32.Parse(Console.ReadLine());
    Console.Write("Podaj długość drugiego odcinka: ");
    int b = Int32.Parse(Console.ReadLine());
    Console.Write("Podaj długość trzeciego odcinka: ");
    int c = Int32.Parse(Console.ReadLine());

    int longest = Math.Max(a, Math.Max(b, c));
    if ((a>0 && b>0 && c>0 ) && (a<b+c && b<a+c && c<a+b))
    {
        Console.WriteLine("Z podanych długości można utworzyć trójkąt");
    }
    else
    {
        Console.WriteLine("Z podanych długości nie można utworzyć trójkąta");
    }
}

void Task11()
{
    /*Napisz program, który zmieni ocenę ucznia na jej opis wg podanej tabeli:
    Ocena
    Opis
    6
    Celujący
    5
    Bardzo dobry
    4
    Dobry
    3
    Dostateczny
    2
    Dopuszczający
    1
    Niedostateczny Dane testowe: 3 Rezultat w terminalu: Dostateczny 12.*/
    Console.Write("Podaj ocenę: ");
    int rate = Int32.Parse(Console.ReadLine());

    switch (rate)
    {
        case 1:
            Console.WriteLine("Niedostateczny");
            break;
        case 2:
            Console.WriteLine("Dopuszczający");
            break;
        case 3:
            Console.WriteLine("Dostateczny");
            break;
        case 4:
            Console.WriteLine("Dobry");
            break;
        case 5:
            Console.WriteLine("Bardzo dobry");
            break;
        case 6:
            Console.WriteLine("Celujący");
            break;
        default:
            Console.WriteLine("Wprowadzono złą wartość");
            break;
    }

}

void Task12()
{
    /* 12.Napisz program, który pobierze numer dnia tygodnia i          wyświetli jego nazwę Dane testowe: 4
        Rezultat w terminalu: Czwartek */
    Console.Write("Który dziś dzień tygodnia?: ");
    int day = Int32.Parse(Console.ReadLine());
    switch (day)
    {
        case 1:
            Console.WriteLine("Poniedziałek");
            break;
        case 2:
            Console.WriteLine("Wtorek");
            break;
        case 3:
            Console.WriteLine("Sroda");
            break;
        case 4:
            Console.WriteLine("Czwartek");
            break;
        case 5:
            Console.WriteLine("Piątek");
            break;
        case 6:
            Console.WriteLine("Sobota");
            break;
        case 7:
            Console.WriteLine("Niedziela");
            break;
        default:
            Console.WriteLine("Wprowadzono złą wartość");
            break;
    }
}

void Task13()
{
    /*Napisz program, który będzie posiadał proste menu (wg. Wzoru poniżej) I będzie prostym kalkulatorem Podaj pierwszą liczbę: … Podaj drugą liczbę: … Podaj numer operacji do wykonania:
        1. Dodawanie
        2. Odejmowanie
        3. Mnożenie
        4. Dzielenie
        …
        Twój wynik to: */
    Console.Write("Podaj pierwszą liczbę: ");
    double a = Double.Parse(Console.ReadLine());
    Console.Write("Podaj drugą liczbę: ");
    double b = Double.Parse(Console.ReadLine());

    Console.WriteLine("Co chcesz zrobić? \n 1.Dodaj \n 2.Odejmij \n 3.Pomnóż \n 4.Podziel");
    int operation = Int32.Parse(Console.ReadLine());
    switch(operation)
    {
        case 1:
            Console.WriteLine($"Twój wynik to: {a + b}");
            break;
        case 2:
            Console.WriteLine($"Twój wynik to: {a - b}");
            break;
        case 3:
            Console.WriteLine($"Twój wynik to: {a * b}");
            break;
        case 4:
            if(a == 0 || b == 0)
            {
                Console.WriteLine($"Nie dzielimy przez 0!");
            }
            else
            {
                Console.WriteLine($"Twój wynik to: {a / b}");
            }
            break;
        default:
            Console.WriteLine("Wprowadzono złą wartość");
            break;
    }
}