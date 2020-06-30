using System;
using System.Collections.Generic;
using System.IO;

namespace Aula27DadosExcel
{
    public class Produto
    {
        
        public string Nome { get; set; }

        public int codigo { get; set; }

        public float Preco { get; set; }

        private const string PATH = "Database/produto.csv";
       
        public Produto()
        {         
            string pasta = PATH.Split('/')[0];

            if(!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }
            
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }
          public void Registrar(Produto prod){
            
            var linha = new string []  { CriarLinha(prod)};
            File.AppendAllLines(PATH, linha);
          }


          public List<Produto> Ler()
          {
            List<Produto> produto = new List<Produto>();

            string []  linhas = File.ReadAllLines(PATH);

            foreach(string linha in linhas)
            {
              string[] dado = linha.Split(";");

              Produto p = new Produto();

              p.codigo = Int32.Parse( Separar (dado[0]));
              p.Nome = Separar (dado [1]);
              p.Preco = float.Parse(Separar (dado[2]));

              produto.Add(p);
            }
            return produto;
          }  

          public string Separar(string dado){
            return dado.Split("=")[1];
          }
        private string CriarLinha(Produto p){
              return $"{p.codigo};{p.Nome};{p.Preco}";
          }
        }
    }