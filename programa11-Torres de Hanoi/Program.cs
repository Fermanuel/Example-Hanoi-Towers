using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace programa11_Torres_de_Hanoi
{
    internal class Program
    {
        public class Hanoi
        {
            public int moviminetos = 0;
            public void hanoi(int n, string origen, string auxiliar, string destino)
            {

                if (n == 1)
                {
                    Console.WriteLine(origen + " -> " + destino);
                    moviminetos++;
                }
                else
                {
                    moviminetos++;
                    hanoi(n - 1, origen, destino, auxiliar);
                    Console.WriteLine(origen + " -> " + destino);
                    hanoi(n - 1, auxiliar, origen, destino);
                }
            }
        }
        static void Main(string[] args)
        {
            char op = 'w';
            string a;

            int n;

            Stopwatch sw = Stopwatch.StartNew();
            Hanoi h = new Hanoi();

            long totalInicio = System.GC.GetTotalMemory(true);

            Console.Title = "Programa11-Torres de Hanoi.";
            do
            {
                Console.Clear();
                Console.WriteLine("TORRES DE HANOI");
                Console.WriteLine("\na) Calcular Movimientos.");
                Console.WriteLine("b) Salir del Programa.");
                Console.Write("\nOPCION: ");
                try
                {
                    op = char.Parse(Console.ReadLine());

                    switch (op)
                    {
                        case 'a':
                            
                            Console.Clear();
                            Console.Write("Numeros de Discos a Mover: ");
                            a= Console.ReadLine();
                            
                            n=int.Parse(a);

                            Console.WriteLine("\nLos movimientos a realizar son: \n");
                            
                            h.hanoi(n, "Origen", "Auxiliar", "Destino");
                            Console.WriteLine("\nEl número total de movimientos es: {0}",h.moviminetos+ "\n");

                            break;

                        case 'b':
                            sw.Stop();

                            TimeSpan ts = sw.Elapsed;

                            string elapsedTime = string.Format("\n{0:00}:{1:00}:{2:00}:{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
                            Console.WriteLine("\nRun Time" + elapsedTime + " Milisegundos");

                            long totalFin = System.GC.GetTotalMemory(true);

                            Console.WriteLine("\nLa Cantidad de memoria en bytes utilizada es de: {0}", totalFin - totalInicio);

                            sw.Restart();
                            break;

                        default:
                            Console.WriteLine("\nOpcion Invalida");
                            break;
                    }
                }
                catch (FormatException g)
                {
                    Console.WriteLine("\n{0}",g.Message);
                }
                finally
                {
                    Console.WriteLine("\nPresione <ENTER> para Continuar...");
                    Console.ReadKey();
                }

            } while (op!='b');
        }
    }
}
