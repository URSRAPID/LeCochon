using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void PlayGame1Player()
    {
        SceneManager.LoadScene("Scene1Player");
    }
    public void duquit()
    {
        Debug.Log("Il est hors jeu");
        Application.Quit();
        
    }
}
   

