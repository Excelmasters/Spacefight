using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<int> numbers = new List<int>();
        numbers.Add(1);
        numbers.Add(24);
        numbers.Add(83);
        numbers.Add(20);
        numbers.Add(1240);
        numbers.Remove(1); 
        Debug.Log(numbers[2]);
        numbers.Remove(1);
        Debug.Log(numbers[2]);
    }


}
