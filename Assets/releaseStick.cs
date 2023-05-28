using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class releaseStick : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] Slider s;
    public void OnPointerUp(PointerEventData e)
    {
        s.value = 0;
    }
}
