using UnityEngine;
using System.Collections;

public class Terrain_MeshRendererController : MonoBehaviour
{
	public bool disableAllMeshRenderersAtStart;
	public GameObject lightObj;

	// Use this for initialization
	void Start ()
	{
		MeshRenderer[] r = FindObjectsOfType (typeof(MeshRenderer)) as MeshRenderer[];

		foreach (MeshRenderer t in r) {
			t.enabled = false;
		}

		lightObj.GetComponent<Light> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
