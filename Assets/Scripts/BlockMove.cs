using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    GameObject objAlpha;
    GameObject clickObj;

    bool isHit = false;
    bool blockHit = false;
    // Start is called before the first frame update
    void Start()
    {
        objAlpha = GameObject.FindWithTag("Alpha");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mousePosition, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.CompareTag("Block")||hitInfo.collider.CompareTag("Alpha"))
                {
                    clickObj = hitInfo.collider.gameObject;
                    //オブジェクト座標交換
                    Vector3 pos = new Vector3(clickObj.transform.position.x, clickObj.transform.position.y, clickObj.transform.position.z);
                    clickObj.transform.position = objAlpha.transform.position;
                    objAlpha.transform.position = pos;
                }
            }
        }
    }
}
