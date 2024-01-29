using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class CorrectTime : MonoBehaviour
{
    [SerializeField]
    GameObject secondsHand;
    [SerializeField]
    GameObject minutesHand;
    [SerializeField]
    GameObject hoursHand;

    public Animator clockAnimator;
    public AudioSource doorCreakOpen;
    public bool audioPlayedOnce = false;

    public float correctHours;
    public float correctMinutes;
    public float correctSeconds;

    public float hoursDegree;
    public float minutesDegree;
    public float secondsDegree;

    public float hours;
    public float minutes;
    public float seconds;

    //public AudioSource

    // Start is called before the first frame update
    void Start()
    {
        // secondsHand.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, secondsDegree));
        //minutesHand.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, minutesDegree));
        // hoursHand.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, hoursDegree));
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("debug test");
        hoursDegree = hoursHand.transform.localRotation.eulerAngles.y;
        secondsDegree = secondsHand.transform.localRotation.eulerAngles.y;
        minutesDegree = minutesHand.transform.localRotation.eulerAngles.y;

        hours = degreeToHour(hoursDegree);
        minutes = degreeToMinAndSec(minutesDegree);
        seconds = degreeToMinAndSec(secondsDegree);

        if ((Mathf.RoundToInt(hours) == correctHours) && (Mathf.RoundToInt(minutes) == correctMinutes) && (Mathf.RoundToInt(seconds) == correctSeconds))
        {
            Debug.Log("correct time!");
            clockAnimator.SetBool("correctTime", true);
            if(!audioPlayedOnce)
            {
                audioPlayedOnce=true;
                doorCreakOpen.Play();
            }
        }

        if (hours == correctHours)
        {
            Debug.Log("correct hour!");
            //clockAnimator.SetBool("correctTime", true);
        }
    }

    float degreeToHour(float degree)
    {
        degree = degree % 360f;
        if (degree <= 180)
        {
            return 12f - ((degree / 30f) + 6f);
        }
        else
        {
            return 12f - ((degree / 30f) - 6f);
        }
    }

    float degreeToMinAndSec(float degree)
    {
        degree = degree % 360f;
        if (degree < 180)
        {
            return 60f - ((degree / 6f) + 30f);
        }
        else
        {
            return 60f - ((degree / 6f) - 30f);
        }
    }
}