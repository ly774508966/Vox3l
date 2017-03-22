//
//  GuiImage.cs
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

namespace alstudios.vox3l.guis
{
	
	public class GuiImage : GuiComponent
	{

		#region Variables

		public ResourceLocation Texture;

		#endregion

		#region Constructors

		public GuiImage(ResourceLocation texture, int x, int y, int width, int height) : base(x, y, width, height)
		{
			Texture = texture;
		}

		#endregion

		#region Object

		public override bool Equals(object obj)
		{
			if(!base.Equals(obj))
				return false;

			if(!(obj is GuiImage))
				return false;

			GuiImage other = (GuiImage) obj;
			return Texture.Equals(other.Texture);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = base.GetHashCode();

				hash *= 227 + Texture.GetHashCode();

				return hash;
			}
		}

		#endregion

	}

}

