using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeLogger : MonoBehaviour
{
    private void Awake()
    {
        SwipeDetect.OnSwipe += SwipeDetect_OnSwipe;
    }

    private void SwipeDetect_OnSwipe(SwipeData data)
    {
        Debug.Log("Swipe in Direction: " + data.Direction);
    }
}
