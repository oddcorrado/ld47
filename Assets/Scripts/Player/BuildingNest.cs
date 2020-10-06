using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingNest : MonoBehaviour
{
    [SerializeField] Text countDisplay;
    [SerializeField] GameObject[] steps;


    private int count = 0;
    public int Count
    {
        get { return count; }
        set
        {
            count = value;
            countDisplay.text = count.ToString() + "/3";
            foreach (var step in steps) step.SetActive(false);
            steps[count - 1].SetActive(true);
        }
    }
}
