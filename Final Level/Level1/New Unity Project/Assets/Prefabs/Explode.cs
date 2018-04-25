using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Explode : MonoBehaviour {

    public GameObject rockShatter;
    public AudioClip boom;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Floor")
        {
            Destroy(this.gameObject);
            GameObject clone = Instantiate(rockShatter, this.transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(boom, this.transform.position);
            Destroy(clone, 0.3f);
        }
    }
}
