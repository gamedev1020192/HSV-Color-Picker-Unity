using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HsvBoxSelector : MonoBehaviour, IPointerDownHandler//IDragHandler
{

    //public HSVPicker picker;
    public HSVDragger dragger;
    private RectTransform rectTransform;
    

	// Use this for initialization
	void Awake ()
	{
	    rectTransform = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void PlaceCursor(PointerEventData eventData)
    {

        var pos = eventData.position;

        //pos.x += rectTransform.sizeDelta.x / 2;
        //pos.y += rectTransform.sizeDelta.y / 2;
        //pos.x /= rectTransform.sizeDelta.x;
        //pos.y /= rectTransform.sizeDelta.y;

        //var pos = new Vector2(eventData.worldPosition.x - picker.hsvImage.rectTransform.position.x, picker.hsvImage.rectTransform.rect.height * picker.hsvImage.transform.lossyScale.y - (picker.hsvImage.rectTransform.position.y - eventData.worldPosition.y));
         Debug.Log(pos + " " + rectTransform.position);
        //pos.x /= picker.hsvImage.rectTransform.rect.width * picker.hsvImage.transform.lossyScale.x;
        //pos.y /= picker.hsvImage.rectTransform.rect.height * picker.hsvImage.transform.lossyScale.y;

		//dragger.rectTransform.InverseTransformPoint
        //dragger.SetSelectorPosition(pos.x, pos.y);

		//dragger.rectTransform.position = new Vector3(pos.x, pos.y, dragger.rectTransform.position.z);

		var m_Offset = Vector2.zero;
		if (rectTransform != null && RectTransformUtility.RectangleContainsScreenPoint(dragger.rectTransform, eventData.position, eventData.enterEventCamera))
		{
			Vector2 localMousePos;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(dragger.rectTransform, eventData.position, eventData.pressEventCamera, out localMousePos))
				m_Offset = localMousePos;
		}

		RectTransform clickRect = dragger.rectTransform;
		Vector2 localCursor;
			if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(clickRect, eventData.position, Camera.main, out localCursor))
				return;
			localCursor -= clickRect.rect.position;
			
			float val = ((localCursor - m_Offset).x / clickRect.rect.size.x);

		clickRect.localPosition = new Vector3(val, 1, 0);

			//normalizedValue = (reverseValue ? 1f - val : val);


    }


    public void OnDrag(PointerEventData eventData)
    {
        PlaceCursor(eventData);
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PlaceCursor(eventData);
    }

    
}
