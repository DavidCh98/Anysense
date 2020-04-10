using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public enum DataType { start, end };

public class HappinessMeter : MonoBehaviour
{
    private float startTime = 0;
    private float duration = 0;
    private int start = 0;
    private int end = 0;

    private void Start()
    {
        startTime = Time.time;
    }

    public void ReportStartData(int score)
    {
        start = score;
    }

    public void ReportEndData(int score)
    {
        end = score;
    }

    public void StartCounting()
    {
        startTime = Time.time;
    }

    public void StopCounting()
    {
        duration += Time.time - startTime;
        startTime = 0;
    }

    public void CloseApplication()
    {
        TimeSpan span = TimeSpan.FromSeconds(duration);
        string output = "Begin mood:\r\n" + start + "/5\r\n" + "Final mood:\r\n" + end + "/5\r\n" + "Time spent in room:\r\n" + span.ToString(@"hh\:mm\:ss") + "\r\nTime and date of saving:\r\n" + DateTime.Now.ToString("HH:mm dd/MM/yyyy");
        string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Anger-Management";
        Directory.CreateDirectory(folder);
        File.WriteAllText(folder + "\\" + DateTime.Now.ToString("HH/mm/dd/MM/yyyy") + "-Data.txt", output);
        Application.Quit();
    }
}
