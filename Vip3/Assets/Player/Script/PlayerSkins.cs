using System.Collections.Generic;
using UnityEngine;

public class PlayerSkins : MonoBehaviour
{
    GameObject player;
    [SerializeField] List<Color> colors;
    public static PlayerSkins instance;
    void Start()
    {       
        if (instance == null) instance = this;
        else Destroy(this);
        player = GameObject.FindWithTag("Player");
        if(colors.Count == 0) colors.Add(Color.white);

    }

    public void ChangeColor(Color color){
        player.GetComponent<SpriteRenderer>().color = color;
    }
    public void ChangeToRandomColor(){
        int index = Random.Range(0, colors.Count);
        player.GetComponent<SpriteRenderer>().color = colors[index];
    }
}
