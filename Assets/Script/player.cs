using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player
{
    public int nbCards;
    public int nbTreasure;
    public string color;

    public player(int cards, int treasure, string color)
    {
        this.nbCards = cards;
        this.nbTreasure = treasure;
        this.color = color;
    }

}
