using UnityEngine;
using System.Collections;

public class BlockBehavior : MonoBehaviour {

    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter2D(Collider2D coll)
    {
        GameObject bullet;
        if (coll.gameObject.tag == "Bullet")
        {
            Debug.Log("block hit");

            bullet = coll.gameObject;

            switch (bullet.GetComponent<BulletStats>().type)
            {
                case BulletStats.BulletType.Fire:
                    Debug.Log("hit by fire block");
                    //check weakness and decrement;
                    break;
                case BulletStats.BulletType.Grass:
                    Debug.Log("ate grass berry");
                    //check weakness and decrement;
                    break;
                case BulletStats.BulletType.Water:
                    Debug.Log("ate water berry");
                    //check weakness and decrement;
                    break;
                default:
                    Debug.Log("berryt error");
                    break;
            }

            Destroy(bullet);

        }

    }

}
