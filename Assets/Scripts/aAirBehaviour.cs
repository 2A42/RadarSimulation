using UnityEngine;

public abstract class AirBehaviour : MonoBehaviour
{
    protected Vector3 startPos;
    protected float speed;
    protected float rotationSpeed;

    protected abstract void Move();
}
