using UnityEngine;

public abstract class LandBehaviour : MonoBehaviour
{
    protected Vector3 startPos;
    protected float rotationSpeed;

    protected abstract void Deploy();
}