using System;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] CubesColorArray;
    [SerializeField] private Color[] ColorsArray;

    public void ChangeColor(string colorOrder)
    {
        for (int i = 0; i < 9; i++)
        {
            CubesColorArray[i].GetComponent<Renderer>().material.color = ColorsArray[Convert.ToInt32(colorOrder[i] - 1)];
        }
    }
}
