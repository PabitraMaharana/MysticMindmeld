using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Playerspawner : MonoBehaviour
{
    public GameObject[] playerprefab;
    public Transform[] spawnPoints;

    private void Start(){
        int randomNumber = Random.Range(0,spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomNumber];
        GameObject playerToSpawn = playerprefab[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
        PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position,Quaternion.identity);
    }
}
