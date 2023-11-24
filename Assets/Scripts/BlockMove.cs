using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ブロックがalphaだったら座標を入れ替える
        if (Input.GetMouseButtonDown(0))
        {
            Ray mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mousePosition, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.CompareTag("Block")||hitInfo.collider.CompareTag("Alpha"))
                {
                    Debug.Log("当たった");
                }
            }
        }
    }
    
}
