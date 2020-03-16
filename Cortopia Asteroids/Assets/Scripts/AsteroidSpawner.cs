using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] _asteroids;

    public float _respawnTime = 5f;
    public float _spawnRegion = 10f;

    private Vector2 _screenBounds;
    private Camera _mainCamera;

    public GameObject[] _numberOfAsteroidsInScene;
    private bool _spawnAsteroid;
    protected void Awake()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    protected void Start()
    {
        _screenBounds = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
      //  StartCoroutine(SpawnAsteroid());
    
    }
    // creates asteroid based on how many are in the scene;
    protected void Update()
    {
        _numberOfAsteroidsInScene = GameObject.FindGameObjectsWithTag("Asteroids");
        if (_numberOfAsteroidsInScene.Length <= 0)
        {
            CreateAsteroid();
        }
        else if (_numberOfAsteroidsInScene.Length <= 5)
        {
            CreateAsteroid();
        }
        else if (_numberOfAsteroidsInScene.Length > 50)
        {
            foreach(GameObject asteroid in _numberOfAsteroidsInScene)
            {
                Destroy(asteroid);
            }
        }

    }
    protected void CreateAsteroid()
    {
        GameObject asteroid = Instantiate(_asteroids[Random.Range(0, _asteroids.Length)]) as GameObject;
        asteroid.transform.position = new Vector2(_screenBounds.x = Random.Range(-_spawnRegion, _spawnRegion), _screenBounds.y = Random.Range(-_spawnRegion, _spawnRegion));
    }

    IEnumerator SpawnAsteroid()
    {      
            yield return new WaitForSeconds(6);               
    }

}
