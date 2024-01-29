using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    [SerializeField] public TileScript[] tiles;
    [SerializeField] private Transform emptySpace = null;
    public int emptySpaceIndex = 7;
    [SerializeField] private GameObject finalPainting;
    [SerializeField] private GameObject frame;
    [SerializeField] private GameObject portal;
    public bool puzzleWinCalled = false;
    public AudioSource puzzleSolved;
    // Start is called before the first frame update
    void Start()
    {
        finalPainting.SetActive(false);
        //Shuffle();
        EasyShuffle();
    }

    // Update is called once per frame
    void Update()
    {
       checkWin();
    }

    public void checkWin()
    {
        int correctTiles = 0;
        foreach (var tile in tiles)
        {
            if (tile != null)
            {
                if (tile.inCorrectPlace)
                {
                    correctTiles++;
                }
            }
        }
        if (correctTiles == tiles.Length - 1)
        {
            Debug.Log("puzzle solced");
            if (!puzzleWinCalled)
            {
                puzzleWinCalled = true;
                StartCoroutine(puzzleWin());
            }
            for (int i = 0; i < tiles.Length; i++)
            {
                if (tiles[i] != null)
                {
                    tiles[i].gameObject.SetActive(false);
                }
            }
        }
    }

    public void EasyShuffle()
    {
        //if (emptySpaceIndex != 8)
        //{
        //    var tileOn8LastPos = tiles[8].targetPosition;
        //    tiles[8].targetPosition = emptySpace.localPosition;
        //    emptySpace.localPosition = tileOn8LastPos;
        //    tiles[emptySpaceIndex] = tiles[8];
        //    tiles[8] = null;
        //    emptySpaceIndex = 8;
        //}

        SwapTiles(3, 6);
        SwapTiles(6, 4);
    }

    public void SwapTiles(int i, int j)
    {
        var lastPos = tiles[i].targetPosition;
        tiles[i].targetPosition = tiles[j].targetPosition;
        tiles[j].targetPosition = lastPos;

        var tile = tiles[i];
        tiles[i] = tiles[j];
        tiles[j] = tile;
    }

    public void Shuffle()
    {
        if (emptySpaceIndex != 8)
        {
            var tileOn8LastPos = tiles[8].targetPosition;
            tiles[8].targetPosition = emptySpace.localPosition;
            emptySpace.localPosition = tileOn8LastPos;
            tiles[emptySpaceIndex] = tiles[8];
            tiles[8] = null;
            emptySpaceIndex = 8;
        }
        int inversion;
        do
        {
            Debug.Log("Puzzle shuffled");
            for (int i = 0; i < tiles.Length - 1; i++)
            {
                if (tiles[i] != null)
                {
                    var lastPos = tiles[i].targetPosition;
                    int randomIndex = Random.Range(0, tiles.Length - 2);
                    tiles[i].targetPosition = tiles[randomIndex].targetPosition;
                    tiles[randomIndex].targetPosition = lastPos;

                    var tile = tiles[i];
                    tiles[i] = tiles[randomIndex];
                    tiles[randomIndex] = tile;
                }
            }
            inversion = GetInversions();
        } while (inversion%2 != 0);

    }

    public int findIndex (TileScript ts)
    {
        for(int i = 0;i < tiles.Length;i++)
        {
            if (tiles[i] != null)
            {
                if (tiles[i] == ts)
                {
                    return i;
                }
            }
        }
        return -1;
    }

    int GetInversions()
    {
        int inversionsSum = 0;
        for (int i = 0; i < tiles.Length; i++)
        {
            int thisTileInvertion = 0;
            for (int j = i; j < tiles.Length; j++)
            {
                if (tiles[j] != null)
                {
                    if (tiles[i].number > tiles[j].number)
                    {
                        thisTileInvertion++;
                    }
                }
            }
            inversionsSum += thisTileInvertion;
        }
        return inversionsSum;
    }

    IEnumerator puzzleWin()
    {
        finalPainting.SetActive(true);
        puzzleSolved.Play();
        yield return new WaitForSeconds(2f);
        finalPainting.SetActive(false);
        frame.SetActive(false);
        portal.SetActive(true);
    }
}
