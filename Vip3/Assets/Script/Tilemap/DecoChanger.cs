using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class DecoChanger : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile test;
    Vector3Int origin;
    bool once;
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
                Debug.Log(pos);
                switch (SpriteChangeManager.Instance.spriteState)
                {
                    case SpriteState.Bright:
                        /*tilemap.SetTile(pos, tilemap.GetTile(new Vector3Int(pos.x,pos.y-3)));*/
                        break;
                    case SpriteState.Dark:
                        tilemap.SetTile(pos, test);
                        break;
                    case SpriteState.Night:
                        tilemap.SetTile(pos, tilemap.GetTile(new Vector3Int(pos.x, pos.y - 3)));
                        break;
                    case SpriteState.Spooky:
                        tilemap.SetTile(pos, tilemap.GetTile(new Vector3Int(pos.x, pos.y - 3)));
                        break;
                    default:
                        break;
                }
            }
        }


        //tilemap.RefreshAllTiles();

    }
}
