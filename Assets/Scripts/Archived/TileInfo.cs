using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    public GameObject rightTile;
    public GameObject leftTile;
    public GameObject topTile;
    public GameObject bottomTile;

    public TileInfo rightTileInfo;
    public TileInfo leftTileInfo;
    public TileInfo topTileInfo;
    public TileInfo bottomTileInfo;

    public GameObject imageTile;

    public int row;
    public int col;
    // Update is called once per frame
    private void Start()
    {
        findRowAndColumn();
        findAdjacentTiles();
    }
    void findRowAndColumn()
    {
        int number = int.Parse(gameObject.name);
        row = number / 10;
        col = number % 10;
    }

    string nameFromNumber(int row, int col)
    {
        return row.ToString() + col.ToString();
    }

    void findAdjacentTiles()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");

        foreach (GameObject tile in tiles)
        {
            if(tile.name == nameFromNumber(row, col-1))
            {
                leftTile = tile;
                leftTileInfo = leftTile.GetComponent<TileInfo>();
            }

            if (tile.name == nameFromNumber(row+1, col))// the row under, but same column
            {
                bottomTile = tile;
                bottomTileInfo = bottomTile.GetComponent<TileInfo>();
            }

            if (tile.name == nameFromNumber(row - 1, col))// the column under, but same row
            {
                topTile = tile;
                topTileInfo = topTile.GetComponent<TileInfo>();
            }

            if(tile.name == nameFromNumber(row, col + 1))
            {
                rightTile = tile;
                rightTileInfo = rightTile.GetComponent<TileInfo>();
            }
        }
    }

}
