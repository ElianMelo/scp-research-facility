using UnityEngine;

public class ThermalResearchButtonsController : MonoBehaviour
{
    [SerializeField] ThermalResearchRoomController controller;
    
    public void UpdateRoomLight(Color color)
    {
        controller.UpdateThermalLight(color);
    }
}
