using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
	public bool inAir;
	public GameObject gameObject;
	public float jump;


	private Rigidbody rb;


	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void Update()
	{

		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

	}

	void OnCollisionEnter(Collision other) 
	{
		if (other.gameObject.tag == "Floor") {
			inAir = false;
		}
	}

	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag == "Floor") {
			inAir = true;
		}
	}
		

	void FixedUpdate () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (h, 0.0f, v);
		rb.AddForce (movement * speed);

		if (Input.GetKeyDown ("space") && !inAir) {
			rb.AddForce (new Vector3 (0, jump, 0));
		}
	}

}
