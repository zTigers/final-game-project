using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavakiller : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Lava")
        {
            Destroy(this.gameObject);
        }
    }
}
