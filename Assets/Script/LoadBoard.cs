using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class LoadBoard : MonoBehaviour
{
    public GameObject myPrefab;

    int BOARD_SIZE = 7;
    int BOARD_LENGTH = -4;
    int BOARD_WIDTH = -64;
    int TILES = 12;
    public Transform dad;

    int nb_T = 6;
    int nb_L = 15;
    int nb_I = 13;
    int nb_treasure = 22;

    // Start is called before the first frame update
    void Start()
    {
        GameObject test = GameObject.Find("pieces");

        treasure();
        GameObject[,] board = createBoard(test);
        //child.GetComponent<Renderer>().enabled = true;
        Debug.Log("game board loaded");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject[,] createBoard(GameObject parent)
    {

        GameObject[,] Board = new GameObject[BOARD_SIZE, BOARD_SIZE];
        for (int i = 0; i < BOARD_SIZE; i++)
        {
            for (int j = 0; j < BOARD_SIZE; j++)
            {
                if (j % 2 != 0)
                {
                    GameObject child = parent.transform.GetChild(choosePiece()).gameObject;
                    Board[i, j] = Instantiate(child, transform.position, transform.rotation);

                    Board[i, j].GetComponent<Renderer>().enabled = true;
                    Board[i, j].transform.SetParent(dad);
                    Board[i, j].transform.position = transform.position + new Vector3(BOARD_WIDTH + (TILES * i), BOARD_LENGTH + TILES * j, 0);
                    placeFirstTreasure(parent, i, j);

                }
                else if (i % 2 != 0)
                {
                    GameObject child = parent.transform.GetChild(choosePiece()).gameObject;
                    Board[i, j] = Instantiate(child, transform.position, transform.rotation);

                    Board[i, j].GetComponent<Renderer>().enabled = true;
                    Board[i, j].transform.SetParent(dad);
                    Board[i, j].transform.position = transform.position + new Vector3(BOARD_WIDTH + (TILES * i), BOARD_LENGTH + TILES * j, 0);
                    placeFirstTreasure(parent, i, j);
                }

            }
        }
        return Board;
    }
    public int choosePiece()
    {
        int T = 0;
        int I = 4;
        int L = 6;

        System.Random r = new System.Random();
        var types = new[] { T, I, L,  };
        int result = types[r.Next(types.Length)];

        Thread.Sleep(1);
        switch (result)
        {
            case 0:
                if (nb_T == 0) choosePiece(); else nb_T--;
                result = r.Next(T, I);
                break;
            case 4:
                if (nb_I == 0) choosePiece(); else nb_I--;
                result = r.Next(I, L);
                break;
            case 6:
                if (nb_L == 0) choosePiece(); else nb_L--;
                result = r.Next(L, L+4);
                break;
            default:
                break;
        }
        return result;
    }
    public void placeFirstTreasure(GameObject parent, int i, int j)
    {
        System.Random gen = new System.Random();
        int prob = gen.Next(100);
        if (prob <= 40 && nb_treasure != 0)
        {
            GameObject images = GameObject.Find("Grid/Treasure/"+(22-nb_treasure+1));
            images.GetComponent<Renderer>().enabled = true;
            images.transform.position = transform.position + new Vector3(BOARD_WIDTH + (TILES * i), BOARD_LENGTH + TILES * j, -1);
            nb_treasure--;
        }
        else
        {

            if (nb_treasure == 0)
            {
                Debug.Log("all treasure placed");
            }
            else
            {
            }
        }
            
    }
    public void treasure()
    {
        GameObject image = GameObject.Find("Grid/Treasure/");
        int i = 0;
        int j = 0;
        foreach (Transform child in image.transform)
        {
            if (j % 2 == 0)
            {
                if (i % 2 == 0)
                {
                    if (j==0 && i==0 || j== 6 && i==0)
                    {
                        i+=2;
                    }
                    child.GetComponent<Renderer>().enabled = true;
                    child.transform.position = transform.position + new Vector3(BOARD_WIDTH + ((TILES) * i), (BOARD_LENGTH) + (TILES-1) * j, -1);
                    nb_treasure--;
                    if (j != 0 && i != 0 || j != 6 && i != 0 || j!=0 && i==0)
                    {
                        i += 2;
                    }
                }
                if (i == 8 || j==0 && i== 6 || j==6 && i== 6)
                {
                    i = 0;
                    j += 2;
                }
            }
            if (nb_treasure == 10)
            {
                return;
            }
        }
    }
}
