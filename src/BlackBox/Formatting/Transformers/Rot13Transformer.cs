﻿//
// Copyright 2011 Patrik Svensson
//
// This file is part of BlackBox.
//
// BlackBox is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// BlackBox is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU Lesser Public License for more details.
//
// You should have received a copy of the GNU Lesser Public License
// along with BlackBox. If not, see <http://www.gnu.org/licenses/>.
//

namespace BlackBox.Formatting
{
	[FormatRendererType("rot13")]
	internal sealed class Rot13Transformer : FormatTransformer
	{
		internal Rot13Transformer(FormatRenderer renderer)
			: base(renderer)
		{
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
		public override string Transform(string source)
		{
			if (source.IsNullOrEmpty())
			{
				return string.Empty;
			}

			// CREDITS: This algorithm was written by Sam Allen and can be found
			// in it's original state at http://dotnetperls.com/rot13.
			char[] array = source.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				int number = (int)array[i];

				if (number >= 'a' && number <= 'z')
				{
					if (number > 'm')
					{
						number -= 13;
					}
					else
					{
						number += 13;
					}
				}
				else if (number >= 'A' && number <= 'Z')
				{
					if (number > 'M')
					{
						number -= 13;
					}
					else
					{
						number += 13;
					}
				}
				array[i] = (char)number;
			}

			// Return the transformed source.
			return new string(array);
		}
	}
}
