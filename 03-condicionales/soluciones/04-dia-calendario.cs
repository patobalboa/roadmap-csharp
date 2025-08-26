
Console.WriteLine("Ingresa un numero entre el 1 y 365");
int numero = int.Parse(Console.ReadLine());

if (numero < 1 && numero > 365)
{
    Console.WriteLine("Numero Inválido");
    System.Environment.Exit(0);
}
string mes = "";
int dia = 0;
switch (numero)
{
    case int n when (n >= 1 && n <= 31):
        mes = "Enero";
        dia = numero;
        break;

    case int n when (n >= 32 && n <= 59):
        mes = "Febrero";
        dia = numero - 31;
        break;

    case int n when (n >= 60 && n <= 90):
        mes = "Marzo";
        dia = numero - 59;
        break;

    case int n when (n >= 91 && n <= 120):
        mes = "Abril";
        dia = numero - 90;
        break;

    case int n when (n >= 121 && n <= 151):
        mes = "Mayo";
        dia = numero - 120;
        break;

    case int n when (n >= 152 && n <= 181):
        mes = "Junio";
        dia = numero - 151;
        break;

    case int n when (n >= 182 && n <= 212):
        mes = "Julio";
        dia = numero - 181;
        break;

    case int n when (n >= 213 && n <= 243):
        mes = "Agosto";
        dia = numero - 212;
        break;

    case int n when (n >= 244 && n <= 273):
        mes = "Septiembre";
        dia = numero - 243;
        break;

    case int n when (n >= 274 && n <= 304):
        mes = "Octubre";
        dia = numero - 273;
        break;

    case int n when (n >= 305 && n <= 334):
        mes = "Noviembre";
        dia = numero - 304;
        break;

    case int n when (n >= 335 && n <= 365):
        mes = "Diciembre";
        dia = numero - 334;
        break;
}

string estacion = "";

switch (mes)
{
    case "Diciembre":
    case "Enero":
    case "Febrero":
        estacion = "Verano";
        break;

    case "Marzo":
    case "Abril":
    case "Mayo":
        estacion = "Otoño";
        break;
    case "Junio":
    case "Julio":
    case "Agosto":
        estacion = "Invierno";
        break;
    
    default:
        estacion = "Primavera";
            break;
}

Console.WriteLine("El día ingresado corresponde al "+ dia + " de " + mes + " en la estacion de "+estacion);








