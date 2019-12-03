using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float motorForce, steerForce;
    public WheelCollider frontLeftWheel, frontRightWheel, backLeftWheel, backRightWheel;
    public GameObject trail, door, emoji, snowRight, snowLeft, snow, finishCelebration, fail, sign;
    private bool PlayerInSnow = false;


    private void Start()
    {
        trail.SetActive(false);
    }

    private void Update()
    {
        float v = motorForce;
        float h = Input.GetAxis("Horizontal") * steerForce;

        backLeftWheel.motorTorque = v;
        backRightWheel.motorTorque = v;

        frontLeftWheel.steerAngle = h;
        frontRightWheel.steerAngle = h;


        float randomRotationX = Random.Range(0, 180);
        float randomRotationY = Random.Range(0, 180);
        Vector3 snowGeneratePositonL = new Vector3(snowLeft.transform.position.x, snowLeft.transform.position.y, snowLeft.transform.position.z);
        Vector3 snowGeneratePositonR = new Vector3(snowRight.transform.position.x, snowRight.transform.position.y, snowRight.transform.position.z);

        if (PlayerInSnow)
        {
            Quaternion quaternion = new Quaternion(randomRotationX, randomRotationY, 0f, 0f);
            Instantiate(snow, snowGeneratePositonL, quaternion);
            Instantiate(snow, snowGeneratePositonR, quaternion);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Snow")
        {
            trail.gameObject.SetActive(true);
            PlayerInSnow = true;
        }

        if (other.gameObject.tag == "Finish")
        {
            finishCelebration.gameObject.SetActive(true);
            StartCoroutine(Finish());
        }

        if (other.gameObject.tag == "Door")
        {
            door.gameObject.SetActive(false);
            emoji.gameObject.SetActive(true);
            fail = Instantiate(fail, gameObject.transform.position + new Vector3(4.5f, 55f, 70f), Quaternion.identity);
            sign = Instantiate(sign, gameObject.transform.position + new Vector3(4.5f, 0f, 70f), Quaternion.identity);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Snow")
        {

            trail.gameObject.SetActive(false);
            PlayerInSnow = false;

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fail")
        {
            StartCoroutine(Timer());
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0f;
    }

    private IEnumerator Finish()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
    }


}
