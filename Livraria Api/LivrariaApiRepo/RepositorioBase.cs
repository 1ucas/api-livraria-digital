using LivrariaApiModel.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace LivrariaApiRepo
{
    public class RepositorioBase
    {
        public static T ObterPeloId<T>(List<T> lista, int id) where T : EntidadeBase
        {
            return lista.FirstOrDefault(c => c.Id == id);
        }

        public static int InserirNovoItem<T>(List<T> lista, T item) where T: EntidadeBase
        {
            var novoId = lista.Count == 0 ? 1 : lista.Max(c => c.Id) + 1;
            item.Id = novoId;
            lista.Add(item);
            return novoId;
        }
    }
}
