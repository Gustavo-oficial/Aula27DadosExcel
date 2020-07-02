using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aula27DadosExcel
{
    public class Produto : IProduto
    {
        
        public string Nome { get; set; }

        public int codigo { get; set; }

        public float Preco { get; set; }

        public string _termo;

        private const string PATH = "Database/produto.csv";
       
        public Produto()
        {         
            string pasta = PATH.Split('/')[0];

            if(!Directory.Exists(pasta)){
                Directory.CreateDirectory(pasta);
            }
            
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }
          public void Registrar(Produto prod){
            
            string [] linha = new string []  { CriarLinha(prod)};
            File.AppendAllLines(PATH, linha);
          }


           public List<Produto> Ler()
        {
      
            List<Produto> produtos = new List<Produto>();

            string[] linhas = File.ReadAllLines(PATH);

            // Varremos nossas linhas
            foreach(string linha in linhas)
            {

                string[] dado = linha.Split(";");

                Produto p   = new Produto();
                p.codigo    = Int32.Parse( Separar(dado[1]) );
                p.Nome      = Separar(dado[0]);
                p.Preco     = float.Parse( Separar(dado[2]) );

                produtos.Add(p);
            }
            produtos = produtos.OrderBy(z => z.Nome).ToList();
            return produtos;
        }


        // o metodo busca um codigo e nome dentro dos produtos 
          public List<Produto> Buscar(string _nome)
        {
            return Ler().FindAll(x => x.Nome == _nome);
        }

        // metodo para remover um produto e mostrar as outras linhas
        public void Excluir(string _termo){
            List<string> linhas = new List<string>();
            {
              ReescreverLinha(linhas, _termo);
              linhas.RemoveAll(z => z.Contains(_termo));
            }
              // output.Write(String.Join(Environment.NewLine, linhas.ToArray()));
            ReescreverCsv(linhas);
        }

        public void Alterar(Produto _produtoalterado){
          
         List<string> linhas = new List<string>();

            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha = arquivo.ReadLine()) != null){
                    linhas.Add(linha);
                }
            }
          linhas.RemoveAll(z => z.Split(";")[0].Contains(_produtoalterado.codigo.ToString()));
        
        }
        private void ReescreverCsv(List<string> lines){
             
             using(StreamWriter output = new StreamWriter(PATH)){
              foreach(string ln in lines){
                output.Write(ln + "\n");
              }
            }
        }

        private void ReescreverLinha(List<string> lines, string _termo){
              using(StreamReader file = new StreamReader(PATH)){
              string linha;
              while ((linha = file.ReadLine()) != null)
              {
                   lines.Add(linha);
              }
            }

        }
    
        public string Separar(string dado)
        {
            return dado.Split("=")[1];
        }
        private string CriarLinha(Produto p){
              return $"{p.codigo};{p.Nome};{p.Preco} \n";
          }
        }
    }