using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Porta : MonoBehaviour
{
    public int LevelACarregar;

    private gameMaster gm;

    private float[] tempos2;

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
                if (gm.pontos == 1)
                {
                    Debug.Log("Final 1");
                    SalvarPontos();
                    SceneManager.LoadScene("Final03");
                }
                if (gm.pontos == 2)
                {
                    Debug.Log("Final 2");
                    SalvarPontos();
                    SceneManager.LoadScene("Final02");
                }
                if (gm.pontos == 3)
                {
                    Debug.Log("Final 3");
                    SalvarPontos();
                    SceneManager.LoadScene("Final01");
                }
                else
                {
                    Debug.Log("Não finalizou");
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
                if (gm.pontos == 1)
                {
                    Debug.Log("Final 1");
                    SalvarPontos();
                    SceneManager.LoadScene("Final03");
                }
                if (gm.pontos == 2)
                {
                    Debug.Log("Final 2");
                    SalvarPontos();
                    SceneManager.LoadScene("Final02");
                }
                if (gm.pontos == 3)
                {
                    Debug.Log("Final 3");
                    SalvarPontos();
                    SceneManager.LoadScene("Final01");
                }
                else
                {
                    Debug.Log("Não finalizou");
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

    public void SalvarPontos()
    {
        PlayerPrefs.SetInt("Pontos", gm.pontos);
        PlayerPrefs.SetFloat("Tempo", gm.tempo);
        tempos2 = gm.getTempos();
        Debug.Log(tempos2.Length);
        Debug.Log(gm.getQntJogadores());
        tempos2[gm.getQntJogadores() - 1] = gm.tempo;
        Debug.Log(tempos2[gm.getQntJogadores() - 1]);
        PlayerPrefsX.SetFloatArray("Tempos", tempos2);

        if (gm.tempo < gm.bestTime)
        {
            PlayerPrefs.SetFloat("Melhor tempo", gm.tempo);
        }
    }

}
