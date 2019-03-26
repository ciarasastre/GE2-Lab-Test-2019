using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterAi : MonoBehaviour
{

    public GameObject spawn;
    public GameObject target;
    public GameObject enemy;

    public Vector3 Destination;

    public float speed = 10f;

    public GameObject[] waypoints;
    public int waypointIndex = 0;
    

    //Fighter will have 7 tiberium
    public float tiberium = 7;

    public enum State
    {
        SEEK,
        ATTACK,
        REFUEL
    }

    public State state;

    // Start is called before the first frame update
    void Start()
    {
        state = FighterAi.State.SEEK;
        StartCoroutine(FSM());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator FSM()
    {
        switch (state)
        {
            case FighterAi.State.SEEK:
                Seek();
                break;

            case FighterAi.State.ATTACK:
                Attack();
                break;

            case FighterAi.State.REFUEL:
                Refuel();
                break;

        }

        yield return null;
    }

    void Seek()
    {
        //Fighter is going to wander to find a base
        if (Vector3.Distance(enemy.transform.position, waypoints[waypointIndex].transform.position) <= 2)
        {
            //Get destination
            Destination = waypoints[waypointIndex].transform.position;

            //Now move there
            float dist = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(spawn.transform.position, Destination, speed);

        }
        else if (Vector3.Distance(enemy.transform.position, waypoints[waypointIndex].transform.position) >= 2)
        {

            waypointIndex += 1;

            if (waypointIndex <= 4)
            {
                waypointIndex = 0;
            }

        }
    }


    void Attack()
    {
        //If you are in the Attack state then spawn bullets and direct them towards the base

        //Your bullets will decrease your tiberium eah round

        //The base will take damadge
    }

    void Refuel()
    {
        //Return back to the base to refuel your tiberium
    }

    private void OnTriggerEnter(Collider col)
    {
        //If you collide with an enemy base start attacking
        if(col.tag == "Finish")
        {
            state = FighterAi.State.ATTACK;
        }
    }
}
