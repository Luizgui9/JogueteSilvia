using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alavanca : MonoBehaviour
{
    private gameMaster gm;
    public GameObject Jaula;
    public GameObject JaulaFundo;
    private GameObject Personagem;
    public string nomePersonagem;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
        Personagem = GameObject.FindGameObjectWithTag(nomePersonagem);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.InputText.text = ("Aperte [E] para Ativar");
            if (Input.GetKeyDown("e"))
            {
                Destroy(Jaula);
                Destroy(JaulaFundo);
                Personagem.GetComponent<Cela>().aberta = true;
                //som de cela abrindo
                gm.InputText.text = ("Procure pela cela aberta");
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                Destroy(Jaula);
                Destroy(JaulaFundo);
                Personagem.GetComponent<Cela>().aberta = true;
                //som de cela abrindo
                gm.InputText.text = ("Procure pela cela aberta");
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
