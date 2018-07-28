﻿using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using DTOs;
using Servicos.Contratos;
using WebApplication.Areas.Loja.Models;

namespace WebApplication.Areas.Loja.Controllers
{
    public class VitrineController : Controller
    {
	    private readonly IProdutoService _produtoService;

	    public VitrineController(IProdutoService produtoService)
	    {
		    _produtoService = produtoService;
	    }

	    // GET: Loja/Home
        public ActionResult Index()
        {
	        ViewBag.Title = "Chef`s - Tudo para sua cozinha";
	        var x = _produtoService.ListarProdutosEmDestaque();
			return View(new VitrineViewModel { Produtos = Mapper.Map<List<ProdutoDTO>, List<ProdutoViewModel>>(x) });
        }
    }
}