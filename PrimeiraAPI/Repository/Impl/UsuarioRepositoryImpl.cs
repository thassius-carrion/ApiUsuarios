using PrimeiraAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiraAPI.Repository.Impl
{
    public class UsuarioRepositoryImpl : IUsuarioRepository
    {
        private readonly PrimeiraAPIContext _context;
        public UsuarioRepositoryImpl(PrimeiraAPIContext context)
        {
            _context = context;
        }
        public void Salvar(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        
    }
}
