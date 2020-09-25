using Desafio_CRUD.Server;
using Microsoft.AspNetCore.Mvc;
using Desafio_CRUD.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

[ApiController]
[Route("[controller]")]
public class ProdutoController : Controller
{
    private readonly AppDbContext db;
    
    public ProdutoController(AppDbContext db)
    {
        this.db = db;
    }

    [HttpGet]
    [Route("List")]
    public async Task<IActionResult> Get()
    {
        var Produtos = await db.Produtos.ToListAsync();
        return Ok(Produtos);
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<IActionResult> Get([FromQuery] string id)
    {
        var user = await db.Produtos.SingleOrDefaultAsync(x => x.ID == Convert.ToInt32(id));
        return Ok(user);
    }

    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> Post([FromBody] Modelo_Produto user)
    {
        try
        {
            var newModelo_Produto = new Modelo_Produto
            {
                ID = user.ID,
                Nome = user.Nome,
                Descricao = user.Descricao,
                Valor = user.Valor,
            };

            db.Add(newModelo_Produto);
            await db.SaveChangesAsync();
            return Ok();
        }
        catch(Exception e)
        {
            return View(e);
        }
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> Put([FromBody] Modelo_Produto Produto_Modificado)
    {
        db.Entry(Produto_Modificado).State = EntityState.Modified;
        try
        {
            await db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw (ex);
        }
        return NoContent();
    }

    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<ActionResult<Modelo_Produto>> Delete(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var user = await db.Produtos.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        db.Produtos.Remove(user);
        await db.SaveChangesAsync();
        return user;
    }

    private bool Modelo_ProdutoExists(int id)
    {
        return db.Produtos.Any(e => e.ID == id);
    }


    /*
    [HttpGet]
    [Route("Teste")]
    public async Task<ActionResult> PostTeste()
    {
        try
        {
            var user2 = new Modelo_Produto();
            user2.ID = 9999;
            user2.Nome = "Produto";
            user2.Descricao = "Teste";
            user2.Valor = 999.99;

            db.Add(user2);
            await db.SaveChangesAsync();
            return Ok(await db.Produtos.ToListAsync());
        }
        catch
        {
            return null;
        }
    }
    */

}