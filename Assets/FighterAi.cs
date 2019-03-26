using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterAi : MonoBehaviour
{

    public GameObject spawn;
    public GameObject target;

    public float speed;

    public GameObject[] waypoints;
    public int waypointIndex;

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
        StartCoroutine("FSM");
    }

    // Update is called once per frame
    void Update()
    {
        IEnumerator FSM()
        {
            switch(state)
            {
                case State.SEEK:
                    Seek();
                    break;

                case State.ATTACK:
                    Attack();
                    break;

                case State.REFUEL:
                    Refuel();
                    break;

            }

            yield return null;
        }
    }

    void Seek()
    {
        //Fighter is going to wander to find a base
        //if(Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position <= 2))
        // {

        // }

        target = waypoints[0];
        float dist = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(spawn.transform.position, target.transform.position, speed);



    }

    void Attack()
    {

    }

    void Refuel()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        //If you collide with an enemy base start attacking
        if(col.tag == "Enemy")
        {
            state = FighterAi.State.ATTACK;
        }
    }
}
