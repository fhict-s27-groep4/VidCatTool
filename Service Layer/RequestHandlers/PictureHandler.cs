using Microsoft.AspNetCore.Http;
using Service_Layer.SessionExtension;
using Service_Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Service_Layer.RequestHandlers
{
    public class PictureHandler
    {
        private readonly SessionHandler sessionHandler;
        private string filePath = "";

        public PictureHandler(SessionHandler sessionHandler)
        {
            this.sessionHandler = null;
            this.sessionHandler = sessionHandler ?? throw new NullReferenceException();
        }

        public bool PictureCopy(IFormFile file)
        {
            if (!string.Equals(file.ContentType, "image/jpg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(file.ContentType, "image/jpeg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(file.ContentType, "image/png", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            string userid = sessionHandler.Session.GetUserIDKey();
            switch (file.ContentType)
            {
                case "image/jpg":
                    filePath = @"..\..\..\..\ProfilePictures\" + userid + ".jpg";
                    break;
                case "image/jpeg":
                    filePath = @"..\..\..\..\ProfilePictures\" + userid + ".jpeg";
                    break;
                case "image/png":
                    filePath = @"..\..\..\..\ProfilePictures\" + userid + ".png";
                    break;
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
        public PictureManagementViewModelGet GetUserIdWithPicture()
        {
            PictureManagementViewModelGet picVM = new PictureManagementViewModelGet();
            string path = @"..\..\..\..\ProfilePictures\" + sessionHandler.Session.GetUserIDKey().ToString();
            if (File.Exists(path + ".jpg"))
            {
                picVM = new PictureManagementViewModelGet() { PicturePath = path + ".jpg" };
            }
            else if (File.Exists(path + ".jpeg"))
            {
                picVM = new PictureManagementViewModelGet() { PicturePath = path + ".jpeg" };
            }
            else if (File.Exists(path + ".png"))
            {
                picVM = new PictureManagementViewModelGet() { PicturePath = path + ".png" };
            }
            else
            {
                picVM = new PictureManagementViewModelGet() { PicturePath = null };
            }
            return picVM;
        }
    }
}
