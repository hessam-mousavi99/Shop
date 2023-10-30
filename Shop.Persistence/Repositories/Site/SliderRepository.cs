using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence.IRepositories.ISite;
using Shop.Application.DTOs.Admin.SiteSetting.Slider;
using Shop.Application.Utils.Paging;
using Shop.Domain.Models.Site;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Generics;

namespace Shop.Persistence.Repositories.Site
{
    public class SliderRepository : GenericRepository<Slider>, ISliderRepository
    {
        private readonly ShopDBContext _context;

        public SliderRepository(ShopDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<FilterSlidersDto> FliterSliders(FilterSlidersDto filterSlidersDto)
        {
            var query=_context.Sliders.AsQueryable();
            if (!string.IsNullOrEmpty(filterSlidersDto.SliderTitle))
            {
                query = query.Where(s => EF.Functions.Like(s.SliderTitle, $"%{filterSlidersDto.SliderTitle}%"));
            }
            #region Paging
            var pager = Pager.Build(filterSlidersDto.PageId, await query.CountAsync(), filterSlidersDto.TakeEntity,
                filterSlidersDto.CountForShowAfterAndBefor);
            var allData=await query.Paging(pager).ToListAsync();
            #endregion
            return filterSlidersDto.SetPaging(pager).SetSilders(allData);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
