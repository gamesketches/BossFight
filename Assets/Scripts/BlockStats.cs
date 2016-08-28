using UnityEngine;
using System.Collections;

public class BlockStats : MonoBehaviour {


    public enum BlockType { Fire, Grass, Water };
    public BlockType type;
    public Sprite[] blockSprites;

    public int hp = 1; // num of hits to die

    private SpriteRenderer rend;

    // Use this for initialization
    void Start () {

        rend = GetComponent<SpriteRenderer>();
        switch (type)
        {
            case BlockType.Fire:
                rend.sprite = blockSprites[0];
                break;
            case BlockType.Grass:
                rend.sprite = blockSprites[1];
                break;
            case BlockType.Water:
                rend.sprite = blockSprites[2];
                break;
            default:
                Debug.Log("block type error");
                break;

        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
