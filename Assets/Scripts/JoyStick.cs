using UnityEngine;

public class JoyStick : MonoBehaviour
{
   RectTransform joyStickObj;
   public RectTransform Knob;

    public Vector2 joyStickObjAnchoredPosition
    {
        get { return joyStickObj.anchoredPosition; }
        set { joyStickObj.anchoredPosition = value; }
    }
    public Vector2 joyStickObjSizeDelta
    {
        get { return joyStickObj.sizeDelta; }
        set { joyStickObj.sizeDelta = value; }
    }

   private void Awake()
   {
      joyStickObj = GetComponent<RectTransform>();
   }
}