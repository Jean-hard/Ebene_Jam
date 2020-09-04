using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractChild2 : MonoBehaviour
{
    public GameObject ecoloL;
    public GameObject pollueurL;
    public GameObject ecoloR;
    public GameObject pollueurR;

    private int ecoloNbr = 0;
    private int pollueurNbr = 0;
    private int totalVelocity = 0;
    private List<GameObject> humans;

    private void Start()
    {
        humans = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HumanR")
        {
            
            float velocityH = collision.gameObject.GetComponent<Rigidbody2D>().velocity.x;
            if (velocityH < 0)
            {
                totalVelocity--;
            }
            if (velocityH > 0)
            {
                totalVelocity++;
            }
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            Human_Right scriptH = collision.gameObject.GetComponent<Human_Right>();
            if (scriptH.isEcolo)
            {
                ecoloNbr++;
            }
            if (!scriptH.isEcolo)
            {
                pollueurNbr++;
            }

            humans.Add(collision.gameObject);
        }


        if (collision.gameObject.tag == "HumanL")
        {
            
            float velocityH = collision.gameObject.GetComponent<Rigidbody2D>().velocity.x;
            if (velocityH < 0)
            {
                totalVelocity--;
            }
            if (velocityH > 0)
            {
                totalVelocity++;
            }
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            Human_Left scriptH = collision.gameObject.GetComponent<Human_Left>();
            if (scriptH.isEcolo)
            {
                ecoloNbr++;
            }
            if (!scriptH.isEcolo)
            {
                pollueurNbr++;
            }

            humans.Add(collision.gameObject);
        }
    }

    IEnumerator Merge()
    {
        foreach(GameObject human in humans)
        {
            human.GetComponent<SpriteRenderer>().color = Color.black;
        }
        yield return new WaitForSeconds(1);
        foreach (GameObject human in humans)
        {
            Destroy(human);
        }
        int totalHumans = pollueurNbr - ecoloNbr;
        print(totalHumans);
        if(totalHumans > 0)
        {
            if (totalVelocity < 0)
            {
                GameObject newPollueur = Instantiate(pollueurR, transform.position, transform.rotation) as GameObject;
                float surface = Mathf.Pow(((newPollueur.transform.localScale.x)), 2)*3.14f/4;
                float totalSurface = surface * Mathf.Abs(totalHumans);
                float newScale = Mathf.Sqrt(totalSurface / 3.14f);
                Debug.Log(newPollueur.transform.localScale + "became: " + newScale);
                newPollueur.transform.localScale = new Vector3(newScale, newScale, newScale);
            }

            if (totalVelocity > 0)
            {
                GameObject newPollueur = Instantiate(pollueurL, transform.position, transform.rotation) as GameObject;
                //newPollueur.transform.localScale *= Mathf.Abs(totalHumans);
                float surface = Mathf.Pow(((newPollueur.transform.localScale.x)), 2) * 3.14f / 4;
                float totalSurface = surface * Mathf.Abs(totalHumans);
                float newScale = Mathf.Sqrt(totalSurface / 3.14f);
                Debug.Log(newPollueur.transform.localScale + "became: " + newScale);
                newPollueur.transform.localScale = new Vector3(newScale, newScale, newScale);
            }

            if(totalVelocity == 0)
            {
                float random = Random.Range(0, 1);
                if(random < 0.5f)
                {
                    GameObject newPollueur = Instantiate(pollueurR, transform.position, transform.rotation) as GameObject;
                    float surface = Mathf.Pow(((newPollueur.transform.localScale.x)), 2) * 3.14f / 4;
                    float totalSurface = surface * Mathf.Abs(totalHumans);
                    float newScale = Mathf.Sqrt(totalSurface / 3.14f);
                    Debug.Log(newPollueur.transform.localScale + "became: " + newScale);
                    newPollueur.transform.localScale = new Vector3(newScale, newScale, newScale);
                }
                if (random >= 0.5f)
                {
                    GameObject newPollueur = Instantiate(pollueurL, transform.position, transform.rotation) as GameObject;
                    //newPollueur.transform.localScale *= Mathf.Abs(totalHumans);
                    float surface = Mathf.Pow(((newPollueur.transform.localScale.x)), 2) * 3.14f / 4;
                    float totalSurface = surface * Mathf.Abs(totalHumans);
                    float newScale = Mathf.Sqrt(totalSurface / 3.14f);
                    Debug.Log(newPollueur.transform.localScale + "became: " + newScale);
                    newPollueur.transform.localScale = new Vector3(newScale, newScale, newScale);
                }
            }
        }

        if (totalHumans < 0)
        {
            if (totalVelocity < 0)
            {
                GameObject newEcolo = Instantiate(ecoloR, transform.position, transform.rotation) as GameObject;
                float surface = Mathf.Pow(((newEcolo.transform.localScale.x)), 2) * 3.14f / 4;
                float totalSurface = surface * Mathf.Abs(totalHumans);
                float newScale = Mathf.Sqrt(totalSurface / 3.14f);
                Debug.Log(newEcolo.transform.localScale + "became: " + newScale);
                newEcolo.transform.localScale = new Vector3(newScale, newScale, newScale);
            }

            if (totalVelocity > 0)
            {
                GameObject newEcolo = Instantiate(ecoloL, transform.position, transform.rotation) as GameObject;
                float surface = Mathf.Pow(((newEcolo.transform.localScale.x)), 2) * 3.14f / 4;
                float totalSurface = surface * Mathf.Abs(totalHumans);
                float newScale = Mathf.Sqrt(totalSurface / 3.14f);
                Debug.Log(newEcolo.transform.localScale + "became: " + newScale);
                newEcolo.transform.localScale = new Vector3(newScale, newScale, newScale);
            }

            if (totalVelocity == 0)
            {
                float random = Random.Range(0, 1);
                if (random < 0.5f)
                {
                    GameObject newEcolo = Instantiate(ecoloR, transform.position, transform.rotation) as GameObject;
                    float surface = Mathf.Pow(((newEcolo.transform.localScale.x)), 2) * 3.14f / 4;
                    float totalSurface = surface * Mathf.Abs(totalHumans);
                    float newScale = Mathf.Sqrt(totalSurface / 3.14f);
                    Debug.Log(newEcolo.transform.localScale + "became: " + newScale);
                    newEcolo.transform.localScale = new Vector3(newScale, newScale, newScale);
                }

                if (random >= 0.5f)
                {
                    GameObject newEcolo = Instantiate(ecoloL, transform.position, transform.rotation) as GameObject;
                    float surface = Mathf.Pow(((newEcolo.transform.localScale.x)), 2) * 3.14f / 4;
                    float totalSurface = surface * Mathf.Abs(totalHumans);
                    float newScale = Mathf.Sqrt(totalSurface / 3.14f);
                    Debug.Log(newEcolo.transform.localScale + "became: " + newScale);
                    newEcolo.transform.localScale = new Vector3(newScale, newScale, newScale);
                }
            }
        }
        Destroy(transform.parent.transform.parent.gameObject);

    }


}
