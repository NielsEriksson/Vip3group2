using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public class TileRule : MonoBehaviour
{
    public Tilemap tilemap;
    public List<RuleTile> ruleTiles = new List<RuleTile>();
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
                switch (SpriteChangeManager.Instance.spriteState)
                {
                    case SpriteState.Bright:
                        tilemap.SetTile(pos, ruleTiles[0]);
                        break;
                    case SpriteState.Dark:
                        tilemap.SetTile(pos, ruleTiles[1]);
                        break;
                    case SpriteState.Night:
                        tilemap.SetTile(pos, ruleTiles[2]);
                        break;
                    case SpriteState.Spooky:
                        tilemap.SetTile(pos, ruleTiles[3]);
                        break;
                    default:
                        break;
                }
            }
        }


        //tilemap.RefreshAllTiles();

    }
}
