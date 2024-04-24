using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 
using Photon.Pun;
using Photon.Realtime;

public class createandJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput; 
    public TMP_Text joinInput; 
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public RoomItem roomItemPrefab;
    List<RoomItem> roomItemsList = new List<RoomItem>();
    public Transform contentObject;
    public float timebetweenUpdates = 1.5f;
    float nextUpdateTime;

    public List<playerItem> playerItemsList = new List<playerItem>(); 
    public playerItem playerItemPrefab;
    public Transform playerItemParent;

    public GameObject playButton;

    private void Start(){

        PhotonNetwork.JoinLobby();
    }
    public void OnClickCreate()
    {
        if(createInput.text.Length >=1)
        {
            PhotonNetwork.CreateRoom(createInput.text, new RoomOptions(){ MaxPlayers = 2, BroadcastPropsChangeToAll = true});
        }
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        joinInput.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;
        UpdatePlayerList();
    
    }

    public override void OnPlayerEnteredRoom(Player newPlayer){
        UpdatePlayerList(); 
    }

    public override void OnPlayerLeftRoom(Player otherPlayer){
        UpdatePlayerList(); 
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList){ 
        if(Time.time >= nextUpdateTime){
            UpdateRoomList(roomList);
            nextUpdateTime = Time.time + timebetweenUpdates;
        }
        
    }

    void UpdateRoomList(List<RoomInfo> list){
        foreach(RoomItem item in roomItemsList){
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();

        foreach (RoomInfo room in list){
            RoomItem newRoom = Instantiate(roomItemPrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            roomItemsList.Add(newRoom);
        }

    }

    public void OnClickLeaveRoom(){
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom(){
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }

    public override void OnConnectedToMaster(){
        PhotonNetwork.JoinLobby();
    }

    void UpdatePlayerList(){
        foreach(playerItem item in playerItemsList){
            Destroy(item.gameObject);
        }
        playerItemsList.Clear();

        if(PhotonNetwork.CurrentRoom == null){
            return;
        }
        foreach(KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players){
            playerItem newPlayerItem = Instantiate(playerItemPrefab, playerItemParent);
            newPlayerItem.SetPlayerInfo(player.Value);
            if(player.Value == PhotonNetwork.LocalPlayer){
                newPlayerItem.ApplyLocalChanges();
            }
            playerItemsList.Add(newPlayerItem);
        }

    }

    private void Update(){
        if(PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= 2){
            playButton.SetActive(true);
        }else{
            playButton.SetActive(false);
        }
    }

    public void OnClickPlayButton(){
            PhotonNetwork.LoadLevel("Game");
    }

    public void RetunToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
