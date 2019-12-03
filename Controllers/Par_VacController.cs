//////using System;
//////using System.Collections.Generic;
//////using System.Linq;
//////using System.Threading.Tasks;
//////using Microsoft.AspNetCore.Http;
//////using Microsoft.AspNetCore.Mvc;
//////using API_BU.Models;
//////using API_BU.Data;
//////using Microsoft.EntityFrameworkCore;
//////using System.Collections.ObjectModel;

//////namespace API_BU.Controllers
//////{
//////    [Route("api/[controller]")]
//////    [ApiController]

//////    public class Par_VacController : ControllerBase
//////    {
//////        private readonly DepPuestoContexto _context;
//////        //[HttpPost]
//////        //public IActionResult Create([FromBody] Par_Vac partidas,int id)
//////        //{
//////        //    partidas.Id = id;
//////        //    if (!ModelState.IsValid)
//////        //    {
//////        //        return BadRequest(ModelState);

//////        //    }
//////        //    _context.Par_vac.Add(partidas);
//////        //    _context.SaveChanges();
//////        //    return Ok(partidas);

//////        //}
//////        //[HttpPost]
//////        //public void Insert(IEnumerable<Datos> g)
//////        ////public async Task<ActionResult<Datos>> insert(IEnumerable<Datos> g)
//////        //{
//////        //    List<int> mylist = new List<int>();
//////        //    mylist.Add(10);
//////        //    mylist.Add(100);
//////        //    mylist.Add(-1);
//////        //    // We can loop over list items with foreach.

//////        //    foreach (int value in g)
//////        //    {
//////        //        Console.WriteLine(value);
//////        //    }



//////        //    //  foreach (var geofence in g)
//////        //    //  {
//////        //    //      Datos ins = new Datos
//////        //    //      {

//////        //    //          Id_emp = geofence.Id_emp,
//////        //    //          Id_vac = geofence.Id_vac,
//////        //    //          Fecha = geofence.Fecha

//////        //    //      };
//////        //    //      //this._context.Par_vac.InsertOnSubmit(ins);
//////        //    //      this._context.Par_vac.Add(ins);
//////        //    //  }
//////        //    //  //            this._context.SubmitChanges();
//////        //    //  this._context.SaveChanges();
//////        //    ////  return Ok();

//////        //    //using (Datos db = new Datos())
//////        //    //{
//////        //    //Datos model = new Datos();

//////        //    //model.Id_emp = 1;
//////        //    //model.Id_vac = 1;
//////        //    //model.Fecha = "2019-11-01";

//////        //    //}
//////        //    //return Ok()
//////        //}

//////        [HttpPost]     
//////        public async Task<IActionResult> Post([FromBody]Datos [] pa)
//////        {

//////            foreach (var geofence in pa)
//////            {
//////                Datos ins = new Datos
//////                {

//////                    Id_emp = geofence.Id_emp,
//////                    Id_vac = geofence.Id_vac,
//////                    Fecha = geofence.Fecha

//////                };
//////                this._context.Par_vac.Add(ins);
//////            }
//////            this._context.SaveChanges();
//////            await _context.SaveChangesAsync();
//////            return NoContent();

//////        }

//////        [HttpGet("{id}")]
//////        public async Task<ActionResult<Datos>> GetTodoItem(int id)
//////         {
//////            var todoItem = await _context.Par_vac.FindAsync(id);

//////            if (todoItem == null)
//////            {
//////                return NotFound();
//////            }

//////            return todoItem;
//////        }

//////    }
//////}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using API_BU.Models;
//using API_BU.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Cors;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;


//namespace API_BU.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class Par_VacController : ControllerBase
//    {
//        private readonly DepPuestoContexto _context;
//        public Par_VacController(DepPuestoContexto contexto)
//        {
//            _context = contexto;
//        }
//        [HttpPost]
//        //public async Task<ActionResult<Datos>> New(Datos item)
//        //{
//        //    try
//        //    {
//        //        //if (!this.ModelState.IsValid)
//        //        //{
//        //        //    return BadRequest();

//        //        //}
//        //        foreach (var g in item.Arr)
//        //        {
//        //            Pr_vac ins = new Pr_vac
//        //            {
//        //                //Id = g.Id,
//        //                Id_emp = g.Id,
//        //                Id_vac = g.Id_vac,
//        //                Fecha = g.Fecha

