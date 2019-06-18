using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cela : MonoBehaviour
{
    private gameMaster gm;

    private GameObject HUD;

    public string nomeHUD;

    public bool aberta = false;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
        HUD = GameObject.FindGameObjectWithTag(nomeHUD);
        HUD.GetComponent<SpriteRenderer>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (aberta)
            {
                gm.InputText.text = ("Aperte [E] para Libertar");
                if (Input.GetKeyDown("e"))
                {
                    HUD.GetComponent<SpriteRenderer>().enabled = true;
                    gm.pontos += 1;
                    Destroy(this.gameObject);
                    //adicionar score e personagem ao HUD
                }
            }
            else
            {
                gm.InputText.text = ("Tente acionar uma das tochas apagadas para abrir a cela!");
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e") && (aberta))
            {
                HUD.GetComponent<SpriteRenderer>().enabled = true;
                gm.pontos += 1;
                Destroy(this.gameObject);
                //adicionar score e personagem ao HUD
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.InputText.text = (" ");
        }
    }
}
