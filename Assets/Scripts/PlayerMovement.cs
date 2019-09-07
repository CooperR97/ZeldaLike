using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb2d;

    public float speed;

    private Vector3 change;

	private Animator anim;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
    }

    private void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
		UpdateAnimAndMove();
    }

    void UpdateAnimAndMove()
	{
		if (change != Vector3.zero)
		{
			MoveCharacter();
			anim.SetFloat("moveX", change.x);
			anim.SetFloat("moveY", change.y);
			anim.SetBool("moving", true);
		}
		else
		{
			anim.SetBool("moving", false);
		}
	}

    void MoveCharacter()
    {
        rb2d.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

}
