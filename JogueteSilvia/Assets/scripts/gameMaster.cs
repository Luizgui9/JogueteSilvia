using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameMaster : MonoBehaviour
{
    public static gameMaster instancia;

    public int pontos;

    public Text pontosText;

    public Text InputText;

    public Text timerText;

    private float startTime;
    public string tempo;
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
                pontos = 0;
                tempo = "";
            }
            else
            {
                pontos = PlayerPrefs.GetInt("Pontos");
                tempo = PlayerPrefs.GetString("Tempo");
            }

            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                timerText.text = tempo;
                pontosText.text = pontos.ToString();
            }
        }
        else
        {
            timerText.text = " ";
            pontosText.text = " ";
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2", ci);

            tempo = minutes + ":" + seconds;

            timerText.text = tempo;
        }
    }
}
