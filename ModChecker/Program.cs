using Mono.Cecil;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            List<string> typeNamesToCheck;
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "typeNames.json");
            AssemblyDefinition ass = AssemblyDefinition.ReadAssembly(args[0]);
            string found = "false";

            try
            {
                string jsonContent = File.ReadAllText(jsonFilePath);
#pragma warning disable CS8600
                typeNamesToCheck = JsonSerializer.Deserialize<List<string>>(jsonContent);
#pragma warning restore CS8600
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

            found = ass.MainModule.GetTypeReferences().Any(typeReference => typeNamesToCheck != null && typeNamesToCheck.Contains(typeReference.Name)) ? "true" : "false";

            Console.Write(found);

        }
        else
        {
            Console.WriteLine("error: Please provide a file path as an argument.");
        }

    }
}