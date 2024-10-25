using System.Collections.Generic;
using  System.Configuration;
using System.Linq;

namespace FILE_MANAGER.Helper
{
	public static class AppConfig
	{
		private static string AppSettings(string key)
		{
			return ConfigurationManager.AppSettings.Get(key);
		}

		public static string WebPath => AppSettings("webPath");
		public static string WebImgPath => AppSettings("webImgPath");
		public static string MobPath => AppSettings("mobPath");
		public static string MobImgPath => AppSettings("mobImgPath");
		public static string MobBuildPath => AppSettings("mobBuildPath");
		public static string MobImgBuildPath => AppSettings("mobImgBuildPath");

		public static List<string>  AffMobilePaths => (AppSettings("affMobilePaths")?.Split(',')).ToList();
        public static List<string> AffWebPaths => (AppSettings("affWebPaths")?.Split(',')).ToList();
        public static List<string> Languages => (AppSettings("languages")?.Split(',')).ToList();
        public static List<string> LanguageCountryCodes => (AppSettings("languageCountryCodes")?.Split(',')).ToList();
        public static List<string> XMLErrorTags => (AppSettings("xmlErrorsTags")?.Split(',')).ToList();

        public static List<string> LanguagesUL => (AppSettings("languagesUL")?.Split(',')).ToList();
        public static List<string> LocalizationFolders => (AppSettings("localizationFolders")?.Split(',')).ToList();
    }
}
