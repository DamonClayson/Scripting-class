using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
    public PlayerController PlayerController;
    public Rigidbody2D rb;
    public BoxCollider2D collider;
    public BoxCollider2D slideCollider;
    public float slideSpeed = 5f;
    public bool isSliding = false;

    private void update()
    {
        if(Input.GetKeyDown("LeftShift"))
        Slide();
    }

    private void Slide()
    {
        isSliding = true;

        collider.enabled = false;
        slideCollider.enabled = true;
    
        // GetComponent<Rigidbody>(AddForce(Vector2.right * slideSpeed));
        if(!PlayerController)
        {
            GetComponent<Rigidbody>().AddForce(Vector2.right * slideSpeed);
        }
            else
            {
                GetComponent<Rigidbody>().AddForce(Vector2.left * slideSpeed);
            }


        //rb.AddForce(Vector2.right * slideSpeed);


        StartCoroutine("stopSlide");
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds (0.8f);
        collider.enabled = true;
        slideCollider.enabled = false;
        isSliding = false;
    }
}
