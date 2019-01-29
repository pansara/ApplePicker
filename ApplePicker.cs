using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGo.transform.position = pos;
            basketList.Add(tBasketGo);
        }
    }

    public void AppleDestroyed()
    {
        //Destroy all the falling apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        //Destroy one of the baskets 
        //Get the index of last basket in basketList
        int basketIndex = basketList.Count - 1;
        //Get a reference to that Basket GameObject
        GameObject tBasketGO = basketList[basketIndex];
        //Remove the Basket from the list and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        //If there are no Baskets left, restart the game
        if(basketList.Count == 0)
        {
            //SceneManager.LoadScene("_Scene_0");
            Application.LoadLevel("gameover");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (numBaskets <= 0)
        {
            
        }
    }
}
