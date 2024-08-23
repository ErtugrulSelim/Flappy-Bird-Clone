using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColumnManager : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject prefab;
    private const int poolSize = 2;
    private List<GameObject> pool;
    private int currentpool = 0;
    public float speed = 1.0f;
    private bool gameended;
    private float screenWidth;
    private float screenHeight;
    private Vector2 screenPosition;
    private Vector3 worldPositionX;
    public CanvasScaler canvasScaler;

    void Start()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            pool.Add(obj);
            pool[i].SetActive(false);
        }
        CalculateWorldPosition();
        FirstColumnPosition();
        AdjustPrefabScaleByCameraSize();
    }

    void CalculateWorldPosition()
    {
        screenPosition = new Vector2(Screen.width / 2 , Screen.height);
        worldPositionX = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x / poolSize, screenPosition.y, Camera.main.nearClipPlane));
    }

    void Update()
    {
        gameended = Collision.gameend;
        GetColumnMove();
        GetColumnPosition();
    }

    void FirstColumnPosition()
    {
        float cameraHeight = mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        for (int i = 0; i < poolSize; i++)
        {

            float minY = -cameraHeight / 4.6f;
            float maxY = cameraHeight / 4.6f;
            float spawnYPosition = Random.Range(minY, maxY);
            float screenRight = mainCamera.ViewportToWorldPoint(new Vector2(1, 0)).x;
            pool[i].transform.position = new Vector2(+screenRight + (-worldPositionX.x * i* 2.7f), spawnYPosition);
            pool[i].SetActive(true);
            currentpool++;
        }
    }

    void GetColumnMove()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (pool[i].activeSelf)
            {
                pool[i].transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }
    }

    void GetColumnPosition()
    {
        float cameraHeight = mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        for (int i = 0; i < poolSize; i++)
        {
            float minY = -cameraHeight / 4.6f;
            float maxY = cameraWidth / 4.6f;
            float spawnYPosition = Random.Range(minY, maxY);
            float screenLeft = mainCamera.ViewportToWorldPoint(new Vector2(0, 0)).x;
            float screenRight = mainCamera.ViewportToWorldPoint(new Vector2(1, 0)).x;
            if (pool[i].transform.position.x < screenLeft + worldPositionX.x/2)
            {
                pool[i].transform.position = new Vector2(screenRight - worldPositionX.x, spawnYPosition);
                pool[i].GetComponent<ColumnController>().SetActivatePoint();
            }
        }
    }
    public void AdjustPrefabScaleByCameraSize()
    {
        if (mainCamera.orthographic)
        {
            float cameraHeight = 2f * mainCamera.orthographicSize;
            float cameraWidth = cameraHeight * mainCamera.aspect;

            float referenceWidth = 12f;
            float referenceHeight = 12f;

            float scaleX = cameraWidth / referenceWidth;
            float scaleY = cameraHeight / referenceHeight;
            float scaleFactor = Mathf.Min(scaleX, scaleY);

            for (int i = 0; i < poolSize; i++)
            {
                pool[i].transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);
            }
        }
        else
        {
            Debug.LogError("Kamera ortografik deðil.");
        }
    }

    public void StopTimeBasedMovement()
    {
        for (int i = 0; i < poolSize; i++)
        {
            pool[i].SetActive(false);
        }
    }
}