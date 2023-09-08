using UnityEngine;

public class RadioWaveBehaviour : aRadioWave
{
    public float Azimuth { get { return az * Mathf.PI / 180; } }
    public float placeAngle { get { return pt * Mathf.PI / 180; } }

    private float pt;
    private float az;
    private bool sphereCast;
    private RaycastHit hit;

    void Start()
    {
        dR = 200;
        Radius = 1;
        maxDist = 1400;
        sphereCast = true;
        birthdateOfRadioWave = Time.time;
        layerMask = LayerMask.GetMask("Default");
    }

    void Update()
    {
        Radius += dR * Time.deltaTime;
        if (Radius > maxDist) Destroy(this);
        if (sphereCast && Physics.SphereCast(Origin, Radius, Direction, out hit, maxDist, layerMask)) sphereCast = false;
        if (Physics.CheckSphere(Origin, Radius, layerMask))
        {
            Vector3 point = hit.point;
            pt = 90 - Vector3.Angle(Vector3.up, point);
            point.y = 0;
            az = Vector3.SignedAngle(point, Vector3.right, Vector3.up);

            ReflectedRadioWaveBehaviour reflectedRadioWave = gameObject.AddComponent<ReflectedRadioWaveBehaviour>();
            reflectedRadioWave.Origin = hit.point;
            reflectedRadioWave.Direction = -transform.up;
            reflectedRadioWave.dR = dR;
            reflectedRadioWave.maxDist = maxDist;
            Destroy(this);
        }
        //if (Time.time - temp > dT)
        //{
        //    temp = Time.time;
        //    Radius += dR * Time.deltaTime;
        //}
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(Origin, Radius);
    }
}