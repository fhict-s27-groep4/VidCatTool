using Microsoft.AspNetCore.Http;
using Service_Layer.SessionExtension;
using Service_Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Service_Layer.RequestHandlers
{
    public class PictureHandler
    {
        private readonly SessionHandler sessionHandler;

        public PictureHandler(SessionHandler sessionHandler)
        {
            this.sessionHandler = sessionHandler ?? throw new NullReferenceException();
        }

        public bool PictureCopy(IFormFile file, string userid)
        {
            string filePath = @"..\ProfilePictures\" + userid;
            switch (file.ContentType)
            {
                case "image/jpg":
                    filePath += ".jpg";
                    break;
                case "image/jpeg":
                    filePath += ".jpeg";
                    break;
                case "image/png":
                    filePath += ".png";
                    break;
                default:
                    return false;
            }
            bool fail = false;
            bool opened = false;
            FileStream fileStream = null;
            try
            {
                fileStream = File.Create(filePath);
                opened = true;
                file.CopyTo(fileStream);
            }
            catch
            {
                fail = true;
            }
            finally
            {
                if (opened)
                {
                    fileStream.Close();
                }
            }
            if (fail)
            {
                return false;
            }
            return true;
        }

        public string GetPictureWithUserID(string userID)
        {
            string folderPath = @"..\ProfilePictures";
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] pictures = dir.GetFiles(userID + "*");
            if(pictures.Count() > 0)
            {
                return pictures[0].FullName;
            }
            return null;
        }
    }
}
