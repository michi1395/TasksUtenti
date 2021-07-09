using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksUtenti
{
    class Task
    {
        public string Descrizione { get; set; }
        public DateTime DataScadenza { get; set; }
        public Priorità Livello { get; set; }

        public Task()
        {

        }

        public enum Priorità
        {
            Basso,
            Medio,
            Alto
        }

    }
}
