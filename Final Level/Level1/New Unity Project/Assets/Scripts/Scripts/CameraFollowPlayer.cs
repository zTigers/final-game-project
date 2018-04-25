using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    public Transform target;
    public Transform leftBounds;
    public Transform rightBounds;
    public float smoothDampTime = 0.15f;

    private Vector3 smoothDampVelocity = Vector3.zero; 
    
   

    private float width, height, levelMinX, levelMaxX;

	// Use this for initialization
	void Start ()
    {
        height = Camera.main.orthographicSize * 2;
        width = height * Camera.main.aspect;

        float leftBoundWidth = leftBounds.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;
        float rightBoundsWidth = rightBounds.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;

        levelMinX = leftBounds.position.x + leftBoundWidth + (width / 2);
        levelMaxX = rightBounds.position.x - rightBoundsWidth + (width / 2);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(target)
        {
            float targetX = Mathf.Max(levelMinX, Mathf.Min(levelMaxX, target.position.x));
            float x = Mathf.SmoothDamp(transform.position.x, targetX, ref smoothDampVelocity.x, smoothDampTime);

            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
	}
}
