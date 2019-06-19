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
                    SalvaHud();
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
                SalvaHud();
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

    void SalvaHud(){
        if(nomeHUD == "hudelfo" && HUD.GetComponent<SpriteRenderer>().enabled == true){
            gm.hudElfo = 1;
            PlayerPrefs.SetInt("Elfo", gm.hudElfo);
        }
        if(nomeHUD == "hudorc" && HUD.GetComponent<SpriteRenderer>().enabled == true){
            gm.hudOrc = 1;
            PlayerPrefs.SetInt("Orc", gm.hudOrc);
        }
        if(nomeHUD == "hudvampira" && HUD.GetComponent<SpriteRenderer>().enabled == true){
            gm.hudVampiro = 1;
            PlayerPrefs.SetInt("Vampiro", gm.hudVampiro);
        }
    }
}
