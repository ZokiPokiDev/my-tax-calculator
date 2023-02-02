using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaxCalculatorAPI.Commands;
using TaxCalculatorAPI.Requests;
using TaxCalculatorAPI.Routes;

namespace TaxCalculatorAPI.Controllers
{
    [ApiController]
    [Route(ApiRoutes.Base)]
    public class PurchaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PurchaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Calculate purchaise by given net value and VAT rate
        /// </summary>
        /// <param name="net"></param>
        /// <param name="vatrate"></param>
        /// <returns></returns> 
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        [HttpGet(ApiRoutes.Purchase.Net)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Purchase>> CalculateNetAmount([FromQuery] PurchaseByVatRateRequest request)
        {
            return Ok(await _mediator.Send(new PurchaseByNetAmountCommand { Net = request.Amount, VatRate = request.VatRate }));
        }

        /// <summary>
        /// Calculate purchaise by given gross value and VAT rate
        /// </summary>
        /// <param name="gross"></param>
        /// <param name="vatrate"></param>
        /// <returns></returns> 
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        [HttpGet(ApiRoutes.Purchase.Gross)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Purchase>> CalculateGrossAmount([FromQuery] PurchaseByVatRateRequest request)
        {
            return Ok(await _mediator.Send(new PurchaseByGrossAmountCommand { Gross = request.Amount, VatRate = request.VatRate }));
        }

        /// <summary>
        /// Calculate purchaise by given VAT value and VAT rate
        /// </summary>
        /// <param name="net"></param>
        /// <param name="vatrate"></param>
        /// <returns></returns> 
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        [HttpGet(ApiRoutes.Purchase.Vat)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Purchase>> CalculateVatAmount([FromQuery] PurchaseByVatRateRequest request)
        {
            return Ok(await _mediator.Send(new PurchaseByVatAmountCommand { VAT = request.Amount, VatRate = request.VatRate }));
        }

        /// <summary>
        /// Calculate purchaise and VAT rate by given net, gross and VAT values
        /// </summary>
        /// <param name="net"></param>
        /// <param name="vatrate"></param>
        /// <returns></returns> 
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        [HttpGet(ApiRoutes.Purchase.VatRate)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Purchase>> CalculateAmountVatRate([FromQuery] PurchaseAmountRequest request)
        {
            return Ok(await _mediator.Send(new PurchaseByVatRateAmountCommand { Net = request.Net, Gross = request.Gross, Vat = request.Vat }));
        }
    }
}
