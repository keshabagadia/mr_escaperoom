using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class Clock : MonoBehaviour
{
    [SerializeField]
    GameObject secondsHand;
    [SerializeField]
    GameObject minutesHand;
    [SerializeField]
    GameObject hoursHand;

    DateTime now;

    [SerializeField]
    float secondsSpeed = 0.25f;

    public bool smoothMovement = false;
    // Start is called before the first frame update
    void Start()
    {
        now = DateTime.Now;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse button clicked!");
            now.AddMinutes(1);
        }
        int seconds = now.Second;
        float secDegree = -(seconds / 60f) * 360;

        int minutes = now.Minute;
        float minDegree = -(minutes / 60f) * 360;

        int hours = now.Hour;
        float hourDegree = -(hours / 12f) * 360;

        if (smoothMovement)
        {
            secDegree = Mathf.LerpAngle(secondsHand.transform.localRotation.eulerAngles.z, secDegree, Time.deltaTime * secondsSpeed);
            minDegree = Mathf.LerpAngle(minutesHand.transform.localRotation.eulerAngles.z, minDegree, Time.deltaTime);
            hourDegree = Mathf.LerpAngle(hoursHand.transform.localRotation.eulerAngles.z, hourDegree, Time.deltaTime);
        }

        secondsHand.transform.localRotation = Quaternion.Euler(new Vector3(0,0,secDegree));
        minutesHand.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, minDegree));
        hoursHand.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, hourDegree));
    }
}
