using UnityEngine;
using System.Collections;

public class Script : MonoBehaviour 
{
	public string name;
	void Awake () 
	{
		Debug.Log("my name is "+ name);
	}
	
}
