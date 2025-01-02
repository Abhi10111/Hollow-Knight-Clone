using UnityEngine;

public class Destructables : Attackables
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [SerializeField] GameObject brokenObject;
    private ParticleSystem particleSystem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void Hit(RaycastHit2D hit, float damage)
    {
        Vector2 hitDirection = -hit.normal;
        if (brokenObject != null)
        {
            GameObject broken=Instantiate(brokenObject,transform.position+brokenObject.transform.position,transform.rotation,transform.parent);
            particleSystem = broken.GetComponent<ParticleSystem>();
            ParticleSystem.ShapeModule shape = particleSystem.shape;
            shape.rotation = new Vector3(0, hitDirection.x * 90, 0);
        }
        Destroy(gameObject);
    }

}
