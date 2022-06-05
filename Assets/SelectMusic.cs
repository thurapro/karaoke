using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectMusic : MonoBehaviour
{

    // Start is called before the first frame update
    public struct KaraokeData
    {
        string video_path;  // ビデオ
        string music_path;  // 音楽
        string word_path;   // 歌詞
        string time_path;   // 歌詞の出現タイミング
    }

    public GameObject select_obj;
    private KaraokeData kd;

    void Start()
    {
        //メインシーンに持っていくデータ
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //　クリック
    public void OnClick()
    {
        SceneManager.LoadScene("MainScen");
    }

}
