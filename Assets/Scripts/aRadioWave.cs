using UnityEngine;

public abstract class aRadioWave : MonoBehaviour
{
    public Vector3 Origin { get; set; }
    public Vector3 Direction { get; set; }
    public float birthdateOfRadioWave { get; set; }
    public float Speed { get { return dR; } }

    protected float dR;
    protected float Radius;
    protected float maxDist;
    protected LayerMask layerMask;
}
