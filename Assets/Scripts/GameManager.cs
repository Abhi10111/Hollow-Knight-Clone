using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameManager instance { get; private set; }

    public GameObject player;

    private void Awake()
    {
        if (instance != this && instance!=null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
