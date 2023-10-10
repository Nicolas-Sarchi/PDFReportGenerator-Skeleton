using API.Dtos;
// using API.Generator;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class FacturaController : BaseApiController
{
    private IUnitOfWork _unitOfWork;
    private readonly IMapper mapper;


    public FacturaController(IUnitOfWork UnitOfWork, IMapper Mapper)
    {
        _unitOfWork = UnitOfWork;
        mapper = Mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<FacturaDto>>> Get()
    {
        var Factura = await _unitOfWork.Facturas.GetAllAsync();
        return mapper.Map<List<FacturaDto>>(Factura);
    }

 [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<FacturaDto>> GetbyId(int id)
    {
        var Factura = await _unitOfWork.Facturas.GetByIdAsync(id);
        return mapper.Map<FacturaDto>(Factura);
    }


[HttpPost]
[ProducesResponseType(StatusCodes.Status201Created)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<FacturaDto>> Post(FacturaPostDto factDto)
{
    var factura = this.mapper.Map<Factura>(factDto);

    _unitOfWork.Facturas.Add(factura);
    await _unitOfWork.SaveAsync();

    var detallesFactura = new List<DetalleFactura>();

    foreach (var detalleFacturaDto in factDto.DetallesFactura)
    {
        var detalleFactura = this.mapper.Map<DetalleFactura>(detalleFacturaDto);
        detalleFactura.IdFacturaFk = factura.Id;
        detallesFactura.Add(detalleFactura);
    }
    factura = await _unitOfWork.Facturas.GetByIdAsync(factura.Id);
    var facturaDto = this.mapper.Map<FacturaDto>(factura);

      return Ok(facturaDto);
}

}}
