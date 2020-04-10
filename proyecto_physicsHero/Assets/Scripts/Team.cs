using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Team 
{
    private string teamName;
    private Color color;
    List<KeyValuePair<Team, Diplomacy>> relationships;

    Team(string name,Color color)
    {
        this.color = color;
        this.teamName = name;
    }
}

public enum Diplomacy
{
    Enemy,
    Ally,
    Neutral
}