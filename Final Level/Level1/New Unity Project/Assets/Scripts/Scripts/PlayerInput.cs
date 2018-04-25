using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {

	Player player;
    private Animator animator;
    public AudioSource audioSource;
    public AudioSource WalkSound;
    public AudioSource WalkSoundLeft;
    public AudioClip jumpSound;

    void Start () {
		player = GetComponent<Player> ();
        animator = GetComponent<Animator>();
        audioSource.clip = jumpSound;
        WalkSound.enabled = false;
        WalkSoundLeft.enabled = false;
    }

	void Update () {
		Vector2 directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		player.SetDirectionalInput (directionalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("jump");
            audioSource.Play();
            player.OnJumpInputDown();

        }
		if (Input.GetKeyUp (KeyCode.Space)) {
			player.OnJumpInputUp ();
		}

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetTrigger("RunLeft");
            WalkSound.enabled = true;
            WalkSound.loop = true;
        }
        else
        {
            WalkSound.enabled = false;
            WalkSound.loop = false;
        }
    
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetTrigger("RunRight");
            WalkSoundLeft.enabled = true;
            WalkSoundLeft.loop = true;
        }
        else
        {
            WalkSoundLeft.enabled = false;
            WalkSoundLeft.loop = false;
        }
    }

    }

