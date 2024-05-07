using UnityEngine;

namespace MVVMExample.Game.Pawns
{
    public class RotateObjects : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        

        private void Update()
        {
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime, Space.World);
        }
    }
}