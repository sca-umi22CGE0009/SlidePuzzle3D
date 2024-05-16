using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScript : MonoBehaviour
{
    [SerializeField,Header("座標")] private List<Vector2> objPos = new();
    [SerializeField,Header("オブジェクト")] GameObject[] objSave = null;
    // Start is called before the first frame update
    void Start()
    {
        Shuffle();
        Vector3 pos = objSave[objSave.Length].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //パズルが一致したら止める
        //if (objPos == objSeve)
        //{
        //    Time.timeScale = 0.0f;
        //}
    }
    //シャッフルする
    void Shuffle()
    {
        for (int i = 0; i < objPos.Count-1; i++)
        {
            int p = Random.Range(0, i - 1);

            Vector2 tmp = objPos[i];
            objPos[i] = objPos[p];
            objPos[p] = tmp;
        }

    }
}
