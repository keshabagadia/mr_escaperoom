using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageInfo : MonoBehaviour
{
    public bool canSlideRight = false;
    public bool canSlideLeft = false;
    public bool canSlideUp = false;
    public bool canSlideDown = false;
    public GameObject connectedTile;
    // Start is called before the first frame update

    private void Start()
    {
       if(connectedTile!=null) PuzzleManager.instance.newConnection(this.gameObject, connectedTile);
    }

    public TileInfo getConnectedTile()
    {
        if(connectedTile==null) return null;
        else return connectedTile.GetComponent<TileInfo>();
    }
}
