using UnityEngine;

public class EyeSight : MonoBehaviour
{

    [Tooltip("Add a Game Object where the character will look from")]
    [SerializeField] GameObject eyes = null;
    [Tooltip("How far the character will see")]
    [SerializeField] float seeingRange = 20f;
    [Tooltip("Sight angle will only be up to 180 degrees. With 0 begin directly forward and 90 begin able to see completely left or right")]
    [SerializeField(), Range(0, 180)] float sightAngle = 80f;
    [Tooltip("The tag of the object that is to be returned.")]
    [SerializeField] string objectTag = "Player";

    Vector3 heading;
    float angle;

    private void Update()
    {
        if(Look() != null)
        {
            Debug.Log($"{Look().gameObject.name} has been seen");
        }
    }

    public GameObject Look()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, seeingRange, Vector3.up, 0);
        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.CompareTag(objectTag) && InSight(hit.transform.gameObject) && hit.transform.gameObject != this.gameObject)
            {
                Debug.DrawLine(eyes.transform.position, hit.transform.position, Color.yellow, 0.5f);  //Draws a line in the scene view to the object seen.
                return hit.transform.gameObject;
            }
        }
        return null;
    }

    private bool InSightAngle(GameObject target) //Checks to see if the object seen is within the angle that can be seen.
    {
        if (target == null) { return false; }
        heading = target.transform.position - eyes.transform.position;
        angle = Vector3.Angle(heading, eyes.transform.forward);
        return angle < sightAngle;
    }

    private bool InSight(GameObject target) //Checks to see if the object seen is obstructed by another object and is with in range and angle.
    {
        if (target == null) { return false; }
        
        RaycastHit hit;
        if ((target.transform.position - eyes.transform.position).sqrMagnitude >= seeingRange * seeingRange || !InSightAngle(target)) { return false; }
        
        return Physics.Linecast(eyes.transform.position, target.transform.position, out hit) && hit.transform.gameObject.name == target.gameObject.name;
    }
}
