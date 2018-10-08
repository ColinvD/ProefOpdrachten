using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

    [SerializeField]
    private float size = 1;
    [SerializeField]
    private int width = 2;
    [SerializeField]
    private int height = 2;

    public void SetSize(float value)
    {
        size = value;
    }

    public void SetWidth(int value)
    {
        width = value;
    }

    public void SetHeight(int value)
    {
        height = value;
    }

    public float GetSize()
    {
        return size;
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }
}
