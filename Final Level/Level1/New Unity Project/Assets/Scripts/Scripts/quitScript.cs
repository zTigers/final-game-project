using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class quitScript : MonoBehaviour {


    public void quitGame()
    {


        Debug.Log("Games is exiting");
        Application.Quit();

    }
    
}
