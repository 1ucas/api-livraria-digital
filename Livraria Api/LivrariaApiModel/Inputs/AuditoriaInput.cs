using LivrariaApiModel.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaApiModel.Inputs 
{
    public class AuditoriaInput : BaseInput
    {
        public int IdRecurso { get; set; }
        public string LogMessagem { get; set; }
        public double Valor { get; set; }
        public string NumeroCartao { get; set; }
        public Usuario Cliente { get; set; }
        public Livro Livro { get; set; }
    }
}
