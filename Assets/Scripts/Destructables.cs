using UnityEngine;

public class Destructables : Attackables
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float destroyDelay = 0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void Hit()
    {
        Destroy(gameObject,destroyDelay);
    }
}
