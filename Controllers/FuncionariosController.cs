using Microsoft.AspNetCore.Mvc;
using System;
using CrudRafa.Models;
using CrudRafa.Database;
using System.Linq;

namespace CrudRafa.Controllers
{

    
    public class FuncionariosController :   Controller
    {
        private readonly ApplicationDBContext database;
        public FuncionariosController(ApplicationDBContext database){
            this.database = database;
        }

        public IActionResult Index(){
            var funcionarios = database.Funcionarios.ToList();
            return View(funcionarios);
        }
        public IActionResult Cadastrar (){
            return View();
        }
        public IActionResult Editar(int id){
            Funcionario funcionario = database.Funcionarios.First(registro => registro.Id == id);
            return View("Cadastrar", funcionario);

        }
        public IActionResult Deletar(int id){
             Funcionario funcionario = database.Funcionarios.First(registro => registro.Id == id);
            database.Funcionarios.Remove(funcionario); 
            database.SaveChanges();
            return RedirectToAction("Index"); 
        }
        
        [HttpPost]
        public IActionResult Salvar(Funcionario funcionario){
            database.Funcionarios.Add(funcionario);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}