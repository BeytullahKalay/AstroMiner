using UnityEditor;
using UnityEngine;

namespace Gun
{
    public class GunMovement : MonoBehaviour
    {
        [SerializeField] private float rotateSpeed = 10f;

        [SerializeField] private Vector2 minMaxRotationZ;
        


        public void RotateGun(float rotateInput)
        {
            transform.Rotate(Vector3.forward * (rotateInput * rotateSpeed * Time.fixedDeltaTime));
            var clampedRotationZ = Mathf.Clamp(TransformUtils.GetInspectorRotation(transform).z, minMaxRotationZ.x, minMaxRotationZ.y);
            TransformUtils.SetInspectorRotation(transform,new Vector3(0,0,clampedRotationZ));
        }
    }
}
