﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour {
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            
            
            SceneManager.LoadScene("Win");
            
        }
    }
}
