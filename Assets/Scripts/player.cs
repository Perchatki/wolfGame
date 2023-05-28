using UnityEngine;
using UnityEngine.UI;
public class player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector2 startPos;
    [SerializeField] float maxX,maxY;
    private float moveInputX, moveInputY;
    [SerializeField] TMPro.TMP_Text text;
    private Vector3 prevPos = Vector3.zero;
    [SerializeField] Slider sliderX,sliderY;


    private Rigidbody2D rb;

    private bool facingRight = true;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb= GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(moveInputX) + Mathf.Abs(moveInputY) > 0)
        {
            rb.velocity = new Vector2(moveInputX * speed, moveInputY * speed/2);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        if (facingRight == false && moveInputX > 0)
        {
            Flip();
        }
        else if(facingRight == true && moveInputX <0)
        {
            Flip();
        }
    }

    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -maxX, maxX), Mathf.Clamp(transform.position.y, startPos.y/2 - maxY, startPos.y/2 + maxY), transform.position.z);
        if (transform.position.y > -1.3)
        {
            gameObject.layer = 6;
        }
        else
        {
            gameObject.layer = 7;
        }


        if ((prevPos - transform.position).magnitude < 0.1)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
        prevPos = transform.position;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer > 5)
        {
            if (collision.transform.tag == "gEgg")
            {
                text.text = (int.Parse(text.text) + 3).ToString();
            }
            else
            {
                text.text = (int.Parse(text.text) + 1).ToString();
            }

            Destroy(collision.gameObject);
        }
    }

    public void ChangePosX()
    {
        if (sliderX.value > .7)
        {
            moveInputX = 1;
        }
        else if (sliderX.value < -.7)
        {
            moveInputX = -1;
        }
        else
        {
            moveInputX = 0;
        }
    }
    public void ChangePosY()
    {
        if (sliderY.value > .7)
        {
            moveInputY = 1;
        }
        else if (sliderY.value < -.7)
        {
            moveInputY = -1;
        }
        else
        {
            moveInputY = 0;
        }
    }



}
