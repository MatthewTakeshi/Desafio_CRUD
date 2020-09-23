using Desafio_CRUD.Server;
using Microsoft.AspNetCore.Mvc;
using Desafio_CRUD.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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