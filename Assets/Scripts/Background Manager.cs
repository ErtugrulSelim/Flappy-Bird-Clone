using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    private List<GameObject> poolStars;
    private List<GameObject> poolPlanets;
    public int poolStarsSize;
    public int poolPlanetsSize;
    public GameObject[] Stars;
    public GameObject[] Planets;
    public Camera mainCamera;
    private int currentPoolStars = 0;
    private int currentPoolPlanets = 0;
    private float tolerance = 0.2f;
    public float speed = 1.0f;


    void Start()
    {      
        poolStars = new List<GameObject>();
        poolPlanets = new List<GameObject>();
        for (int i = 0; i < poolStarsSize; i++)
        {
            GameObject selectedStarsObject = SelectRandomStars(Stars);
            GameObject gameObject = Instantiate(selectedStarsObject);
            poolStars.Add(gameObject);
            poolStars[currentPoolStars].SetActive(false);
        }
        for (int i = 0; i < poolPlanetsSize; i++)
        {
            GameObject selectedPlanetObject = SelectRandomStars(Planets);
            GameObject gameObject = Instantiate(selectedPlanetObject);
            poolPlanets.Add(gameObject);
            poolPlanets[currentPoolPlanets].SetActive(false);
        }
        GetFirstPosition();
    }
    GameObject SelectRandomPlanet(GameObject[] Planets)
    {
        int randomIndex = Random.Range(0, Stars.Length);
        return Planets[randomIndex];
    }
    GameObject SelectRandomStars(GameObject[] Stars)
    {
        int randomIndex = Random.Range(0, Stars.Length);
        return Stars[randomIndex];
    }
    void Update()
    {
        GetMove();
        GetPosition();
    }

    void GetFirstPosition()
    {
        for (int i = 0; i < poolStarsSize; i++)
        {
            float spawnYPosition = Random.Range(-6f, 6f);
            float spawnXPosition = Random.Range(-10f, 14f);
            poolStars[i].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            poolStars[currentPoolStars].SetActive(true);
            currentPoolStars++;
        }
        for (int i = 0; i < poolPlanetsSize; i++)
        {
            float spawnYPosition = Random.Range(-6f, 6f);
            float spawnXPosition = Random.Range(-10f, 45f);
            poolPlanets[i].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            poolPlanets[currentPoolPlanets].SetActive(true);
            currentPoolPlanets++;
        }
    }
    void GetMove()
    {
        for (int i = 0; i < poolStarsSize; i++)
        {
            poolStars[i].transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        for (int i = 0; i < poolPlanetsSize; i++)
        {
            poolPlanets[i].transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    void GetPosition()
    {
        float screenLeft = mainCamera.ViewportToWorldPoint(new Vector2(0, 0)).x;
        for (int i = 0; i < poolStarsSize; i++)
        {
            float spawnYPosition = Random.Range(-6f, 6f);
            if (poolStars[i].transform.position.x < screenLeft - tolerance)
            {
                poolStars[i].transform.position = new Vector2(15, spawnYPosition);
            }

        }
        for (int i = 0; i < poolPlanetsSize; i++)
        {
            float spawnYPosition = Random.Range(-6f, 6f);
            float spawnXPosition = Random.Range(19f, 90f);
            if (poolPlanets[i].transform.position.x < screenLeft - tolerance)
            {
                poolPlanets[i].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            }
        }
    }

}