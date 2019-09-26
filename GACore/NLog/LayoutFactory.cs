namespace GACore.NLog
{
	public static class LayoutFactory
	{
		private static readonly string processLayout = @"${processtime} ${level: padding = -8:padCharacter = } ${message} ${exception:format=tostring}";

		private static readonly string longDateLayout = @"${longdate} ${level: padding = -8:padCharacter = } ${message} ${exception:format=tostring}";

		public static string ProcessLayout => processLayout;

		public static string LongDateLayout => longDateLayout;

		public static string DefaultLayout => longDateLayout;
	}
}