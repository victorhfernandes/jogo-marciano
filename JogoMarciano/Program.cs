using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoMarciano
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0, marc, ammo = 5, ammo2 = 3, ammo3 = 2, alvo = 0, row, col, verow = 0, vecol, menu, nivel, op;
            bool acerto = false;
            int[,] arvore = new int[10, 10];

            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Jogo do Marciano");


                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("================");
                Console.WriteLine("1) Jogar");
                Console.WriteLine("2) Instruções");
                Console.WriteLine("================\n");

                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("Opção: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    menu = int.Parse(Console.ReadLine());
                }
                while (menu != 1 && menu != 2);

                Console.WriteLine("\nDificuldade: ");
                Console.WriteLine("1) Facil");
                Console.WriteLine("2) Medio");
                Console.WriteLine("3) Dificil");
                Console.WriteLine("================\n");

                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("Opção: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    nivel = int.Parse(Console.ReadLine());
                }
                while (nivel != 1 && nivel != 2 && nivel != 3);

                if (menu == 2)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Jogo do Marciano");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("================");
                    Console.WriteLine("Jogador 1");
                    Console.WriteLine("Esconda o Marciano em uma das 100 árvores.");
                    Console.WriteLine("\n");
                    Console.WriteLine("Jogador 2");
                    Console.WriteLine("Tem 5 chances de acertá-lo.");
                    Console.WriteLine("================");
                    Console.WriteLine("0) Voltar");
                    Console.WriteLine("================\n");
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("Opção: ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        menu = int.Parse(Console.ReadLine());

                    }
                    while (menu != 0);
                }
            }
            while (menu != 1 && menu != 2);

            switch (nivel)
            {
                case 1:
                    Console.WriteLine("Case 1");
                    Console.Clear();
                    do
                    {
                        //escolher onde arvore está
                        Console.Write("Árvore do Marciano: ");
                        marc = int.Parse(Console.ReadLine());
                    } while (marc > 100);
                    //fim escolher arvore

                    //transformando marc em bidimencional para futura verificação
                    if (marc > 10 && marc != 20 && marc != 30 && marc != 40 && marc != 50 &&
                                marc != 60 && marc != 70 && marc != 80 && marc != 90 && marc != 100)
                    {
                        verow = marc / 10;
                        vecol = (marc % 10) - 1;
                    }
                    if (marc < 10)
                    {
                        verow = 0;
                        vecol = marc - 1;
                    }
                    if (marc == 10 || marc == 20 || marc == 30 || marc == 40 || marc == 50 ||
                                marc == 60 || marc == 70 || marc == 80 || marc == 90 || marc == 100)
                    {
                        verow = (marc / 10) - 1;
                        vecol = 9;
                    }

                    //populando
                    for (row = 0; row <= 9; row++)
                    {
                        for (col = 0; col <= 9; col++)
                        {
                            arvore[row, col] = (i + 1);
                            i++;
                        }
                    }

                    do
                    {
                        //dicas
                        Console.Clear();

                        if (alvo < marc && alvo != 0)
                        {
                            if (verow == row)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Estou mais à DIREITA");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Estou mais à BAIXO");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            }
                        }
                        if (alvo > marc && alvo != 0)
                        {
                            if (verow == row)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Estou mais à ESQUERDA");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Estou mais à CIMA");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            }
                            



                        }


                        //visualizando
                        for (row = 0; row <= 9; row++)
                        {
                            for (col = 0; col <= 9; col++)
                            {
                                if (arvore[row, col] == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("♣({0:D2}) ", arvore[row, col]);
                                }
                                else
                                {
                                    //Console.BackgroundColor = ConsoleColor.DarkGreen;
                                    Console.ForegroundColor = ConsoleColor.Green;

                                    Console.Write("♣({0:D2}) ", arvore[row, col]);
                                }
                            }
                            Console.WriteLine(" ");
                        }

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;

                        Console.Write("Munição: {0}\n", ammo);

                        Console.Write("\n");
                        do
                        {
                            Console.Write("Atirar: ");
                            alvo = int.Parse(Console.ReadLine());
                        } while (alvo > 100);


                        if (alvo != marc && alvo <= 100)
                        {

                            if (alvo <= 9)
                            {
                                row = 0;
                                col = alvo - 1;

                                arvore[row, col] = 0;
                            }
                            if (alvo > 10 && alvo != 20 && alvo != 30 && alvo != 40 && alvo != 50 &&
                                alvo != 60 && alvo != 70 && alvo != 80 && alvo != 90 && alvo != 100)
                            {
                                row = alvo / 10;
                                col = (alvo % 10) - 1;

                                arvore[row, col] = 0;
                            }
                            if (alvo == 10 || alvo == 20 || alvo == 30 || alvo == 40 || alvo == 50 ||
                                alvo == 60 || alvo == 70 || alvo == 80 || alvo == 90 || alvo == 100)
                            {

                                row = (alvo / 10) - 1;
                                col = 9;

                                arvore[row, col] = 0;
                            }
                        }

                        if (alvo == marc)
                        {
                            acerto = true;
                        }

                        ammo--;

                        //verificação se alvo < 0 || alvo > 100

                    } while (ammo > 0 && acerto != true);

                    if (acerto == true)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Parabéns, você explodiu os miolos do marciano!");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    if (ammo == 0 && acerto == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Você foi levado para Marte!\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("  .     .  :     .    .. :. .___---------___.");
                        Console.WriteLine("       .  .   .    .  :.:. _\".^ .^ ^.  '.. :\"-_. .");
                        Console.WriteLine("    .  :       .  .  .:../:            . .^  :.: .");
                        Console.WriteLine("        .   . :: +. :.:/: .   .    .        . . .:\\");
                        Console.WriteLine(" .  :    .     . _ :::/:               .  ^ .  . .:\\");
                        Console.WriteLine("  .. . .   . - : :.:./.                        .  .:\\");
                        Console.WriteLine("  .      .     . :..|:                    .  .  ^. .:|");
                        Console.WriteLine("    .       . : : ..||        .                . . !:|");
                        Console.WriteLine("  .     . . . ::. ::\\(                           . :)/");
                        Console.WriteLine(" .   .     : . : .:.|. ######              .#######::|");
                        Console.WriteLine("  :.. .  :-  : .:  ::|.#######           ..########:|");
                        Console.WriteLine(" .  .  .  ..  .  .. :\\ ########          :######## :/");
                        Console.WriteLine("  .        .+ :: : -.:\\ ########       . ########.:/");
                        Console.WriteLine("    .  .+   . . . . :.:\\. #######       #######..:/");
                        Console.WriteLine("      :: . . . . ::.:..:.\\           .   .   ..:/");
                        Console.WriteLine("   .   .   .  .. :  -::::.\\.       | |     . .:/");
                        Console.WriteLine("      .  :  .  .  .-:.\":.::.\\             ..:/ ");
                        Console.WriteLine(" .      -.   . . . .: .:::.:.\\.           .:/");
                        Console.WriteLine(".   .   .  :      : ....::_:..:\\   ___.  :/");
                        Console.WriteLine("   .   .  .   .:. .. .  .: :.:.:\\       :/");
                        Console.WriteLine("     +   .   .   : . ::. :.:. .:.|\\  .:/|");
                        Console.WriteLine("     .         +   .  .  ...:: ..|  --.:|");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }

                    break;

                case 2:
                    Console.WriteLine("Case 2");
                    Console.Clear();
                    do
                    {
                        //escolher onde arvore está
                        Console.Write("Árvore do Marciano: ");
                        marc = int.Parse(Console.ReadLine());
                    } while (marc > 100);
                    //fim escolher arvore

                    //transformando marc em bidimencional para futura verificação
                    if (marc > 10 && marc != 20 && marc != 30 && marc != 40 && marc != 50 &&
                                marc != 60 && marc != 70 && marc != 80 && marc != 90 && marc != 100)
                    {
                        verow = marc / 10;
                        vecol = (marc % 10) - 1;
                    }
                    if (marc < 10)
                    {
                        verow = 0;
                        vecol = marc - 1;
                    }
                    if (marc == 10 || marc == 20 || marc == 30 || marc == 40 || marc == 50 ||
                                marc == 60 || marc == 70 || marc == 80 || marc == 90 || marc == 100)
                    {
                        verow = (marc / 10) - 1;
                        vecol = 9;
                    }

                    //populando
                    for (row = 0; row <= 9; row++)
                    {
                        for (col = 0; col <= 9; col++)
                        {
                            arvore[row, col] = (i + 1);
                            i++;
                        }
                    }

                    do
                    {
                        //dicas
                        Console.Clear();


                        if (alvo < marc && alvo != 0)
                        {
                            if (verow == row)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Estou mais à DIREITA");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Estou mais à BAIXO");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            }
                        }
                        if (alvo > marc && alvo != 0)
                        {
                            if (verow == row)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Estou mais à ESQUERDA");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Estou mais à CIMA");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            }




                        }

                        //visualizando
                        for (row = 0; row <= 9; row++)
                        {
                            for (col = 0; col <= 9; col++)
                            {
                                if (arvore[row, col] == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("♣({0:D2}) ", arvore[row, col]);
                                }
                                else
                                {
                                    //Console.BackgroundColor = ConsoleColor.DarkGreen;
                                    Console.ForegroundColor = ConsoleColor.Green;

                                    Console.Write("♣({0:D2}) ", arvore[row, col]);
                                }
                            }
                            Console.WriteLine(" ");
                        }

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;

                        Console.Write("Munição: {0}\n", ammo2);

                        Console.Write("\n");
                        do
                        {
                            Console.Write("Atirar: ");
                            alvo = int.Parse(Console.ReadLine());
                        } while (alvo > 100);


                        if (alvo != marc && alvo <= 100)
                        {

                            if (alvo <= 9)
                            {
                                row = 0;
                                col = alvo - 1;

                                arvore[row, col] = 0;
                            }
                            if (alvo > 10 && alvo != 20 && alvo != 30 && alvo != 40 && alvo != 50 &&
                                alvo != 60 && alvo != 70 && alvo != 80 && alvo != 90 && alvo != 100)
                            {
                                row = alvo / 10;
                                col = (alvo % 10) - 1;

                                arvore[row, col] = 0;
                            }
                            if (alvo == 10 || alvo == 20 || alvo == 30 || alvo == 40 || alvo == 50 ||
                                alvo == 60 || alvo == 70 || alvo == 80 || alvo == 90 || alvo == 100)
                            {

                                row = (alvo / 10) - 1;
                                col = 9;

                                arvore[row, col] = 0;
                            }
                        }

                        if (alvo == marc)
                        {
                            acerto = true;
                        }

                        ammo2--;

                        //verificação se alvo < 0 || alvo > 100

                    } while (ammo2 > 0 && acerto != true);

                    if (acerto == true)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Parabéns, você explodiu os miolos do marciano!");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    if (ammo2 == 0 && acerto == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Você foi levado para Marte!\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("  .     .  :     .    .. :. .___---------___.");
                        Console.WriteLine("       .  .   .    .  :.:. _\".^ .^ ^.  '.. :\"-_. .");
                        Console.WriteLine("    .  :       .  .  .:../:            . .^  :.: .");
                        Console.WriteLine("        .   . :: +. :.:/: .   .    .        . . .:\\");
                        Console.WriteLine(" .  :    .     . _ :::/:               .  ^ .  . .:\\");
                        Console.WriteLine("  .. . .   . - : :.:./.                        .  .:\\");
                        Console.WriteLine("  .      .     . :..|:                    .  .  ^. .:|");
                        Console.WriteLine("    .       . : : ..||        .                . . !:|");
                        Console.WriteLine("  .     . . . ::. ::\\(                           . :)/");
                        Console.WriteLine(" .   .     : . : .:.|. ######              .#######::|");
                        Console.WriteLine("  :.. .  :-  : .:  ::|.#######           ..########:|");
                        Console.WriteLine(" .  .  .  ..  .  .. :\\ ########          :######## :/");
                        Console.WriteLine("  .        .+ :: : -.:\\ ########       . ########.:/");
                        Console.WriteLine("    .  .+   . . . . :.:\\. #######       #######..:/");
                        Console.WriteLine("      :: . . . . ::.:..:.\\           .   .   ..:/");
                        Console.WriteLine("   .   .   .  .. :  -::::.\\.       | |     . .:/");
                        Console.WriteLine("      .  :  .  .  .-:.\":.::.\\             ..:/ ");
                        Console.WriteLine(" .      -.   . . . .: .:::.:.\\.           .:/");
                        Console.WriteLine(".   .   .  :      : ....::_:..:\\   ___.  :/");
                        Console.WriteLine("   .   .  .   .:. .. .  .: :.:.:\\       :/");
                        Console.WriteLine("     +   .   .   : . ::. :.:. .:.|\\  .:/|");
                        Console.WriteLine("     .         +   .  .  ...:: ..|  --.:|");
                        Console.ForegroundColor = ConsoleColor.DarkGray;

                    }
                    break;

                case 3:

                    Console.Clear();
                    do
                    {
                        //escolher onde arvore está
                        Console.Write("Árvore do Marciano: ");
                        marc = int.Parse(Console.ReadLine());
                    } while (marc > 100);
                    //fim escolher arvore

                    //transformando marc em bidimencional para futura verificação
                    if (marc > 10 && marc != 20 && marc != 30 && marc != 40 && marc != 50 &&
                                marc != 60 && marc != 70 && marc != 80 && marc != 90 && marc != 100)
                    {
                        verow = marc / 10;
                        vecol = (marc % 10) - 1;
                    }
                    if (marc < 10)
                    {
                        verow = 0;
                        vecol = marc - 1;
                    }
                    if (marc == 10 || marc == 20 || marc == 30 || marc == 40 || marc == 50 ||
                                marc == 60 || marc == 70 || marc == 80 || marc == 90 || marc == 100)
                    {
                        verow = (marc / 10) - 1;
                        vecol = 9;
                    }

                    //populando
                    for (row = 0; row <= 9; row++)
                    {
                        for (col = 0; col <= 9; col++)
                        {
                            arvore[row, col] = (i + 1);
                            i++;
                        }
                    }

                    do
                    {
                        //dicas
                        Console.Clear();
                        if (alvo < marc && alvo != 0)
                        {
                            if (verow == row)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Estou mais à DIREITA");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Estou mais à BAIXO");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            }
                        }
                        if (alvo > marc && alvo != 0)
                        {
                            if (verow == row)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Estou mais à ESQUERDA");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Estou mais à CIMA");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            }




                        }

                        //visualizando
                        for (row = 0; row <= 9; row++)
                        {
                            for (col = 0; col <= 9; col++)
                            {
                                if (arvore[row, col] == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("♣({0:D2}) ", arvore[row, col]);
                                }
                                else
                                {
                                    //Console.BackgroundColor = ConsoleColor.DarkGreen;
                                    Console.ForegroundColor = ConsoleColor.Green;

                                    Console.Write("♣({0:D2}) ", arvore[row, col]);
                                }
                            }
                            Console.WriteLine(" ");
                        }

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;

                        Console.Write("Munição: {0}\n", ammo3);

                        Console.Write("\n");
                        do
                        {
                            Console.Write("Atirar: ");
                            alvo = int.Parse(Console.ReadLine());
                        } while (alvo > 100);


                        if (alvo != marc && alvo <= 100)
                        {

                            if (alvo <= 9)
                            {
                                row = 0;
                                col = alvo - 1;

                                arvore[row, col] = 0;
                            }
                            if (alvo > 10 && alvo != 20 && alvo != 30 && alvo != 40 && alvo != 50 &&
                                alvo != 60 && alvo != 70 && alvo != 80 && alvo != 90 && alvo != 100)
                            {
                                row = alvo / 10;
                                col = (alvo % 10) - 1;

                                arvore[row, col] = 0;
                            }
                            if (alvo == 10 || alvo == 20 || alvo == 30 || alvo == 40 || alvo == 50 ||
                                alvo == 60 || alvo == 70 || alvo == 80 || alvo == 90 || alvo == 100)
                            {

                                row = (alvo / 10) - 1;
                                col = 9;

                                arvore[row, col] = 0;
                            }
                        }

                        if (alvo == marc)
                        {
                            acerto = true;
                        }

                        ammo3--;

                        //verificação se alvo < 0 || alvo > 100

                    } while (ammo3 > 0 && acerto != true);

                    if (acerto == true)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Parabéns, você explodiu os miolos do marciano!");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺ ☺");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    if (ammo3 == 0 && acerto == false)
                    {
                        Console.Clear();
                   
                        Console.WriteLine("Você foi levado para Marte!\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("  .     .  :     .    .. :. .___---------___.");
                        Console.WriteLine("       .  .   .    .  :.:. _\".^ .^ ^.  '.. :\"-_. .");
                        Console.WriteLine("    .  :       .  .  .:../:            . .^  :.: .");
                        Console.WriteLine("        .   . :: +. :.:/: .   .    .        . . .:\\");
                        Console.WriteLine(" .  :    .     . _ :::/:               .  ^ .  . .:\\");
                        Console.WriteLine("  .. . .   . - : :.:./.                        .  .:\\");
                        Console.WriteLine("  .      .     . :..|:                    .  .  ^. .:|");
                        Console.WriteLine("    .       . : : ..||        .                . . !:|");
                        Console.WriteLine("  .     . . . ::. ::\\(                           . :)/");
                        Console.WriteLine(" .   .     : . : .:.|. ######              .#######::|");
                        Console.WriteLine("  :.. .  :-  : .:  ::|.#######           ..########:|");
                        Console.WriteLine(" .  .  .  ..  .  .. :\\ ########          :######## :/");
                        Console.WriteLine("  .        .+ :: : -.:\\ ########       . ########.:/");
                        Console.WriteLine("    .  .+   . . . . :.:\\. #######       #######..:/");
                        Console.WriteLine("      :: . . . . ::.:..:.\\           .   .   ..:/");
                        Console.WriteLine("   .   .   .  .. :  -::::.\\.       | |     . .:/");
                        Console.WriteLine("      .  :  .  .  .-:.\":.::.\\             ..:/ ");
                        Console.WriteLine(" .      -.   . . . .: .:::.:.\\.           .:/");
                        Console.WriteLine(".   .   .  :      : ....::_:..:\\   ___.  :/");
                        Console.WriteLine("   .   .  .   .:. .. .  .: :.:.:\\       :/");
                        Console.WriteLine("     +   .   .   : . ::. :.:. .:.|\\  .:/|");
                        Console.WriteLine("     .         +   .  .  ...:: ..|  --.:|");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    break;
            }
            Console.ReadKey();
            // munição esta ficando negativa e usuario mesmo quando perde é mandado pra marte
        }
    }
}
