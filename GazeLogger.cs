using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GazeLogger : MonoBehaviour
{
    private List<string> gazeDataList = new List<string>();
    private string filePath;

    void Start()
    {
        string directoryPath = Application.persistentDataPath + "/GazeLogs";
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        string timeStamp = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
        filePath = Path.Combine(directoryPath, $"gaze_log_{timeStamp}.csv");

        gazeDataList.Add("ObjectName,응시시간(초),관심도여부,표시방법");  // CSV Header
    }

    public void LogPopupResponse(string objectName, string response)
    {
        string line = $"{objectName},2,관심{(response == "Y" ? "있음" : "없음")},popup";
        gazeDataList.Add(line);
        SaveToFile();
        FindObjectOfType<GazeTracker>()?.ResetPopupState();
    }

    public void LogManualSelection(string objectName)
    {
        string line = $"{objectName},1.2,관심있음,manual";
        gazeDataList.Add(line);
        SaveToFile();
    }

    void SaveToFile()
    {
        File.WriteAllLines(filePath, gazeDataList.ToArray());
    }
}
