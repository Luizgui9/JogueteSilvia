using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaiParaNovoUsuario : MonoBehaviour
{
    public void botaoVaiParaNovoUsuario()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CriaConta");
    }
}
