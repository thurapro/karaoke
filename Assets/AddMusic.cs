using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class AddMusic : MonoBehaviour
{
    string path;
    public GameObject prefab;
    public Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("ErrorPanel").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {

        string path = EditorUtility.OpenFilePanel("Load Scripts", Application.dataPath + "/KaraokeList", "csv");
        if (string.IsNullOrEmpty(path) || path.Contains("list") != true) {
             return;
         }
         else {
             ReadFiles(path);
         }
  
    }

    // カラオケ一覧にデータを追加
    void ReadFiles(string path)
    {
        // csvファイルを読み込む
        StreamReader sr = new StreamReader(path);

        //音楽名(カラオケ)
        const string music_name = "music_name";

        // 音楽名列番号
        int music_col = 0;

        // 1行読み込む(タイトル行)
        string line = sr.ReadLine();

        // カンマ区切り
        string[] data = line.Split(',');

        // 列数分ループ
        for (int i = 0; i < data.Length; i++)
        {
            // 音楽名の列番号を取得
            if (data[i] == music_name)
            {
                music_col = i;
                break;
            }
        }

        // 最後の行まで読み込む
        while (!sr.EndOfStream)
        {
            // 1行づつ読み込む
            line = sr.ReadLine();

            // カンマ区切り
            data = line.Split(',');

            // music_nameの列の値だけ取得をカラオケ曲追加
            // musicNameの複製
            GameObject obj = Instantiate(prefab);

            // 曲名をオブジェクトネームに変更
            obj.name = data[music_col];
            
            // テキスト
            obj.GetComponent<Text>().text = data[music_col];
        }
    }

}
