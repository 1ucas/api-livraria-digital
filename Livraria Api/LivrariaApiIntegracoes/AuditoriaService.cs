using LivrariaApiModel.Entidades;
using LivrariaApiModel.Inputs;
using LivrariaApiModel.Outputs;
using System;
using System.Collections.Generic;

namespace LivrariaApiServices
{
    public class AuditoriaService : BaseService
    {
        public AuditoriaService(string authToken) : base(authToken)
        {
        }

        public void Auditar(int clienteId, int livroId, int valor, string cartao)
        {
            var input = new AuditoriaInput
            {
                IdRecurso = 1,
                LogMessagem = "Compra realizada",
                Valor = valor,
                NumeroCartao = cartao,
                Cliente = new Usuario
                {
                    Id = clienteId
                },
                Livro = new Livro
                {
                    Id = livroId
                }
            };
            var response = Post<AuditoriaOutput>("auditoria", input, false);
        }

    }
}
