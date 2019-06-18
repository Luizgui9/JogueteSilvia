using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogar : MonoBehaviour
{
    public void buttonJogar(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("ingame");
    }
}
