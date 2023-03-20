using System;

namespace GeradorCPF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nome;
            string singleName;
            string email;
            string cpf;string rg;
            string telefone;string telefonecpf;
            string cep;
            while (true)
            {
                nome = GerarNome();
                rg = GerarRg();
                cpf = GerarCpf();
                cep = GerarCep();
                telefonecpf = cpf.Replace(".", "").Replace("-","");
                telefone = Convert.ToUInt64(telefonecpf).ToString(@"\(00\)00000\-0000");
                singleName = nome.Split(" ")[0].ToString();
                email = singleName+nome.Split("  ")[1].ToString();
                Console.WriteLine("Nome: " + nome.Split("  ")[0].ToString());
                Console.WriteLine("Email: " + email);
                Console.WriteLine("Telefone: " + telefone);
                Console.WriteLine("RG: " + rg);
                Console.WriteLine("RG: " + rg.Replace(".","").Replace("-", ""));
                Console.WriteLine("CPF: " + cpf);
                Console.WriteLine("CPF: " + cpf.Replace(".","").Replace("-", ""));
                Console.WriteLine("CEP: " + cep);
                Console.WriteLine("CEP: " + cep.Replace("-", "") + Environment.NewLine);
            }
        }

        private static String GerarCpf()
        {
            int soma = 0, resto = 0;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new Random();
            string cpf = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            cpf = cpf + resto;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            cpf = cpf + resto;
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }
        private static String GerarRg()
        {
            Random rnd = new Random();
            string rg = rnd.Next(100000000, 999999999).ToString();

            return Convert.ToUInt64(rg).ToString(@"00\.000\.000\-0");
        }
        private static String GerarCep()
        {
            Random rnd = new Random();
            string cep = rnd.Next(10000000, 99999999).ToString();

            return Convert.ToUInt64(cep).ToString(@"00000\-000"); ;
        }
        private static String GerarNome()
        {
            var random = new Random();
            var nomes = new[] { "Giovane", "Fernando", "Jorge", "Sidnaldo", "Rodolfo", "Rafael", "Efraim" };
            var sobrenomes = new[] { "Porsche", "Tesla", "Ferrari", "Audi", "Bmw", "Lexus", "Mercedes-Benz", "Volvo", "Lamborghini", "Mazda" };
            var emails = new[] { "@gmail.com", "@actdigital.com.br", "@bocombbm.com.br", "@hotmail.com", "@gov.br" };
            return nomes[random.Next(nomes.Length)] + " " + sobrenomes[random.Next(sobrenomes.Length)] + "  " + emails[random.Next(emails.Length)];
        }
    }
}
