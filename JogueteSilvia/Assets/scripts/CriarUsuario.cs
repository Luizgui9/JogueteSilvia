using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class CriarUsuario : MonoBehaviour
{
    public InputField inputLogin;
    public InputField inputPassword;
    public InputField inputPasswordConf;
    public void botaoCriarLogin()
    {
        if (inputPassword.text == inputPasswordConf.text
            && inputPassword.text != ""
            && inputLogin.text != "")
        {
            StartCoroutine(CadastrarUsuario(inputLogin.text, inputPassword.text));
        }
        else
        {
            Debug.Log("Senha diferentes ou em branco");
        }
    }

    IEnumerator CadastrarUsuario(string login, string password)
    {
        WWWForm wwwf = new WWWForm();
        wwwf.AddField("SQL", "SELECT * FROM player WHERE login = '" + login + "'",
            System.Text.Encoding.UTF8);


        using (var w = UnityWebRequest.Post("https://spigo.net/sql_to_json.php", wwwf))
        {
            yield return w.SendWebRequest();

            if (w.isNetworkError || w.isHttpError)
            {
                Debug.Log(w.error);
            }
            else
            {
                Players playerContainer = JsonUtility.FromJson<Players>(w.downloadHandler.text);
                if (playerContainer.objetos.Length == 0)
                {
                    StartCoroutine(InserirUsuarioNoBanco(login, password));
                }
                else
                {
                    Debug.Log("Não vou criar, " + login + " já existe");
                }

            }

        }
    }


    IEnumerator InserirUsuarioNoBanco(string login, string password)
    {
        WWWForm wwwf = new WWWForm();
        wwwf.AddField("SQL", "INSERT INTO player (login, password) VALUES ('" + login + "' , '" + password + "' )",
            System.Text.Encoding.UTF8);


        using (var w = UnityWebRequest.Post("https://spigo.net/sql_to_json.php", wwwf))
        {
            yield return w.SendWebRequest();
            PlayerPrefs.SetString("login", login);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }

    }
}
