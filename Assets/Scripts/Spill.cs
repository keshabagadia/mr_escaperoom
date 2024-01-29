using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spill : MonoBehaviour
{
    ParticleSystem waterPouring;
    public AudioSource waterFalling;
    private bool waterFallingSoundEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        waterPouring = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Angle(Vector3.down, transform.forward) <= 90f)
        {
            waterPouring.Play();
            if (!waterFallingSoundEnabled)
            {
                waterFallingSoundEnabled = true;
                waterFalling.Play();
            }

        }
        else
        {
            waterPouring.Stop();
            waterFalling.Stop();
            waterFallingSoundEnabled=false;
        }
    }

    //public void OnParticleCollision(GameObject other)
    //{
    //    Debug.Log("Collision Detected with: " + other.name);
    //    if (other.CompareTag("Fire"))
    //    {
    //        Debug.Log("Extinguishing Fire");
    //        other.GetComponent<ParticleSystem>().Stop();
    //    }
    //}
}
