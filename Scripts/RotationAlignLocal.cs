using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAlignLocal : MonoBehaviour {

	public float aimSpeed = 10.0f;
	private Vector3 history;

	void Start () {
		history = transform.localPosition;
	}

	void Update () {
		Vector3 direction = transform.localPosition - history;
		history = transform.localPosition; // Don't update history until after the direction is calculated, so as to grab the previous frame position data

		direction = direction.normalized;
		var rotation = Quaternion.LookRotation(direction);
		transform.localRotation = Quaternion.Slerp(transform.localRotation, rotation, aimSpeed * Time.deltaTime);
	}
}

// Resources:
// https://www.c-sharpcorner.com/article/transforming-objects-using-c-sharp-scripts-in-unity/
// https://www.youtube.com/watch?v=YfIOPWuUjn8
// https://docs.unity3d.com/ScriptReference/Transform-rotation.html
// https://docs.unity3d.com/ScriptReference/Transform-position.html
// https://docs.unity3d.com/ScriptReference/Mathf.PerlinNoise.html
