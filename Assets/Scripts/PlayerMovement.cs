using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public bool locked;

    private Vector2 velocity;


    private string horizontalAxis;
	private string verticalAxis;
    private float speed;
    private float maxSpeed;


    private Rigidbody2D rb2D;

	private PlayerStats playerStats;

	void Awake() {
		locked = false;
	}

	void Start() {
		playerStats = GetComponent<PlayerStats>();

        rb2D = GetComponent<Rigidbody2D>();
        speed = playerStats.speed;
        maxSpeed = playerStats.maxSpeed;
	}

	void Update() {
		HandleMovement();
	}

	void HandleMovement() {
        speed = playerStats.speed;
        maxSpeed = playerStats.maxSpeed;

        if (!locked) {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //go left
                transform.localScale = new Vector3(-2, 2, 1);
                transform.position += new Vector3 (-speed, 0.0f, 0.0f);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                //go right
                transform.localScale = new Vector3(2, 2, 1);
                transform.position += new Vector3 (speed, 0.0f, 0.0f) ;
            }

            //jump
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //transform.localScale = new Vector3(-1, 1, 1);
                transform.position += new Vector3(0.0f, speed, 0.0f);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                //transform.localScale = new Vector3(-1, 1, 1);
                transform.position += new Vector3(0.0f, -speed, 0.0f);
            }

            //limit the velocity if it's too high or too low
            if (velocity.x > maxSpeed)
            {
                velocity.x = maxSpeed;
            }
            else if (velocity.x < -maxSpeed)
            {
                velocity.x = -maxSpeed;
            }

            if (velocity.y > maxSpeed)
            {
                velocity.y = maxSpeed;
            }
            else if (velocity.y < -maxSpeed)
            {
                velocity.y = -maxSpeed;
            }


        }
    }


	public void InitializeAxes(string[] controls) {
		horizontalAxis = controls[0];
		verticalAxis = controls[1];
	}

	public Rigidbody2D GetRigidbody2D() {
		return rb2D;
	}
}
