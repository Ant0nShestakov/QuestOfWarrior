using System;
using System.IO;
using UnityEngine;

public class FileDataHandler
{
    private string _dataPath = string.Empty;
    private string _dataFileName = string.Empty;

    public FileDataHandler(string _dataPath, string _datafileName)
    {
        this._dataFileName = _datafileName;
        this._dataPath = _dataPath;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(_dataPath, _dataFileName);
        GameData loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                string dataload = "";
                using (FileStream fs = new(fullPath, FileMode.Open))
                {
                    using (StreamReader sr = new(fs))
                    {
                        dataload = sr.ReadToEnd();
                    }
                }

                loadedData = JsonUtility.FromJson<GameData>(dataload);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
        return loadedData;
    }

    public void Save(GameData data)
    {
        string fullPath = Path.Combine(_dataPath, _dataFileName);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataStore = JsonUtility.ToJson(data, true);
            Debug.Log(dataStore);

            using (FileStream fs = new(fullPath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(dataStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

    }
}
