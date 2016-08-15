using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {


    BulletStats bulletStats;
    float fireSpeed = 0.075f;
    float waterSpeed = 0.05f;
    float grassGrow = 0.1f;
    int growthRate = 1;
    float birthTime = Time.time;
    int maxGrass = 5;

    public GameObject basicBulletPrefab;
    public float inheritedBirth = -1;

    private PlayerStats playerStats;
	// Use this for initialization
	void Start () {
        bulletStats = GetComponent<BulletStats>();
        if(inheritedBirth > 0)
        {
            birthTime = inheritedBirth;
        }
//        birthTime = Time.time;
        
	}
	
	// Update is called once per frame
	void Update () {


        if (bulletStats.lifetime <= Time.time - birthTime)
            Destroy(gameObject);
        //Debug.Log("lifetime = " + (bulletStats.lifetime  - ( Time.time - birthTime)));

        switch (bulletStats.type)
        {
            case BulletStats.BulletType.Fire:
                //fire behavior
                switch (bulletStats.dir)
                {
                    case BulletStats.Dir.right:
                        transform.position += new Vector3(fireSpeed, 0.0f, 0.0f);
                        break;
                    case BulletStats.Dir.left:
                        transform.position += new Vector3(-fireSpeed, 0.0f, 0.0f);
                        break;
                    case BulletStats.Dir.down:
                        transform.position += new Vector3(0.0f, -fireSpeed, 0.0f);
                        break;
                    case BulletStats.Dir.up:
                        transform.position += new Vector3(0.0f, fireSpeed, 0.0f);
                        break;
                    default:
                        Debug.Log("Fire bullet behavior error");
                        break;
                }
                break;
            case BulletStats.BulletType.Water:
                //water behavior
                switch (bulletStats.dir)
                {
                    case BulletStats.Dir.right:
                        WaterShot(bulletStats);
                        break;
                    case BulletStats.Dir.down:
                        WaterShot(bulletStats);
                        break;
                    case BulletStats.Dir.left:
                        WaterShot(bulletStats);
                        break;
                    case BulletStats.Dir.up:
                        WaterShot(bulletStats);
                        break;
                    default:
                        Debug.Log("Water bullet direction error");
                        break;
                }
                break;
            case BulletStats.BulletType.Grass:
                grassShot(bulletStats);
                break;
            default:
                Debug.Log("Undefined bullet behavior error");
                break;
        }
	
	}

    void WaterShot(BulletStats blstats) //shoot 3 bullets spread style
    {
        float slowFactor = 0.00f;
        slowFactor += 0.04f;
        switch (blstats.dir)
        {
            case BulletStats.Dir.right:
                switch (bulletStats.shotIndex)
                {
                    case 0:
                        transform.position += new Vector3(waterSpeed - slowFactor, waterSpeed - slowFactor, 0.0f);
                        break;
                    case 1:
                        transform.position += new Vector3(waterSpeed - slowFactor, 0.0f, 0.0f);
                        break;
                    case 2:
                        transform.position += new Vector3(waterSpeed - slowFactor, -waterSpeed + slowFactor, 0.0f);
                        break;
                    default:
                        Debug.Log("Water bullet behavior error");
                        break;
                }
                break;
            case BulletStats.Dir.left:
                switch (bulletStats.shotIndex)
                {
                    case 0:
                        transform.position += new Vector3(-waterSpeed + slowFactor, waterSpeed - slowFactor, 0.0f);
                        break;
                    case 1:
                        transform.position += new Vector3(-waterSpeed + slowFactor, 0.0f, 0.0f);
                        break;
                    case 2:
                        transform.position += new Vector3(-waterSpeed + slowFactor, -waterSpeed + slowFactor, 0.0f);
                        break;
                    default:
                        Debug.Log("Water bullet behavior error");
                        break;
                }
                break;
            case BulletStats.Dir.down:
                switch (bulletStats.shotIndex)
                {
                    case 0:
                        transform.position += new Vector3(-waterSpeed + slowFactor, -waterSpeed + slowFactor, 0.0f);
                        break;
                    case 1:
                        transform.position += new Vector3(0.0f, -waterSpeed + slowFactor, 0.0f);
                        break;
                    case 2:
                        transform.position += new Vector3(waterSpeed - slowFactor, -waterSpeed + slowFactor, 0.0f);
                        break;
                    default:
                        Debug.Log("Water bullet behavior error");
                        break;
                }
                break;
            case BulletStats.Dir.up:
                switch (bulletStats.shotIndex)
                {
                    case 0:
                        transform.position += new Vector3(waterSpeed - slowFactor, waterSpeed - slowFactor, 0.0f);
                        break;
                    case 1:
                        transform.position += new Vector3(0.0f, waterSpeed - slowFactor, 0.0f);
                        break;
                    case 2:
                        transform.position += new Vector3(-waterSpeed + slowFactor, waterSpeed - slowFactor, 0.0f);
                        break;
                    default:
                        Debug.Log("Water bullet behavior error");
                        break;
                }
                break;
        }
    }

    void grassShot(BulletStats blstats) //grow grass
    {
        float growChance;

        growChance = Random.RandomRange(0, 1.0f);

        //if ((Time.time - startTime >= growthRate))
            Debug.Log("checking for growth : " + (Time.time - birthTime));
        if ((Time.time - birthTime >= growthRate) && growChance <= grassGrow && blstats.shotIndex + 1 < maxGrass)
        {
            GameObject bullet = null;
            BulletStats bulletStats;

            bullet = ((GameObject)Instantiate(basicBulletPrefab, transform.position + new Vector3(Random.Range(-1, 1) , Random.Range(-1, 1) , 0.0f),
                Quaternion.Euler(0.0f, 0.0f, 0.0f)));
            bulletStats = bullet.GetComponent<BulletStats>();
            bullet.GetComponent<SpriteRenderer>().sprite = bullet.GetComponent<BulletStats>().BulletSprites[1];
            bulletStats.type = BulletStats.BulletType.Grass;
            //bulletStats.dir = (BulletStats.Dir)playerStats.currentDir; 
            bulletStats.lifetime = (bulletStats.lifetime - (Time.time - birthTime));
            bulletStats.shotIndex = blstats.shotIndex + 1;
            bullet.GetComponent<BulletBehavior>().inheritedBirth = birthTime;   
            
            Debug.Log("shot index = " + blstats.shotIndex);
            growChance = 0; //stop this grass from producing moer
        }
    }

}