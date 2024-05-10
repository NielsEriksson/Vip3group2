using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public class TileRule : MonoBehaviour
{
    public Tilemap tilemap;
    public List<RuleTile> ruleTiles = new List<RuleTile>();
    public List<GameObject> decoTilemap = new List<GameObject>();
    public List<GameObject> backgrounds = new List<GameObject>();
    List<SpriteRenderer> platforms = new List<SpriteRenderer>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Platform"))
        {
            platforms.Add(item.GetComponent<SpriteRenderer>());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!UpgradeManager.Instance.platformTexture)
        {
            tilemap.color = Color.black;
            foreach (SpriteRenderer item in platforms)
            {
                item.color = Color.black;
            }
        }
        else
        {
            tilemap.color = Color.white;
            foreach (SpriteRenderer item in platforms)
            {
                item.color = Color.white;
            }
        }

        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.GetTile(pos) != null)
            {
                switch (SpriteChangeManager.Instance.spriteState)
                {
                    case SpriteState.Bright:
                        //if (tilemap.GetTile(pos) == ruleTiles[0]) if for some reason there is a need to paint tiles other than groundTiles on groundTile tilemap
                            tilemap.SetTile(pos, ruleTiles[0]);
                        SetDeco(0);
                        break;
                    case SpriteState.Dark:
                        tilemap.SetTile(pos, ruleTiles[1]);
                        SetDeco(1);
                        break;
                    case SpriteState.Night:
                        tilemap.SetTile(pos, ruleTiles[2]);
                        SetDeco(2);
                        break;
                    case SpriteState.Spooky:
                        tilemap.SetTile(pos, ruleTiles[3]);
                        SetDeco(3);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    void SetDeco(int numSet)
    {
        if (!UpgradeManager.Instance.backgroundTexture)
        {
            foreach (GameObject bg in backgrounds)
            {
                bg.SetActive(false);
            }
            return;
        }

        for (int i = 0; i < decoTilemap.Count; i++)
        {
            if (i == numSet)
            {
                decoTilemap[i].SetActive(true);
                backgrounds[i].SetActive(true);
                continue;
            }
            decoTilemap[i].SetActive(false);
            backgrounds[i].SetActive(false);

        }
    }
}
