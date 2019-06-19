using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrIntro : MonoBehaviour
{
    public void buttonIntro()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Intro");
    }
}
