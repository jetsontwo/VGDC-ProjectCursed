﻿using UnityEngine;
using System.Collections;

public class ShieldAction : MonoBehaviour {
    public int damage;
    public float size;
    private CircleCollider2D outer;

	// Use this for initialization
	void Start ()
    {
        outer = gameObject.GetComponent<CircleCollider2D>();

        gameObject.transform.localScale = new Vector3(size * 3 / 4, size, size);
        //Sets size of shield

        PublicFunctions.PhaseThruTag(gameObject, new string[] { "Player", "Friendly" });
        //Phase through players and enemies
    }

    void OnCollisionEnter2D(Collision2D touch)
    {
        PublicFunctions.DamageEnemy(touch, damage);
    }//Damage the enemy

	// Update is called once per frame
	void Update ()
    {
        transform.localPosition = Vector3.zero;
	}//Keeps the shield in center of the player
}

//Possibly make shield for enemies as well?