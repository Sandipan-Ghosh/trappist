﻿using Promact.Trappist.DomainModel.DbContext;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using System;
using System.Linq;
using Promact.Trappist.Repository.Categories;

namespace Promact.Trappist.Test.Category
{
    [Collection("Register Dependency")]
    public class CategoryRepositoryTest : BaseTest
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryRepositoryTest(Bootstrap bootstrap) : base(bootstrap)
        {   
            _categoryRepository = _scope.ServiceProvider.GetService<ICategoryRepository>();
        }

        [Fact]
        public void AddCategory()
        {
            var category = CreateCategory();
            _categoryRepository.AddCategory(category);
            Assert.True(_trappistDbContext.Category.Count() == 1);
        }

        [Fact]
        public void UpdateCategory()
        {
            var category = CreateCategory();
            _categoryRepository.AddCategory(category);
            var categoryToUpdate = _categoryRepository.GetCategory(category.Id);
            Assert.NotNull(categoryToUpdate);
            if (categoryToUpdate != null)
                categoryToUpdate.CategoryName = "Updated Category";
            _categoryRepository.CategoryEdit(categoryToUpdate);
            Assert.True(_trappistDbContext.Category.Count(x=>x.CategoryName == "Updated Category") == 1);
        }

        private DomainModel.Models.Category.Category CreateCategory()
        {
            var category = new DomainModel.Models.Category.Category
            {
                CategoryName = "test category",
                CreatedDateTime = DateTime.UtcNow
            };
            return category;
        }
    }
}
