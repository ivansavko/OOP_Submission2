using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Content : MonoBehaviour
{
    [SerializeField]
    public GameObject content;

    private float _animationSpeed = 0.1f;
    [SerializeField]
    public float animationSpeed
    {
        get { return _animationSpeed; }
        set
        {
            if (value < 0.0f)
            {
                Debug.LogError("You can't set a negative animation speed!");
                _animationSpeed = 1.0f;
            }
            else
            {
                _animationSpeed = value;
            }
        }
    }

    public virtual void GetInfo()
    {
        Debug.Log("animationSpeed = " + animationSpeed);
    }

}
