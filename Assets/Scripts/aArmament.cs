using UnityEngine;

public abstract class aArmament : MonoBehaviour
{
    protected float creationTime;
    protected float timeToLive;
    protected int velocity;
    protected int damage;
    //FUCKING FIX IT
    protected MeshRenderer mesh;
    protected Vector3 origin;
    protected Quaternion angle;

    public MeshRenderer Mesh { set { mesh = value; } }
    public Vector3 Origin { set { origin = value; } }
    public Quaternion Angle { set { angle = value; } }
}