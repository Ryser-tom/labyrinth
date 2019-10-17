using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LoadBoard : MonoBehaviour
{
    int BOARDLENGTH = 7;
    int BOARDWIDTH = 7;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Load game board");
        TilemapRenderer rnd = gameObject.GetComponent<TilemapRenderer>();
        rnd.enabled = true;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Tilemap[,] createBoard()
    {
        Tilemap[,] Board = new Tilemap[BOARDLENGTH, BOARDWIDTH];
        for (int i = 0; i < BOARDWIDTH; i++)
        {
            for (int j = 0; i < BOARDLENGTH; i++)
            {
                Tilemap tileMovable(Tilemap T0);
                Board[j, i] = tileMovable;
            }
        }

        return Board;
    }
}
