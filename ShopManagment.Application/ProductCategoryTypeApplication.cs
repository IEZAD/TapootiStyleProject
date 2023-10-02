using AutoMapper;
using System.Net;
using Microsoft.EntityFrameworkCore;
using _0_Framework.Domain.Pagination;
using _0_Framework.Apllication.Logger;
using _0_Framework.Apllication.Resources;
using _0_Framework.Apllication.Utilities;
using _0_Framework.Apllication.Pagination;
using _0_Framework.Apllication.Apllication;
using _0_Framework.Apllication.Messaging.ApiWrapper;
using ShopManagment.Domain.ProductCategoryAgg.ProductCategoryTypeAgg;
using ShopManagment.Application.Contracts.ProductCategory.ProductCategoryType;

namespace ShopManagment.Application
{
    public class ProductCategoryTypeApplication : TapootiApllication, IProductCategoryTypeApplication
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IProductCategoryTypeRepository _productCategoryTypeRepository;
        private readonly IProductCategoryTypeQueryRepository _productCategoryTypeQueryRepository;

        public ProductCategoryTypeApplication(ILogger logger,
                                              IMapper mapper,
                                              IProductCategoryTypeRepository productCategoryTypeRepository,
                                              IProductCategoryTypeQueryRepository productCategoryTypeQueryRepository) : base(logger, mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _productCategoryTypeRepository = productCategoryTypeRepository;
            _productCategoryTypeQueryRepository = productCategoryTypeQueryRepository;
        }

