using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace Adomicilio.Models
{
    public class ImageUtils
    {
        
       public static byte[] ImageToByteArray(Image x)
    {
        ImageConverter _imageConverter = new ImageConverter();
        byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
        return xByte;
    }
    public Image byteArrayToImage(byte[] byteArrayIn)
   {
    MemoryStream ms = new MemoryStream(byteArrayIn);
    Image returnImage = Image.FromStream(ms);
    return returnImage;
    }
    }
  

}