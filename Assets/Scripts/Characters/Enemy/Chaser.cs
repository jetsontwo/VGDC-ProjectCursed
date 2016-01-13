﻿using UnityEngine;
using System.Collections;
using System;

public class Chaser : MonoBehaviour {
    public float totalHealth;
    private float health;
    public float speed;
    private Transform player;
    public GameObject healthBar;
    private Vector3 direction;
    private float aroundTime;
    public GameObject HealthPickUp;
    public int dropPercent;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        healthBar.SetActive(false);

        health = totalHealth;

        aroundTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.transform.localScale = new Vector3(2 * health / totalHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);

        if (health <= 0)
        {
            System.Random drop = new System.Random();
            int chance = drop.Next(100);

            if (dropPercent > chance)
            {
                Instantiate(HealthPickUp, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
            }
            Destroy(gameObject);
        }

        if (aroundTime > 0)
        {
            direction = new Vector3(gameObject.transform.position.y - player.position.y, player.position.x - gameObject.transform.position.x, 0);
            aroundTime -= Time.deltaTime;
        }
        else
        {
            direction = new Vector3(player.position.x - gameObject.transform.position.x, player.position.y - gameObject.transform.position.y, 0);
        }
        
        direction.Normalize();

        transform.rotation = Quaternion.Euler(0, 0, 0);

        transform.Translate(direction * Time.deltaTime * speed);

        PublicFunctions.PhaseThruTag(gameObject, new string[] { "Enemy", "Danger" });
    }

    void OnCollisionEnter2D(Collision2D wall)
    {
        if (wall.gameObject.CompareTag("Scenery"))
        {
            aroundTime++;
        }
    }

    public void EnemyDamage(int damage)
    {
        if (!healthBar.activeSelf)
        {
            healthBar.SetActive(true);
        }

        health -= damage;
    }
}
