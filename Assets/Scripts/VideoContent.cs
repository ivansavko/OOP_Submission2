using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoContent : Content
{
    VideoPlayer videoPlayer;

    public void PlayVideo(VideoClip videoClip)
    {
        videoPlayer = gameObject.GetComponent<VideoPlayer>();
        videoPlayer.clip = videoClip;
        videoPlayer.playbackSpeed = animationSpeed;
        videoPlayer.loopPointReached += OnLoopPointReached;
        videoPlayer.Play();
        
    }

    public void FinishVideo()
    {
        videoPlayer.Stop();
    }

    //This is an example of POLYMORPHISM in OOP for my Submission:
    public override void GetInfo()
    {
        Debug.Log("This is a video!");
    }

    private void OnLoopPointReached(UnityEngine.Video.VideoPlayer source)
    {
        videoPlayer.loopPointReached -= OnLoopPointReached;
        Debug.Log("Відтворення відео завершено.");
        ShowAdManager.Instance.PlayNextMedia();
    }
}
