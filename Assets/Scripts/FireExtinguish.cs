using System.Collections;
using UnityEngine;

public class FireExtinguish : MonoBehaviour
{
    public GameObject chest;
    public Light fireLight;
    public float delayInSeconds = 2.0f; // Delay before the object appears
    ParticleSystem fireParticles;
    float maxIntensity = 10f; // Maximum intensity of fire
    float extinguishRate = 0.5f; // Rate at which fire is extinguished
    public AudioSource firePutOutSFX;
    public AudioSource fireCrackling;
    private bool oneAudioLoopPlayed=false;

    void Start()
    {
        fireParticles = GetComponent<ParticleSystem>();
        if (chest != null)
            chest.SetActive(false);

    }

    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Water")) 
        {
            Debug.Log("Collided");
            ReduceFireIntensity();              
        }
    }

    void ReduceFireIntensity()
    {
        var emission = fireParticles.emission;
        maxIntensity -= extinguishRate;
        emission.rateOverTime = maxIntensity;

        // Update the light intensity
        if (fireLight != null)
        {
            fireLight.intensity = maxIntensity / 10f;
        }

        if (maxIntensity <= 0)
        {
            fireParticles.Stop();
            Invoke("ActivateObject", delayInSeconds); // Invoke ActivateObject after a delay
            if (!oneAudioLoopPlayed)
            {
                fireCrackling.Stop();
                firePutOutSFX.Play();
                oneAudioLoopPlayed = true;
            }
            if (fireLight != null)
                fireLight.enabled = false; // Turn off the light
        }
    }
    void ActivateObject()
    {
        if (chest != null)
        {
            chest.SetActive(true);
        }
    }
}

