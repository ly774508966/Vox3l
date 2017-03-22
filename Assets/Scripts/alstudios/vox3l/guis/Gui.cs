//
//  Gui.cs
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
using System.Collections.Generic;

namespace alstudios.vox3l.guis
{
	
	public abstract class Gui
	{

		#region Variables

		private List<GuiComponent> _Components;

		#endregion

		#region Constructors

		public Gui(params object[] parameters)
		{
			_Components = new List<GuiComponent>();

			Initialize(parameters);
			BuildScreen();
		}

		#endregion

		#region Gui

		public virtual void Initialize(params object[] parameters)
		{
		}

		public virtual void BuildScreen()
		{
		}

		public void AddComponent(GuiComponent component)
		{
			_Components.Add(component);
		}

		public List<GuiComponent> GetComponents()
		{
			return _Components;
		}

		#endregion

	}

}

