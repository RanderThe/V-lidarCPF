using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t === Validador de CPF === \n");

            Console.Write("Insira seu primeiro nome: ");
            string nome = Console.ReadLine();

            Console.Write("\nInsira seu sobrenome: ");
            string sobrenome = Console.ReadLine();

            Console.Write("\nInsira sua idade: ");
            int idade = int.Parse(Console.ReadLine());

            Console.Write("\nInsira seu CPF: ");
            string cpf = Console.ReadLine();

            Pessoa pessoa = new Pessoa(nome, sobrenome, idade, cpf);

            if (pessoa.ValidarCPF())
                Console.WriteLine("CPF VÁLIDO!");
            else
                Console.WriteLine("CPF INVÁLIDO!");

            Console.Write("Programa finalizado, tecle algo para fechar...");
            Console.ReadKey();
        }
    }

    class Pessoa
    {
        public string nome;
        private string sobrenome;
        private int idade;
        private string cpf;

        public Pessoa(string nome, string sobrenome, int idade, string cpf)
        {
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.idade = idade;
            this.cpf = cpf;
        }
        public string Nome()
        {
            return (nome);
        }
        public string SobreNome()
        {
            return (sobrenome);
        }
        public int Idade()
        {
            return (idade);
        }
        public string Cpf()
        {
            return (cpf);
        }

        static void valida(int[] a, ref int dgverif1, ref int dgverif2, ref bool valido)
        {
            int x = 0, result = 0;
            int sum = 0;
            valido = false;
            for (int i = 0, j = 10; i <= 8; i++, j--)
            {
                x = Convert.ToInt32(a[i]) * j;
                sum += x;
            }
            result = sum % 11;
            if (result < 2)
                dgverif1 = 0;
            else
            {
                dgverif1 = (11 - result);
            }

            sum = 0; result = 0; x = 0;
            for (int i = 0, j = 11; i <= 9; i++, j--)
            {
                x = Convert.ToInt32(a[i]) * j;
                sum += x;
            }
            result = sum % 11;
            if (result < 2)
                dgverif2 = 0;
            else
            {
                dgverif2 = (11 - result);
            }
            if (a[9] == dgverif1 && a[10] == dgverif2)
                valido = true;
        }

        public bool ValidarCPF()
        {
            this.cpf = Regex.Replace(this.cpf, "[^0-9]+", "");

            if (Regex.IsMatch(this.cpf, "(^0+$|^1+$|^2+$|^3+$|^4+$|^5+$|^6+$|^7+$|^8+$|^9+$)", RegexOptions.Multiline))
                return false;

            if (this.cpf.Length == 11)
            {
                int[] cpf = new int[11];
                for (int i = 0; i < 11; i++)
                {
                    cpf[i] = int.Parse(this.cpf[i].ToString());
                }
                int v1 = 0, v2 = 0;
                bool valido = false;
                valida(cpf, ref v1, ref v2, ref valido);
                return (valido);
            }
            else
                return (false);
        }
    }
}






/*    
 * 
 *          //Remover todos os caracteres não numéricos usando expressão regular no C#
 *          
 * 
 * 
 * 
 * 
 *          
        int[] cpf = new int[10];
            Console.WriteLine("Digite o CPF: (11 digitos)");
            lerCpf(cpf);
            validar(cpf);
            Console.WriteLine(":");
            imprime(cpf);
            Console.ReadKey();
        }

        static void lerCpf(int[] v)
        {
            for (int i = 0; i < v.Length-1; i++)
            {
                v[i] = int.Parse(Console.ReadLine());
            }
        }
        static void validar(int[] a)
        {
            int x = 0,result = 0, j=10 ;
            for (int i = 0; a[i] <= 8; i++)
            {                
                x = a[i] * j;                
                j--;
            }            
            result = x/11;
        }


        static void imprime(int[] v)
        {
            for (int i = 0; i <= v.Length - 1; i++)
            {

                Console.Write(v[i] + "");
            }
        }*/
