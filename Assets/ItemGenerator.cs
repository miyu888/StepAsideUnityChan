using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabをいれる
    public GameObject coinPrefab;
    //cornPrefabをいれる
    public GameObject conePrefab;
    //次にこの場所にunitychanが到着したらアイテムを生成する地点
    private int nextItemGenerationPos = 80;
    //ゴール地点
    private int goalPos = 360;

    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //Unitychanのいる場所の何m前方にアイテムを生成するかという距離
    private int itemGenerationDistance = 50;
    //アイテムを生成する間隔
    private int itemGenerationInterval = 15;
    //Unitychan.の参照を入れる
    GameObject unitychan;


    // Start is called before the first frame update
    void Start()
    {
        unitychan = GameObject.Find("unitychan");

    }


    public void Generate()
    {
       int i = nextItemGenerationPos;
        

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
                    for (int j = -1; j <= 1; j++)
                    {
                        //アイテムの種類を決める
                        int item = Random.Range(1, 11);
                        //アイテムをz座標のオフセットをランダムに設定
                        int offsetZ = Random.Range(-5, 6);
                        //60%コイン配置：30%車配置：10%何もなし
                        if (1 <= item && item <= 6)
                        {
                            //コインを作成
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

    // Update is called once per frame
    void Update()
    {
        //itemGenerationPositionZは「アイテムを生成するz座標」
        float itemGenerationPositionZ = unitychan.transform.position.z + itemGenerationDistance;
        //float f = unitychan.transform.position.z;

        //一定の距離ごとにログを出す
        if (unitychan.transform.position.z > nextItemGenerationPos && itemGenerationPositionZ < goalPos)
        {
            Debug.LogFormat("unitychanのZ座標:{0},アイテムを生成したいZ座標{1}", unitychan.transform.position.z, itemGenerationPositionZ);
            //アイテムを生成したら、次に生成するポイントに更新する
            nextItemGenerationPos += itemGenerationInterval;

            Generate();

        }
    }
}
