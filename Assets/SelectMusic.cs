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
        string video_path;  // �r�f�I
        string music_path;  // ���y
        string word_path;   // �̎�
        string time_path;   // �̎��̏o���^�C�~���O
    }

    public GameObject select_obj;
    private KaraokeData kd;

    void Start()
    {
        //���C���V�[���Ɏ����Ă����f�[�^
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //�@�N���b�N
    public void OnClick()
    {
        SceneManager.LoadScene("MainScen");
    }

}
