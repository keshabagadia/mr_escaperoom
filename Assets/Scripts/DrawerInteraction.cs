using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerInteraction : MonoBehaviour
{
    public int drawerID; // Unique identifier for each drawer
    public DrawerPuzzleController puzzleController; // Reference to the central puzzle controller

    public Rigidbody drawerBody;
    private bool isPulledOut = false;

    private bool isDrawerStopped = false;

    public AudioSource drawerLocked;
    public AudioSource drawerOpened;

    //private bool isLocked = false; // flag for locking the drawer
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("DrawerEnd"))
        {
            isDrawerStopped = true;

        }
        else if (other.CompareTag("PullOutTrigger") && !isPulledOut)
        {
            isPulledOut = true;
            puzzleController.DrawerPulled(drawerID);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("DrawerEnd"))
        {
            isDrawerStopped = false;
        }
        if (other.CompareTag("PullOutTrigger"))
        {
            isPulledOut = false;

            puzzleController.DrawerPushedIn(drawerID); // Notify the controller

        }

    }

    void FixedUpdate()
    {
        if (isDrawerStopped)
        {
            StopDrawerMovement();
        }
        else if (!isPulledOut && !puzzleController.CanDrawerBePulled(drawerID))
        {
            StopDrawerMovement();
        }
    }
    private void StopDrawerMovement()
    {
        // Assuming x-axis for drawer movement
        if (drawerBody.velocity.x > 0)
        {
            drawerBody.velocity = Vector3.zero;
        }
    }


    public void OnDrawerPulled() // Call this when the drawer is pulled
    {
        puzzleController.DrawerPulled(drawerID);
    }

    public void PlayerDrawerSound()
    {
        if (!isPulledOut && !puzzleController.CanDrawerBePulled(drawerID))
        {
            drawerLocked.Play();
        }

/*        if (!isPulledOut && puzzleController.CanDrawerBePulled(drawerID))
        {
            drawerOpened.Play();
        }*/
    }

}