        //Test Done :)
        public async Task<ApiWrapperResponse<List<MenuItemViewModel>>> ExecuteAsync()
        {
            try
            {
                var productCategoryTypes = _productCategoryTypeQueryRepository.GetAllAsNoTracking().Include(x => x.SubType).OrderBy(x => x.OrderId);

                var entities = _mapper.Map<List<MenuItemViewModel>>(productCategoryTypes);

                var result = new ApiWrapperResponse<List<MenuItemViewModel>>(entities);

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex, new List<MenuItemViewModel>());
            }
        }

        //Test Done :)
        public async Task<ApiWrapperResponse<ProductCategoryTypeViewModel>> GetDetailsAsync(Guid id)
        {
            try
            {
                var entity = await _productCategoryTypeQueryRepository.GetByIdAsync(id);
                var result = _mapper.Map<ProductCategoryTypeViewModel>(entity);
                return new ApiWrapperResponse<ProductCategoryTypeViewModel>(result);
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex, new ProductCategoryTypeViewModel());
            }
        }

        //Test Done :)
        public async Task<ApiWrapperResponse<ProductCategoryTypeViewModel>> DeleteAsync(Guid request)
        {
            try
            {
                var model = await _productCategoryTypeQueryRepository.GetByIdAsync(request);
                if (model is null)
                    return new ApiWrapperResponse<ProductCategoryTypeViewModel>(true, HttpStatusCode.NotFound, ApplicationMessages.RecordNotFound);

                var entity = _mapper.Map<ProductCategoryTypeViewModel>(model);
                var result = await _productCategoryTypeRepository.DeleteByIdAsync(request);
                await _productCategoryTypeRepository.SaveChangesAsync();

                if (result)
                    return new ApiWrapperResponse<ProductCategoryTypeViewModel>(entity, false, HttpStatusCode.NoContent, ApplicationMessages.Successed);

                return new ApiWrapperResponse<ProductCategoryTypeViewModel>(true, HttpStatusCode.BadRequest, ApplicationMessages.Failed);
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex, new ProductCategoryTypeViewModel());
            }
        }

        //Test Done :)
        public async Task<ApiWrapperResponse<ProductCategoryTypeViewModel>> CreateAsync(CreateProductCategoryType request)
        {
            try
            {
                request.Type = request.Type.ReplaceArabicCharacters().Trim();

                if (_productCategoryTypeRepository.Exists(x => x.Type == request.Type && x.ParentProductCategoryTypeId == request.ParentProductCategoryTypeId) &&
                    _productCategoryTypeRepository.Exists(x => x.OrderId == request.OrderId && x.ParentProductCategoryTypeId == request.ParentProductCategoryTypeId))
                    return new ApiWrapperResponse<ProductCategoryTypeViewModel>(true, HttpStatusCode.BadRequest, ApplicationMessages.DuplicatedRecord);

                ProductCategoryType productCategoryType = new(request.Type, request.OrderId, request.ParentProductCategoryTypeId);
                await _productCategoryTypeRepository.CreateAsync(productCategoryType);
                await _productCategoryTypeRepository.SaveChangesAsync();

                var entity = _mapper.Map<ProductCategoryTypeViewModel>(productCategoryType);

                return new ApiWrapperResponse<ProductCategoryTypeViewModel>(entity, false, HttpStatusCode.Created, ApplicationMessages.Successed);
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex, new ProductCategoryTypeViewModel());
            }
        }

        //Test Done :)
        public async Task<ApiWrapperResponse<ProductCategoryTypeViewModel>> UpdateAsync(UpdateProductCategoryType request)
        {
            try
            {
                request.Type = request.Type.ReplaceArabicCharacters().Trim();

                var productCategoryType = await _productCategoryTypeRepository.GetByIdAsync(request.Id);

                if (productCategoryType is null)
                    return new ApiWrapperResponse<ProductCategoryTypeViewModel>(true, HttpStatusCode.NotFound, ApplicationMessages.RecordNotFound);

                if (_productCategoryTypeRepository.Exists(x => x.Type == request.Type && x.ParentProductCategoryTypeId == request.ParentProductCategoryTypeId) &&
                    _productCategoryTypeRepository.Exists(x => x.OrderId == request.OrderId && x.ParentProductCategoryTypeId == request.ParentProductCategoryTypeId))
                    return new ApiWrapperResponse<ProductCategoryTypeViewModel>(true, HttpStatusCode.BadRequest, ApplicationMessages.DuplicatedRecord);

                productCategoryType.Update(request.Type, request.OrderId, request.ParentProductCategoryTypeId);
                await _productCategoryTypeRepository.SaveChangesAsync();

                var entity = _mapper.Map<ProductCategoryTypeViewModel>(productCategoryType);

                return new ApiWrapperResponse<ProductCategoryTypeViewModel>(entity, false, HttpStatusCode.OK, ApplicationMessages.Successed);
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex, new ProductCategoryTypeViewModel());
            }
        }

        //Test Done :)
        public async Task<ApiWrapperResponse<PagedResult<ProductCategoryTypeViewModel>>> SearchAsync(ProductCategoryTypeSearchModel request)
        {
            try
            {
                request.Type = request.Type.ReplaceArabicCharacters().Trim();

                var result = await _productCategoryTypeQueryRepository.Search(request);

                if (result.Data.Count() > 0)
                    return new ApiWrapperResponse<PagedResult<ProductCategoryTypeViewModel>>(result, false, HttpStatusCode.OK, ApplicationMessages.Successed);

                return new ApiWrapperResponse<PagedResult<ProductCategoryTypeViewModel>>(false, HttpStatusCode.OK, ApplicationMessages.RecordNotFound);
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex, new PagedResult<ProductCategoryTypeViewModel>());
            }
        }

        //Test Done :)
        public async Task<ApiWrapperResponse<PagedResult<ProductCategoryTypeListViewModel>>> GetProductCategoryTypesAsync(ProductCategoryTypeListRequest request)
        {
            try
            {
                var productCategoryTypes = _productCategoryTypeQueryRepository.GetAllAsNoTracking().OrderBy(x => x.OrderId);

                var models = productCategoryTypes.Where(x => x.ParentProductCategoryTypeId == request.ParentProductCategoryTypeId);

                var result = await _mapper.ProjectTo<ProductCategoryTypeListViewModel>(models).ToListAsync();

                var entity = result.ToPagedResult10(request.Page);

                return new ApiWrapperResponse<PagedResult<ProductCategoryTypeListViewModel>>(entity);
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex, new PagedResult<ProductCategoryTypeListViewModel>());
            }
        }
    }
}