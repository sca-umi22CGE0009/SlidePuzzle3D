using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTextMove : MonoBehaviour
{
    [Header("�t�F�[�h�����鎞��")]
    [SerializeField]
    private float fadeTime = 1f;
    private CanvasGroup img;

    private bool check = false;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<CanvasGroup>();
        img.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //0��������1�ɂ���
        if (!check)
        {
            img.alpha += fadeTime * Time.deltaTime;
            if (img.alpha == 1)
            {
                check = true;
            }
        }
        //1��������0�ɂ���
        if (check)
        {
            img.alpha -= fadeTime * Time.deltaTime;
            if (img.alpha == 0)
            {
                check = false;
            }
        }
    }
}
