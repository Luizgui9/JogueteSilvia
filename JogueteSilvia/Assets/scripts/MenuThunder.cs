using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuThunder : MonoBehaviour
{
    public float timer;
    public Animator animator;
    public AudioSource audio;

    void Start()
    {
        animator = GetComponent<Animator>();

    }
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 1){
            audio.Play();
        }
        if(timer <= 0)
        {
            animator.SetInteger("thunder", 1);
            timer = 10;
        }
        if(timer <= 9f)
        {
            animator.SetInteger("thunder", 0);
        }
        if (timer < 8f)
        {
            animator.SetInteger("thunder", 1);
            
        }
        if (timer < 7f)
        {
            animator.SetInteger("thunder", 0);
        }
        if (timer < 6f)
        {
            audio.Stop();
        }
    }
}
