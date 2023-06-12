import subprocess

def run_csharp_app(file_path, argument):
    process = subprocess.Popen(["dotnet", file_path, argument], stdout=subprocess.PIPE)
    output, _ = process.communicate()
    return output.decode().strip()

def main():
    csharp_app_path = "D:\\Valheim_Dev\\ModChecker\\ModChecker\\bin\\Debug\\net6.0\\ModChecker.exe"
    argument_value = "D:\\Valheim_Dev\\Valheim\\BepInEx\\plugins\\ServerCharacters.dll"

   # output_value = run_csharp_app(csharp_app_path, argument_value)
    process = subprocess.Popen([csharp_app_path, argument_value, "."], stdout=subprocess.PIPE)
    (output_value, err) = process.communicate()
    print("Output value: ", output_value)

if __name__ == "__main__":
    main()
