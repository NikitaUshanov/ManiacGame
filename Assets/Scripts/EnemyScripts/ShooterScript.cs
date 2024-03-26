using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public GameObject bullet;
    public Rigidbody2D myRigidbody;
    public float verticalSpeed;
    public float horizontalSpeed;
    public float spawnRate;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBullet();
        ChangeVelocity();
    }


    void SpawnBullet()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }

    void ChangeVelocity()
    {
        if (Input.GetKey(KeyCode.W))
        {
            myRigidbody.velocity += Vector2.up * verticalSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.velocity += Vector2.right * horizontalSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.velocity += Vector2.left * horizontalSpeed * Time.deltaTime;
        }
    }
}
