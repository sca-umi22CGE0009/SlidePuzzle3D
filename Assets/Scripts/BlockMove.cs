using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    GameObject objAlpha;
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
        //rayの方向
        Vector3 aDir = new Vector3(-length, 0, 0);
        Vector3 dDir = new Vector3(-length, 0, 0);
        Vector3 wDir = new Vector3(0, length, 0);
        Vector3 sDir = new Vector3(0, -length, 0);

        Ray a = new Ray(start, aDir);
        Ray d = new Ray(start, dDir);
        Ray w = new Ray(start, wDir);
        Ray s = new Ray(start, sDir);

        if (Input.GetMouseButtonDown(0))
        {
            Ray mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mousePosition, out RaycastHit hitInfo))
            {
                if (Physics.Raycast(a, out RaycastHit ahitInfo))
                {
                    if (hitInfo.collider.CompareTag("Block") && ahitInfo.collider.CompareTag("Block"))
                    {
                        GameObject aObj = ahitInfo.collider.gameObject;
                        //オブジェクト座標交換
                        Vector3 aPos = new Vector3(aObj.transform.position.x, aObj.transform.position.y, aObj.transform.position.z);
                        aObj.transform.position = objAlpha.transform.position;
                        objAlpha.transform.position = aPos;
                    }
                }
            }
        }
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

        Ray a = new Ray(start, aDir);
        Ray d = new Ray(start, dDir);
        Ray w = new Ray(start, wDir);
        Ray s = new Ray(start, sDir);

        if (Physics.Raycast(d, out RaycastHit dhitInfo))
        {
            GameObject dObj = dhitInfo.collider.gameObject;
            //オブジェクト座標交換
            Vector3 dPos = new Vector3(dObj.transform.position.x, dObj.transform.position.y, dObj.transform.position.z);
            dObj.transform.position = objAlpha.transform.position;
            objAlpha.transform.position = dPos;
        }
        if (Physics.Raycast(w, out RaycastHit whitInfo))
        {
        }
        if (Physics.Raycast(s, out RaycastHit shitInfo))
        {
        }
    }
}
