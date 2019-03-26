using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

public class Seek : SteeringBehaviour
{
    public GameObject targetGameObject = null;
    public Vector3 target = Vector3.zero;

    public GameObject bulletPrefab;
    public GameObject bulletSpawn;

    //Fighter will have 7 tiberium
    public float tiberium = 7;

    public void OnDrawGizmos()
    {
        if (isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.cyan;
            if (targetGameObject != null)
            {
                target = targetGameObject.transform.position;
            }
            Gizmos.DrawLine(transform.position, target);
        }
    }
    
    public override Vector3 Calculate()
    {
        return boid.SeekForce(target);    
    }

    public void Update()
    {
        if (targetGameObject != null)
        {
            target = targetGameObject.transform.position;
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Finish")
        {
            //Go idle
            Debug.Log("Collided");
            transform.position = Vector3.zero;

            Attack();
        }
    }

    public void Attack()
    {
        //Spawn bullets
       /* while (tiberium != 0) //So you havent run out
        {
            StartCoroutine(Shoot());
        }

        if(tiberium == 0)
        {
            Refuel();
        }*/
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(2);
        Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.identity);
        tiberium -= 1;
    }

    public void Refuel()
    {

    }
}