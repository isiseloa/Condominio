using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Util
{
    /// <summary>
    /// classe para verificação de tipos
    /// </summary>
    public class Utilities
    {

        /// <summary>
        /// verifica se uma string é um numero válido
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumber(string value)
        {
            int valor = 0;
            return int.TryParse(value, out valor);
        }

        /// <summary>
        /// verifica se uma data é um numero valido
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValidDate(string value)
        {
            DateTime result;
            return DateTime.TryParse(value, out result);
        }

    }
}
