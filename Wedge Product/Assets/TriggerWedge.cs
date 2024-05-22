using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWedge : MonoBehaviour
{

    public Transform A;
    public Transform B;
    public Transform C;
    public Transform PT;
    Vector2 a;
    Vector2 b;
    Vector2 c;
    Vector2 pt;

    private void OnDrawGizmos()
    {
         a = A.position;
         b = B.position;
         c = C.position;
         pt = PT.position;

        Gizmos.DrawSphere(pt, 0.2f);
        Gizmos.color = Contains()? Color.red : Color.white;
        Gizmos.DrawLine(a, b);
        Gizmos.DrawLine(b, c);
        Gizmos.DrawLine(c, a);
       
        



    }

    bool WedgeContains(Vector2 a , Vector2 b)
    {
        return (a.x * b.y - a.y*b.x)< 0;
    }

    bool direction(Vector2 a , Vector2 b,Vector2 pt) {
        Vector2 dir = b-a;
        Vector2 dirPoint = pt - a;
        return WedgeContains(dir, dirPoint);
    }

    bool Contains()
    {
        bool ab = direction(a, b, pt);
        bool bc = direction(b, c, pt);
        bool ca = direction(c, a, pt);

        return ab && bc && ca;

    }

}
