using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Domain.Util.Security
{
    public class Criptografia
    {
        /// <summary>
        /// criptografa o texto usando o algoritmo MD5 (não pode ser descriptografado)
        /// </summary>
        /// <param name="texto">Texto a ser criptografado</param>
        /// <returns>Hash de bytes gerado a partir do texto</returns>
        public static String EncriptMD5(String texto)
        {
            //Cria um objeto enconding para assegurar o padrão 
            //de encondig para o texto origem
            UnicodeEncoding ue = new UnicodeEncoding();

            //Retorna um byte array baseado no texto origem
            Byte[] ByteSourceText = ue.GetBytes(texto);

            //Instancia um objeto MD5
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            //Calcula o valor do hash para o texto origem
            Byte[] ByteHash = md5.ComputeHash(ByteSourceText);

            //Converte o valor obtido para o formato string
            return Convert.ToBase64String(ByteHash);
        }


        /// <summary>
        /// Criptografa o texto usando o algoritmo RSA (chave pública/privada)
        /// </summary>
        /// <param name="texto">Texto a ser criptografado</param>
        /// <returns></returns>
        public static String EncriptRSA(String texto)
        {
            StringBuilder ret = new StringBuilder();
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            try
            {
                //carrega a chave pública
                RSA.FromXmlString("<RSAKeyValue><Modulus>xLzhHlHBwH3rvCYfr0P8YhHHjsEjytUIhkH+IsgdUwRoqc0ZZPfrhKTmEe2d/B/bu9jcfiqNTZaU3RLWIAR2YX81/2TzE9IYo10D36MvuHY/BD9JsGb/i9qojvxUtk2AbjLWOx65lYH7CQWTyA9GOxN+IbA+xGoUkw0bxMJBsA0=</Modulus><Exponent>AQAB</Exponent><P>4lpuOd1eEfx4/+G+utkt4W7gns5iXJxMUZS9uadnzwrmroIgRbgGmF/xO5BUWh556jFh+JYqlTsazGIrqzmhww==</P><Q>3oFzUWZbTIqUuH15Q2u91sooft5ztB/uncBoU7fYRaJFwbi1idvA9yi/jpt2oVU7ARuWygJnmY+/poMSC5/57w==</Q><DP>AUgHxbYWGT33pWMuxDoEg3kwNlXuwp1z5SZVaJ6k/MwQAD7mVd6z0tsAL5kikRwJDqVW66RV+2BJR4zquF5sJw==</DP><DQ>Qvf5Sl2hSwdGvcReFBHAgH419AFmF6eovOglPlVODZ9KmYTLduOiT4F/Lh/Sc7pgWPQBzWkt30UprKc0bjVHFw==</DQ><InverseQ>0eqJFQH2PEtaGPB5SE1u5zZm4OC9yCVxGmRWYFBhRXz3JEb9e/4Z81HyDgrxxgyaCy8S2jQePUQ5Mav2w3axYg==</InverseQ><D>QozF9fSf/tZZnL6kryvnPuFWyOJqkh04EfpW1jstODzgjrfTZEU9BRSmwt/HNlcshEGabI9GVz2dw56wkgoQZNjGMRzG5Wj8kUsta4ws5O9OpKG9JlpR0RiZkYBrxf7472C+IioA1saxiUknJwPCjiEgaADj3FAT4v8/fLUOEv0=</D></RSAKeyValue>");

                //busca o numero máximo de bytes
                Int32 maxBytes = ((RSA.KeySize / 8) - 11) / 2;

                for (int i = 0; i <= texto.Length - 1; i += maxBytes)
                {
                    string bloco;
                    if ((i + maxBytes) >= texto.Length)
                    {
                        bloco = texto.Substring(i);
                    }
                    else
                    {
                        bloco = texto.Substring(i, maxBytes);
                    }

                    //Criptografa
                    Byte[] byteEncriptado = RSA.Encrypt(System.Text.Encoding.Unicode.GetBytes(bloco), false);
                    ret.Append(Convert.ToBase64String(byteEncriptado));

                }

                return ret.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        /// <summary>
        /// Descriptografa o texto criptografado pelo algoritmo RSA
        /// </summary>
        /// <param name="texto">texto a ser descriptografado</param>
        /// <returns></returns>
        public static String Decript(String texto)
        {
            StringBuilder ret = new StringBuilder();
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            try
            {
                //carrega a chave pública
                RSA.FromXmlString("<RSAKeyValue><Modulus>xLzhHlHBwH3rvCYfr0P8YhHHjsEjytUIhkH+IsgdUwRoqc0ZZPfrhKTmEe2d/B/bu9jcfiqNTZaU3RLWIAR2YX81/2TzE9IYo10D36MvuHY/BD9JsGb/i9qojvxUtk2AbjLWOx65lYH7CQWTyA9GOxN+IbA+xGoUkw0bxMJBsA0=</Modulus><Exponent>AQAB</Exponent><P>4lpuOd1eEfx4/+G+utkt4W7gns5iXJxMUZS9uadnzwrmroIgRbgGmF/xO5BUWh556jFh+JYqlTsazGIrqzmhww==</P><Q>3oFzUWZbTIqUuH15Q2u91sooft5ztB/uncBoU7fYRaJFwbi1idvA9yi/jpt2oVU7ARuWygJnmY+/poMSC5/57w==</Q><DP>AUgHxbYWGT33pWMuxDoEg3kwNlXuwp1z5SZVaJ6k/MwQAD7mVd6z0tsAL5kikRwJDqVW66RV+2BJR4zquF5sJw==</DP><DQ>Qvf5Sl2hSwdGvcReFBHAgH419AFmF6eovOglPlVODZ9KmYTLduOiT4F/Lh/Sc7pgWPQBzWkt30UprKc0bjVHFw==</DQ><InverseQ>0eqJFQH2PEtaGPB5SE1u5zZm4OC9yCVxGmRWYFBhRXz3JEb9e/4Z81HyDgrxxgyaCy8S2jQePUQ5Mav2w3axYg==</InverseQ><D>QozF9fSf/tZZnL6kryvnPuFWyOJqkh04EfpW1jstODzgjrfTZEU9BRSmwt/HNlcshEGabI9GVz2dw56wkgoQZNjGMRzG5Wj8kUsta4ws5O9OpKG9JlpR0RiZkYBrxf7472C+IioA1saxiUknJwPCjiEgaADj3FAT4v8/fLUOEv0=</D></RSAKeyValue>");

                //busca o número máximo de bytes
                Int32 maxBytes = 172;

                for (int i = 0; i <= texto.Length - 1; i += maxBytes)
                {
                    String bloco;
                    if ((i + maxBytes) >= texto.Length)
                    {
                        bloco = texto.Substring(i);
                    }
                    else
                    {
                        bloco = texto.Substring(i, maxBytes);
                    }

                    //descriptografa
                    Byte[] byteEncriptado = RSA.Decrypt(Convert.FromBase64String(bloco), false);
                    ret.Append(System.Text.Encoding.Unicode.GetString(byteEncriptado));


                }
                return ret.ToString();

            }

            catch
            {
                return texto;
            }
        }

    }
}
