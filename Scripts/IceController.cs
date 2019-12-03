using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceController : MonoBehaviour
{
    public bool carMoving = true;
    public bool timerStart = false;
    public GameObject fail;
    private void Update()
    {

        float velocity = gameObject.GetComponent<Rigidbody>().velocity.magnitude;

        if (velocity > 2f)
        {
            carMoving = true;
        }
        else
        {
            carMoving = false;
            if (timerStart == false)
            {
                StartCoroutine(Timer());
                timerStart = true;
            }

        }

    }
    private IEnumerator Timer()
    {

        yield return new WaitForSeconds(2f);
        if (carMoving == false)
        {
            
            fail = Instantiate(fail, gameObject.transform.position + new Vector3(0, 50f, 0), Quaternion.identity);
           
        }
        timerStart = false;
    }

    






}
