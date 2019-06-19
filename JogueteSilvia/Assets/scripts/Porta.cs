using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Porta : MonoBehaviour
{
    public int LevelACarregar;

    private gameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            gm.InputText.text = ("Aperte [E] para Entrar");
            if (Input.GetKeyDown("e"))
            {
                if (gm.pontos > 0)
                {
                    SalvarPontos();
                    SceneManager.LoadScene(LevelACarregar);
                }
                else
                {
                    gm.InputText.text = ("Salve pelo menos um personagem para sair!");
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if(Input.GetKeyDown("e"))
            {
                if (gm.pontos > 0)
                {
                    SalvarPontos();
                    SceneManager.LoadScene(LevelACarregar);
                }
                else
                {
                    gm.InputText.text = ("Salve pelo menos um personagem para sair!");
                }
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

    void SalvarPontos()
    {
        PlayerPrefs.SetInt("Pontos", gm.pontos);
        PlayerPrefs.SetFloat("Tempo", gm.tempo);

        if (gm.tempo < gm.bestTime)
        {
            PlayerPrefs.SetFloat("Melhor tempo", gm.tempo);
        }
    }

}
