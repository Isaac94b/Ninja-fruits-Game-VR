using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrangeBehavior : MonoBehaviour
{
    public GameObject orange;
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
        //     ananas.transform.AddComponent<Rigidbody>();
        // }
    }
    private void OnMouseDown()
    {
        transform.DetachChildren();
        orange.transform.AddComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Sword")
        {
            transform.DetachChildren();
            orange.transform.AddComponent<Rigidbody>();
            hitAudio.Play();
            if (this.gameObject.transform.childCount == 0)
            {
                fruitSpawner.val++;
            }

        }

    }
}
