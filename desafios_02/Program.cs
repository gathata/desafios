using System;

namespace desafios_02
{
    class Pessoa
    {
        public string nome;
        public string idade;
        public string sexo;

    }    

    class Program
    {
        
        static void PrintPessoa(Pessoa pessoa)
        {
            Console.WriteLine(pessoa.nome);
            Console.WriteLine(pessoa.sexo);
            Console.WriteLine(pessoa.idade);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Qual o seu nome?");
            string nome = Console.ReadLine();
            Console.WriteLine ("Qual sua idade?");
            string idade = Console.ReadLine();
            Console.WriteLine("Qual o seu sexo?");
            string sexo = Console.ReadLine ();

            Pessoa pessoa = new Pessoa ();
            pessoa.nome = nome;
            pessoa.idade = idade;
            pessoa.sexo = sexo;

            PrintPessoa (pessoa);
        }
    }
}
