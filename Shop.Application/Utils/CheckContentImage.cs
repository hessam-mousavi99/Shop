﻿using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Text.RegularExpressions;


namespace Shop.Application.Utils
{
    public static class CheckContentImage
    {
        #region check image
        public const int ImageMinimumBytes = 512;

        public static bool IsImage(this IFormFile postedFile)
        {
            //-------------------------------------------
            //  Check the image mime types
            //-------------------------------------------
            if (postedFile.ContentType.ToLower() != "image/jpg" &&
                        postedFile.ContentType.ToLower() != "image/jpeg" &&
                        postedFile.ContentType.ToLower() != "image/pjpeg" &&
                        postedFile.ContentType.ToLower() != "image/x-png" &&
                        postedFile.ContentType.ToLower() != "image/png")
            {
                return false;
            }

            //-------------------------------------------
            //  Check the image extension
            //-------------------------------------------
            if (Path.GetExtension(postedFile.FileName).ToLower() != ".jpg"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".png"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".jpeg")
            {
                return false;
            }

            //-------------------------------------------
            //  Attempt to read the file and check the first bytes
            //-------------------------------------------
            try
            {
                if (!postedFile.OpenReadStream().CanRead)
                {
                    return false;
                }
                //------------------------------------------
                //check whether the image size exceeding the limit or not
                //------------------------------------------ 
                if (postedFile.Length < ImageMinimumBytes)
                {
                    return false;
                }

                byte[] buffer = new byte[ImageMinimumBytes];
                postedFile.OpenReadStream().Read(buffer, 0, ImageMinimumBytes);
                string content = System.Text.Encoding.UTF8.GetString(buffer);
                if (Regex.IsMatch(content, @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            //-------------------------------------------
            //  Try to instantiate new Bitmap, if .NET will throw exception
            //  we can assume that it's not a valid image
            //-------------------------------------------

            try
            {
                using (var bitmap = new System.Drawing.Bitmap(postedFile.OpenReadStream()))
                {
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                postedFile.OpenReadStream().Position = 0;
            }

            return true;
        }
        #endregion

        #region check video 

        public static bool IsFile(this IFormFile postedFile)
        {
            //-------------------------------------------
            //  Check the image mime types
            //-------------------------------------------
            if (postedFile.ContentType.ToLower() != "video/mp4" &&
                        postedFile.ContentType.ToLower() != "video/mkv" &&
                        postedFile.ContentType.ToLower() != "video/mpv" &&
                        postedFile.ContentType.ToLower() != "application/octet-stream" &&
                        postedFile.ContentType.ToLower() != "application/x-zip-compressed")
            {
                return false;
            }

            //-------------------------------------------
            //  Check the image extension
            //-------------------------------------------
            if (Path.GetExtension(postedFile.FileName).ToLower() != ".mp4"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".mpv"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".mkv"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".rar"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".zip")
            {
                return false;
            }

            //-------------------------------------------
            //  Attempt to read the file and check the first bytes
            //-------------------------------------------
            try
            {
                if (!postedFile.OpenReadStream().CanRead)
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        #endregion

    }
}
