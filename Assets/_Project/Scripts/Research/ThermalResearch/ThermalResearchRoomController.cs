using UnityEngine;

public class ThermalResearchRoomController : MonoBehaviour
{
    [SerializeField] Light thermalLight;
    
    public void UpdateThermalLight(Color color)
    {
        thermalLight.color = color;
    }
}
