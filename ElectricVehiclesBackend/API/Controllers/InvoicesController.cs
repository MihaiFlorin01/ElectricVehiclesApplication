using Abstractions;
using AutoMapper;
using Dtos.InvoiceDtos;
using Dtos.RentalDtos;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoicesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<ViewInvoiceDto>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewInvoiceDto>>> GetInvoices()
        {
            var invoices = await _unitOfWork.GetRepository<Invoice>().GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ViewInvoiceDto>>(invoices));
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewInvoiceDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}", Name = "GetInvoiceById")]
        public async Task<ActionResult<ViewInvoiceDto>> GetInvoiceById(int id)
        {
            var invoice = await _unitOfWork.GetRepository<Invoice>().GetByIdAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ViewInvoiceDto>(invoice));
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewInvoiceDto), 201)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<ViewInvoiceDto>> AddInvoice(CreateInvoiceDto createInvoiceDto)
        {
            var invoiceEntity = _mapper.Map<Invoice>(createInvoiceDto);

            _unitOfWork.GetRepository<Invoice>().Add(invoiceEntity);

            await _unitOfWork.SaveChangesAsync();

            var invoiceToReturn = _mapper.Map<ViewInvoiceDto>(invoiceEntity);

            return CreatedAtRoute("GetInvoiceById", new { id = invoiceEntity.Id }, invoiceToReturn);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewInvoiceDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<ActionResult<ViewInvoiceDto>> UpdateInvoice(UpdateInvoiceDto updateInvoiceDto)
        {
            var invoiceEntity = _mapper.Map<Invoice>(updateInvoiceDto);

            _unitOfWork.GetRepository<Invoice>().Update(invoiceEntity);

            await _unitOfWork.SaveChangesAsync();

            var invoiceToReturn = _mapper.Map<ViewInvoiceDto>(invoiceEntity);

            return Ok(invoiceToReturn);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewInvoiceDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ViewInvoiceDto>> DeleteInvoice(int id)
        {
            var invoiceEntity = await _unitOfWork.GetRepository<Invoice>().GetByIdAsync(id);

            if (invoiceEntity == null)
            {
                return NotFound();
            }

            await _unitOfWork.GetRepository<Invoice>().DeleteByIdAsync(id);

            await _unitOfWork.SaveChangesAsync();

            var invoiceToReturn = _mapper.Map<ViewInvoiceDto>(invoiceEntity);

            return Ok(invoiceToReturn);
        }
    }
}
