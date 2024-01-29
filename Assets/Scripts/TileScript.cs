using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TileScript : MonoBehaviour
{
    [SerializeField] private Transform emptySpace = null;
    public Vector3 targetPosition;
    private Vector3 correctPosition;
    [SerializeField] GameScript gameScript;
    public int number;
    public bool inCorrectPlace;
    public AudioSource tileSlideSFX;

    private void Awake()
    {
        targetPosition = transform.localPosition;
        correctPosition = transform.localPosition;
    }

    private void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, 0.07f);
        if(targetPosition == correctPosition)
        {
            inCorrectPlace = true;
        }
        else
        {
            inCorrectPlace = false;
        }
    }
    public void TileGrabbed()
    {
        //Debug.Log(this.name + " is " + Vector3.Distance(emptySpace.localPosition, transform.localPosition) + " away from empty space.");

        // Check if the distances meet the criteria
        if (Vector3.Distance(emptySpace.localPosition, transform.localPosition) <= 0.13f)
        {
            Vector3 lastEmptySpacePosition = emptySpace.localPosition;
            emptySpace.localPosition = targetPosition;
            targetPosition = lastEmptySpacePosition;
            int tileIndex = gameScript.findIndex(this.GetComponent<TileScript>());
            gameScript.tiles[gameScript.emptySpaceIndex] = gameScript.tiles[tileIndex];
            gameScript.emptySpaceIndex = tileIndex;
            gameScript.tiles[tileIndex] = null;
            tileSlideSFX.Play();
        }
    }
}
