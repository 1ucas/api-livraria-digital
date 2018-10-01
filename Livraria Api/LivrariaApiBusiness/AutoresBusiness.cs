using LivrariaApiModel.Dtos;
using LivrariaApiRepo;
using System.Collections.Generic;
using System.Linq;

namespace LivrariaApiBusiness
{
    public class AutoresBusiness
    {
        public List<AutorDto> Listar()
        {
            return AutorRepositorio.GerarDto(AutorRepositorio.Listar());
        }

        public AutorDto ObterPeloId(int id)
        {
            return AutorRepositorio.GerarDto(AutorRepositorio.ObterPeloId(id));
        }

        public int Criar(AutorDto autor)
        {
            return AutorRepositorio.InserirNovoItem(autor);
        }

        public int Inserir(int id, AutorDto autor)
        {
            var autorExistente = AutorRepositorio.ObterPeloId(id);
            if (autorExistente == null)
            {
                autor.Id = id;
                return AutorRepositorio.InserirNovoItem(autor);
            }
            else
            {
                autorExistente.Nome = autor.Nome;
                return id;
            }
        }

        public void Remover(int id)
        {
            var autorExistente = AutorRepositorio.Autores.FirstOrDefault(c => c.Id == id);
            AutorRepositorio.Autores.Remove(autorExistente);
        }
    }
}
