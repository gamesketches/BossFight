using UnityEngine;
using System.Collections;

public class BlockBehavior : MonoBehaviour {


    BlockStats blockStats;

    // Use this for initialization
    void Start () {
        blockStats = GetComponent<BlockStats>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter2D(Collider2D coll)
    {
        GameObject bullet;
        BulletStats bulletStats;
        if (coll.gameObject.tag == "Bullet")
        {
            Debug.Log("block hit");

            bullet = coll.gameObject;

            bulletStats = bullet.GetComponent<BulletStats>();
            
            switch (blockStats.type)
            {
                case BlockStats.BlockType.Fire:
                    //check weakness and decrement;
                    if (bulletStats.type == BulletStats.BulletType.Water)
                    {
                        Debug.Log("Fire block hit by water");
                        blockStats.hp--;
                        CheckHP();
                    }
                    break;
                case BlockStats.BlockType.Grass:
                    //check weakness and decrement;
                    if (bulletStats.type == BulletStats.BulletType.Fire)
                    {
                        Debug.Log("Grass block hit by fire");
                        blockStats.hp--;
                        CheckHP();
                    }
                    break;
                case BlockStats.BlockType.Water:
                    //check weakness and decrement;
                    if (bulletStats.type == BulletStats.BulletType.Grass)
                    {
                        Debug.Log("Grass block hit by water");
                        blockStats.hp--;
                        CheckHP();
                    }
                    break;
                default:
                    Debug.Log("berryt error");
                    break;

            }
            Destroy(bullet);
        }

    }

    void CheckHP()
    {
        if(blockStats.hp <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }


    
}
