using MongoRepository;
using mongoTestes.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mongoTestes
{
    class Program
    {

        static MongoRepository<Pessoas> pessoasRepo = new MongoRepository<Pessoas>();
        static void Main(string[] args)
        {

            var cliente = new Pessoas() { Nome = "Mario Aécio", Email = "amario@gmail.com", DtNasc = new DateTime(1974, 06, 28), Enderecos= new List<Enderecos>() { new Enderecos { Bairro="Vila aaa", End="rua ddas merces" } } };
            var cliente2 = new Pessoas() { Nome = "Jesse Jones", Email = "jess@gmail.com", DtNasc = new DateTime(1974, 06, 28), Enderecos = new List<Enderecos>() { new Enderecos { Bairro = "Vila aaa", End = "rua ddas merces" } } };

            pessoasRepo.Add(new[] { cliente, cliente2});

            DumpData();

            //atualiza o mario..
            cliente.Nome = "Agora não é mais Mario..";
            pessoasRepo.Update(cliente);

            cliente2.Enderecos[0].Tipo = "rua";
            pessoasRepo.Update(cliente2);

            //pessoasRepo.Delete(cliente2.Id);

            Console.WriteLine("Press any key...");
            Console.ReadKey();

        }

        public static void DumpData() {

            Console.WriteLine("Total de pessoas em seu banco: {0}", pessoasRepo.Count());

            foreach (var p in pessoasRepo)
            {
                Console.WriteLine("{0}\t{1} has {2} pessoas", p.Nome, p.Email, p.DtNasc);
                foreach (var e in p.Enderecos)
                {
                    Console.WriteLine("\t{0}, tipo {1}", e.End, e.Tipo);
                }
                Console.WriteLine(new string('=', 50));
            }

        } 

    }
}
