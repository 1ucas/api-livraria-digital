using LivrariaApiModel.Dtos;
using LivrariaApiRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaApiBusiness
{
    public class LivrosBusiness
    {
        public List<LivroDto> Filtrar(int id = 0, string titulo = null, int autor = 0, int editora = 0)
        {
            var livrosFiltrados = LivroRepositorio.Listar().Where(l => (id == 0 ? true : l.Id == id) &&
                                                            (editora == 0 ? true : l.EditoraId == editora) &&
                                                                (autor == 0 ? true : l.AutorId == autor) &&
                                                                    (titulo == null ? true : l.Titulo.Contains(titulo))).ToList();
            if (livrosFiltrados.Any())
            {
                return LivroRepositorio.GerarDto(livrosFiltrados);

            }
            return null;
        }

        public LivroDto ObterPeloId(int id)
        {
            return LivroRepositorio.GerarDto(LivroRepositorio.ObterPeloId(id));
        }

        public int Criar(LivroDto livro)
        {
            return LivroRepositorio.InserirNovoItem(livro);
        }

        public int Inserir(int id, LivroDto livro)
        {
            var LivroExistente = LivroRepositorio.ObterPeloId(id);
            if (LivroExistente == null)
            {
                livro.Id = id;
                return LivroRepositorio.InserirNovoItem(livro);
            }
            else
            {
                LivroExistente.DataPublicacao =  DateTime.Parse(livro.DataPublicacao);
                LivroExistente.Titulo = livro.Titulo;
                LivroExistente.AutorId = livro.AutorId;
                LivroExistente.EditoraId = livro.EditoraId;
                return id;
            }
        }

        public void Remover(int id)
        {
            var LivroExistente = LivroRepositorio.Livros.FirstOrDefault(c => c.Id == id);
            LivroRepositorio.Livros.Remove(LivroExistente);
        }
    }
}
