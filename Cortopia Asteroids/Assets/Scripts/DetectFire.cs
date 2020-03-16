using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFire : MonoBehaviour
{
    float _speed;
    private Rigidbody2D _rb_2D;
    private Transform _currentPos;
    public int _maxDistanceUntilBulletIsDestroyed = 8;

    // Use this for initialization
    void Start()
    {
        _speed = Random.Range(4f, 7f);
        _rb_2D = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyBulletOverTime());
    }

    // Update is called once per frame
    void Update()
    {      
        _currentPos = transform;
        _rb_2D.velocity = transform.up * _speed;
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        // checks if the player has moved over the max distance, if it has the bullet is destroyed;

        if (Vector3.Distance(playerTransform.position, _currentPos.position) > _maxDistanceUntilBulletIsDestroyed)
        {
            Destroy(gameObject);
        }

    }

    // destorys the bullet when it hits an asteroid or another bullet;
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        Debug.Log("BOOM");
        Destroy(gameObject);
    }

    // destroys the bullet after a certain time if it hasnt traveld past the limit range yet.
    IEnumerator DestroyBulletOverTime()
    {
        yield return new WaitForSeconds(8);
        Destroy(gameObject);
    }
}
