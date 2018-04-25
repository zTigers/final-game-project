using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour {

    // Use this for initialization
    public void LoadScene(int level)
    {

        SceneManager.LoadScene(level);
    }
}
