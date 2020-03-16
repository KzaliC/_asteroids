using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public GameObject _bullet;
    public GameObject _mainPlayer;
    public AudioClip _bulletAudio;
    public Transform _firePos;
    private AudioSource _audioSource;
    private LifeManager _lifeManager;
    
    protected void Awake()
    {
        _lifeManager = FindObjectOfType<LifeManager>();
        _audioSource = GetComponent<AudioSource>();
        gameObject.layer = 9;
        StartCoroutine(immunityOff());
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ShotBullet();
        }
    }
    // Shoots bullet the bullet at the firepos and plays a shooting sound
    void ShotBullet()
    {
        _audioSource.PlayOneShot(_bulletAudio);
        Instantiate(_bullet, new Vector2(_firePos.transform.position.x, _firePos.transform.position.y), _firePos.transform.rotation);
    }
   //on collsion kills the player and deducts a life point
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroids")
        {
            _lifeManager.PlayerHit();
            Destroy(gameObject);

        }
    }

    IEnumerator immunityOff()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.layer = 10;
    }
}