//        //            };
//        //            _context.Par_vac.Add(ins);
//        //        }
//        //        _context.Par_vac.Add(item);
//        //        _context.SaveChanges();
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        Console.WriteLine(ex.ToString());
//        //    }
//        //    return Ok(item);

//        //    //foreach (var g in item.Arr)
//        //    //{
//        //    //    Pr_vac ins = new Pr_vac
//        //    //    {
//        //    //        //Id = g.Id,
//        //    //        Id_emp = g.Id_emp,
//        //    //        Id_vac = g.Id_vac,
//        //    //        Fecha = g.Fecha

//        //    //    };
//        //    //    _context.Par_vac.Add(ins);
//        //    //}
//        //    //this._context.SaveChanges();
//        //    //await _context.SaveChangesAsync();
//        //    //return Ok(item);
//        }
//    }
//}

////        private readonly DepPuestoContexto _context;
////        public Par_VacController(DepPuestoContexto contexto)
////        {
////            _context = contexto;
////        }

////        public object Mapper { get; private set; }

////        [HttpGet]
////        public async Task<ActionResult<IEnumerable<Datos>>> GetVac()
////        {
////            //return await _context.Par_vac.ToListAsync();
////            return NoContent();
////        }

////        //[HttpPost]
////        //public async Task<IActionResult> AddVac([FromBody] Datos[] arr)
////        //public void GetTemplates(IEnumerable<string> emailAddresses)
////        //{
////        //    if (!this.ModelState.IsValid)
////        //    {
////        //       // return BadRequest();

////        //    }
////        //    //foreach (var geofence in arr)
////        //    // {
////        //    //        Datos ins = new Datos
////        //    //    {

////        //    //        Id_emp = geofence.Id_emp,
////        //    //        Id_vac = geofence.Id_vac,
////        //    //        Fecha = geofence.Fecha

////        //    //    };
////        //    //    this._context.Par_vacc.Add(ins);
////        //    //}
////        //    //foreach (var orp in arr)
////        //    //{
////        //    //    _context.Par_vacc.Add(orp);
////        //    //    _context.SaveChanges();
////        //    //}


////        //    //this._context.Par_vacc.Add(vac);
////        //    //this._context.SaveChanges();
////        //    // await _context.SaveChangesAsync();
////        //    //return Ok(arr);

////        //    foreach (var email in emailAddresses)
////        //    {
////        //        var promotionDto = new Datos
////        //        {
////        //            Id_emp = promotionDto.Id_emp,
////        //            Id_vac = promotionDto.Id_vac,
////        //            Fecha = promotionDto.Fecha,

////        //        };
////        //        //Add(promotionDto);

////        //    }


////        //}


////        [HttpPost]
////        public async Task<ActionResult<Vacaciones>> Post()
////        {
////            //var context = new DepPuestoContexto();
////            var author = new Datos { Id = 1 };
////            var books = new List<Pr_vac> {
////            new Pr_vac { Id = 1, Id_vac = 1,Fecha="2019-11-01" }

////        };
////        _context.AddRange(books);
////        _context.SaveChanges();

////            //using (_context)
////            //{
////            //    foreach (var g in item.Arr)
////            //    {
////            //        //var car = _context.Par_vacc.SingleOrDefault(x => x.Id == Id);
////            //        //if (car == null)
////            //        //{
////            //        Pr_vac ins = new Pr_vac
////            //        {
////            //            Id = g.Id,
////            //            Id_emp = g.Id_emp,
////            //            Id_vac = g.Id_vac,
////            //            Fecha = g.Fecha

////            //        };

////            //            _context.Par_vacc.Add(ins);
////            //        //}
////            //        ins.Id = Id;
////            //    }
////            //    _context.SaveChanges();
////            //}


////            //foreach (var g in item.Arr)
////            // {
////            //     Pr_vac ins = new Pr_vac
////            //     {
////            //         Id=g.Id,
////            //         Id_emp = g.Id_emp,
////            //         Id_vac = g.Id_vac,
////            //         Fecha = g.Fecha

////            //     };
////            //     _context.Par_vacc.AddRange(ins);


////            // }
////            // _context.SaveChanges();
////            return Ok(item);
////        }

////    }
////}