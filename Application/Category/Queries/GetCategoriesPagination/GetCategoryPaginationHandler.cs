using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Dtos.ResponData;
using Application.Dtos;
using Azure;
using MediatR;
using WebApi.DBHelper;

namespace Application.Category.Queries.GetCategoriesWithPagination
{
    public class GetCategoryPaginationHandler : IRequestHandler<GetCategoryPaginationQuery, ResponDataDto>
    {
        private readonly IDbHelper _dbHelper;
        public GetCategoryPaginationHandler(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public async Task<ResponDataDto> Handle(GetCategoryPaginationQuery request, CancellationToken cancellationToken)
        {
            
            var lstCategory = await _dbHelper.ExcuteProceduceMultiDataAsync<CategoryDto>(
                "sp_get_category_pagination",
                new Dapper.DynamicParameters(
                    new
                    {
                        page_number = request.page_number,
                        page_size = request.page_size
                    })
            );

            return new ResponDataDto()
            {
                data = lstCategory,
                page_number = request.page_number,
                page_size = request.page_size,
                total_record = lstCategory.Count()
            };
        }

    }

}