using UnityEngine;

public class MouseToWorld : MonoBehaviour
{
    public static MouseToWorld instance;

    public Vector3 oldPosition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Vector3 mouseWorldPosition = Input.mousePosition;
        mouseWorldPosition.z = -Camera.main.transform.position.z;
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseWorldPosition);
        mouseWorldPosition.z = 0f;
        transform.position = mouseWorldPosition;
        if (oldPosition != transform.position)
        {
            transform.up = Vector3.Lerp(transform.up, transform.position - oldPosition, 0.9f);
            //transform.up = transform.position - oldPosition;
        }
        oldPosition = mouseWorldPosition;
    }
}
