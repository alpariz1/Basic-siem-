using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class SIEMAlarmSystem
{
    static void Main(string[] args)
    {
        string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        string eventLogPath = Path.Combine(projectDirectory, "events.txt");  // Olay log dosyasının yolu
        string alarmLogPath = Path.Combine(projectDirectory, "alarmlogs.txt");  // Alarm geçmişi dosyasının yolu

        try
        {
            // Olay log dosyasını oku
            var eventLines = File.ReadAllLines(eventLogPath);

            List<string> alarms = new List<string>();

            // Çalıştırma zamanı için zaman damgası
            string runTimestamp = $"********** Çalıştırma Zamanı: {DateTime.Now} **********";
            alarms.Add(runTimestamp);

            foreach (var line in eventLines)
            {
                string alarm = GenerateAlarm(line);
                if (!string.IsNullOrEmpty(alarm))
                {
                    alarms.Add(alarm);
                    Console.WriteLine(alarm);
                }
            }

            // Alarm geçmişini dosyaya kaydet
            if (alarms.Count > 1)  // Eğer sadece zaman damgası eklenmişse, dosyaya yazma
            {
                File.AppendAllLines(alarmLogPath, alarms);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hata: {ex.Message}");
        }
    }

    static string GenerateAlarm(string logLine)
    {
        if (logLine.Contains("Failed Login"))
        {
            return $"[ALARM] {logLine}";
        }
        else if (logLine.Contains("X EVENT"))
        {
            return $"[X] {logLine}";
        }
        else if (logLine.Contains("Successful Login"))
        {
            return $"[INFO] {logLine}";
        }

        return null;
    }
}

