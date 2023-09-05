using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunguska : LandBehaviour
{
    private GameObject turretModel;
    private GameObject gunsModel;
    private GameObject radarModel;
    private Vector3 TargetPos;

    private TunguskaRadar radar;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 2.5f;
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
}