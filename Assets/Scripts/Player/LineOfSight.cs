using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    //Variables for the Field of view.
    [Header("Sight Variables")]
    public float Resolution;
    public float SightRadius;
    //Clamp values between 0 to 360.
    [Range(0, 360)]
    public float Angle;
    public LayerMask obstacleMask;
    public MeshFilter SightFilter;
    Mesh SightMesh;
    //Find the obstacle targets

    //Function: Start is called before the first frame update 
    private void Start()
    {
        SightMesh = new Mesh();
        SightMesh.name = "Sight Mesh";
        SightFilter.mesh = SightMesh;
    }

    //Function: The angle we are facing in degrees which is converted into radiants.
    public Vector3 AngleFromDirection(float angle, bool GlobalAngle)
    {
        
        if (GlobalAngle == false)
        {
            angle -= transform.eulerAngles.z;
        }
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad));
    }
   
    //Function: Draw rays bewteen the FOV angle.
    void DrawFOVRays()
    {
        int stepCount = Mathf.RoundToInt(Angle * Resolution);
        float AngleSize = Angle / stepCount;
        List<Vector3> SightPoints = new List<Vector3>();

        //
        for(int i = 0; i <= stepCount; i++)
        {
            //Calculate the angle the raycast is shot at, for every index value giving a new ray.
            float angle = (transform.eulerAngles.z - Angle / 2)*-1 + AngleSize * i;
            //Testing the rays
            Debug.DrawLine(transform.position, transform.position + AngleFromDirection(angle, true) * SightRadius, Color.red);
            
            //Add a new raycast vector to the list.
            RayCastInfo newRayCast = RayCastSight(angle);
            SightPoints.Add(newRayCast.EndPoint);
        }

        int VertexCount = SightPoints.Count + 1;
        Vector3[] vertices = new Vector3[VertexCount];
        int[] triangles = new int[(VertexCount - 2) * 3];

        vertices[0] = Vector3.zero;
        //Calculate the angle between the rays using triangles to fromulate it.
        for (int i = 0;i < VertexCount - 1; i++)
        {
            vertices[i + 1] = transform.InverseTransformPoint(SightPoints[i]);
            if(i<VertexCount - 2)
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }
            
        }
        //Sight Mesh will be used to define the amount of rays shot from the player, a balance needs to be found.
        //Too many rays will make the game less performant, whilst not many will make the line of sight jitter.
        SightMesh.Clear();
        SightMesh.vertices = vertices;
        SightMesh.triangles = triangles;
        SightMesh.RecalculateNormals();
    }

    //Function: It returns a struct of raycast information.
    RayCastInfo RayCastSight(float globalAngle)
    {
        Vector3 direction = AngleFromDirection(globalAngle, true);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, ((int)SightRadius), obstacleMask);
        //Check if the ray has hit something, if it hasn't then we return a raycast with true boolean, else return 
        //a raycast value with false boolean and shoot it to the end of the view distance.
        if (hit.collider != null)
        {
            return new RayCastInfo(true, hit.distance, globalAngle, hit.point);
        }
        return new RayCastInfo(false, SightRadius, globalAngle, transform.position + direction * SightRadius);
    }
    //Struct: Handle rayCasts information
    public struct RayCastInfo
    {
        //Raycast variables, hold information about the raycast.
        public float DistanceRay;
        public float AngleRay;
        public bool RayHit;
        public Vector3 EndPoint;

        //Constructor: making a raycast constructor.
        public RayCastInfo(bool RayHit, float DistanceRay, float AngleRay, Vector3 EndPoint)
        {
            this.DistanceRay = DistanceRay;
            this.AngleRay = AngleRay;
            this.RayHit = RayHit;
            this.EndPoint = EndPoint;
        }

    }
    //Function: it executes after all updates have been executed.
    private void LateUpdate()
    {
        //Calling the function DrawFOVRays.
        DrawFOVRays();
    }
}


