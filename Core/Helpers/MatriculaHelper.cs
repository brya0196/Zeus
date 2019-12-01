using System;

namespace Core.Helpers
{
    public class MatriculaHelper
    {
        private static string separator = "-";
        
        public static string Generator(string matricula)
        {
            var sequenceFixed = 1;
            if (matricula != null)
            {
                var matriculaSplited = matricula.Split(separator);
                var sequence = int.Parse(matriculaSplited[1]);
                sequenceFixed = sequence++;
            }

            var year = DateTime.Now.Year;
            return year + separator + sequenceFixed;
        }
    }
}