//
//  GuiEventHandler.cs
//
//  Author:
//       Tom Wright <arclight@alstudios.co.uk>
//
//  Copyright 2017  Tom Wright
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
using alstudios.vox3l.events;
using alstudios.vox3l.guis;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using alstudios.vox3l.unity.managers;

namespace alstudios.vox3l.unity.events
{
	
	public class GuiEventHandler
	{

		#region Variables

		public Canvas Canvas;
		public GameObject UIObject;

		private Dictionary<GuiComponent, GameObject> _Components;

		#endregion

		#region GuiEventHandler

		[EventListener]
		public void OnGuiOpenEvent(GuiEvent.Open eventArg)
		{
			CreateCanvas();

			if(UIObject != null)
			{
				for(int i = 0; i < UIObject.transform.childCount; i++)
					Object.Destroy(UIObject.transform.GetChild(i).gameObject);

				Object.Destroy(UIObject);
			}

			_Components = new Dictionary<GuiComponent, GameObject>();

			UIObject = CreateUIObject(eventArg.Source.GetType().Name, Canvas.transform);

			foreach(GuiComponent component in eventArg.Source.GetComponents())
			{
				GameObject componentGo = CreateUIObject(component.GetType().Name, UIObject.transform);
				RectTransform rt = componentGo.GetComponent<RectTransform>();

				rt.anchoredPosition = new Vector2(component.X, component.Y);
				rt.sizeDelta = new Vector2(component.Width, component.Height);

				if(component is GuiImage)
				{
					GuiImage guiImage = (GuiImage) component;

					Image image = componentGo.AddComponent<Image>();
					image.sprite = ResourceManager.CreateSprite(guiImage.Texture);
				}
			}
		}

		private void CreateCanvas()
		{
			if(Canvas != null)
				return;

			GameObject canvasGo = CreateUIObject("Canvas", null);

			Canvas canvas = canvasGo.AddComponent<Canvas>();
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;
			canvas.referencePixelsPerUnit = 256;
			canvas.pixelPerfect = true;

			CanvasScaler scaler = canvasGo.AddComponent<CanvasScaler>();
			scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
			scaler.referenceResolution = new Vector2(1920, 1080);
			scaler.referencePixelsPerUnit = 256;

			GraphicRaycaster raycaster = canvasGo.AddComponent<GraphicRaycaster>();
			raycaster.blockingObjects = GraphicRaycaster.BlockingObjects.None;
			raycaster.ignoreReversedGraphics = true;

			GameObject eventSystemGo = CreateUIObject("EventSystem", null);

			EventSystem eventSystem = eventSystemGo.AddComponent<EventSystem>();
			eventSystem.pixelDragThreshold = 5;
			eventSystem.sendNavigationEvents = false;

			StandaloneInputModule inputModule = eventSystemGo.AddComponent<StandaloneInputModule>();
			inputModule.submitButton = "Submit";
			inputModule.cancelButton = "Cancel";
			inputModule.horizontalAxis = "Horizontal";
			inputModule.verticalAxis = "Vertical";
			inputModule.inputActionsPerSecond = 10;
			inputModule.repeatDelay = 0.5F;
			inputModule.forceModuleActive = false;

			Canvas = canvas;
		}

		private GameObject CreateUIObject(string name, Transform parent)
		{
			GameObject uiObject = new GameObject();
			uiObject.name = name;
			uiObject.layer = LayerMask.NameToLayer("UI");
			uiObject.transform.SetParent(parent);

			RectTransform rt = uiObject.AddComponent<RectTransform>();
			rt.anchorMin = new Vector2(0, 1);
			rt.anchorMax = new Vector2(0, 1);
			rt.pivot = new Vector2(0, 1);
			rt.anchoredPosition = new Vector2(0, 0);
			rt.sizeDelta = new Vector2(0, 0);

			return uiObject;
		}

		#endregion

	}

}

