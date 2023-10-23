using System.Security.Cryptography;

Console.Clear();
Console.WriteLine("--- Adivinha ---\n");

Console.Write("Estou pensando em um número entre 1 e 100.");
Thread.Sleep(500); Console.Write(".");
Thread.Sleep(500); Console.Write(".");
Thread.Sleep(500); Console.WriteLine(" Pronto! Agora, tente adivinhar.");

int palpite = 0;
int numeroSecreto = RandomNumberGenerator.GetInt32(1, 101);
int tentativa = 1;
bool acertou = false;

do
{
    Console.Write($"\nFaça seu palpite #{tentativa}? ");

    if (!Int32.TryParse(Console.ReadLine(), out palpite) || palpite < 1 || palpite > 100)
        continue;

    int erro = palpite - numeroSecreto;
    int distanciaErro = Math.Abs(erro);

    acertou = (palpite == numeroSecreto);

    if (!acertou)
    {
        tentativa++;

        if (distanciaErro <= 3)
            ExibeColorido("Pelando!\n", ConsoleColor.DarkRed);
        else if (distanciaErro <= 10)
            ExibeColorido("Quente!\n", ConsoleColor.Red);
        else
        {
            if (distanciaErro >= 30)
                ExibeColorido("Congelando... ", ConsoleColor.DarkBlue);
            else
                ExibeColorido("Frio... ", ConsoleColor.Blue);

            bool tentarMaisAlto = Math.Sign(erro) == -1;

            Console.Write("tente um número mais ");
            ExibeColorido(tentarMaisAlto ? "alto" : "baixo", tentarMaisAlto ? ConsoleColor.Green : ConsoleColor.Yellow);
            Console.WriteLine(".");
        }
    }
}
while (tentativa <= 7 && !acertou);

Console.Write("\nO número que escolhi era ");
ExibeColorido(numeroSecreto.ToString(), ConsoleColor.Magenta);
Console.WriteLine(".\n");

ExibeColorido(acertou ? "Parabéns!" : "Tente novamente.", acertou ? ConsoleColor.Green : ConsoleColor.Yellow);

void ExibeColorido(string texto, ConsoleColor cor)
{
    Console.ForegroundColor = cor;
    Console.Write(texto);
    Console.ResetColor();
}