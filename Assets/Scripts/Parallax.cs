using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
	public float parallaxEffectX = 0.1f;
	public float parallaxEffectY = 0.1f;

	private float lastCameraX;
	private float lastCameraY;
	private Transform cameraTansform;
    // Start is called before the first frame update
    void Start()
    {
		cameraTansform = Camera.main.transform;
		lastCameraX = cameraTansform.position.x;
		lastCameraY = cameraTansform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		float deltaX = cameraTansform.position.x - lastCameraX;
		float deltaY = cameraTansform.position.y - lastCameraY;
		lastCameraX = cameraTansform.position.x;
		lastCameraY = cameraTansform.position.y;

		transform.position += new Vector3(deltaX * parallaxEffectX, deltaY * parallaxEffectY, 0);
	}
}
