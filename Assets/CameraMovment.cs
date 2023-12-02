using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    public float dumping = 1f;
    public Vector2 offset = new Vector2(0f, 0f);
    public bool isLeft;

    private Transform player;
    private int lastX;


    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x),offset.y);
        FindPlayer(isLeft);
    }

    public void FindPlayer(bool playerIsLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);

        if(playerIsLeft)
            transform.position = new Vector3(player.position.x - offset.x, player.position.y - offset.y, transform.position.z);
       
        else 
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
    }


    [SerializeField]
    float leftLimit;

    [SerializeField]
    float rightLimit;

    [SerializeField]
    float bottomLimit;

    [SerializeField]
    float upperLimit;
    
    void Update()
    {
        if (player)
        {


            int currentX = Mathf.RoundToInt(player.position.x);
            if (currentX > lastX)
                isLeft = false;
            else if (currentX < lastX)
                isLeft = true;

            lastX = Mathf.RoundToInt(player.position.x);

            Vector3 target;
            if (isLeft)
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            else
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping);
            transform.position = currentPosition;
        }

        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
            transform.position.z
            );
    }
}