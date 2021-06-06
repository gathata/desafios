using System;
using System.Collections.Generic;
using Jitbit.Utils;

namespace desafios_06
{
    class Aluno
    {
        public string Nome;
        public string Nota;
        public string Idade;

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Desafio 06 da Thai \n======= == == ====\n");

            List <Aluno> listadeAlunos = new List<Aluno> ();
            listadeAlunos.Add(new Aluno() { Nome = "Naruto", Nota = "9", Idade = "10 anos" });
            listadeAlunos.Add(new Aluno() { Nome = "Itachi", Nota = "9", Idade = "16 anos" });
            listadeAlunos.Add(new Aluno() { Nome = "Sakura", Nota = "8", Idade = "15 anos" });

            var myExport = new CsvExport();

            foreach (var aluno in listadeAlunos)
            {
                myExport.AddRow();
	            myExport["Nome"] = aluno.Nome;
	            myExport["Nota"] = aluno.Nota;
	            myExport["Idade"] = aluno.Idade;   
            }
	
	        myExport.ExportToFile("Desafio_06_da_Thai.csv");
        }
    }
}
