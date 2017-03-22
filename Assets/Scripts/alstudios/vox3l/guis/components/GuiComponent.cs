//
//  GuiComponent.cs
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

namespace alstudios.vox3l.guis
{
	
	public abstract class GuiComponent
	{

		#region Variables

		public int X;
		public int Y;

		public int Width;
		public int Height;

		#endregion

		#region Constructors

		public GuiComponent(int x, int y, int width, int height)
		{
			X = x;
			Y = y;

			Width = width;
			Height = height;
		}

		#endregion

		#region Object

		public override bool Equals(object obj)
		{
			if(!(obj is GuiComponent))
				return false;

			GuiComponent other = (GuiComponent) obj;
			return X.Equals(other.X) && Y.Equals(other.Y) && Width.Equals(other.Width) && Height.Equals(other.Height);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = 47;

				hash *= 227 + X.GetHashCode();
				hash *= 227 + Y.GetHashCode();

				hash *= 227 + Width.GetHashCode();
				hash *= 227 + Height.GetHashCode();

				return hash;
			}
		}

		#endregion

	}

}

