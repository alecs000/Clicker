using UnityEngine;

public class Snail : Enemy, IMovalible
{
    Vector3 minPos;
    Vector3 maxPos;
    bool rotateInLastFrame = false;
    private void Awake()
    {
        minPos = Border.minPos;
        maxPos = Border.maxPos;
    }
    void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        if (rotateInLastFrame)
        {
            rotateInLastFrame = false;
            return;
        }
        if (transform.position.x > maxPos.x || transform.position.x < minPos.x)
        {
            transform.eulerAngles = new Vector3(0, -transform.eulerAngles.y, 0);
            rotateInLastFrame = true;
        }
        else if (transform.position.z < minPos.z || transform.position.z > maxPos.z)
        {
            transform.eulerAngles = new Vector3(0, 180 - transform.eulerAngles.y, 0);
            rotateInLastFrame = true;
        }
    }
}
