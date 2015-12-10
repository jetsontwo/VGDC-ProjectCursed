﻿using UnityEngine;
using System.Collections;

public class ShieldAction : MonoBehaviour {
    public int damage;
    public float size;

	// Use this for initialization
	void Start ()
    {
        gameObject.transform.localScale = new Vector3(size, size, size);
	}

    void OnCollisionEnter2D(Collision2D touch)
    {
        if (touch.collider.gameObject.tag == "Enemy")
        {
            //Chaser.EnemyDamage(damage);
            Chaser c = (Chaser) touch.collider.gameObject.GetComponent(typeof(Chaser));
            c.EnemyDamage(damage);
        }
    }

	// Update is called once per frame
	void Update ()
    {
        PublicFunctions.PhaseThruFriend(gameObject);
	}
}

//Possibly make shield for enemies as well?