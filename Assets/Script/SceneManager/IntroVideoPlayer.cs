using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroVideoPlayer : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    void Start(){
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    public void OnVideoFinished(VideoPlayer vp){
        SceneManager.LoadScene("GamePlay");
    }
}
