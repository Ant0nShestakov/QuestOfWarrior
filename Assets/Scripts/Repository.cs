using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using Mono.Data;
using System.Data;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class Repository : MonoBehaviour
{
    [SerializeField] private string _dataBaseName;
    [SerializeField] private string _tableName;

    private int minID;
    private int maxID;

    private List<string> _repos;
  
    public static Repository instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    void Start()
    {
        _repos = new List<string>();
        GetData();
    }

    public string GetString(int index) => _repos[index];

    public List<string> GetAll() => _repos;

    public int CheckCount() => _repos.Count;

    private void GetData()
    {
        int rndIndex = Random.Range(1, 5);
        minID = rndIndex;
        maxID = rndIndex + 4;
        string conn = SetDataBaseClass.SetDataBase(_dataBaseName + ".db");
        IDbConnection dbcon;
        IDbCommand dbcmd;
        IDataReader reader;

        dbcon = new SqliteConnection(conn);

        dbcon.Open();

        dbcmd = dbcon.CreateCommand();
        string SQLQuery = "Select questions,answer,first_not_val_answer,second_not_val_answer,thrid_not_val_answer,Hint FROM " + _tableName + " WHERE id >= " + minID +" AND id <= " + maxID;
        dbcmd.CommandText = SQLQuery;
        reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            _repos.Add(reader.GetString(0) + "&" + reader.GetString(1) + "&" 
                + reader.GetString(2) + "&" + reader.GetString(3) + "&" 
                + reader.GetString(4) + "&" + reader.GetString(5));
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
    }
}
