using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMJ.Utils
{
    public static class FileHelper
    {
        public static string ToCsV<T>(this IEnumerable<T> source) where T : new()
        {
            var header = $"{string.Join(",", new T().GetType().GetProperties().Select(c => c.Name))}\n";
            if (source.Count() == 0) return header;
            var table = string.Join(",", source.Select(c => c == null ? string.Empty : string.Join(",", c.GetType().GetProperties().Select(p => p.GetValue(c, null)?.ToString()?.Replace(",", string.Empty) ?? " "))));
            return new StringBuilder().Append(header).Append(table).ToString();
        }
    }
}
