using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTOs.Accounts;
using Shop.Application.Features.OrderEntities.Order.Requests.Commands;
using Shop.Application.Features.OrderEntities.Order.Requests.Queries;
using Shop.Web.Extentions;
using Shop.Web.Models.VM.Account;

namespace Shop.Web.Areas.Admin.Controllers
{
    public class OrderController : AdminBaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        #region filter-orders
        public async Task<IActionResult> FilterOrders(FilterOrdersVM filterOrders)
        {
            var map = _mapper.Map<FilterOrdersDto>(filterOrders);
            var response = await _mediator.Send(new FilterOrdersRequest() { FilterOrdersDto = map });
            return View(_mapper.Map<FilterOrdersVM>(response));
        }
        #endregion
        #region change order-state
        public async Task<IActionResult> ChangeStateToSent(long orderId)
        {
            var command=new ChangeStateToSentCommandRequest { OrderId=orderId };
            var response=await _mediator.Send(command);
           
            if (response)
            {
                return JsonResponseStatus.Success();
            }

            return JsonResponseStatus.Error();

        }
        #endregion
        #region OrderDetail
        public async Task<IActionResult> OrderDetail(long orderId)
        {
            var data = await _mediator.Send(new GetOrderDetailRequest { OrderId = orderId });
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }
        #endregion
    }
}
