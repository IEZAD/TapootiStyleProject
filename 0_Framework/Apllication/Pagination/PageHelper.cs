using System.Linq.Expressions;
using _0_Framework.Domain.Pagination;

namespace _0_Framework.Apllication.Pagination
{
    public static class PageHelper
    {
        public static int PageSize10 => 10;

        public static int PageSize20 => 20;

        public static int PageSize100 => 100;

        public static PagedResult<T> ToPagedResult<T>(this List<T> list, int page) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = PageSize20,
                RowCount = list.Count()
            };

            var pageCount = (double)result.RowCount / PageSize20;
            result.PageCount = (int)Math.Ceiling(pageCount);
            var skip = (page - 1) * PageSize20;
            result.Data = list.Skip(skip).Take(PageSize20).ToList();

            return result;
        }

        public static PagedResult<T> ToPagedResult10<T>(this List<T> query, int page) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = PageSize10,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / PageSize10;
            result.PageCount = (int)Math.Ceiling(pageCount);
            var skip = (page - 1) * PageSize10;
            result.Data = query.Skip(skip).Take(PageSize10).ToList();

            return result;
        }

        public static PagedResult<T> ToPagedResult<T>(this IQueryable<T> query, int page) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = PageSize20,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / PageSize20;
            result.PageCount = (int)Math.Ceiling(pageCount);
            var skip = (page - 1) * PageSize20;
            result.Data = query.Skip(skip).Take(PageSize20).ToList();

            return result;
        }

        public static PagedResult<T> ToPagedResult10<T>(this IQueryable<T> query, int page) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = PageSize10,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / PageSize10;
            result.PageCount = (int)Math.Ceiling(pageCount);
            var skip = (page - 1) * PageSize10;
            result.Data = query.Skip(skip).Take(PageSize10).ToList();

            return result;
        }

        public static PagedResult<T> ToPagedResult100<T>(this IQueryable<T> query, int page) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = PageSize100,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / PageSize100;
            result.PageCount = (int)Math.Ceiling(pageCount);
            var skip = (page - 1) * PageSize100;
            result.Data = query.Skip(skip).Take(PageSize100).ToList();

            return result;
        }

        public static PagedResult<T> ToPagedResult<T>(this List<T> list, int page, int take) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = take,
                RowCount = list.Count()
            };

            var pageCount = (double)result.RowCount / PageSize20;
            result.PageCount = (int)Math.Ceiling(pageCount);
            var skip = (page - 1) * take;
            result.Data = list.Skip(skip).Take(take).ToList();

            return result;
        }

        public static IEnumerable<T> ToPaged<T>(this IQueryable<T> query, int page, int take) where T : class
        {
            var skip = (page - 1) * take;
            var list = query.Skip(skip).Take(take).ToList();

            return list;
        }

        public static PagedResult<T> ToPagedResult<T>(this IQueryable<T> list, int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = list.Count()
            };

            var pageCount = (double)result.RowCount / PageSize20;
            result.PageCount = (int)Math.Ceiling(pageCount);
            var skip = (page - 1) * PageSize20;
            result.Data = list.Skip(skip).Take(PageSize20).ToList();

            return result;
        }

        public static PagedResult<T> PagedResultDtoToView<T, V>(this List<T> View, PagedResult<V> dto) where T : class where V : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = dto.CurrentPage,
                PageSize = dto.PageSize,
                RowCount = dto.RowCount,
                PageCount = dto.PageCount
            };

            result.Data = View;

            return result;
        }

        public static async Task<PagedResult<T>> ToPagedResultAsync<T>(this IQueryable<T> query, int page) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = PageSize20,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / PageSize20;
            result.PageCount = (int)Math.Ceiling(pageCount);
            var skip = (page - 1) * PageSize20;
            await Task.Run(() => result.Data = query.Skip(skip).Take(PageSize20).ToList());

            return result;
        }

        public static PagedResult<T> ToPagedResultWithPageSize<T>(this List<T> list, int pageSize, int page) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = list.Count()
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);
            var skip = (page - 1) * pageSize;
            result.Data = list.Skip(skip).Take(pageSize).ToList();

            return result;
        }

        public static PagedResult<T> ToPagedResultWithSize<T>(this IQueryable<T> query, int pageSize, int page) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);
            var skip = (page - 1) * pageSize;
            result.Data = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }

    public static class PagingExtensions
    {
        //used by LINQ to SQL
        public static IQueryable<TSource> ToPaged<TSource>(this IQueryable<TSource> source, int page, int pageSize)
        {
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }


        //--------used by LINQ--------
        public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> source, int page, int pageSize)
        {
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> source, int page, int pageSize, out int rowsCount)
        {
            rowsCount = source.Count();
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// صفحه بندی کوئری
        /// </summary>
        /// <param name="query">کوئری مورد نظر شما</param>
        /// <param name="pageNum">شماره صفحه</param>
        /// <param name="pageSize">سایز صفحه</param>
        /// <param name="orderByProperty">ترتیب خواص</param>
        /// <param name="isAscendingOrder">اگر برابر با <c>true</c> باشد صعودی است</param>
        /// <param name="rowsCount">تعداد کل ردیف ها</param>
        /// <returns></returns>
        public static IQueryable<T> PagedResultCommand<T, TResult>(this IQueryable<T> query, int pageNum, int pageSize,
                Expression<Func<T, TResult>> orderByProperty, bool isAscendingOrder, out int rowsCount)
        {
            if (pageSize <= 0) pageSize = 20;
            //مجموع ردیف‌های به دست آمده
            rowsCount = query.Count();
            // اگر شماره صفحه کوچکتر از 0 بود صفحه اول نشان داده شود
            if (/*rowsCount <= pageSize ||*/ pageNum <= 0) pageNum = 1;
            // محاسبه ردیف هایی که نسبت به سایز صفحه باید از آنها گذشت
            int excludedRows = (pageNum - 1) * pageSize;
            // ردشدن از ردیف‌های اضافی و  دریافت ردیف‌های مورد نظر برای صفحه مربوطه
            return query.Skip(excludedRows).Take(pageSize);
        }

        public static IQueryable<TSource> PagedResultCommand<TSource>(this IQueryable<TSource> query, int pageNum, int pageSize, out int rowsCount)
        {
            if (pageSize <= 0) pageSize = 20;
            //مجموع ردیف‌های به دست آمده
            rowsCount = query.Count();
            // اگر شماره صفحه کوچکتر از 0 بود صفحه اول نشان داده شود
            if (pageNum <= 0) pageNum = 1;
            // محاسبه ردیف هایی که نسبت به سایز صفحه باید از آنها گذشت
            int excludedRows = (pageNum - 1) * pageSize;
            // ردشدن از ردیف‌های اضافی و  دریافت ردیف‌های مورد نظر برای صفحه مربوطه
            return query.Skip(excludedRows).Take(pageSize);
        }
    }
}