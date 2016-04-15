using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingPoints : MonoBehaviour
{
    public GameObject criticalImage;
    public Text damagePoints;
    public string chestDamage;
    public string legDamage;
    public string headDamage;
    private Animator anim;
    private Animator animHead;

	// Use this for initialization
	void Start ()
	{
	    anim = damagePoints.GetComponent<Animator>();
	    animHead = criticalImage.GetComponent<Animator>();
	    Debug.Log(anim);
	    Debug.Log(animHead);
	    damagePoints = damagePoints.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    FloatingDamage();
	}

    private void FloatingDamage()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        int rayLength = 20;
        Debug.DrawRay(transform.position, fwd*rayLength, Color.green);

        if (Input.GetButtonDown("Fire1") && Physics.Raycast(transform.position, fwd, out hit, rayLength))
        {
            Debug.Log("Fires raycast");
            Debug.Log(hit.transform.name);
            Debug.Log(hit.transform.tag);
            if (hit.transform.tag == "chestDamage")
            {
                Debug.Log("Hits chest");
                anim.SetTrigger("dam");
                damagePoints.text = chestDamage;
            }
            if (hit.transform.tag == "legDamage")
            {
                Debug.Log("Hits legs");
                anim.SetTrigger("dam");
                damagePoints.text = legDamage;
            }
            if (hit.transform.tag == "headDamage")
            {
                Debug.Log("Hits head");
                anim.SetTrigger("dam");
                animHead.SetTrigger("head");
                damagePoints.text = headDamage;
            }
        }
    }
}
