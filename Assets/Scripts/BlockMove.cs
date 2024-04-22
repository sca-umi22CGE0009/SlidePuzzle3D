using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    GameObject objAlpha;
    //[SerializeField, Header("左")] private GameObject left;
    [SerializeField,Header("Rayの長さ")] private float length = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        objAlpha = GameObject.FindWithTag("Alpha");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = objAlpha.transform.position;
        Vector3 start = new Vector3(pos.x, pos.y, pos.z);

        Vector3 aDir = new Vector3(-length, 0, 0);
        Vector3 dDir = new Vector3(length, 0, 0);

        Ray rayLeft = new Ray(start, aDir);
        Ray rayRight = new Ray(start, dDir);

        if (Input.GetMouseButtonDown(0))
        {
            Ray mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mousePosition, out RaycastHit hitInfo))
            {
                if (Physics.Raycast(rayLeft, out RaycastHit hitLeft))
                {
                    if (hitLeft.collider.CompareTag("Block"))
                    {
                        GameObject hit = hitLeft.collider.gameObject;
                        //オブジェクト座標交換
                        Vector3 leftPos = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);
                        hit.transform.position = objAlpha.transform.position;
                        objAlpha.transform.position = leftPos;
                    }
                }
            }
        }
        Debug.DrawRay(rayLeft.origin, rayLeft.direction * length, UnityEngine.Color.green);
    }
    void BlockJudge()
    {

    }
    void RayJudge()
    {
        Vector3 pos = objAlpha.transform.position;
        Vector3 start = new Vector3(pos.x, pos.y, pos.z);
        //rayの方向
        Vector3 aDir = new Vector3(length, 0, 0);
        Vector3 dDir = new Vector3(-length, 0, 0);
        Vector3 wDir = new Vector3(0, length, 0);
        Vector3 sDir = new Vector3(0, -length, 0);

        Ray Rayleft = new Ray(pos, aDir);
        Ray d = new Ray(start, dDir);
        //Ray w = new Ray(start, wDir);
        //Ray s = new Ray(start, sDir);

        if (Physics.Raycast(Rayleft, out RaycastHit leftHit))
        {
            GameObject leftObj = leftHit.collider.gameObject;
            //オブジェクト座標交換
            Vector3 leftPos = new Vector3(leftObj.transform.position.x, leftObj.transform.position.y, leftObj.transform.position.z);
            leftObj.transform.position = objAlpha.transform.position;
            objAlpha.transform.position = leftPos;
        }
        //if (Physics.Raycast(d, out RaycastHit dhitInfo))
        //{
        //    GameObject dObj = dhitInfo.collider.gameObject;
        //    //オブジェクト座標交換
        //    Vector3 dPos = new Vector3(dObj.transform.position.x, dObj.transform.position.y, dObj.transform.position.z);
        //    dObj.transform.position = objAlpha.transform.position;
        //    objAlpha.transform.position = dPos;
        //}
        //if (Physics.Raycast(w, out RaycastHit whitInfo))
        //{

        //}
        //if (Physics.Raycast(s, out RaycastHit shitInfo))
        //{
        //}
    }
}
