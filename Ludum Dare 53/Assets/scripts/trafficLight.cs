using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficLight : MonoBehaviour
{
    public GameObject red;
    public GameObject green;
    public GameObject yellow;

    bool redLight = false;
    public GameManager game;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(time());
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("hi");
        //Check to see if the tag on the collider is equal to Enemy
        if (other.tag == "Player" && redLight)
        {
            game.UpdateGameState(GameManager.GameState.Defeat);
        }
    }

    IEnumerator time()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 10f));
            green.SetActive(false);
            yellow.SetActive(true);
            yield return new WaitForSeconds(1);
            redLight = true;
            yellow.SetActive(false);
            red.SetActive(true);
            yield return new WaitForSeconds(Random.Range(5f, 10f));
            red.SetActive(false);
            green.SetActive(true);
            redLight = false;
        }

    }
}
