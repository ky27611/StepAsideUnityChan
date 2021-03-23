using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private GameObject unitychan;
    //private Transform myTransform;
    private float invisiblePosz = 6.5f;
    private float distance = 0;

    // Start is called before the first frame update
    void Start()
    {
        //回転を開始する角度を設定
        this.transform.Rotate(0, Random.Range(0, 360), 0);

        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        //回転
        this.transform.Rotate(0, 6, 0);

        //unityちゃんとの距離がinvisiblePoszより大きくなったらオブジェクト消去
        this.distance = unitychan.transform.position.z - this.transform.position.z;

        if (distance >= invisiblePosz)
        {
            Destroy(this.gameObject);
        }
    }
}
