using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tile
{
    Platform = 0,
    Hole = 1
};

[CreateAssetMenu(fileName = "Map", menuName = "ScriptableObjects/Map", order = 1)]
public class Map : ScriptableObject
{
    public int width;
    public int height;
    public Tile[] tiles;
}
