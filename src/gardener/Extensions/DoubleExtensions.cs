using System;

namespace gardener.Extensions
{
	public static class DoubleExtensions
	{
		#region Public
		public static double Clamp(this double self, double min, double max) => Math.Min(max, Math.Max(self, min));
		#endregion
	}
}
