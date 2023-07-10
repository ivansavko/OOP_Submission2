using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageDisplay : Content
{
    public Image image;

    public void ShowAD(Sprite sprite)
    {
        image.sprite = sprite;
    }

    //This is an example of POLYMORPHISM in OOP for my Submission:
    public override void GetInfo()
    {
        Debug.Log("This is a picture!");
    }
}
