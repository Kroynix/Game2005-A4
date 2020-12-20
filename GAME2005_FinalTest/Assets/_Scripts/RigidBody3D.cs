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
                    if(this.name != "Player" && this.transform.position.y <= 1.5 &&
                        this.transform.position.x > -34.172 && this.transform.position.x < 34.172 &&
                        this.transform.position.z > -32.61 && this.transform.position.z < 32.61)
                    {
                        velocity.y = 0;
                    }
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

    public void addForceleftBullet()
    {
        if (this.gameObject.tag != "Player")
        {
            transform.position += Vector3.left;
            Debug.Log(transform.position);
        }
    }
    public void addForcerightBullet()
    {
        if (this.gameObject.tag != "Player")
        {
            transform.position += Vector3.right;
            Debug.Log(transform.position);
        }
    }
    public void addForceforwardBullet()
    {
        if (this.gameObject.tag != "Player")
        {
            transform.position += Vector3.forward;
            Debug.Log(transform.position);
        }
    }
    public void addForcebackwardBullet()
    {
        if (this.gameObject.tag != "Player")
        {
            transform.position += Vector3.back;
            Debug.Log(transform.position);
        }
    }



    public void addForceleftBody()
    {
        if (this.gameObject.tag != "Player")
        {
            transform.position += Vector3.left * 0.05f;
            Debug.Log(transform.position);
        }
    }
    public void addForcerightBody()
    {
        if (this.gameObject.tag != "Player")
        {
            transform.position += Vector3.right * 0.05f;
            Debug.Log(transform.position);
        }
    }
    public void addForceforwardBody()
    {
        if (this.gameObject.tag != "Player")
        {
            transform.position += Vector3.forward * 0.05f;
            Debug.Log(transform.position);
        }
    }
    public void addForcebackwardBody()
    {
        if (this.gameObject.tag != "Player")
        {
            transform.position += Vector3.back * 0.05f;
            Debug.Log(transform.position);
        }
    }

    public void AddForce(string Direction)
    {
        if (Direction == "Left")
        {
            transform.position += Vector3.left * 0.1f;
        }
        else if (Direction == "Right")
        {
            transform.position += Vector3.right * 0.1f;
        }
        else if (Direction == "forward")
        {
            transform.position += Vector3.forward * 0.1f;
        }
        else if (Direction == "back")
        {
            transform.position += Vector3.back * 0.1f;
        }
    }




}
