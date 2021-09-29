using PrimeiraAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiraAPI.Repository
{
    public interface IUsuarioRepository
    {
        public void Salvar(Usuario usuario);
    }
}
