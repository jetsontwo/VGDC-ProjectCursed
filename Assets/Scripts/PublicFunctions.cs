﻿using UnityEngine;
using System.Collections;
using System.Linq;

public class PublicFunctions : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PhaseThruFriend(gameObject);
    }

    public static void PhaseThruFriend(GameObject thing)
    {
        GameObject[] friendlies = GameObject.FindGameObjectsWithTag("Friendly");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject col in friendlies)
        {
            Physics2D.IgnoreCollision(thing.GetComponent<Collider2D>(), col.GetComponent<Collider2D>());
        }

        foreach (GameObject col in players)
        {
            Physics2D.IgnoreCollision(thing.GetComponent<Collider2D>(), col.GetComponent<Collider2D>());
        }
    }

    public static void PhaseThruEnemy(GameObject thing)
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] dangers = GameObject.FindGameObjectsWithTag("Danger");

        foreach (GameObject col in enemies)
        {
            Physics2D.IgnoreCollision(thing.GetComponent<Collider2D>(), col.GetComponent<Collider2D>());
        }

        foreach (GameObject col in dangers)
        {
            Physics2D.IgnoreCollision(thing.GetComponent<Collider2D>(), col.GetComponent<Collider2D>());
        }
    }

    public static IEnumerator InstantDrain(float drain)
    {
        EnergyBar.instant = drain;
        yield return new WaitForSeconds(1 / 60);
        EnergyBar.instant = 0;
    }

    public static float WrapSin(float a)
    {
        if (a < 0)
        {
            a += 2 * Mathf.PI;
        }

        return a;
    }

    public static float FindAngle(float x, float y)
    {
        float result = 0;
        
        float[] xlist = { Mathf.Rad2Deg * Mathf.Acos(x), -Mathf.Rad2Deg * Mathf.Acos(x) };
        float[] ylist = { Mathf.Rad2Deg * WrapSin(Mathf.Asin(y)), 180 - (Mathf.Rad2Deg * WrapSin(Mathf.Asin(y))) };

        float[] differences = {Mathf.Abs(xlist[0] - ylist[0]), Mathf.Abs(xlist[0] - ylist[1]),
                               Mathf.Abs(xlist[1] - ylist[0]), Mathf.Abs(xlist[1] - ylist[1])};

        foreach (float a in xlist)
        {
            foreach (float b in ylist)
            {
                if (Mathf.Abs(a - b) == differences.Min())
                {
                    result = a;
                }
            }
        }

        return result;
    }
}
