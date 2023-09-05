using UnityEngine;

public class ReflectedRadioWaveBehaviour : RadioWaveBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Radius = 1;
        layerMask = LayerMask.GetMask("Land");
    }

    // Update is called once per frame
    void Update()
    {
        Radius += dR * Time.deltaTime;
        if (Radius > maxDist) Destroy(this);
        if (Physics.CheckSphere(Origin, Radius, layerMask))
        {
            TunguskaRadar.isHit = true;
            TunguskaRadar.tempExactPosOfTarget = Origin; //bruh
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
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(Origin, Radius);
    }
}