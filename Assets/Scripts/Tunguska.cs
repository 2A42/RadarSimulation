using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunguska : LandBehaviour
{
    [SerializeField] private MeshRenderer AAGunsBulletMesh;

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
        intervalBetweenShots = 2f;
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
        Debug.DrawLine(transform.position, TargetPos);
    }

    protected override void Deploy()
    {
        if (radar.getAzimuth() != 0 && radar.getPlaceAngle() != 0)
        {
            float phiAngle = radar.getAzimuth() * 180 / Mathf.PI - 90; 
            float psiAngle = radar.getPlaceAngle() * 180 / Mathf.PI - 30;
            
            //Smooth rotation
            turretModel.transform.rotation = Quaternion.Slerp(turretModel.transform.rotation, Quaternion.Euler(turretModel.transform.rotation.eulerAngles.x, 0, -phiAngle), rotationSpeed * Time.deltaTime);
            gunsModel.transform.rotation = Quaternion.Slerp(gunsModel.transform.rotation, Quaternion.Euler(-psiAngle, gunsModel.transform.rotation.eulerAngles.y, 0), rotationSpeed * Time.deltaTime);
        }
        if (TunguskaRadar.isHit)
        {
            TargetPos = radar.getTargetPosition();
            TunguskaRadar.isHit = false;

            //FUCKING FIX IT
            if (Time.time - timeOfTheLastShot > intervalBetweenShots)
            {
                TunguskaAAGuns guns = gameObject.AddComponent<TunguskaAAGuns>();
                guns.Mesh = AAGunsBulletMesh;
                guns.Origin = transform.position;
                guns.Angle = gunsModel.transform.rotation;
            }
        }
        radarModel.transform.Rotate(0, 300f * Time.deltaTime, 0);
    }
}