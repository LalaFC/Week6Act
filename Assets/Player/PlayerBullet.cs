using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBullet : MonoBehaviour
{

    [SerializeField] public float speed = 10f;
    public float damage = 20;
    public Rigidbody2D rb;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("PlayerScore");
        rb.velocity = transform.up * speed;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > Boundary.boundary.y)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D (Collider2D hit)
    {

        if (hit.gameObject.tag == "Enemy" || hit.gameObject.tag == "EnemyBullet")
        {
            if (hit.gameObject.tag == "Enemy")
            {
                EnemyMechanics enemy = hit.gameObject.GetComponent<EnemyMechanics>();

                score += enemy.TakeDamage(damage);
                PlayerPrefs.SetInt("PlayerScore", score);
                PlayerPrefs.Save();

            }
            Destroy(gameObject);
        }
    }
}
