using UnityEngine;
using System.Collections;

public class BulletStats : MonoBehaviour {


    public Sprite[] BulletSprites;
    public enum BulletType {Fire, Grass, Water};
    public BulletType type;
    public enum Dir { right, down, left, up };
    public Dir dir;

    public float lifetime = 0;
    public int shotIndex = 0; //using for water shot

    // Use this for initialization
    void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
