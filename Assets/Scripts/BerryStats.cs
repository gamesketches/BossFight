using UnityEngine;
using System.Collections;

public class BerryStats : MonoBehaviour {

    private enum BerryType {Boss,Fire,Grass,Water,Magic};
    BerryType berryType;

    // Use this for initialization
    void Start() {
        int berryRand = (Random.RandomRange(0, 4));
        switch (berryRand)
        {
            case 0:
                berryType = BerryType.Boss;
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
