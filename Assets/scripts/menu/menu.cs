using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene(1);
    }

    public void exit()
    {
        Debug.Log("Se salio de la aplicación...");
        Application.Quit();
    }
}
