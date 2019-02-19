using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

  public float jumpForce;
  public float runSpeed;
  Rigidbody2D rb;
  bool canJump;

	// Use this for initialization
	void Start () {
    rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
    if (Input.GetButtonDown("Jump") && canJump)
    {
      canJump = false;
      rb.velocity += new Vector2(0, jumpForce);
    }
    rb.velocity = new Vector2(Input.GetAxis("Horizontal") * runSpeed, rb.velocity.y);
	}

  private void OnCollisionEnter2D(Collision2D collision)
  {
    Debug.Log(collision.transform.name);
    if (collision.transform.name.Contains("Ground"))
    {
      canJump = true;
    }
  }

  private void OnCollisionExit2D(Collision2D collision)
  {
    if (collision.transform.name.Contains("Ground"))
    {
      canJump = false;
    }
  }
}
