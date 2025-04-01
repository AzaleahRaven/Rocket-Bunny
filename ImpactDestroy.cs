using UnityEngine;

public class ImpactDestroy : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        if (anim != null)
        {
            Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
        }
        else
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
