using System;
using System.Collections.Generic;

namespace Aula27DadosExcel
{
    class Program
    {
        static void Main(string[] args)
        {
           Produto p1 = new Produto();
           p1.codigo =1;
           p1.Nome = "TV 70'";
           p1.Preco = 6000f;

           p1.Registrar(p1);
         

           List<Produto> lista = p1.Ler();

           foreach(Produto item in lista){
               Console.WriteLine($"{item.Nome} - ${item.Preco}");
           }
        }
    }
}
