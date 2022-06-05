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

    // �J���I�P�ꗗ�Ƀf�[�^��ǉ�
    void ReadFiles(string path)
    {
        // csv�t�@�C����ǂݍ���
        StreamReader sr = new StreamReader(path);

        //���y��(�J���I�P)
        const string music_name = "music_name";

        // ���y����ԍ�
        int music_col = 0;

        // 1�s�ǂݍ���(�^�C�g���s)
        string line = sr.ReadLine();

        // �J���}��؂�
        string[] data = line.Split(',');

        // �񐔕����[�v
        for (int i = 0; i < data.Length; i++)
        {
            // ���y���̗�ԍ����擾
            if (data[i] == music_name)
            {
                music_col = i;
                break;
            }
        }

        // �Ō�̍s�܂œǂݍ���
        while (!sr.EndOfStream)
        {
            // 1�s�Âǂݍ���
            line = sr.ReadLine();

            // �J���}��؂�
            data = line.Split(',');

            // music_name�̗�̒l�����擾���J���I�P�Ȓǉ�
            // musicName�̕���
            GameObject obj = Instantiate(prefab);

            // �Ȗ����I�u�W�F�N�g�l�[���ɕύX
            obj.name = data[music_col];
            
            // �e�L�X�g
            obj.GetComponent<Text>().text = data[music_col];
        }
    }

}
