﻿using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
    public static int team = 2;

	// Use this for initialization
	void Start () {
	
		Destroy (gameObject, 3);

	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate(Vector3.forward);

	}
}
