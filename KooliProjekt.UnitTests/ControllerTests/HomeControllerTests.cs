﻿using Xunit;
using KooliProjekt.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace KooliProjekt.UnitTests.ControllerTests
{
    public class HomeControllerTests
    {
        
        [Fact]
        public void Index_should_return_index_view()
        {

            // Arrange
            var controller = new HomeController();
            

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(string.IsNullOrEmpty(result.ViewName) ||
                        result.ViewName == "Index");
        }
        [Fact]
        public void Privacy_should_return_privacy_view()
        {

            // Arrange
            var controller = new HomeController();
            

            // Act
            var result = controller.Privacy() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(string.IsNullOrEmpty(result.ViewName) ||
                        result.ViewName == "Privacy");
        }

    }
}