using System.Collections;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private bool gameended;
    public Rigidbody2D rb;
    public float forceAmount;
    public Collider2D Collider2D;
    public AudioClip gameOverClip;
    [SerializeField] bool voiceCalled = false;
    [SerializeField] bool isSpaceDisabled = false;
    private bool isTouchDisabled;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (!isTouchDisabled && touch.phase == TouchPhase.Began)
                {
                    JumpForce();
                }

            }
            if (!isSpaceDisabled && Input.GetKeyDown(KeyCode.Space))
            {
                JumpForce();
            }
            UpdateRotation();
            gameended = Collision.gameend;
        if (!voiceCalled && gameended == true)
        {
            AudioManager.instance.PlayGameOverSFX(gameOverClip);
            Collider2D.enabled = false;
            voiceCalled = true;
            isSpaceDisabled = true;
            isTouchDisabled = true;
            StartCoroutine(SimulateJump());

        }

    }
    IEnumerator SimulateJump()
    {
        while (true)
        {
            float randomInterval = Random.Range(0.57f, 1.34f);
            Debug.Log(randomInterval);
            yield return new WaitForSeconds(randomInterval);
            JumpForce();
        }
    }

    void JumpForce()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector3(0, 1, 1) * forceAmount, ForceMode2D.Impulse);
        rb.centerOfMass = new Vector3(1, 0, 0);
    }


    void UpdateRotation()
    {
        float angle = Mathf.Atan2(rb.velocity.y, 10) * Mathf.Rad2Deg -65;
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }
 }
