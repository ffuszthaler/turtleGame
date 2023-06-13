using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationEaseInOut
{
    public class EaseInOut
    {
        public static Vector3 MoveTowardSmoothstep(Vector3 source, Vector3 target, float t)
        {
            Vector3 position = new Vector3();
            if (t > 1) return target;
            else if (t < 0) return source;

            t = t * t * t * t * t;

            position = (target - source) * t + source;
            return position;
        }
    }
}