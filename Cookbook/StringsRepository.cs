using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook
{
    public class StringsRepository : IStringsRepository
    {
        private static readonly string Seperator = Environment.NewLine;

        public List<string> Read(string filePath)
        {
            var fileRows = File.ReadAllText(filePath);
            return fileRows.Split(Seperator).ToList();
        }

        public void Write(string filePath, List<string> strings)
        {
            File.WriteAllText(filePath, string.Join(Seperator, strings));
        }
    }
}
