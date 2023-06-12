using Mono.Cecil;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "typeNames.json");
            AssemblyDefinition ass = AssemblyDefinition.ReadAssembly(args[0]);

            List<string> typeNamesToCheck;

            try
            {
                string jsonContent = File.ReadAllText(jsonFilePath);
                typeNamesToCheck = JsonSerializer.Deserialize<List<string>>(jsonContent) ?? new List<string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: Cannot read JSON file: {ex.Message}");
                typeNamesToCheck = new List<string>()
                {
                    "ZNet",
                    "ZRpc",
                    "ZRoutedRpc",
                    "ZPackage"
                };
            }

            bool found = ass.MainModule.GetTypeReferences().Any(typeReference => typeNamesToCheck.Contains(typeReference.Name));

            Console.WriteLine(found ? "true" : "false");
        }
        else
        {
            Console.WriteLine("error: Please provide a file path as an argument.");
        }
    }

}