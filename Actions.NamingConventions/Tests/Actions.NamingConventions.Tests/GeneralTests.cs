using System.Diagnostics;

namespace Actions.NamingConventions.Tests;

public class GeneralTests : IDisposable
{
    private string csprojPath;
    private Process process;
    private string tempOutputFile = Path.GetTempFileName();

    public GeneralTests()
    {
        var currentDir = AppContext.BaseDirectory;
        var projectDir = Path.GetFullPath(Path.Combine(currentDir, "../../../../../Src/NamingConvention"));
        csprojPath = Path.Combine(projectDir, "NamingConvention.csproj");
        
        if (!File.Exists(csprojPath))
            throw new FileNotFoundException($"Project file not found at: {csprojPath}");
        
        process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments =
                    $"run --project \"{csprojPath}\" ",
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                Environment = { ["GITHUB_OUTPUT"] = tempOutputFile }
            }
        };
    }

    [Fact]
    public void Program_WithValidArguments_ProducesExpectedOutput()
    {
        try
        {
            process.StartInfo.Arguments += "path: Tasks.User.Presentation environment: Development product: Automate";

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            Assert.Equal(0, process.ExitCode);
            Assert.True(string.IsNullOrEmpty(error), $"Unexpected error: {error}");

            // Read and assert the output file
            var fileOutput = File.ReadAllText(tempOutputFile);
            Assert.Contains("FolderName=Tasks", fileOutput);
            Assert.Contains("RgName=D-Automate-Rg-Weu", fileOutput);
            Assert.Contains("ApimName=D-Automate-Portal-Management-Apim-Weu", fileOutput);
            Assert.Contains("ApiId=Task-User", fileOutput);
            Assert.Contains("ApiPath=tasks/user", fileOutput);
            Assert.Contains("FunctionName=D-Automate-Task-User-Func-01-Weu", fileOutput);
            Assert.Contains("WebAppName=D-Automate-Task-User-webApp-Weu", fileOutput);
        }
        finally
        {
            if (File.Exists(tempOutputFile))
                File.Delete(tempOutputFile);
        }
    }

    [Fact]
    public void Program_WithValidAutomateArguments_ProducesExpectedOutput()
    {
        try
        {
            process.StartInfo.Arguments += $"path: Automate.Api.Schedueler environment: Development product: Automate";

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            Assert.Equal(0, process.ExitCode);
            Assert.True(string.IsNullOrEmpty(error), $"Unexpected error: {error}");

            // Read and assert the output file
            var fileOutput = File.ReadAllText(tempOutputFile);
            Assert.Contains("FolderName=Automate", fileOutput);
            Assert.Contains("RgName=D-Automate-Rg-Weu", fileOutput);
            Assert.Contains("ApimName=D-Automate-Portal-Management-Apim-Weu", fileOutput);
            Assert.Contains("ApiId=Api-Schedueler", fileOutput);
            Assert.Contains("ApiPath=api/schedueler", fileOutput);
            Assert.Contains("FunctionName=D-Automate-Api-Schedueler-Func-01-Weu", fileOutput);
            Assert.Contains("WebAppName=D-Automate-Api-Schedueler-webApp-Weu", fileOutput);
        }
        finally
        {
            if (File.Exists(tempOutputFile))
                File.Delete(tempOutputFile);
        }
    }

    [Fact]
    public void Program_WithMissingArguments_ThrowsArgumentException()
    {
        process.Start();
        string error = process.StandardError.ReadToEnd();
        process.WaitForExit();

        Assert.Contains("Please supply arguments", error);
        Assert.NotEqual(0, process.ExitCode);
    }

    public void Dispose()
    {
        if (File.Exists(tempOutputFile))
            File.Delete(tempOutputFile);
        process?.Dispose();
    }
}