using Cafeteria2;
using Cafeteria2.Controllers;
using Cafeteria2.Modelos;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;

namespace CafeteriaControllerTest
{
    public class BebidasControllerTest
    {
        private BebidasController _controller;

        private BebidasController _controllerMock;

        private Mock<BebidasModel> _mockBebidasModel = new Mock<BebidasModel>();

        [SetUp]
        public void Setup()
        {
            ///_controller = new BebidasController();
            _controllerMock = new BebidasController(_mockBebidasModel.Object);
        }

        [Test]
        public void BebidasController_Crear_DebeController()
        {

            ///Assert
            Assert.NotNull(_controller);
        }


        [Test]
        public void BebidasController_GetAll_DebeTraerTegistros()
        {
            ///Arrenge

            _mockBebidasModel
                .SetupAllProperties();

            _mockBebidasModel.Setup(
                    mock => mock.GetAll()
                )
                .Returns(new List<Bebidas>() { new Bebidas(), new Bebidas() });

            ///Assert
            var response = _controllerMock.Get() as OkNegotiatedContentResult<List<Bebidas>>;

            
            ///Assert
            Assert.NotNull(_controllerMock);
            Assert.True(response.Content.Any());
        }


        [Test]
        public void BebidasController_GetById_Ok( [Range(1,5)] int id)
        {
            ///Arrenge
            _mockBebidasModel.Setup(
                    mock => mock.GetById(It.IsAny<int>())
                )
            .Returns(new Bebidas());


            /// Assert
            var response = _controllerMock.Get(id) as OkNegotiatedContentResult<Bebidas>;


            /// Assert
            Assert.NotNull(response.Content);
        }

        [Test]
        public void BebidasController_GetAllById_DebeLanzarError()
        {
            ///Arrenge
            _mockBebidasModel.Setup(
                    mock => mock.GetById(0)
                )
                .Throws<Exception>();


            /// Assert
            var response = _controllerMock.Get(0);


            /// Assert
            Assert.IsInstanceOf<InternalServerErrorResult>(response);
        }

        [TearDown]
        public void TearDown()
        {
            _mockBebidasModel.Invocations.Clear();
        }

    }
}