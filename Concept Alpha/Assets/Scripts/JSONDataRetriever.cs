using System;
using System.Text;
using System.Net;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class JSONDataRetriever {
    List<ATMLocation> atmLocations = new List<ATMLocation>();

    public void ReadData()
    {
        ParseAtmData();
    }

    private void ParseAtmData()
    {
        var file = File.ReadAllText("Assets/Resources/JSON/ATMLocatoinsParsedLondon.txt");
        string[] atmData = file.Split('\n');
        foreach(string datum in atmData)
        {
            string filer = datum.Trim(new char[] { '[', ']', });
            string[] parts = filer.Split(',');
            ATMLocation newAtm = new ATMLocation(parts[2], float.Parse(parts[1]), float.Parse(parts[0]));
            atmLocations.Add(newAtm);
        }
    }

    private void ParseStoreData()
    {
        var file = File.ReadAllText("Asset/Resources/JSON/meow.txt");
        //string[] storeData = file.Split('');
    }
    
    private void ParseTipData()
    {

    }
}

public struct ATMLocation {
    string name;
    float lat, lon;

    public ATMLocation(string newName, float newLat, float newLon)
    {
        name = newName;
        lat = newLat;
        lon = newLon;
    }
}

