using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class endgame : MonoBehaviour, IInteractable {
 
	public gemcount gem;
 
	private void Start() {
		
	}
 
	public string GetDescription() {
		return "Place Gems To return";
	}
 
	public void Interact() {
		gem.Decrement(2);
        
	}
}