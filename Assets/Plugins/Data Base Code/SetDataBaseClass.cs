using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SetDataBaseClass
{
        public static string SetDataBase(string DataBaseName)
        {
            string conn = "";
#if UNITY_EDITOR
            conn = "URI=file:" + Application.dataPath + "\\StreamingAssets" + "/"+ DataBaseName; //Path to database
            Debug.Log("Windows Mode");
#elif UNITY_STANDALONE
            conn = "URI=file:" + Path.Combine(Application.dataPath, "StreamingAssets", DataBaseName);
            //if (!File.Exists(conn)) UnpackDatabase(conn, DataBaseName);

#elif UNITY_ANDROID
            conn = "URI=file:" + Application.persistentDataPath + "/" + DataBaseName; //Path to database.
            Debug.Log("Android Mode");
#endif
        return conn;
        }


    /// <summary> –аспаковывает базу данных в указанный путь. </summary>
    /// <param name="toPath"> ѕуть в который нужно распаковать базу данных. </param>
    private static void UnpackDatabase(string toPath, string fileName)
    {
        string fromPath = Path.Combine(Application.streamingAssetsPath, fileName);

        WWW reader = new WWW(fromPath);
        while (!reader.isDone) { }

        File.WriteAllBytes(toPath, reader.bytes);
    }
}
