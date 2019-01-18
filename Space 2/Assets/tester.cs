using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class IDictionaryExtensions
{
    public class tester : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Dictionary<int, Vector3> dictionary = new Dictionary<int, Vector3>();
            dictionary.Add(0, new Vector3(1, 1, 1));
            dictionary.Add(2, new Vector3(1, 1, 1));
            dictionary.Add(1, new Vector3(1, 1, 1));
            Debug.Log(dictionary.Keys);

            foreach (KeyValuePair<int, Vector3> pair in dictionary)
                if (dictionary.Values.Equals(pair.Value)) ;
            {
                Debug.Log("2");
            }

        }
    }

}
