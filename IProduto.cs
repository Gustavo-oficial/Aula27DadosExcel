namespace Aula27DadosExcel
{
    public interface IProduto
    {
        void Registrar(Produto prod);

         void Excluir(string _termo);

         void Alterar(Produto _produtoalterado);

        
    }
}