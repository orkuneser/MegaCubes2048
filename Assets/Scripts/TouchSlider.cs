using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TouchSlider : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityAction OnPointerDownEvent;
    public UnityAction<float> OnPointerDragEvent;
    public UnityAction OnPointerUpEvent;

    private Slider sliderObj;

    private void Awake()
    {
        sliderObj = GetComponent<Slider>();
        sliderObj.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        //
        if (OnPointerDragEvent != null)
        {
            OnPointerDragEvent.Invoke(value);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //
        if (OnPointerDownEvent!=null)
        {
            OnPointerDownEvent.Invoke();
        }

        if (OnPointerDragEvent != null)
        {
            OnPointerDragEvent.Invoke(sliderObj.value);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //
        if (OnPointerUpEvent!=null)
        {
            OnPointerUpEvent.Invoke();
        }

        // Reset Slider Value:
        sliderObj.value = 0f;
    }

    private void OnDestroy()
    {
        // Remove Listeners: to avoid memory leaks
        sliderObj.onValueChanged.RemoveListener(OnSliderValueChanged);
    }

}
