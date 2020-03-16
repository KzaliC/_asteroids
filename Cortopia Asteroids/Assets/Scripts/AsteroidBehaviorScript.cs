using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AsteroidBehaviorScript : MonoBehaviour
{
    
    public float _maxThrust;
    public float _maxTorque;

    public float _screenTop;
    public float _screenBottom;
    public float _screenLeft;
    public int _screenRight;
    public int asteroidSize;

    public Rigidbody2D _rigidbody2D;
    public GameObject _asteroidMedium;
    public GameObject _asteroidSmall;
    private BoxCollider2D _boxCollider2D;

    private ScoreHandler _scoreHandler;


    protected void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _boxCollider2D.enabled = false;
        _scoreHandler = FindObjectOfType<ScoreHandler>();
        StartCoroutine(EnableBoxCollider());
    }

    // gives the asteroid a radnom direction
    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        return new Vector2(x, y);
    }

    protected void Start()
    {
        Vector2 thrust = new Vector2(Random.Range(-_maxThrust, _maxThrust), Random.Range(-_maxThrust, _maxThrust));
        float torque = Random.Range(-_maxTorque, _maxTorque);

        _rigidbody2D.AddForce(thrust);
        _rigidbody2D.AddTorque(torque);

       
        _rigidbody2D.velocity = RandomVector(0f, 5f);

    }

    protected void Update()
    {
        Vector2 newPos = transform.position;
        if(transform.position.y > _screenTop)
        { newPos.y = _screenBottom; }

        if (transform.position.y < _screenBottom)
        { newPos.y = _screenTop; }

        if (transform.position.x > _screenRight)
        { newPos.x = _screenLeft; }

        if (transform.position.y < _screenLeft)
        { newPos.x = _screenRight; }
        transform.position = newPos;
        
    }
    //stops the asteroid from instantly kill itself when its Instantiated from a size 3 or 2;
    IEnumerator EnableBoxCollider()
    {
        yield return new WaitForSeconds(1);
        _boxCollider2D.enabled = true;
    }
    // checks which object collided with the ateroid and gives points if the bullet hits an asteroid
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Asteroids")
        {
            
            if (asteroidSize == 3)
            {
                Instantiate(_asteroidMedium, transform.position, transform.rotation);
                Instantiate(_asteroidMedium, transform.position, transform.rotation);
              
            }
            else if (asteroidSize == 2)
            {
                Instantiate(_asteroidSmall, transform.position, transform.rotation);
                Instantiate(_asteroidSmall, transform.position, transform.rotation);
            }
            else if (asteroidSize == 1)
            {

            }
            if(collision.gameObject.tag == "Bullet")
            {
                AddScore();
            }
        }
        Destroy(gameObject);
    }
  // adds +1 to the score when a bullet hits an asteroid
    protected void AddScore()
    {
        _scoreHandler.AsteriodAddScore();
        Debug.Log("Added Score");
    }
}
