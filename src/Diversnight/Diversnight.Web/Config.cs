using System.Runtime.CompilerServices;
using System.Web.Configuration;

namespace Diversnight.Web
{
    public static class Config
    {
        /* Stolen from https://github.com/tdwtf/WtfWebApp/ without remorse */

        public static class Diversnight
        {
            public static string Admins { get { return ReadFromFile(); } }

            private static string ReadFromFile([CallerMemberName] string key = null)
            {
                return WebConfigurationManager.AppSettings["Diversnight." + key];
            }
        }

        public static class Mandrill
        {
            public static string ApiKey { get { return ReadFromFile(); } }

            private static string ReadFromFile([CallerMemberName] string key = null)
            {
                return WebConfigurationManager.AppSettings["Mandrill." + key];
            }
        }

        public static class Facebook
        {
            public static string AppId { get { return ReadFromFile(); } }
            public static string AppSecret { get { return ReadFromFile(); } }

            private static string ReadFromFile([CallerMemberName] string key = null)
            {
                return WebConfigurationManager.AppSettings["Facebook." + key];
            }
        }

        public static class Instagram
        {
            public static string ClientId { get { return ReadFromFile(); } }
            public static string Tags { get { return ReadFromFile(); } }
            public static string ApiUrl { get { return ReadFromFile(); } }

            private static string ReadFromFile([CallerMemberName] string key = null)
            {
                return WebConfigurationManager.AppSettings["Instagram." + key];
            }
        }
    }
}