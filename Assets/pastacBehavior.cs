using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.XR.Interaction.Toolkit.InputHelpers;



public class pastacBehavior : MonoBehaviour
{
    public GameObject pasteque2;
    public FruitSpawner fruitSpawner;
    public AudioSource hitAudio;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        detruitFruit();
    }
    private void detruitFruit()
    {
        // if (OVRInput.Get(OVRInput.Button.One))
        // {
        //     transform.DetachChildren();
        //     pasteque2.transform.AddComponent<Rigidbody>();
        // }
    }
    private void OnMouseDown()
    {
        transform.DetachChildren();
        pasteque2.transform.AddComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Sword")
        {
            transform.DetachChildren();
            pasteque2.transform.AddComponent<Rigidbody>();
            hitAudio.Play();
            if (this.gameObject.transform.childCount == 0)
            {
                fruitSpawner.val++;
            }

        }
    }

}