using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace HSSolution.Application.Functions;

public static class Functions
{
    public static bool VerificaCPF(string cpf)
    {
        if (cpf == "11111111111" || cpf == "22222222222" || cpf == "33333333333" || cpf == "44444444444" || cpf == "55555555555" || cpf == "66666666666" || cpf == "77777777777" || cpf == "88888888888" || cpf == "99999999999" || cpf == "00000000000")
            return false;
        else if (Regex.IsMatch(cpf, @"(^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$)"))
            return validaCpf(cpf);
        else
            return false;
    }

    private static bool validaCpf(string cpf)
    {
        var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string tempCpf;
        string digito;
        int soma;
        int resto;

        cpf = cpf.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Length != 11)
            return false;

        tempCpf = cpf.Substring(0, 9);

        soma = 0;

        for (int i = 0; i < 9; i++)
        {
            soma += int.Parse(tempCpf[i].ToString()) * (multiplicador1[i]);
        }

        resto = soma % 11;

        resto = resto < 2 ? 0 : 11 - resto;

        digito = resto.ToString();
        tempCpf = tempCpf + digito;

        int soma2 = 0;

        for (int i = 0; i < 10; i++)
            soma2 += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma2 % 11;

        resto = resto < 2 ? 0 : 11 - resto;

        digito = digito + resto.ToString();
        return cpf.EndsWith(digito);
    }
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
}




