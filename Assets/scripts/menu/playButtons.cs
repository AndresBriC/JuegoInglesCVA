using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playButtons : MonoBehaviour
{
    public void playHouse()
    {
        SceneManager.LoadScene(2);
    }

    public void playBus()
    {
        SceneManager.LoadScene(3);
    }

    public void playSchool()
    {
        SceneManager.LoadScene(4);
    }
}
