namespace ClashRoyale.Files.Sound
{
    using System.Collections.Generic;
    using System.IO;

    public static class SoundFiles
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="SoundFiles"/> is initialized.
        /// </summary>
        public static bool Initialized
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the musics.
        /// </summary>
        public static Dictionary<string, SoundFile> Musics
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the effects.
        /// </summary>
        public static Dictionary<string, SoundFile> Effects
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            if (SoundFiles.Initialized)
            {
                return;
            }

            string[] SfxFiles = Directory.GetFiles("Gamefiles/sfx/", "*.wav");
            string[] OggFiles = Directory.GetFiles("Gamefiles/music/", "*.ogg");

            SoundFiles.Effects = new Dictionary<string, SoundFile>(SfxFiles.Length);
            SoundFiles.Musics  = new Dictionary<string, SoundFile>(OggFiles.Length);

            foreach (string FilePath in SfxFiles)
            {
                FileInfo FileInfo = new FileInfo(FilePath);

                if (FileInfo.Exists)
                {
                    SoundFile SoundFile = new SoundFile(FileInfo);
                    SoundFiles.Effects.Add(SoundFile.Name, SoundFile);
                }
            }

            foreach (string FilePath in OggFiles)
            {
                FileInfo FileInfo = new FileInfo(FilePath);

                if (FileInfo.Exists)
                {
                    SoundFile SoundFile = new SoundFile(FileInfo);
                    SoundFiles.Musics.Add(SoundFile.Name, SoundFile);
                }
            }

            SoundFiles.Initialized = true;

            Logging.Info(typeof(SoundFiles), "Loaded " + (SoundFiles.Musics.Count + SoundFiles.Effects.Count) + " Wav/Ogg files.");
        }

        /// <summary>
        /// Search and return the correct <see cref="SoundFile" /> according to the given file name.
        /// </summary>
        /// <param name="Name">The file name.</param>
        public static SoundFile GetMusicFile(string Name)
        {
            if (SoundFiles.Musics.ContainsKey(Name))
            {
                return SoundFiles.Musics[Name];
            }

            return null;
        }

        /// <summary>
        /// Search and return the correct <see cref="SoundFile" /> according to the given file name.
        /// </summary>
        /// <param name="Name">The file name.</param>
        public static SoundFile GetEffectFile(string Name)
        {
            if (SoundFiles.Effects.ContainsKey(Name))
            {
                return SoundFiles.Effects[Name];
            }

            return null;
        }
    }
}