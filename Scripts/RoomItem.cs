using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  
public class RoomItem : MonoBehaviour
{
    public TMP_Text roomName; 
    createandJoinRooms manager;

    private void Start(){
        manager = FindObjectOfType<createandJoinRooms>();
    }

    public void SetRoomName(string _roomN) 
    {
        roomName.text = _roomN;
    }
    public void OnClickItem(){
        manager.JoinRoom(roomName.text);
    }
}
