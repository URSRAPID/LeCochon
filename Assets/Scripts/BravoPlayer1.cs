using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BravoPlayer1 : MonoBehaviour
{
    public void PlayNewGame()
    {
        SceneManager.LoadScene("Scene1Player");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
