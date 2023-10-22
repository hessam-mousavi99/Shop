﻿namespace Shop.Application.Utils
{
    public static class PathExtensions
    {
        #region user avatar

        public static string UserAvatarOrgin="/img/userAvatar/orgin/";
        public static string UserAvatarOrginServer=Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/userAvatar/orgin/");

        public static string UserAvatarThumb = "/img/userAvatar/thumb/";
        public static string UserAvatarThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/userAvatar/thumb/");

        #endregion

        #region product categories

        public static string CategoryOrgin = "/img/category/orgin/";
        public static string CategoryOrginServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/category/orgin/");

        public static string CategoryThumb = "/img/category/thumb/";
        public static string CategoryThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/category/thumb/");

        #endregion

        #region product

        public static string ProductOrgin = "/img/product/orgin/";
        public static string ProductOrginServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/product/orgin/");

        public static string ProductThumb = "/img/product/thumb/";
        public static string ProductThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/product/thumb/");

        #endregion

        #region slider

        public static string SliderOrgin = "/img/slider/orgin/";
        public static string SliderOrginServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/slider/orgin/");

        public static string SliderThumb = "/img/slider/thumb/";
        public static string SliderThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/slider/thumb/");

        #endregion
    }
}
