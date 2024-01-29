using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectItemPicked : MonoBehaviour
{
    public AudioSource correctActionfeedback;
    public bool audioPlayedOnce = false;
    // Start is called before the first frame update
    public void RewardSound()
    {
            if (!audioPlayedOnce)
            {
                audioPlayedOnce=true;
                correctActionfeedback.Play();
            }


     }
}
