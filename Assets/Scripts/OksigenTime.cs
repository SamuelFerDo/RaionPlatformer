using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OksigenTime : MonoBehaviour
{
    [SerializeField] private Text oksgienTime;
    [SerializeField] private float time;
    public int timeInt;

    private void Update()
    {
        if (timeInt <= 0)
        {
            Debug.Log("Kalah");
        }
        time -= Time.deltaTime;
        timeInt = (int)time;
        oksgienTime.text = " OKSIGEN " + timeInt;
    }
}
