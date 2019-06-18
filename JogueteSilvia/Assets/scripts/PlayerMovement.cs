﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public Animator gateAnim;
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
        
        if(PauseScript.GameIsPaused){
            transform.Translate( 0, 0, 0);
        }
        else{
            Movimentacao();
        }
    }

    private void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.tag == "monster")
        {
            //Destroy(gameObject);
            //SceneManager.LoadScene(2);
        }
    }

    //Este onTrigger é uma tentativa de fazer a porta se abrir quando o player se aproxima
    public void OnTriggerEnter2D(Collider2D gateAction){
        if(gateAction.gameObject.tag == "Gate"){
          gateAnim.SetInteger("gate", 1);
          Debug.Log("------------------------ENTROU");
        }
        if(gateAnim){
            gateAnim.SetInteger("gate", 2);
        }
        
        
    }

    private void Movimentacao(){
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
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetInteger("move", 0);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed, 0, 0);
            animator.SetInteger("move", 1);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetInteger("move", 0);
        }
    }
}
