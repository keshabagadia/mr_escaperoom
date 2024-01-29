using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Content.Interaction;

public class SmoothenClockInteraction : MonoBehaviour
{
    public Material newMaterial; // Set the new material
    private Material originalMaterial;
    public Renderer handRenderer; // Store the original material
    public XRKnob knobComponent1;
    public XRKnob knobComponent2;
    public XRKnob knobComponent3;

    public void Start()
    {
        originalMaterial = handRenderer.material;
    }
    public void ChangeToNewMaterial()
    {
        // Change to the new material
        if (handRenderer != null && newMaterial != null)
        {
            handRenderer.material = newMaterial;
        }
    }

    public void RevertToOriginalMaterial()
    {
        // Revert to the original material
        if (handRenderer != null && originalMaterial != null)
        {
            handRenderer.material = originalMaterial;
        }
    }

    public void DisableOtherXRKnobs()
    {
        if(knobComponent1 != null)
        {
            knobComponent1.enabled = true;
        }

        if(knobComponent2 != null) 
        { 
            knobComponent2.enabled = false;
        }

        if (knobComponent3 != null)
        {
            knobComponent3.enabled = false;
        }


    }
}
