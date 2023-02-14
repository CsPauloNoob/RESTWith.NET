using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using RESTWithDotNet.Models;
using RESTWithDotNet.Models.Services.Implementation;
using System.Globalization;

namespace RESTWithDotNet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }


    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_personService.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var person = _personService.FindById(id);

        if(person == null)
            return NotFound();

        return Ok(person);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {
        if (person == null)
            return BadRequest();
        else
            _personService.Create(person);
        return Ok();
    }

    [HttpPut]
    public IActionResult Put([FromBody] Person person)
    {
        if (person == null)
            return BadRequest();
        return Ok(_personService.Update(person));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        _personService.Delete(id);
        return NoContent();
    }

}
