using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    public GameObject[] pies;
    public GameObject pinObject;
    GameObject[] spwanedPins;
    int _pieCounter = 0;
    bool isTenth = false;
    public ParticleSystem smokePuff;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_pieCounter != 10)
            {
                GameObject obj = Instantiate(pinObject, transform.position, transform.rotation);
                _pieCounter++;
            }
            else
            {
                isTenth = true;
            }

            if (isTenth)
            {
                int index = Random.Range(0, 7);
                Destroy(pies[index]);
                Instantiate(smokePuff, pies[index].transform.position, pies[index].transform.rotation);
                FindObjectOfType<AudioManager>().Play("PopPie");
                ScoreManager.pinCount = 0;
                _pieCounter = 0;
                isTenth = false;
                DestroySpwanedPins();
            }
            
        }
    }

    public void DestroySpwanedPins()
    {
        spwanedPins = GameObject.FindGameObjectsWithTag("Pin");

        foreach (GameObject pin in spwanedPins)
        {
            Destroy(pin);
        }
    }
}
