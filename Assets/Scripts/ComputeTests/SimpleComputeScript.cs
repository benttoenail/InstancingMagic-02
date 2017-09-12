using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleComputeScript : MonoBehaviour {

    public ComputeShader _compute;
    public RenderTexture result;

    public int Res;

    public Color color;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        int kernel = _compute.FindKernel("CSMain");

        result = new RenderTexture(Res, Res, 24);
        result.enableRandomWrite = true;
        result.Create();

        _compute.SetTexture(kernel, "Result", result);
        _compute.SetVector("color", color);
        _compute.Dispatch(kernel, Res / 8, Res / 8, 1);

    }
}
