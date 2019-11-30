using System;

namespace Core.Helpers
{
    public class MatriculaHelper
    {
        private static string separator = "-";
        
        public static string Generator(string matricula)
        {
            var matriculaSplited = matricula.Split(separator);
            var sequence = int.Parse(matriculaSplited[1]);
            var sequenceFixed = sequence++;
            
            var year = DateTime.Now.Year;
            return year + separator + sequenceFixed;
        }
    }
}