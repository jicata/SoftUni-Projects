namespace WalkingGame.AnimationHandling
{
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public static class AssetBufferer
    {
        public static List<Texture2D> textures = new List<Texture2D>();
        public static Texture2D specialTexture;
        public static void BufferImages(ContentManager manager)
        {
            string path =
            @"C:\Users\Maika\Documents\visual studio 2015\Projects\CSharpOOP2PreludeWorkshop\WalkingGame\Content\FallingStuff"; // insert your own path here
            var currentDir = Directory.GetFiles(path);
            foreach (var fileName in currentDir)
            {
                string extractedFileName = fileName.Substring(fileName.LastIndexOf(@"\") - "FallingStuff".Length);
                string fileNameWithoutExtension = extractedFileName.Substring(0, extractedFileName.Length - 4);
                Texture2D texture = manager.Load<Texture2D>(fileNameWithoutExtension);
                if (texture.Name.Contains("bonus"))
                {
                    specialTexture = texture;
                }
                else
                {
                    textures.Add(texture);
                }
            }
        }
    }
}
