using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject sled;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Fix Game Over part
        if (player == null || sled == null)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
