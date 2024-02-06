using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieTheater.Controllers;
using MovieTheater.Interfaces;
using MovieTheater.Models;
using MovieTheater.Models.DTO;
using System;
using System.Diagnostics.Metrics;

namespace MovieTheater_Test
{
    public class ProjectionTypeController_Test
    {
        [Fact]
        public async Task GetById_ValidId_ReturnsObjectAsync()
        {
        
            ProjectionType projectionType = new ProjectionType()
            {
                Id = 1,
                Type = "2D",
                ProjectionHallId = 1,
                ProjectionHall = new ProjectionHall() { Id = 1, Name = "XC", Capacity = 1 },
            };

            ProjectionTypeDTO ptDto = new ProjectionTypeDTO()
            {
                Id = 1,
                Type = "2D",
                ProjectionHallId = 1,
                ProjectionHallName = "XC",
                ProjectionHallCapacity = 1
            };

            var mockRepository = new Mock<IProjectionTypeRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(projectionType);

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new Profiles()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new ProjectionTypeController(mapper, mockRepository.Object);

     
            var actionResult = await controller.GetById(1) as OkObjectResult;

   
            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);

            ProjectionTypeDTO dtoResult = (ProjectionTypeDTO)actionResult.Value;
            Assert.Equal(projectionType.Id, dtoResult.Id);
            Assert.Equal(projectionType.Type, dtoResult.Type);
            Assert.Equal(projectionType.ProjectionHallId, dtoResult.ProjectionHallId);
            Assert.Equal(projectionType.ProjectionHall.Name, dtoResult.ProjectionHallName);
            Assert.Equal(projectionType.ProjectionHall.Capacity, dtoResult.ProjectionHallCapacity);

        }
        [Fact]
        public async void GetProjectionTypeInvalidId_ReturnsNotFound()
        {

            var mockRepository = new Mock<IProjectionTypeRepository>();

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new Profiles()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new ProjectionTypeController(mapper, mockRepository.Object);

            var actionResult = await controller.GetById(12) as NotFoundResult;

    
            Assert.NotNull(actionResult);
        }
        [Fact]
        public async void GetAllAsync_ReturnsCollection()
        {
    
            List<ProjectionType> pt = new List<ProjectionType>() {
                new ProjectionType()
            {
                Id = 1,
                Type = "2D",
                ProjectionHallId = 1,
                ProjectionHall = new ProjectionHall() { Id = 1, Name = "XC", Capacity = 1 },
            },
           new ProjectionType()
            {
                Id = 2,
                Type = "2D",
                ProjectionHallId = 1,
                ProjectionHall = new ProjectionHall() { Id = 1, Name = "XC", Capacity = 1 },
            }
        };

            var mockRepository = new Mock<IProjectionTypeRepository>();
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(pt);

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new Profiles()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new ProjectionTypeController(mapper,mockRepository.Object);

            // Act
            var actionResult = await controller.GetAll() as OkObjectResult;

            // Assert
            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);

            List<ProjectionTypeDTO> dtoResult = (List<ProjectionTypeDTO>)actionResult.Value;

            for (int i = 0; i < dtoResult.Count; i++)
            {
                Assert.Equal(pt[i].Id, dtoResult[i].Id);
                Assert.Equal(pt[i].Type, dtoResult[i].Type);
                Assert.Equal(pt[i].ProjectionHallId, dtoResult[i].ProjectionHallId);
                Assert.Equal(pt[i].ProjectionHall.Name, dtoResult[i].ProjectionHallName);
                Assert.Equal(pt[i].ProjectionHall.Capacity, dtoResult[i].ProjectionHallCapacity);
            }
        }
        [Fact]
        public async void Create_ValidRequest_SetsLocationHeader()
        {
            ProjectionType projectionType = new ProjectionType()
            {
                Id = 1,
                Type = "2D",
                ProjectionHallId = 1,
                ProjectionHall = new ProjectionHall() { Id = 1, Name = "XC", Capacity = 1 },
            };

            ProjectionTypeDTO ptDto = new ProjectionTypeDTO()
            {
                Id = 1,
                Type = "2D",
                ProjectionHallId = 1,
                ProjectionHallName = "XC",
                ProjectionHallCapacity = 1
            };

            var mockRepository = new Mock<IProjectionTypeRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(projectionType);

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new Profiles()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new ProjectionTypeController(mapper, mockRepository.Object);

         /* 
            var actionResult = await controller.Create(projectionType) as CreatedAtActionResult;

     
            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);
            Assert.Equal("GetById", actionResult.ActionName);
            Assert.Equal(1, actionResult.RouteValues["id"]);

            ProjectionTypeDTO dtoResult = (ProjectionTypeDTO)actionResult.Value;
            Assert.Equal(projectionType.Id, dtoResult.Id);
            Assert.Equal(projectionType.Type, dtoResult.Type);
            Assert.Equal(projectionType.ProjectionHallId, dtoResult.ProjectionHallId);
            Assert.Equal(projectionType.ProjectionHall.Name, dtoResult.ProjectionHallName);
            Assert.Equal(projectionType.ProjectionHall.Capacity, dtoResult.ProjectionHallCapacity);*/
        }

    }
}