using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameMaster : MonoBehaviour
{
    public static gameMaster instancia;
    public Text melhorTempoText, InputText, timerText, mediaText, medianaText;
    public int hudElfo, hudOrc, hudVampiro;
    public int pontos;
    private float startTime;
    public float bestTime;
    public float tempo;
    CultureInfo ci = new CultureInfo("en-us");

    public int qntJogadores;

    private GameObject HUD1, HUD2, HUD3;

    public string HUDELFO, HUDVAMPIRO, HUDORC;

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
                PlayerPrefs.DeleteKey("Elfo");
                PlayerPrefs.DeleteKey("Orc");
                PlayerPrefs.DeleteKey("Vampiro");
                pontos = 0;
                tempo = 0.0f;
                hudElfo = 0;
                hudOrc = 0;
                hudVampiro = 0;

                if (PlayerPrefs.HasKey("qntJogadores"))
                {
                    qntJogadores = PlayerPrefs.GetInt("qntJogadores") + 1;
                }
                else
                {
                    PlayerPrefs.SetInt("qntJogadores", 0);                    
                }
            }
            else
            {
                pontos = PlayerPrefs.GetInt("Pontos");
                tempo = PlayerPrefs.GetFloat("Tempo"+qntJogadores);
                bestTime = PlayerPrefs.GetFloat("Melhor tempo");
                hudElfo = PlayerPrefs.GetInt("Elfo");
                hudOrc = PlayerPrefs.GetInt("Orc");
                hudVampiro = PlayerPrefs.GetInt("Vampiro");

            }

            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                if (PlayerPrefs.HasKey("Elfo")){
                    if(PlayerPrefs.GetInt("Elfo") == 1){
                        HUD1 = GameObject.FindGameObjectWithTag(HUDELFO);
                        HUD1.GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
                if (PlayerPrefs.HasKey("Vampiro")){
                    if(PlayerPrefs.GetInt("Vampiro") == 1){
                        HUD2 = GameObject.FindGameObjectWithTag(HUDVAMPIRO);
                        HUD2.GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
                if (PlayerPrefs.HasKey("Orc")){
                    if(PlayerPrefs.GetInt("Orc") == 1){
                        HUD3 = GameObject.FindGameObjectWithTag(HUDORC);
                        HUD3.GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
                timerText.text = converteTempo(PlayerPrefs.GetFloat("Tempo"+qntJogadores));
                melhorTempoText.text = converteTempo(PlayerPrefs.GetFloat("Melhor tempo"));
                float tempoTotal = 0, mediana = 0;
                for (int i = 0; i <= qntJogadores; i++)
                {
                    tempoTotal += PlayerPrefs.GetFloat("Tempo"+i);
                    if ((qntJogadores+1) % 2 == 0)
                    {
                        if (i == (qntJogadores + 1) / 2)
                            mediana = PlayerPrefs.GetFloat("Tempo" + i);
                        if (i == ((qntJogadores + 1) / 2) + 1)
                            mediana = (mediana + PlayerPrefs.GetFloat("Tempo" + i)) / 2;
                    }
                    else
                    {
                        if (i == (qntJogadores) / 2)
                            mediana = PlayerPrefs.GetFloat("Tempo" + i);
                    }
                }
                mediaText.text = converteTempo((tempoTotal/(float)qntJogadores));
                
                medianaText.text = converteTempo(mediana);
            }
        }
        else
        {
            // pontosText.text = " ";
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
