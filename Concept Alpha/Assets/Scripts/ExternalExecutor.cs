using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class ExternalExecutor {
    public List<string> submoduleNames = new List<string>();

    public void ExecuteSubmodules()
    {
        foreach (string submoduleName in submoduleNames)
        {

        }
    }

    /*private string ExecuteSubmodule(string cmd, string args)
    {
        string argsExt = string.Empty;
        foreach (string file in mysteryFiles)
        {
            argsExt += file + " ";
        }

        args += " " + argsExt;

        Process process = new Process();
        process.StartInfo.FileName = cmd;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.Arguments = args;
        process.Start();

        StreamReader reader = process.StandardOutput;
        string output = reader.ReadToEnd();
        process.WaitForExit();

        return output;
    }*/
}
