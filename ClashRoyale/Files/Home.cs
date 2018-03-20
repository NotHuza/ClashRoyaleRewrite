namespace ClashRoyale.Files
{
    using System.IO;
    using System.Text;

    using Newtonsoft.Json.Linq;

    public static class Home
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Home" /> has been already initalized.
        /// </summary>
        public static bool Initalized
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the filename.
        /// </summary>
        public static string Filename
        {
            get
            {
                return Config.IsMaxedServer ? "starting_home_max.json" : "starting_home.json";
            }
        }

        /// <summary>
        /// Gets the json file content.
        /// </summary>
        public static JObject Json;

        /// <summary>
        /// Initializes a new instance of the <see cref="Home" /> class.
        /// </summary>
        public static void Initialize()
        {
            if (Home.Initalized)
            {
                return;
            }

            Home.Initalized = true;

            if (Directory.Exists("Gamefiles/level/"))
            {
                if (File.Exists("Gamefiles/level/" + Filename))
                {
                    string RawFile = File.ReadAllText("Gamefiles/level/" + Filename, Encoding.UTF8);

                    if (!string.IsNullOrEmpty(RawFile))
                    {
                        Home.Json = JObject.Parse(RawFile);
                    }
                    else
                    {
                        Logging.Error(typeof(Home), "string.IsNullOrEmpty(RawFile) == true at Initialize().");
                    }
                }
                else
                {
                    Logging.Error(typeof(Home), "File.Exists(Path) != true at Initialize().");
                }
            }
            else
            {
                Logging.Error(typeof(Home), "Directory.Exists(Path) != true at Initialize().");
            }
        }
    }
}