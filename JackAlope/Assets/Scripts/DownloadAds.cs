using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DownloadAds : MonoBehaviour {

    // Use this for initialization
    void Start() {
        string dbPath = "";
        string realPath = "";
        if (Application.platform == RuntimePlatform.Android)
        {
            // Android
            string oriPath = System.IO.Path.Combine(Application.streamingAssetsPath, "db.bytes");

            // Android only use WWW to read file
            WWW reader = new WWW(oriPath);
            while (!reader.isDone) { }

            realPath = Application.persistentDataPath + "/db";
            System.IO.File.WriteAllBytes(realPath, reader.bytes);

            dbPath = realPath;
        }
        else
        {
            // iOS
            dbPath = System.IO.Path.Combine(Application.streamingAssetsPath, "db.bytes");
        }

        StartCoroutine(Download(dbPath));
    }

    IEnumerator Download(string dbPath)
    {
        using (WWW www = new WWW("http://Sameer.com/SampleVideo_360x240_2mb.mp4"))
        {
            yield return www;
            File.WriteAllBytes(dbPath, www.bytes);
        }
    }
            // Update is called once per frame
            void Update () {
		
	}
}
