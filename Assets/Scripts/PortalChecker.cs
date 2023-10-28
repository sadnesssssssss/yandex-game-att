using System.Linq;
using UnityEngine;

public class PortalChecker : MonoBehaviour
{
    [SerializeField] private ScorePortal _portalOne, _portalTwo;
    private string _firstOp;
    private string _secondOp;
    private void Start()
    {
        while (CheckOperations()){
            print("123");
            switch (Random.Range(0, 2))
            {
                case 0:
                    _portalOne.ChangeOperation();
                    break;
                default:
                    _portalTwo.ChangeOperation();
                    break;
            }
        }
    }

    private bool CheckOperations()
    {
        _firstOp = _portalOne.GetOperation();
        _secondOp = _portalTwo.GetOperation();
        var negOps = Operations.NegOperations;
        return (negOps.Contains(_firstOp) && negOps.Contains(_secondOp));
    }
}