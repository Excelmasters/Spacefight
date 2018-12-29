using UnityEngine;
using System.Collections;

// Copy meshes from children into the parent's Mesh.
// CombineInstance stores the list of meshes.  These are combined
// and assigned to the attached Mesh.

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class CombineMeshes : MonoBehaviour
{
    public GameObject ss;
    private int x;
    void Update()
    {
        Destroy(ss.GetComponent<MeshCollider>());
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
            CombineInstance[] combine = new CombineInstance[meshFilters.Length];

            int i = 0;
            while (i < meshFilters.Length)
            {
                combine[i].mesh = meshFilters[i].sharedMesh;

                combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
                meshFilters[i].gameObject.SetActive(false);

                i++;
            }
            transform.GetComponent<MeshFilter>().mesh = new Mesh();
            transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
            transform.gameObject.SetActive(true);
            this.transform.position = ss.transform.position;




            ss.AddComponent<MeshCollider>();
            MeshCollider CCgb = ss.GetComponent<MeshCollider>();
            CCgb.convex = true;


        foreach (Transform child in ss.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

    ss.GetComponent<MeshCollider>().convex = true;



        enabled = false;
    }
 
}

