using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonLight : MonoBehaviour {

    public float lightRadius;
    [Range(0, 360)]
    public float lightAngle;

    public Vector3 mousePos;

    public Char_control _char;
    //public GameObject Direction;

    public int meshResolution;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public MeshFilter viewMeshFilter; //mesh untuk lighting
    Mesh viewMesh;

    // Use this for initialization
    void Start () {
        viewMesh = new Mesh();
        viewMesh.name = "View Mesh";
        viewMeshFilter.mesh = viewMesh;
    }
	
	// Update is called once per frame
	void Update () {
        mousePos=_char._mousePos;
        print(mousePos);

        DrawRaycast();
    }

    void DrawRaycast(){
        int rayCount = meshResolution;
        float rayAngleSize = lightAngle / (rayCount);

        List<Vector3> rayPoints = new List<Vector3>();

        for (int i = 0; i <= rayCount; i++)
        {
            float angle = transform.eulerAngles.z - lightAngle / 2 + rayAngleSize * i;
            Debug.DrawLine(transform.position, transform.position + DirFromAngle(angle, true) * lightRadius, Color.red);
            RayCastInfo newRayCastInfo = RayCasting(angle);
            rayPoints.Add(newRayCastInfo.point);
        }


        int vertexCount = rayPoints.Count+1;
        Vector3[] vertices = new Vector3[vertexCount+1];
        int[] triangles = new int[(vertexCount - 2) * 3];

        print("vertex count "+vertexCount);
        print("ray point " + rayPoints.Count);
        print("vertices count" + vertices.Length);

        vertices[0] = Vector3.zero;
        for (int i = 0; i < vertexCount-1; i++){

            vertices[i+1] = transform.InverseTransformPoint(rayPoints[i]);

            if (i < vertexCount - 2)
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }
        }

        viewMesh.Clear();

        viewMesh.vertices = vertices;
        viewMesh.triangles = triangles;
        viewMesh.RecalculateNormals();
    }

    RayCastInfo RayCasting(float globalAngle){
        Vector3 direction = DirFromAngle(globalAngle, true);
        //RaycastHit2D hit2D;
        RaycastHit hit;

        //if (Physics2D.Raycast(transform.position,direction,out hit,lightRadius,obstacleMask)){

        //}
        if (Physics.Raycast(transform.position,direction,out hit,lightRadius,obstacleMask)){
            print("hit!");
            return new RayCastInfo(true, hit.point, hit.distance, globalAngle);
        }
        else{
            print("not Hit");
            return new RayCastInfo(false, transform.position + direction * lightRadius, lightRadius, globalAngle);
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees,bool angleIsGlobal)
    {
        //print("");

        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.z;
        }
          
        return new Vector3(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0);
    }

    public struct RayCastInfo
    {
        public bool hit;
        public Vector3 point;
        public float dst;
        public float angle;

        public RayCastInfo(bool _hit, Vector3 _point, float _dst, float _angle)
        {
            hit = _hit;
            point = _point;
            dst = _dst;
            angle = _angle;
        }
    }
}
