using LivrariaApiModel.Dtos;
using LivrariaApiRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaApiBusiness
{
    public class ComentarioBusiness
    {
        public List<ComentarioDto> Listar(int pagina, int itensPorPagina)
        {
            var comentarios = ComentarioRepositorio.Listar(pagina, itensPorPagina);
            if (comentarios == null)
            {
                return new List<ComentarioDto>();
            }
            return ComentarioRepositorio.GerarDto(comentarios);
        }

        public ComentarioDto ObterPeloId(int id)
        {
            return ComentarioRepositorio.GerarDto(ComentarioRepositorio.ObterPeloId(id)));
        }

        public int Criar(ComentarioDto Comentario)
        {
            return ComentarioRepositorio.InserirNovoItem(Comentario);
        }

        public int Inserir(int id, ComentarioDto Comentario)
        {
            var ComentarioExistente = ComentarioRepositorio.ObterPeloId(id);
            if (ComentarioExistente == null)
            {
                Comentario.Id = id;
                return ComentarioRepositorio.InserirNovoItem(Comentario);
            }
            else
            {
                ComentarioExistente.Conteudo = Comentario.Conteudo;
                return id;
            }
        }

        public void Remover(int id)
        {
            var ComentarioExistente = ComentarioRepositorio.Comentarios.FirstOrDefault(c => c.Id == id);
            ComentarioRepositorio.Comentarios.Remove(ComentarioExistente);
        }

    }
}
