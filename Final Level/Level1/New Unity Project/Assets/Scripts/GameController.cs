using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// NEW USING STATEMENTS
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [Header("Wave Settings")]
    public GameObject hazard; // What are we spawning?
   // public Vector2 spawnValue; // Where do we spawn our hazards?
    public int hazardCount; // How many hazards per wave?
    public float startWait; // How long until the first wave?
    public float spawnWait; // How long between each hazard in each wave?
    public float waveWait; // How long between each wave of enemies?
    public Transform target;
    private float width, height, levelMinX, levelMaxX;
    public float smoothDampTime = 0.15f;
    private Vector3 smoothDampVelocity = Vector3.zero;
    public Transform leftBounds;
    public Transform rightBounds;

    [Header("Text Options")]
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    [Header("Game Audio Options")]
    public AudioClip victorySFX;

    private bool gameOver;
    private bool restart;
    private int score;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        /*  score = 0;

          scoreText.text = "";
          restartText.text = "";
          gameOverText.text = "";

          audioSource = GetComponent<AudioSource>();

          UpdateScore();*/
        float leftBoundWidth = leftBounds.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;
        float rightBoundsWidth = rightBounds.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;

        levelMinX = leftBounds.position.x + leftBoundWidth + (width / 2);
        levelMaxX = rightBounds.position.x - rightBoundsWidth + (width / 2);

        StartCoroutine(SpawnWaves());
	}
	
	// Update is called once per frame
	void Update () {
		if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                // THE OLD WAY (DON'T USE THIS ONE)
                // Application.LoadLevel(Application.loadedLevel);
                // SceneManager.LoadScene("Spaceshooter"); // <-- This works fine but prone to error
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // <-- Better but more complicated
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait); // Pause. How long do we wait for the first wave?
        while(true)
        {
            for(int i = 0; i < hazardCount; i++)
            {
                //Vector2 spawnPosition = new Vector2(spawnValue.y, Random.Range(-spawnValue.x, spawnValue.x));
                //Vector2 spawnPosition = new Vector2(spawnValue.y, Random.Range(-16.0f.,))
                //                                      12                          -3.5          3.5
                if (target)
                {
                    float targetX = Mathf.Max(levelMinX, Mathf.Min(levelMaxX, target.position.x));
                    float x = Mathf.SmoothDamp(transform.position.x, targetX, ref smoothDampVelocity.x, smoothDampTime);

                    transform.position = new Vector3(x, transform.position.y, transform.position.z);
                }

                Quaternion spawnRotation = Quaternion.identity; // Default rotation.
                Instantiate(hazard, transform.position, spawnRotation);
                yield return new WaitForSeconds(spawnWait); // Wait time between spawning each asteroid
            }
            yield return new WaitForSeconds(waveWait);

            if(gameOver)
            {
                restartText.gameObject.SetActive(true);
                restartText.text = "Press R for Restart";
                restart = true;
                break;
            }
        }
    }

    // Update the score text
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        // score = score + newScoreValue;
        // Debug.Log("Score is " + score);

        if(score % 100 == 0)
        {
            audioSource.clip = victorySFX;
            audioSource.Play();
        }

        UpdateScore();
    }

    public void GameOver()
    {
        // Debug.Log("Game is Over");
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}
