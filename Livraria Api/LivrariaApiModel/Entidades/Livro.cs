﻿
namespace LivrariaApiModel.Entidades
{
    public class Livro : EntidadeBase
    {
        public string Titulo { get; set; }
        public int EditoraId { get; set; }
    }
}