using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace MVVMExample.Game.Pawns
{
    public class MovePlayerToMousePoint : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);
                var hit = new RaycastHit[1];
                if (Physics.RaycastNonAlloc(ray, hit, 100f) > 0)
                {
                    var targetPosition = hit.First().point;
                    _agent.SetDestination(targetPosition);
                }
            }
        }
    }
}