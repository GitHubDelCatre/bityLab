using System.Security.Cryptography;
using System.Text;

namespace lib_bytelab.nucleo
{
    public class Seguridad
    {
        /// <summary>Convierte la contraseña en un hash SHA256 (nunca se guarda la contraseña plana).</summary>
        public static string Cifrar(string clave)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(clave));
            return Convert.ToHexString(bytes);
        }
    }
}
