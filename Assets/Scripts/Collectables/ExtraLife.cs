using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class ExtraLife : MonoBehaviour {

	Rigidbody2D rb2D;
    BoxCollider2D bc2D;

    public AudioClip collSFX;

	// Use this for initialization
	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        bc2D = GetComponent<BoxCollider2D>();

        rb2D.gravityScale = 0;
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        bc2D.isTrigger = true;
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            Character_Controller cc = c.GetComponent<Character_Controller>();
            if (cc)
                cc.lives++;

            Sound_Manager.instance.PlaySingleSound(collSFX);

            Destroy(gameObject);
        }
    }
}
