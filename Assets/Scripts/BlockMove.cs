using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    GameObject objAlpha;
    //[SerializeField, Header("左")] private GameObject left;
    [SerializeField,Header("Rayの長さ")] private float length = 2.5f;

    void Start()
    {
        objAlpha = GameObject.FindWithTag("Alpha");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = objAlpha.transform.position;
        Vector3 start = new Vector3(pos.x, pos.y, pos.z);

        Vector3 lDir = new Vector3(-length, 0, 0);
        Vector3 rDir = new Vector3(length, 0, 0);

        Ray rayLeft = new Ray(start, lDir);
        Ray rayRight = new Ray(start, rDir);

        //マウスの判定
        if (Input.GetMouseButtonDown(0))
        {
            Ray mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mousePosition, out RaycastHit hitInfo))
            {
                        RayJudge();
            }
        }
#if true
        Debug.DrawRay(rayLeft.origin, rayLeft.direction * length, UnityEngine.Color.green);
        Debug.DrawRay(rayRight.origin, rayRight.direction * length, UnityEngine.Color.red);
#else
        Debug.DrawRay(rayLeft.origin, rayLeft.direction * length, UnityEngine.Color.blue);
        Debug.DrawRay(rayLeft.origin, rayLeft.direction * length, UnityEngine.Color.yellow);
#endif
    }
    void BlockJudge()
    {

    }
    void RayJudge()
    {
        Vector3 pos = objAlpha.transform.position;
        Vector3 start = new Vector3(pos.x, pos.y, pos.z);
        //rayの方向
        Vector3 lDir = new Vector3(length, 0, 0);
        Vector3 rDir = new Vector3(-length, 0, 0);
        Vector3 uDir = new Vector3(0, length, 0);
        Vector3 dDir = new Vector3(0, -length, 0);

        Ray rayLeft = new Ray(pos, lDir);
        Ray rayRight = new Ray(start, rDir);
        //Ray rayUp = new Ray(start, uDir);
        //Ray rayDown = new Ray(start, dDir);

        if (Physics.Raycast(rayLeft, out RaycastHit hitL))
        {
            if (hitL.collider.CompareTag("Block"))
            {
                GameObject objL = hitL.collider.gameObject;
                //オブジェクト座標交換
                Vector3 PosL = new Vector3(objL.transform.position.x, objL.transform.position.y, objL.transform.position.z);
                objL.transform.position = objAlpha.transform.position;
                objAlpha.transform.position = PosL;
            }
        }

        if (Physics.Raycast(rayRight, out RaycastHit hitR))
        {
            if (hitR.collider.CompareTag("Block"))
            {
                GameObject objR = hitR.collider.gameObject;
                //オブジェクト座標交換
                Vector3 posR = new Vector3(objR.transform.position.x, objR.transform.position.y, objR.transform.position.z);
                objR.transform.position = objAlpha.transform.position;
                objAlpha.transform.position = posR;
            }
        }
        //if (Physics.Raycast(w, out RaycastHit whitInfo))
        //{

        //}
        //if (Physics.Raycast(s, out RaycastHit shitInfo))
        //{
        //}
    }

}
