using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using FluentAssertions;
using HelloWebApi.Controllers;
using HelloWebApi.Models;
using HelloWebApi.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HelloWebApi.Tests
{
    [TestClass]
    public class GreetingsControllerTests
    {
        private const string ApiUrl = "http://testing.local/greetings";
        private readonly GreetingsController _controller;
        private readonly IGreetingRepository _repository;

        public GreetingsControllerTests()
        {
            _repository = Mock.Of<IGreetingRepository>();
            _controller = new GreetingsController(_repository, AutomapperConfig.Configure().CreateMapper())
            {
                Request = new HttpRequestMessage {RequestUri = new Uri(ApiUrl)},
                Configuration = new HttpConfiguration()
            };
        }

        [TestClass]
        public class GetAll : GreetingsControllerTests
        {
            private readonly HttpResponseMessage _response;

            public GetAll()
            {
                _response = _controller.Get().ExecuteAsync(new CancellationToken()).Result;
            }

            [TestMethod]
            public void ShouldReturnOk()
            {
                _response.StatusCode.Should().Be(HttpStatusCode.OK);
            }

            [TestMethod]
            public void ShouldCallGetAllOnRepository()
            {
                Mock.Get(_repository).Verify(x => x.GetAll());
            }

            [TestMethod]
            public void ShouldReturnGreetings()
            {
                IEnumerable<Greeting> greetings;
                _response.TryGetContentValue(out greetings).Should().BeTrue();
            }
        }

        [TestClass]
        public class Get : GreetingsControllerTests
        {
            private readonly HttpResponseMessage _errorResponse;
            private readonly HttpResponseMessage _okResponse;

            public Get()
            {
                Mock.Get(_repository).Setup(x => x.Get(1)).Returns(new Entities.Greeting());
                _okResponse = _controller.Get(1).ExecuteAsync(new CancellationToken()).Result;
                _errorResponse = _controller.Get(2).ExecuteAsync(new CancellationToken()).Result;
            }

            [TestMethod]
            public void ShouldReturnOk()
            {
                _okResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            }

            [TestMethod]
            public void ShouldReturnNotFound()
            {
                _errorResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }

            [TestMethod]
            public void ShouldCallGetOnRepository()
            {
                Mock.Get(_repository).Verify(x => x.Get(1));
            }

            [TestMethod]
            public void ShouldReturnGreeting()
            {
                Greeting greeting;
                _okResponse.TryGetContentValue(out greeting).Should().BeTrue();
            }
        }

        [TestClass]
        public class Add : GreetingsControllerTests
        {
            private readonly Greeting _greeting;
            private readonly HttpResponseMessage _response;

            public Add()
            {
                Mock.Get(_repository)
                    .Setup(x => x.Add(It.IsAny<Entities.Greeting>()))
                    .Callback<Entities.Greeting>(g => g.Id = 1);

                _greeting = new Greeting {Message = "testing"};
                _response = _controller.Add(_greeting).ExecuteAsync(new CancellationToken()).Result;
            }

            [TestMethod]
            public void ShouldReturnCreated()
            {
                _response.StatusCode.Should().Be(HttpStatusCode.Created);
            }

            [TestMethod]
            public void ShouldReturnLocation()
            {
                _response.Headers.Location.Should().Be(ApiUrl + "/1");
            }

            [TestMethod]
            public void ShouldCallAddOnRepository()
            {
                Mock.Get(_repository).Verify(x => x.Add(It.IsAny<Entities.Greeting>()));
            }

            [TestMethod]
            public void ShouldReturnGreeting()
            {
                Greeting greeting;
                _response.TryGetContentValue(out greeting).Should().BeTrue();
                greeting.Message.Should().Be(_greeting.Message);
            }
        }

        [TestClass]
        public class Delete : GreetingsControllerTests
        {
            private readonly HttpResponseMessage _response;

            public Delete()
            {
                _response = _controller.Delete(1).ExecuteAsync(new CancellationToken()).Result;
            }

            [TestMethod]
            public void ShouldReturnNoContent()
            {
                _response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            }

            [TestMethod]
            public void ShouldCallDeleteOnRepository()
            {
                Mock.Get(_repository).Verify(x => x.Delete(1));
            }
        }
    }
}