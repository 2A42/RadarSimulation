using System.Collections.Generic;
using UnityEngine;

public class TunguskaRadar : Radar
{
    public static Vector3 tempExactPosOfTarget; //

    // Start is called before the first frame update
    void Start()
    {
        timeOfTheLastRadioWave = 0;
        intervalBetweenRadioWaves = 2f;
        radioWaves = new Queue<RadioWaveBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeOfTheLastRadioWave > intervalBetweenRadioWaves) createRadioWave();
    }

    protected override void createRadioWave()
    {
        timeOfTheLastRadioWave = Time.time;
        RadioWaveBehaviour radioWave = gameObject.AddComponent<RadioWaveBehaviour>();
        radioWave.Origin = transform.position;
        radioWave.Direction = transform.up;
        radioWaves.Enqueue(radioWave);
    }

    public override Vector3 getTargetPosition()
    {
        Azimuth = radioWaves.Peek().Azimuth;
        placeAngle = radioWaves.Peek().placeAngle;
        timeAfterGettingSignal = (Time.time - radioWaves.Peek().birthdateOfRadioWave) / 2;
        Radius = timeAfterGettingSignal * radioWaves.Peek().Speed + radioWaves.Peek().Speed * Time.deltaTime;
        float Projection = Radius * Mathf.Cos(placeAngle);
        float X = Projection * Mathf.Cos(Azimuth);
        float Y = Radius * Mathf.Sin(placeAngle);
        float Z = Projection * Mathf.Sin(Azimuth);

        Vector3 Pos = new Vector3(X, Y, Z);
        radioWaves.Dequeue();
        return Pos;
        //else return Vector3.zero;
    }

    public override float getAzimuth()
    {
        return Azimuth;
    }

    public override float getPlaceAngle()
    {
        return placeAngle;
    }
}