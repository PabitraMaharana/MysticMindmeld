using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class chessinteraction : MonoBehaviour, IInteractable {
 
	public GameObject cam;
	public GameObject softlock;
 
	private void Start() {

	}
 
	public string GetDescription() {
		return "To play Chess";
	}
 
	public void Interact() {
		cam.SetActive(true);
		softlock.SetActive(false);
	}
}