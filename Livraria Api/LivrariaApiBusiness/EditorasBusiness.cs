using LivrariaApiModel.Dtos;
using LivrariaApiRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaApiBusiness
{
    public class EditorasBusiness
    {
        public List<EditoraDto> Listar()
        {
            var Editoras = EditoraRepositorio.Listar();
            if (Editoras == null)
            {
                return new List<EditoraDto>();
            }
            return EditoraRepositorio.GerarDto(Editoras);
        }

        public EditoraDto ObterPeloId(int id)
        {
            return EditoraRepositorio.GerarDto(EditoraRepositorio.ObterPeloId(id));
        }

        public int Criar(EditoraDto Editora)
        {
            return EditoraRepositorio.InserirNovoItem(Editora);
        }

        public int Inserir(int id, EditoraDto Editora)
        {
            var EditoraExistente = EditoraRepositorio.ObterPeloId(id);
            if (EditoraExistente == null)
            {
                Editora.Id = id;
                return EditoraRepositorio.InserirNovoItem(Editora);
            }
            else
            {
                EditoraExistente.Nome = Editora.Nome;
                return id;
            }
        }

        public void Remover(int id)
        {
            var EditoraExistente = EditoraRepositorio.Editoras.FirstOrDefault(c => c.Id == id);
            EditoraRepositorio.Editoras.Remove(EditoraExistente);
        }

    }
}
