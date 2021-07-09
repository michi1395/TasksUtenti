using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TasksUtenti.Task;

namespace TasksUtenti
{
    class TasksManager
    {
        static List<Task> tasks = new List<Task>();
        static string path = @"E:\Pink Academy\TasksUtente.txt";
        public static void VisualizzaTasks()
        {
            VisualizzaTasks(tasks);
        }
        public static void VisualizzaTasks(List<Task> tasks)
        {
            if (tasks.Count > 0)
            {
                int count = 1;
                Console.WriteLine("Descrizione\t\t\t\t\t Data scadenza\t\t Priorità");
                foreach (Task task in tasks)
                {
                    if(task.Descrizione.Length>8 && task.Descrizione.Length <= 17)
                    { 
                        Console.WriteLine($"{count} -> {task.Descrizione}\t\t\t\t {task.DataScadenza.Day}/{task.DataScadenza.Month}/{task.DataScadenza.Year}\t\t {task.Livello}");
                        count++;
                    }
                    else if(task.Descrizione.Length > 17 && task.Descrizione.Length <=24)
                    {
                        Console.WriteLine($"{count} -> {task.Descrizione}\t\t\t {task.DataScadenza.Day}/{task.DataScadenza.Month}/{task.DataScadenza.Year}\t\t {task.Livello}");
                        count++;
                    }
                    else if (task.Descrizione.Length > 24 && task.Descrizione.Length <=32)
                    {
                        Console.WriteLine($"{count} -> {task.Descrizione}\t\t\t {task.DataScadenza.Day}/{task.DataScadenza.Month}/{task.DataScadenza.Year}\t\t {task.Livello}");
                        count++;
                    }
                    else
                    {
                        Console.WriteLine($"{count} -> {task.Descrizione}\t\t\t\t\t {task.DataScadenza.Day}/{task.DataScadenza.Month}/{task.DataScadenza.Year}\t\t {task.Livello}");
                        count++;
                    }

                }

            }
            else
            {
                Console.WriteLine("Nessun task presente!");
            }
        }
        public static void AggiungiTask()
        {
            Task task = new Task();
            Console.WriteLine("\n");
            Console.WriteLine("Inserisci la descrizione");
            task.Descrizione = Console.ReadLine();


            bool isDate = true;
            DateTime dataInserita;
            DateTime now = DateTime.Now.Date;
            
            do
            {
                Console.WriteLine("\nInserisci la data di scadenza:");
                isDate = DateTime.TryParse(Console.ReadLine(), out dataInserita);


            } while (!isDate || dataInserita > now);

            task.DataScadenza = dataInserita;

            Console.WriteLine("\nInserisci la priorità:");
            task.Livello = InserisciPriorità();

            tasks.Add(task);
        }
        public static Priorità InserisciPriorità()
        {

            Console.WriteLine($"Premi {(int)Priorità.Basso} per creare un task con priorità {Priorità.Basso}");
            Console.WriteLine($"Premi {(int)Priorità.Medio} per creare un task con priorità {Priorità.Medio}");
            Console.WriteLine($"Premi {(int)Priorità.Alto} per creare un task con priorità {Priorità.Alto}");
            int tipo = Check();
            return (Priorità)tipo;


        }
        public static void EliminaTask()
        {
            Console.WriteLine("SELEZIONA IL TASK DA CANCELLARE");
            Console.WriteLine("");
            VisualizzaTasks();
            int numTask = 0;
            bool isInt = false;
            do
            {
                isInt = int.TryParse(Console.ReadLine(), out numTask);
            } while (!isInt || numTask < 0 || numTask > tasks.Count);

            Task taskDaEliminare = tasks.ElementAt(numTask - 1);
            tasks.Remove(taskDaEliminare);
        }

        public static void CercaTask()
        {
            Console.WriteLine("Inserisci la priorità da cercare");
            Priorità livelloTask = InserisciPriorità();

            List<Task> tasksPerPriorità = new List<Task>();
            foreach (Task task in tasks)
            {
                if (task.Livello == livelloTask)
                {
                    tasksPerPriorità.Add(task);
                }
            }
            if (tasksPerPriorità.Count > 0)
            {
                VisualizzaTasks(tasksPerPriorità);
            }
            else
            {
                Console.WriteLine($"Non sono presenti tasks con priorità {livelloTask}");
            }

        }
        public static void SalvaSuFile()
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Descrizione\t\t\t\t Data scadenza\t\t Priorità");
            }
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                foreach (Task task in tasks)
                {
                    if (task.Descrizione.Length > 8 && task.Descrizione.Length <= 17)
                    {
                        sw.WriteLine($"{task.Descrizione}\t\t\t\t {task.DataScadenza.Day}/{task.DataScadenza.Month}/{task.DataScadenza.Year}\t\t {task.Livello}");

                    }
                    else if (task.Descrizione.Length > 17 && task.Descrizione.Length < 24)
                    {
                        sw.WriteLine($"{task.Descrizione}\t\t\t {task.DataScadenza.Day}/{task.DataScadenza.Month}/{task.DataScadenza.Year}\t\t {task.Livello}");

                    }
                    else if (task.Descrizione.Length > 24 && task.Descrizione.Length <=32)
                    {
                        sw.WriteLine($"{task.Descrizione}\t\t {task.DataScadenza.Day}/{task.DataScadenza.Month}/{task.DataScadenza.Year}\t\t {task.Livello}");

                    }
                    else
                    {
                        sw.WriteLine($"{task.Descrizione}\t\t\t\t\t {task.DataScadenza.Day}/{task.DataScadenza.Month}/{task.DataScadenza.Year}\t\t {task.Livello}");
                    }
                }
            }
        }

        public static int Check()
        {
            int num = 0;
            while (!int.TryParse(Console.ReadLine(), out num) || num < 0 || num > 2)
            {
                Console.WriteLine("Puoi inserire solo 0, 1 o 2! Riprova:");
            }

            return num;

        }
    }
}
