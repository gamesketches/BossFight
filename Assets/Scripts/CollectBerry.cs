using UnityEngine;
using System.Collections;

public class CollectBerry : MonoBehaviour {


    private GameObject berry;
    PlayerStats playerStats;

	// Use this for initialization
	void Start () {

        playerStats = GetComponent<PlayerStats>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Berry")
        {
            Debug.Log("ooh eaten");
        }

        berry = coll.gameObject;

        switch (berry.GetComponent<BerryStats>().berryType)
        {
            case BerryStats.BerryType.Boss:
                Debug.Log("ate a boss berry");
                break;
            case BerryStats.BerryType.Fire:
                Debug.Log("ate fire berry");
                playerStats.firePower++;
                break;
            case BerryStats.BerryType.Grass:
                Debug.Log("ate grass berry");
                playerStats.grassPower++;
                break;
            case BerryStats.BerryType.Water:
                Debug.Log("ate water berry");
                playerStats.waterPower++;
                break;
            case BerryStats.BerryType.Magic:
                Debug.Log("ate magic berry");
                break;
            default:
                Debug.Log("berryt error");
                break;
        }

        Destroy(berry);


    }
}
