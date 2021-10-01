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

        public List<Usuario> GetUsuarios()
        {
            return _context.Usuario.ToList();
        }

        public Usuario GetUsuarioById(int Id)
        {
            return _context.Usuario.Find(Id);
        }

        public void DeleteUsuarioById(int Id)
        {
            _context.Usuario.Remove(GetUsuarioById(Id));
            _context.SaveChanges();
        }

        public void Salvar(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            _context.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            _context.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }

        public bool IsUsuarioEIdValido(Usuario usuario, int Id)
        {
            if(usuario == null || Id <= 0)
            {
                return false;
            }
            return true;
        }
          
    }
}
