using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyType
{
    STATIC,
    DYNAMIC
}


[System.Serializable]
public class RigidBody3D : MonoBehaviour
{
    [Header("Gravity Simulation")]
    public float gravityScale;
    public float mass;
    public BodyType bodyType;
    public float timer;
    public bool isFalling;

    [Header("Attributes")]
    public Vector3 velocity;
    public Vector3 velocityleft;
    public Vector3 velocityright;
    public Vector3 velocityforward;
    public Vector3 velocitybackward;
    public Vector3 acceleration;
    private float gravity;
    public Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        gravity = -0.001f;
        velocity = Vector3.zero;
        acceleration = new Vector3(0.0f, gravity * gravityScale, 0.0f);
        if (bodyType == BodyType.DYNAMIC)
        {
            isFalling = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bodyType == BodyType.DYNAMIC)
        {
            if (isFalling)
            {
                timer += Time.deltaTime;
                
                if (gravityScale < 0)
                {
                    gravityScale = 0;
                }

                if (gravityScale > 0)
                {
                    velocity += acceleration * 0.5f * timer * timer;
                    transform.position += velocity;
                }
            }
        }
    }

    public void Stop()
    {
        timer = 0;
        isFalling = false;
    }

    public void addForceleft()
    {
        if (this.gameObject.tag != "Player")
        {
            transform.position += Vector3.left;
            Debug.Log(transform.position);
        }
    }
    public void addForceright()
    {
        if (this.gameObject.tag != "Player")
        {
            transform.position += Vector3.right;
            Debug.Log(transform.position);
        }
    }
    public void addForceforward()
    {
        if (this.gameObject.tag != "Player")
        {
            transform.position += Vector3.forward;
            Debug.Log(transform.position);
        }
    }
    public void addForcebackward()
    {
        if (this.gameObject.tag != "Player")
        {
            transform.position += Vector3.back;
            Debug.Log(transform.position);
        }
    }

}
