using LivrariaApiModel.Dtos;
using LivrariaApiRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaApiBusiness
{
    public class LivroBusiness
    {
        public List<LivroDto> Listar()
        {
            var Livros = LivroRepositorio.Listar();
            if (Livros == null)
            {
                return new List<LivroDto>();
            }
            return LivroRepositorio.GerarDto(Livros);
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
