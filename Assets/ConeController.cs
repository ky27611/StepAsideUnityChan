using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeController : MonoBehaviour
{
    private GameObject unitychan;
    private float invisiblePosz = 6.5f;
    private float distance = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        //unityちゃんとの距離がinvisiblePoszより大きくなったらオブジェクト消去
        this.distance = unitychan.transform.position.z - this.transform.position.z;

        if (distance >= invisiblePosz)
        {
            Destroy(this.gameObject);
        }
    }
}
