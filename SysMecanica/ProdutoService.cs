using Newtonsoft.Json;
using System;

namespace SysMecanica
{
    public class ProdutoService : IProdutoService
    {
        public Produto Buscar(string codigo)
        {
            ProdutoDao produtoDao = new ProdutoDao();
            return produtoDao.Buscar(Convert.ToInt32(codigo));
        }

        public bool Add(string json)
        {

            Produto produto = JsonConvert.DeserializeObject<Produto>(json);
            ProdutoDao produtoDao = new ProdutoDao();
            produtoDao.Add(produto);
            return true;
        }

        /*
            requisição POST passando objeto

            var dados = {Codigo:1, Descricao:'Cadeira', Preco: 200.00}

            var dadosString = JSON.stringify(dados)

            var xhr = new XMLHttpRequest();

            xhr.open("POST", "http://localhost:8080/produto/Add");

            xhr.setRequestHeader('Content-Type', 'application/json')

            var dadosString = JSON.stringify(dados)

            xhr.send(dadosString);

         */

        /*
          requisição GET

            var dados = {Codigo:1, Descricao:'Cadeira', Preco: '200.00'}

            var xhr = new XMLHttpRequest();

            var dadosString = JSON.stringify(dados)

            xhr.open("GET", "http://localhost:8080/produto/Add?json=" + dadosString);

            xhr.setRequestHeader('Content-Type', 'application/json')

            xhr.send();
         */
    }
}
