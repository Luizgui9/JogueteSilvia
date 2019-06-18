using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Jogo : MonoBehaviour
{
    public Text txtBotaoJogar;
    private int pontos = 0;
    void Start()
    {
        txtBotaoJogar.text = "Olá " + PlayerPrefs.GetString("login");
    }

    public void Pontuar()
    {
        if (Random.Range(1, 20) < 2)
        {
            txtBotaoJogar.text = "Que pena " + PlayerPrefs.GetString("login") + "\n" +
                                 "Você perdeu...";
            pontos = 0;
        }
        else
        {
            pontos++;
            txtBotaoJogar.text = "Parabéns " + PlayerPrefs.GetString("login") + "\n" +
                                 "Você já fez " + pontos + " ponto(s)";
        }
    }

    public void botaoAcabou()
    {
        StartCoroutine(atualizarPonto(PlayerPrefs.GetString("login")));        
    }

    IEnumerator atualizarPonto(string login)
    {
        WWWForm wwwf = new WWWForm();
        wwwf.AddField("SQL", "UPDATE player SET pontos = " + pontos + " WHERE login = '" + login +"'",
            System.Text.Encoding.UTF8);

        pontos = 0;
        txtBotaoJogar.text = "Olá " + PlayerPrefs.GetString("login");

        using (var w = UnityWebRequest.Post("https://spigo.net/sql_to_json.php", wwwf))
        {
            yield return w.SendWebRequest();
            PlayerPrefs.SetString("login", login);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Jogo");
        }

    }
}
