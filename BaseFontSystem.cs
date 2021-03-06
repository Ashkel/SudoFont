using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Diagnostics;


namespace SudoFont
{
	// The SudoFont application interacts with fonts entirely through a BaseFontSystem.
	// There are two implementations of BaseFontSystem: one using .NET and one using Win32 APIs.
	// The Win32 API version can access more features and font types like .otf files.
	public interface IFontSystem
	{
		// Enumerate font family names.
		int NumFontFamilies { get; }
		IFontFamily GetFontFamily( int iFamily );

		// Lookup a font family by name.
		IFontFamily GetFontFamilyByName( string familyName );
		IFont CreateFont( string familyName, int size, FontStyle style, TextRenderingHint renderingHint );
	}

	public interface IFontFamily
	{
		string Name { get; }
		bool IsStyleAvailable( FontStyle style );
	}

	public interface IFont
	{
		string Name { get; }

		void DrawString( Graphics g, string str, Brush brush, Point location );

		float[] GetCharacterXPositions( Graphics g, string str );		// Gets the X offset of each character in the string.
		SizeF MeasureString( Graphics g, string str );

		float GetHeightInPixels( Control control );	// You must pass a Control here that can create a Graphics if this function needs one.
		float GetBaselinePos( Graphics g, FontStyle style );	// This returns the distance from the top of the font to the baseline that characters sit on.

		IFontFamily FontFamily { get; }
	}
}

