using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //Prefabを入れる
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;
    //スタート地点
    public float startPos = 80f;
    //ゴール地点
    private float goalPos = 360f;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    private GameObject unitychan;
    private float createPos;
    private float createRange = 15f;
    private float createdistance;
    bool createswitch;

    // Start is called before the first frame update
    void Start()
    {
        /*
        //一定の距離ごとにアイテムを生成
        for (int i = startPos; i < goalPos; i+=15)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for(int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くz座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置：30%車配置：10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }
        }
        */

        this.unitychan = GameObject.Find("unitychan");
        createswitch = true;
        createPos = startPos;
       
    }

    // Update is called once per frame
    void Update()
    {

        //生成点とユニティちゃんとの距離が一定以下になったらアイテム生成して次の生成点を更新
        createdistance = createPos - unitychan.transform.position.z;

        if (createdistance <= 55f && createswitch == true)
        {
            createItem();

            createPos += createRange;

            //ゴール地点から先には生成しない
            if(createPos > goalPos)
            {
                createPos = goalPos;
                createswitch = false;
            }

        }

    }

    void createItem()
    {
        //どのアイテムを出すのかをランダムに設定
        int num = Random.Range(1, 11);
        if (num <= 2)
        {
            //コーンをx軸方向に一直線に生成
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate(conePrefab);
                cone.transform.position = new Vector3(4 * j, cone.transform.position.y, createPos);
            }
        }
        else
        {
            //レーンごとにアイテムを生成
            for (int j = -1; j <= 1; j++)
            {
                //アイテムの種類を決める
                int item = Random.Range(1, 11);
                //アイテムを置くz座標のオフセットをランダムに設定
                int offsetZ = Random.Range(-5, 6);
                //60%コイン配置：30%車配置：10%何もなし
                if (1 <= item && item <= 6)
                {
                    //コインを生成
                    GameObject coin = Instantiate(coinPrefab);
                    coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, createPos + offsetZ);
                }
                else if (7 <= item && item <= 9)
                {
                    //車を生成
                    GameObject car = Instantiate(carPrefab);
                    car.transform.position = new Vector3(posRange * j, car.transform.position.y, createPos + offsetZ);
                }
            }
        }
    }

}
