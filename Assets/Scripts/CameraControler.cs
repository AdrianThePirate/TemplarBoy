using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class CameraControler : MonoBehaviour {
	public Transform PlayerTransform;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update() {
		var x = PlayerTransform.position.x;
		var y = PlayerTransform.position.y;
		if (x < 0)
			x = 0;
		if (y < 0)
			y = 0;
		transform.position = new Vector3(x, y, -10);
	}
}
