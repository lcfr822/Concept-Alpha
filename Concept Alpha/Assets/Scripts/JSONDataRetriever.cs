using System;
using System.Text;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONDataRetriever {
    private string[] apiUris =
    {
        "https://api.discover.com/cityguides/v2/categories",
        "https://api.discover.com/cityguides/v2/cities",
        /*"https://api.discover.com/cityguides/v2/merchants?"*/
    };

    public List<string> InitAPIs()
    {
        List<string> values = new List<string>();
        ClientRequest(apiUris[0]);
        return values;
    }

    private string ClientRequest(string uri)
    {
        WebClient newClient = new WebClient();
        newClient.Headers.Clear();
        newClient.Headers.Add(HttpRequestHeader.Accept, "application/json");
        newClient.Headers.Add("x-dfs-api-plan", "CITYGUIDES_SANDBOX");
        newClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer f86129fc-b444-4b2c-ad74-6d60868a4cf7");
        string jsonResult = Encoding.UTF8.GetString(newClient.DownloadData(uri));
        Debug.Log(jsonResult);
        return jsonResult;
    }
}
