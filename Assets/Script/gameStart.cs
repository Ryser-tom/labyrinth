using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class gameStart : MonoBehaviour
{
    player[] players = new player[]
    {
        new player(5,0,"green"),
        new player(5,0,"red"),
        new player(5,0,"blue"),
        new player(5,0,"orange")
    };

    public Text m_MyText;
    public Image myImage;
    GameObject image;
    public GameObject objective;
    // Start is called before the first frame update
    void Start()
    {
        m_MyText.text = players[0].color +
            " player turn" +
            "\n" +
            "number of cards left : " +
            players[0].nbCards +
            "\n" +
            "your objective : ";
        image = GameObject.Find("Grid/Treasure");
        chooseObjective();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void chooseObjective()
    {
        System.Random r = new System.Random();
        int rInt = r.Next(0, 22);

        myImage.sprite = Resources.Load("Images/"+rInt) as Sprite;

    }
}
