using UnityEngine;

public class Collision : MonoBehaviour
{
    public static bool gameend;
    public static int score = 0;
    public GameObject Point;
    public AudioClip scoreSfx;



    private void Start()
    {
        gameend = false;
        score = 0;
    }
        void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (collision2D.gameObject.tag == "Player" && gameObject.tag == "Column")
            {
                gameend = true;
            
            }

            if (collision2D.gameObject.tag == "Player" && gameObject.tag == "Point")
            {
                score++;
                AudioManager.instance.PlayScoreSFX(scoreSfx);
                Point.GetComponent<BoxCollider2D>().enabled = false;

            }
        }
    }
