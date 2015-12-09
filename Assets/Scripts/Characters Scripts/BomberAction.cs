﻿using UnityEngine;
using System.Collections;

public class BomberAction : MonoBehaviour {
    public GameObject Bomb;
    public int limit;
    private int numBombs;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.localPosition = Vector3.zero;

        numBombs = GameObject.FindGameObjectsWithTag("Friendly").Length;

        if (Input.GetButtonDown("Action") & numBombs < limit)
        {
            Instantiate(Bomb, gameObject.transform.position + new Vector3(0, 0, 0), gameObject.transform.rotation);
        }
	}
}