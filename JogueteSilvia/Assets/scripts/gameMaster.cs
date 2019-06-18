using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class gameMaster : MonoBehaviour
{
    public static gameMaster instancia;

    public int pontos;

    public Text melhorTempoText;

    public Text pontosText;

    public Text InputText;

    public Text timerText;

    private bool p1, p2, p3;

    private float startTime;
    public float bestimes = 1000.00f;
    public float tempo;
    CultureInfo ci = new CultureInfo("en-us");

    void Start()
    {
        startTime = Time.time;
        if (PlayerPrefs.HasKey("Pontos"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                PlayerPrefs.DeleteKey("Pontos");
                PlayerPrefs.DeleteKey("Tempo");
                PlayerPrefs.DeleteKey("Melhor tempo");
                pontos = 0;
                tempo = 0.0f;
                bestimes = 0.0f;
            }
            else
            {
                pontos = PlayerPrefs.GetInt("Pontos");
                tempo = PlayerPrefs.GetFloat("Tempo");
                bestimes = PlayerPrefs.GetFloat("Melhor tempo");
            }

            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                pontosText.text = PlayerPrefs.GetInt("Pontos").ToString();
                timerText.text = PlayerPrefs.GetFloat("Tempo").ToString("f2");
                melhorTempoText.text = PlayerPrefs.GetFloat("Melhor tempo").ToString("f2");
            }
        }
        else
        {
            pontosText.text = " ";
            timerText.text = " ";
            melhorTempoText.text = " ";
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2", ci);

            tempo = t;
            timerText.text = minutes + ":" + seconds;
        }
    }

}
