using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ColorChanger : MonoBehaviour, IInteractable {
 
	Animator mat;
 
	private void Start() {
		mat = GetComponent<Animator>();
	}
 
	public string GetDescription() {
		return "To Move Pieces";
	}
 
	public void Interact() {
		mat.SetBool("move" , true);
	}
}