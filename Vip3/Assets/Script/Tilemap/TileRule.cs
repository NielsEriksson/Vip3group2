using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum Seasson
{
    Spring,Summer,Fall,Winter
}

public class TileRule : MonoBehaviour
{
    public Tilemap tilemap;    
    public List<RuleTile> ruleTiles = new List<RuleTile>();
    public Seasson season;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
            foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
            {
                if (tilemap.GetTile(pos) != null)
                {
                    switch (season)
                    {
                        case Seasson.Spring:
                            tilemap.SetTile(pos, ruleTiles[0]);
                            break;
                        case Seasson.Summer:
                            tilemap.SetTile(pos, ruleTiles[1]);
                            break;
                        case Seasson.Fall:
                            break;
                        case Seasson.Winter:
                            break;
                        default:
                            break;
                    }
                }
            }


        //tilemap.RefreshAllTiles();

    }
}
