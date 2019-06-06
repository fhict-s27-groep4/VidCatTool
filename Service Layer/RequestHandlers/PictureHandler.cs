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
            this.sessionHandler = null;
            this.sessionHandler = sessionHandler ?? throw new NullReferenceException();
        }

        public bool PictureCopy(IFormFile file)
        {
            string filePath = @"..\ProfilePictures\" + sessionHandler.Session.GetUserIDKey();
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
        public PictureManagementViewModelGet GetPictureWithUserID(string userID)
        {
            string folderPath = Path.GetFullPath(@"..\ProfilePictures");
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] pictures = dir.GetFiles(userID + "*");
            string path = null;
            if(pictures.Count() > 0)
            {
                path = pictures[0].FullName;
            }
            return new PictureManagementViewModelGet() { PicturePath = path } ;
        }
    }
}
