using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FuncoesBotoes : MonoBehaviour
{

    public void Sair()
    {
        Application.Quit();
    }

    public void Jogar()
    {
        SceneManager.LoadScene(1);
    }

}
