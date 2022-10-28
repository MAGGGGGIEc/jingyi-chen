using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Rigidbody2D rig;

    public GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            rig.velocity=new Vector2(Input.GetAxis("Horizontal"), 0f)*10f;
        }
        else {
            rig.velocity = Vector2.zero;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {

            rig.AddForce(new Vector2(0, 10f)*500f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "food") {

            Destroy(collision.gameObject);
            manager.GetSorce();
        }
    }
}
