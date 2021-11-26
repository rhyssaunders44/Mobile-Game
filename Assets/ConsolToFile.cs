using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsolToFile : MonoBehaviour
{
    private string fileName = "";
    private void OnEnable() => Application.logMessageReceived += Log;

    private void OnDisable() => Application.logMessageReceived -= Log;

    public void Log(string logString, string stackTrace, LogType type)
    {
        if (fileName == "")
        {
            string path = System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Desktop) + "/Unity_Logs";
            System.IO.Directory.CreateDirectory(path);
            string formattedDate = DateTime.Now.ToString().Replace("/", "").Replace(":", "");
            fileName = path + "/log-" + formattedDate + ".txt";

            System.IO.File.Create(fileName);
        }

        string formattedLogString = "[" + DateTime.Now + " | " + type + "]" + logString;
        
        try
        {
            System.IO.File.AppendAllText(fileName, formattedLogString + "\n");
        }
        catch
        {
            
        }

    }
}
