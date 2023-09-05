using System.Collections.Generic;
using UnityEngine;

public abstract class Radar : MonoBehaviour
{
    public static bool isHit;

    protected Queue<RadioWaveBehaviour> radioWaves;
    protected float intervalBetweenRadioWaves;
    protected float timeOfTheLastRadioWave;
    protected float timeAfterGettingSignal;
    protected float Radius;
    protected float Azimuth;
    protected float placeAngle;

    protected abstract void createRadioWave();

    public abstract float getAzimuth();
    public abstract float getPlaceAngle();
    public abstract Vector3 getTargetPosition();
}
