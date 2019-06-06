using Service_Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.ServiceLayer.ViewModelTests
{
    public class AlgoritmSettingsTest
    {
        AlgoritmSettingsModel model;
        public AlgoritmSettingsTest()
        {
            model = new AlgoritmSettingsModel();
        }
        [Fact]
        public void CheckGetSetEqual()
        {
            model.BiggestPercentIAB = 2.11;
            model.IabToleranceTier1 = 2.97;
            model.IabToleranceTier2 = 4.79;
            model.MaximumRatings = 80;
            model.PadTolerance = 3.56;
            Assert.Equal(2.11, model.BiggestPercentIAB);
            Assert.Equal(2.97, model.IabToleranceTier1);
            Assert.Equal(4.79, model.IabToleranceTier2);
            Assert.Equal(80, model.MaximumRatings);
            Assert.Equal(3.56, model.PadTolerance);
        }
        [Fact]
        public void CheckGetSetNotEqual()
        {
            model.BiggestPercentIAB = 2.71;
            model.IabToleranceTier1 = 2.87;
            model.IabToleranceTier2 = 4.72;
            model.MaximumRatings = 81;
            model.PadTolerance = 3.66;
            Assert.NotEqual(2.11, model.BiggestPercentIAB);
            Assert.NotEqual(2.97, model.IabToleranceTier1);
            Assert.NotEqual(4.79, model.IabToleranceTier2);
            Assert.NotEqual(80, model.MaximumRatings);
            Assert.NotEqual(3.56, model.PadTolerance);
        }
    }
}
