using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysMecanica
{
    public class ProdutoDao
    {
        public static List<Produto> _produtos = new List<Produto>();

        public void Add(Produto produto)
        {
            _produtos.Add(produto);
        }

        public Produto Buscar(int codigo)
        {
            return _produtos.FirstOrDefault(x => x.Codigo.Equals(codigo));
        }
    }
}
