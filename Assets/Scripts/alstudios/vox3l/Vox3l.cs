//
//  Vox3l.cs
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
using alstudios.vox3l.helpers;
using alstudios.vox3l.settings;

namespace alstudios.vox3l
{
	
	public class Vox3l : Singleton<Vox3l>
	{
		
		#region Variables

		public DirectorySettings Directories;

		private bool _initialized;

		#endregion

		#region Constructors

		private Vox3l()
		{
		}

		#endregion

		#region Vox3l

		public void Initialize(DirectorySettings directorySettings)
		{
			if(_initialized)
				throw new System.Exception("One or more Mods are trying to initialize Vox3l; this is an internal method and should not be touched by Mods!");

			Directories = directorySettings;

			EventBus.INSTANCE.Trigger(new GuiEvent.Open(new GuiScreenStartup()));

			// Initialize Blocks/Items/Entities/etc.
			// Register/Load Mod Content

			// Localizations
			// Resource Packs

//			EventBus.INSTANCE.Trigger(new GuiEvent.Open(new GuiMenuMain()));

			_initialized = true;
		}

		public void Quit(object source)
		{
		}

		#endregion

	}

}

