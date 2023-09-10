using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunguska : LandBehaviour
{
    [SerializeField] private GameObject Projectile;
    [SerializeField] private Transform gunsBarrelLeft;
    [SerializeField] private Transform gunsBarrelRight;

    private Vector3 TargetPos;
    private float timeOfTheLastShot;
    private float intervalBetweenShots;

    private GameObject turretModel;
    private GameObject gunsModel;
    private GameObject radarModel;

    private TunguskaRadar radar;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 2.5f;
        timeOfTheLastShot = 0;
        intervalBetweenShots = 0.025f;
        startPos = transform.position;
        turretModel = GameObject.Find("tunguskaTurret");
        gunsModel = GameObject.Find("tunguskaGuns");
        radarModel = GameObject.Find("tunguskaRadar");

        radar = gameObject.AddComponent<TunguskaRadar>();
    }

    // Update is called once per frame
    void Update()
    {
        Deploy();
        Shoot();
        Debug.DrawLine(transform.position, TargetPos);
    }

    protected override void Deploy()
    {
        if (radar.getAzimuth() != 0 && radar.getPlaceAngle() != 0)
        {
            float phiAngle = radar.getAzimuth() * 180 / Mathf.PI - 90; 
            float psiAngle = radar.getPlaceAngle() * 180 / Mathf.PI - 25;
            
            //Smooth rotation
            turretModel.transform.rotation = Quaternion.Slerp(turretModel.transform.rotation, Quaternion.Euler(turretModel.transform.rotation.eulerAngles.x, 0, -phiAngle), rotationSpeed * Time.deltaTime);
            gunsModel.transform.rotation = Quaternion.Slerp(gunsModel.transform.rotation, Quaternion.Euler(-psiAngle, gunsModel.transform.rotation.eulerAngles.y, 0), rotationSpeed * Time.deltaTime);
        }
        if (TunguskaRadar.isHit)
        {
            TargetPos = radar.getTargetPosition();
            TunguskaRadar.isHit = false;
        }
        radarModel.transform.Rotate(0, 300f * Time.deltaTime, 0);
    }

    private void Shoot()
    {
        if (Time.time - timeOfTheLastShot > intervalBetweenShots)
        {
            timeOfTheLastShot = Time.time;
            Instantiate(Projectile, gunsBarrelLeft.position, gunsBarrelLeft.rotation);
            Instantiate(Projectile, gunsBarrelRight.position, gunsBarrelRight.rotation);
        }
    }
}