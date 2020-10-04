using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingNest : MonoBehaviour
{
    [SerializeField] Text countDisplay;

    private int count = 0;
    public int Count
    {
        get { return count; }
        set { count = value; countDisplay.text = count.ToString(); }
    }
}
