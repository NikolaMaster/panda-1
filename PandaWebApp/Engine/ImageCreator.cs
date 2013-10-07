using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.Helpers;

namespace PandaWebApp.Engine
{
    public class ImageCreator
    {
        private const string CachePath = "/Content/img/cache/";
        private const string ImgPath = "/Content/img/";
        private const int MaxWidth = 800;
        private const int MaxHeight = 600;

        private static string generatePath(string srcImagePath, int width, int height)
        {
            var ext = Path.GetExtension(srcImagePath);
            return CachePath + Crypt.GetMD5Hash(srcImagePath + width + height) + ext;
        }

        public static string Create(string src, int width, int height)
        {
            var sourcePath = HttpContext.Current.Server.MapPath(src);
            if (string.IsNullOrEmpty(sourcePath) || !File.Exists(sourcePath))
            {
                return string.Empty;
            }
            using (var srcBitmap = new Bitmap(sourcePath))
            {
                var s = Math.Min((double)width / srcBitmap.Width, (double)height / srcBitmap.Height);
                var w = (int)(s * srcBitmap.Width);
                var h = (int)(s * srcBitmap.Height);

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

        public static void Crop(string src, int x1, int y1, int x2, int y2)
        {
            var sourcePath = HttpContext.Current.Server.MapPath(src);
            double kw, kh;
            using (var srcBitmap = new Bitmap(sourcePath))
            {
                kw = srcBitmap.Width > WebConstants.PhotoEditWidth ? (double)srcBitmap.Width / WebConstants.PhotoEditWidth : (double)1;
                kh = srcBitmap.Height > WebConstants.PhotoEditHeight ? (double)srcBitmap.Height / WebConstants.PhotoEditHeight : (double)1;
            }
            var width = (int)Math.Floor((x2 - x1) * kw);
            var height = (int)Math.Floor((y2 - y1) * kh);
            var x = (int)Math.Floor(x1 * kw);
            var y = (int)Math.Floor(y1 * kh);
            Create(src, new Rectangle(x, y, width, height));
        }

        public static void Create(string src, Rectangle crop)
        {
            var sourcePath = HttpContext.Current.Server.MapPath(src);
            if (string.IsNullOrEmpty(sourcePath) || !File.Exists(sourcePath))
            {
                return;
            }
            Bitmap cropped;
            using (var srcBitmap = new Bitmap(sourcePath))
            {
                cropped = srcBitmap.Clone(crop, srcBitmap.PixelFormat);
            }
            cropped.Save(sourcePath);
        }

        public static string SavePhoto(HttpPostedFileBase file)
        {
            var sourcePath = HttpContext.Current.Server.MapPath(ImgPath);
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            using (var srcBitmap = new Bitmap(file.InputStream))
            {
                var aspect = 1.0;
                if (srcBitmap.Width > MaxWidth)
                {
                    aspect = (double)MaxWidth / srcBitmap.Width;
                }
                if (srcBitmap.Height*aspect > MaxHeight)
                {
                    aspect = (double)MaxHeight / srcBitmap.Height;
                }
                using (
                    var destBitmap = new Bitmap(srcBitmap,
                                                new Size((int)(srcBitmap.Width*aspect), (int)(srcBitmap.Height*aspect))))
                {
                    destBitmap.Save(Path.Combine(sourcePath, fileName));
                }
            }
            return ImgPath + fileName;
        }

        public static string SavePhoto(string url)
        {
            var request = WebRequest.Create(url);
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                var contentType = response.ContentType;
                var ext = string.Empty;
                switch (contentType)
                {
                    case "image/png" : ext = ".png";break;
                    case "image/jpeg" : ext = ".jpg";break;
                    default:
                        throw new Exception("Unknown content type");
                }
                var sourcePath = HttpContext.Current.Server.MapPath(ImgPath);
                var fileName = Guid.NewGuid() + ext;

                // Download the file
                using (var file = File.OpenWrite(Path.Combine(sourcePath, fileName)))
                {
                    var buffer = new byte[4096];
                    int bytesRead;
                    do
                    {
                        bytesRead = stream.Read(buffer, 0, buffer.Length);
                        file.Write(buffer, 0, bytesRead);
                    } while (bytesRead != 0);

                    return ImgPath + fileName;
                }
            }
        }
    }
}