using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCorrectTile : MonoBehaviour
{
    private TileInfo tileInfo;
    private bool canMakeNewConnection = true;

    private void Start()
    {
        tileInfo = GetComponent<TileInfo>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Image")&&canMakeNewConnection)
        {
            canMakeNewConnection = PuzzleManager.instance.updateConnection(other.gameObject, this.gameObject); ;
            Debug.Log("collision detected " + this.gameObject.name);
            if (other.name == name)
            {
                Debug.Log("win");
                PuzzleManager.instance.tile[tileInfo.row-1,tileInfo.col-1] = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Image")
        {
            Debug.Log("trigger exited " + this.gameObject.name);
            canMakeNewConnection=true;
            //PuzzleManager.instance.deleteConnection(this.gameObject);
            if (other.name == name)
            {
                PuzzleManager.instance.tile[tileInfo.row - 1,tileInfo.col - 1] = false;
            }
        }
    }
}