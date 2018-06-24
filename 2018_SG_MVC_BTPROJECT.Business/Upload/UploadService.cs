using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
 

 
namespace _2018_SG_MVC_BTPROJECT.Business.Upload
{
    public class UploadService : IDisposable
    {
        protected HttpPostedFileBase _postedFile;
        protected string FileExtension
        {
            get;
            private set;

        }
        protected string RealFileName
        {
            get;
            private set;

        }

        public UploadService(HttpPostedFileBase postedFile)
        {
            _postedFile = postedFile;
            string[] nameArray = _postedFile.FileName.Split('.');
            FileExtension = nameArray[nameArray.Length - 1];
            RealFileName = nameArray[0];
        }


        public virtual FileUploadResult Upload(string virtualPath, string SmallPath, string LargePath, string fileName)
        {
            //string path = HttpContext.Current.Server.MapPath(virtualPath);
            string SmallImagepath = HttpContext.Current.Server.MapPath(SmallPath);
            string LargeImagepath = HttpContext.Current.Server.MapPath(LargePath);
            //string uniqFileName = CreateUniqName(fileName.ToString(), path);
            //string SmalluniqFileName = CreateUniqName(fileName.ToString(), SmallPath);
            //string LargeuniqFileName = CreateUniqName(fileName.ToString(), LargePath);
            Image photoThumb = Image.FromStream(_postedFile.InputStream, true, true);

            //_postedFile.SaveAs(path + "/" + uniqFileName);
            //if (Width==0 && Height==0 )
            //{
            //    _postedFile.SaveAs(path + "/" + uniqFileName);
            //}
            //else
            //{
            //    FixedSize(SmalluniqFileName, photoThumb, 256, 236, true);
            //    FixedSize(LargeuniqFileName, photoThumb, 256, 236, true);

            //}

            string photoPropertyName = Path.GetFileName(fileName);
            string photoPropertyToPath = Path.Combine(HttpContext.Current.Server.MapPath(virtualPath), photoPropertyName);
            _postedFile.SaveAs(photoPropertyToPath);



            string ph = Path.Combine(SmallImagepath, fileName);
            string phl = Path.Combine(LargeImagepath, fileName);
            FixedSize(ph, photoThumb, 100, 100, true);
            FixedSize(phl, photoThumb, 200, 200, true);


            return new FileUploadResult
            {
                //FilePath = path + "/" + uniqFileName,
                FilePath = fileName,
                IsSuccess = true,
                Message = "Upload işleminiz gerçekleşti",
            };


        }


        // Generate thumbnail from Image
        public static void FixedSize(string filePathName, Image image, int Width, int Height, bool needToFill)
        {

            Bitmap bmpThumb = null;
            try
            {
                int sourceWidth = image.Width;
                int sourceHeight = image.Height;
                int sourceX = 0;
                int sourceY = 0;
                double destX = 0;
                double destY = 0;

                double nScale = 0;
                double nScaleW = 0;
                double nScaleH = 0;

                nScaleW = ((double)Width / (double)sourceWidth);
                nScaleH = ((double)Height / (double)sourceHeight);
                if (!needToFill)
                {
                    nScale = Math.Min(nScaleH, nScaleW);
                }
                else
                {
                    nScale = Math.Max(nScaleH, nScaleW);
                    destY = (Height - sourceHeight * nScale) / 2;
                    destX = (Width - sourceWidth * nScale) / 2;
                }

                if (nScale > 1)
                    nScale = 1;

                int destWidth = (int)Math.Round(sourceWidth * nScale);
                int destHeight = (int)Math.Round(sourceHeight * nScale);

                bmpThumb = new Bitmap(destWidth + (int)Math.Round(2 * destX), destHeight + (int)Math.Round(2 * destY));

                using (Graphics graphic = Graphics.FromImage(bmpThumb))
                {
                    graphic.Clear(Color.White);
                    graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphic.SmoothingMode = SmoothingMode.HighQuality;
                    graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphic.CompositingQuality = CompositingQuality.HighQuality;

                    Rectangle to = new System.Drawing.Rectangle((int)Math.Round(destX), (int)Math.Round(destY), destWidth, destHeight);
                    Rectangle from = new System.Drawing.Rectangle(sourceX, sourceY, sourceWidth, sourceHeight);

                    graphic.DrawImage(image, to, from, System.Drawing.GraphicsUnit.Pixel);
                    image = bmpThumb;
                    // created thumbnail is uploaded
                    image.Save(filePathName);
                    // _postedFile.SaveAs(path + "/" + uniqFileName);
                }//done with drawing on "graphic"
            }
            catch
            { //error before IDisposable ownership transfer
                if (bmpThumb != null) bmpThumb.Dispose();
                // throw;
            }
        }

        public static Image ResizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);
            nPercent = nPercentH < nPercentW ? nPercentH : nPercentW;

            var destWidth = (int)(sourceWidth * nPercent);
            var destHeight = (int)(sourceHeight * nPercent);

            var b = new Bitmap(destWidth, destHeight);
            var g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            imgToResize.Dispose();
            return (Image)b;
        }




        public string CreateUniqName(string fileName, string path)
        {
            string filePath = "";
            string uniqnumber = Guid.NewGuid().ToString("N");
            int i = 0;
            do
            {
                if (i == 0)
                    filePath = uniqnumber + '_' + RealFileName + "." + FileExtension;
                else filePath = fileName + i + "." + FileExtension;
                ++i;
            } while (File.Exists(path + "\\" + filePath));
            return filePath;

        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
