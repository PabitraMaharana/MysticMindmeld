using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class rewspawn : MonoBehaviour, IInteractable {
 
	Animator mat;
    public enemycountholder counter;

    string str = "Respawn";
 
	private void Start() {
		mat = GetComponent<Animator>();
	}
 
	public string GetDescription() {
		return str;
	}
 
	public void Interact() {
        str = counter.Decrement(1);
		mat.SetBool("Dead" , false);
	}
}