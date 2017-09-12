using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class GPUInstancing : MonoBehaviour {

    [SerializeField]
    GameObject instanceObject;
    public int count;

    Mesh mesh;
    Material mat;

    Matrix4x4[] matrix;
    Matrix4x4 oneMatrix;

    private Vector3 translationX;
    private Vector3 translationZ;
    public Vector3 eulerAngles;
    public Vector3 scale = new Vector3(1, 1, 1);
    
    ShadowCastingMode castShadows;

    private float t;

	// Use this for initialization
	void Start () {

        mesh = instanceObject.GetComponent<MeshFilter>().sharedMesh;
        mat = instanceObject.GetComponent<Renderer>().sharedMaterial;

	}
	
	// Update is called once per frame
	void Update () {

        //SinGrid();
        
    }

    void SinGrid()
    {
        Quaternion rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z);
        t += Time.deltaTime;

        castShadows = ShadowCastingMode.On;

        for (int i = 0; i < count; i++)
        {
            float y = Mathf.Sin(1.0f * t - i);
            translationX = new Vector3((count / 2 * -1) + i, y, 0);
            Matrix4x4 m = Matrix4x4.TRS(translationX, rotation, scale);
            matrix = new Matrix4x4[1] { m };

            Graphics.DrawMeshInstanced(mesh, 0, mat, matrix, matrix.Length, null, castShadows, true, 0, null);

            for (int j = 0; j < count; j++)
            {
                float _y = Mathf.Sin(1.0f * t - j);
                translationZ = new Vector3((count / 2 * -1) + i, _y, (count / 2 * -1) + j);
                Matrix4x4 _m = Matrix4x4.TRS(translationZ, rotation, scale);
                matrix = new Matrix4x4[1] { _m };

                Graphics.DrawMeshInstanced(mesh, 0, mat, matrix, matrix.Length, null, castShadows, true, 0, null);
            }
        }
    }
}
