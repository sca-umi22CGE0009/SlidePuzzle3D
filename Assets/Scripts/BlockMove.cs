using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class BlockMove : MonoBehaviour
{
    GameObject objAlpha;
    GameObject objClick;

    [SerializeField,Header("Ray�̒���")] private float length = 2.5f;

    void Start()
    {
        objAlpha = GameObject.FindWithTag("Alpha");
    }

    void Update()
    {
        //�}�E�X�̔���
        if (Input.GetMouseButtonDown(0))
        {
            Ray mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mousePosition, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.CompareTag("Block"))
                {
                    //�I�񂾃I�u�W�F�N�g
                    objClick = hitInfo.collider.gameObject;
                    RayJudge();
                }
            }
        }
    }
    //ray���S�����ɐL�΂��Ă���
    void RayJudge()
    {
        //ray�̕���
        Vector3 lDir = new Vector3(length, 0, 0);
        Vector3 rDir = new Vector3(-length, 0, 0);
        Vector3 uDir = new Vector3(0, length, 0);
        Vector3 dDir = new Vector3(0, -length, 0);

        placeChanger(lDir);
        placeChanger(rDir);
        placeChanger(uDir);
        placeChanger(dDir);
    }
    //�����u���b�N�ɓ������Ă��邩�ǂ����̔���
    void placeChanger(Vector3 dir)
    {
        Vector3 pos = objClick.transform.position;
        Vector3 start = new Vector3(pos.x, pos.y, pos.z);

        Ray ray = new Ray(pos, dir);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Alpha"))
            {
                GameObject obj = hit.collider.gameObject;
                Vector3 tmp = obj.transform.position;
                //�I�u�W�F�N�g���W����
                obj.transform.position = objClick.transform.position;
                objClick.transform.position = tmp;
            }
        }
    }
}
