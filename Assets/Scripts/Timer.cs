using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timeText;
    float hours = 0f;
    float minutes = 0f;
    float seconds = 0f;

    float t;

    // Start is called before the first frame update
    void Start()
    {
        t =0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        seconds = t;
        seconds = Mathf.Floor(seconds);

        minutes = seconds / 60;
        minutes = Mathf.Floor(minutes);

        hours = minutes / 60;
        hours = Mathf.Floor(hours);

        seconds -= minutes * 60;
        minutes -= hours * 60;

        timeText.text = ($"{hours.ToString("00")}:{minutes.ToString("00")}:{seconds.ToString("00")}");
    }
}
