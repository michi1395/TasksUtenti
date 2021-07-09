using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksUtenti
{
    class Menù
    {
        static public void Start()
        {
            Console.WriteLine("Benvenuto!");
            int scelta = 0;
            do
            {
                Console.WriteLine("\nPremi 1 per Vedere tutti i tasks");
                Console.WriteLine("Premi 2 per Aggiungere un nuovo task");
                Console.WriteLine("Premi 3 per Eliminare task");
                Console.WriteLine("Premi 4 per Cercare task per priorità");
                Console.WriteLine("Premi 0 per Uscire");



                bool isInt = true;

                do
                {
                    isInt = int.TryParse(Console.ReadLine(), out scelta);
                    if (!isInt)
                    {
                        Console.WriteLine("La scelta è sbagliata... Riprova");
                    }
                } while (!isInt);
                switch (scelta)
                {
                    case 1:
                        TasksManager.VisualizzaTasks();
                        break;
                    case 2:
                        TasksManager.AggiungiTask();
                        break;
                    case 3:
                        TasksManager.EliminaTask();
                        break;
                    case 4:
                        TasksManager.CercaTask();
                        break;
                    case 0:
                        TasksManager.SalvaSuFile();
                        break;
                    default:
                        Console.WriteLine("La scelta è sbagliata... Riprova");
                        break;

                }
            } while (scelta != 0);
        }
    }
}

