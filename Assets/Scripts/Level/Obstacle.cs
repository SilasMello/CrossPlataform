using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour 
{
    [Range(0,5)]
    public int health = 5;
    public RectTransform healthBar;

    public AudioClip killEffect;
    AudioSource asEnemyDead;

    float healthScale;
	// Use this for initialization
	void Start () {

        healthScale = healthBar.sizeDelta.x / health;
        asEnemyDead = GetComponent<AudioSource>();

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player_Projectile")
        {
            health--;
            healthBar.sizeDelta = new Vector2(health * healthScale, healthBar.sizeDelta.y);

            if (health <= 0)
            {
				Destroy(gameObject, killEffect.length);
                asEnemyDead.PlayOneShot(killEffect);
            }
        }
    }
}
