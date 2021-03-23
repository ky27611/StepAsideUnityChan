using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleterController : MonoBehaviour
{
    private GameObject unitychan;
    private Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, unitychan.transform.position.z - 6.5f);   
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }



}
