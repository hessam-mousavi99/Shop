using Shop.Domain.Models.BaseEntities;

namespace Shop.Application.Utils.Paging
{
    public static class Pager
    {
        public static BasePaging Build(int pageId,int allEntityCount,int take,int countForShowAfterAndBefor)
        {
            var pageCount = Convert.ToInt32(Math.Ceiling(allEntityCount / (double)take));

            return new BasePaging
            {
                PageId = pageId,
                AllEntityCount = allEntityCount,
                CountForShowAfterAndBefor = countForShowAfterAndBefor,
                SkipEntitiy = (pageId - 1) * take,
                TakeEntity = take,
                StartPage = pageId - countForShowAfterAndBefor <= 0 ? 1 : pageId - countForShowAfterAndBefor,
                EndPage = pageId + countForShowAfterAndBefor > pageCount ? pageCount : pageId + countForShowAfterAndBefor,
                PageCount = pageCount
            };
        }
    }
}
