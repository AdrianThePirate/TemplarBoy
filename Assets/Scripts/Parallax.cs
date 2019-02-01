using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
	public float paralaxEffectX = 0.1f;
	public float paralaxEffectY = 0.1f;

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
    void Update()
    {
		float deltaX = cameraTansform.position.x - lastCameraX;
		transform.position += Vector3.right * (deltaX * paralaxEffectX);
		lastCameraX = cameraTansform.position.x;

		float deltaY = cameraTansform.position.y - lastCameraY;
		transform.position += Vector3.up * (deltaY * paralaxEffectY);
		lastCameraY = cameraTansform.position.y;
	}
}
