using Mono.Cecil;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            string filePath = args[0];
            AssemblyDefinition ass = AssemblyDefinition.ReadAssembly(filePath);
            List<TypeReference> typeReferences = new List<TypeReference>();
            List<string> typeNamesToCheck = new List<string> { "ZNet", "ZRpc", "ZRoutedRpc", "ZPackage" };

            string found = "false";
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
            Console.WriteLine("Please provide a file path as an argument.");
        }

    }
}