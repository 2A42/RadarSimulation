using UnityEngine;

public class MQ9 : AirBehaviour
{
    protected override void Move()
    {
        speed = Random.Range(-50, -5);
        if (transform.position.y > 15)
        {
            transform.Rotate(0, 0, rotationSpeed);
            transform.Rotate(Random.Range(-2, 2) * rotationSpeed, 0, 0);
        }
        else
        {
            transform.Rotate(0, 0, -rotationSpeed);
            transform.Rotate(-rotationSpeed * 2, 0, 0);
        }
        transform.position += transform.up * Time.deltaTime * speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 0.1f;
        startPos = new Vector3(Random.Range(-50, 50), Random.Range(1, 50), Random.Range(-50, 50));
        transform.position = startPos;
        transform.Rotate(-90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}