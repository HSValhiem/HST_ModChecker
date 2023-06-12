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
                typeNamesToCheck = JsonSerializer.Deserialize<List<string>>(jsonContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                typeNamesToCheck = new List<string>();
            }

            foreach (TypeReference typeReference in ass.MainModule.GetTypeReferences())
            {
                if (typeNamesToCheck.Contains(typeReference.Name))
                {
                    found = "true";
                    break;
                }
            }
            Console.Write(found);

        }
        else
        {
            Console.WriteLine("error: Please provide a file path as an argument.");
        }

    }
}