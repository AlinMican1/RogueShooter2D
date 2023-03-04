using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
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

    private void Start()
    {
        SightMesh = new Mesh();
        SightMesh.name = "Sight Mesh";
        SightFilter.mesh = SightMesh;
    }

    //function for the angle we are facing in degrees which is converted into radiants.
    public Vector3 AngleFromDirection(float angle, bool GlobalAngle)
    {
        if (GlobalAngle == false)
        {
            angle -= transform.eulerAngles.z;
        }
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad));
    }
    /*public Vector3 AngleFromDirection(float angle, bool GlobalAngle)
    {
        if(GlobalAngle == false)
        {
            angle -= transform.eulerAngles.z;
        }
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
    }*/
    
    //Draw rays bewteen the FOV angle.
    void DrawFOVRays()
    {
        int stepCount = Mathf.RoundToInt(Angle * Resolution);
        float AngleSize = Angle / stepCount;
        List<Vector3> SightPoints = new List<Vector3>();
        for(int i = 0; i <= stepCount; i++)
        {

            float angle = (transform.eulerAngles.z - Angle / 2)*-1 + AngleSize * i;
            
            RayCastInfo newRayCast = RayCastSight(angle);
            SightPoints.Add(newRayCast.EndPoint);
        }
        int VertexCount = SightPoints.Count + 1;
        Vector3[] vertices = new Vector3[VertexCount];
        int[] triangles = new int[(VertexCount - 2) * 3];

        vertices[0] = Vector3.zero;
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
        SightMesh.Clear();
        SightMesh.vertices = vertices;
        SightMesh.triangles = triangles;
        SightMesh.RecalculateNormals();
    }
    RayCastInfo RayCastSight(float globalAngle)
    {
        Vector3 direction = AngleFromDirection(globalAngle, true);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, ((int)SightRadius), obstacleMask);
        if (hit.collider != null)
        {
            return new RayCastInfo(true, hit.distance, globalAngle, hit.point);
        }
        return new RayCastInfo(false, SightRadius, globalAngle, transform.position + direction * SightRadius);
    }
    //Handle rayCasts information
    public struct RayCastInfo
    {
        public float DistanceRay;
        public float AngleRay;
        public bool RayHit;
        public Vector3 EndPoint;

        public RayCastInfo(bool RayHit, float DistanceRay, float AngleRay, Vector3 EndPoint)
        {
            this.DistanceRay = DistanceRay;
            this.AngleRay = AngleRay;
            this.RayHit = RayHit;
            this.EndPoint = EndPoint;
        }

    }
    
    private void LateUpdate()
    {
        DrawFOVRays();
    }
}


