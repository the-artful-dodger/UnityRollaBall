using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Globalization;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	private int count;
	public Text countText;
	public Text winText;
	public Text scorer; 
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
		scorer.text = "";
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement*speed);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 11) {
			winText.text = "You Win!!";
			float scoreValue = (1 / Time.realtimeSinceStartup) * 100000000;
			scorer.text = (scoreValue.ToString());
			if(Input.GetKey("escape"))
				Application.Quit();
		}
	}
}