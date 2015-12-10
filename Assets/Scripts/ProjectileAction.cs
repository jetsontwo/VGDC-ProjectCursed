﻿using UnityEngine;
using System.Collections;

public class ProjectileAction : MonoBehaviour {
    public float speed;
    public int damage;
    private int startState;

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, 3);
    }
	
    void OnCollisionEnter2D(Collision2D contact)
    {
        if (contact.collider.gameObject.tag == "Enemy")
        {
            //Chaser.EnemyDamage(damage);
            Chaser c = (Chaser) contact.collider.gameObject.GetComponent(typeof(Chaser));
            c.EnemyDamage(damage);
        }

        Destroy(gameObject);
    }

	// Update is called once per frame
	void Update ()
    {
            transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
    }
}
