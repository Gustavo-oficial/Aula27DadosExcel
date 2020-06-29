using System;

namespace Aula27DadosExcel
{
    class Program
    {
        static void Main(string[] args)
        {
           Produto p1 = new Produto();
           p1.codigo =1;
           p1.Nome = "Televisão 70'";
           p1.Preco = 6000f;

           p1.Registrar(p1);
        }
    }
}
