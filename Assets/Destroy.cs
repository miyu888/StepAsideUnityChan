using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    //unityちゃん
    GameObject unitychan;
    float deadLine = -10f;
    // Start is called before the first frame update
    void Start()
    {
        unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        float Line = unitychan.transform.position.z + deadLine;
        //Z座標を超えたら破棄
        if (transform.position.z < Line)
        {
            Destroy(gameObject);
        }

    }
}