using UnityEngine;
using System.Collections;

public class ship : MonoBehaviour {

	public Rigidbody2D rb;
	public int speed;
	bool up = false;
	bool down = false;
	bool right = false;
	bool left = false;
	float timer = 0;

	bool shootside =false;

	Transform rightg;
	Transform leftg;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		leftg = transform.Find ("Left");
		rightg = transform.Find ("Right");
	
	}
	void shoot(){
		if (timer < Time.time) {

			if (shootside) {
				GameObject tmp = Instantiate (Resources.Load ("beam"), leftg.position, leftg.rotation)as GameObject;

				shootside = false;
				timer = Time.time + 0.5f;
			} else {
				GameObject tmp = Instantiate (Resources.Load ("beam"), rightg.position, rightg.rotation)as GameObject;
				shootside = true;
				timer = Time.time + 0.25f;
			}

		}
	}

	// Update is called once per frame
	void Update () {
	if (Input.GetMouseButton (0))
	{shoot ();
	}
		if (Input.GetKey (KeyCode.W)) {
			up = true;
		} else
			up = false;
		if (Input.GetKey (KeyCode.S)) {
			down = true;
		} else
			down = false;
		if (Input.GetKey (KeyCode.A)) {
			left = true;
		} else
			left = false;
		if (Input.GetKey (KeyCode.D)) {
			right = true;
		} else
			right = false;
	
	
	}

	void FixedUpdate(){
		Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 lookat = transform.position - mouse;
		float angle = Mathf.Atan2 (lookat.y, lookat.x) * Mathf.Rad2Deg + 90;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

		if (up) {
			rb.AddForce (transform.up * speed);

		}
		if (down) {
			rb.AddForce (-transform.up * speed);
		}
		if (left) {
			rb.AddForce (-transform.right * speed);
		}
		if (right) {
			rb.AddForce (transform.right * speed);
		}
}

}
