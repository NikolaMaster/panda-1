﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PandaWebApp.Engine
{
    public class ImageCreator
    {
        private const string CachePath = "/Content/img/cache/";

        private static string generatePath(string srcImagePath, int width, int height)
        {
            var ext = Path.GetExtension(srcImagePath);
            return CachePath + Crypt.GetMD5Hash(srcImagePath + width + height) + ext;
        }

        public static string Create(string src, int? width, int? height)
        {
            var sourcePath = HttpContext.Current.Server.MapPath(src);
            if (string.IsNullOrEmpty(sourcePath) || !File.Exists(sourcePath))
            {
                return string.Empty;
            }
            using (var srcBitmap = new Bitmap(sourcePath))
            {
                var w = width.HasValue ? width.Value : srcBitmap.Width;
                var h = height.HasValue ? height.Value : srcBitmap.Height;

                var imagePath = generatePath(sourcePath, w, h);
                var mappedImagePath = HttpContext.Current.Server.MapPath(imagePath);
                if (File.Exists(mappedImagePath))
                {
                    return imagePath;
                }

                using (var destBitmap = new Bitmap(srcBitmap, new Size(w, h)))
                {
                    destBitmap.Save(mappedImagePath);
                    return imagePath;
                }
            }
        }
    }
}