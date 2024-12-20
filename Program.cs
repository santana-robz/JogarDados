using System;
using System.Reflection.Metadata.Ecma335;

namespace JogarDados
{
    class Program
    {
        //Criando variáveis para acessar os jogadores de qualquer método.
        public static string JogadorN1;
        public static string JogadorN2;

        //Criação de variáveis para armazenar a pontuação dos jogadores
        public static byte  PontosJogadorN1;
        public static byte  PontosJogadorN2;

        //Criando variável para armazenar a rodada atual
        public static byte RodadaAtual;

        static void Main(string[] args)
        {
            ConfigurarJogo();
            IniciarRodadas();
        }

        public static void ConfigurarJogo()
        {
            RodadaAtual = 0;

            CriarJogadores();
            AtualizarPlacar();

            Console.WriteLine($"\n Jogadores {JogadorN1} e {JogadorN2} Criados. Pressione qualquer tecla para iniciar o jogo.");
            Console.Read();
        }

        public static void CriarJogadores()
        {
            Console.WriteLine("Informe o nome do primeiro jogador:");
            JogadorN1 = Console.ReadLine();
            PontosJogadorN1 = 0;
            Console.WriteLine("Informe o nome do segundo jogador:");
            JogadorN2 = Console.ReadLine();
            PontosJogadorN2 = 0;
        }

        public static void AtualizarPlacar()
        {
            Console.WriteLine($"### Pontos do jogador {JogadorN1}: {PontosJogadorN1}");
            Console.WriteLine($"### Pontos do jogador {JogadorN2}: {PontosJogadorN2}");
            Console.WriteLine();

            if(RodadaAtual == 0)
            {
                Console.WriteLine("### Jogo não iniciado...");
            }
        }

        //Esse método faz uso de recursão, pesquisar sobre se não o conhece
        public static void IniciarRodadas()
        {
            AtualizarPlacar();
            if(RodadaAtual ==3)
            {
                FinalizarJogo();
                return;
            }

            RodadaAtual++;

            Console.WriteLine($"Rodada {RodadaAtual} iniciada!\n");

            Console.WriteLine($"Jogador {JogadorN1}, pressione ENTER para fazer sua jogada...");
            Console.Read();
            byte valorTiradoJogadorN1 = JogarDado();
            Console.WriteLine($"Valor do dado jogador pelo {JogadorN1}: {valorTiradoJogadorN1}");

            Console.WriteLine($"Jogador {JogadorN2}, pressione a tecla ENTER para fazer a sua jogada...");
            Console.Read();
            byte valorTiradoJogadorN2 = JogarDado();
            Console.WriteLine($"Valor do dado jogado pelo {JogadorN2}: {valorTiradoJogadorN2}");
               
            if(valorTiradoJogadorN1 == valorTiradoJogadorN2)
            {
                Console.WriteLine($"\n{JogadorN1} tirou o número {valorTiradoJogadorN1} e {JogadorN2} o número {valorTiradoJogadorN2}. Empate!");
                Console.WriteLine("Pressione ENTER para continuar com o jogo...");
                Console.Read();
            }
            else
            {
                string vencedor;

                if(valorTiradoJogadorN1 > valorTiradoJogadorN2)
                {
                    vencedor = JogadorN1;
                    PontosJogadorN1++;
                }
                else
                {
                    vencedor = JogadorN2;
                    PontosJogadorN2++;
                }

                Console.WriteLine($"\n{JogadorN1} tirou o número {valorTiradoJogadorN1} e {JogadorN2} o número {valorTiradoJogadorN2}. {vencedor} venceu a rodada {RodadaAtual}.");
                Console.WriteLine("Pressione ENTER para continuar com o jogo...");
                Console.Read();
            }
        }
      
    

    public static byte JogarDado()
    {
        Random Dados = new Random();
        return Convert.ToByte(Dados.Next(1, 6));
    }

    public static void FinalizarJogo()
    {
        AtualizarPlacar();
        Console.WriteLine("Jogo Finalizado!");

        if(PontosJogadorN1 > PontosJogadorN2)
        {
            Console.WriteLine("Empate!");
        }
        else if(PontosJogadorN1 > PontosJogadorN2)
        {
            Console.WriteLine($"O jogador {JogadorN1} venceu com {PontosJogadorN1} pontos!");
        }
        else
        {
            Console.WriteLine($"O jogador {JogadorN2} venceu com {PontosJogadorN2} pontos");
        }
    }
    }
}