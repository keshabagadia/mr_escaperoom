using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemPlaced : MonoBehaviour
{
    [SerializeField] GameObject image;
    private bool oneAudioLoopPlayed = false;
    public AudioSource puzzleSolved;
    public AudioSource thanks;
    [SerializeField] private GameObject finalPainting;
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("KeyItem"))
        {
            other.gameObject.SetActive(false);
            finalPainting.SetActive(true);
            image.SetActive(true);
            if (!oneAudioLoopPlayed)
            {
                oneAudioLoopPlayed = true;
                puzzleSolved.Play();
//              thanks.Play();
                gameManager.gameWon = true;
            }   
        }

    }

}
