using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public Text melhorTempo;
    public Text tempoatual;
    public Text media;
    public Text Mediana;

    void Start()
    {
        melhorTempo.text = HighScore();
        tempoatual.text = PlayerPrefs.GetFloat("tempo").ToString("f2");
    }

    void Update()
    {
        
    }

    public string HighScore()
    {
        float tempo = PlayerPrefs.GetFloat("tempo");

        if (tempo < PlayerPrefs.GetFloat("tempo"))
        {
            PlayerPrefs.SetFloat("tempo", tempo);
        }
        return tempo.ToString("f2");
    }
}
