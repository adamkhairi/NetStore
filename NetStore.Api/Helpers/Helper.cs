using System;
using System.IO;
using ImageUploader;

namespace NetStore.Api.Helpers
{
    public static class Helper
    {
        public static bool uploadImg(byte[] imgByte,string folder)
        {
            var imgStream = new MemoryStream(imgByte != null ? imgByte : new byte[] { });
            var imgName = Guid.NewGuid().ToString();
            var img = $"{imgName}.jpg";
            var productImgFolder = folder;

            return FilesHelper.UploadImage(imgStream, productImgFolder, imgName);
        }
    }
}
