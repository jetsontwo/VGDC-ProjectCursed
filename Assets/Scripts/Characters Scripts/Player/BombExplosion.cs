﻿using UnityEngine;
using System.Collections;

public class BombExplosion : MonoBehaviour {
    public float range;
    public int damage;

    // Use this for initialization
    void Start ()
    {
        gameObject.transform.localScale = new Vector3(range, range, 1);
	}
	
    void OnCollisionEnter2D(Collision2D hit)
    {
        PublicFunctions.DamageEnemy(hit, damage);
    }

    // Update is called once per frame
    void Update()
    {
        PublicFunctions.PhaseThruPlayer(gameObject);
    }

}
