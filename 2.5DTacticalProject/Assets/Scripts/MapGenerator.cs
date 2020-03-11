using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] GameObject tilePlatformPrefab;
    [SerializeField] Map[] maps;
    [SerializeField] int currentMapIndex;

    private float positionScaleFactor = 1f;
    // Start is called before the first frame update
    void Start()
    {
        currentMapIndex = 0;
        createMap(maps[currentMapIndex]);
    }

    public void createMap(Map map)
    {
        Tile[] tiles = map.tiles;
        for(int z = 0; z < map.height; z++)
        {
            for(int x = 0; x < map.width; x++)
            {
                if(tiles[x * z] == Tile.Platform)
                {
                    GameObject platform = Instantiate(tilePlatformPrefab, transform);
                    platform.transform.position = (new Vector3(x, 0, z) * positionScaleFactor);
                }
            }
        }
    }

    public void loadNextMap()
    {
        currentMapIndex = currentMapIndex + 1 % maps.Length;
        createMap(maps[currentMapIndex]);
    }
}
