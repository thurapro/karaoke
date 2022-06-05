using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class BaseScreen : MonoBehaviour
{
    private GameObject obj;
    private RawImage Preview;
    public VideoPlayer videoPlayer;
    public VideoClip videoClip;
    private new GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("preview");
        Preview = obj.GetComponent<RawImage>();

        RenderTexture renderTexture;
        renderTexture = new RenderTexture(960, 540, 0);

        camera = GameObject.Find("Main Camera");

        Preview.material.mainTexture = renderTexture;

        if (videoPlayer == null) videoPlayer = camera.AddComponent<VideoPlayer>();

        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = renderTexture;
        videoPlayer.source = VideoSource.VideoClip;
        videoPlayer.clip = videoClip;
        videoPlayer.errorReceived += ErrorReceived;
        videoPlayer.prepareCompleted += PrepareCompleted;
        videoPlayer.Prepare();
        videoPlayer.isLooping = false;
        videoPlayer.aspectRatio = VideoAspectRatio.Stretch;
        videoPlayer.targetCameraAlpha = 1;
        videoPlayer.loopPointReached += EndReached;
    }

    // �G���[�������ɌĂ΂��
    private void ErrorReceived(VideoPlayer vp, string message)
    {
        Debug.Log("�G���[����");
        vp.errorReceived -= ErrorReceived;
        vp.prepareCompleted -= PrepareCompleted;
        Destroy(videoPlayer);
        vp = null;
    }

    //�@����̓ǂݍ��݂�����������Ă΂��
    void PrepareCompleted(VideoPlayer vp)
    {
        vp.prepareCompleted -= PrepareCompleted;
        Debug.Log("���[�h����");
        vp.Play();
    }

    // ����Đ��������ɌĂ΂��
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("�Đ�����");
        vp.errorReceived -= ErrorReceived;
        Destroy(videoPlayer);
        videoPlayer = null;
        // ����Đ��������̏���
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
