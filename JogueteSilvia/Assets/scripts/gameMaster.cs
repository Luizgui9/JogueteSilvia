using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameMaster : MonoBehaviour
{
    public static gameMaster instancia;
    public Text melhorTempoText;
    public Text pontosText;
    public Text InputText;
    public Text timerText;
    private bool p1, p2, p3;
    public int pontos;
    private float startTime;
    public float bestTime;
    public float tempo;
    CultureInfo ci = new CultureInfo("en-us");

    void Start()
    {
        startTime = Time.time;
        
        if(PlayerPrefs.HasKey("Melhor tempo")){
            bestTime = PlayerPrefs.GetFloat("Melhor tempo");
        }else{
            bestTime = 999.99f;
        }

        if (PlayerPrefs.HasKey("Pontos"))
        {
            startTime = Time.time;
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                PlayerPrefs.DeleteKey("Pontos");
                PlayerPrefs.DeleteKey("Tempo");
                pontos = 0;
                tempo = 0.0f;

            }
            else
            {
                pontos = PlayerPrefs.GetInt("Pontos");
                tempo = PlayerPrefs.GetFloat("Tempo");
                bestTime = PlayerPrefs.GetFloat("Melhor tempo");
            }

            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                pontosText.text = PlayerPrefs.GetInt("Pontos").ToString();
                timerText.text = converteTempo(PlayerPrefs.GetFloat("Tempo"));
                melhorTempoText.text = converteTempo(PlayerPrefs.GetFloat("Melhor tempo"));
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
            tempo = t;

            timerText.text = converteTempo(t);
        }
    }
    string converteTempo(float time){
            string minutes = ((int)time / 60).ToString();
            string seconds = (time % 60).ToString("f2", ci);
            return minutes + ":" + seconds;
    }

}
