using UnityEngine;
using UnityEngine.EventSystems;

namespace Inputs
{
    public class JoyButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        public bool IsPressed;
        
        //Interfaz IPointrDown, sirve para enviar un evento cuando pulsas en la imagen o boton asociada
        public void OnPointerDown(PointerEventData eventData)
        {
            IsPressed = true;
        }
        
        //Metodo de la interfaz IPointerUp, igual pero al dejar de pulsar
        public void OnPointerUp(PointerEventData eventData)
        {
            IsPressed = false;
        }
        
    }
}