using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -speed, 0);
            animator.SetInteger("move", 3);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetInteger("move", 0);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, speed, 0);
            animator.SetInteger("move", 2);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetInteger("move", 0);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed, 0, 0);
            animator.SetInteger("move", 1);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetInteger("move", 0);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed, 0, 0);
            animator.SetInteger("move", 1);
            transform.localScale = new Vector2(1, 1);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetInteger("move", 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.tag == "monster")
        {
            Destroy(gameObject);
        }
    }
}
