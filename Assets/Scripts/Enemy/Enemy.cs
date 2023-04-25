using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PointToPlayer();
    }

    void Hurt(GameObject gameObject)
    {
        //get damage script 
        //deal damage based on its damage
    }


    void OnCollisionEnter(Collision other)
    {
        string objecttag = other.gameObject.tag;

        if(objecttag.Equals("Damaging"))
        {
            Hurt(other.gameObject);
        }
    }


    private void PointToPlayer()
    {

        Vector3 pos = PlayerMovement.instance.transform.position;
        Vector3 difference =  pos - transform.position;

        float bodyAngle = -Mathf.Rad2Deg * Mathf.Atan2(difference.z, difference.x);

        transform.rotation = Quaternion.AngleAxis(bodyAngle, Vector3.up);
        

    }
}