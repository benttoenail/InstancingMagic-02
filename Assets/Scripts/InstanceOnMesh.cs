using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceOnMesh : MonoBehaviour {

    [SerializeField]
    GameObject instanceObject;

    /*
    [SerializeField]
    GameObject meshObject;
    */

    public Vector3 objectScale;

    List<Vector3> vertsOri = new List<Vector3>();
    List<Vector3> vertsUpdate = new List<Vector3>();
    List<GameObject> objs = new List<GameObject>();

    int vertexCount;
    int objectCount;
    MeshFilter _meshfilter;
    Mesh _mesh;

    // Use this for initialization
    void Start () {

        /*
        if(meshObject != null)
        {
            _meshfilter = meshObject.GetComponent<MeshFilter>();
            _mesh = _meshfilter.mesh;
        }
        */
        _meshfilter = GetComponent<MeshFilter>();
        _mesh = _meshfilter.mesh;

        vertexCount = _mesh.vertexCount;

        GameObject instatiatedObjects = new GameObject();
        instatiatedObjects.name = "Instatiated_Objects";

        for (int i = 0; i < vertexCount; i++)
        {
            vertsOri.Add(_mesh.vertices[i]);

            if(instanceObject != null)
            {
                
                GameObject temp = Instantiate(instanceObject, vertsOri[i], Quaternion.identity) as GameObject;
                temp.transform.SetParent(instatiatedObjects.transform);
                objs.Add(temp);

            }
            
        }

        objectCount = objs.Count;

    }
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < objectCount; i++)
        {
            objs[i].transform.position = _mesh.vertices[i];
            objs[i].transform.localScale = objectScale;
            objs[i].transform.LookAt(gameObject.transform);
        }

        

	}
}
