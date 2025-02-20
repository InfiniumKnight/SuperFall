using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DoorTrigger : MonoBehaviour
{
    [Header("door Animator")]
    public Animator doorAnimator;

    private void OnTriggerEnter(Collider other)
    {
        // detect player)
        if (other.CompareTag("Player"))
        {
            
            // doorAnimator.SetTrigger("OpenDoor");

            // 如果你直接呼叫特定動畫名稱：
            doorAnimator.Play("DoorOpen");

            Debug.Log("door trigger");
        }
    }
}
