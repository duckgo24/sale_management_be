using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Domain.Exceptions;
using MediatR;
using WebApi.DBHelper;

namespace Application.Category.Commands.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly IDbHelper _dbHelper;
        public CreateCategoryHandler(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var checkCategoryExit = await _dbHelper.ExcuteProceduceSingleDataAsync<CategoryDto>(
                    "sp_find_category_by_name",
                     new Dapper.DynamicParameters(
                            new
                            {
                                category_name = request.category_name
                            })
                    );

                if (checkCategoryExit?.category_id != null)
                {
                    throw new BadRequestException("Category is exist.");
                }


                var newCategory = await _dbHelper.ExcuteProceduceByUserAsync<CategoryDto>(
                    "sp_create_category",
                     new Dapper.DynamicParameters(
                        new
                        {
                            category_id = Guid.NewGuid().ToString(),
                            category_name = request.category_name,
                            category_desc = request.category_desc,
                            category_image = request.category_image
                        })
                );
                return newCategory;
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}