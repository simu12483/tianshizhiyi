using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using random = UnityEngine.Random;

public class BoardObject : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;
        public Count (int min,int max)
        {
            minimum = min;
            maximum = max;
        }
        public int Columns = 16;
        public int rows = 8;
        public Count wallcount = new Count (5,9);
        public GameObject exit;
        public GameObject[] floorTiles;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
