using System.Collections;
using UnityEngine;

//FUCKING FIX IT
public class TunguskaAAGuns : aArmament
{
    // Use this for initialization
    void Start()
    {
        damage = 100;
        velocity = 10;
        timeToLive = 10;
        creationTime = Time.time;
        mesh.transform.rotation = angle;
        mesh.transform.position = origin;
    }

    // Update is called once per frame
    void Update()
    {
        //FUCKING FIX IT
        Vector3 rofl = mesh.transform.position * velocity * Time.deltaTime;
        mesh.transform.position += transform.forward * Time.deltaTime * velocity;
        if (Time.time - creationTime > timeToLive) Destroy(this);
    }
}