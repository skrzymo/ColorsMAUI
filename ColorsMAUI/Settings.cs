using System;
using System.Globalization;
using System.Xml.Linq;

namespace ColorsMAUI
{
	internal static class Settings
	{
		private static readonly string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "colors.xml");

		private static readonly IFormatProvider formatProvider = CultureInfo.InvariantCulture;

		public static void Save(double r, double g, double b)
        {
			XDocument xml = new XDocument(
				new XElement("settings",
					new XElement("r", r.ToString(formatProvider)),
					new XElement("g", g.ToString(formatProvider)),
					new XElement("b", b.ToString(formatProvider))
				)
			);

			xml.Save(filePath);
        }

		public static (double r, double g, double b) Load()
        {
			if (!File.Exists(filePath))
				return (0.0, 0.0, 0.0);

			try
            {
				XDocument xml = XDocument.Load(filePath);
				double r = double.Parse(xml.Root.Element("r").Value, formatProvider);
				double g = double.Parse(xml.Root.Element("g").Value, formatProvider);
				double b = double.Parse(xml.Root.Element("b").Value, formatProvider);

				return (r, g, b);
			}
			catch
            {
				return (0.0, 0.0, 0.0);
            }
        }
	}
}

