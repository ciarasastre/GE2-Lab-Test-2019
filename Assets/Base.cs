using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Base : MonoBehaviour
{
    public float tiberium = 0;
    //public float time = 1000;

    //public TextMeshPro text;

    public GameObject fighterPrefab;
    public GameObject Spawn;
    //public GameObject fighter;


    // Start is called before the first frame update
    void Start()
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material.color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);
        }

        //While application is still running
        StartCoroutine(TiberiumBase());

    }

    // Update is called once per frame
    void Update()
    {
        //text.text = "" + tiberium; Not working yet as i am trying to figure out text first

        //For every second that passes add 5 units of tiberium
        //StartCoroutine(TiberiumBase());

        //Check if the unit == 10 then spawn a fighter ship
        if(tiberium == 10)
        {
            Instantiate(fighterPrefab, Spawn.transform.position, Quaternion.identity);
            tiberium = tiberium - 10;
            
        }
    }

    IEnumerator TiberiumBase()
    {
        yield return new WaitForSeconds(2);
        //tiberium = tiberium + 5;

        tiberium = 10;
    }
}
