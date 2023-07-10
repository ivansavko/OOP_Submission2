using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ShowAdManager : MonoBehaviour
{
    public Sprite[] images;
    public VideoClip[] videos;
    //This is an example of INHERITANCE in OOP for my Submission: ImageDisplay and VideoContent classes inherits Content class
    public VideoContent videoPlayer;
    public ImageDisplay imageDisplay;
    //This is an example of ENCAPSULATION in OOP for my Submission:
    public static ShowAdManager Instance { get; private set; }
    [Tooltip("Time to show image before the next one")]
    [SerializeField]
    float imageDisplayDuration;
    [SerializeField]
    float imageDisplayCountdown;//temp
    bool isImageDisplayed;
    bool isVideoShown;
    [SerializeField]
    private int currentImageIndex = 0;
    [SerializeField]
    private int currentVideoIndex = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        PlayNextMedia();
    }

    private void Start()
    {
        imageDisplayCountdown = imageDisplayDuration;
        //PlayNextMedia();
    }

    //This is an example of ABSTRACTION in OOP for my Submission:
    public void PlayNextMedia()
    {
        if ((images.Length > 0) && (currentImageIndex < images.Length))
        {
            isImageDisplayed = true;
            isVideoShown = false;
            imageDisplay.ShowAD(images[currentImageIndex]);
            currentImageIndex++;
            imageDisplay.GetInfo();
        }
        else
        {
            videoPlayer.GetInfo();
            isImageDisplayed = false;
            isVideoShown = true;
            PlayNextVideo();
        }
    }

    public void Update()
    {
        TimerToNextImage();
    }

    public void PlayNextVideo()
    {

        if ((videos.Length > 0) && (currentVideoIndex < videos.Length))
        {
            imageDisplay.gameObject.SetActive(false);
            videoPlayer.animationSpeed = 1.0f;
            videoPlayer.PlayVideo(videos[currentVideoIndex]);
            currentVideoIndex++;
        }
        else
        {
            videoPlayer.FinishVideo();
            imageDisplay.gameObject.SetActive(true);
            currentImageIndex = 0;
            currentVideoIndex = 0;
            PlayNextMedia();
        }
    }

    private void TimerToNextImage()
    {
        if ((isImageDisplayed) && (!isVideoShown))
        {
            imageDisplayCountdown -= Time.deltaTime;
            if (imageDisplayCountdown <= 0)
            {
                isImageDisplayed = false;
                imageDisplayCountdown = imageDisplayDuration;
                PlayNextMedia();
            }
        }
    }
}