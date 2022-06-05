using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(RawImage), typeof(VideoPlayer), typeof(AudioSource))]

public class videoScript : MonoBehaviour
{
    private RawImage image;
    private VideoPlayer player;
    private AudioSource source;
    public  bool preview_mode;
    public static string player_url;
    public static string source_url;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<RawImage>();
        player = GetComponent<VideoPlayer>();
        player.EnableAudioTrack(0, true);
        source = GetComponent<AudioSource>();
        player.SetTargetAudioSource(0, source);
        Init();
    }

    void Init()
    {
        player.time = 6.5f;
        source.time = 0.0f;
        source.volume = 1.0f;
        player.Play();
        source.Play();
    }


    // Update is called once per frame
    void Update()
    {
        
        image.texture = player.texture;

        if (preview_mode)
        {
            Preview();
        }
        else
        { 
            Play();
        }
    }

    // プレビューモード
    private void Preview()
    {
        image.texture = player.texture;
        if (source.time >= 15.0f)
        {
            if (source.volume <= 0.0f)
            {
                SceneManager.LoadScene("SelectScene");
               /* player.Stop();
                source.Stop();
                Init();*/
            }
            else
            {
                source.volume -= 0.01f;
            }
        }
    }

    // プレビューモード
    private void Play()
    {
        image.texture = player.texture;
        if (!source.isPlaying)
        {
            SceneManager.LoadScene("SelectScene");
        }
    }
}