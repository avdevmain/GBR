using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    public class RotateTowardsMouse : FsmStateAction
    {
        public Camera cam;
        public FsmFloat mouseX;
        public FsmFloat mouseY;
        public FsmVector3 resultVector3;

        void CalculateVector()
        {
            // Converting the mouse position to a point in 3D-space
            Vector3 point = cam.ScreenToWorldPoint(new Vector3(mouseX.Value, mouseY.Value, 1));
            // Using some math to calculate the point of intersection between the line going through the camera and the mouse position with the XZ-Plane
            float t = cam.transform.position.y / (cam.transform.position.y - point.y);
            Vector3 finalPoint = new Vector3(t * (point.x - cam.transform.position.x) + cam.transform.position.x, 1, t * (point.z - cam.transform.position.z) + cam.transform.position.z);
            //Rotating the object to that point
            //transform.LookAt(finalPoint, Vector3.up);
            resultVector3.Value = finalPoint;


        }


        public override void OnUpdate()
        {
            CalculateVector();
        }


    }
}
