//
//  Vox3lController.cs
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
using alstudios.vox3l.settings;
using alstudios.vox3l.unity.events;

using UnityEngine;

namespace alstudios.vox3l.unity
{
	
	public class Vox3lController : MonoBehaviour
	{

		#region MonoBehaviour

		protected void Awake()
		{
			EventBus.INSTANCE.Register(new GuiEventHandler());
		}

		protected void Start()
		{
			Vox3l.INSTANCE.Initialize(new DirectorySettings(Application.persistentDataPath));
		}

		protected void OnApplicationQuit()
		{
			Vox3l.INSTANCE.Quit(this);
		}

		#endregion

	}

}

