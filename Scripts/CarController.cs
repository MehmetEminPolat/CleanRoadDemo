using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject player;

    float carSpeed = 30f;
    public float epsilon = 10f;
    public float range = 15f;
    private float sqrDistance;



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }


    private void Update()
    {
        sqrDistance = (player.transform.position - transform.position).sqrMagnitude;
        if (sqrDistance < range * range)
        {

            Quaternion currentRotation = transform.rotation;
            Vector3 direction = player.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction, player.transform.up);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, 0.3f);
            if ((transform.position - player.transform.position).magnitude > epsilon)
            {
                transform.Translate(0f, 0f, carSpeed * Time.deltaTime);
            }

        }


    }

}
