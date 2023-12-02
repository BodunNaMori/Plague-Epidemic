using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMovement : MonoBehaviour
{
    public float speed = 0.21f;
    public GameObject sky;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -27.28)
        {
            
            if (transform.position.x < 13.61)
            {
                
                Instantiate(sky, new Vector3(75.8f, 1.62f, 0.07f), Quaternion.identity);
            }

            Destroy(gameObject);
        }
        
    }
}
