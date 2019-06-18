using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Logar : MonoBehaviour
{
    public InputField inputLogin;
    public InputField inputSenha;
    
    public void botaoVerificaLogin()
    {
        StartCoroutine(verificaLogin(inputLogin.text, inputSenha.text));
    }

    IEnumerator verificaLogin(string login, string password)
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
                if(playerContainer.objetos.Length == 0)
                {
                    Debug.Log("Usuário inexistente");
                }
                else
                {
                    if (playerContainer.objetos[0].password == password)
                    {
                        PlayerPrefs.SetString("login", login);
                        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
                    }
                    else
                    {
                        Debug.Log("Erroooou a senha");
                    }
                }
                
            }

        }
    }
}
