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

        public List<Usuario> GetUsuarios();

        public Usuario GetUsuarioById(int Id);

        public void DeleteUsuarioById(int Id);

        public void AtualizarUsuario(Usuario usuario);
        public bool IsUsuarioEIdValido(Usuario usuario, int Id);
    }
}
