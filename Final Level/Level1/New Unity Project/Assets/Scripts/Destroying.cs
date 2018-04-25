using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Destroying : MonoBehaviour {
   
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            SceneManager.LoadScene("End Game");



        }
       /* if (other.tag == "Floor")
        {
            Destroy(this.gameObject);
        }
        if(other.tag == "Lava")
        {
            Destroy(this.gameObject);
        }
        */
    }
   

}
