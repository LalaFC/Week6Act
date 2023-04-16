
using UnityEngine;

public class BgScroller : MonoBehaviour
{
    [SerializeField] Transform First, Second;
    [SerializeField] private float scrollSpd, offSet;
    private float Vdif = 20.48f, minHt = -12f;
    private Vector3 newPos;

    void Start()
    {
        Vdif = Second.position.y - First.position.y;
        offSet += First.position.z;
    }

    void Update()
    {
        Movement();
        Wrap();
    }

    void Movement()
    {
        First.position = new Vector3(First.position.x, First.position.y - (Time.deltaTime * scrollSpd), offSet);
        Second.position = new Vector3(Second.position.x, Second.position.y - (Time.deltaTime * scrollSpd), offSet);
    }

    void Wrap()
    {
        if (First.position.y < minHt)
        {
            newPos = new Vector3(First.position.x, First.position.y + Vdif *2, offSet);
            First.position = newPos;
        }

        if (Second.position.y < minHt)
        {
            newPos = new Vector3(Second.position.x, Second.position.y + Vdif*2, offSet);
            Second.position = newPos;
        }

    }

}
