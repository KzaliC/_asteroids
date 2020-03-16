using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject _playerPrefab;
    public Transform _playerTransfromPrefab;

    private GameObject _playerInScene;

    protected void Update()
    {
        _playerInScene = GameObject.FindGameObjectWithTag("Player");
        if(_playerInScene == null)
        {
            SpawnNewPlayer();
        }
    }
    // if the player isnt in the scene the a new player prefab gets spawned;
    protected void  SpawnNewPlayer()
    {      
        Instantiate(_playerPrefab, new Vector2(_playerTransfromPrefab.transform.position.x, _playerTransfromPrefab.transform.position.y), Quaternion.identity);
    }
}
