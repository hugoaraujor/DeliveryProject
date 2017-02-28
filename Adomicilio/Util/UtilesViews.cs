using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace Adomicilio.Models
{
    public class UtilesViews
    {
        public String bytestoimage(byte[] imageenbytes)
        {
            if (imageenbytes.Count() != 0)
            {
                MemoryStream ms = new MemoryStream(imageenbytes);
                Image imge = Image.FromStream(ms);

                String img2 = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray(), 0, ms.ToArray().Length);
                return img2;
            }
            else
                return "../../images/NOPHOTO.png";
        }
    }
}