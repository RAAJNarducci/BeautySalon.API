using ProjetoBaseCore.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseCore.Domain.Entities
{
    public abstract class Dominio : EntityBase<Dominio>
    {
        public string Descricao { get; set; }

        public override bool EstaValido()
        {
            return true;
        }
    }
}
