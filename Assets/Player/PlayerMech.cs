using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMech : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] public GameObject Bullet;
    [SerializeField] public Transform BulletSpawnSpot;
    public float Health;
    public Rigidbody2D PlayerBody;

    void Start()
    {
        Health = 100;

        for (int i = 0; i < Bullet.transform.childCount; i++)
        {
            Bullet.transform.GetChild(i).gameObject.SetActive(false);
        }
        InvokeRepeating("Shoot", 0.5f, 0.1f);

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(moveHorizontal * Vector2.right);
        Health = PlayerPrefs.GetFloat("PlayerHP");
        Health = Mathf.Clamp(Health, 0, 100);
        PlayerPrefs.SetFloat("PlayerHP", Health);
        PlayerPrefs.Save();

    }
    void Shoot()
    {
        Instantiate(Bullet, BulletSpawnSpot.position, Quaternion.identity);
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        Debug.Log("Player Hit! HP = " + Health);
        PlayerPrefs.SetFloat("PlayerHP", Health);
        PlayerPrefs.Save();

        if (Health == 0)
            Die();
    }
    void Die()
    {
        Debug.Log("You have Died. T^T");
        GetComponent<ScoreManager>().FinalScore();
        SceneManager.LoadScene(0);
    }
}
