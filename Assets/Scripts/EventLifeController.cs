using UnityEngine;

public class EventLifeController : MonoBehaviour
{
    [SerializeField] private TaskController task;
    [SerializeField] private GameObject bar;
    [SerializeField] private GameObject target;
    [SerializeField] private bool isLeft = true;
    [SerializeField] private Camera cam;

    void Update()
    {
        var targetPos = target.transform.position;

        cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        
        var pos = Camera.main.ViewportToWorldPoint(new Vector3(isLeft ? 0 : 1, 1));
        transform.position = new Vector3(pos.x + .5f * (isLeft ? 1 : -1), pos.y, 0);
        
        bar.transform.localScale = new Vector3(task.lifeTime / task.TimeToRefill, 1, 1);
    }
}
