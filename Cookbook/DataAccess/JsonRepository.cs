using System.Text.Json;

namespace Cookbook.DataAccess
{
    public class JsonRepository : IStringsRepository
    {
        public List<string> Read(string filePath)
        {
            var fileRows = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<string>>(fileRows);
        }

        public void Write(string filePath, List<string> strings)
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(strings));
        }
    }
}
