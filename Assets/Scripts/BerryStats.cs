using UnityEngine;
using System.Collections;

public class BerryStats : MonoBehaviour {

    public enum BerryType {Boss,Fire,Grass,Water,Magic};
    public BerryType berryType;
    SpriteRenderer rend;
    Sprite[] berrySprites;

    // Use this for initialization
    void Start() {
        rend = GetComponent<SpriteRenderer>();

        berrySprites = GetComponent<BerryArray>().BerrySprites;


        int berryRand = (Random.RandomRange(0, 4));

        switch (berryRand)
        {
            case 0:
                berryType = BerryType.Boss;
                rend.sprite = berrySprites[(int)BerryType.Boss];
                break;
            case 1:
                berryType = BerryType.Fire;
                rend.sprite = berrySprites[(int)BerryType.Fire];
                break;
            case 2:
                berryType = BerryType.Grass;
                rend.sprite = berrySprites[(int)BerryType.Grass];
                break;
            case 3:
                berryType = BerryType.Water;
                rend.sprite = berrySprites[(int)BerryType.Water];
                break;
            case 4:
                berryType = BerryType.Magic;
                rend.sprite = berrySprites[(int)BerryType.Magic];
                break;
            default:
                Debug.Log("berryt error");
                break;
        }
    }
           
	
	// Update is called once per frame
	void Update () {
	
	}
}
