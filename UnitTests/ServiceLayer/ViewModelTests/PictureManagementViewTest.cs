using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Service_Layer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.IO;
using Moq;

namespace UnitTests.ServiceLayer.ViewModelTests
{
    public class PictureManagementViewTest
    {
        PictureManagementViewModelGet get;
        PictureManagementViewModelPost post;
        PictureManagementViewModel model;
        public PictureManagementViewTest()
        {
            
        }
        [Fact]
        public void CheckGetSetEqual()
        {
            get = new PictureManagementViewModelGet();
            post = new PictureManagementViewModelPost();
            get.PicturePath = "hello there dear reader";
            var fileMock = new Mock<IFormFile>();
            IFormFile file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 0, 0, "Data", "dummy.txt");
            post.File = file;
            model = new PictureManagementViewModel()
            {
                Get = get,
                Post = post
            };
            Assert.Equal("hello there dear reader", model.Get.PicturePath);
            Assert.Equal("Data", model.Post.File.Name);
            Assert.Equal(0, model.Post.File.Length);
            Assert.Equal("dummy.txt", model.Post.File.FileName);
        }
    }
}
