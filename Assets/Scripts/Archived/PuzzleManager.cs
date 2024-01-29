using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        
        if (instance == null) instance = this;
        else Destroy(this);
    }

    //flags to check all images are in place
    public bool[,] tile = new bool[3, 3];

    //final win flag
    public bool puzzleSolved;

    // Start is called before the first frame update
    
    void Start()
    {
        initialiseFlags();
        tile[2,2] = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkWinOrNot())
        {
            Debug.Log("Puzzle solved!!");
        }
    }

    private void initialiseFlags()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                tile[i,j] = false;
            }
        }

    }

    private bool checkWinOrNot()
    {
        puzzleSolved = true;

        for (int i = 0; i < tile.GetLength(0); i++)
        {
            for (int j = 0; j < tile.GetLength(1); j++)
            {
                if (!tile[i,j])
                {
                    puzzleSolved = false;
                    break;
                }
            }

            if (!puzzleSolved)
            {
                break;
            }
        }
        return puzzleSolved;

    }

    //related to puzzle solving gameplay

    public bool updateConnection(GameObject imageTile, GameObject staticTile)
    {
        if (deleteConnection(imageTile.GetComponent<ImageInfo>().getConnectedTile()))
        {
            return newConnection(imageTile, staticTile);
        }
        else
        {
            return false;
        }
    }
    public bool newConnection(GameObject imageTile, GameObject staticTile)
    {
        Debug.Log("in new connection " + imageTile.name + " " + staticTile.name);
        ImageInfo imageInfo = imageTile.GetComponent<ImageInfo>();
        TileInfo tileInfo = staticTile.GetComponent<TileInfo>();

        if (imageInfo == null) Debug.Log("image hasn't been passed");
        if (tileInfo == null) Debug.Log("tile hasn't been passed");

        imageInfo.connectedTile = staticTile;
        tileInfo.imageTile = imageTile;
        imageTile.transform.position = staticTile.transform.position + new Vector3(0, 0f, -0.01f);
        updateSlidingAbility(imageTile, staticTile);
        updateAdjacentTileAvailability(staticTile);
        return true;
        
    }

    public bool deleteConnection(TileInfo staticTileInfo)
    {
        Debug.Log("delete" + staticTileInfo.gameObject.name);
        staticTileInfo.imageTile = null;
        updateAdjacentTileAvailability(staticTileInfo.gameObject);
        return true;
    }

    public bool updateAdjacentTileAvailability(GameObject staticTile)
    {
        TileInfo tileInfo = staticTile.GetComponent<TileInfo>();

        if (tileInfo.rightTile != null)
        {
            if (tileInfo.rightTile.GetComponent<TileInfo>().imageTile != null)
            {
                updateSlidingAbility(tileInfo.rightTile.GetComponent<TileInfo>().imageTile, tileInfo.rightTile);
            }
        }
        if (tileInfo.leftTile != null)
        {
            if (tileInfo.leftTile.GetComponent<TileInfo>().imageTile != null)
            {
                updateSlidingAbility(tileInfo.leftTile.GetComponent<TileInfo>().imageTile, tileInfo.leftTile);
            }
        }
        if (tileInfo.topTile != null)
        {
            if (tileInfo.topTile.GetComponent<TileInfo>().imageTile != null)
            {
                updateSlidingAbility(tileInfo.topTile.GetComponent<TileInfo>().imageTile, tileInfo.topTile);
            }
        }
        if (tileInfo.bottomTile != null)
        {
            if (tileInfo.bottomTile.GetComponent<TileInfo>().imageTile != null)
            {
                updateSlidingAbility(tileInfo.bottomTile.GetComponent<TileInfo>().imageTile, tileInfo.bottomTile);
            }
        }
        return true;
    }
    private bool checkAdjacentTileAvailability(TileInfo adjacentTile)
    {
        if (adjacentTile != null)
        {
            Debug.Log("checking " + adjacentTile.gameObject.name);
            if (adjacentTile.imageTile == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool updateSlidingAbility(GameObject imageTile, GameObject staticTile)
    {
        ImageInfo imageInfo = imageTile.GetComponent<ImageInfo>();
        TileInfo tileInfo = staticTile.GetComponent<TileInfo>();

        imageInfo.canSlideRight = checkAdjacentTileAvailability(tileInfo.rightTileInfo);
        imageInfo.canSlideLeft = checkAdjacentTileAvailability(tileInfo.leftTileInfo);
        imageInfo.canSlideUp = checkAdjacentTileAvailability(tileInfo.topTileInfo);
        imageInfo.canSlideDown= checkAdjacentTileAvailability(tileInfo.bottomTileInfo);

        return true;
    }
}
