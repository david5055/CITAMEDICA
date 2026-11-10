
using System;
using System.Security.Cryptography;

namespace medicitass
{
    public static class SeguridadPassword
    {
        // CREAR HASH DE CONTRASEÑA
        public static string CrearHash(string contrasena)
        {
            byte[] salt = new byte[16];

            using (RandomNumberGenerator rng =
                RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(
                contrasena,
                salt,
                100000,
                HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(32);

                return "PBKDF2-SHA256$100000$" +
                    Convert.ToBase64String(salt) + "$" +
                    Convert.ToBase64String(hash);
            }
        }

        // VERIFICAR CONTRASEÑA
        public static bool Verificar(
            string contrasena,
            string hashGuardado)
        {
            try
            {
                string[] partes = hashGuardado.Split('$');

                if (partes.Length != 4 ||
                    partes[0] != "PBKDF2-SHA256")
                {
                    return false;
                }

                int iteraciones = int.Parse(partes[1]);

                if (iteraciones < 100000 ||
                    iteraciones > 1000000)
                {
                    return false;
                }

                byte[] salt =
                    Convert.FromBase64String(partes[2]);

                byte[] hashOriginal =
                    Convert.FromBase64String(partes[3]);

                if (salt.Length != 16 ||
                    hashOriginal.Length != 32)
                {
                    return false;
                }

                using (var pbkdf2 = new Rfc2898DeriveBytes(
                    contrasena,
                    salt,
                    iteraciones,
                    HashAlgorithmName.SHA256))
                {
                    byte[] hashNuevo = pbkdf2.GetBytes(32);

                    int diferencia = 0;

                    for (int i = 0; i < 32; i++)
                    {
                        diferencia |=
                            hashNuevo[i] ^ hashOriginal[i];
                    }

                    return diferencia == 0;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
