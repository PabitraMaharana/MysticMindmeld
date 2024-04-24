using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class respawnpoints : MonoBehaviour, IInteractable {
 
	public enemycountholder counter;
    public Animator anim;

    string info;
 
	private void Start() {

	}
 
	public string GetDescription() {
		return info;
	}
 
	public void Interact() {
        info = counter.Decrement(-1);
        if(info == "Respawn ")
		    anim.SetBool("Dead" , false);

	}
}