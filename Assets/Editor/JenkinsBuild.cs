using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class JenkinsBuild
{
    public static void ReleaseNote()
    {
        string logs = GitTool.RunCommand("log --oneline --decorate");

        Console.WriteLine(logs);

        using (StreamWriter writer = new StreamWriter("~/Desktop/releaseNotes.txt"))
        {
            writer.Write(logs);
        }
    }
}

public static class GitTool
{
    /// <summary>
    /// Create a virtual command prompt to run git command
    /// </summary>
    /// <param name="gitCommand">The command without "git"</param>
    /// <returns>The result of the command</returns>
    public static string RunCommand(string gitCommand)
    {
        // Strings that will catch the output from our process.
        string output = "no-git";
        string errorOutput = "no-git";

        // Set up our processInfo to run the git command and log to output and errorOutput.
        ProcessStartInfo processInfo = new ProcessStartInfo("git", @gitCommand)
        {
            CreateNoWindow = true,          // We want no visible pop-ups
            UseShellExecute = false,        // Allows us to redirect input, output and error streams
            RedirectStandardOutput = true,  // Allows us to read the output stream
            RedirectStandardError = true    // Allows us to read the error stream
        };

        // Set up the Process
        Process process = new Process
        {
            StartInfo = processInfo
        };
        try
        {
            process.Start();  // Try to start it, catching any exceptions if it fails
        }
        catch (Exception e)
        {
            // For now just assume its failed cause it can't find git.
            UnityEngine.Debug.LogError("Git is not set-up correctly, required to be on PATH, and to be a git project.");
            throw e;
        }

        // Read the results back from the process so we can get the output and check for errors
        output = process.StandardOutput.ReadToEnd();
        errorOutput = process.StandardError.ReadToEnd();

        process.WaitForExit();  // Make sure we wait till the process has fully finished.
        process.Close();        // Close the process ensuring it frees it resources.

        // Check for failure due to no git setup in the project itself or other fatal errors from git.
        if (output.Contains("fatal") || output == "no-git" || output == "")
        {
            throw new Exception("Command: git " + @gitCommand + " Failed\n" + output + errorOutput);
        }
        // Log any errors.
        if (errorOutput != "")
        {
            UnityEngine.Debug.LogError("Git Error: " + errorOutput);
        }

        return output;
    }
}
