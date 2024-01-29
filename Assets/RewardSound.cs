using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSound : MonoBehaviour
{
    public AudioSource correctActionfeedback;
    public bool audioPlayedOnce = false;
    // Start is called before the first frame update
    public void EnableSound()
    {
        if (!audioPlayedOnce)
        {
            audioPlayedOnce = true;
            correctActionfeedback.Play();
        }


    }
}