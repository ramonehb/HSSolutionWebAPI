using System.Security.Cryptography;
using System.Text;

namespace HSSolution.Domain;

public static class Criptografia
{
    public static string Hash(string senha)
    {
        using SHA256 hasher = SHA256.Create();

        byte[] dados = hasher.ComputeHash(Encoding.UTF8.GetBytes(senha));

        StringBuilder sBuilder = new StringBuilder();

        for (int i = 0; i < dados.Length; i++)
        {
            sBuilder.Append(dados[i].ToString("X2"));
        }

        return sBuilder.ToString();
    }
}

