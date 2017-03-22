﻿//
//  Singleton.cs
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

namespace alstudios.vox3l.helpers
{

	public class Singleton<T>
	{

		#region Singleton

		private static T _Instance;

		public static T INSTANCE
		{
			get
			{
				if(_Instance == null)
					_Instance = (T) System.Activator.CreateInstance(typeof(T), true);

				return _Instance;
			}
		}

		#endregion

	}

}

