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
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }
          public void Registrar(Produto produto){
            
            var linha = new string []  { CriarLinha(produto)};
            File.AppendAllLines(PATH, linha);
          }

        private string CriarLinha(Produto p){
              return $"{p.codigo};{p.Nome};{p.Preco}";
          }
        }
    }