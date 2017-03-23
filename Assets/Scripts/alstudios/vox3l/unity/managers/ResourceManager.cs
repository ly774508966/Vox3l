//
//  ResourceManager.cs
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
using alstudios.vox3l.resources;

using UnityEngine;
using System.IO;

namespace alstudios.vox3l.unity.managers
{
	
	public static class ResourceManager
	{

		#region Variables

		#endregion

		#region Constructors

		static ResourceManager()
		{
		}

		#endregion

		#region ResourceManager

		public static Sprite CreateSprite(ResourceLocation texture)
		{
			Texture2D t2d = Resources.Load<Texture2D>(Path.Combine(texture.Domain, texture.Path));

			if(t2d == null)
				return null;

			return Sprite.Create(t2d, new Rect(0, 0, t2d.width, t2d.height), new Vector2(0.5F, 0.5F));
		}

		#endregion

	}

}

