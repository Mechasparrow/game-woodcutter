using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        string tag = hit.collider.gameObject.tag;
        GameObject go = hit.collider.gameObject;
        if (hit.collider.gameObject.CompareTag("tree_barrier"))
        {
            GameObject tree = go.transform.parent.gameObject.transform.parent.gameObject;
            bool cut = anim.GetCurrentAnimatorStateInfo(0).IsName("Cut");
            if (cut)
            {
                Tree t = tree.GetComponent<Tree>();
                t.beginCutting();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool mousePress = Input.GetMouseButtonDown(0);
        if (mousePress)
        {
            anim.SetTrigger("Cut");
        }
    }
}
