using System.Collections;
using UnityEngine;

//FUCKING FIX IT
public class CannonProjectile : aArmament
{
    // Use this for initialization
    void Start()
    {
        damage = 100;
        velocity = 75;
        timeToLive = 5;
        creationTime = Time.time;
        transform.Rotate(0, Random.Range(-1,2), 90);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.up * Time.deltaTime * velocity;
        if (Time.time - creationTime > timeToLive) Destroy(this);
    }
}